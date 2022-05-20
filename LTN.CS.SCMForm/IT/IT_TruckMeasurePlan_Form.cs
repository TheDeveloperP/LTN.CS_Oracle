using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.IT.Implement;
using LTN.CS.SCMService.IT.Interface;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.IT
{
    public partial class IT_TruckMeasurePlan_Form : CoreForm
    {
        public IIT_TruckMeasurePlanService MainService { get; set; }
        public IT_TruckMeasurePlan_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            txt_CarNo.Focus();//用于刷新时间控件
            Hashtable ht = new Hashtable();
            ht.Add("PlanNo",txt_PlanNo.Text);
            ht.Add("CarNo", txt_CarNo.Text);
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));

            }
            gCtrl_TruckMeasurePlan.DataSource= MainService.ExecuteDB_QueryIT_TruckMeasurePlan(ht);
        }

        private void btn_HidePanel_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
        }

        private void IT_TruckMeasurePlan_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            btn_Query_Click(null, null);
        }

        private void gView_TruckMeasurePlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "C_CREATETIME" || e.Column.FieldName == "C_PLANLIMITTIME" || e.Column.FieldName == "C_UPDATETIME")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gCtrl_TruckMeasurePlan.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                gView_TruckMeasurePlan.ExportToXls(fileDialog.FileName, options);
            }
        }
    }
}
