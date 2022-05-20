using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_DVR_Form : CoreForm
    {
        #region 变量
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_Dvr_Info selectMainEntity { get; set; }
        private bool queryMain { get; set; }
        public ISM_Dvr_InfoService MainService { get; set; }

        public string AliasMeterName;
        #endregion
        #region 构造函数
        public SM_DVR_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void ClearMainEditer()
        {
            txt_DvrFactory.EditValue = string.Empty;
            txt_ChannelNub.EditValue = string.Empty;
            txt_DvrIP1.EditValue = string.Empty;
            txt_DvrIP2.EditValue = string.Empty;
            txt_DvrModel.EditValue = string.Empty;
            txt_DvrSpec.EditValue = string.Empty;
            txt_Storage.EditValue = string.Empty;
            txt_userName.EditValue = string.Empty;
            txt_Port.EditValue = string.Empty;
            txt_Password.EditValue = string.Empty;
        }
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertDvrInfo(selectMainEntity);
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

            if (txt_DvrFactory.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_DvrFactory, "硬盘录像机名称为必填！", ErrorType.Information);
                return;
            }

            if (eventMainNow.Method.Name == "CustomMainUpdate")
            {


            }

            //if (eventMainNow.Method.Name == "CustomMainUpdate")
            //{

            //    if (!AliasMeterName.Equals(txt_DvrFactory.EditValue.ToString()))
            //    {

            //        Boolean b = IsNotExist(txt_DvrFactory.EditValue.ToString());
            //        if (b == false)
            //        {
            //            dxErrorProvider1.SetError(txt_DvrFactory, "硬盘录像机名称已经存在！", ErrorType.Information);
            //            return;
            //        }

            //    }
            //}
            if (txt_DvrIP1.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_DvrIP1, "IP地址1为必填！", ErrorType.Information);
                return;
            }
            //if (txt_DvrIP2.EditValue == string.Empty)
            //{
            //    dxErrorProvider1.SetError(txt_DvrIP2, "IP地址2为必填！", ErrorType.Information);
            //    return;
            //}

            if (eventMainNow.Method.Name == "CustomMainUpdate")
            {

                if (!AliasMeterName.Equals(txt_DvrFactory.EditValue.ToString()))
                {

                    Boolean b = IsNotExist(txt_DvrFactory.EditValue.ToString());
                    if (b == false)
                    {
                        dxErrorProvider1.SetError(txt_DvrFactory, "硬盘录像机名称已经存在！", ErrorType.Information);
                        return;
                    }

                }
            }
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_Dvr_Info()
                {
                    createUser = SessionHelper.LogUserNickName,
                    updateUser = SessionHelper.LogUserNickName
                };
                Boolean b = IsNotExist(txt_DvrFactory.EditValue.ToString());
                if (b == false)
                {
                    dxErrorProvider1.SetError(txt_DvrFactory, "硬盘录像机名称已经存在！", ErrorType.Information);
                    return;
                }
            }
            selectMainEntity.ChannelNub = MyNumberHelper.ConvertToInt32(txt_ChannelNub.Text);
            selectMainEntity.DvrIP1 = txt_DvrIP1.Text;
            selectMainEntity.DvrSpec = txt_DvrModel.Text;
            selectMainEntity.DvrFactory = txt_DvrFactory.Text;
            selectMainEntity.DvrModel = txt_DvrSpec.Text;
            if (txt_Storage.Text != "") { selectMainEntity.Storage = MyNumberHelper.ConvertToInt32(txt_Storage.Text); }

            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
            selectMainEntity.DvrIP2 = txt_DvrIP2.Text;

            // selectMainEntity.PondId = new HK_PondSite_Info() { IntId = MyNumberHelper.ConvertToInt32(lu_PondId.EditValue) };
            //selectMainEntity.IsCancle = new DataTypeObj() { IntValue = 0 };
            selectMainEntity.Password = txt_Password.Text;
            selectMainEntity.Port = txt_Port.Text;
            selectMainEntity.Username = txt_userName.Text;
            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
        }

        private Boolean IsNotExist(string DvrCannel)
        {
            Boolean b = false;


            var list = MainService.ExecuteDB_QuerySingle(DvrCannel);
            if (list == null || list.Count == 0)
            {
                b = true;
            }
            return b;
        }
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_Dvr_Info;
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
        private void SetMainEditer(SM_Dvr_Info entity)
        {
            if (entity != null)
            {

                txt_DvrFactory.EditValue = entity.DvrFactory;
                txt_ChannelNub.EditValue = entity.ChannelNub;
                txt_DvrIP1.EditValue = entity.DvrIP1;
                txt_DvrModel.EditValue = entity.DvrSpec;
                txt_Storage.EditValue = entity.Storage;
                txt_DvrSpec.EditValue = entity.DvrModel;
                txt_DvrIP2.EditValue = entity.DvrIP2;
                txt_Password.EditValue = entity.Password;
                txt_Port.EditValue = entity.Port;
                txt_userName.EditValue = entity.Username;
                AliasMeterName = entity.DvrFactory;
            }
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

            txt_DvrSpec.Enabled = enabled;
            txt_ChannelNub.Enabled = enabled;
            txt_DvrIP1.Enabled = enabled;
            txt_DvrIP2.Enabled = enabled;
            txt_DvrModel.Enabled = enabled;
            txt_DvrFactory.Enabled = enabled;
            txt_Storage.Enabled = enabled;
            txt_userName.Enabled = enabled;
            txt_Port.Enabled = enabled;
            txt_Password.Enabled = enabled;
            if (enabled)
            {
                txt_DvrFactory.Focus();
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

        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {

                    var rs = MainService.ExecuteDB_UpdateDvrInfo(selectMainEntity);
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
                var rs = MainService.ExecuteDB_DeleteDvrInfo(selectMainEntity);
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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

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

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_Dvr_Info;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
                // SetMainGridData(true);
            }
        }

        private void SM_DVR_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(true);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }
    }
}
