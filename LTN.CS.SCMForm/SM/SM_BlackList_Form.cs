using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
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
    public partial class SM_BlackList_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; } 
        private SM_BlackList selectMainEntity { get; set; }
        private SM_BlackListHistory selectHistoryEntity { get; set; }
        private bool queryMain { get; set; }
        public ISM_BlackListService MainService { get; set; }
        public SM_BlackList_Form()
        {
            InitializeComponent();
        }
        private void SM_BlackList_Form_Shown(object sender, EventArgs e)
        {
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            SetMainGridData(false);
            SetHtyGridData(false);
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_CriminalRecord.Enabled = enabled;
            if (enabled)
            {
                txt_CarName.Focus();
            }
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Add.Enabled = true;
                
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Delete.Enabled = true;
                btn_fresh.Enabled = true;
            }
            else
            {
                btn_Add.Enabled = false;                
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;
                btn_Delete.Enabled = false;
                btn_fresh.Enabled = false;
            }
        }
        /// <summary>
        /// 设定操作区数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_BlackList;
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
            }
        }
        private void SetMainEditer(SM_BlackList entity)
        {
            //txt_CarName.Text = entity.CarName;
            //txt_CriminalRecord.EditValue = entity.CriminalRecord;

        }
        private void ClearMainEditer()
        {
            txt_CarName.Text = string.Empty;
            txt_CriminalRecord.Text= string.Empty;


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
                    var rss = MainService.ExecuteDB_QueryAll();

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
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_BlackList group = gvw_main.GetRow(i) as SM_BlackList;
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
        /// 设定主档Grid数据
        /// </summary>
        private void SetHtyGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;

                    var rss = MainService.ExecuteDB_QueryHistoryAll();
                    if (rss != null) {
                        List<SM_BlackListHistory> data = rss.ToList();
                        data.ForEach(r => {
                            if (r.UPDATETIME != null) {
                                r.UPDATETIME=CommonHelper.Str14ToTimeFormart(r.UPDATETIME);
                            }
                        });  
                    }

                    gcl_hty.DataSource = rss;
                    gvw_hty.BestFitColumns();
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
        private void setError()
        {
            if (txt_CarName.EditValue == null)
            {
                dxErrorProvider1.SetError(txt_CarName, "实际车牌为必填！", ErrorType.Information);
            }
            if (txt_CriminalRecord.Text == "")
            {
                dxErrorProvider1.SetError(txt_CriminalRecord, "违规记录为必填！", ErrorType.Information);
            }
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            selectHistoryEntity = new SM_BlackListHistory();


            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                setError();
                if (dxErrorProvider1.HasErrors)
                {
                    return;
                }
                selectMainEntity = new SM_BlackList();
                selectMainEntity.CarName = txt_CarName.Text.Trim();
                selectMainEntity.CriminalRecord =  txt_CriminalRecord.Text.Trim();

                selectHistoryEntity.OperationRecord = "加入黑名单：" + txt_CriminalRecord.Text.Trim();
                selectHistoryEntity.CarName = txt_CarName.Text.Trim();
                selectHistoryEntity.UpdateUserName = SessionHelper.LogUserNickName;
                selectHistoryEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);

                
            }


            if (eventMainNow.Method.Name == "CustomMainDelete")
            {
                selectMainEntity = gvw_main.GetFocusedRow() as SM_BlackList;
                selectMainEntity.CriminalRecord = "";
                selectHistoryEntity.OperationRecord = "取消黑名单";
                selectHistoryEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                selectHistoryEntity.UpdateUserName = SessionHelper.LogUserNickName;
                
            }


            selectHistoryEntity.CarName = selectMainEntity.CarName;
            selectHistoryEntity.UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            selectHistoryEntity.UpdateUserName = SessionHelper.LogUserNickName;
        }
        private void btn_fresh_Click(object sender, EventArgs e)
        {
            SetMainEditerData();
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            CustomMainSelect(null,null);
        }
        private void CustomMainSelect(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CarName.Text))
            {
                txt_CarName.EditValue = "";
            }
            var rss = MainService.ExecuteDB_QueryBlackListByCarName(txt_CarName.EditValue.ToString().Trim());
            gcl_main.DataSource = rss;
            var rss1 = MainService.ExecuteDB_QueryBlackListHistoryByCarName(txt_CarName.EditValue.ToString().Trim());
            if (rss1 != null)
            {
                List<SM_BlackListHistory> data = rss1.ToList();
                data.ForEach(r => {
                    if (r.UPDATETIME != null)
                    {
                        r.UPDATETIME = CommonHelper.Str14ToTimeFormart(r.UPDATETIME);
                    }
                });
            }
            gcl_hty.DataSource = rss1;
        }
        private void gvw_main_DoubleClick(object sender, EventArgs e)
        {
            SetHtyGridData(false);
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
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
                    //判断是否已经存在
                    var rss = MainService.ExecuteDB_QueryBlackListByCarName2(txt_CarName.Text);
                    if (rss is CustomDBError)
                    {

                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rss).ErrorMsg);
                    }
                    else
                    {
                        IList<SM_BlackList> mm = rss as IList<SM_BlackList>;
                        if (mm != null && mm.Count > 0)
                        {
                            MessageDxUtil.ShowError("操作失败：该车辆已经加入黑名单！");
                            return;
                        }
                    }
                    //如果不存在则加入和名单
                    var rs = MainService.ExecuteDB_InsertBlackList(selectMainEntity);
                    rs = MainService.ExecuteDB_InsertBlackListHistory(selectHistoryEntity);
                    if (rs is CustomDBError)
                    {

                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        SetHtyGridData(false);
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {

            if (gvw_main.DataRowCount < 1)
            {
                var mm = MessageDxUtil.ShowTips("暂无数据可以删除");
                return;
            }
            selectMainEntity = gvw_main.GetFocusedRow() as SM_BlackList;
            if (selectMainEntity != null)
            {
                var rs = MessageDxUtil.ShowYesNoAndTips(selectMainEntity.CarName + "确定取消该黑名单吗?");
                if (rs == DialogResult.Yes)
                {
                    eventMainNow = CustomMainDelete;
                    CustomMainDelete(null, null);
                }
            }
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainDelete(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (dxErrorProvider1.HasErrors) { return; }


                var rs = MainService.ExecuteDB_DeleteBlackList(selectMainEntity);

                //删除之后需要在历史记录中添加（或者在其之前）
                rs = MainService.ExecuteDB_InsertBlackListHistory(selectHistoryEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                    SetHtyGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            btn_Confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_BlackList;
                if (entity != null)
                {
                    // SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
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

        private void gvw_hty_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_hty.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }
    }
}
