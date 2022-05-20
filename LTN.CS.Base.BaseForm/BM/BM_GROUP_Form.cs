using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LTN.CS.Base.BusinessService.BM.Interface;
using System.Threading;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;
using System.Linq;


namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_GROUP_Form : CoreForm
    {
        #region 实例变量
        public IBMGROUPService groupServices { get; set; }
        private BM_GROUP groupSelect { get; set; }
        public IBMUSERService userService { get; set; }
        //当前执行事件
        private EventHandler eventNow;
        private int selectId { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BM_GROUP_Form()
        {
            InitializeComponent();
        }
        #endregion·

        #region 控件事件
        /// <summary>
        /// 界面加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_GROUP_Form_Load(object sender, EventArgs e)
        {
            SetNamageNameData();
            SetGridData(true);
            ResetEditerUI(false, layoutControl1);
            SetBtnEnable();
            groupSelect = new BM_GROUP();

        }

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            ClearUI();
            SetBtnNoEnable();
            eventNow = CustomAdd;
            btn_sure.Click += eventNow;
        }
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            SetBtnNoEnable();
            eventNow = CustomUpdate;
            btn_sure.Click += eventNow;
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
            ResetEditerUI(false, layoutControl1);
            gvw_main_FocusedRowChanged(null, null);
            SetBtnEnable();
        }
        /// <summary>
        /// 切换页面焦点方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventNow == null)
            {

                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    groupSelect = gvw_main.GetFocusedRow() as BM_GROUP;
                    selectId = groupSelect.IntId;
                    SetUIValue();
                }
                else
                {
                    groupSelect = new BM_GROUP();
                    selectId = -1;
                    SetUIValueNull();
                }
                ChangeBtnText();

                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    groupSelect = gvw_main.GetFocusedRow() as BM_GROUP;
                    selectId = groupSelect.IntId;
                    SetUIValue();
                }
            }
            
        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (groupSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
            {
                if (MessageDxUtil.ShowYesNoAndTips("删除后无法恢复，是否确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    CustomDelete();
                }
            }
            else
            {
                MessageDxUtil.ShowError("该群组为启用状态，无法删除，请先禁用该群组！");
            }
        }
        /// <summary>
        /// 禁用按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ISFORBID_Click(object sender, EventArgs e)
        {
            CustomDisable();
        }

       
        #endregion

        #region 自定义方法

        /// <summary>
        /// 改变按钮文本
        /// </summary>
        private void ChangeBtnText()
        {
            if (groupSelect != null && groupSelect.IsForbid != null)
            {
                btn_ISFORBID.Text = groupSelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = groupSelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16 : global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
        }
        /// <summary>
        /// 查询管理员下拉控件
        /// </summary>
        private void SetNamageNameData()
        {
            try
            {
                IList<BM_USER> user = userService.ExecuteDB_QueryAll();
                user = user.Where<BM_USER>(p => p.IsForbid.EntityValue.Equals((Int32)IntBool.No)).ToList<BM_USER>();
                lud_ManaName.Properties.DataSource = user;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
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
                    int selectIdOld = selectId;
                    gcl_center.DataSource = groupServices.ExecuteDB_QueryAll();
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectId = selectIdOld;
                        SetLeftFocusRow();
                        gvw_main_FocusedRowChanged(null, null);
                    }
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);

        }

        /// <summary>
        /// 设定UI不可用
        /// </summary>
        private void ClearUI()
        {
            txt_GroupNo.Text = string.Empty;
            txt_GroupName.Text = string.Empty;
            txt_GroupDescription.Text = string.Empty;
            lud_ManaName.EditValue = null;
            chk_Isforbiden.Checked = false;
        }
        /// <summary>
        /// 设定编辑区是否可用
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="cc"></param>
        protected virtual void ResetEditerUI(bool flag, Control cc)
        {
            Control.ControlCollection ccs = cc.Controls;
            int n;
            if ((n = ccs.Count) > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Control ctl = ccs[i];
                    if (ctl.GetType().IsSubclassOf(typeof(BaseEdit)))
                    {
                        ctl.Enabled = flag;
                    }
                }
            }
        }

        /// <summary>
        /// 设定按钮
        /// </summary>
        private void SetBtnEnable()
        {
            btn_add.Enabled = true;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            btn_sure.Enabled = false;
            btn_cancel.Enabled = false;
            btn_ISFORBID.Enabled = true;
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
            txt_GroupNo.Text = groupSelect.GroupNo;
            txt_GroupName.Text = groupSelect.GroupName;
            txt_GroupDescription.Text = groupSelect.GroupDes;
            lud_ManaName.EditValue = groupSelect.ManageEMPId.IntId;
            chk_Isforbiden.Checked = groupSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
        }
        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValueNull()
        {
            txt_GroupNo.Text = "";
            txt_GroupName.Text = "";
            txt_GroupDescription.Text = "";
            lud_ManaName.EditValue = null;
            chk_Isforbiden.Checked = false;
        }
        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetgroupSelect(bool isAdd)
        {
            if (isAdd)
            {
                groupSelect = new BM_GROUP() { CreateEMPId = (SessionHelper.LogUser as BM_USER), CreateUser = (SessionHelper.LogUser as BM_USER) };
            }
            groupSelect.GroupNo = txt_GroupNo.Text;
            groupSelect.GroupName = txt_GroupName.Text;
            groupSelect.GroupDes = txt_GroupDescription.Text;
            groupSelect.ManageEMPId = new BM_USER() { IntId = MyNumberHelper.ConvertToInt32(lud_ManaName.EditValue) }; ;
            groupSelect.IsForbid = chk_Isforbiden.Checked ? new EntityInt(1) : new EntityInt(0);
            groupSelect.UpdateUser = SessionHelper.LogUser as BM_USER;
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
            if (lud_ManaName.EditValue == null)
            {
                dxErrorProvider1.SetError(lud_ManaName, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_GroupNo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_GroupNo, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_GroupName.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_GroupName, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            else
            {
                BM_GROUP user = groupServices.ExecuteDB_QueryByName(txt_GroupName.Text);
                if (isAdd)
                {
                    if (user != null)
                    {
                        dxErrorProvider1.SetError(txt_GroupName, "该群组名已注册", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }
                else
                {
                    if (user != null && txt_GroupName.Text != groupSelect.GroupName)
                    {
                        dxErrorProvider1.SetError(txt_GroupName, "该群组名已注册", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }
            }
            return isOk;
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
            bool isexception = false;
            try
            {
                ReSetgroupSelect(true);
                var rs = groupServices.ExecuteDB_InserGROUP(groupSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                selectId = MyNumberHelper.ConvertToInt32(rs);
                SetGridData(false);
            }
            catch (Exception ep)
            {
                isexception = true;
                MessageDxUtil.ShowError(ep.Message);
            }
            finally
            {
                if (!isexception)
                {
                    ResetEditerUI(false, layoutControl1);
                    SetBtnEnable();
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomUpdate(object sender, EventArgs e)
        {
            BM_USER users = SessionHelper.LogUser as BM_USER;
            bool isexception = false;
            if (groupSelect.CreateEMPId.IntId != users.IntId && groupSelect.ManageEMPId.IntId != users.IntId)
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
                ReSetgroupSelect(false);
                var rs = groupServices.ExecuteDB_UpdateGROUP(groupSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                SetGridData(false);
            }
            catch (Exception ep)
            {
                isexception = true;
                MessageDxUtil.ShowError(ep.Message);
            }
            finally
            {
                if (!isexception)
                {
                    ResetEditerUI(false, layoutControl1);
                    SetBtnEnable();
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
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
                BM_USER user = SessionHelper.LogUser as BM_USER;
                if (groupSelect.CreateEMPId.IntId != user.IntId && groupSelect.ManageEMPId.IntId != user.IntId)
                {
                    MessageDxUtil.ShowError("当前用户无删除权限！");
                    return;
                }
                ReSetgroupSelect(false);
                var rs = groupServices.ExecuteDB_DeleteGROUP(groupSelect);
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
        /// 用户自定义禁用
        /// </summary>
        private void CustomDisable()
        {
            try
            {
                if (groupSelect != null && groupSelect.IsForbid != null)
                {
                    groupSelect.IsForbid = groupSelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = groupServices.ExecuteDB_DisableDGROUP(groupSelect);
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
                    BM_GROUP user = gvw_main.GetRow(i) as BM_GROUP;
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
        #endregion


    }
}