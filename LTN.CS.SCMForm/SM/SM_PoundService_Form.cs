using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
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
    public partial class SM_PoundService_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_PoundService_Info selectMainEntity { get; set; }

        private bool queryMain { get; set; }
        public ISM_PoundService_InfoService MainService { get; set; }
        public ISM_PoundSite_InfoService PoundService { get; set; }
        public ISM_Dvr_InfoService DvrService { get; set; }
        public ISM_Meter_InfoService MeterService { get; set; }
        public ISM_LPRCameraService LPRCameraService { get; set; }

        public SM_PoundService_Form()
        {
            InitializeComponent();
        }
        private void SM_PoundService_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(false);
            SetMainButtonEnabled(true);
            SetData();
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
                    if (rss != null)
                    {
                        List<SM_PoundService_Info> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            if (r.UpdateTime != null)
                            {
                                r.updateTime = CommonHelper.Str14ToTimeFormart(r.updateTime);
                            }
                            if (r.CreateTime != null)
                            {
                                r.createTime = CommonHelper.Str14ToTimeFormart(r.createTime);
                            }
                        });
                    }
                    gcl_main.DataSource = rss;
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
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


        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_PoundService_Info group = gvw_main.GetRow(i) as SM_PoundService_Info;
                    if (group.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        selectMainRowNum = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (!isFocused)
            {
                if (rowcount - 1 < selectMainRowNum)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_PoundService_Info;
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
                SetMainEditerEnabled(false);
            }
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            lue_MeterName1.Enabled = enabled;
            lue_MeterName2.Enabled = enabled;
            txt_PoundName.Enabled = enabled;
            txt_CarNoIP1.Enabled = enabled;
            txt_CarNoIP2.Enabled = enabled;
            txt_PrintBaud1.Enabled = enabled;
            txt_PrintBaud2.Enabled = enabled;
            txt_PrintCOM1.Enabled = enabled;
            txt_PrintCOM2.Enabled = enabled;
            txt_RFIDBaud.Enabled = enabled;
            txt_RFIDCOM.Enabled = enabled;
            txt_SignalCOM1.Enabled = enabled;
            txt_SignalCOM2.Enabled = enabled;
            slu_dvr.Enabled = enabled;
            txt_meterBaud1.Enabled = enabled;
            cb_meterCOM1.Enabled = enabled;
            txt_metercheck1.Enabled = enabled;
            txt_meterCOMstart1.Enabled = enabled;
            txt_meterCOMstop1.Enabled = enabled;
            txt_meterBaud2.Enabled = enabled;
            cb_meterCOM2.Enabled = enabled;
            txt_metercheck2.Enabled = enabled;
            txt_meterCOMstart2.Enabled = enabled;
            txt_meterCOMstop2.Enabled = enabled;
            txt_INFRAREDGRATING1.Enabled = enabled;
            txt_INFRAREDGRATING2.Enabled = enabled;
            txt_IOCOMBaud.Enabled = enabled;
            txt_IOCOMbit.Enabled = enabled;
            txt_IOCOMcheck.Enabled = enabled;
            txt_IOCOMNO.Enabled = enabled;
            txt_IOCOMstopbit.Enabled = enabled;
            
            if (enabled)
            {
                txt_PrintBaud1.Focus();
            }
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_insert.Enabled = true;
                btn_confirm.Enabled = false;
                btn_cancel.Enabled = false;
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
            else
            {
                btn_insert.Enabled = false;
                btn_confirm.Enabled = true;
                btn_cancel.Enabled = true;
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
            }
        }
        private void SetMainEditer(SM_PoundService_Info entity)
        {
            if (entity != null)
            {
                lue_MeterName1.EditValue = entity.MeterId1.IntId;
                lue_MeterName2.EditValue = entity.MeterId2.IntId;             
                txt_PoundName.EditValue = entity.PoundId.IntId;
                txt_CarNoIP1.EditValue = entity.LPRCAMERAID1.IntId;
                txt_CarNoIP2.EditValue = entity.LPRCAMERAID2.IntId;
                txt_PrintBaud1.EditValue = entity.PrintBAUD1;
                txt_PrintBaud2.EditValue = entity.PrintBAUD2;
                txt_PrintCOM1.EditValue = entity.PrintCOM1;
                txt_PrintCOM2.EditValue = entity.PrintCOM2;
                txt_RFIDBaud.EditValue = entity.RFIDBAUD;
                txt_RFIDCOM.EditValue = entity.RFIDCOM;
                txt_SignalCOM1.EditValue = entity.SignalCOM1;
                txt_SignalCOM2.EditValue = entity.SignalCOM2;
                slu_dvr.EditValue = entity.DVRID.IntId;
                txt_meterBaud1.EditValue = entity.METERBAUD1;
                txt_metercheck1.EditValue = entity.METERCHECK1;
                txt_meterCOMstart1.EditValue = entity.METERSTARTBIT1;
                txt_meterCOMstop1.EditValue = entity.METERSTOPBIT1;
                cb_meterCOM1.EditValue = entity.METERCOM1;
                txt_meterBaud2.EditValue = entity.METERBAUD2;
                txt_metercheck2.EditValue = entity.METERCHECK2;
                txt_meterCOMstart2.EditValue = entity.METERSTARTBIT2;
                txt_meterCOMstop2.EditValue = entity.METERSTOPBIT2;
                cb_meterCOM2.EditValue = entity.METERCOM2;
                txt_INFRAREDGRATING1.EditValue = entity.INFRAREDGRATING1;
                txt_INFRAREDGRATING2.EditValue = entity.INFRAREDGRATING2;
                txt_IOCOMBaud.EditValue = entity.IOBAUD;
                txt_IOCOMbit.EditValue = entity.IOSTARTBIT;
                txt_IOCOMcheck.EditValue = entity.IOCHECK;
                txt_IOCOMNO.EditValue = entity.IOCOMNO;
                txt_IOCOMstopbit.EditValue = entity.IOSTOPBIT;                
            }
        }
        private void ClearMainEditer()
        {
            lue_MeterName1.EditValue = null;
            lue_MeterName2.EditValue = null;
            txt_PoundName.EditValue = null;
            txt_CarNoIP1.EditValue = null;
            txt_CarNoIP2.EditValue = null;
            txt_PrintBaud1.EditValue = string.Empty;
            txt_PrintBaud2.EditValue = string.Empty;
            txt_PrintCOM1.EditValue = string.Empty;
            txt_PrintCOM2.EditValue = string.Empty;
            txt_RFIDBaud.EditValue = string.Empty;
            txt_RFIDCOM.EditValue = string.Empty;
            txt_SignalCOM1.EditValue = string.Empty;
            txt_SignalCOM2.EditValue = string.Empty;
            slu_dvr.EditValue = null;
            txt_meterBaud1.EditValue = string.Empty;
            txt_metercheck1.EditValue = string.Empty;
            cb_meterCOM1.EditValue = string.Empty;
            txt_meterCOMstart1.EditValue = string.Empty;
            txt_meterCOMstop1.EditValue = string.Empty;
            txt_meterBaud2.EditValue = string.Empty;
            txt_metercheck2.EditValue = string.Empty;
            cb_meterCOM2.EditValue = string.Empty;
            txt_meterCOMstart2.EditValue = string.Empty;
            txt_meterCOMstop2.EditValue = string.Empty;
            txt_INFRAREDGRATING1.EditValue = string.Empty;
            txt_INFRAREDGRATING2.EditValue = string.Empty;
            txt_IOCOMBaud.EditValue = string.Empty;
            txt_IOCOMbit.EditValue = string.Empty;
            txt_IOCOMcheck.EditValue = string.Empty;
            txt_IOCOMNO.EditValue = string.Empty;
            txt_IOCOMstopbit.EditValue = string.Empty;
            
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_confirm.Click += eventMainNow;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_confirm.Click += eventMainNow;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SM_PoundService_Info psi = gvw_main.GetFocusedRow() as SM_PoundService_Info;
            if (psi == null)
            {
                MessageDxUtil.ShowWarning("没有数据可以删除!");
                return;
            }
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
                var entity = gvw_main.GetFocusedRow() as SM_PoundService_Info;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
            }
        }
        #region 自定义方法
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertPoundInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdatePoundInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
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
                var rs = MainService.ExecuteDB_DeletePoundInfo(selectMainEntity);
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
        private void ResetSelectMainEntity()
        {

            if (txt_PoundName.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_PoundName, "磅房名称为必填！", ErrorType.Information);
                return;
            }
            var pound = MainService.ExecuteDB_QueryAllByPoundId(Convert.ToInt32(txt_PoundName.EditValue.ToString()));
            
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (pound != null && pound.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_PoundName, "该磅房已经存在!", ErrorType.Information);
                    return;
                }
                selectMainEntity = new SM_PoundService_Info()
                {
                    CreateUserName = SessionHelper.LogUserNickName,
                    UpdateUserName = SessionHelper.LogUserNickName
                    
                };
            }
            if (eventMainNow.Method.Name == "CustomMainUpdate")
            {
                selectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
                if (pound != null && pound.Count() > 0 && pound[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_PoundName, "该磅房已经存在!", ErrorType.Information);
                    return;
                }
            }
            //if(eventMainNow.Method.Name == "CustomMainInsert")
            //{
            //    selectMainEntity = new SM_PoundService_Info()
            //    {
            //        CreateUserName = SessionHelper.LogUserNickName,
            //        UpdateUserName = SessionHelper.LogUserNickName
            //    };
            //}
            if (!string.IsNullOrEmpty(txt_CarNoIP1.Text))
            {
                //int car = MyNumberHelper.ConvertToInt32(txt_CarNoIP1.EditValue.ToString());
                //var c = LPRCameraService.ExecuteDB_QueryAll();
                //string carnoip1 = string.Empty;
                //c.ToList().ForEach(r => { if (car == r.IntId) { carnoip1 = r.LPRIP1; } });
                selectMainEntity.LPRCAMERAID1 = new SM_LPRCamera() { IntId = MyNumberHelper.ConvertToInt32(txt_CarNoIP1.EditValue.ToString()), LPRFactory = txt_CarNoIP1 .Text};
            }
            else
            {
                selectMainEntity.LPRCAMERAID1 = new SM_LPRCamera();
            }
            if (!string.IsNullOrEmpty(txt_CarNoIP2.Text))
            {
                //int car = MyNumberHelper.ConvertToInt32(txt_CarNoIP2.EditValue.ToString());
                //var c = LPRCameraService.ExecuteDB_QueryAll();
                //string carnoip2 = string.Empty;
                //c.ToList().ForEach(r => { if (car == r.IntId) { carnoip2 = r.LPRIP2; } });
                //selectMainEntity.LPRCAMERAID2 = new SM_LPRCamera() { LPRIP2 = carnoip2 };
                selectMainEntity.LPRCAMERAID2 = new SM_LPRCamera() { IntId = MyNumberHelper.ConvertToInt32(txt_CarNoIP2.EditValue.ToString()), LPRFactory = txt_CarNoIP2.Text };
            }
            else
            {
                selectMainEntity.LPRCAMERAID2 = new SM_LPRCamera();
            }
            if (!string.IsNullOrEmpty(slu_dvr.Text))
            {
                selectMainEntity.DVRID = new SM_Dvr_Info() { IntId = Convert.ToInt32(slu_dvr.EditValue.ToString()), DvrFactory = slu_dvr.Text };
            }
            else
            {
                selectMainEntity.DVRID = new SM_Dvr_Info();
            }
            if (!string.IsNullOrEmpty(lue_MeterName1.Text))
            {
                int id = MyNumberHelper.ConvertToInt32(lue_MeterName1.EditValue.ToString());
                var meter = MeterService.ExecuteDB_QueryAll();
                string a = string.Empty;
                meter.ToList().ForEach(r => { if (id == r.IntId) { a = r.AnalysisNo; } });
                selectMainEntity.MeterId1 = new SM_Meter_Info() { MeterName = lue_MeterName1.Text, IntId = Convert.ToInt32(lue_MeterName1.EditValue.ToString()), AnalysisNo = a };
            }
            else
            {
                selectMainEntity.MeterId1 = new SM_Meter_Info();
            }
            if (!string.IsNullOrEmpty(lue_MeterName2.Text))
            {
                int id = MyNumberHelper.ConvertToInt32(lue_MeterName1.EditValue.ToString());
                var meter = MeterService.ExecuteDB_QueryAll();
                string a = string.Empty;
                meter.ToList().ForEach(r => { if (id == r.IntId) { a = r.AnalysisNo; } });
                selectMainEntity.MeterId2 = new SM_Meter_Info() { MeterName = lue_MeterName2.Text, IntId = Convert.ToInt32(lue_MeterName2.EditValue.ToString()), AnalysisNo = a };
            }
            else
            {
                selectMainEntity.MeterId2 = new SM_Meter_Info();
            }

            int pondid = MyNumberHelper.ConvertToInt32(txt_PoundName.EditValue.ToString());
            var pond = PoundService.ExecuteDB_QueryAll();
            string no = string.Empty;
            pond.ToList().ForEach(r => { if (pondid == r.IntId) { no = r.PoundSiteNo; } });
            selectMainEntity.PrintBAUD1 = MyNumberHelper.ConvertToInt32( txt_PrintBaud1.Text.Trim());
            selectMainEntity.PrintBAUD2 = MyNumberHelper.ConvertToInt32(txt_PrintBaud2.Text.Trim());
            selectMainEntity.PrintCOM1 = txt_PrintCOM1.Text.Trim();
            selectMainEntity.PrintCOM2 = txt_PrintCOM2.Text.Trim();
            selectMainEntity.RFIDBAUD = MyNumberHelper.ConvertToInt32(txt_RFIDBaud.Text.Trim());
            selectMainEntity.RFIDCOM = txt_RFIDCOM.Text.Trim();
            selectMainEntity.SignalCOM1 = txt_SignalCOM1.Text.Trim();
            selectMainEntity.SignalCOM2 = txt_SignalCOM2.Text.Trim();            
            selectMainEntity.PoundId = new SM_PoundSite_Info() { PoundSiteName = txt_PoundName.Text, IntId = MyNumberHelper.ConvertToInt32(txt_PoundName.EditValue.ToString()),PoundSiteNo=no };
            selectMainEntity.METERBAUD1 = MyNumberHelper.ConvertToInt32(txt_meterBaud1.Text.Trim());
            selectMainEntity.METERCHECK1 = MyNumberHelper.ConvertToInt32(txt_metercheck1.Text.Trim());
            selectMainEntity.METERCOM1 = cb_meterCOM1.Text.Trim();
            selectMainEntity.METERSTARTBIT1 = MyNumberHelper.ConvertToInt32(txt_meterCOMstart1.Text.Trim());
            selectMainEntity.METERSTOPBIT1 = MyNumberHelper.ConvertToInt32(txt_meterCOMstop1.Text.Trim());
            selectMainEntity.METERBAUD2 = MyNumberHelper.ConvertToInt32(txt_meterBaud2.Text.Trim());
            selectMainEntity.METERCHECK2 = MyNumberHelper.ConvertToInt32(txt_metercheck2.Text.Trim());
            selectMainEntity.METERCOM2 = cb_meterCOM2.Text.Trim();
            selectMainEntity.METERSTARTBIT2 = MyNumberHelper.ConvertToInt32(txt_meterCOMstart2.Text.Trim());
            selectMainEntity.METERSTOPBIT2 = MyNumberHelper.ConvertToInt32(txt_meterCOMstop2.Text.Trim());
            selectMainEntity.INFRAREDGRATING1 = txt_INFRAREDGRATING1.Text.Trim();
            selectMainEntity.INFRAREDGRATING2 = txt_INFRAREDGRATING2.Text.Trim();
            selectMainEntity.IOBAUD = MyNumberHelper.ConvertToInt32(txt_IOCOMBaud.Text.Trim());
            selectMainEntity.IOCHECK = MyNumberHelper.ConvertToInt32(txt_IOCOMcheck.Text.Trim());
            selectMainEntity.IOCOMNO = txt_IOCOMNO.Text.Trim();
            selectMainEntity.IOSTARTBIT = MyNumberHelper.ConvertToInt32(txt_IOCOMbit.Text.Trim());
            selectMainEntity.IOSTOPBIT = MyNumberHelper.ConvertToInt32(txt_IOCOMstopbit.Text.Trim());
            selectMainEntity.createTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            selectMainEntity.updateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void SetData()
        {

            var _pounds = PoundService.ExecuteDB_QueryAll();
            txt_PoundName.Properties.DataSource = _pounds;
            var dinfo = DvrService.ExecuteDB_QueryAll();
            slu_dvr.Properties.DataSource = dinfo;
            var _meters1 = MeterService.ExecuteDB_QueryAll();
            lue_MeterName1.Properties.DataSource = _meters1;
            lue_MeterName2.Properties.DataSource = _meters1;
            var _lpr = LPRCameraService.ExecuteDB_QueryAll();
            txt_CarNoIP1.Properties.DataSource = _lpr;
            txt_CarNoIP2.Properties.DataSource = _lpr;



        }


        #endregion

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }
    }
}
