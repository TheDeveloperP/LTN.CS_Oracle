using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Pond_Bill_CarsForJinCai_Form : CoreForm
    {
        #region 实例变量
        public IPM_Bill_TruckService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        private PM_Bill_Truck selectMainEntity { get; set; }
        public ISM_Guid_InfoService guidService { get; set; }
        #endregion
        public PM_Pond_Bill_CarsForJinCai_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            SetGridData(false);
        }

        private void SetGridData(bool isFirst)
        {

            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                txt_CarName.Focus();
                Hashtable ht = setCondition();
                var result = MainService.ExecuteDB_QueryPM_Bill_TruckByPond(ht);
                gridCtrl.DataSource = result;

                if (!isFirst)
                {
                    selectMainId = selectLeftIdOld;
                    SetMainFocusRow();
                }
                queryMain = true;

            }
            catch (Exception ex)
            {

            }

        }
        private void SetMainFocusRow()
        {
            int rowcount = gView_TruckPoundBill.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_Bill_Truck group = gView_TruckPoundBill.GetRow(i) as PM_Bill_Truck;
                    if (group.I_INTID == selectMainId)
                    {
                        gView_TruckPoundBill.FocusedRowHandle = i;
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
                    gView_TruckPoundBill.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gView_TruckPoundBill.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        private Hashtable setCondition()
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(txt_CarName.Text.Trim()))
            {
                ht.Add("CarName", txt_CarName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_FromDeptName.Text.Trim()))
            {
                ht.Add("FromDeptName", txt_FromDeptName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_ToDeptName.Text.Trim()))
            {
                ht.Add("ToDeptName", txt_ToDeptName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_MaterialName.Text.Trim()))
            {
                ht.Add("MaterialName", txt_MaterialName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_PlanNo.Text.Trim()))
            {
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_WgtlistNo.Text.Trim()))
            {
                ht.Add("WgtNo", txt_WgtlistNo.Text.Trim());
            }
            ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
            ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            return ht;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gridCtrl.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            //fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                //options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                gView_TruckPoundBill.ExportToXls(fileDialog.FileName, options);
            }
        }

        private void gView_TruckPoundBill_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gView_TruckPoundBill.GetFocusedRow() as PM_Bill_Truck;
                if (entity != null)
                {
                    selectMainId = entity.I_INTID;
                    selectMainRowNum = gView_TruckPoundBill.FocusedRowHandle;
                }
                selectMainEntity = entity;
            }
        }

        private void gView_TruckPoundBill_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView_TruckPoundBill.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Lime;
            }
        }

        private void PM_Pond_Bill_CarsForJinCai_Form_Shown(object sender, EventArgs e)
        {
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
        }
    }
}
