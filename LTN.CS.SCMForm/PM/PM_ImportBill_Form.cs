using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using LTN.CS.SCMForm.Common;
using System.Collections;
using DevExpress.XtraReports.UI;
using LTN.CS.SCMEntities.ConditionEntity;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_ImportBill_Form : CoreForm
    {
        public IPM_ImportBillService MainService;
         private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        private PM_ImportBill selectMainEntity { get; set; }
        public PM_ImportBill_Form()
        {
            InitializeComponent();
        }

        private void SetGridData(bool isFirst)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                var result = MainService.ExecuteDB_QueryPM_ImportBill(QueryHashTable());
                gCtrl_ImportBill.DataSource = result;

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
            int rowcount = gView_ImportBill.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_ImportBill group = gView_ImportBill.GetRow(i) as PM_ImportBill;
                    if (group.I_Intid == selectMainId)
                    {
                        gView_ImportBill.FocusedRowHandle = i;
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
                    gView_ImportBill.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gView_ImportBill.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        private List<PM_ImportBill> ConvertToList(List<Cell> Cells)
        {
            List<PM_ImportBill> ImportBills = null;
            try
            {
                ImportBills = new List<PM_ImportBill>();
                string CreateUserName= SessionHelper.LogUserNickName;
                int ColumnIndex= Cells.Max(r => r.ColumnIndex);
                int RowIndex = Cells.Max(r => r.RowIndex);
                string ImBatchNum = CommonHelper.TimeToStr14(DateTime.Now);
                for (int i = 1; i <= RowIndex; i++)
                {
                    int j = 3;
                    PM_ImportBill ImpotBill = new PM_ImportBill();
                    ImpotBill.C_CreateUserName = CreateUserName;
                    ImpotBill.C_ImBatchNum = ImBatchNum;
                    ImpotBill.C_CarNo = Cells.FirstOrDefault(r => r.RowIndex==i&&r.ColumnIndex==j).Value.ToString();
                    ImpotBill.C_PondNo = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j -2).Value.ToString();
                    ImpotBill.C_GrossWgtTime =Convert.ToDateTime( Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j+1).Value.ToString());
                    ImpotBill.C_TareWgtTime = Convert.ToDateTime(Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j+2).Value.ToString());
                    ImpotBill.C_MaterialName = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j+3).Value.ToString();
                    ImpotBill.N_GrossWgt = Convert.ToDecimal(Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j +4).Value.ToString());
                    ImpotBill.N_TareWgt = Convert.ToDecimal(Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j +5).Value.ToString());
                    ImpotBill.N_NetWgt = Convert.ToDecimal(Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j + 6).Value.ToString());
                    ImpotBill.C_FromDeptName = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j +7).Value.ToString();
                    ImpotBill.C_ToDeptName = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j + 8).Value.ToString();
                    ImpotBill.C_NetWgtMan = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j + 9).Value.ToString();
                    ImpotBill.C_Remark = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j + 13).Value.ToString();
                    ImpotBill.C_GrossWgtSite = Cells.FirstOrDefault(r => r.RowIndex == i && r.ColumnIndex == j + 14).Value.ToString();
                    ImportBills.Add(ImpotBill);
                }
            }
            catch (Exception ex)
            {
                ImportBills = null;
            }
            return ImportBills;

        }

        private Hashtable QueryHashTable()
        {
            Hashtable ht = new Hashtable();
            string carno = txt_CarNo.Text.Trim();
            DateTime startTime = Convert.ToDateTime(date_StartTime.Text);
            DateTime endTime = Convert.ToDateTime(date_EndTime.Text);
            //string type = cBox_Type.Text.Trim();
            ht.Add("C_CarNo", carno);
            ht.Add("StartTime", startTime);
            ht.Add("EndTime", endTime);
            int statevalue = 0;
            //if (cBox_Type.Text == "毛重时间") { statevalue = 1; }
            //if (cBox_Type.Text == "皮重时间") { statevalue = 2; }
            ht.Add("state", statevalue);
            return ht;
        }

        private void PM_ImportBill_Form_Load(object sender, EventArgs e)
        {
            InitView(gView_ImportBill);
            this.date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            this.date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
        }
 
        #region
        //private  DataTable ExcelToDataTable(string filePath, bool isColumnName)
        //{
        //    DataTable dataTable = null;
        //    FileStream fs = null;
        //    DataColumn column = null;
        //    DataRow dataRow = null;
        //    IWorkbook workbook = null;
        //    ISheet sheet = null;
        //    IRow row = null;
        //    ICell cell = null;
        //    int startRow = 0;
        //    try
        //    {
        //        using (fs = File.OpenRead(filePath))
        //        {
        //            // 2007版本  
        //            if (filePath.IndexOf(".xlsx") > 0)
        //                workbook = new XSSFWorkbook(fs);
        //            // 2003版本  
        //            else if (filePath.IndexOf(".xls") > 0)
        //                workbook = new HSSFWorkbook(fs);

        //            if (workbook != null)
        //            {
        //                sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet  
        //                dataTable = new DataTable("Data");
        //                if (sheet != null)
        //                {
        //                    int rowCount = sheet.LastRowNum;//总行数  
        //                    if (rowCount > 0)
        //                    {
        //                        IRow firstRow = sheet.GetRow(0);//第一行  
        //                        int cellCount = firstRow.LastCellNum;//列数  

        //                        //构建datatable的列  
        //                        if (isColumnName)
        //                        {
        //                            startRow = 1;//如果第一行是列名，则从第二行开始读取  
        //                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
        //                            {
        //                                cell = firstRow.GetCell(i);
        //                                if (cell != null)
        //                                {
        //                                    if (cell.StringCellValue != null)
        //                                    {
        //                                        column = new DataColumn(cell.StringCellValue);
        //                                        dataTable.Columns.Add(column);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
        //                            {
        //                                column = new DataColumn("column" + (i + 1));
        //                                dataTable.Columns.Add(column);
        //                            }
        //                        }

        //                        //填充行  
        //                        for (int i = startRow; i <= rowCount; ++i)
        //                        {
        //                            row = sheet.GetRow(i);
        //                            if (row == null) continue;

        //                            dataRow = dataTable.NewRow();
        //                            for (int j = row.FirstCellNum; j < cellCount; ++j)
        //                            {
        //                                cell = row.GetCell(j);
        //                                if (cell == null)
        //                                {
        //                                    dataRow[j] = "";
        //                                }
        //                                else
        //                                {
        //                                    //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
        //                                    switch (cell.CellType)
        //                                    {
        //                                        case CellType.Blank:
        //                                            dataRow[j] = "";
        //                                            break;
        //                                        case CellType.Numeric:
        //                                            short format = cell.CellStyle.DataFormat;
        //                                            //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
        //                                            if (format == 14 || format == 31 || format == 57 || format == 58)
        //                                                dataRow[j] = cell.DateCellValue;
        //                                            else
        //                                                dataRow[j] = cell.NumericCellValue;
        //                                            break;
        //                                        case CellType.String:
        //                                            dataRow[j] = cell.StringCellValue;
        //                                            break;
        //                                    }
        //                                }
        //                            }
        //                            dataTable.Rows.Add(dataRow);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return dataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageDxUtil.ShowError(ex.Message);
        //        if (fs != null)
        //        {
        //            fs.Close();
        //        }
        //        return null;
        //    }
        //}



        ///// <summary>
        ///// 写excel
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //private  bool DataTableToExcel(DataTable dt, string excePath)
        //{
        //    bool result = false;
        //    IWorkbook workbook = null;
        //    FileStream fs = null;
        //    IRow row = null;
        //    ISheet sheet = null;
        //    ICell cell = null;
        //    try
        //    {
        //        if (dt != null)
        //        {
        //            workbook = new HSSFWorkbook();
        //            sheet = workbook.CreateSheet("Sheet0");//创建一个名称为Sheet0的表  
        //            int rowCount = dt.Rows.Count;//行数  
        //            int columnCount = dt.Columns.Count;//列数  

        //            //设置列头  
        //            row = sheet.CreateRow(0);//excel第一行设为列头  
        //            for (int c = 0; c < columnCount; c++)
        //            {
        //                cell = row.CreateCell(c);
        //                cell.SetCellValue(dt.Columns[c].ColumnName);
        //            }

        //            //设置每行每列的单元格,  
        //            for (int i = 0; i < rowCount; i++)
        //            {
        //                row = sheet.CreateRow(i + 1);
        //                for (int j = 0; j < columnCount; j++)
        //                {
        //                    cell = row.CreateCell(j);//excel第二行开始写入数据  
        //                    cell.SetCellValue(dt.Rows[i][j].ToString());
        //                }
        //            }
        //            if (File.Exists(excePath))
        //                File.Delete(excePath);
        //            using (fs = File.OpenWrite(excePath))
        //            {
        //                workbook.Write(fs);//向打开的这个xls文件中写入数据  
        //                result = true;
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (fs != null)
        //        {
        //            fs.Close();
        //        }
        //        return false;
        //    }
        //}
        #endregion

        private void gView_ImportBill_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView_ImportBill.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Lime;
            }
        }

        private void gView_ImportBill_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gView_ImportBill.GetFocusedRow() as PM_ImportBill;
                if (entity != null)
                {
                    selectMainId = entity.I_Intid;
                    selectMainRowNum = gView_ImportBill.FocusedRowHandle;
                }
                selectMainEntity = entity;
            }
        }

        private void btn_QueryData_Click(object sender, EventArgs e)
        {
            SetGridData(false);
        }

        private void btn_ImportData_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";
            fileDialog.RestoreDirectory = false;    //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.GetFullPath(fileDialog.FileName);
                PM_ImportExcel_Form form = new PM_ImportExcel_Form();
                form.SheetControl.LoadDocument(filePath);
                form.ShowDialog();
                if (form.Cells == null || form.Cells.Count == 0)
                {
                    return;
                }
                List<PM_ImportBill> ImportBills = ConvertToList(form.Cells);
                if (ImportBills == null || ImportBills.Count == 0)
                {
                    return;
                }
                object count = MainService.ExecuteDB_InsertPM_ImportBill(ImportBills);
                if (count == null)
                {
                    MessageDxUtil.ShowError("插入异常！！");
                }
                else
                {
                    MessageDxUtil.ShowTips("插入成功，共" + count.ToString() + "条。");
                }
            }
        }

        private void btn_PrintData_Click(object sender, EventArgs e)
        {
            IList<PM_ImportBill> list = new List<PM_ImportBill>();
            PM_ImportBill bill = gView_ImportBill.GetFocusedRow() as PM_ImportBill;
            if (bill == null)
                return;
            bill.I_PrintNum += 1;
            var rs = MainService.ExecuteDB_UpdatePM_ImportBill(bill);

            Wgstion.wgistion1 = bill.C_PondNo;

            list.Add(bill);
            XtraReport6 xt = new XtraReport6();
            xt.DataSource = list;
            xt.PageHeight = 500;
            xt.PageWidth = 827;
            xt.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ReportPrintTool tool = new ReportPrintTool(xt);
            tool.ShowPreview();

            SetGridData(false);
        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            IList<PM_ImportBill> list = new List<PM_ImportBill>();
            PM_ImportBill bill = gView_ImportBill.GetFocusedRow() as PM_ImportBill;
            if (bill == null)
                return;
            bill.I_PrintNum += 1;
            var rs = MainService.ExecuteDB_UpdatePM_ImportBill(bill);

            Wgstion.wgistion1 = bill.C_PondNo;

            list.Add(bill);
            XtraReport6_2 xt = new XtraReport6_2();
            xt.DataSource = list;
            xt.PageHeight = 500;
            xt.PageWidth = 827;
            xt.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ReportPrintTool tool = new ReportPrintTool(xt);
            tool.ShowPreview();

            SetGridData(false);
        }
    }
}
