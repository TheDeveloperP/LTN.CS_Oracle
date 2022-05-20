using DevExpress.XtraPrinting;
using LTN.CS.Base;
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_TareWeightHistoryForm : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_TareWeightHistory selectMainEntity { get; set; }
        private bool queryMain { get; set; }
        public ISM_TareWeightHistoryService MainService { get; set; }
        public ISM_TareWeightService tareWeightService { get; set; }
        public SM_TareWeightHistoryForm()
        {
            InitializeComponent();
        }
        private void SM_TareWeightHistoryForm_Shown(object sender, EventArgs e)
        {
            //de_startTime.Text = DateTime.Now.AddDays(2).ToShortDateString() + " 00:00:00";
            de_startTime.Text = DateTime.Now.ToShortDateString() + " 00:00:00";
            de_endTime.Text = DateTime.Now.ToShortDateString() + " 23:59:59";
            SetMainGridData(false);
        }
        /// <summary>
        /// 设定主档Grid数据
        /// </summary>
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryByCarnameAndTime(getCondition());
                    if (rss != null)
                    {
                        List<SM_TareWeightHistory> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);
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
                    SetMainEditerData();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        public Hashtable getCondition()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(de_startTime.Text))
            {
                condition.Add("StartTime", CommonHelper.TimeToStr14(Convert.ToDateTime(de_startTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(de_endTime.Text))
            {
                condition.Add("EndTime", CommonHelper.TimeToStr14(Convert.ToDateTime(de_endTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(txt_CarNamequery.Text))
            {
                condition.Add("CarName", txt_CarNamequery.Text);
            }
            return condition;
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
                    SM_TareWeightHistory group = gvw_main.GetRow(i) as SM_TareWeightHistory;
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
        /// <summary>
        /// 显示数据编辑区数据
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(SM_TareWeightHistory entity)
        {
            txt_CarName.Text = entity.CarName;
            txt_tare.Text = entity.HistoryTare.ToString();
            txt_PoundNo.Text = entity.SiteNo;
            txt_PoundName.Text = entity.SiteName;
        }
        /// <summary>
        /// 清除数据编辑数据
        /// </summary>
        private void ClearMainEditer()
        {
            txt_CarName.Text = string.Empty;
            txt_tare.Text = string.Empty;
            txt_PoundNo.Text = string.Empty;
            txt_PoundName.Text = string.Empty;
        }
        /// <summary>
        /// 设定操作区数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_TareWeightHistory;
                if (entity != null)
                {
                    SetMainEditer(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                selectMainEntity = entity;
                queryMain = true;
                SetMainEditerEnabled(false);
            }
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_CarName.Enabled = enabled;
            txt_PoundName.Enabled = enabled;
            txt_tare.Enabled = enabled;
            txt_PoundNo.Enabled = enabled;
        }
        private void btn_fresh_Click(object sender, EventArgs e)
        {
            txt_CarNamequery.Focus();
            var rss = MainService.ExecuteDB_QueryByCarnameAndTime(getCondition());
            if (rss != null)
            {
                List<SM_TareWeightHistory> data = rss.ToList();
                data.ForEach(r =>
                {
                    r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);
                });
            }
            gcl_main.DataSource = rss;
            //gvw_main.BestFitColumns();
            SetMainEditerData();
        }
        private void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            selectMainEntity = new SM_TareWeightHistory();
            selectMainEntity = gvw_main.GetFocusedRow() as SM_TareWeightHistory;
            selectMainEntity.HistoryTare = Convert.ToInt32(txt_tare.Text);
            selectMainEntity.CarName = txt_CarName.Text;
            selectMainEntity.CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            selectMainEntity.CreateUserName = SessionHelper.LogUserNickName;
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (gvw_main.DataRowCount < 1)
            {
                var mm = MessageDxUtil.ShowTips("暂无数据可以删除");
                return;
            }
            selectMainEntity = gvw_main.GetFocusedRow() as SM_TareWeightHistory;
            if (selectMainEntity != null)
            {
                var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
                if (rs == DialogResult.Yes)
                {
                    ResetSelectMainEntity();
                    if (dxErrorProvider1.HasErrors) { return; }
                    var rss = MainService.ExecuteDB_DeleteHistoryTare(selectMainEntity);
                    if (rss is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rss).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                    }
                }
            }
        }
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_TareWeightHistory;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gcl_main.DataSource == null)
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
                gvw_main.ExportToXlsx(fileDialog.FileName, options);
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(fileDialog.FileName);//打开指定路径下的文件
            }
        }

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
        //新增
        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CarNamequery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var rss = MainService.ExecuteDB_QueryByCarnameAndTime(getCondition());
                if (rss != null)
                {
                    List<SM_TareWeightHistory> data = rss.ToList();
                    data.ForEach(r =>
                    {
                        r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);
                    });
                }
                gcl_main.DataSource = rss;
                //gvw_main.BestFitColumns();
                SetMainEditerData();
            }
        }

        private void btn_ToUse_Click(object sender, EventArgs e)
        {
            var entity = gvw_main.GetFocusedRow() as SM_TareWeightHistory;
            if (entity != null)
            {
                if (entity.CREATETIME == null || entity.CreateUserName == null || entity.HistoryTare <= 0)
                {
                    MessageDxUtil.ShowError("操作失败：选中记录不符合修改条件");
                    return;
                }
                string carName = entity.CarName;
                IList<SM_TareWeight> list = tareWeightService.ExecuteDB_QueryAllByCarNo(carName);
                if (list[0].IsUsed.EntityValue == 0)
                {
                    MessageDxUtil.ShowError("操作失败：请先作废该车辆最新皮重记录");
                    return;
                }

                SM_TareWeight tareWeight = new SM_TareWeight();

                tareWeight.CarName = entity.CarName;
                tareWeight.CREATETIME = Convert.ToDateTime(entity.CREATETIME).ToString("yyyyMMddHHmmss");
                tareWeight.CreateUserName = entity.CreateUserName;
                tareWeight.SiteName = entity.SiteName;
                tareWeight.SiteNo = entity.SiteNo;
                tareWeight.UPDATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                tareWeight.UpdateUserName = SessionHelper.LogUserNickName;
                tareWeight.NewTare = entity.HistoryTare;
                tareWeight.IsUsed = new EntityInt(1);//默认都给设置成禁用状态,设置之后需要相关人员确认启用该皮重
                var rs = tareWeightService.ExecuteDB_UpdateTareWeight3(tareWeight);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    MessageDxUtil.ShowTips("操作成功");
                }
            }
        }
    }
}
