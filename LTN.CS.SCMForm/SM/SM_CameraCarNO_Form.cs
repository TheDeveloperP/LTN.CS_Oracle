using DevExpress.XtraCharts;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using LTN.CS.Base;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_CameraCarNO_Form : CoreForm
    {

        public ISM_CameraCarNOService MainService { get; set; }
        private SM_CameraCarNO selectEntity { get; set; }
        public ISM_PoundSite_InfoService PoundSite_InfoService { get; set; }
        public SM_CameraCarNO_Form()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面展示时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SM_CameraCarNO_Form_Shown(object sender, EventArgs e)
        {
            slu_SiteName.Properties.DataSource = PoundSite_InfoService.ExecuteDB_QueryAll();
            dt_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");         
            dt_EndTime.EditValue = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);

            BtnEnabled(false);
            
        }
        private void CarRecognitionRate()
        {
            gridControl2.DataSource = MainService.ExecuteDB_QueryCarRecognitionRateAll();
            gv_Site.BestFitColumns();
        }
        private void BtnEnabled(bool b)
        {
            txt_RFID.Enabled = b;
            txt_SystemCarPlate.Enabled = b;
            dt_MatchTime.Enabled = b;
            txt_MatchResults.Enabled = b;

        }
        /// <summary>
        /// 查询哈希表
        /// </summary>
        /// <returns></returns>
        private Hashtable hashTable()
        {
            Hashtable ht = new Hashtable();
            string siteno = string.Empty;
            if (!string.IsNullOrEmpty(slu_SiteName.Text))
            {
               siteno = slu_SiteName.EditValue.ToString().Trim();
            }
          
            string carplate = txt_CarPlateNumber.Text.ToString().Trim();
            string starttime = dt_StartTime.Text.Trim();
            string endtime = dt_EndTime.Text.Trim();
            ht.Add("PoundSiteName", siteno);
            ht.Add("Cameracarno", carplate);
            ht.Add("StartTime", starttime);
            ht.Add("EndTime", endtime);
            return ht;
        }

        private void gv_CarPlateNumber_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName== "Resulttype")
            {
                switch(e.Value.ToString().Trim())
                {
                    case "1":
                        e.DisplayText = "成功";
                        break;
                    case "0":
                        e.DisplayText = "失败";
                        break;
                    default:
                        e.DisplayText = "";
                        break;
                }
            }
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        { 
            IList<SM_CameraCarNO> CameraCarNos = MainService.ExecuteDB_QuerySiteCar(hashTable());
            gridControl1.DataSource = CameraCarNos;
            gv_CarPlateNumber.BestFitColumns();
            gridControl1.RefreshDataSource();
            if(CameraCarNos!=null && CameraCarNos.Count!=0)
            {
                int SuccessTotal = CameraCarNos.ToList().FindAll(r => r.Resulttype == 1).Count;
                int FailTotal = CameraCarNos.ToList().FindAll(r => r.Resulttype == 0).Count;
                double successrate = (double)SuccessTotal / (double)(SuccessTotal + FailTotal);
                string successRate = successrate.ToString("0.00%");
                txt_SucceedNumber.Text = SuccessTotal.ToString();
                txt_failedNumber.Text = FailTotal.ToString();
                txt_SuccessRate.Text = successRate;
            } 
        }

        private void gv_CarPlateNumber_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv_CarPlateNumber.GetFocusedRow() != null)
            {
                selectEntity = gv_CarPlateNumber.GetFocusedRow() as SM_CameraCarNO;
                DisplayData(selectEntity);
            }
        }
         /// <summary>
         /// 显示区内容
         /// </summary>
         /// <param name="selectEntity"></param>
        private void DisplayData(SM_CameraCarNO selectEntity)
        {
   
            if (!string.IsNullOrEmpty(selectEntity.Cameracarno.ToString()))
            {
                txt_RFID.Text = selectEntity.Cameracarno.ToString();
            }
            txt_SystemCarPlate.Text = selectEntity.Cardcarno.ToString();
            dt_MatchTime.Text = selectEntity.Createtime.ToString();
            if(selectEntity.Resulttype.ToString()=="1")
            {
                txt_MatchResults.Text = "成功";
            }
            else if(selectEntity.Resulttype.ToString() == "0")
            {
                txt_MatchResults.Text = "失败";
            }
            else
            {
                txt_MatchResults.Text = "";
            }
        }
        /// <summary>
        /// 站点识别率按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_site_Click(object sender, EventArgs e)
        {
            CarRecognitionRate();
            var rss = MainService.ExecuteDB_QueryCarRecognitionRateAll();
            DataTable dt = new DataTable();
            dt.Columns.Add("类型", Type.GetType("System.String"));
            dt.Columns.Add("数量", Type.GetType("System.Int32"));

            double SuccessTotal = rss.AsEnumerable().Select(d => Convert.ToDouble(d.Field<decimal>("成功"))).Sum();
            double FailTotal = rss.AsEnumerable().Select(d => Convert.ToDouble(d.Field<decimal>("失败"))).Sum();
            dt.Rows.Add(new object[] { "成功", SuccessTotal });
            dt.Rows.Add(new object[] { "失败", FailTotal });
            chartControl1.Series[0].ArgumentDataMember = "类型";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "数量" });
            chartControl1.Series[0].ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.DataSource = dt;

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if(gridControl2.DataSource!=null)
            {
                ExportToExcel(DateTime.Now.Date.ToString("yyyyMMdd")+"站点识别率",gridControl2);
            }
            else
            {
                MessageDxUtil.ShowTips("先查询数据再导出数据!");
            }
        }
        /// <summary>
        /// DevExpress通用导出Excel,支持多个控件同时导出在同一个Sheet表
        /// eg:ExportToXlsx("",gridControl1,gridControl2);
        /// 将gridControl1和gridControl2的数据一同导出到同一张工作表
        /// </summary>
        /// <param name="title">文件名</param>
        /// <param name="panels">控件集</param>
        public void ExportToExcel(string title, params IPrintable[] panels)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = title;
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
                return;
            string FileName = saveFileDialog.FileName;
            PrintingSystem ps = new PrintingSystem();
            CompositeLink link = new CompositeLink(ps);
            ps.Links.Add(link);
            foreach (IPrintable panel in panels)
            {
                link.Links.Add(CreatePrintableLink(panel));
            }
            link.Landscape = true;//横向           
            //判断是否有标题，有则设置         
            //link.CreateDocument(); //建立文档
            try
            {
                int count = 1;
                //在重复名称后加（序号）
                while (File.Exists(FileName))
                {
                    if (FileName.Contains(")."))
                    {
                        int start = FileName.LastIndexOf("(");
                        int end = FileName.LastIndexOf(").") - FileName.LastIndexOf("(") + 2;
                        FileName = FileName.Replace(FileName.Substring(start, end), string.Format("({0}).", count));
                    }
                    else
                    {
                        FileName = FileName.Replace(".", string.Format("({0}).", count));
                    }
                    count++;
                }
                if (FileName.LastIndexOf(".xlsx") >= FileName.Length - 5)
                {
                    XlsxExportOptions options = new XlsxExportOptions();
                    link.ExportToXlsx(FileName, options);
                }
                else
                {
                    XlsExportOptions options = new XlsExportOptions();
                    link.ExportToXls(FileName, options);
                }
                if (DevExpress.XtraEditors.XtraMessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(FileName);//打开指定路径下的文件
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowTips(ex.Message);
            }
        }
        /// <summary>
        /// 创建打印Componet 打印chart图表
        /// </summary>
        /// <param name="printable"></param>
        /// <returns></returns>
        PrintableComponentLink CreatePrintableLink(IPrintable printable)
        {
            ChartControl chart = printable as ChartControl;
            if (chart != null)
                chart.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch;
            PrintableComponentLink printableLink = new PrintableComponentLink() { Component = printable };
            return printableLink;
        }
    }
}
