using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.SCMEntities.IT;
using LTN.CS.SCMForm.Common;
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
    public partial class IT_BeltScalePlan_Form : CoreForm
    {
        public IIT_BeltScalePlanService MainService { get; set; }
        public IIT_BeltStopScalePlanService BeltStopService { get; set; }

        public IT_BeltScalePlan_Form()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        public Hashtable getCondition()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(date_StartTime.Text))
            {
                condition.Add("StartTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_StartTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(date_EndTime.Text))
            {
                condition.Add("EndTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_EndTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(txt_PlanNo.Text))
            {
                condition.Add("PlanNo", txt_PlanNo.Text);
            }
            return condition;
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Query();
        }
        public void Query()
        {
            var rss1 = MainService.ExecuteDB_QueryByPlannoAndTime(getCondition());
            if (rss1 != null)
            {
                List<IT_BeltScalePlan> data = rss1.ToList();
                data.ForEach(r =>
                {
                    r.c_createtime = CommonHelper.Str14ToTimeFormart(r.c_createtime);
                });
            }
            gcl1_main.DataSource = rss1;
            gvw1_main.BestFitColumns();
            var rss2 = BeltStopService.ExecuteDB_QueryByPlannoAndTime(getCondition());
            if (rss2 != null)
            {
                List<IT_BeltStopScalePlan> data = rss2.ToList();
                data.ForEach(r =>
                {
                    r.c_createtime = CommonHelper.Str14ToTimeFormart(r.c_createtime);
                });
            }
            gcl2_main.DataSource = rss2;
            gvw2_main.BestFitColumns();
        }
        private void IT_BeltScalePlan_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void gvw1_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "status")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString().Trim())
                    {
                        case "Y":
                            e.DisplayText = "接受";
                            break;
                        case "N":
                            e.DisplayText = "未接受";
                            break;
                        default:
                            e.DisplayText = "";
                            break;
                    }
                }
            }
        }

        private void gvw2_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "status1")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString().Trim())
                    {
                        case "Y":
                            e.DisplayText = "接受";
                            break;
                        case "N":
                            e.DisplayText = "未接受";
                            break;
                        default:
                            e.DisplayText = "";
                            break;
                    }
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gcl1_main.DataSource == null)
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
                gvw1_main.ExportToXls(fileDialog.FileName, options);
            }
        }
    }
}
