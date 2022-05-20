using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
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

namespace LTN.CS.SCMForm.CS
{
    public partial class CS_Bill_Belt_Form : CoreForm
    {
        public IPM_Bill_BeltScaleService MainService { get; set; }
        public CS_Bill_Belt_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gCtrl_BeltBill.DataSource == null)
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
                gView_BeltBill.ExportToXls(fileDialog.FileName, options);
            }
        }

        private void Query()
        {
            Hashtable ht = new Hashtable();
            ht.Add("BeltNo", txt_BeltNo.Text);
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            }
            if (checkBox1.Checked)
            {
                ht.Add("totalNum", "Y");
            }
            else
            {
                ht.Add("totalNum", "N");
            }
            ht.Add("MaterialName", txt_materiel.Text);
            var result = MainService.ExecuteDB_QueryPM_Bill_BeltByHashtable(ht);
            gCtrl_BeltBill.DataSource = result;
        }


        private void gView_BeltBill_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "C_Measurestarttime" || e.Column.FieldName == "C_Measureendtime" || e.Column.FieldName == "C_Billcreatetime" || e.Column.FieldName == "C_Updatetime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }

        private void CS_Bill_Belt_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }
    }
}
