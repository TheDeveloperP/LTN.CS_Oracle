using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.Common;
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

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_BeltScalePlan_Form : CoreForm
    {
        public IPT_BeltScalePlanService MainService { get; set; }
        public PT_BeltScalePlan_Form()
        {
            InitializeComponent();
        }

        private void btn_Sel_Click(object sender, EventArgs e)
        {
            Panel_Query.Visible = true;
            txt_PlanNo.Focus();
            Query();
        }

        private void Query()
        {

            if (string.IsNullOrEmpty(date_StartTime.Text) || string.IsNullOrEmpty(date_EndTime.Text))
            {
                MessageDxUtil.ShowTips("时间不能为空");
            }

            date_StartTime.Refresh();
            DateTime StartTime = Convert.ToDateTime(date_StartTime.Text);
            DateTime EndTime = Convert.ToDateTime(date_EndTime.Text);
            Hashtable ht = new Hashtable();
            ht.Add("StartDate", CommonHelper.TimeToStr14(StartTime));
            ht.Add("EndDate", CommonHelper.TimeToStr14(EndTime));
            ht.Add("PlanNo", txt_PlanNo.Text);

            int rowHandle = gView_BeltScalePlan.FocusedRowHandle;
            var rss = MainService.ExecuteDB_QueryBeltScalePlanByHashTable(ht);
            gCtrl_BeltScalePlan.DataSource = rss;
            gView_BeltScalePlan.FocusedRowHandle = rowHandle;
        }

        private void PT_BeltScalePlan_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        private void gView_BeltScalePlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "C_Createtime" || e.Column.FieldName == "C_Stoptime" || e.Column.FieldName == "C_Updatetime" || e.Column.FieldName == "C_Starttime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
            if (e.Column.FieldName == "C_Planstate")
            {
                if (e.Value.ToString() == "0")
                {
                    e.DisplayText = "未完成";
                }
                else if (e.Value.ToString() == "1")
                {
                    e.DisplayText = "已完成";
                }
                else if (e.Value.ToString() == "2")
                {
                    e.DisplayText = "已作废";
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PT_BeltScalePlanOperate_Form frm = new PT_BeltScalePlanOperate_Form();
            frm.MainService = MainService;
            frm.BeltScalePlan = new PT_BeltScalePlan();
            frm.ShowDialog();
            Query();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var item = gView_BeltScalePlan.GetFocusedRow() as PT_BeltScalePlan;
            if (item == null)
                return;

            PT_BeltScalePlanOperate_Form frm = new PT_BeltScalePlanOperate_Form();
            frm.MainService = MainService;
            frm.BeltScalePlan = item;
            frm.ShowDialog();
            Query();
    }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            var item = gView_BeltScalePlan.GetFocusedRow() as PT_BeltScalePlan;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
            {
                item.C_Updatetime = CommonHelper.TimeToStr14(DateTime.Now);
                item.C_Updateusername = SessionHelper.LogUserNickName;
                var result = MainService.ExecuteDB_InvalidBeltScalePlanByIntId(item);
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

        private void btn_Export2_Click(object sender, EventArgs e)
        {
            if (gCtrl_BeltScalePlan.DataSource == null)
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
                gView_BeltScalePlan.ExportToXls(fileDialog.FileName, options);
            }
        }

        private void gView_BeltScalePlan_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string state = gView_BeltScalePlan.GetRowCellValue(e.RowHandle, "C_Planstate").ToString();
            if (state == "2")
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void gView_BeltScalePlan_DoubleClick(object sender, EventArgs e)
        {
            btn_Update_Click(null, null);
        }
    }
}
