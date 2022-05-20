using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Pond_Bill_Supplies_Form : CoreForm
    {
        #region 实例变量
        private PM_Pond_Bill_Supplies SelectMainEntity { get; set; }
        public IPM_Pond_Bill_SuppliesService MainService { get; set; }
        public IPM_Bill_SuppliesService billService { get; set; }
        public ISM_GczTare_InfoService gczService { get; set; }  
        private bool queryMain { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }

        public ISM_Materiel_LevelService MaterielService { get; set; }



        #endregion
        /// <summary>
        /// 品名
        /// </summary>

        List<SM_Materiel_Level> materiels = null;
        private List<SM_Materiel_Level> Materiels
        {
            get
            {
                if (materiels == null)
                {
                    materiels = MaterielService.ExecuteDB_QueryAll().ToList<SM_Materiel_Level>();
                }
                return materiels;
            }
            set
            {
                materiels = value;
            }
        }
        
        #region 构造函数
        public PM_Pond_Bill_Supplies_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void setDataSource()
        {
            dte_StartTime.Text = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd 00:00:00");
            dte_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        private Hashtable setCondition()
        {
            Hashtable ht = new Hashtable();
            DateTime StartTime = Convert.ToDateTime(dte_StartTime.Text);
            DateTime EndTime = Convert.ToDateTime(dte_EndTime.Text);
            if (!string.IsNullOrEmpty(dte_StartTime.Text))
            {
                ht.Add("StartTime", StartTime.ToString("yyyyMMddHHmmss"));
            }
            if (!string.IsNullOrEmpty(dte_EndTime.Text))
            {
                ht.Add("EndTime", EndTime.ToString("yyyyMMddHHmmss"));
            }
            if (!string.IsNullOrEmpty(txt_WgtlistNo.Text))
            {
                ht.Add("WgtlistNo", txt_WgtlistNo.Text);
            }
            if (!string.IsNullOrEmpty(txt_PlanNo.Text))
            {
                ht.Add("PlanNo", txt_PlanNo.Text);
            }
            if (!string.IsNullOrEmpty(txt_WagNo.Text))
            {
                ht.Add("WagNo", txt_WagNo.Text);
            }
            //新增
            if (checkEdit1.Checked)
            {
                ht.Add("isSelected", "Y");
            }
            else
            {
                ht.Add("isSelected", "N");
            }
            return ht;
        }
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QuerySuppliesPondByHashTable(setCondition());
                    if (rss != null)
                    {
                        List<PM_Pond_Bill_Supplies> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            //System.Globalization.CultureInfo Culinfo = CultureInfo.GetCultureInfo("zh-cn");
                            if (r.UpdateTime != null)
                            {
                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.UpdateTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.UpdateTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.CreateTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.CreateTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.CreateTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.PlanCreateTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.PlanCreateTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.PlanCreateTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.GrossWgtTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.GrossWgtTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.GrossWgtTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.TareWgtTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.TareWgtTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.TareWgtTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.PlanLimitTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.PlanLimitTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.PlanLimitTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                        });
                    }
                    gcl_main.DataSource = rss;

                    //gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
                    }
                    queryMain = true;
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 主档焦点行转换
        /// </summary>
        private void SetMainFocusRow()
        {

            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_Pond_Bill_Supplies Supplies = gvw_main.GetRow(i) as PM_Pond_Bill_Supplies;
                    if (Supplies.IntId == selectMainId)
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

        /// <summary>
        /// 自定义作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainDelete()
        {
            try
            {
                if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
                {
                    SelectMainEntity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Supplies;
                    SelectMainEntity.DataFlag = new EntityInt(0);
                    SelectMainEntity.PlanStatus = "D";
                    SelectMainEntity.UpLoadStatus = "N";
                    SelectMainEntity.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    SelectMainEntity.UpdateUser = SessionHelper.LogUserNickName;
                    var rs = MainService.ExecuteDB_InvalidSuppliesPondByIntId(SelectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        #endregion

        #region 控件方法
        private void PM_Pond_Bill_Supplies_Form_Load(object sender, EventArgs e)
        {
            InitView(gvw_main);
            setDataSource();
            SetMainGridData(true);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Supplies;
                if (entity != null)
                {
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                SelectMainEntity = entity;
            }
        }

        private void gvw_main_DoubleClick(object sender, EventArgs e)
        {
            btn_update_Click(null, null);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_PondSupplies_Form frm = new PM_PondSupplies_Form();
            frm.MainService = MainService;
            frm.billService = billService;
            frm.gczService = gczService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                //重新设置PM_Pond_Bill_Supplies_Form的数据源
                SetMainGridData(false);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SelectMainEntity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Supplies;
            if (SelectMainEntity == null)
                return;
            PM_PondSupplies_Form frm = new PM_PondSupplies_Form();
            frm.Text = "磅单修改";
            frm.SelectMainEntity = SelectMainEntity;
            frm.MainService = MainService;
            frm.billService = billService;
            frm.gczService = gczService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            CustomMainDelete();
        }
        #endregion
        /// <summary>
        /// 导出  可否在excel中加入计量章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
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
                gvw_main.ExportToXlsx(fileDialog.FileName, options);
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
                SetMainGridData(false);
            }
        }
        /// <summary>
        /// 委托号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false);
            }
        }
        /// <summary>
        /// 车皮号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_WagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false);
            }
        }
        //新增 潘 11-12
        /// <summary>
        /// 批量作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_multiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowhandles = gvw_main.GetSelectedRows();//获得选中的行号集合
                if (rowhandles.Length == 0)
                {
                    return;
                }
                string billWgtListNos = string.Empty;
                for (int i = 0; i < rowhandles.Count(); i++)
                {
                    billWgtListNos += gvw_main.GetRowCellValue(rowhandles[i], "WgtlistNo").ToString() + "\n";
                }
                billWgtListNos = string.Format("是否作废以下磅单:\n{0}", billWgtListNos);
                if (MessageDxUtil.ShowYesNoAndTips(billWgtListNos) == DialogResult.Yes)
                {
                    object result = null;
                    for (int i = 0; i < rowhandles.Count(); i++)
                    {
                        var item = gvw_main.GetRow(rowhandles[i]) as PM_Pond_Bill_Supplies;
                        item.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        item.UpdateUser = SessionHelper.LogUserNickName;
                        item.DataFlag = new EntityInt(0);
                        item.PlanStatus = "D";
                        item.UpLoadStatus = "N";
                        result = MainService.ExecuteDB_InvalidSuppliesPondByIntId(item);                        
                    }
                    if (result != null)
                    {
                        MessageDxUtil.ShowTips("批量作废成功");
                        //刷新内容
                        SetMainGridData(false);
                    }
                    else
                    {
                        MessageDxUtil.ShowError("作废异常");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }           
        }
       
        /// <summary>
        /// 批量更新磅单委托内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //1.获得gridView中选中的行   
                int[] rowHandles = gvw_main.GetSelectedRows();
                if (rowHandles.Length == 0)
                {
                    return;
                }
                if (MessageDxUtil.ShowYesNoAndTips("确认同步选中磅单的委托？") == DialogResult.Yes)
                {
                    List<string> suppliesBillWgtNos = new List<string>();
                    List<string> requestPlanLists = new List<string>();
                    for (int i = 0; i < rowHandles.Count(); i++)
                    {
                        //2.获得选中行的磅单号
                        //suppliesBillWgtNos.Add(gvw_main.GetRowCellValue(rowHandles[i], "gridColumn28").ToString());
                        //requestPlanLists.Add(gvw_main.GetRowCellValue(rowHandles[i], "gridColumn1").ToString());//委托号
                        string wgtlistno = gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString();
                        string requestPlanno = gvw_main.GetRowCellValue(rowHandles[i], "PlanNo").ToString();

                        //3.根据磅单号，更新磅单委托内容                
                        //billService.ExecuteDB_QuerySuppliesByPlan(requestPlanno).FirstOrDefault();
                        PM_Bill_Supplies suppliesRequest = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == requestPlanno).FirstOrDefault();
                        //PM_Pond_Bill_Supplies bill = MainService.ExecuteDB_QueryByWgistonNo(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());
                        PM_Pond_Bill_Supplies bill = MainService.ExecuteDB_QueryByWgistonNo(wgtlistno);

                        //4.更新磅单中的委托相关的字段
                        if (bill.PlanNo == suppliesRequest.PlanNo)
                        {
                            bill.WagNo = suppliesRequest.WagNo;
                            bill.MaterialNo = suppliesRequest.MaterialNo;
                            bill.MaterialName = suppliesRequest.MaterialName;
                            bill.FromDeptNo = suppliesRequest.FromDeptNo;
                            bill.FromDeptName = suppliesRequest.FromDeptName;
                            bill.FromStoreNo = suppliesRequest.FromStoreNo;
                            bill.FromStoreName = suppliesRequest.FromStoreName;
                            bill.ToDeptNo = suppliesRequest.ToDeptNo;
                            bill.ToDeptName = suppliesRequest.ToDeptName;
                            bill.ToStoreNo = suppliesRequest.ToStoreNo;
                            bill.ToStoreName = suppliesRequest.ToStoreName;
                            bill.ShipNo = suppliesRequest.ShipNo;
                            bill.FromStation = suppliesRequest.FromStation;
                            bill.SerialNo = suppliesRequest.SerialNo;
                            bill.DeliveryNo = suppliesRequest.DeliveryNo;
                            bill.ContractNo = suppliesRequest.ContractNo;
                            bill.ProjectNo = suppliesRequest.ProjectNo;
                            bill.WayBillNo = suppliesRequest.WayBillNo;
                            bill.MarshallingNo = suppliesRequest.MarshallingNo;
                            bill.BusinessType = suppliesRequest.BusinessType;
                            bill.WeightType = suppliesRequest.WeightType;
                            bill.TareType = suppliesRequest.TareType;
                            bill.MoveStillType = suppliesRequest.MoveStillType;
                            bill.PlanLimitTime = suppliesRequest.PlanLimitTime;
                            bill.PondLimit = suppliesRequest.PondLimit;
                            bill.Remark = suppliesRequest.Remark;
                            bill.PlanCreateUser = suppliesRequest.CreateUser;
                            bill.PlanCreateTime = suppliesRequest.CreateTime;
                            bill.CReserve1 = suppliesRequest.CReserve1;
                            bill.CReserve2 = suppliesRequest.CReserve2;
                            bill.CReserve3 = suppliesRequest.CReserve3;
                            bill.IReserve1 = suppliesRequest.IReserve1;
                            bill.IReserve2 = suppliesRequest.IReserve2;
                            bill.IReserve3 = suppliesRequest.IReserve3;
                            //更新磅单中的字段信息
                            if (bill.UpLoadStatus == "Y")
                            {
                                bill.PlanStatus = "U";
                            }
                            bill.UpLoadStatus = "N";
                            bill.UpdateUser = SessionHelper.LogUserNickName;
                            bill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            //需明确是否根据净重时间来更新
                            //bill.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            //更新磅单信息
                            var rs = MainService.ExecuteDB_UpdateSuppliesInfo(bill);
                            if (rs is CustomDBError)
                            {
                                MessageDxUtil.ShowError("同步委托信息失败：" + ((CustomDBError)rs).ErrorMsg);
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
            SetMainGridData(false);             
        }


        /// <summary>
        /// 物资磅单批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_multiUpdate_Click(object sender, EventArgs e)
        {
            //1.获取选中的行的磅单号
            int[] rowHandles = gvw_main.GetSelectedRows();
            if (rowHandles.Length == 0)
            {
                return;
            }
            string billWgtNos = string.Empty;
            List<string> wgtListNos = new List<string>();
            for (int i = 0; i < rowHandles.Count(); i++)
            {
                billWgtNos += (gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString()) + "\n";
                wgtListNos.Add(gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString());
            }
            billWgtNos = string.Format("是否批量修改以下磅单:\n{0}", billWgtNos);

            if (MessageDxUtil.ShowYesNoAndTips("是否确认修改选中磅单") == DialogResult.Yes)
            {
                //弹出窗口对字段进行修改
                PM_BillMultiUpdate_Supplies frm = new PM_BillMultiUpdate_Supplies();
                frm.MainService = MainService;
                frm.SuppliesBillWgtNos = wgtListNos;                                
                frm.Materiels = Materiels;
                frm.ShowDialog();                
                SetMainGridData(false);
            }
            else
            {
                return;
            }
        }
        //临时新增
        private void gToolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //1.获得gridView中选中的行   
                int[] rowHandles = gvw_main.GetSelectedRows();
                if (rowHandles.Length == 0)
                {
                    return;
                }
                if (MessageDxUtil.ShowYesNoAndTips("确认删除选中磅单的磅单备注？") == DialogResult.Yes)
                {
                    List<string> suppliesBillWgtNos = new List<string>();                    
                    for (int i = 0; i < rowHandles.Count(); i++)
                    {
                        string wgtlistno = gvw_main.GetRowCellValue(rowHandles[i], "WgtlistNo").ToString();                                                
                        PM_Pond_Bill_Supplies bill = MainService.ExecuteDB_QueryByWgistonNo(wgtlistno);                                               
                        //更新磅单中的字段信息
                        if (bill.UpLoadStatus == "Y")
                        {
                            bill.PlanStatus = "U";
                        }
                        bill.UpLoadStatus = "N";
                        bill.UpdateUser = SessionHelper.LogUserNickName;
                        bill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        bill.PondRemark = "";                       
                        var rs = MainService.ExecuteDB_UpdateSuppliesInfo(bill);
                        if (rs is CustomDBError)
                        {
                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
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
            SetMainGridData(false);             
        }
    }
}
