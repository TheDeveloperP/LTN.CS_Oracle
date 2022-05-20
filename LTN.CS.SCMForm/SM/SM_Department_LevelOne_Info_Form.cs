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
    public partial class SM_Department_LevelOne_Info_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        private SM_Department_LevelOne_Info selectMainEntity { get; set; }
        public ISM_Department_LevelOne_InfoService MainService { get; set; }
        public ISM_Department_LevelTwo_InfoService LevelTwoService { get; set; }
        public SM_Department_LevelOne_Info_Form()
        {
            InitializeComponent();
        }
        private void SM_Department_LevelOne_Info_Form_Shown(object sender, EventArgs e)
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
                    var rss = MainService.ExecuteDB_QueryAll();
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
                    SM_Department_LevelOne_Info group = gvw_main.GetRow(i) as SM_Department_LevelOne_Info;
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
                var entity = gvw_main.GetFocusedRow() as SM_Department_LevelOne_Info;
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


        private void SetMainEditer(SM_Department_LevelOne_Info entity)
        {
            if (entity != null && entity.DeptCode != null)
            {
                txt_LevelOneCode.EditValue = entity.DeptCode;
                txt_LevelOneShortName.EditValue = entity.DeptShortName;
                txt_LevelOneName.EditValue = entity.DeptName; 
            }
        }
        private void ClearMainEditer()
        {
            txt_LevelOneCode.EditValue = string.Empty;
            txt_LevelOneShortName.EditValue = string.Empty;
            txt_LevelOneName.EditValue = string.Empty;            
        }
        private void SetMainEditerEnabled(bool enabled)
        {            
            txt_LevelOneShortName.Enabled = enabled;
            txt_LevelOneName.Enabled = enabled;
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
            if (txt_LevelOneName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_LevelOneName, "单位名称不能为空！", ErrorType.Information);
            }
            var queryResult = MainService.ExecuteDB_QueryByDeptName(txt_LevelOneName.EditValue.ToString().Trim());
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (queryResult != null && queryResult.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_LevelOneName, "单位名称已存在！", ErrorType.Information);
                    return;
                }
                selectMainEntity = new SM_Department_LevelOne_Info()
                {
                    CreateUserName = SessionHelper.LogUserNickName,
                    UpdateUserName = SessionHelper.LogUserNickName
                };
            }
            else
            {
                if (queryResult != null && queryResult.Count() > 0 && queryResult[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_LevelOneName, "该单位已存在请确认单位名称！", ErrorType.Information);
                    return;
                }
            }
            selectMainEntity.DeptName = txt_LevelOneName.Text.Trim();
            selectMainEntity.DeptShortName = txt_LevelOneShortName.Text.Trim();
            selectMainEntity.UpdateUserName =SessionHelper.LogUserNickName;
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
                selectMainEntity.CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                selectMainEntity.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertDepartment(selectMainEntity);
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
                selectMainEntity.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                selectMainEntity.DeptCode = txt_LevelOneCode.Text;
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdateDepartment(selectMainEntity);
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
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SM_Department_LevelOne_Info psite = gvw_main.GetFocusedRow() as SM_Department_LevelOne_Info;
            if (psite == null)
            {
                MessageDxUtil.ShowWarning("没有数据可以删除!");
                return;
            }
            int areaId = MyNumberHelper.ConvertToInt32(gvw_main.GetFocusedRowCellValue("IntId"));
            IList<SM_Department_LevelTwo_Info> materLevelTwo = LevelTwoService.ExecuteDB_QueryByMainId(areaId);
            if (materLevelTwo != null && materLevelTwo.Count() > 0)
            {
                MessageDxUtil.ShowWarning("存在二级数据，无法删除");
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
                var entity = gvw_main.GetFocusedRow() as SM_Department_LevelOne_Info;
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

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
    }
}
