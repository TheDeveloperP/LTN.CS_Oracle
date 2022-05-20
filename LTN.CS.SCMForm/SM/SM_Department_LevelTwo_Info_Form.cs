using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
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
    public partial class SM_Department_LevelTwo_Info_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        private SM_Department_LevelTwo_Info selectMainEntity { get; set; }
        private SM_Department_LevelOne_Info LevelOneMainEntity { get; set; }
        public ISM_Department_LevelTwo_InfoService MainService { get; set; }
        public ISM_Department_LevelOne_InfoService LevelOneService { get; set; }
        public int selectleftId { get; set; }
        public SM_Department_LevelTwo_Info_Form()
        {
            LevelOneMainEntity = new SM_Department_LevelOne_Info();
            InitializeComponent();
        }
        private void SM_Department_LevelTwo_Info_Form_Shown(object sender, EventArgs e)
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
                    var rss = LevelOneService.ExecuteDB_QueryAll();
                    if (rss != null)
                    {
                        List<SM_Department_LevelOne_Info> data = rss.ToList();                        
                        data.ForEach(r =>
                        {
                            r.UpdateTime = CommonHelper.Str14ToTimeFormart(r.UpdateTime);
                            r.CreateTime = CommonHelper.Str14ToTimeFormart(r.CreateTime);                           
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
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        private void SetMainGridData2(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectIdOld = selectleftId;
                    var rss= MainService.ExecuteDB_QueryByMainId(LevelOneMainEntity.IntId);
                    if (rss != null)
                    {
                        List<SM_Department_LevelTwo_Info> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            r.UPDATETIME = CommonHelper.Str14ToTimeFormart(r.UPDATETIME);
                            r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);                            
                        });
                    }
                    gCtrl1.DataSource = rss;
                    gView1.BestFitColumns();
                    if (!isFirst)
                    {
                        selectleftId = selectIdOld;
                    }
                    SetLeftFocusRow();
                    gView1_FocusedRowChanged(null, null);
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
                    SM_Department_LevelOne_Info user = gvw_main.GetRow(i) as SM_Department_LevelOne_Info;
                    if (user.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectMainId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectMainId)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainId = rowcount - 1;
                }
                else if (selectMainId == 0)
                {
                    gvw_main.FocusedRowHandle = 0;
                    selectMainId = 0;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainId;
                }
            }
        }
        private void SetMainEditerEnabled(bool enabled)
        {            
            txt_LevelTwoShortName.Enabled = enabled;
            txt_LevelTwoName.Enabled = enabled;
            if (enabled)
            {
                txt_LevelTwoCode.Focus();
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
        private void SetLeftFocusRow()
        {
            int rowcount = gView1.RowCount;
            bool isFocused = false;
            if (selectleftId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_Department_LevelTwo_Info dic = gView1.GetRow(i) as SM_Department_LevelTwo_Info;
                    if (dic.IntId == selectleftId)
                    {
                        gView1.FocusedRowHandle = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectleftId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectleftId)
                {
                    gView1.FocusedRowHandle = rowcount - 1;
                    selectleftId = rowcount - 1;
                }
                else if (selectleftId == 0)
                {
                    gView1.FocusedRowHandle = 0;
                    selectleftId = 0;
                }
                else
                {
                    gView1.FocusedRowHandle = selectleftId;
                }
            }
        }
        private void gView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gView1.GetFocusedRow() as SM_Department_LevelTwo_Info;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectleftId = entity.IntId;
                    selectMainRowNum = gView1.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
        }
        private void ClearMainEditer()
        {
            txt_LevelTwoCode.EditValue = string.Empty;
            txt_LevelTwoShortName.EditValue = string.Empty;
            txt_LevelTwoName.EditValue = string.Empty;
        }
        private void SetMainEditer(SM_Department_LevelTwo_Info entity)
        {
            if (entity != null && entity.TwoDeptCode != null)
            {
                txt_LevelTwoCode.EditValue = entity.TwoDeptCode;
                txt_LevelTwoShortName.EditValue = entity.TwoDeptShortName;
                txt_LevelTwoName.EditValue = entity.TwoDeptName;
            }
        }
        public void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            if (txt_LevelTwoName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_LevelTwoName, "单位名称不能为空！", ErrorType.Information);
            }
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_Department_LevelTwo_Info()
                {
                    CreateUserName = SessionHelper.LogUserNickName,
                    UpdateUserName =SessionHelper.LogUserNickName
                };
            }
            selectMainEntity.MainId = LevelOneMainEntity.IntId;
            selectMainEntity.TwoDeptShortName = txt_LevelTwoShortName.Text.Trim();
            selectMainEntity.TwoDeptName = txt_LevelTwoName.Text.Trim();
            selectMainEntity.UpdateUserName =SessionHelper.LogUserNickName;
            selectMainEntity.CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            selectMainEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
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
                    var rs = MainService.ExecuteDB_InsertDepartment(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectleftId = Convert.ToInt32(rs);
                        SetMainGridData2(false);
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
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdateDepartment(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData2(false);
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
            SM_Department_LevelTwo_Info psite = gView1.GetFocusedRow() as SM_Department_LevelTwo_Info;
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
                var rs = MainService.ExecuteDB_DeleteDepartment(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData2(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventMainNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    LevelOneMainEntity = gvw_main.GetFocusedRow() as SM_Department_LevelOne_Info;
                    if (LevelOneMainEntity != null)
                    {
                        selectMainId = LevelOneMainEntity.IntId;
                        SetMainGridData2(true);
                    }
                }
            }
        }
        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
        private void gView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView1.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
    }
}
