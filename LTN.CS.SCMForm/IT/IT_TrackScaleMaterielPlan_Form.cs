using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.IT;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.IT.Interface;

namespace LTN.CS.SCMForm.IT
{
    public partial class IT_TrackScaleMaterielPlan_Form : CoreForm
    {
        public IIT_TrackScaleMaterielPlanService MainService { get; set; }
        //private Color MM = Color.Green;
        public IT_TrackScaleMaterielPlan_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            //txt_HeatNo.Focus();//用于刷新时间控件
            Hashtable ht = new Hashtable();
            ht.Add("PlanNo", txt_PlanNo.Text);
            ht.Add("WagNo", txt_WagNo.Text);
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));

            }
            var rss= MainService.ExecuteDB_QueryIT_TrackScaleMaterielPlan(ht);
            if (rss != null)
            {
                List<IT_TrackScaleMaterielPlan> data = rss.ToList();

                data.ForEach(r =>
                {
                    r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);
                } );
            }
            gcl_main.DataSource = rss;
            gvw_main.BestFitColumns();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gcl_main.DataSource == null)
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
                gcl_main.ExportToXls(fileDialog.FileName, options);
            }
        }

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            IT_TrackScaleMaterielPlan item = gvw_main.GetRow(e.RowHandle) as IT_TrackScaleMaterielPlan;
            ;
            if (item == null)
                return;
            string uploadStatus = item.UPLOADSTATUS;
            if (!String.IsNullOrEmpty(uploadStatus))
            {
                if (uploadStatus == "N")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void IT_TrackScaleMaterielPlan_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            btn_Query_Click(null, null);
        }
    }
}
