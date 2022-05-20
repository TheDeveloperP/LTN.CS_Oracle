using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.ServiceInterface.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.SCMService.SM.Interface;
using Spring.Context;
using Spring.Context.Support;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_PoundSite_Form : CoreForm
    {
        #region 变量

        public ISM_PoundSite_InfoService MainService { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        public SM_PoundSite_Info selectMainEntity { get; set; }
        private EventHandler eventMainNow;
        #endregion

        #region 构造器
        public SM_PoundSite_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
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

        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_PoundSite_Info group = gvw_main.GetRow(i) as SM_PoundSite_Info;
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
                var entity = gvw_main.GetFocusedRow() as SM_PoundSite_Info;
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



        private void SetMainEditer(SM_PoundSite_Info entity)
        {
            if (entity != null && entity.PoundSiteNo != null)
            {
                txt_PondSiteNo.EditValue = entity.PoundSiteNo;
                txt_PondSiteNickName.EditValue = entity.PoundSiteNickName;
                txt_PondSiteName.EditValue = entity.PoundSiteName;
                lup_PondSiteType.EditValue = entity.PoundType.IntValue;//磅点类别
               lup_PondState.EditValue = entity.PoundSiteStatus.IntValue;//磅点状态

                txt_PondSiteIP.EditValue = entity.PoundSiteIP;
                txt_Range.EditValue = entity.Range;
                //txt_Accuracy.EditValue = entity.Accuracy;
                ce_redOpen.EditValue=  entity.IsRedOpen == null ? false : entity.IsRedOpen.EntityValue == 1;
                //txt_Level.EditValue = entity.;

                // ch_IsUsing.EditValue = entity.IsSettle == null ? false : entity.IsSettle.EntityValue == 1;//是否结算
                txt_PondSiteAddress.EditValue = entity.PoundSiteAddress;
                // txt_DvrId.EditValue = entity.DVRIP;
            }
        }

        private void ClearMainEditer()
        {
            txt_PondSiteNo.EditValue = string.Empty;
            txt_PondSiteNickName.EditValue = string.Empty;
            txt_PondSiteName.EditValue = string.Empty;
            lup_PondSiteType.EditValue = 1;
            txt_PondSiteIP.EditValue = string.Empty;
            txt_Range.EditValue = string.Empty;
           // txt_Accuracy.EditValue = string.Empty;
            //txt_Level.EditValue = string.Empty;
            lup_PondState.EditValue = 1;
            //ch_IsUsing.Checked = false;
            txt_PondSiteAddress.EditValue = string.Empty;
            ce_redOpen.Checked = false;
            //txt_DvrId.EditValue = string.Empty;
        }

        private void SetMainEditerEnabled(bool enabled)
        {
            txt_PondSiteNo.Enabled = enabled;
            txt_PondSiteNickName.Enabled = enabled;
            txt_PondSiteName.Enabled = enabled;
            lup_PondSiteType.Enabled = enabled;
            txt_PondSiteIP.Enabled = enabled;
            txt_Range.Enabled = enabled;
           // txt_Accuracy.Enabled = enabled;
            // txt_Level.Enabled = enabled;
           lup_PondState.Enabled = enabled;
            ce_redOpen.Enabled = enabled;
            //ch_IsUsing.Enabled = enabled;
            txt_PondSiteAddress.Enabled = enabled;
            // txt_DvrId.Enabled = enabled;
            if (enabled)
            {
                txt_PondSiteNo.Focus();
            }
        }

        private void SetMainButtonEnabled(bool update)
        {

            btn_Refresh.Enabled = update;
            btn_Add.Enabled = update;
            btn_update.Enabled = update;
            btn_Delete.Enabled = update;
            btn_Confirm.Enabled = !update;
            btn_Cancel.Enabled = !update;

        }

        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdatePoundSiteInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        UploadUpdatePondSiteInfo(selectMainEntity);
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
        /// 实体赋值
        /// </summary>
        public void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            if (txt_PondSiteNo.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_PondSiteNo, "磅点编号为必填！", ErrorType.Information);
            }
            if (txt_PondSiteName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_PondSiteName, "磅点名称为必填！", ErrorType.Information);
            }

            //if (txt_DvrId.EditValue == string.Empty)
            //{
            //    dxErrorProvider1.SetError(txt_DvrId, "硬盘录像机信息为必填！", ErrorType.Information);
            //}

            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_PoundSite_Info()
                {
                    createUser = SessionHelper.LogUserNickName,
                    updateUser = SessionHelper.LogUserNickName
                };
            }

            var queryResult = MainService.ExecuteDB_QueryByPoundSiteId(txt_PondSiteNo.Text);
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (queryResult != null && queryResult.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_PondSiteNo, "磅点已存在！", ErrorType.Information);
                    return;
                }
            }
            else
            {
                if (queryResult != null && queryResult.Count() > 0 && queryResult[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_PondSiteNo, "该磅点已存在请确认磅点！", ErrorType.Information);
                    return;
                }
            }


            selectMainEntity.IsRedOpen= new EntityInt(ce_redOpen.Checked ? 1 : 0);
            selectMainEntity.PoundSiteNo = txt_PondSiteNo.Text;
            selectMainEntity.PoundSiteNickName = txt_PondSiteNickName.Text;
            selectMainEntity.PoundSiteName = txt_PondSiteName.Text;
            selectMainEntity.PoundType = new PondTypeObj() { IntValue = MyNumberHelper.ConvertToInt32(lup_PondSiteType.EditValue) };
            selectMainEntity.PoundSiteIP = txt_PondSiteIP.Text;
            selectMainEntity.Range = MyNumberHelper.ConvertToDecimal(txt_Range.Text);
            //selectMainEntity.Accuracy = MyNumberHelper.ConvertToDecimal(txt_Accuracy.Text);
            selectMainEntity.Accuracy = 0;
            selectMainEntity.PoundSiteStatus = new PondStatusObj() { IntValue = MyNumberHelper.ConvertToInt32(lup_PondState.EditValue) };
            //selectMainEntity.PoundSiteStatus = new PondStatusObj() { IntValue =1 };
            selectMainEntity.PoundSiteAddress = txt_PondSiteAddress.Text;
            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
            // selectMainEntity.Level = MyNumberHelper.ConvertToInt32(txt_Level.EditValue);
            // selectMainEntity.IsSettle = new EntityInt(ch_IsUsing.Checked ? 1 : 0);
            //selectMainEntity.DataType = new DataTypeObj() { IntValue = 0 };


        }
        /// <summary>
        /// 任务调度
        /// </summary>
        /// <param name="pondSite"></param>
        private void UploadUpdatePondSiteInfo(SM_PoundSite_Info pondSite)
        {
            try
            {
                DM_PondSite_Info_WCF pondWcf = new DM_PondSite_Info_WCF();
                pondWcf.IntId = pondSite.IntId;
                pondWcf.PondSiteNo = pondSite.PoundSiteNo;
                //pondWcf.Level = pondSite.Level;
                pondWcf.PondSiteNickName = pondSite.PoundSiteNickName;
                pondWcf.PondSiteType = new SiteTypeObj(pondSite.PoundType.IntValue);
                //pondWcf.PondSiteType = new SiteTypeObj(MyNumberHelper.ConvertToInt32(pondSite.PoundType.EnumValue.ToString()));               
                pondWcf.PondSiteName = pondSite.PoundSiteName;
                pondWcf.PondSiteIP = pondSite.PoundSiteIP;
                pondWcf.PondSiteAddress = pondSite.PoundSiteAddress;
                pondWcf.PondSiteStatus = pondSite.PoundSiteStatus;
                pondWcf.Range = (Decimal)pondSite.Range;
                pondWcf.Accuracy = (Decimal)pondSite.Accuracy;
                // pondWcf.DVRId = pondSite.DVRIP.IntId;
                pondWcf.DVRIP = pondSite.DVRIP;
                IApplicationContext ctx = ContextRegistry.GetContext();
                using (ChannelFactory<IDM_PondSite_InfoWCFService> factory = ctx.GetObject("DM_PondSite_InfoWCFServiceClient") as ChannelFactory<IDM_PondSite_InfoWCFService>)
                {
                    IDM_PondSite_InfoWCFService service = factory.CreateChannel();
                    int rs = service.UpdatePondSite(pondWcf);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertPoundSiteInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        UploadUpdatePondSiteInfo(selectMainEntity);
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

        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeletePoundSiteInfo(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                    UploadDeletePondSiteInfo(selectMainEntity);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void UploadDeletePondSiteInfo(SM_PoundSite_Info pondSite)
        {
            DM_PondSite_Info_WCF pondWcf = new DM_PondSite_Info_WCF();
            pondWcf.IntId = pondSite.IntId;
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (ChannelFactory<IDM_PondSite_InfoWCFService> factory = ctx.GetObject("DM_PondSite_InfoWCFServiceClient") as ChannelFactory<IDM_PondSite_InfoWCFService>)
            {
                IDM_PondSite_InfoWCFService service = factory.CreateChannel();
                int rs = service.DeletePondSite(pondWcf);
            }
        }
        #endregion

        #region 控件事件

        #endregion


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void SM_PoundSite_Form_Shown(object sender, EventArgs e)
        {
            //txt_PondSiteType.Properties.DataSource = DataPondTypeObj.GetAuthTypeData();
            lup_PondSiteType.Properties.DataSource = PondTypeObj.GetPondTypeData();
             lup_PondState.Properties.DataSource = PondStatusObj.GetPondStatusData();
            //lue_DvrId.Properties.DataSource = dvrService.ExecuteDB_QueryAll();
            SetMainGridData(false);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_PoundSite_Info;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SM_PoundSite_Info psite = gvw_main.GetFocusedRow() as SM_PoundSite_Info;
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

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }

       
    }
}
