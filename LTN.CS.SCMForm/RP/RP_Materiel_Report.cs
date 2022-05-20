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
using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.SCMForm.PM;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System.IO;
using Microsoft.Office.Interop.Excel;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace LTN.CS.SCMForm.RP
{
    public partial class RP_Materiel_Report : CoreForm
    {
        #region 实例变量
        public IPM_Pond_Bill_SuppliesService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        private PM_Pond_Bill_Supplies selectMainEntity { get; set; }
        public ISM_Guid_InfoService guidService { get; set; }
        public IRP_Print_RecordService printService { get; set; }
        public RP_Materiel_PrintRecord printEntity { get; set; }
    
        //定义全局变量
        public string fromDeptName = "";
        public string toDeptName = "";
        public string materielName = "";
        #endregion

        #region 构造函数
        public RP_Materiel_Report()
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
                var result = MainService.ExecuteDB_QueryByPond(ht);
                gcl_main.DataSource = result;

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
                fromDeptName = txt_FromDeptName.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txt_ToDeptName.Text.Trim()))
            {
                ht.Add("ToDeptName", txt_ToDeptName.Text.Trim());
                toDeptName = txt_ToDeptName.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txt_MaterialName.Text.Trim()))
            {
                ht.Add("MaterialName", txt_MaterialName.Text.Trim());
                materielName = txt_MaterialName.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txt_PlanNo.Text.Trim()))
            {
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_WgtlistNo.Text.Trim()))
            {
                ht.Add("WgtNo", txt_WgtlistNo.Text.Trim());
            }
            //新增
            if (checkEdit1.Checked)
            {
                ht.Add("isChecked", "Y");
            }
            else
            {
                ht.Add("isChecked", "N");
            }
            ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
            ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            return ht;
        }

        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_Pond_Bill_Supplies group = gvw_main.GetRow(i) as PM_Pond_Bill_Supplies;
                    if (group.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
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
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        #endregion

        private void btn_Query_Click(object sender, EventArgs e)
        {
            SetGridData(false);
        }
        /// <summary>
        /// A4五联打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowHandles = gvw_main.GetSelectedRows();
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
                //IList<PM_Pond_Bill_Supplies> list = new List<PM_Pond_Bill_Supplies>();
                IList<PM_Pond_Bill_Supplies_New> list = new List<PM_Pond_Bill_Supplies_New>();
                if (rowHandles.Count() > 0)
                {
                    for (int i = rowHandles.Count() - 1; i >= 0; i--)
                    {
                        //string s = gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString();
                        PM_Pond_Bill_Supplies truck = MainService.ExecuteDB_QueryByWgistonNo(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());

                        if (truck != null)
                        {
                            truck.PrintNum = 9;
                            var rs = MainService.ExecuteDB_UpdatePrint1(truck);
                            //2022.4.25 李佳政
                            printEntity = new RP_Materiel_PrintRecord();
                            printEntity.PlanNo = truck.PlanNo;
                            printEntity.WgtlistNo = truck.WgtlistNo;
                            printEntity.MaterialName = truck.MaterialName;
                            printEntity.Printer = SessionHelper.LogUserNickName;
                            printEntity.PrintTime = CommonHelper.TimeToStr14(DateTime.Now);
                            printEntity.WagNo = truck.WagNo;
                            printService.ExecuteDB_InsertRP_Print_Record(printEntity);


                            //list.Add(truck);
                            PM_Pond_Bill_Supplies_New newBill = transferObject(truck);
                            list.Add(newBill);
                        }
                    }
                }
                XtraReportRP xt = new XtraReportRP();//修改模板

                XtraReportRP_2 xt2 = new XtraReportRP_2();
                XtraReportRP_3 xt3 = new XtraReportRP_3();
                XtraReportRP_4 xt4 = new XtraReportRP_4();
                XtraReportRP_5 xt5 = new XtraReportRP_5();

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
                    SetGridData(false);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RP_Materiel_Report_Load(object sender, EventArgs e)
        {
            InitView(gvw_main);
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            //初始化分联打印下拉框
            setDropList_fenlian();
        }

        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            IList<PM_Pond_Bill_Supplies> list = new List<PM_Pond_Bill_Supplies>();
            //IList<PM_Pond_Bill_Supplies_New> list = new List<PM_Pond_Bill_Supplies_New>();
            int[] rowHandles = gvw_main.GetSelectedRows();
            if (rowHandles.Count() > 0)
            {
                for (int i = rowHandles.Count() - 1; i >= 0; i--)
                {
                    PM_Pond_Bill_Supplies truck = MainService.ExecuteDB_QueryByWgistonNo(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());
                    if (truck != null)
                    {
                        truck.PrintNum += 1;
                        var rs = MainService.ExecuteDB_UpdatePrint1(truck);
                        Wgstion.wgistion1 = truck.WgtlistNo;
                        list.Add(truck);

                        //报表打印记录 2022 4.25李佳政
                        printEntity = new RP_Materiel_PrintRecord();
                        printEntity.PlanNo = truck.PlanNo;
                        printEntity.WgtlistNo = truck.WgtlistNo;
                        printEntity.MaterialName = truck.MaterialName;
                        printEntity.Printer = SessionHelper.LogUserNickName;
                        printEntity.PrintTime = CommonHelper.TimeToStr14(DateTime.Now);
                        printEntity.WagNo = truck.WagNo;
                        printService.ExecuteDB_InsertRP_Print_Record(printEntity);

                        /*
                        PM_Pond_Bill_Supplies_New newBill = transferObject(truck);
                        list.Add(newBill);
                         * */
                    }
                }
                XtraReportRP2 xt = new XtraReportRP2();
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

        private void gToolStripButton4_Click(object sender, EventArgs e)
        {
            /*
            if (gcl_main.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            //fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsxExportOptions options = new XlsxExportOptions();//使用xlsx
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                //在这里对gvw_main中的数据进行一次转化
                //gvw_main.ExportToXlsx(fileDialog.FileName, options);
                DataGridToExcel(gvw_main, fileDialog.FileName);                                                             
            }
             * */
            if (gcl_main.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            //fileDialog.Title = Text;           
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel) return;
            string fileName = fileDialog.FileName;
            if (fileName == "")
            {
                MessageBox.Show("请输入文件名!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            DataExportToExcel(gvw_main, fileName);
            //DataGridToExcel(gvw_main);
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "PrintNum")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "未打印"; break;
                        case "9":
                            e.DisplayText = "A4打印"; break;
                        default:
                            e.DisplayText = "针式打印"; break;
                    }
                }
            }
        }
        //新增
        /// <summary>
        /// 磅单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_WgtlistNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetGridData(false);
            }
        }
        /// <summary>
        /// 来源单位回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_FromDeptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetGridData(false);
            }
        }
        /// <summary>
        /// 品名回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_MaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetGridData(false);
            }
        }
        /// <summary>
        /// 委托单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetGridData(false);
            }
        }
        /// <summary>
        /// 去向单位回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_ToDeptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetGridData(false);
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
                SetGridData(false);
            }
        }
        //11-11 新增分联打印
        private void setDropList_fenlian()
        {
            checkedComboBoxEdit_fenlian.Properties.Items.Clear();
            //自定义数组
            string[] strs = new string[] { "第一联", "第二联", "第三联", "第四联", "第五联" };
            //添加项
            checkedComboBoxEdit_fenlian.Properties.Items.AddRange(strs);
            /*
            if (checkedComboBoxEdit1.Properties.Items.Count > 0)
            {
                checkedComboBoxEdit1.Properties.Items[strs[0]].CheckState = CheckState.Checked;
            }
             */

            //是否显示确定、取消按钮
            checkedComboBoxEdit_fenlian.Properties.ShowButtons = true;
            checkedComboBoxEdit_fenlian.Properties.DropDownRows = checkedComboBoxEdit_fenlian.Properties.Items.Count + 1;
        }
        /// <summary>
        /// 分联打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_printFL_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowHandles = gvw_main.GetSelectedRows();
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
                IList<PM_Pond_Bill_Supplies> list = new List<PM_Pond_Bill_Supplies>();

                if (rowHandles.Count() > 0)
                {
                    for (int i = rowHandles.Count() - 1; i >= 0; i--)
                    {
                        //string s = gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString();
                        PM_Pond_Bill_Supplies bill = MainService.ExecuteDB_QueryByWgistonNo(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());

                        if (bill != null)
                        {
                            bill.PrintNum = 9;
                            var rs = MainService.ExecuteDB_UpdatePrint1(bill);

                            //2022.4.25 李佳政
                            printEntity = new RP_Materiel_PrintRecord();
                            printEntity.PlanNo = bill.PlanNo;
                            printEntity.WgtlistNo = bill.WgtlistNo;
                            printEntity.MaterialName = bill.MaterialName;
                            printEntity.Printer = SessionHelper.LogUserNickName;
                            printEntity.PrintTime = CommonHelper.TimeToStr14(DateTime.Now);
                            printEntity.WagNo = bill.WagNo;
                            printService.ExecuteDB_InsertRP_Print_Record(printEntity);

                            list.Add(bill);
                        }
                    }
                }
                //实现按天、分联打印
                //增加一个选择第几联打印的下拉控件
                List<object> checkedComValues = checkedComboBoxEdit_fenlian.Properties.Items.GetCheckedValues();
                //1.时间2.联    使用嵌套循环来处理                
                DateTime startTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text);
                DateTime endTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text);
                DateTime time1 = startTime;
                //配置打印机信息
                System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
                string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
                //配置表头信息               
                Wgstion.fromdeptname = fromDeptName;
                Wgstion.todeptname = toDeptName;
                Wgstion.materialname = materielName;
                Console.WriteLine(Wgstion.fromdeptname + '\t' + Wgstion.todeptname + '\t' + Wgstion.materialname);
                //生成32位格式的唯一标识符字符串
                Wgstion.wgistion1 = Guid.NewGuid().ToString("N");
                SM_Guid_Info guidInfo = new SM_Guid_Info();
                guidInfo.strGuid = Wgstion.wgistion1;
                guidService.ExecuteDB_InsertGuidInfo(guidInfo);

                //根据是否勾选按天打印来区分
                Boolean isDay = checkEdit_printByDate.Checked;
                if (!isDay)
                {
                    IList<PM_Pond_Bill_Supplies_New> newList = new List<PM_Pond_Bill_Supplies_New>();
                    foreach (PM_Pond_Bill_Supplies bill in list)
                    {
                        PM_Pond_Bill_Supplies_New newBill = transferObject(bill);
                        newList.Add(newBill);
                    }


                    if (checkedComValues.Count == 5 || checkedComValues.Count == 0)
                    {
                        XtraReportRP xt = new XtraReportRP();
                        XtraReportRP_2 xt2 = new XtraReportRP_2();
                        XtraReportRP_3 xt3 = new XtraReportRP_3();
                        XtraReportRP_4 xt4 = new XtraReportRP_4();
                        XtraReportRP_5 xt5 = new XtraReportRP_5();
                        /*
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
                         * */
                        xt.DataSource = newList;
                        xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        xt2.DataSource = newList;
                        xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        xt3.DataSource = newList;
                        xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        xt4.DataSource = newList;
                        xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        xt5.DataSource = newList;
                        xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        /*
                        Console.WriteLine("xt打印一次");
                        Console.WriteLine("xt2打印一次");
                        Console.WriteLine("xt3打印一次");
                        Console.WriteLine("xt4打印一次");
                        Console.WriteLine("xt5打印一次");
                        */
                        xt.Print(sDefault);
                        xt2.Print(sDefault);
                        xt3.Print(sDefault);
                        xt4.Print(sDefault);
                        xt5.Print(sDefault);
                    }
                    else
                    {
                        for (int j = 0; j < checkedComValues.Count; j++)
                        {
                            switch (checkedComValues[j].ToString())
                            {
                                /*
                            case "第一联":
                                XtraReportRP xt = new XtraReportRP();
                                xt.DataSource = list;
                                xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                xt.Print(sDefault);
                                //Console.WriteLine("xt打印一次" + time1.ToString());
                                break;
                            case "第二联":
                                XtraReportRP_2 xt2 = new XtraReportRP_2();
                                xt2.DataSource = list;
                                xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                xt2.Print(sDefault);
                                //Console.WriteLine("xt2打印一次" + time1.ToString());
                                break;
                            case "第三联":
                                XtraReportRP_3 xt3 = new XtraReportRP_3();
                                xt3.DataSource = list;
                                xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                xt3.Print(sDefault);
                                //Console.WriteLine("xt3打印一次" + time1.ToString());
                                break;
                            case "第四联":
                                XtraReportRP_4 xt4 = new XtraReportRP_4();
                                xt4.DataSource = list;
                                xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                xt4.Print(sDefault);
                                //Console.WriteLine("xt4打印一次" + time1.ToString());
                                break;
                            case "第五联":
                                XtraReportRP_5 xt5 = new XtraReportRP_5();
                                xt5.DataSource = list;
                                xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                xt5.Print(sDefault);
                                //Console.WriteLine("xt5打印一次" + time1.ToString());
                                break;
                                 * */
                                case "第一联":
                                    XtraReportRP xt = new XtraReportRP();
                                    xt.DataSource = newList;
                                    xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt.Print(sDefault);
                                    //Console.WriteLine("xt打印一次" + time1.ToString());
                                    break;
                                case "第二联":
                                    XtraReportRP_2 xt2 = new XtraReportRP_2();
                                    xt2.DataSource = newList;
                                    xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt2.Print(sDefault);
                                    //Console.WriteLine("xt2打印一次" + time1.ToString());
                                    break;
                                case "第三联":
                                    XtraReportRP_3 xt3 = new XtraReportRP_3();
                                    xt3.DataSource = newList;
                                    xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt3.Print(sDefault);
                                    //Console.WriteLine("xt3打印一次" + time1.ToString());
                                    break;
                                case "第四联":
                                    XtraReportRP_4 xt4 = new XtraReportRP_4();
                                    xt4.DataSource = newList;
                                    xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt4.Print(sDefault);
                                    //Console.WriteLine("xt4打印一次" + time1.ToString());
                                    break;
                                case "第五联":
                                    XtraReportRP_5 xt5 = new XtraReportRP_5();
                                    xt5.DataSource = newList;
                                    xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt5.Print(sDefault);
                                    //Console.WriteLine("xt5打印一次" + time1.ToString());
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    //勾选了按天打印
                    while (time1 < endTime)
                    {
                        //对要打印的数据进行筛选
                        string time = time1.ToString("yyyyMMdd");
                        time1 = time1.AddDays(1);
                        IList<PM_Pond_Bill_Supplies> printList = list.Where(s => s.CreateTime.Contains(time)).ToList<PM_Pond_Bill_Supplies>();
                        if (printList == null || printList.Count == 0)
                        {
                            continue;
                        }

                        IList<PM_Pond_Bill_Supplies_New> newPrintList = new List<PM_Pond_Bill_Supplies_New>();
                        foreach (PM_Pond_Bill_Supplies bill in printList)
                        {
                            PM_Pond_Bill_Supplies_New newBill = transferObject(bill);
                            newPrintList.Add(newBill);
                        }

                        if (checkedComValues.Count == 5 || checkedComValues.Count == 0)
                        {
                            XtraReportRP xt = new XtraReportRP();

                            XtraReportRP_2 xt2 = new XtraReportRP_2();
                            XtraReportRP_3 xt3 = new XtraReportRP_3();
                            XtraReportRP_4 xt4 = new XtraReportRP_4();
                            XtraReportRP_5 xt5 = new XtraReportRP_5();
                            /*
                            xt.DataSource = printList;
                            xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt2.DataSource = printList;
                            xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt3.DataSource = printList;
                            xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt4.DataSource = printList;
                            xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt5.DataSource = printList;
                            xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                             */
                            xt.DataSource = newPrintList;
                            xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt2.DataSource = newPrintList;
                            xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt3.DataSource = newPrintList;
                            xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt4.DataSource = newPrintList;
                            xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            xt5.DataSource = newPrintList;
                            xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;

                            /*
                            Console.WriteLine("xt打印一次");
                            Console.WriteLine("xt2打印一次");
                            Console.WriteLine("xt3打印一次");
                            Console.WriteLine("xt4打印一次");
                            Console.WriteLine("xt5打印一次");
                            */
                            xt.Print(sDefault);
                            xt2.Print(sDefault);
                            xt3.Print(sDefault);
                            xt4.Print(sDefault);
                            xt5.Print(sDefault);
                        }
                        else
                        {
                            for (int j = 0; j < checkedComValues.Count; j++)
                            {
                                switch (checkedComValues[j].ToString())
                                {
                                    /*
                                case "第一联":
                                    XtraReportRP xt = new XtraReportRP();
                                    xt.DataSource = printList;
                                    xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt.Print(sDefault);
                                    //Console.WriteLine("xt打印一次" + time1.ToString() + printList[0].UpdateTime);
                                    break;
                                case "第二联":
                                    XtraReportRP_2 xt2 = new XtraReportRP_2();
                                    xt2.DataSource = printList;
                                    xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt2.Print(sDefault);
                                    //Console.WriteLine("xt2打印一次" + time1.ToString() + printList[0].UpdateTime);
                                    break;
                                case "第三联":
                                    XtraReportRP_3 xt3 = new XtraReportRP_3();
                                    xt3.DataSource = printList;
                                    xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt3.Print(sDefault);
                                    //Console.WriteLine("xt3打印一次" + time1.ToString() + printList[0].UpdateTime);
                                    break;
                                case "第四联":
                                    XtraReportRP_4 xt4 = new XtraReportRP_4();
                                    xt4.DataSource = printList;
                                    xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt4.Print(sDefault);
                                    //Console.WriteLine("xt4打印一次" + time1.ToString() + printList[0].UpdateTime);
                                    break;
                                case "第五联":
                                    XtraReportRP_5 xt5 = new XtraReportRP_5();
                                    xt5.DataSource = printList;
                                    xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                    xt5.Print(sDefault);
                                    //Console.WriteLine("xt5打印一次" + time1.ToString() + printList[0].UpdateTime);
                                    break;
                                     * */
                                    case "第一联":
                                        XtraReportRP xt = new XtraReportRP();
                                        xt.DataSource = newPrintList;
                                        xt.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                        xt.Print(sDefault);
                                        //Console.WriteLine("xt打印一次" + time1.ToString() + newPrintList[0].UpdateTime);
                                        break;
                                    case "第二联":
                                        XtraReportRP_2 xt2 = new XtraReportRP_2();
                                        xt2.DataSource = newPrintList;
                                        xt2.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                        xt2.Print(sDefault);
                                        //Console.WriteLine("xt2打印一次" + time1.ToString() + newPrintList[0].UpdateTime);
                                        break;
                                    case "第三联":
                                        XtraReportRP_3 xt3 = new XtraReportRP_3();
                                        xt3.DataSource = newPrintList;
                                        xt3.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                        xt3.Print(sDefault);
                                        //Console.WriteLine("xt3打印一次" + time1.ToString() + newPrintList[0].UpdateTime);
                                        break;
                                    case "第四联":
                                        XtraReportRP_4 xt4 = new XtraReportRP_4();
                                        xt4.DataSource = newPrintList;
                                        xt4.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                        xt4.Print(sDefault);
                                        //Console.WriteLine("xt4打印一次" + time1.ToString() + newPrintList[0].UpdateTime);
                                        break;
                                    case "第五联":
                                        XtraReportRP_5 xt5 = new XtraReportRP_5();
                                        xt5.DataSource = newPrintList;
                                        xt5.PaperKind = System.Drawing.Printing.PaperKind.A4;
                                        xt5.Print(sDefault);
                                        //Console.WriteLine("xt5打印一次" + time1.ToString() + newPrintList[0].UpdateTime);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //使用新增打印模板
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            IList<PM_Pond_Bill_Supplies> list = new List<PM_Pond_Bill_Supplies>();

            int[] rowHandles = gvw_main.GetSelectedRows();
            if (rowHandles.Count() > 0)
            {
                for (int i = rowHandles.Count() - 1; i >= 0; i--)
                {
                    PM_Pond_Bill_Supplies truck = MainService.ExecuteDB_QueryByWgistonNo(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());
                    if (truck != null)
                    {
                        truck.PrintNum += 1;
                        var rs = MainService.ExecuteDB_UpdatePrint1(truck);
                        Wgstion.wgistion1 = truck.WgtlistNo;
                        list.Add(truck);
                    }
                }
                XtraReportRP2_New xt = new XtraReportRP2_New();
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

        public PM_Pond_Bill_Supplies_New transferObject(PM_Pond_Bill_Supplies bill)
        {
            PM_Pond_Bill_Supplies_New newBill = new PM_Pond_Bill_Supplies_New();
            newBill.PlanStatus = bill.PlanStatus;
            newBill.PlanNo = bill.PlanNo;
            newBill.WagNo = bill.WagNo;
            newBill.MaterialNo = bill.MaterialNo;
            newBill.MaterialName = bill.MaterialName;
            newBill.FromDeptNo = bill.FromDeptNo;
            newBill.FromDeptName = bill.FromDeptName;
            newBill.FromStoreNo = bill.FromDeptNo;
            newBill.FromStoreName = bill.FromStoreName;
            newBill.ToDeptNo = bill.ToDeptName;
            newBill.ToDeptName = bill.ToDeptName;
            newBill.ToStoreNo = bill.ToStoreNo;
            newBill.ToStoreName = bill.ToStoreName;
            newBill.ShipNo = bill.ShipNo;
            newBill.FromStation = bill.FromStation;
            newBill.SerialNo = bill.SerialNo;
            newBill.DeliveryNo = bill.DeliveryNo;
            newBill.ContractNo = bill.ContractNo;
            newBill.ProjectNo = bill.ProjectNo;
            newBill.WayBillNo = bill.WayBillNo;
            newBill.MarshallingNo = bill.MarshallingNo;
            newBill.BusinessType = bill.BusinessType;
            newBill.WeightType = bill.WeightType;
            newBill.TareType = bill.TareType;
            newBill.MoveStillType = bill.MoveStillType;
            newBill.PlanLimitTime = bill.PlanLimitTime;
            newBill.PondLimit = bill.PondLimit;
            newBill.Remark = bill.Remark;
            newBill.CReserve1 = bill.CReserve1;
            newBill.CReserve2 = bill.CReserve2;
            newBill.CReserve3 = bill.CReserve3;
            newBill.IReserve1 = bill.IReserve1;
            newBill.IReserve2 = bill.IReserve2;
            newBill.IReserve3 = bill.IReserve3;
            newBill.CreateUser = bill.CreateUser;
            newBill.CreateTime = bill.CreateTime;
            newBill.WgtlistNo = bill.WgtlistNo;

            string grosswgt = (bill.GrossWgt * 1000).ToString();
            string tarewgt = (bill.TareWgt * 1000).ToString();
            string netwgt = (bill.NetWgt * 1000).ToString();

            newBill.GrossWgt = System.Int32.Parse(grosswgt.Contains('.') ? grosswgt.Substring(0, grosswgt.IndexOf('.')) : grosswgt);
            newBill.TareWgt = System.Int32.Parse(tarewgt.Contains('.') ? tarewgt.Substring(0, tarewgt.IndexOf('.')) : tarewgt);
            newBill.NetWgt = System.Int32.Parse(netwgt.Contains('.') ? netwgt.Substring(0, netwgt.IndexOf('.')) : netwgt);

            newBill.GrossWgtTime = bill.GrossWgtTime;
            newBill.TareWgtTime = bill.TareWgtTime;
            newBill.GrossWgtSiteNo = bill.GrossWgtSiteNo;
            newBill.GrossWgtSiteName = bill.GrossWgtSiteName;
            newBill.TareWgtSiteNo = bill.TareWgtSiteNo;
            newBill.TareWgtSiteName = bill.TareWgtSiteName;
            newBill.GrossWgtMan = bill.GrossWgtMan;
            newBill.TareWgtMan = bill.TareWgtMan;
            newBill.PondRemark = bill.PondRemark;
            newBill.CReserveFlag1 = bill.CReserveFlag1;
            newBill.CReserveFlag2 = bill.CReserveFlag2;
            newBill.CReserveFlag3 = bill.CReserveFlag3;
            newBill.IReserveFlag1 = bill.IReserveFlag1;
            newBill.IReserveFlag2 = bill.IReserveFlag2;
            newBill.IReserveFlag3 = bill.IReserveFlag3;
            newBill.PrintNum = bill.PrintNum;
            return newBill;
        }

        public static void DataGridToExcel(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {
            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";        
            saveFileDialog.FileName = title;
            DialogResult dr = saveFileDialog.ShowDialog();            
            */
            SaveFileDialog fileDialog = new SaveFileDialog();
            //fileDialog.Title = Text;           
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel) return;
            Stream myStream;
            myStream = fileDialog.OpenFile();
            string fileName = fileDialog.FileName;
            if (fileName == "")
            {
                MessageBox.Show("请输入文件名!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                List<string> listFiledName = new List<string>();
                for (int i = 0; i <= dgv.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        str += "序号";
                    }
                    else
                    {
                        if (dgv.Columns[i - 1].Visible == true)
                        {
                            str += "\t";
                            string caption = dgv.Columns[i - 1].Caption;
                            if (caption.Contains('吨'))
                            {
                                caption = caption.Replace("(吨)", "(KG)");
                            }
                            str += caption;
                            listFiledName.Add(dgv.Columns[i - 1].FieldName);
                        }
                    }
                }
                sw.WriteLine(str);
                int count = 0;

                //写内容               
                List<string> list = new List<string>();
                list.Add("GrossWgt");
                list.Add("TareWgt");
                list.Add("NetWgt");
                List<string> list2 = new List<string>();
                list2.Add("GrossWgtTime");
                list2.Add("TareWgtTime");
                list2.Add("ContractNo");
                list2.Add("CreateTime");
                list2.Add("UpdateTime");
                list2.Add("PlanLimitTime");
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    count++;
                    string tempStr = "";
                    for (int k = 0; k < dgv.Columns.Count + 1; k++)
                    {
                        if (k == 0)
                        {
                            tempStr = count.ToString();
                        }
                        else
                        {
                            if (dgv.Columns[k - 1].Visible == true)
                            {
                                tempStr += "\t";
                                string columnName = listFiledName[k - 1];
                                //tempStr += dt.Rows[j][k - 1].ToString().Trim();
                                if (dgv.GetRowCellValue(j, columnName) == null)
                                {
                                    tempStr += "";
                                }
                                else if (list.Contains(columnName))
                                {
                                    string temp = dgv.GetRowCellValue(j, columnName).ToString();
                                    string result = (System.Decimal.Parse(temp) * 1000).ToString();
                                    tempStr += result.Contains('.') ? result.Substring(0, result.IndexOf('.')) : result;
                                    //tempStr += result.Substring(0, result.IndexOf('.'));
                                }
                                else if (list2.Contains(columnName))
                                {
                                    tempStr += dgv.GetRowCellValue(j, columnName).ToString() + "\'";
                                }
                                else
                                {
                                    tempStr += dgv.GetRowCellValue(j, columnName).ToString();
                                }
                            }
                        }
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                sw.Dispose();
                myStream.Close();
                myStream.Dispose();
                MessageBox.Show("报表导出成功!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        public static void DataExportToExcel(DevExpress.XtraGrid.Views.Grid.GridView gv, string fileName)
        {
            try
            {
                if (gv == null)
                {
                    MessageBox.Show("GridView 不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (gv.RowCount < 1)
                {
                    MessageBox.Show("GridView中内容为空,请先选择数据！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //获取列名、列标题  放到List集合中
                System.Collections.ArrayList listCaption = new System.Collections.ArrayList();
                System.Collections.ArrayList listFieldName = new System.Collections.ArrayList();
                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    if (gv.Columns[i].Visible)
                    {
                        //CustomizationSearchCaption可以获取到GridView的列名
                        listCaption.Add(gv.Columns[i].CustomizationSearchCaption);
                        listFieldName.Add(gv.Columns[i].FieldName);
                    }
                }

                IWorkbook workbook = null;
                ISheet sheet;

                //保存文件
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
                saveFileDialog.RestoreDirectory = true;

                MemoryStream ms = new MemoryStream();

                string extension = Path.GetExtension(fileName);

                if (extension.Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook();
                }
                //创建Sheet
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet("Sheet1");//Sheet的名称  
                }
                else
                {
                    MessageBox.Show("导出报表失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                sheet.ForceFormulaRecalculation = true;
                //设置几种列的样式

                ICellStyle cellStyle1 = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                //cellStyle1.DataFormat = format.GetFormat("yyyy年m月d日");                
                cellStyle1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

                //设置字体
                if (workbook is HSSFWorkbook)
                {
                    HSSFFont font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "新宋体";
                    font.FontHeightInPoints = 9;
                    cellStyle1.SetFont(font);
                }
                else if (workbook is XSSFWorkbook)
                {
                    XSSFFont font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "新宋体";
                    font.FontHeightInPoints = 9;
                    cellStyle1.SetFont(font);
                }

                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; //水平居中
                cellStyle1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //垂直居中

                //存入列名
                IRow row0 = sheet.CreateRow(0);
                for (int i = 0; i < listCaption.Count; i++)
                {
                    string captionName = listCaption[i].ToString().Trim();
                    if (captionName.Contains('吨'))
                    {
                        captionName = captionName.Replace("(吨)", "(KG)");
                    }
                    row0.CreateCell(i).SetCellValue(captionName);

                    if (listCaption[i].ToString().Contains("号") || listCaption[i].ToString().Contains("时间") || listCaption[i].ToString().Contains("单位"))
                    {
                        sheet.SetColumnWidth(i, 10 * 500);
                    }
                    else if (listCaption[i].ToString().Contains("名称"))
                    {
                        sheet.SetColumnWidth(i, 10 * 700);
                    }
                    else
                    {
                        sheet.SetColumnWidth(i, 10 * 300);
                    }

                    //设置行高
                    row0.HeightInPoints = 15f;
                    row0.GetCell(i).CellStyle = cellStyle1;
                }
                int grossWgtSum = 0;
                int tareWgtSum = 0;
                int netWgtSum = 0;
                for (int r = 0; r < gv.RowCount; r++)
                {
                    //创建行row
                    IRow row = sheet.CreateRow(r + 1);
                    //创建列cell
                    for (int i = 0; i < listFieldName.Count; i++)
                    {
                        //获取每行每列的数据开始填充
                        var obj = gv.GetRowCellValue(r, listFieldName[i].ToString());
                        if (obj != null)
                        {
                            string fieledName = listFieldName[i].ToString().Trim();
                            if (fieledName == "GrossWgt" || fieledName == "TareWgt" || fieledName == "NetWgt")
                            {
                                string result = (Convert.ToDecimal(obj) * 1000).ToString();
                                result = result.Contains('.') ? result.Substring(0, result.IndexOf('.')) : result;
                                row.CreateCell(i, CellType.Numeric).SetCellValue(Convert.ToInt32(result));
                                switch (fieledName)
                                {
                                    case "GrossWgt":
                                        grossWgtSum += Convert.ToInt32(result);
                                        break;
                                    case "TareWgt":
                                        tareWgtSum += Convert.ToInt32(result);
                                        break;
                                    case "NetWgt":
                                        netWgtSum += Convert.ToInt32(result);
                                        break;
                                }
                            }
                            else
                            {
                                row.CreateCell(i).SetCellValue(obj.ToString());
                            }
                        }
                        else
                        {
                            row.CreateCell(i).SetCellValue(string.Empty);
                        }
                        row.GetCell(i).CellStyle = cellStyle1;
                    }
                }
                //加上最后一行
                IRow endRow = sheet.CreateRow(gv.RowCount + 1);
                for (int i = 0; i < listFieldName.Count; i++)
                {
                    switch (i)
                    {
                        case 1:
                            endRow.CreateCell(i).SetCellValue(gv.RowCount);
                            break;
                        case 5:
                            endRow.CreateCell(i).SetCellValue(grossWgtSum.ToString() + '.');
                            break;
                        case 6:
                            endRow.CreateCell(i).SetCellValue(tareWgtSum.ToString() + '.');
                            break;
                        case 7:
                            endRow.CreateCell(i).SetCellValue(netWgtSum.ToString() + '.');
                            break;
                        default:
                            endRow.CreateCell(i).SetCellValue(string.Empty);
                            break;
                    }
                    endRow.GetCell(i).CellStyle = cellStyle1;

                }
                //保存为Excel文件                  
                workbook.Write(ms);
                FileStream file = new FileStream(fileName, FileMode.Create);
                workbook.Write(file);
                file.Close();
                workbook.Close();

                MessageBox.Show("导出报表成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出报表失败！", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }



    }
}
