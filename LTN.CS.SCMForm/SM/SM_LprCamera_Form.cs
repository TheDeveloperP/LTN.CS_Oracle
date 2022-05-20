using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_LprCamera_Form : CoreForm
    {
        #region 变量
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_LPRCamera selectMainEntity { get; set; }
        private bool queryMain { get; set; }
        public ISM_LPRCameraService MainService { get; set; }
        #endregion

        public SM_LprCamera_Form()
        {
            InitializeComponent();
        }
        private void SM_LprCamera_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(true);
        }
        #region 自定义方法
        private void ClearMainEditer()
        {
            txt_LPRFactory.EditValue = string.Empty;
            txt_ChannelNum.EditValue = string.Empty;
            txt_LPRIP1.EditValue = string.Empty;
            txt_LPRIP2.EditValue = string.Empty;
            txt_LPRModel.EditValue = string.Empty;
            txt_LPRSpec.EditValue = string.Empty;
            txt_Storage.EditValue = string.Empty;
            txt_userName.EditValue = string.Empty;
            txt_Port.EditValue = string.Empty;
            txt_Password.EditValue = string.Empty;
        }
        private void SetMainButtonEnabled(bool enabled)
        {

            btn_Add.Enabled = enabled;
            btn_update.Enabled = enabled;
            btn_Delete.Enabled = enabled;
            btn_Confirm.Enabled = !enabled;
            btn_Cancel.Enabled = !enabled;

        }

        private void SetMainEditerEnabled(bool enabled)
        {

            txt_LPRSpec.Enabled = enabled;
            txt_ChannelNum.Enabled = enabled;
            txt_LPRIP1.Enabled = enabled;
            txt_LPRIP2.Enabled = enabled;
            txt_LPRModel.Enabled = enabled;
            txt_LPRFactory.Enabled = enabled;
            txt_Storage.Enabled = enabled;
            txt_userName.Enabled = enabled;
            txt_Port.Enabled = enabled;
            txt_Password.Enabled = enabled;
            if (enabled)
            {
                txt_LPRFactory.Focus();
            }
            dxErrorProvider1.ClearErrors();

        }

        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAll();

                    gcl_main.DataSource = rss;

                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        //SetMainFocusRow();
                    }
                    queryMain = true;
                    SetMainEditerData();
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_LPRCamera;
                if (entity != null)
                {
                    SetMainEditer(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                selectMainEntity = entity;
                queryMain = true;
            }
        }
        private void SetMainEditer(SM_LPRCamera entity)
        {
            if (entity != null)
            {
                txt_LPRFactory.EditValue = entity.LPRFactory;
                txt_ChannelNum.EditValue = entity.ChannelNum;
                txt_LPRIP1.EditValue = entity.LPRIP1;
                txt_LPRModel.EditValue = entity.LPRSpec;
                txt_Storage.EditValue = entity.Storage;
                txt_LPRSpec.EditValue = entity.LPRModel;
                txt_LPRIP2.EditValue = entity.LPRIP2;
                txt_Password.EditValue = entity.Password;
                txt_Port.EditValue = entity.Port;
                txt_userName.EditValue = entity.Username;
            }
        }

        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertLPRInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void ResetSelectMainEntity()
        {
            if (txt_LPRFactory.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_LPRFactory, "硬盘录像机名称为必填！", ErrorType.Information);
                return;
            }
            if (txt_LPRIP1.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_LPRIP1, "IP地址1为必填！", ErrorType.Information);
                return;
            }
            //if (txt_LPRIP2.Text == string.Empty)
            //{
            //    dxErrorProvider1.SetError(txt_LPRIP2, "IP地址2为必填！", ErrorType.Information);
            //    return;
            //}
            var camera = MainService.ExecuteDB_QueryByLPRName(txt_LPRFactory.EditValue.ToString());
            if (eventMainNow.Method.Name == "CustomMainUpdate" && camera != null && camera.Count() > 0 && camera[0].IntId != selectMainEntity.IntId)
            {
                dxErrorProvider1.SetError(txt_LPRFactory, "硬盘录像机名称已经存在！", ErrorType.Information);
                return;
            }
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (camera != null && camera.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_LPRFactory, "硬盘录像机名称已经存在！", ErrorType.Information);
                    return;
                }
                selectMainEntity = new SM_LPRCamera()
                {
                    createUser = SessionHelper.LogUserNickName,
                    updateUser = SessionHelper.LogUserNickName
                };
            }
            selectMainEntity.ChannelNum = MyNumberHelper.ConvertToInt32(txt_ChannelNum.Text);
            selectMainEntity.LPRIP1 = txt_LPRIP1.Text;
            selectMainEntity.LPRSpec = txt_LPRModel.Text;
            selectMainEntity.LPRFactory = txt_LPRFactory.Text;
            selectMainEntity.LPRModel = txt_LPRSpec.Text;
            if (txt_Storage.Text != "") { selectMainEntity.Storage = MyNumberHelper.ConvertToInt32(txt_Storage.Text); }

            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
            selectMainEntity.LPRIP2 = txt_LPRIP2.Text;
            selectMainEntity.Password = txt_Password.Text;
            selectMainEntity.Port = txt_Port.Text;
            selectMainEntity.Username = txt_userName.Text;
            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
        }
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {

                    var rs = MainService.ExecuteDB_UpdateLPRInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeleteLPRInfo(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        #endregion

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
            SetMainGridData(false);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_LPRCamera;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
        }


    }
}
