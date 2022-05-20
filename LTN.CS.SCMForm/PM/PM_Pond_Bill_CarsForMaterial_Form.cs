using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.ConditionEntity;
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
using DevExpress.XtraPrinting;
using System.Threading;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Pond_Bill_CarsForMaterial_Form : CoreForm
    {
        #region 实例变量
        public IPM_Bill_TruckService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        private PM_Bill_Truck selectMainEntity { get; set; }
        public ISM_Guid_InfoService guidService { get; set; }
        #endregion

        #region 构造函数
        public PM_Pond_Bill_CarsForMaterial_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
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
            ht.Add("TareWgtListNo1", "105");//105 106 是物资磅
            ht.Add("TareWgtListNo2","106");
            ht.Add("GrossWgtListNo1", "105");
            ht.Add("GrossWgtListNo2", "106");
            ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
            ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            return ht;
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Query_Click(object sender, EventArgs e)
        {
            SetGridData(false);
        }
        /// <summary>
        /// A4五联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
                if (rowHandles.Length == 0)
                {
                    return;
                }

                if (string.IsNullOrEmpty(txt_FromDeptName.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txt_FromDeptName, "供货单位为必填!", ErrorType.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txt_ToDeptName.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txt_ToDeptName, "收货单位为必填!", ErrorType.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txt_MaterialName.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txt_MaterialName, "品名为必填!", ErrorType.Warning);
                    return;
                }
                IList<PM_Bill_Truck> list = new List<PM_Bill_Truck>();
                if (rowHandles.Count() > 0)
                {
                    for (int i = rowHandles.Count()-1; i >=0; i--)
                    {
                        PM_Bill_Truck truck = MainService.ExecuteDB_QueryBillTruckByWgistonNo(gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString());
                        if (truck != null)
                        {
                            truck.I_PRINTNUM = 9;
                            var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck3(truck);
                            list.Add(truck);
                        }
                    }
                }
                XtraReport3 xt = new XtraReport3();
                XtraReport3_2 xt2 = new XtraReport3_2();
                XtraReport3_3 xt3 = new XtraReport3_3();
                XtraReport3_4 xt4 = new XtraReport3_4();
                XtraReport3_5 xt5 = new XtraReport3_5();
                
                if (list != null && list.Count != 0)
                {
                    Wgstion.fromdeptname = txt_FromDeptName.Text.Trim();
                    Wgstion.todeptname = txt_ToDeptName.Text.Trim();
                    Wgstion.materialname = txt_MaterialName.Text.Trim();
                    Wgstion.wgistion1 = Guid.NewGuid().ToString("N");
                    SM_Guid_Info guidInfo = new SM_Guid_Info();
                    guidInfo.strGuid = Wgstion.wgistion1;
                    guidService.ExecuteDB_InsertGuidInfo(guidInfo);
                    xt.DataSource = list;
                    xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    xt2.DataSource = list;
                    xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    xt3.DataSource = list;
                    xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    xt4.DataSource = list;
                    xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    xt5.DataSource = list;
                    xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    //ReportPrintTool tool = new ReportPrintTool(xt);
                    //tool.ShowPreview();
                    System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
                    string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
                    xt.Print(sDefault);
                    xt2.Print(sDefault);
                    xt3.Print(sDefault);
                    xt4.Print(sDefault);
                    xt5.Print(sDefault);
                }
            }
            catch (Exception)
            {
            }
           

        }
        private void PM_Pond_Bill_Cars_Form_Load(object sender, EventArgs e)
        {
            InitView(gView_TruckPoundBill); 
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
        }
        private void txt_CarName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        #endregion

        private void gToolStripButton4_Click(object sender, EventArgs e)
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
                try
                {
                    gView_TruckPoundBill.ExportToXls(fileDialog.FileName, options);
                    MessageBox.Show("报表导出成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报表导出失败", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                
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

        private void gView_TruckPoundBill_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "I_PRINTNUM")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "未打印"; break;
                        case "9":
                            e.DisplayText = "A4打印";break;
                        default:
                            e.DisplayText = "针式打印"; break;
                    }
                }
            }
        }

        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            IList<PM_Bill_Truck> list = new List<PM_Bill_Truck>();

            int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
            if (rowHandles.Count() > 0)
            {
                for (int i = rowHandles.Count() - 1; i >= 0; i--)
                {
                    PM_Bill_Truck truck = MainService.ExecuteDB_QueryBillTruckByWgistonNo(gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString());
                    if (truck != null)
                    {
                        if (truck.I_ONETWOPLAN == 1)
                        {
                            truck.C_TODEPTNAME = truck.C_MIDDLEDEPTNAME;
                        }
                        truck.I_PRINTNUM += 1;
                        var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck3(truck);
                        Wgstion.wgistion1 = truck.C_WGTLISTNO;
                        list.Add(truck);
                    }
                }
                XtraReport2 xt = new XtraReport2();
                xt.DataSource = list;
                xt.PageHeight = 500;
                xt.PageWidth = 827;
                xt.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                //ReportPrintTool tool = new ReportPrintTool(xt);
                //tool.ShowPreview();
                System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
                string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
                xt.Print(sDefault);
                SetGridData(false);
            }
        }
        //新增
        /// <summary>
        /// 一车两单打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            IList<PM_Bill_Truck> list = new List<PM_Bill_Truck>();
            var item = gView_TruckPoundBill.GetFocusedRow();
            if (item == null)
            {
                return;
            }
            PM_Bill_Truck truck = MainService.ExecuteDB_QueryBillTruckByWgistonNo((item as PM_Bill_Truck).C_WGTLISTNO);
            if (truck == null)
            {
                return;
            }
            if (truck.I_ONETWOPLAN == 1)
            {
                PM_Bill_Truck truck2 = truck;
                truck2.C_FROMDEPTNAME = truck.C_MIDDLEDEPTNAME;
                truck2.I_PRINTNUM += 1;
                //根据码单号更新打印次数
                var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck3(truck);

                Wgstion.wgistion1 = truck.C_WGTLISTNO;
                list.Add(truck2);
                XtraReport2 xt = new XtraReport2(); 
                //XtraReport2_2 xt = new XtraReport2_2();
                xt.DataSource = list;
                xt.PageHeight = 500;
                xt.PageWidth = 827;
                xt.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
                string sDefault = print.PrinterSettings.PrinterName;
                xt.Print(sDefault);
                SetGridData(false);
            }
        }

        private void gToolStripButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                txt_CarName.Focus();
                Hashtable ht = setCondition();
                var result = MainService.ExecuteDB_QueryPM_Bill_TruckByPondForAFourOne(ht);
                gridCtrl.DataSource = result;
                selectMainId = selectLeftIdOld;
                SetMainFocusRow();
                queryMain = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void gToolStripButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                txt_CarName.Focus();
                Hashtable ht = setCondition();
                var result = MainService.ExecuteDB_QueryPM_Bill_TruckByPondForAFourTwo(ht);
                gridCtrl.DataSource = result;
                selectMainId = selectLeftIdOld;
                SetMainFocusRow();
                queryMain = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void gToolStripButton5_Click(object sender, EventArgs e)
        {
            IList<PM_Bill_Truck> list = new List<PM_Bill_Truck>();

            int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
            if (rowHandles.Count() > 0)
            {
                for (int i = rowHandles.Count() - 1; i >= 0; i--)
                {
                    PM_Bill_Truck truck = MainService.ExecuteDB_QueryBillTruckByWgistonNo(gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString());
                    if (truck != null)
                    {
                        if (truck.I_ONETWOPLAN == 1)
                        {
                            truck.C_TODEPTNAME = truck.C_MIDDLEDEPTNAME;
                        }
                        truck.I_PRINTNUM += 1;
                        var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck3(truck);
                        Wgstion.wgistion1 = truck.C_WGTLISTNO;
                        list.Add(truck);
                    }
                }
                XtraReport2_2 xt = new XtraReport2_2();
                xt.DataSource = list;
                xt.PageHeight = 500;
                xt.PageWidth = 827;
                xt.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                //ReportPrintTool tool = new ReportPrintTool(xt);
                //tool.ShowPreview();
                System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
                string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
                xt.Print(sDefault);
                SetGridData(false);
            }
        }



        
    }
}
