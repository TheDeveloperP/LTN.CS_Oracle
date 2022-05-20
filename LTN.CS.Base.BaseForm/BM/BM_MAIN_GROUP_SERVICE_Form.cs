using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;
using System.Threading;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_MAIN_GROUP_SERVICE_Form : CoreForm
    {
        #region 实例变量
        public IBMMAINASSEMBLYService mainassemblyService { get; set; }
        public IBMMAINGROUPService mainGroupService { get; set; }
        public IBMMAINPAGEService pageService { get; set; }
        public IBMSERVERService serverService { get; set; }
        public IBMMAINGROUPSERVICEService groupMServices { get; set; }
        private BM_MAIN_GROUP_SERVICE groupMSelect { get; set; }
        private BM_MAIN_GROUP mainGroupSelect { get; set; }
        BM_MAIN_ASSEMBLY assemblySelect = new BM_MAIN_ASSEMBLY();
        bool execute = true;
        public IList<TreeListNode> roots = new List<TreeListNode>();
        //当前执行事件
        private EventHandler eventNow;
        private int selectId { get; set; }
        private bool changeRow = true;
        #endregion

        #region 构造函数
        public BM_MAIN_GROUP_SERVICE_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_MAIN_GROUP_SERVICE_Form_Load(object sender, EventArgs e)
        {
            InitTree();
            ResetEditerUI(false);
            SetServiceNameData();
            SetAssemblyNameData();
            SetBtnEnable();
        }

        /// <summary>
        /// 节点展开前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (e.Node.Nodes.Count < 1)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                Cursor.Current = currentCursor;
            }
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_sure.Click -= eventNow;
            eventNow = null;
            dxErrorProvider1.ClearErrors();
            ResetEditerUI(false);
            gvw_main_FocusedRowChanged(null, null);
            SetBtnEnable();
            execute = true;
        }
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true);
            ClearUI();
            SetBtnNoEnable();
            eventNow = CustomAdd;
            btn_sure.Click += eventNow;
            execute = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (groupMSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
            {
                if (MessageDxUtil.ShowYesNoAndTips("删除后无法恢复，是否确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    CustomDelete();
                    ResetEditerUI(false);
                }
            }
            else
            {
                MessageDxUtil.ShowError("该用户为启用状态，无法删除，请先禁用该用户！");
            }
            execute = true;
        }
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true);
            SetBtnNoEnable();
            eventNow = CustomUpdate;
            btn_sure.Click += eventNow;
            execute = false;
        }
        /// <summary>
        /// 切换页面焦点方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(eventNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    groupMSelect = gvw_main.GetFocusedRow() as BM_MAIN_GROUP_SERVICE;
                    selectId = groupMSelect.IntId;
                    SetUIValue();
                }
                else
                {
                    groupMSelect = new BM_MAIN_GROUP_SERVICE();
                    selectId = -1;
                    SetUIValueNull();
                }
                ChangeBtnText();
            }
            
        }
        /// <summary>
        /// 下拉触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lud_Service_Enter(object sender, EventArgs e)
        {
            SetServiceNameData();
        }
        /// <summary>
        /// 焦点切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (changeRow)
            {
                if (treeList1.FocusedNode != null && treeList1.FocusedNode.GetValue("Type").ToString() == "Group")
                {
                    mainGroupSelect = e.Node.Tag as BM_MAIN_GROUP;
                }
                else
                {
                    mainGroupSelect = null;
                }
                SetGridData(true);
            }
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
            else
            {
                e.NodeImageIndex = 2;
            }
        }
        /// <summary>
        /// 选择图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            CheckState check = (CheckState)e.Node.GetValue("Check");
            if (check == CheckState.Unchecked)
                e.NodeImageIndex = 0;
            else if (check == CheckState.Checked)
                e.NodeImageIndex = 1;
            else e.NodeImageIndex = 2;
        }
        /// <summary>
        /// 程序集下拉绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetAssemblyNameData(object sender, EventArgs e)
        {
            SetAssemblyNameData();
        }
        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
                SetCheckedNode(treeList1.FocusedNode);
            if (e.KeyData == Keys.Enter)
            {
                if (treeList1.FocusedNode.HasChildren) treeList1.FocusedNode.Expanded = !treeList1.FocusedNode.Expanded;
            }
        }

        /// <summary>
        /// 作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Diabled_Click(object sender, EventArgs e)
        {
            CustomDisable();
        }

        #endregion

        #region 自定义方法

        /// <summary>
        /// 初始化树的数据
        /// </summary>
        private void InitTree()
        {
            try
            {
                if (pageService != null)
                {
                    changeRow = false;
                    treeList1.BeginUnboundLoad();
                    treeList1.ClearNodes();
                    IList<BM_MAIN_PAGE> pages = pageService.ExecuteDB_QueryAll();
                    if (pages != null && pages.Count > 0)
                    {
                        foreach (BM_MAIN_PAGE page in pages)
                        {
                            TreeListNode node = treeList1.AppendNode(new object[] { page.IntId, page.Index, page.Text, "Page", false }, null);
                            node.Tag = page;
                            node["Check"] = CheckState.Unchecked;
                            IList<BM_MAIN_GROUP> list = mainGroupService.ExecuteDB_QueryByPageId(page.IntId);
                            if (list != null && list.Count > 0)
                            {
                                node.HasChildren = true;
                                InitTreeLeafForFirst(list, node);
                            }
                            else
                            {
                                node.HasChildren = false;
                            }
                            roots.Add(node);

                        }
                    }
                    treeList1.EndUnboundLoad();
                    changeRow = true;
                }
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// /设定节点状态
        /// </summary>
        /// <param name="node"></param>
        private void SetCheckedNode(TreeListNode node)
        {
            CheckState check = (CheckState)node.GetValue("Check");
            //if (check == CheckState.Checked) check = CheckState.Checked;
            //else check = CheckState.Unchecked;
            treeList1.FocusedNode = node;
            treeList1.BeginUpdate();
            node["Check"] = check;
            node.CheckState = check;
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
            treeList1.EndUpdate();
        }
        /// <summary>
        /// 设定服务名称的下来选单数据
        /// </summary>
        private void SetServiceNameData()
        {
            try
            {
                IList<BM_SERVICE> users = serverService.ExecuteDB_QueryServerId(1);
                lud_Service.Properties.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitTreeLeafForFirst(IList<BM_MAIN_GROUP> groups, TreeListNode node)
        {
            foreach (BM_MAIN_GROUP group in groups)
            {
                TreeListNode nodeTemp = treeList1.AppendNode(new object[] { group.IntId, group.Index,"    "+group.Text, "Group", false }, node);
                nodeTemp.Tag = group;
                nodeTemp["Check"] = CheckState.Unchecked;
                nodeTemp.HasChildren = false;
                roots.Add(nodeTemp);
            }
        }
        /// <summary>
        /// 设定子节点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i]["Check"] = check;
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设定父节点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (!check.Equals(node.ParentNode.Nodes[i]["Check"]))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode["Check"] = b ? CheckState.Indeterminate : check;
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        /// <summary>
        /// 设定Assembly的下拉选单数据
        /// </summary>
        private void SetAssemblyNameData()
        {
            try
            {
                IList<BM_MAIN_ASSEMBLY> users = mainassemblyService.ExecuteDB_QueryAll();
                cbx_Assembly.Properties.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 设定UI不可用
        /// </summary>
        private void ClearUI()
        {
            lud_Service.EditValue = null;
            txt_No.Text = string.Empty;
            cbx_Assembly.EditValue = null;
            txt_Spic.Text = string.Empty;
            txt_Lpic.Text = string.Empty;
            chk_Isforbiden.Checked = false;
        }
        /// <summary>
        /// 设定编辑区是否可用
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="cc"></param>
        protected virtual void ResetEditerUI(bool flag)
        {
            lud_Service.Enabled = flag;
            txt_No.Enabled = flag;
            cbx_Assembly.Enabled = flag;
            txt_Spic.Enabled = flag;
            txt_Lpic.Enabled = flag;
            chk_Isforbiden.Enabled = flag;
        }
        /// <summary>
        /// 设定按钮
        /// </summary>
        private void SetBtnEnable()
        {
            btn_add.Enabled = true;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            btn_ISFORBID.Enabled = true;
            btn_sure.Enabled = false;
            btn_cancel.Enabled = false;
        }
        /// <summary>
        /// 设定按钮
        /// </summary>
        private void SetBtnNoEnable()
        {
            btn_add.Enabled = false;
            btn_update.Enabled = false;
            btn_sure.Enabled = true;
            btn_cancel.Enabled = true;
            btn_delete.Enabled = false;
            btn_ISFORBID.Enabled = false;
        }
        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValue()
        {
            groupMSelect = gvw_main.GetFocusedRow() as BM_MAIN_GROUP_SERVICE;
            lud_Service.EditValue = groupMSelect.Service.IntId;
            txt_No.Text = groupMSelect.Index.ToString();
            txt_Spic.Text = groupMSelect.Glyph;
            txt_Lpic.Text = groupMSelect.LargeGlyph;
            cbx_Assembly.EditValue = groupMSelect.MainAssembly.IntId;
            chk_Isforbiden.Checked = groupMSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
        }
        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValueNull()
        {
            lud_Service.EditValue = null;
            txt_No.Text = "";
            txt_Spic.Text = "";
            txt_Lpic.Text = "";
            cbx_Assembly.EditValue = null;
            chk_Isforbiden.Checked = false;
        }
        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetgroupMSelect(bool isAdd)
        {
            if (isAdd)
            {
                groupMSelect = new BM_MAIN_GROUP_SERVICE() { CreateEMPId = (SessionHelper.LogUser as BM_USER), CreateUser = (SessionHelper.LogUser as BM_USER) };
            }
            groupMSelect.Group = new BM_MAIN_GROUP() { IntId = mainGroupSelect.IntId };
            groupMSelect.Service = new BM_SERVICE() { IntId = Convert.ToInt32(lud_Service.EditValue) };
            groupMSelect.Index = Convert.ToInt32(txt_No.Text);
            groupMSelect.MainAssembly = mainassemblyService.ExecuteDB_QueryById((int)cbx_Assembly.EditValue);
            groupMSelect.Glyph = txt_Spic.Text;
            groupMSelect.LargeGlyph = txt_Lpic.Text;
            groupMSelect.IsForbid = chk_Isforbiden.Checked ? new EntityInt(1) : new EntityInt(0);
            groupMSelect.UpdateUser = SessionHelper.LogUser as BM_USER;
        }

        /// <summary>
        /// 验证画面输入
        /// </summary>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        private bool Verify(bool isAdd)
        {
            dxErrorProvider1.ClearErrors();
            bool isOk = true;
            if (lud_Service.EditValue == null)
            {
                dxErrorProvider1.SetError(lud_Service, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (cbx_Assembly.EditValue == null)
            {
                dxErrorProvider1.SetError(cbx_Assembly, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_Spic.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_Spic, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_No.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_No, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            else if (txt_No.Text != "0" && MyNumberHelper.ConvertToInt32(txt_No.Text)<=0)
            {
                dxErrorProvider1.SetError(txt_No, "该栏位为正整数", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_Lpic.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_Lpic, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            return isOk;
        }
        /// <summary>
        /// 用户自定义禁用
        /// </summary>
        private void CustomDisable()
        {
            try
            {
                if (groupMSelect != null && groupMSelect.IsForbid!=null)
                {
                    groupMSelect.IsForbid = groupMSelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = groupMServices.ExecuteDB_DisableSERVICEMENU(groupMSelect);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                        return;
                    }
                    SetGridData(false);
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }
        /// <summary>
        /// 焦点行转换
        /// </summary>
        private void SetLeftFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    BM_MAIN_GROUP_SERVICE user = gvw_main.GetRow(i) as BM_MAIN_GROUP_SERVICE;
                    if (user.IntId == selectId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        //selectId = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectId)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectId = rowcount - 1;
                }
                else if (selectId == 0)
                {
                    gvw_main.FocusedRowHandle = 0;
                    selectId = 0;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectId;
                }
            }
        }
        /// <summary>
        /// 改变按钮文本
        /// </summary>
        private void ChangeBtnText()
        {
            if (groupMSelect != null && groupMSelect.IsForbid != null)
            {
                btn_ISFORBID.Text = groupMSelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = groupMSelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16 : global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomAdd(object sender, EventArgs e)
        {
            if (!Verify(true))
            {
                return;
            }
            try
            {
                ReSetgroupMSelect(true);
                var rs = groupMServices.ExecuteDB_InserUser(groupMSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    return;
                }
                selectId = MyNumberHelper.ConvertToInt32(rs);
                SetGridData(false);
                ResetEditerUI(false);
                SetBtnEnable();
                btn_sure.Click -= eventNow;
                eventNow = null;
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
            execute = true;
        }

        /// <summary>
        /// 设定Grid数据
        /// </summary>
        private void SetGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    try
                    {
                        int selectIdOld = selectId;
                        IList<BM_MAIN_GROUP_SERVICE> list = null;
                        if (treeList1.FocusedNode.GetValue("Type").ToString() == "Group")
                        {
                            int groupId = MyNumberHelper.ConvertToInt32(treeList1.FocusedNode.GetValue("IntId"));
                            list = groupMServices.ExecuteDB_QueryByGroupId(groupId);
                        }
                        gcl_center.DataSource = list;
                        gvw_main.BestFitColumns();
                        if (!isFirst)
                        {
                            selectId = selectIdOld;
                            SetLeftFocusRow();
                            gvw_main_FocusedRowChanged(null, null);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 用户自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDelete()
        {
            try
            {
                BM_USER users = SessionHelper.LogUser as BM_USER;
                if (groupMSelect.CreateEMPId.IntId != users.IntId)
                {
                    MessageDxUtil.ShowError("当前用户无删除权限！");
                    return;
                }
                ReSetgroupMSelect(false);
                var rs = groupMServices.ExecuteDB_DeleteUser(groupMSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    return;
                }
                SetGridData(false);
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }

        /// <summary>
        /// 用户自定义修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomUpdate(object sender, EventArgs e)
        {
            BM_USER users = SessionHelper.LogUser as BM_USER;
            if (groupMSelect.CreateEMPId.IntId != users.IntId)
            {
                MessageDxUtil.ShowError("当前用户无修改权限！");
                return;
            }
            if (!Verify(false))
            {
                return;
            }
            try
            {
                ReSetgroupMSelect(false);
                var rs = groupMServices.ExecuteDB_UpdateUser(groupMSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    return;
                }
                SetGridData(false);
                ResetEditerUI(false);
                SetBtnEnable();
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
            finally
            {
                btn_sure.Click -= eventNow;
                eventNow = null;
            }
            execute = true;
        }
        #endregion

    }
}
