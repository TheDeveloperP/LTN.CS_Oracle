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
using LTN.CS.Core.Helper;
using System.Threading;
using DevExpress.XtraEditors;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_MAINASSEMBLY_Form : CoreForm
    {
        #region 实例变量
        public IBMUSERService userService { get; set; }
        private BM_MAIN_ASSEMBLY assemblySelect { get; set; }
        public IBMMAINASSEMBLYService assemblyService { get; set; }
        //当前执行事件
        private EventHandler eventNow;
        private int selectId { get; set; }
        #endregion

        #region 构造函数
        public BM_MAINASSEMBLY_Form()
        {
            InitializeComponent();
        }
        #endregion
        
        #region 控件事件
        /// <summary>
        /// 下拉触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_ManageEMPId_Enter(object sender, EventArgs e)
        {
            SetManageEMPIdData();
        }

        /// <summary>
        /// 界面加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_MAINASSEMBLY_Form_Load(object sender, EventArgs e)
        {
            SetManageEMPIdData();
            SetGridData(true);
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
            
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            ResetEditerUI(false);
            btn_sure.Click -= eventNow;
            eventNow = null;
            gvw_main_FocusedRowChanged(null, null);
            SetBtnEnable();
        }

        /// <summary>
        /// Grid视图焦点行切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    assemblySelect = gvw_main.GetFocusedRow() as BM_MAIN_ASSEMBLY;
                    selectId = assemblySelect.IntId;
                    SetUIValue();
                    ChangeBtnText();
                }
            }
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
        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (assemblySelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
            {
                if (MessageDxUtil.ShowYesNoAndTips("删除后无法恢复，是否确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    CustomDelete();
                }
            }
            else
            {
                MessageDxUtil.ShowError("该用户为启用状态，无法删除，请先禁用该用户！");
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
            if (assemblySelect != null && assemblySelect.IsForbid != null)
            {
                btn_ISFORBID.Text = assemblySelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = assemblySelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16 : global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
        }
        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValue()
        {
            txt_AssemblyName.Text = assemblySelect.AssemblyName;
            txt_AssemblyShortName.Text = assemblySelect.AssemblyShortName;
            txt_ManageEMPId.EditValue = assemblySelect.ManageEMPId.IntId;
            chk_Isforbid.Checked = assemblySelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;

        }
        /// <summary>
        /// 设定编辑区是否可用
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="cc"></param>
        protected virtual void ResetEditerUI(bool flag)
        {
            txt_AssemblyName.Enabled = flag;
            txt_AssemblyShortName.Enabled = flag;
            txt_ManageEMPId.Enabled = flag;
            chk_Isforbid.Enabled = flag;
        }
        /// <summary>
        /// 设定UI不可用
        /// </summary>
        private void ClearUI()
        {
            txt_AssemblyName.Text = string.Empty;
            txt_AssemblyShortName.Text = string.Empty;
            txt_ManageEMPId.EditValue = null;
            chk_Isforbid.Checked = false;

        }
        /// <summary>
        /// 设定管理人员的下来选单数据
        /// </summary>
        private void SetManageEMPIdData()
        {
            try
            {
                IList<BM_USER> users = userService.ExecuteDB_QueryAll();
                users = users.Where<BM_USER>(p => p.IsForbid.EntityValue.Equals((Int32)IntBool.No)).ToList<BM_USER>();
                txt_ManageEMPId.Properties.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
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
        private void SetBtnNoEnable(){
            btn_add.Enabled = false;
            btn_update.Enabled = false;
            btn_sure.Enabled = true;
            btn_cancel.Enabled = true;
            btn_delete.Enabled = false;
            btn_ISFORBID.Enabled = false;
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
                    gcl_center.DataSource = assemblyService.ExecuteDB_QueryAll();
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectId = selectIdOld;
                        SetLeftFocusRow();
                        gvw_main_FocusedRowChanged(null, null);
                    }
                    ResetEditerUI(false);
                    SetBtnEnable();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 焦点行转换
        /// </summary>
        private void SetLeftFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectId != 0)
            {for (int i = 0; i < rowcount; i++)
                {
                    BM_MAIN_ASSEMBLY user = gvw_main.GetRow(i) as BM_MAIN_ASSEMBLY;
                    if (user.IntId == selectId)
                    {
                        gvw_main.FocusedRowHandle = i;
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
        /// 验证画面输入
        /// </summary>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        private bool Verify(bool isAdd)
        {
            dxErrorProvider1.ClearErrors();
            bool isOk = true;
            if (txt_AssemblyName.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_AssemblyName, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            else
            {
                IList<BM_MAIN_ASSEMBLY> pages = assemblyService.SelectByAssemblyName(txt_AssemblyName.Text);
                if (isAdd)
                {
                    if (pages != null && pages.Count > 0)
                    {
                        dxErrorProvider1.SetError(txt_AssemblyName, "页面名称已存在", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }
                else
                {
                    if (pages != null && pages.Count > 0 && txt_AssemblyName.Text != assemblySelect.AssemblyName)
                    {
                        dxErrorProvider1.SetError(txt_AssemblyName, "页面名称已存在", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }

            }
            if (txt_AssemblyShortName.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_AssemblyShortName, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            if (txt_ManageEMPId.EditValue == null)
            {
                dxErrorProvider1.SetError(txt_ManageEMPId, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }

            return isOk;
        }
        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetassemblySelect(bool isAdd)
        {
            if (isAdd)
            {
                assemblySelect = new BM_MAIN_ASSEMBLY() { CreateUser = (SessionHelper.LogUser as BM_USER), CreateEMPId = (SessionHelper.LogUser as BM_USER) };
            }
            assemblySelect.AssemblyName = txt_AssemblyName.Text;
            assemblySelect.AssemblyShortName = txt_AssemblyShortName.Text;
            assemblySelect.ManageEMPId = new BM_USER() { IntId = MyNumberHelper.ConvertToInt32(txt_ManageEMPId.EditValue) };
            assemblySelect.IsForbid = chk_Isforbid.Checked ? new EntityInt(1) : new EntityInt(0);
            assemblySelect.UpdateUser = SessionHelper.LogUser as BM_USER;
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
                ReSetassemblySelect(true);
                var rs = assemblyService.ExecuteDB_InsertmainAssembly(assemblySelect);
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
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
        }

        /// <summary>
        /// 用户自定义修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomUpdate(object sender, EventArgs e)
        {
            if (!Verify(false))
            {
                return;
            }
            bool isexception = false;
            try
            {
                ReSetassemblySelect(false);
                var rs = assemblyService.ExecuteDB_UpdatemainAssembly(assemblySelect);
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
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
        }
        /// <summary>
        /// 用户自定义禁用
        /// </summary>
        private void CustomDisable()
        {
            try
            {
                if (assemblySelect != null && assemblySelect.IsForbid != null)
                {
                    assemblySelect.IsForbid = assemblySelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = assemblyService.ExecuteDB_Disabled(assemblySelect);
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
        /// 用户自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDelete()
        {
            try
            {
                ReSetassemblySelect(false);
                var rs = assemblyService.ExecuteDB_DeletemainAssembly(assemblySelect);
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

        #endregion
    }
}
