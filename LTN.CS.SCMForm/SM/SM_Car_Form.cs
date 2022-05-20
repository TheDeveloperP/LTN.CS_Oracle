using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_Car_Form : CoreForm
    {
        private EventHandler eventMainNow;
        public ISM_Car_InfoService CarService { get; set; }
        private SM_Car_Info selectMainEntity { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
 
        public bool isChange = false;
        public SM_Car_Form()
        {
            InitializeComponent();
        }
        private void SM_Car_Form_Shown(object sender, EventArgs e)
        {
            
            SetMainGridData(false);
        }
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var  rss= CarService.ExecuteDB_QueryAll();
                    if (rss != null)
                    {
                        List<SM_Car_Info> data = rss.ToList();
                        data.ForEach(r=> 
                        {
                            if (r.UpdateTime != null)
                            {
                                r.UpdateTime = CommonHelper.Str14ToTimeFormart(r.UpdateTime);  
                            }
                            if (r.CreateTime != null) {
                                r.CreateTime = CommonHelper.Str14ToTimeFormart(r.CreateTime);
                            }
                        });
                    }
                    
                    gCtrl_main.DataSource = rss;
                    gView_main.BestFitColumns();
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
            int rowcount = gView_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_Car_Info group = gView_main.GetRow(i) as SM_Car_Info;
                    if (group.IntId == selectMainId)
                    {
                        gView_main.FocusedRowHandle = i;
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
                    gView_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gView_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gView_main.GetFocusedRow() as SM_Car_Info;
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
        private void SetMainEditer(SM_Car_Info entity)
        {
            if (entity != null && entity.CarNo != null)
            {
                txt_CarNo.EditValue = entity.CarNo;
                txt_CarName.EditValue = entity.CarName;
                txt_CarPeople.EditValue = entity.CarPeople;
                txt_CarTelePhone.EditValue = entity.CarTelephone;
                txt_StandardTare.EditValue = entity.StandardTare;
                ch_IsAuto.EditValue = entity.IsAuto == null ? false : entity.IsAuto.EntityValue == 1;
            }
        }

        private void ClearMainEditer()
        {
            txt_CarNo.EditValue = string.Empty;
            txt_CarName.EditValue = string.Empty;
            txt_CarPeople.EditValue = string.Empty;
            txt_CarTelePhone.EditValue = string.Empty;
            txt_StandardTare.EditValue = string.Empty;
            ch_IsAuto.Checked = false;
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            
            txt_CarName.Enabled = enabled;
            txt_CarPeople.Enabled = enabled;
            txt_CarTelePhone.Enabled = enabled;
            txt_StandardTare.Enabled = enabled;
            ch_IsAuto.Enabled = enabled;
            if (enabled)
            {
                txt_CarNo.Focus();
            }
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Add.Enabled = true;
                btn_update.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else
            {
                btn_Add.Enabled = false;
                btn_update.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;
            }
        }
        public void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            if (txt_CarName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_CarName, "车号不能为空！", ErrorType.Information);
            }
            SM_Car_Info carinfo = new SM_Car_Info();
            carinfo.CarName = txt_CarName.Text;
            var queryResult = CarService.ExecuteDB_QueryAllByCarName2(carinfo);
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (queryResult != null && queryResult.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_CarName, "车号已存在！", ErrorType.Information);
                    return;
                }
                selectMainEntity = new SM_Car_Info()
                {
                    CreateUserName =  SessionHelper.LogUserNickName ,
                    UpdateUserName = SessionHelper.LogUserNickName 
                };
            }
            else
            {
                if (queryResult != null && queryResult.Count() > 0 && queryResult[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_CarName, "该车号已存在请确认车号！", ErrorType.Information);
                    return;
                }
            }
            if (eventMainNow.Method.Name == "CustomMainUpdate") {
                selectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
            }
            
            selectMainEntity.CarName = txt_CarName.Text.Trim();
            selectMainEntity.CarPeople = txt_CarPeople.Text.Trim();
            selectMainEntity.CarTelephone = txt_CarTelePhone.Text.Trim();
            selectMainEntity.StandardTare = MyNumberHelper.ConvertToDecimal(txt_StandardTare.Text.Trim());
            selectMainEntity.IsAuto = new EntityInt(ch_IsAuto.Checked ? 1 : 0);
            selectMainEntity.CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            selectMainEntity.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            isChange = true;
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = CarService.ExecuteDB_InsertCarInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        isChange = false;
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
        private void btn_update_Click(object sender, EventArgs e)
        {
            isChange = true;
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                selectMainEntity.CarNo = txt_CarNo.Text;
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = CarService.ExecuteDB_UpdateCarInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        isChange = false;
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
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SM_Car_Info psite = gView_main.GetFocusedRow() as SM_Car_Info;
            if (psite == null)
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
        private void CustomMainDelete()
        {
            try
            {
                var rs = CarService.ExecuteDB_DeleteCarInfo(selectMainEntity);
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
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            isChange = false;
            btn_Confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gView_main.GetFocusedRow() as SM_Car_Info;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gView_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
        }
        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SM_Car_Info carinfo = new SM_Car_Info();
            if(string.IsNullOrEmpty(txt_searchCarName.Text))
            {
                txt_searchCarName.EditValue = "";
            }
            carinfo.CarName = txt_searchCarName.EditValue.ToString().Trim();
            var rss= CarService.ExecuteDB_QueryAllByCarName(carinfo);
            if (rss != null)
            {
                List<SM_Car_Info> data = rss.ToList();
                data.ForEach(r =>
                {
                    r.UpdateTime = CommonHelper.Str14ToTimeFormart(r.UpdateTime);
                    r.CreateTime= CommonHelper.Str14ToTimeFormart(r.CreateTime);
                });
             }
            gCtrl_main.DataSource = rss;
            gView_main.BestFitColumns();
        }
    }

}
