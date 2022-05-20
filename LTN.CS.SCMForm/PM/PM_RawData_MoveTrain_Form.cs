using DevExpress.XtraGrid.Views.Base;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
namespace LTN.CS.SCMForm.PM
{
    public partial class PM_RawData_MoveTrain_Form : CoreForm
    {
        #region 实例变量
        public IPM_RawData_MoveTrainService MainService { get; set; }
        public ISM_PoundSite_InfoService PondSiteService { get; set; }
        /// <summary>
        /// 当前执行事件
        /// </summary>
        private EventHandler eventMainNow;
        /// <summary>
        /// 当前选中实体ID
        /// </summary>
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        private PM_RawData_MoveTrain selectMainEntity { get; set; }
        //新增
        private PM_RawData_MoveTrain_New selectMainEntity_new { get; set; }
        #endregion

        #region 构造函数
        public PM_RawData_MoveTrain_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void setDataSource()
        {
            lue_DataFlag.Properties.DataSource = RawDataStatusObj.GetRawDataStatusData();
            lue_WeightFlag.Properties.DataSource = WeightTypeObj.GetWeightTypeData();
            lue_SiteNo.Properties.DataSource = PondSiteService.ExecuteDB_QueryAll();
            lue_PondSite_ref.Properties.DataSource = PondSiteService.ExecuteDB_QueryAll();
            dte_begin.Text = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd 00:00:00");
            dte_end.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        private Hashtable GetQueryCondition()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(txt_TrainNo_ref.Text))
            {
                condition.Add("CarNo", txt_TrainNo_ref.Text);
            }
            if (!string.IsNullOrEmpty(lue_PondSite_ref.Text))
            {
                condition.Add("SiteNo", lue_PondSite_ref.EditValue);
            }
            if (!string.IsNullOrEmpty(dte_begin.Text))
            {
                condition.Add("BeginDate", dte_begin.Text);
            }
            if (!string.IsNullOrEmpty(dte_end.Text))
            {
                condition.Add("EndDate", dte_end.Text);
            }
            return condition;
        }
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    Hashtable dictionary = GetQueryCondition();
                    //var rss = MainService.ExecuteDB_QueryByHashTable(dictionary);
                    var rss = MainService.ExecuteDB_QueryByHashTable_New(dictionary);
                    if (rss != null)
                    {
                        List<PM_RawData_MoveTrain_New> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            if (r.UpdateTime != null)
                            {
                                r.UpdateTime = CommonHelper.Str14ToTimeFormart(r.UpdateTime);
                            }
                            if (r.CreateTime != null)
                            {
                                r.CreateTime = CommonHelper.Str14ToTimeFormart(r.CreateTime);
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
                    SetMainEditerData();
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
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
            /*
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_RawData_MoveTrain rawData = gvw_main.GetRow(i) as PM_RawData_MoveTrain;
                    if (rawData.IntId == selectMainId)
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
             * */
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_RawData_MoveTrain_New rawData = gvw_main.GetRow(i) as PM_RawData_MoveTrain_New;
                    if (rawData.IntId == selectMainId)
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
                //var entity = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain;
                var entity = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain_New;                
                if (entity != null)
                {
                    //SetMainEditer(entity);
                    SetMainEditer_New(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                //selectMainEntity = entity;
                selectMainEntity_new = entity;
                queryMain = true;
            }
        }
        private void SetMainEditer(PM_RawData_MoveTrain entity)
        {
            if (entity != null)
            {
                txt_CarNo.Text = entity.CarNo;
                txt_OrderNo.Text = entity.OrderNo;
                txt_FormationTag.Text = entity.FormationTag;
                txt_WeightData.Text = entity.WeightData.ToString();
                txt_Speed.Text = entity.Speed.ToString();
                lue_SiteNo.EditValue = entity.SiteNo.PoundSiteNo;
                lue_DataFlag.EditValue = entity.DataFlag.IntValue;
                lue_WeightFlag.EditValue = entity.WeightFlag.IntValue;
                dte_WeightTime.Text = entity.WeightTime;
            }
        }
        private void ClearMainEditer()
        {
            txt_OrderNo.Text = string.Empty;
            txt_CarNo.Text = string.Empty;
            txt_FormationTag.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txt_WeightData.Text = string.Empty;
            txt_Speed.Text = string.Empty;
            lue_SiteNo.EditValue = null;
            lue_DataFlag.EditValue = null;
            lue_WeightFlag.EditValue = null;
            dte_WeightTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Add.Enabled = true;
                btn_update.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else
            {
                btn_Add.Enabled = false;
                btn_update.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;
            }
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_OrderNo.Enabled = enabled;
            txt_CarNo.Enabled = enabled;
            txt_FormationTag.Enabled = enabled;
            txt_WeightData.Enabled = enabled;
            txt_Speed.Enabled = enabled;
            lue_DataFlag.Enabled = enabled;
            lue_SiteNo.Enabled = enabled;
            lue_WeightFlag.Enabled = enabled;
            dte_WeightTime.Enabled = enabled;
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSelectMainEntity()
        {
            if (eventMainNow != null && eventMainNow.Method.Name == "CustomMainInsert")
            {
                /*
                selectMainEntity = new PM_RawData_MoveTrain()
                {
                    CreateUser = SessionHelper.LogUserNickName,
                    UpdateUser = SessionHelper.LogUserNickName
                };
                 * */
                selectMainEntity_new = new PM_RawData_MoveTrain_New()
                {
                    CreateUser = SessionHelper.LogUserNickName,
                    UpdateUser = SessionHelper.LogUserNickName
                };
            }
            /*
            selectMainEntity.OrderNo = txt_OrderNo.Text;
            selectMainEntity.CarNo = txt_CarNo.Text;
            selectMainEntity.FormationTag = txt_FormationTag.Text;
            selectMainEntity.WeightData = Convert.ToDecimal(txt_WeightData.Text);
            selectMainEntity.Speed = Convert.ToDecimal(txt_Speed.Text);
            selectMainEntity.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = lue_SiteNo.EditValue.ToString() };
            selectMainEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)lue_DataFlag.EditValue };
            selectMainEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)lue_WeightFlag.EditValue };
            selectMainEntity.WeightTime = dte_WeightTime.Text;
            selectMainEntity.UpdateUser = SessionHelper.LogUserNickName;
             * */
            selectMainEntity_new.OrderNo = txt_OrderNo.Text;
            selectMainEntity_new.CarNo = txt_CarNo.Text;
            selectMainEntity_new.FormationTag = txt_FormationTag.Text;
            selectMainEntity_new.WeightData = Convert.ToDecimal(txt_WeightData.Text);
            selectMainEntity_new.Speed = Convert.ToDecimal(txt_Speed.Text);
            selectMainEntity_new.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = lue_SiteNo.EditValue.ToString() };
            selectMainEntity_new.DataFlag = new RawDataStatusObj() { IntValue = (int)lue_DataFlag.EditValue };
            selectMainEntity_new.WeightFlag = new WeightTypeObj() { IntValue = (int)lue_WeightFlag.EditValue };
            selectMainEntity_new.WeightTime = dte_WeightTime.Text;
            selectMainEntity_new.UpdateUser = SessionHelper.LogUserNickName;

        }
        /// <summary>
        /// 自定义修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    //var rs = MainService.ExecuteDB_UpdateRawDataInfo(selectMainEntity);
                    var rs = MainService.ExecuteDB_UpdateRawDataInfo_New(selectMainEntity_new);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 自定义新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    //var rs = MainService.ExecuteDB_InsertRawDataInfo(selectMainEntity);
                    var rs = MainService.ExecuteDB_InsertRawDataInfo_New(selectMainEntity_new);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeleteRawDataInfo(selectMainEntity);
                //var rs = MainService.ExecuteDB_DeleteRawDataInfo_New(selectMainEntity_new);
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
        #endregion

        #region 控件事件
        private void gvw_main_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            /*
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
             * */
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain_New;
                if (entity != null)
                {
                    SetMainEditer_New(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity_new = entity;
                SetMainButtonEnabled(true);
            }

        }
        /// <summary>
        /// 画面开始展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PM_RawData_MoveTrain_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();
            SetMainGridData(true);
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            /*
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
             * */
            var rs = MessageDxUtil.ShowYesNoAndTips("该功能暂时收起");
        }

        private void gvw_main_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var item = gvw_main.GetRowCellValue(e.RowHandle, "DataFlag.RawDataStatusDesc");
            if (item != null)
            {
                string dataflag = gvw_main.GetRowCellValue(e.RowHandle, "DataFlag.RawDataStatusDesc").ToString();
                if (dataflag == "作废")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                if (dataflag == "保存" || dataflag == "已匹配")
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
            
            
        }
        #endregion

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            /*
            var item = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
            {
                item.UpdateTime = CommonHelper.TimeToStr14(DateTime.Now);
                item.UpdateUser = SessionHelper.LogUserNickName;
                var result = MainService.ExecuteDB_InvalidRawDatByIntId(item);
                if (result != null)
                {
                    MessageDxUtil.ShowTips("作废成功");
                    SetMainGridData(false);
                }
                else
                {
                    MessageDxUtil.ShowError("作废异常");
                }
            }
             * */
            var item = gvw_main.GetFocusedRow() as PM_RawData_MoveTrain_New;
            if (item == null)
                return;
            if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
            {
                item.UpdateTime = CommonHelper.TimeToStr14(DateTime.Now);
                item.UpdateUser = SessionHelper.LogUserNickName;
                //var result = MainService.ExecuteDB_InvalidRawDatByIntId(item);
                var result = MainService.ExecuteDB_InvalidRawDatByIntId_New(item);
                if (result != null)
                {
                    MessageDxUtil.ShowTips("作废成功");
                    SetMainGridData(false);
                }
                else
                {
                    MessageDxUtil.ShowError("作废异常");
                }
            }
        }
        //新增序号列
        private void gvw_main_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        //导出原始数据
        private void gToolStripButton1_Click(object sender, EventArgs e)
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
        private void SetMainEditer_New(PM_RawData_MoveTrain_New entity)
        {
            if (entity != null)
            {
                txt_CarNo.Text = entity.CarNo;
                txt_OrderNo.Text = entity.OrderNo;
                txt_FormationTag.Text = entity.FormationTag;
                txt_WeightData.Text = entity.WeightData.ToString();
                txt_Speed.Text = entity.Speed.ToString();
                lue_SiteNo.EditValue = entity.SiteNo.PoundSiteNo;
                lue_DataFlag.EditValue = entity.DataFlag.IntValue;
                lue_WeightFlag.EditValue = entity.WeightFlag.IntValue;
                dte_WeightTime.Text = entity.WeightTime;
            }
        }
    }
}
