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
    public partial class SM_Materiel_Level_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        private SM_Materiel_Level selectMainEntity { get; set; }
        public ISM_Materiel_LevelService MainService { get; set; }
        public SM_Materiel_Level_Form()
        {
            InitializeComponent();
        }
        private void SM_Materiel_Level_Form_Shown(object sender, EventArgs e)
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
                    //if (rss != null) {
                    //    List<SM_Materiel_Level> data = rss.ToList();
                    //    data.ForEach(r =>
                    //    {
                    //        r.UpdateTime = CommonHelper.Str14ToTimeFormart(r.UpdateTime);
                    //        r.CreateTime = CommonHelper.Str14ToTimeFormart(r.CreateTime);
                    //    });
                    //}
                    gcl_main.DataSource = rss;
                    //gvw_main.BestFitColumns();
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
                    SM_Materiel_Level group = gvw_main.GetRow(i) as SM_Materiel_Level;
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
                var entity = gvw_main.GetFocusedRow() as SM_Materiel_Level;
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
        private void SetMainEditer(SM_Materiel_Level entity)
        {
            if (entity != null)
            {
                txt_LevelCode.EditValue = entity.MaterielCode;
                txt_LevelName.EditValue = entity.MaterielName;
                txt_LevelModel.EditValue = entity.MaterielModel;
                txt_LevelSpec.EditValue = entity.MaterielSpec;
            }
        }
        private void ClearMainEditer()
        {            
            txt_LevelName.EditValue = string.Empty;
            txt_LevelModel.EditValue = string.Empty;
            txt_LevelCode.EditValue = string.Empty;
            txt_LevelSpec.EditValue = string.Empty;
        }
        private void SetMainEditerEnabled(bool enabled)
        {            
            txt_LevelName.Enabled = enabled;
            txt_LevelModel.Enabled = enabled;
            txt_LevelSpec.Enabled = enabled;
            txt_LevelCode.Enabled = enabled;
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
            if (txt_LevelName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_LevelName, "物料名称不能为空！", ErrorType.Information);
            }
            var queryResult = MainService.ExecuteDB_QueryRepeatByMaterielName(txt_LevelName.Text);
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_Materiel_Level()
                {
                    CreateUserName = SessionHelper.LogUserNickName,
                    UpdateUserName = SessionHelper.LogUserNickName
            };
            }
            selectMainEntity.MaterielCode = txt_LevelCode.Text.Trim();
            selectMainEntity.MaterielName = txt_LevelName.Text.Trim();
            selectMainEntity.MaterielSpec = txt_LevelSpec.Text.Trim();
            selectMainEntity.MaterielModel = txt_LevelModel.Text.Trim();
            selectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
            selectMainEntity.CreateTime = CommonHelper.TimeToStr14(DateTime.Now);
            selectMainEntity.UpdateTime = CommonHelper.TimeToStr14(DateTime.Now);
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
                    var rs = MainService.ExecuteDB_InsertMateriel(selectMainEntity);
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
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdateMateriel(selectMainEntity);
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
            SM_Materiel_Level psite = gvw_main.GetFocusedRow() as SM_Materiel_Level;
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
                var rs = MainService.ExecuteDB_DeleteMateriel(selectMainEntity);
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
                var entity = gvw_main.GetFocusedRow() as SM_Materiel_Level;
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
