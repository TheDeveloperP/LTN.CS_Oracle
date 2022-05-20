using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_TruckMeasurePlan_Form : CoreForm
    {
        public IPT_TruckMeasurePlanService MainService { get; set; }
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


        private List<SM_Materiel_Level> Materiels
        {
            get
            {
                if (materiels == null)
                {
                    materiels=MaterielService.ExecuteDB_QueryAll().ToList();
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


        private List<string> Pounds
        {
            get
            {
                if (pounds == null)
                {
                    pounds = new List<string>();
                    var _pounds = PoundService.ExecuteDB_QueryAll();
                    if (_pounds != null)
                    {
                        _pounds.ToList().ForEach(r => { pounds.Add(r.PoundSiteName); });
                    }

                }
                return pounds;
            }
            set
            {
                pounds = value;
            }
        }
        private List<string> pounds = null;
        #endregion




        public PT_TruckMeasurePlan_Form()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PT_TruckMeasurePlanOperate_Form frm = new PT_TruckMeasurePlanOperate_Form();
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.isFuzhi = false;
            frm.ShowDialog();

            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();


        }


        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            var item = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;
            if (item == null)
                return;

            PT_TruckMeasurePlanOperate_Form frm = new PT_TruckMeasurePlanOperate_Form();
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.TruckMeasurePlan2 = item;
            frm.isFuzhi = true;
            frm.ShowDialog();

            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var item = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;
            if (item == null)
                return;
            PT_TruckMeasurePlanOperate_Form frm = new PT_TruckMeasurePlanOperate_Form();
            frm.TruckMeasurePlan = item;
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.isFuzhi = false;
            frm.ShowDialog();
            Query();
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            var item = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
            {
                item.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                item.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                var result=MainService.ExecuteDB_InvalidTruckMeasurePlanByIntId(item);
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

        private void PT_TruckMeasurePlan_Form_Shown(object sender, EventArgs e)
        {
            InitView(gView_TruckMeasurePlan);
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void Query(bool isFirst=false)
        {

            try
            {

                if (string.IsNullOrEmpty(date_StartTime.Text) || string.IsNullOrEmpty(date_EndTime.Text))
                {
                    MessageDxUtil.ShowTips("时间不能为空");
                }

                date_StartTime.Refresh();
                DateTime StartTime = Convert.ToDateTime(date_StartTime.Text);
                DateTime EndTime = Convert.ToDateTime(date_EndTime.Text);
                Hashtable ht = new Hashtable();
                ht.Add("StartTime", CommonHelper.TimeToStr14(StartTime));
                ht.Add("EndTime", CommonHelper.TimeToStr14(EndTime));
                ht.Add("CARNAME", txt_TruckNo.Text);
                ht.Add("PLANNO", textEdit1.Text);
                int rowHandle = gView_TruckMeasurePlan.FocusedRowHandle;
                var rss = MainService.ExecuteDB_QueryTruckMeasurePlanByHashTable(ht);
                gCtrl_TruckMeasurePlan.DataSource = rss;
                gView_TruckMeasurePlan.FocusedRowHandle = rowHandle;
                int selectLeftIdOld = selectMainId;
                queryMain = false;
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
            int rowcount = gView_TruckMeasurePlan.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PT_TruckMeasurePlan group = gView_TruckMeasurePlan.GetRow(i) as PT_TruckMeasurePlan;
                    if (group.I_INTID == selectMainId)
                    {
                        gView_TruckMeasurePlan.FocusedRowHandle = i;
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
                    gView_TruckMeasurePlan.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gView_TruckMeasurePlan.FocusedRowHandle = selectMainRowNum;
                }
            }
        }

        private void btn_HidePanel_Click(object sender, EventArgs e)
        {
            Panel_Query.Visible = false;
        }


        private void btn_Sel_Click(object sender, EventArgs e)
        {
            Panel_Query.Visible = true;
            txt_TruckNo.Focus();
            Query();
        }


        private void btn_Export2_Click(object sender, EventArgs e)
        {
            if (gCtrl_TruckMeasurePlan.DataSource == null)
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
                gView_TruckMeasurePlan.ExportToXls(fileDialog.FileName, options);
            }

        }

        private void gView_TruckMeasurePlan_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string state = gView_TruckMeasurePlan.GetRowCellValue(e.RowHandle, "C_PLANSTATE").ToString();
            if (state == "已作废")
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void gView_TruckMeasurePlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName== "C_CREATETIME" || e.Column.FieldName == "C_PLANLIMITTIME"||e.Column.FieldName== "C_UPDATETIME")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }

        private void gView_TruckMeasurePlan_DoubleClick(object sender, EventArgs e)
        {
            var item = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;
            if (item == null)
                return;
            PT_TruckMeasurePlanOperate_Form frm = new PT_TruckMeasurePlanOperate_Form();
            frm.TruckMeasurePlan = item;
            frm.MainService = MainService;
            frm.Depts = Depts;
            frm.Stores = Stores;
            frm.CarsNums = CarsNums;
            frm.Products = Products;
            frm.Pounds = Pounds;
            frm.Materiels = Materiels;
            frm.ShowDialog();
            Query();
        }

        private void gView_TruckMeasurePlan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;
                if (entity != null)
                {
                    selectMainId = entity.I_INTID;
                    selectMainRowNum = gView_TruckMeasurePlan.FocusedRowHandle;
                }
            }
        }


        private void txt_TruckNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Panel_Query.Visible = true;
                txt_TruckNo.Focus();
                Query();
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Panel_Query.Visible = true;
                txt_TruckNo.Focus();
                Query();
            }
        }

        private void date_StartTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Panel_Query.Visible = true;
                txt_TruckNo.Focus();
                Query();
            }
        }

        private void date_EndTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Panel_Query.Visible = true;
                txt_TruckNo.Focus();
                Query();
            }
        }

        private void btn_BatchUpdate_Click(object sender, EventArgs e)
        {
            IList<PT_TruckMeasurePlan> list = null;
            int[] rows = gView_TruckMeasurePlan.GetSelectedRows();
            if (rows != null && rows.Count() > 0)
            {
                list = new List<PT_TruckMeasurePlan>();
                foreach (int row in rows)
                {
                    PT_TruckMeasurePlan plan = gView_TruckMeasurePlan.GetRow(row) as PT_TruckMeasurePlan;
                    list.Add(plan);//获取批量列表
                }
            }
            //IList<PT_TruckMeasurePlan> list = getBatchList(false);
            if (list == null || list.Count <= 0)
            {
                MessageDxUtil.ShowWarning("请先选择要修改的数据！");
                return;
            }
            var rss = MessageDxUtil.ShowYesNoAndTips("确认要批量修改数据吗?");
            if (rss == DialogResult.Yes)
            {
                PT_TruckMeasureUpdate_Form frm = new PT_TruckMeasureUpdate_Form();
                frm.list = list;
                frm.MainService = MainService;
                frm.ShowDialog();
                Query();
            }
        }

        private void btn_BatchInvalid_Click(object sender, EventArgs e)
        {
            int[] rowHandles = gView_TruckMeasurePlan.GetSelectedRows();
            if (rowHandles.Length == 0)
            {
                return;
            }
            string PlanNos = string.Empty;
            for (int i = 0; i < rowHandles.Count(); i++)
            {
                PlanNos += gView_TruckMeasurePlan.GetRowCellValue(rowHandles[i], "C_PLANNO").ToString() + "\n";
            }
            PlanNos= string.Format("是否作废以下委托单号：\n{0}", PlanNos);
            if (MessageDxUtil.ShowYesNoAndTips(PlanNos) == DialogResult.Yes)
            {
                object result = null;
                for (int i = 0; i < rowHandles.Count(); i++)
                {
                    var item = gView_TruckMeasurePlan.GetRow(rowHandles[i]) as PT_TruckMeasurePlan;
                    item.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                    item.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                    result = MainService.ExecuteDB_InvalidTruckMeasurePlanByIntId(item);
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

        private void gView_TruckMeasurePlan_TopRowChanged(object sender, EventArgs e)
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

        private void gView_TruckMeasurePlan_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gView_TruckMeasurePlan.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Lime;
            }
        }
    }
}
