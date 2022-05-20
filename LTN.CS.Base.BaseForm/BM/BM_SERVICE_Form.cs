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
    public partial class BM_SERVICE_Form : CoreForm
    {

        #region 实例变量
        public IBMUSERService userService { get; set; }

        private BM_SERVICE serviceSelect { get; set; }
        public IBMSERVERService serviceService { get; set; }
        //当前执行事件
        private EventHandler eventNow;
        private int selectId { get; set; }
        #endregion

        #region 构造函数
        public BM_SERVICE_Form()
        {
            InitializeComponent();
        }
        #endregion     
        
        #region 控件事件

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    serviceSelect = gvw_main.GetFocusedRow() as BM_SERVICE;
                    selectId = serviceSelect.IntId;
                    SetUIValue();
                    ChangeBtnText();
                }
            }
        }

        private void txt_lueManageEMPId_Enter(object sender, EventArgs e)
        {
            SetManageEMPIdData();
        }

        private void BM_SERVICE_Form_Load(object sender, EventArgs e)
        {
            SetManageEMPIdData();
            SetGridData(true);
            ResetEditerUI(false, layoutControl1);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            ClearUI();
            SetBtnNoEnable();
            eventNow = CustomAdd;
            btn_sure.Click += eventNow;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            SetBtnNoEnable();
            eventNow = CustomUpdate;
            btn_sure.Click += eventNow;
        }



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
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (serviceSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
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
        /// 禁用服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ISFORBID_Click(object sender, EventArgs e)
        {
            CustomDisable();
        }
        /// <summary>
        /// 限制服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Limited_Click(object sender, EventArgs e)
        {
            CustomLimit();
        }

        #endregion
       
        #region 自定义方法

        /// <summary>
        /// 用户自定义禁用
        /// </summary>
        private void CustomDisable()
        {
            try
            {
                if (serviceSelect != null && serviceSelect.IsForbid != null)
                {
                    serviceSelect.IsForbid = serviceSelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = serviceService.ExecuteDB_DisableService(serviceSelect);
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
        /// 用户自定义禁用
        /// </summary>
        private void CustomLimit()
        {
            try
            {
                if (serviceSelect != null && serviceSelect.IsForbid != null)
                {
                    serviceSelect.IsLimit = serviceSelect.IsLimit.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = serviceService.ExecuteDB_LimitedService(serviceSelect);
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
        /// 改变按钮文本
        /// </summary>
        private void ChangeBtnText()
        {
            if (serviceSelect != null && serviceSelect.IsForbid != null)
            {
                btn_ISFORBID.Text = serviceSelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = serviceSelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16 : global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
            if (serviceSelect != null && serviceSelect.IsLimit != null)
            {
                btn_Limited.Text = serviceSelect.IsLimit.EntityValue == 0 ? "限制" : "释放";
                btn_Limited.Image = serviceSelect.IsLimit.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.limited_24 : global::LTN.CS.Base.BaseForm.Properties.Resources.unlimited_24;
            }
        }

        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValue()
        {
            txt_ServiceNo.Text = serviceSelect.ServiceNo;
            txt_ServiceName.Text = serviceSelect.ServiceName;
            txt_ServiceDesc.Text = serviceSelect.ServiceDes;
            txt_lueManageEMPId.EditValue = serviceSelect.ManageEMPId.IntId;
            txt_chkIsForbid.Checked = serviceSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
            txt_chkIsLimit.Checked = serviceSelect.IsLimit.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
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
        /// 设定UI不可用
        /// </summary>
        private void ClearUI()
        {
            txt_ServiceNo.Text = string.Empty;
            txt_ServiceName.Text = string.Empty;
            txt_ServiceDesc.Text = string.Empty;
            txt_lueManageEMPId.EditValue = null;
            txt_chkIsForbid.Checked = false;
            txt_chkIsLimit.Checked = false;        
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
                txt_lueManageEMPId.Properties.DataSource = users;
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
            btn_Limited.Enabled = true;
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
            btn_Limited.Enabled = false;
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
                    gcl_center.DataSource = serviceService.ExecuteDB_QueryAll();                
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
                    BM_SERVICE user = gvw_main.GetRow(i) as BM_SERVICE;
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
            if (txt_ServiceNo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_ServiceNo, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }
            else
            {
                IList<BM_SERVICE> pages = null;// serviceService.ExecuteDB_QueryServiceNo(txt_ServiceNo.Text);
                if (isAdd)
                {
                    if (pages != null && pages.Count > 0)
                    {
                        dxErrorProvider1.SetError(txt_ServiceNo, "服务代码已存在", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }
                else
                {
                    if (pages != null && pages.Count > 0 && txt_ServiceNo.Text != serviceSelect.ServiceNo)
                    {
                        dxErrorProvider1.SetError(txt_ServiceNo, "服务代码已存在", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        isOk = false;
                    }
                }

            }

            if (txt_ServiceName.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_ServiceName, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }

            if (txt_lueManageEMPId.EditValue == null)
            {
                dxErrorProvider1.SetError(txt_lueManageEMPId, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }

            if (txt_ServiceDesc.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_ServiceDesc, "该栏位为必填", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                isOk = false;
            }

            return isOk;
        }
        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetPageSelect(bool isAdd)
        {
            if (isAdd)
            {
                serviceSelect = new BM_SERVICE() { CreateUser = (SessionHelper.LogUser as BM_USER), CreateEMPId = (SessionHelper.LogUser as BM_USER) };
            }            
            serviceSelect.ServiceNo = txt_ServiceNo.Text;
            serviceSelect.ServiceName = txt_ServiceName.Text;
            serviceSelect.ServiceDes = txt_ServiceDesc.Text;
            serviceSelect.ManageEMPId = new BM_USER() { IntId = MyNumberHelper.ConvertToInt32(txt_lueManageEMPId.EditValue) };
            serviceSelect.IsForbid = txt_chkIsForbid.Checked ? new EntityInt(1) : new EntityInt(0);
            serviceSelect.IsLimit = txt_chkIsLimit.Checked ? new EntityInt(1) : new EntityInt(0);
            serviceSelect.UpdateUser = SessionHelper.LogUser as BM_USER;
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
            BM_SERVICE servicNo = serviceService.ExecuteDB_QueryByNo(txt_ServiceNo.Text);
            if (servicNo != null)
            {
                MessageDxUtil.ShowError("该服务代码已经注册，请更改服务代码！");
                return;
            }

            try
            {
                ReSetPageSelect(true);
                var rs =  serviceService.ExecuteDB_Insert(serviceSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                selectId = MyNumberHelper.ConvertToInt32(rs);
                SetGridData(false);
                ResetEditerUI(false, layoutControl1);
                SetBtnEnable();
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
            BM_SERVICE servicNo = serviceService.ExecuteDB_QueryByNo(txt_ServiceNo.Text);
            if (servicNo != null && txt_ServiceNo.Text != serviceSelect.ServiceNo)
            {
                MessageDxUtil.ShowError("该服务代码已经注册，请更改服务代码！");
                return;
            }
            bool isexception = false;
            try
            {
                ReSetPageSelect(false);
                var rs =  serviceService.ExecuteDB_Update(serviceSelect);
                if (serviceSelect.IsLimit.EntityValue == (Int32)IntBool.No)
                {
                    
                }
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                SetGridData(false);
                ResetEditerUI(false, layoutControl1);
                SetBtnEnable();
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
        /// 用户自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDelete()
        {
            try
            {
                ReSetPageSelect(false);
                var rs =  serviceService.ExecuteDB_Delete(serviceSelect);
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
