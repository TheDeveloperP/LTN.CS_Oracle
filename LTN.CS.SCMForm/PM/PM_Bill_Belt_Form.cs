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

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_Belt_Form : CoreForm
    {
        public IPM_Bill_BeltScaleService MainService { get; set; }
        public IPT_BeltScalePlanService PT_BeltScalePlanService { get; set; }
        public PM_Bill_Belt_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_Bill_Belt_Operate_Form frm = new PM_Bill_Belt_Operate_Form();
            frm.MainService = MainService;
            frm.PT_BeltScalePlanService = PT_BeltScalePlanService;
            frm.BeltBill = new PM_Bill_Belt();
            frm.ShowDialog();
            Query();
               
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var item = gView_BeltBill.GetFocusedRow() as PM_Bill_Belt;
            if (item == null)
                return;

            PM_Bill_Belt_Operate_Form frm = new PM_Bill_Belt_Operate_Form();
            frm.MainService = MainService;
            frm.PT_BeltScalePlanService = PT_BeltScalePlanService;
            frm.BeltBill = item;
            frm.ShowDialog();
            Query();
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            var item = gView_BeltBill.GetFocusedRow() as PM_Bill_Belt;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
            {
                item.C_Updatetime = CommonHelper.TimeToStr14(DateTime.Now);
                item.C_Updateusername = SessionHelper.LogUserNickName;
                var result = MainService.ExecuteDB_InvalidPM_Bill_Belt(item);
                if (result != null)
                {
                    MessageDxUtil.ShowTips("作废成功");
                    Query();
                }
                else
                {
                    MessageDxUtil.ShowError("作废异常");
                }
            }
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

        private void PM_Bill_Belt_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }
        private void Query()
        {
            Hashtable ht = new Hashtable();
            ht.Add("PlanNo", txt_PlanNo.Text);
            ht.Add("WgtNo", txt_WgtNo.Text);
            //新增过滤
            if (checkBox1.Checked)
            {
                ht.Add("totalNum", "Y");
            }
            else
            {
                ht.Add("totalNum", "N");
            }
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            }
            var result = MainService.ExecuteDB_QueryPM_Bill_BeltByHashtable(ht);
            gCtrl_BeltBill.DataSource = result;
        }

        private void gView_BeltBill_DoubleClick(object sender, EventArgs e)
        {
            btn_Update_Click(null, null);
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
    }
}
