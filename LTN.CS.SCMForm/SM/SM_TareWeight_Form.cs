using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_TareWeight_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_TareWeight selectMainEntity { get; set; }

        private bool queryMain { get; set; }
        public ISM_TareWeightService MainService { get; set; }
        public SM_TareWeight_Form()
        {
            InitializeComponent();
        }
        private void SM_TareWeight_Form_Shown(object sender, EventArgs e)
        {
            de_startTime.Text = DateTime.Now.AddDays(-2).ToShortDateString() + " 00:00:00";
            de_endTime.Text = DateTime.Now.ToShortDateString() + " 23:59:59";
            SetMainGridData(false);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            txt_CarNamequery.Focus();
            SetMainGridData(false);
        }
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;

                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAllByCondition(getCondition());
                    if (rss != null)
                    {
                        List<SM_TareWeight> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            r.UPDATETIME = CommonHelper.Str14ToTimeFormart(r.UPDATETIME);
                            r.CREATETIME = CommonHelper.Str14ToTimeFormart(r.CREATETIME);
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
                    SetMainEditerData();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        private Hashtable getCondition()
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
        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_TareWeight group = gvw_main.GetRow(i) as SM_TareWeight;
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
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_TareWeight;
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
            checkEdit1.Enabled = enabled;
        }
        private void SetMainEditer(SM_TareWeight entity)
        {
            if (entity != null)
            {
                txt_CarName.EditValue = entity.CarName;
                txt_PoundName.EditValue = entity.SiteName;
                txt_tare.EditValue = entity.NewTare;
                checkEdit1.EditValue = entity.IsUsed == null ? false : entity.IsUsed.EntityValue == 1;
            }
        }
        private void ClearMainEditer()
        {
            txt_CarName.EditValue = string.Empty;
            txt_PoundName.EditValue = string.Empty;
            txt_tare.EditValue = string.Empty; ;
            checkEdit1.EditValue = false;
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SM_TareWeight psite = gvw_main.GetFocusedRow() as SM_TareWeight;
            if (psite == null)
            {
                MessageDxUtil.ShowWarning("没有数据可以删除!");
                return;
            }
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }
        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeleteTareWeight(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "IsUsed")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString().Trim())
                    {
                        case "否":
                            e.DisplayText = "启用";
                            break;
                        case "是":
                            e.DisplayText = "作废";
                            break;
                        default:
                            e.DisplayText = "";
                            break;
                    }
                }
            }
        }
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_TareWeight;
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

        private void btn_Using_Click(object sender, EventArgs e)
        {

            try
            {
                var entity = gvw_main.GetFocusedRow() as SM_TareWeight;
                selectMainEntity.IsUsed = new EntityInt(0);
                //selectMainEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                //selectMainEntity.CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                //selectMainEntity.CarName = txt_CarName.Text;
                //selectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
                //selectMainEntity.NewTare = Convert.ToInt32(txt_tare.Text);
                //selectMainEntity.SiteName = txt_PoundName.Text;
                //selectMainEntity.SiteNo = entity.SiteNo;
                var rs = MainService.ExecuteDB_UpdateTareWeight2(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void btn_NotUse_Click(object sender, EventArgs e)
        {
            try
            {
                var rs = MessageDxUtil.ShowYesNoAndTips("确定作废吗?");
                if (rs == DialogResult.Yes)
                {
                    CustomUnused();
                }

            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void CustomUnused()
        {
            var entity = gvw_main.GetFocusedRow() as SM_TareWeight;
            selectMainEntity.IsUsed = new EntityInt(1);
            //selectMainEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            //selectMainEntity.CREATETIME = CommonHelper.TimeToStr14(Convert.ToDateTime(entity.CREATETIME));
            //selectMainEntity.CarName = txt_CarName.Text;
            //selectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;
            //selectMainEntity.NewTare = Convert.ToInt32(txt_tare.Text);
            //selectMainEntity.SiteName = txt_PoundName.Text;
            //selectMainEntity.SiteNo = entity.SiteNo;
            var rs = MainService.ExecuteDB_UpdateTareWeight2(selectMainEntity);
            if (rs is CustomDBError)
            {
                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
            }
            else
            {
                SetMainGridData(false);
            }
        }

        /// <summary>
        /// 自定义焦点行颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                SetMainGridData(false);
            }
        }
    }
}
