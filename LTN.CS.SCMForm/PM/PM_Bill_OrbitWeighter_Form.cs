﻿using LTN.CS.Base;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
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

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_OrbitWeighter_Form : CoreForm
    {
        public IPM_Bill_OrbitWeighterService MainService { get; set; }
        public PM_Bill_OrbitWeighter_Form()
        {
            InitializeComponent();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(date_StartTime.Text))
            {
                condition.Add("StartTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_StartTime.Text)));
            }
            if (!string.IsNullOrEmpty(date_EndTime.Text))
            {
                condition.Add("EndTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_EndTime.Text)));
            }
            if (!string.IsNullOrEmpty(txt_MatNo.Text))
            {
                condition.Add("MatNo", txt_MatNo.Text);
            }
            gcl_main.DataSource = MainService.ExecuteDB_QueryOrbitWeighterBillByHashTable(condition);
        }

        private void PM_Bill_OrbitWeighter_Shown(object sender, EventArgs e)
        {
            date_StartTime.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "T_WEIGHT_TIME" || e.Column.FieldName == "T_PRODUCT_TIME")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
            if (e.Column.Name == "T_BILL_STATUS")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString().Trim())
                    {
                        case "0":
                            e.DisplayText = "未完成";
                            break;
                        case "1":
                            e.DisplayText = "已完成";
                            break;
                        case "2":
                            e.DisplayText = "作废";
                            break;
                        default:
                            e.DisplayText = "";
                            break;
                    }
                }
            }

            if (e.Column.Name == "T_STATUS")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString().Trim())
                    {
                        case "0":
                            e.DisplayText = "自动";
                            break;
                        case "1":
                            e.DisplayText = "手动";
                            break;
                        default:
                            e.DisplayText = "";
                            break;
                    }
                }
            }
             
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton1_Click(object sender, EventArgs e)
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
                gvw_main.ExportToXls(fileDialog.FileName, options);
            }
        }
    }
}
