using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LTN.CS.BaseEntities.BM;
using RV.PM.ICcardMakeData;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_RFID_Info_Form : CoreForm
    {
        private EventHandler eventMainNow;
        public ISM_RFID_InfoService MainService { get; set; }
        private SM_RFID_Info selectMainEntity { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }

        bool isConnect = false;
        RFIDAPI api = new RFIDAPI();

        public SM_RFID_Info_Form()
        {
            InitializeComponent();
        }
        private void ClearMainEditer()
        {
            txt_carno.EditValue = string.Empty;
            txt_RFID.EditValue = string.Empty;
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_carno.Enabled = enabled;
            txt_RFID.Enabled = enabled;
            dxErrorProvider1.ClearErrors();
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            btn_add.Enabled = enabled;
            btn_update.Enabled = enabled;
            btn_invalid.Enabled = enabled;
            btn_confirm.Enabled = !enabled;
            btn_cancel.Enabled = !enabled;
        }
        /// <summary>
        /// 页面数据及样式显示
        /// </summary>
        /// <param name="isFirst"></param>
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

                    //gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        //SetMainFocusRow();
                    }
                    queryMain = true;
                    //SetMainEditerData();
                    //SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 展示选中行数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_RFID_Info;
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
        private void SetMainEditer(SM_RFID_Info entity)
        {
            if (entity != null)
            {
                txt_RFID.EditValue = entity.RFIDno;
                txt_carno.EditValue = entity.Carname;
            }
        }
        #region 自定义方法
        /// <summary>
        /// 自定义添加方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertRFIDInfo(selectMainEntity);
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
        /// <summary>
        /// 自定义修改方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdateRFIDInfo(selectMainEntity);
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
        /// <summary>
        /// 自定义作废方法
        /// </summary>
        private void CustomMainInvalid()
        {
            try
            {
                
                selectMainEntity.Updateusername = SessionHelper.LogUserNickName;
                var rs = MainService.ExecuteDB_InvalidRFIDInfo(selectMainEntity);
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
        private Boolean IsNotExistCarNo(string CarNo)
        {
            Boolean b = false;
            var list = MainService.ExecuteDB_QueryCarNo(CarNo);
            if (list == null ||list.Count==0 )
            {
                b = true;
            }
            return b;

        }
        private Boolean IsNotExistRFID(string RFID)
        {
            Boolean RF = false;
            var listRF = MainService.ExecuteDB_QueryRFID(RFID);
            if (listRF == null || listRF.Count == 0)
            {
                RF = true;
            }
            return RF;
        }
        private void ResetSelectMainEntity()
        {

            if (string.IsNullOrEmpty(txt_carno.Text.Trim()))
            {
                dxErrorProvider1.SetError(txt_carno, "车牌号码为必填！", ErrorType.Information);
                return;
            }
            if (string.IsNullOrEmpty(txt_RFID.Text.Trim()))
            {
                dxErrorProvider1.SetError(txt_RFID, "rfid为必填！", ErrorType.Information);
                return;
            }
                selectMainEntity = new SM_RFID_Info()
                {
                    Createusername = SessionHelper.LogUserNickName,
                    Updateusername = SessionHelper.LogUserNickName
                };
                selectMainEntity.Isused = "Y";
                Boolean b = IsNotExistCarNo(txt_carno.Text.Trim());
                if (b == false)
                {
                    dxErrorProvider1.SetError(txt_carno, "该车牌号码已经绑定过RFID！", ErrorType.Information);
                    return;
                }
                Boolean RF = IsNotExistRFID(txt_RFID.Text.Trim());
                if (RF == false)
                {
                    dxErrorProvider1.SetError(txt_RFID, "该RFID已存在！", ErrorType.Information);
                    return;
                }
                selectMainEntity.Carname = txt_carno.Text.ToUpper().Trim();
                selectMainEntity.RFIDno = txt_RFID.Text.Trim();
                
            
            //if (eventMainNow.Method.Name == "CustomMainUpdate")
            //{
            //    var querycarnoResult = MainService.ExecuteDB_QueryCarNo(txt_carno.EditValue.ToString().Trim());
            //    if(querycarnoResult != null && querycarnoResult.Count()>0 && querycarnoResult[0].IntId!=selectMainEntity.IntId)
            //    {
            //        dxErrorProvider1.SetError(txt_carno, "该车牌号码已经绑定过RFID！", ErrorType.Information);
            //        return;
            //    }
            //    var queryRFResult = MainService.ExecuteDB_QueryRFID(txt_RFID.EditValue.ToString().Trim());
            //    if (queryRFResult != null && queryRFResult.Count() > 0 && queryRFResult[0].IntId != selectMainEntity.IntId)
            //    {
            //        dxErrorProvider1.SetError(txt_carno, "该RFID已存在！", ErrorType.Information);
            //        return;
            //    }
            //    selectMainEntity.Carname = txt_carno.Text.Trim();
            //    selectMainEntity.RFIDno = txt_RFID.Text.Trim();
            //    selectMainEntity.Updateusername = SessionHelper.LogUserNickName;
            //}            
        }


        #endregion

        private void btn_add_Click(object sender, EventArgs e)
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

        private void btn_invalid_Click(object sender, EventArgs e)
        {
            var rs = MessageDxUtil.ShowYesNoAndTips("确定作废数据吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainInvalid();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
            SetMainGridData(false);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (queryMain && eventMainNow == null)
            //{
            //    var entity = gvw_main.GetFocusedRow() as SM_RFID_Info;
            //    if (entity != null)
            //    {
            //        SetMainEditer(entity);
            //        selectMainId = entity.IntId;
            //        selectMainRowNum = gvw_main.FocusedRowHandle;
            //    }
            //    selectMainEntity = entity;
            //    SetMainButtonEnabled(true);
                
            //}
        }

        private void SM_RFID_Info_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isConnect = api.init();
            if (isConnect == true)
            {
                Timer_Test_.Start();
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            try
            {
                if (!api.Inventory().Equals(txt_RFID.Text))
                {
                    this.Invoke(new ShowDataCallback(showText), new object[] { api.Inventory() });    
                }
            }
            catch (Exception)
            {
            } 
        }

        private delegate void ShowDataCallback(string str);

        void showText(string ss)
        {
            this.txt_RFID.Text = ss;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            ResetSelectMainEntity();
            if (!dxErrorProvider1.HasErrors)
            {
                var rs = MainService.ExecuteDB_InsertRFIDInfo(selectMainEntity);
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

        private void button3_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            var rs = MessageDxUtil.ShowYesNoAndTips("确定解绑该条数据吗?");
            if (rs == DialogResult.Yes)
            {
                var entity = gvw_main.GetFocusedRow() as SM_RFID_Info;
                selectMainEntity = entity;
                CustomMainInvalid();
            }
        }

        private void SM_RFID_Info_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            api.close();
        }
    }
}
