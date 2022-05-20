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
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPrinting.Native;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.ServiceInterface.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using Spring.Context;
using Spring.Context.Support;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_Site_Form : CoreForm
    {
        #region 构造器
        public SM_Site_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量
        private EventHandler eventMainNow;
        public SM_Site_Info selectMainEntity { get; set; }
        public ISM_Site_InfoService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        #endregion

        #region 自定义方法

        private void ClearMainEditer()
        {
            txt_SiteNo.EditValue = string.Empty;
            txt_SiteName.EditValue = string.Empty;
            lup_SiteType.EditValue = 1;
            txt_SiteAddress.EditValue = string.Empty;
            txt_SiteIP1.EditValue = string.Empty;
            txt_SiteIP2.EditValue = string.Empty;
           // txt_Level.EditValue = string.Empty;
            ch_IsAutoWeight.Checked = false;
        }

        private void SetMainEditerEnabled(bool enabled)
        {
            txt_SiteNo.Enabled = enabled;
            txt_SiteName.Enabled = enabled;
            lup_SiteType.Enabled = enabled;
            txt_SiteAddress.Enabled = enabled;
            txt_SiteIP1.Enabled = enabled;
            txt_SiteIP2.Enabled = enabled;
           // txt_Level.Enabled = enabled;
            ch_IsAutoWeight.Enabled = enabled;
            if (enabled)
            {
                txt_SiteNo.Focus();
            }
        }
        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="enabled"></param>
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Refresh.Enabled = true;
                btn_Add.Enabled = true;
                btn_update.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else
            {
                btn_Refresh.Enabled = false;
                btn_Add.Enabled = false;
                btn_update.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;
            }
        }
        /// <summary>
        /// 实体赋值
        /// </summary>
        public void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            if (txt_SiteNo.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_SiteNo, "坐席编号为必填！", ErrorType.Information);
            }
            if (txt_SiteName.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_SiteName, "坐席名称为必填！", ErrorType.Information);
            }

            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_Site_Info()
                {
                    //createUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                   // updateUser = new BM_USER() { IntId = SessionHelper.LogUserId }
                   createUser=SessionHelper.LogUserNickName,
                   updateUser=SessionHelper.LogUserNickName
                };
            }
            //var queryResult = MainService.ExecuteDB_QueryAllByPondSiteNo(txt_SiteNo.Text);
            var queryResult = MainService.ExecuteDB_QueryBySiteId(txt_SiteNo.Text);
            
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (queryResult != null && queryResult.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_SiteNo, "坐席编号已存在！", ErrorType.Information);
                    return;
                }
            }
            else
            {
                if (queryResult != null && queryResult.Count() > 0 && queryResult[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_SiteNo, "该编号已存在请确认坐席编号！", ErrorType.Information);
                    return;
                }
            }
          
            selectMainEntity.siteId = txt_SiteNo.Text;
            selectMainEntity.siteName = txt_SiteName.Text;
            selectMainEntity.siteType = new PondTypeObj() { IntValue = MyNumberHelper.ConvertToInt32(lup_SiteType.EditValue) };
            selectMainEntity.siteLocation = txt_SiteAddress.Text;
            //selectMainEntity.siteLevel = MyNumberHelper.ConvertToInt32(txt_Level.EditValue);
            selectMainEntity.siteLevel = 0;
            selectMainEntity.IsAutoWeigh = new EntityInt(ch_IsAutoWeight.Checked ? 1 : 0);
            selectMainEntity.siteIp1 = txt_SiteIP1.Text;
            selectMainEntity.siteIp2 = txt_SiteIP2.Text;
            //selectMainEntity.DataType = new DataTypeObj() { IntValue = 0 };
            //selectMainEntity.UpdateUser = new BM_USER() { IntId = SessionHelper.LogUserId };
            selectMainEntity.updateUser = SessionHelper.LogUserNickName;
        }

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
                    SM_Site_Info group = gvw_main.GetRow(i) as SM_Site_Info;
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
                var entity = gvw_main.GetFocusedRow() as SM_Site_Info;
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
        private void SetMainEditer(SM_Site_Info entity)
        {
            if (entity != null && entity.siteId != null)
            {
                txt_SiteNo.EditValue = entity.siteId;
                txt_SiteName.EditValue = entity.siteName;
                //txt_SiteType.EditValue = entity.siteType;
                lup_SiteType.EditValue = entity.siteType.IntValue;
                txt_SiteAddress.EditValue = entity.siteLocation;
                txt_SiteIP1.EditValue = entity.siteIp1;
                txt_SiteIP2.EditValue = entity.siteIp2;
               // txt_Level.EditValue = entity.siteLevel;
                ch_IsAutoWeight.EditValue = entity.IsAutoWeigh == null ? false : entity.IsAutoWeigh.EntityValue == 1;
            }
        }


        /// <summary>
        ///自定义新增
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
                    //var rs = MainService.ExecuteDB_InsertSite(selectMainEntity);
                    var rs = MainService.ExecuteDB_InsertSiteInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        UploadUpdateSiteInfo(selectMainEntity);
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

        private void UploadUpdateSiteInfo(SM_Site_Info Site)
        {
            DM_Site_Info_WCF siteWCF = new DM_Site_Info_WCF();
            siteWCF.IntId = Site.IntId;
            siteWCF.SiteNo = Site.siteId;
            //siteWCF.SiteType = Site.siteType;
            //siteWCF.SiteType = new Base.Common.SiteTypeObj(1);
            siteWCF.SiteType = new SiteTypeObj(1);
            //siteWCF.SiteType = new DataPondTypeObj(1);
            siteWCF.SiteName = Site.siteName;
            siteWCF.SiteIP = Site.siteIp1;
            siteWCF.IP2 = Site.siteIp2;
            siteWCF.SiteAddress = Site.siteLocation;
            siteWCF.IsAutoWeigh = Site.IsAutoWeigh;
            siteWCF.Level = Site.siteLevel;//坐席优先级
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (ChannelFactory<IDM_Site_InfoWCFService> factory = ctx.GetObject("DM_Site_InfoWCFServiceClient") as ChannelFactory<IDM_Site_InfoWCFService>)
            {
                IDM_Site_InfoWCFService service = factory.CreateChannel();
                int rs = service.UpdateSite(siteWCF);
            }
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
                    var rs = MainService.ExecuteDB_UpdateSiteInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        UploadUpdateSiteInfo(selectMainEntity);
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
                //var rs = MainService.ExecuteDB_UpdateSiteByZuoFei(selectMainEntity);

                var rs = MainService.ExecuteDB_DeleteSiteInfo(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                    UploadDeleteSiteInfo(selectMainEntity);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void UploadDeleteSiteInfo(SM_Site_Info Site)
        {
            DM_Site_Info_WCF siteWCF = new DM_Site_Info_WCF();
            siteWCF.IntId = Site.IntId;
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (ChannelFactory<IDM_Site_InfoWCFService> factory = ctx.GetObject("DM_Site_InfoWCFServiceClient") as ChannelFactory<IDM_Site_InfoWCFService>)
            {
                IDM_Site_InfoWCFService service = factory.CreateChannel();
                int rs = service.DeleteSite(siteWCF);
            }
        }
        #endregion

        #region 控件事件
        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }
        #endregion

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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_Site_Info;
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
            SM_Site_Info psite = gvw_main.GetFocusedRow() as SM_Site_Info;
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

        private void SM_Site_Form_Shown(object sender, EventArgs e)
        {
            //lup_SiteType.Properties.DataSource = DataPondTypeObj.GetAuthTypeData();
            lup_SiteType.Properties.DataSource = PondTypeObj.GetPondTypeData();
            SetMainGridData(false);
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
