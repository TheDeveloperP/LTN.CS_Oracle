using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
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

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Pond_Bill_Iron_Form : CoreForm
    {
        #region 实例变量
        private PM_Pond_Bill_Iron SelectMainEntity { get; set; }
        public IPM_Pond_Bill_IronService MainService { get; set; }
        public IPM_Bill_IronService billService { get; set; }
        //public ISM_Department_LevelTwo_InfoService departmentTwoService { get; set; }
        //public ISM_PoundSite_InfoService siteService { get; set; }
        private bool queryMain { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        #endregion

        #region 构造函数
        public PM_Pond_Bill_Iron_Form()
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
            if (!string.IsNullOrEmpty(txt_HeatNo.Text))
            {
                ht.Add("HeatNo", txt_HeatNo.Text);
            }
            if (!string.IsNullOrEmpty(txt_TankNo.Text))
            {
                ht.Add("TankNo", txt_TankNo.Text);
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
                    var rss = MainService.ExecuteDB_QueryIronPondByHashTable(setCondition());
                    if (rss != null)
                    {
                        List<PM_Pond_Bill_Iron> data = rss.ToList();
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
                    PM_Pond_Bill_Iron iron = gvw_main.GetRow(i) as PM_Pond_Bill_Iron;
                    if (iron.IntId == selectMainId)
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
                    SelectMainEntity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Iron;
                    SelectMainEntity.DataFlag = new EntityInt(0);
                    SelectMainEntity.PlanStatus = "D";
                    SelectMainEntity.UpLoadStatus = "N";
                    SelectMainEntity.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    SelectMainEntity.UpdateUser = SessionHelper.LogUserNickName;
                    var rs = MainService.ExecuteDB_InvalidIronPondByIntId(SelectMainEntity);
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

        private void PM_Pond_Bill_Iron_Form_Load(object sender, EventArgs e)
        {
            setDataSource();
            SetMainGridData(true);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_PondInfo_Form frm = new PM_PondInfo_Form();
            frm.MainService = MainService;
            frm.billService = billService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SelectMainEntity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Iron;
            if (SelectMainEntity == null)
                return;
            PM_PondInfo_Form frm = new PM_PondInfo_Form();
            frm.Text = "磅单修改";
            frm.SelectMainEntity = SelectMainEntity;
            frm.MainService = MainService;
            frm.billService = billService;
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

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gvw_main.GetFocusedRow() as PM_Pond_Bill_Iron;
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

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (gcl_main.DataSource == null)
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
                gvw_main.ExportToXls(fileDialog.FileName, options);
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
        /// 炉号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_HeatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false);
            }
        }
        /// <summary>
        /// 罐号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_TankNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false);
            }
        }

    }
}
