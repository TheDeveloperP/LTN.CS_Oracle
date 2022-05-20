using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
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

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PoundBillMaintainForTruckHistory_Form : CoreForm
    {
        public IPM_Bill_TruckService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        public PM_PoundBillMaintainForTruckHistory_Form()
        {
            InitializeComponent();
        }
        private void PM_PoundBillMaintainForTruckHistory_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
        }


        private void Query(bool isFirst = false)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());
                ht.Add("WgtNo", txt_WgtNo.Text.Trim());
                ht.Add("CARNAME", txt_CarName.Text.Trim());
                if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
                {
                    ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                    ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));

                }
                var result = MainService.ExecuteDB_QueryPM_Bill_TruckHistoryByHashtable(ht);
                gCtrl_TruckPoundBill.DataSource = result;
                if (!isFirst)
                {
                    selectMainId = selectLeftIdOld;
                    SetMainFocusRow();
                }
                queryMain = true;
            }
            catch (Exception)
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
                    PM_Bill_Truck_History group = gView_TruckPoundBill.GetRow(i) as PM_Bill_Truck_History;
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

        private void gView_TruckPoundBill_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gView_TruckPoundBill.GetRow(e.RowHandle) as PM_Bill_Truck_History;
            if (item == null)
                return;
            if (!String.IsNullOrEmpty(item.C_UPDATECOLUMNS))
            {
                if (item.C_UPDATECOLUMNS=="作废")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                string[] columns = item.C_UPDATECOLUMNS.Split('|');
                if (columns!=null && columns.Contains(e.Column.FieldName))
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gCtrl_TruckPoundBill.DataSource==null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.FileName = Text;
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsxExportOptions options = new XlsxExportOptions();
                options.TextExportMode = TextExportMode.Text;
                gView_TruckPoundBill.ExportToXlsx(fileDialog.FileName, options);
            }
        }
        //新增
        /// <summary>
        /// 委托单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }
        /// <summary>
        /// 车号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CarName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }
        /// <summary>
        /// 磅单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_WgtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }

        
        
    }
}
