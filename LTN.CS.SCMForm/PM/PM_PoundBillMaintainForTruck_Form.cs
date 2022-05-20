using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.SCMEntities.PT;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PoundBillMaintainForTruck_Form : CoreForm
    {
        public IPM_Bill_TruckService MainService { get; set; }
        public ISM_Car_InfoService CarService { get; set; }
        public ISM_Department_LevelTwo_InfoService LevelTwoService { get; set; }
        public ISM_Department_LevelOne_InfoService LevelOneService { get; set; }
        public ISM_Materiel_LevelService MaterielService { get; set; }
        public ISM_PoundSite_InfoService PoundService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }


        #region 下拉框数据源
        /// <summary>
        /// 品名
        /// </summary>
        private List<SM_Materiel_Level> Materiels
        {
            get
            {
                if (materiels == null)
                {
                    materiels = MaterielService.ExecuteDB_QueryAll().ToList();
                }
                return materiels;
            }
            set
            {
                materiels = value;
            }
        }
        private List<SM_Materiel_Level> materiels = null;

        /// <summary>
        /// 单位
        /// </summary>
        public List<string> Depts
        {
            get
            {
                if (depts == null)
                {
                    depts = new List<string>() { "" };
                    var _depts = LevelOneService.ExecuteDB_QueryAll();
                    if (_depts != null)
                    {
                        _depts.ToList().ForEach(r => { depts.Add(r.DeptName); });
                    }
                }
                return depts;
            }
            set
            {
                depts = value;
            }
        }
        public List<string> depts = null;

        /// <summary>
        /// 仓库
        /// </summary>
        public List<string> Stores
        {
            get
            {
                if (stores == null)
                {
                    stores = new List<string>() { "" };
                    var _stores = LevelTwoService.ExecuteDB_QueryAll();
                    if (_stores != null)
                    {
                        _stores.ToList().ForEach(r => { stores.Add(r.TwoDeptName); });
                    }
                }
                return stores;
            }
            set
            {
                stores = value;
            }
        }
        public List<string> stores = null;
        /// <summary>
        /// 车号
        /// </summary>
        public List<string> CarsNums
        {
            get
            {
                if (carsnums == null)
                {
                    carsnums = new List<string>() { "" };
                    var _carsnums = CarService.ExecuteDB_QueryAll();
                    if (_carsnums != null)
                    {
                        _carsnums.ToList().ForEach(r => { carsnums.Add(r.CarName); });
                    }
                }
                return carsnums;
            }
            set
            {
                carsnums = value;
            }
        }

        public List<string> carsnums = null;

        /// <summary>
        ///   品名
        /// </summary>

        public List<string> Products
        {
            get
            {
                if (products == null)
                {
                    products = new List<string>() { "" };
                    var _products = MaterielService.ExecuteDB_QueryAll();
                    if (_products != null)
                    {
                        _products.ToList().ForEach(r => products.Add(r.MaterielName));
                    }
                }
                return products;
            }
            set
            {
                products = value;
            }
        }
        public List<string> products = null;


        private List<SM_PoundSite_Info> Pounds
        {
            get
            {
                if (pounds == null)
                {

                    var result = PoundService.ExecuteDB_QueryAll();
                    if (result != null)
                    {
                        pounds = result.ToList().FindAll(r=>r.PoundType.IntValue==1);
                    }
                    else
                    {
                        pounds = new List<SM_PoundSite_Info>();
                    }
                }
                return pounds;
            }
            set
            {
                pounds = value;
            }
        }
        private List<SM_PoundSite_Info> pounds = null;
        #endregion


        public PM_PoundBillMaintainForTruck_Form()
        {
            InitializeComponent();       
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_TruckPoundBill_Form frm = new PM_TruckPoundBill_Form();
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.ShowDialog();
            frm.Dispose();
            Query();
        }

        private void btn_HidePanel_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            Query();
        }

        private void PM_PoundBillMaintainForTruck_Form_Shown(object sender, EventArgs e)
        {
            InitView(gView_TruckPoundBill);
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void gView_TruckPoundBill_DoubleClick(object sender, EventArgs e)
        {
            btn_Update_Click(null, null);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var item = gView_TruckPoundBill.GetFocusedRow();
            if (item == null)
                return;
            PM_Bill_Truck itemTruck = MainService.ExecuteDB_QueryBillTruckByWgistonNo((item as PM_Bill_Truck).C_WGTLISTNO);
            if (itemTruck == null)
                return;
            PM_TruckPoundBill_Form frm = new PM_TruckPoundBill_Form();
            frm.TruckBill = itemTruck;
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.ShowDialog();
            frm.Dispose();
            Query();
        }

        private void btn_BatchUpdate_Click(object sender, EventArgs e)
        {
            int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
            if (rowHandles.Length == 0)
            {
                return;
            }
            List<string> TruckBillWgtNos = new List<string>();
            for (int i = 0; i < rowHandles.Count(); i++)
            {
                TruckBillWgtNos.Add(gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString());
            }

            PM_TruckPoundBills_Form frm = new PM_TruckPoundBills_Form();
            frm.MainService = this.MainService;
            frm.TruckBillWgtNos = TruckBillWgtNos;
            frm.Materiels = Materiels;
            frm.ShowDialog();
            Query();
        }

        private void Query(bool isFirst=false)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());
                ht.Add("WgtNo", txt_WgtNo.Text.Trim());
                ht.Add("CARNAME", textEdit1.Text.Trim());
                ht.Add("ContractNo", textEdit3.Text.Trim());
                if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
                {
                    ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                    ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));

                }
                var  result=MainService.ExecuteDB_QueryPM_Bill_TruckByHashtable(ht);
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

        private void gView_TruckPoundBill_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "C_BILLCREATETIME" || e.Column.FieldName == "C_TAREWGTTIME" || e.Column.FieldName == "C_GROSSWGTTIME"|| e.Column.FieldName =="C_UPDATETIME" ||e.Column.FieldName== "C_CREATETIME")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }

            if (e.Column.FieldName == "I_RETURNFLAG")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "退货"; break;
                        default:
                            e.DisplayText = "正常"; break;
                    }
                }
            }

            if (e.Column.FieldName == "I_REPEATFLAG")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "正常"; break;
                        default:
                            e.DisplayText = "复磅"; break;
                    }
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gCtrl_TruckPoundBill.DataSource == null)
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
                gView_TruckPoundBill.ExportToXls(fileDialog.FileName, options);
            }
        }
        /// <summary>
        /// 作废按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Invalid_Click(object sender, EventArgs e)
        {

            string billNumber = Convert.ToString(gView_TruckPoundBill.GetRowCellValue(gView_TruckPoundBill.FocusedRowHandle, "C_WGTLISTNO"));
            string str = string.Format("是否作废磅单号：{0}", billNumber);
            var item = gView_TruckPoundBill.GetFocusedRow() as PM_Bill_Truck;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips(str) == DialogResult.Yes)
            {
                item.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                item.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                var result = MainService.ExecuteDB_InvalidPM_Bill_Truck(item);
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
        
        /// <summary>
        /// 批量作废按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BatchInvalid_Click(object sender, EventArgs e)
        {
            int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
            if (rowHandles.Length==0)
            {
                return;
            }
            string BillWgtListNos = string.Empty;
            for (int i = 0; i < rowHandles.Count(); i++)
            {
                BillWgtListNos += gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString() + "\n";
            }
            BillWgtListNos = string.Format("是否作废以下磅单号：\n{0}", BillWgtListNos);
            if (MessageDxUtil.ShowYesNoAndTips(BillWgtListNos) == DialogResult.Yes)
            {
                object result = null;
                for (int i = 0; i < rowHandles.Count(); i++)
                {
                    var item = gView_TruckPoundBill.GetRow(rowHandles[i]) as PM_Bill_Truck;
                    item.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                    item.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                    result = MainService.ExecuteDB_InvalidPM_Bill_Truck(item);
                }
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
        private void gView_TruckPoundBill_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string state = gView_TruckPoundBill.GetRowCellValue(e.RowHandle, "C_BILLSTATE").ToString();
            if (state == "已作废")
            {
                e.Appearance.BackColor = Color.Red;
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
            }
        }

        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void txt_WgtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void date_StartTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void date_EndTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void gView_TruckPoundBill_TopRowChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            int width = CalcIndicatorBestWidth(view);
            if ((view.IndicatorWidth - 4 < width || view.IndicatorWidth + 4 > width) && view.IndicatorWidth != width)
            {
                view.IndicatorWidth = width;
            }
        }
        int CalcIndicatorBestWidth(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            Graphics graphics = new Control().CreateGraphics();
            SizeF sizeF = new SizeF();
            int count = view.TopRowIndex + ((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)view.GetViewInfo()).RowsInfo.Count;
            if (count == 0)
            {
                count = 30;
            }
            sizeF = graphics.MeasureString(count.ToString(), view.Appearance.Row.Font);
            return Convert.ToInt32(sizeF.Width) + 20;
        }

        private void gView_TruckPoundBill_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView_TruckPoundBill.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Lime;
            }
        }
        //2021-11-7 新增 合同号 字段
        /// <summary>
        /// 合同号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                panelControl1.Visible = true;
                Query();
            }
        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //1.获得gridView中选中的行   
                int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
                if (rowHandles.Length == 0)
                {
                    MessageDxUtil.ShowTips("未选择需要同步委托的磅单");
                    return;
                }
                if (MessageDxUtil.ShowYesNoAndTips("确认同步选中磅单的委托？") == DialogResult.Yes)
                {
                    List<string> truckPondBillWgtlistNos = new List<string>();
                    List<string> requestPlanLists = new List<string>();
                    for (int i = 0; i < rowHandles.Count(); i++)
                    {
                        //2.获得选中行的磅单号、委托号                       
                        string wgtlistno = gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString();
                        string requestPlanno = gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_PLANNO").ToString();
                        //3.根据磅单号，更新磅单委托内容  
                        PT_TruckMeasurePlan planInfo = MainService.ExecuteDB_QueryTruckMeasurePlanByPlanNo(requestPlanno);    //更新之后的委托          
                        Hashtable ht = new Hashtable();
                        ht.Add("WgtNo", wgtlistno);
                        PM_Bill_Truck bill = MainService.ExecuteDB_QueryPM_Bill_TruckByPond2(ht).FirstOrDefault();
                        //4.更新磅单中的委托相关的字段
                        if (bill.C_PLANNO == planInfo.C_PLANNO)
                        {
                            bill.C_CARNO = planInfo.C_CARNO;
                            bill.C_CARNAME = planInfo.C_CARNAME;
                            bill.C_CARSERIALNUMBER = planInfo.C_CARSERIALNUMBER;
                            bill.C_CONTRACTNO = planInfo.C_CONTRACTNO;
                            bill.C_MATERIALNO = planInfo.C_MATERIALNO;
                            bill.C_MATERIALNAME = planInfo.C_MATERIALNAME;
                            bill.C_FROMDEPTNO = planInfo.C_FROMDEPTNO;
                            bill.C_FROMDEPTNAME = planInfo.C_FROMDEPTNAME;
                            bill.C_FROMSTORENO = planInfo.C_FROMSTORENO;
                            bill.C_FROMSTORENAME = planInfo.C_FROMSTORENAME;
                            bill.C_TODEPTNO = planInfo.C_TODEPTNO;
                            bill.C_TODEPTNAME = planInfo.C_TODEPTNAME;
                            bill.C_TOSTORENO = planInfo.C_TOSTORENO;
                            bill.C_TOSTORENAME = planInfo.C_TOSTORENAME;
                            bill.I_BUSINESSTYPE = planInfo.I_BUSINESSTYPE;
                            bill.I_PLANTYPE = planInfo.I_PLANTYPE;
                            bill.I_ISAUTO = planInfo.I_ISAUTO;
                            bill.I_WEIGHTTYPE = planInfo.I_WEIGHTTYPE;
                            bill.I_TARETIMELIMIT = planInfo.I_TARETIMELIMIT;
                            bill.I_ONEMORESTOCK = planInfo.I_ONEMORESTOCK;
                            bill.I_ISCHILDIDENFY = planInfo.I_ISCHILDIDENFY;
                            bill.I_ISCREATEMOTHERPOND = planInfo.I_ISCREATEMOTHERPOND;
                            bill.C_CONNECTPLANNO = planInfo.C_CONNECTPLANNO;
                            bill.I_ONETWOPLAN = planInfo.I_ONETWOPLAN;
                            bill.C_MIDDLEDEPTNO = planInfo.C_MIDDLEDEPTNO;
                            bill.C_MIDDLEDEPTNAME = planInfo.C_MIDDLEDEPTNAME;
                            bill.C_MIDDLESTORENO = planInfo.C_MIDDLESTORENO;
                            bill.C_MIDDLESTORENAME = planInfo.C_MIDDLESTORENAME;
                            bill.I_RETALLYKG = planInfo.I_RETALLYKG;
                            bill.I_COMPUTERTYPE = planInfo.I_COMPUTERTYPE;
                            bill.I_DOWNVALUE = planInfo.I_DOWNVALUE;
                            bill.I_UPVALUE = planInfo.I_UPVALUE;
                            bill.C_PERCENTAGE = planInfo.C_PERCENTAGE;
                            bill.C_SHIPPINGNOTE = planInfo.C_SHIPPINGNOTE;
                            bill.I_REPEATPOUND = planInfo.I_REPEATPOUND;
                            bill.C_PLANLIMITTIME = planInfo.C_PLANLIMITTIME;
                            bill.C_PONDLIMIT = planInfo.C_PONDLIMIT;
                            bill.C_CREATETIME = planInfo.C_CREATETIME;
                            bill.C_CREATEUSERNAME = planInfo.C_CREATEUSERNAME;
                            bill.C_REMARK = planInfo.C_REMARK;
                            bill.C_RESERVE1 = planInfo.C_RESERVE1;
                            bill.C_RESERVE2 = planInfo.C_RESERVE2;
                            bill.C_RESERVE3 = planInfo.C_RESERVE3;
                            bill.I_RESERVE1 = planInfo.I_RESERVE1;
                            bill.I_RESERVE2 = planInfo.I_RESERVE2;
                            bill.I_RESERVE3 = planInfo.I_RESERVE3;
                            bill.C_PLANSTATE = planInfo.C_PLANSTATE;
                            bill.C_CONTAINERNO = planInfo.C_CONTAINERNO;
                            bill.C_RESERVE4 = planInfo.C_RESERVE4;
                            bill.C_RESERVE5 = planInfo.C_RESERVE5;
                            bill.C_RESERVE6 = planInfo.C_RESERVE6;
                            bill.C_RESERVE7 = planInfo.C_RESERVE7;

                            //更新磅单中的字段信息
                            if (bill.C_UPLOADSTATUE == "Y")
                            {
                                bill.C_PLANSTATUS = "U";
                            }
                            bill.C_UPLOADSTATUE = "N";
                            bill.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                            bill.C_UPDATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");

                            //更新磅单信息
                            var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck(bill);
                            if (rs == null)
                            {
                                MessageDxUtil.ShowError("同步委托信息失败");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
            //4.刷新gridView内容
            Query();          
        }
        //临时新增功能 批量删除磅单备注
        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //1.获得gridView中选中的行   
                int[] rowHandles = gView_TruckPoundBill.GetSelectedRows();
                if (rowHandles.Length == 0)
                {
                    MessageDxUtil.ShowTips("请选择磅单");
                    return;
                }
                if (MessageDxUtil.ShowYesNoAndTips("确认删除选中磅单的磅单备注信息？") == DialogResult.Yes)
                {
                    List<string> truckPondBillWgtlistNos = new List<string>();
                    
                    for (int i = 0; i < rowHandles.Count(); i++)
                    {
                        //2.获得选中行的磅单号、委托号                       
                        string wgtlistno = gView_TruckPoundBill.GetRowCellValue(rowHandles[i], "C_WGTLISTNO").ToString();                                            
                        Hashtable ht = new Hashtable();
                        ht.Add("WgtNo", wgtlistno);
                        PM_Bill_Truck bill = MainService.ExecuteDB_QueryPM_Bill_TruckByPond2(ht).FirstOrDefault();
                        //更新磅单中的字段信息
                        if (bill.C_UPLOADSTATUE == "Y")
                        {
                            bill.C_PLANSTATUS = "U";
                        }
                        bill.C_UPLOADSTATUE = "N";
                        bill.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                        bill.C_UPDATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                        bill.C_PONDREMARK = "";

                        //更新磅单信息
                        var rs = MainService.ExecuteDB_UpdatePM_Bill_Truck(bill);
                        if (rs == null)
                        {
                            MessageDxUtil.ShowError("操作失败");
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
            //4.刷新gridView内容
            Query();
        }
    }
}
