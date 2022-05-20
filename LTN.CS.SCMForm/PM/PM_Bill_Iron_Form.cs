using LTN.CS.Base;
using LTN.CS.Base.Common;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_Iron_Form : CoreForm
    {
        #region 实例变量
        private PM_Bill_Iron SelectMainEntity { get; set; }
        //public ISM_Department_LevelTwo_InfoService departmentTwoService { get; set; } 
        public IPM_Bill_IronService MainService { get; set; }
        private bool queryMain { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }

        #endregion

        #region 构造函数
        public PM_Bill_Iron_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void setDataSource()
        {
            lue_BillStatus.Properties.DataSource = BillStatusObj.GetBillStatusData();
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
            if (!string.IsNullOrEmpty(lue_BillStatus.Text))
            {
                ht.Add("BillStatus", lue_BillStatus.EditValue.ToString());
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
                    var rss = MainService.ExecuteDB_QueryIronPlanByHashTable(setCondition());
                    if (rss != null)
                    {
                        List<PM_Bill_Iron> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            System.Globalization.CultureInfo Culinfo = CultureInfo.GetCultureInfo("zh-cn");
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
                        });
                    }
                        gcl_main.DataSource = rss;

                    gvw_main.BestFitColumns();
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
                    PM_Bill_Iron iron = gvw_main.GetRow(i) as PM_Bill_Iron;
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
                    SelectMainEntity = gvw_main.GetFocusedRow() as PM_Bill_Iron;
                    SelectMainEntity.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.InvalidMeasure };
                    SelectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
                    var rs = MainService.ExecuteDB_InvalidIronPlanByIntId(SelectMainEntity);
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

        #region 控件事件
        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_IronPlan_Form frm = new PM_IronPlan_Form();
            frm.MainService = MainService;
            //frm.departmentTwoService = departmentTwoService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SelectMainEntity = gvw_main.GetFocusedRow() as PM_Bill_Iron;
            if (SelectMainEntity == null)
                return;
            PM_IronPlan_Form frm = new PM_IronPlan_Form();
            frm.Text = "铁水计划修改";
            frm.SelectMainEntity = SelectMainEntity;
            frm.MainService = MainService;
            //frm.departmentTwoService = departmentTwoService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void PM_Bill_Iron_Form_Load(object sender, EventArgs e)
        {
            setDataSource();
            SetMainGridData(true);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gvw_main.GetFocusedRow() as PM_Bill_Iron;
                if (entity != null)
                {
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                SelectMainEntity = entity;
            }
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            CustomMainDelete();
        }

        private void gvw_main_DoubleClick(object sender, EventArgs e)
        {
            btn_update_Click(null, null);
        }

        #endregion

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gvw_main.GetRow(e.RowHandle) as PM_Bill_Iron;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            //string BillStatus = gvw_main.GetRowCellValue(e.RowHandle, "BillStatus.BillStatusDesc").ToString();
            if (e.Column.FieldName== "BillStatus.BillStatusDesc" && item.BillStatus.BillStatusDesc == "作废")
            {
                e.Appearance.BackColor = Color.Orange;
            }
            if (e.Column.FieldName == "BillStatus.BillStatusDesc" && item.BillStatus.BillStatusDesc == "完成计量")
            {
                e.Appearance.BackColor = Color.Green;
            }
            if (item.UpdateUserName!=null)
            {
                if (e.Column.FieldName == "UpdateUserName" && reg.IsMatch(item.UpdateUserName) && item.BillStatus.BillStatusDesc == "作废")
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
           
        }
    }
}
