using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.API;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_MoveTrain_Mats_Form : CoreForm
    {
        #region 实例变量
        public IPM_RawData_MoveTrainService rawdatamoveservice { get; set; }
        public IPM_Pond_Bill_SuppliesService pondsuppliesService { get; set; }
        public IPM_Bill_SuppliesService suppliesService { get; set; }
        private ISM_Dvr_InfoService dvrService { get; set; }
        public ISM_PoundSite_InfoService pondSiteInfoService { get; set; }
        public IPM_Middle_SuppliesPond_InfoService middleService { get; set; }
        public IPM_Standard_Tare_InfoService tareService { get; set; }
        public string siteno;
        public string IP;
        public string formationtag;
        public PM_Pond_Bill_Supplies pondInfo { get; set; }
        private DM_PondSite_Info_WCF pondSiteInfo { get; set; }
        public PM_RawData_MoveTrain rawData { get; set; }
        public PM_Middle_SuppliesPond_Info middlePond { get; set; }
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        #endregion

        #region 构造函数
        public PM_Bill_MoveTrain_Mats_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void Settxt_poundsiteData()
        {
            var rss = pondSiteInfoService.ExecuteDB_QueryAll2();
            rss = rss == null ? null : rss.Where(e => e.PondSiteType != null && e.PondSiteType.EnumValue == SiteType.DynamicMaterial).ToList();
            synchronizationContext.Send(a =>
            {
                lue_SiteNo.Properties.DataSource = rss;
            }, null);
        }
        private void lue_SiteNo_EditValueChanged(object sender, EventArgs e)
        {
            gcl_main.DataSource = null;
            if (MyNumberHelper.ConvertToInt32(lue_SiteNo.EditValue) != 0 && lue_SiteNo.EditValue != null)
            {

                DM_PondSite_Info_WCF pond = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                siteno = pond.PondSiteNo;
                IP = pond.PondSiteIP;
            }
            if (siteno == string.Empty)
            {
                MessageDxUtil.ShowTips("选择有效磅点！");
                return;
            }
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                ht.Add("SiteNo", lue_SiteNo.EditValue);
            }
            lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);
        }
        private void lue_FormationTag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                btn_select_Click(null, null);
                getPond(formationtag);
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(lue_SiteNo.Text))
                {
                    ht.Add("SiteNo", lue_SiteNo.EditValue);
                }
                lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);
            }
            catch (Exception)
            {
            }
        }
        private Hashtable NewMethod()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                condition.Add("SiteNo", lue_SiteNo.EditValue.ToString());
            }
            if (!string.IsNullOrEmpty(lue_FormationTag.Text))
            {
                condition.Add("FormationTag", lue_FormationTag.Text);
            }

            return condition;
        }
        private void getPond(string formation)
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                ht.Add("SiteNo", lue_SiteNo.EditValue.ToString());
            }
            if (!string.IsNullOrEmpty(lue_FormationTag.Text))
            {
                ht.Add("Traingroup", lue_FormationTag.Text);
            }
            var result = middleService.ExecuteDB_QueryByGroup(ht);
            if (result is CustomDBError)
            {
                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
            }
            else
            {
                if (result.Count != 0)
                {
                    List<PM_Middle_SuppliesPond_Info> data = result.ToList();
                    data.ForEach(r =>
                    {
                        if (r.GrossWgtTime != null)
                        {
                            r.GrossWgtTime = CommonHelper.Str14ToTimeFormart(r.GrossWgtTime);
                        }
                        if (r.TareWgtTime != null)
                        {
                            r.TareWgtTime = CommonHelper.Str14ToTimeFormart(r.TareWgtTime);
                        }
                    });
                }
                gcl_pond.DataSource = result;
                gvw_pond.BestFitColumns();
            }
        }
        private bool matchPlan(PM_Pond_Bill_Supplies poundtrainmats)
        {
            bool bl = true;
            try
            {
                var rs = suppliesService.ExecuteDB_QueryIronByCarNo(String.Format("'{0}'", poundtrainmats.WagNo));
                if (rs != null && rs.Count == 1)
                {
                    PM_Bill_Supplies suppliesplan = rs.FirstOrDefault();
                    if (suppliesplan.BillStatus.IntValue != 2 && suppliesplan.BillStatus.IntValue != 3)
                    {
                        poundtrainmats.PlanNo = suppliesplan.PlanNo;
                        poundtrainmats.WagNo = suppliesplan.WagNo;
                        poundtrainmats.MaterialNo = suppliesplan.MaterialNo;
                        poundtrainmats.MaterialName = suppliesplan.MaterialName;
                        poundtrainmats.FromDeptNo = suppliesplan.FromDeptNo;
                        poundtrainmats.FromDeptName = suppliesplan.FromDeptName;
                        poundtrainmats.FromStoreNo = suppliesplan.FromStoreNo;
                        poundtrainmats.FromStoreName = suppliesplan.FromStoreName;
                        poundtrainmats.ToDeptNo = suppliesplan.ToDeptNo;
                        poundtrainmats.ToDeptName = suppliesplan.ToDeptName;
                        poundtrainmats.ToStoreNo = suppliesplan.ToStoreNo;
                        poundtrainmats.ToStoreName = suppliesplan.ToStoreName;
                        poundtrainmats.ShipNo = suppliesplan.ShipNo;
                        poundtrainmats.FromStation = suppliesplan.FromStation;
                        poundtrainmats.SerialNo = suppliesplan.SerialNo;
                        poundtrainmats.DeliveryNo = suppliesplan.DeliveryNo;
                        poundtrainmats.ContractNo = suppliesplan.ContractNo;
                        poundtrainmats.ProjectNo = suppliesplan.ProjectNo;
                        poundtrainmats.WayBillNo = suppliesplan.WayBillNo;
                        poundtrainmats.MarshallingNo = suppliesplan.MarshallingNo;
                        poundtrainmats.BusinessType = suppliesplan.BusinessType;
                        poundtrainmats.WeightType = suppliesplan.WeightType;
                        poundtrainmats.TareType = suppliesplan.TareType;
                        poundtrainmats.MoveStillType = suppliesplan.MoveStillType;
                        poundtrainmats.PlanLimitTime = suppliesplan.PlanLimitTime;
                        poundtrainmats.PondLimit = suppliesplan.PlanLimitTime;
                        poundtrainmats.PlanCreateUser = suppliesplan.CreateTime;
                        poundtrainmats.PlanCreateUser = suppliesplan.CreateUser;
                        poundtrainmats.Remark = suppliesplan.Remark;
                        poundtrainmats.CReserve1 = suppliesplan.CReserve1;
                        poundtrainmats.CReserve2 = suppliesplan.CReserve2;
                        poundtrainmats.CReserve3 = suppliesplan.CReserve3;
                        poundtrainmats.IReserve1 = suppliesplan.IReserve1;
                        poundtrainmats.IReserve2 = suppliesplan.IReserve2;
                        poundtrainmats.IReserve3 = suppliesplan.IReserve3;
                        poundtrainmats.UpLoadStatus = "N";
                        poundtrainmats.PlanStatus = "I";
                        poundtrainmats.PlanCreateUser = suppliesplan.CreateUser;
                        poundtrainmats.PlanCreateTime = suppliesplan.CreateTime;
                        poundtrainmats.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                        poundtrainmats.UpdateUser = SessionHelper.LogUserNickName;
                        //DateTime date = Convert.ToDateTime(poundtrainmats.GrossWgtTime);
                        //poundtrainmats.GrossWgtTime = CommonHelper.TimeToStr14(date);
                        //date = Convert.ToDateTime(poundtrainmats.TareWgtTime);
                        //poundtrainmats.TareWgtTime = CommonHelper.TimeToStr14(date);
                        var res = pondsuppliesService.ExecuteDB_UpdateSuppliesInfo(poundtrainmats);
                        suppliesplan.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                        suppliesplan.UpdateUser = SessionHelper.LogUserNickName;
                        var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(suppliesplan);
                    }
                }
                else if (rs.Count == 0)
                {
                    bl = false;
                    MessageDxUtil.ShowTips(poundtrainmats.WagNo + "车不存在计划!");
                }
                else
                {
                    bl = false;
                    MessageDxUtil.ShowTips(poundtrainmats.WagNo + "车存在多条计划，请手动匹配!");
                }
            }
            catch (Exception)
            {
                bl = false;
            }

            return bl;
        }
        private bool getPlan1(PM_RawData_MoveTrain rawData,List<string> list)
        {
            bool bl = true;
            try
            {
                var rs = suppliesService.ExecuteDB_QueryIronByCarNo(String.Format("'{0}'", rawData.CarNo));
                if (rs != null && rs.Count == 1)
                {
                    PM_Bill_Supplies suppliesplan = rs.FirstOrDefault();
                    mapping(rawData, suppliesplan);
                }
                else
                {
                    bl = false;
                    list.Add(rawData.CarNo);
                }
            }
            catch (Exception ex)
            {
                bl = false;
            }
            return bl;
        }

        private void mapping(PM_RawData_MoveTrain data,PM_Bill_Supplies supplies)
        {
            //DateTime beforDT = System.DateTime.Now;
            if (supplies.BillStatus.IntValue != 2 && supplies.BillStatus.IntValue != 3)
            {
                PM_Middle_SuppliesPond_Info middle = new PM_Middle_SuppliesPond_Info();
                PM_Standard_Tare_Info tare = new PM_Standard_Tare_Info();
                middle.GrossWgt = data.WeightData;
                DateTime date = Convert.ToDateTime(data.WeightTime);
                middle.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
                middle.GrossWgtMan = SessionHelper.LogUserNickName;
                middle.GrossWgtSiteNo = lue_SiteNo.EditValue.ToString();
                middle.GrossWgtSiteName = lue_SiteNo.Text;
                middle.TrainGroupGross = lue_FormationTag.Text;
                middle.PlanNo = supplies.PlanNo;
                middle.WagNo = supplies.WagNo;
                middle.MaterialNo = supplies.MaterialNo;
                middle.MaterialName = supplies.MaterialName;
                middle.FromDeptNo = supplies.FromDeptNo;
                middle.FromDeptName = supplies.FromDeptName;
                middle.FromStoreNo = supplies.FromStoreNo;
                middle.FromStoreName = supplies.FromStoreName;
                middle.ToDeptNo = supplies.ToDeptNo;
                middle.ToDeptName = supplies.ToDeptName;
                middle.ToStoreNo = supplies.ToStoreNo;
                middle.ToStoreName = supplies.ToStoreName;
                middle.ShipNo = supplies.ShipNo;
                middle.FromStation = supplies.FromStation;
                middle.SerialNo = supplies.SerialNo;
                middle.DeliveryNo = supplies.DeliveryNo;
                middle.ContractNo = supplies.ContractNo;
                middle.ProjectNo = supplies.ProjectNo;
                middle.WayBillNo = supplies.WayBillNo;
                middle.MarshallingNo = supplies.MarshallingNo;
                middle.BusinessType = supplies.BusinessType;
                middle.WeightType = supplies.WeightType;
                middle.TareType = supplies.TareType;
                middle.MoveStillType = supplies.MoveStillType;
                middle.PlanLimitTime = supplies.PlanLimitTime;
                middle.PondLimit = supplies.PlanLimitTime;
                middle.Remark = supplies.Remark;
                middle.PondRemark = "";
                middle.CReserve1 = supplies.CReserve1;
                middle.CReserve2 = supplies.CReserve2;
                middle.CReserve3 = supplies.CReserve3;
                middle.IReserve1 = supplies.IReserve1;
                middle.IReserve2 = supplies.IReserve2;
                middle.IReserve3 = supplies.IReserve3;
                middle.PlanCreateUser = supplies.CreateUser;
                middle.PlanCreateTime = supplies.CreateTime;
                middle.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
                middle.CreateUser = SessionHelper.LogUserNickName;
                middle.UpdateUser = SessionHelper.LogUserNickName;
                middle.DataFlag = new EntityInt(1);
                supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
                var re = tareService.ExecuteDB_QueryByCar(data.CarNo);
                if (re != null && re.Count > 0)
                {
                    tare = re.FirstOrDefault();
                    middle.TareWgt = tare.TareWgt;
                    middle.TareWgtTime = tare.TareTime;
                    middle.TareWgtMan = middle.GrossWgtMan;
                    middle.TareWgtSiteNo = middle.GrossWgtSiteNo;
                    middle.TareWgtSiteName = middle.GrossWgtSiteName;
                    middle.NetWgt = middle.GrossWgt - middle.TareWgt;
                    middle.TrainGroupTare = middle.TrainGroupGross;
                    middle.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                    supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                }
                var rw = middleService.ExecuteDB_InsertMiddleInfo(middle);
                supplies.UpdateUser = SessionHelper.LogUserNickName;
                var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);
                data.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.marked };
                data.UpdateUser = SessionHelper.LogUserName;
                var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(data);
                //DateTime afterDT = System.DateTime.Now;
                //TimeSpan ts = afterDT.Subtract(beforDT);
                //MessageDxUtil.ShowTips("这段代码总共花费:"+ts.TotalSeconds+"s");
            }
        }
        private void returnMiddle(PM_Middle_SuppliesPond_Info pondbill)
        {
            pondbill.DataFlag = new EntityInt(0);
            pondbill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.InvalidMeasure };
            pondbill.UpdateUser = SessionHelper.LogUserNickName;
            var rs = middleService.ExecuteDB_InvalidSuppliesMiddleByIntId(pondbill);
            if (rs is CustomDBError)
            {
                MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                return;
            }

            Hashtable ht1 = new Hashtable();
            ht1.Add("CarNo", pondbill.WagNo);
            ht1.Add("FormationTag", pondbill.TrainGroupGross);
            ht1.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.GrossWgtTime));
            IList<PM_RawData_MoveTrain> grossdata1 = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht1);
            for (int i = 0; i < grossdata1.Count; i++)
            {
                grossdata1[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                grossdata1[i].UpdateUser = SessionHelper.LogUserNickName;
                var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata1[i]);
            }
            var rss = suppliesService.ExecuteDB_QuerySuppliesByPlan(pondbill.PlanNo);
            if (rss.Count != 0)
            {
                PM_Bill_Supplies supplies = rss.FirstOrDefault();
                supplies.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.NoMeasure };
                supplies.UpdateUser = SessionHelper.LogUserNickName;
                var rw = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);
            }
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 查询过磅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                if (lue_FormationTag.EditValue == null)
                {
                    // MessageDxUtil.ShowTips("选择有效磅点！");
                    return;
                }
                formationtag = lue_FormationTag.Text;
                Hashtable condition = NewMethod();
                var list = rawdatamoveservice.ExecuteDB_QueryBytagdata(condition);
                gcl_main.DataSource = list;
                gvw_main.BestFitColumns();
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 作废过磅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zuofei_Click(object sender, EventArgs e)
        {
            try
            {
                gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                if (gvw_main.RowCount > 0)
                {
                    int[] rows = gvw_main.GetSelectedRows();
                    if (rows.Length != 0)
                    {
                        foreach (var rowNum in rows)
                        {
                            PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                            if (gvw_main.GetRowCellValue(rowNum, "TankNo") != null)
                            {
                                updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
                            }

                            updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.obsolete };
                            updateEntity.UpdateUser = SessionHelper.LogUserNickName;
                            var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
                            if (rs is CustomDBError)
                            {
                                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                            }
                        }
                        MessageDxUtil.ShowTips("已作废！");
                    }

                }
                btn_select_Click(null, null);
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }
        /// <summary>
        /// 视频连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shipin_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_shipin.Text == "视频连接")
                {
                    if (lue_SiteNo.EditValue != null)
                    {
                        pondSiteInfo = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                        if (pondSiteInfo != null)
                        {
                            VideoPlay();
                            btn_huifang.Enabled = false;
                            btn_start.Enabled = false;
                            btn_stop.Enabled = false;
                            btn_back.Enabled = false;
                        }
                        btn_shipin.Text = "中断连接";
                    }
                }
                else
                {
                    if (pondSiteInfo != null)
                    {
                        VideoStop();
                        btn_huifang.Enabled = true;
                        btn_start.Enabled = true;
                        btn_stop.Enabled = true;
                        btn_back.Enabled = true;
                    }
                    pondSiteInfo = null;
                    btn_shipin.Text = "视频连接";
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog("视频连接失败");
            }
        }

        #region
        /// <summary>
        /// 标记重车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_biaomao_Click(object sender, EventArgs e)
        {
            //var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否为毛重？");
            //if (yn == DialogResult.Yes)
            //{
            //    try
            //    {
            //        gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
            //        if (gvw_main.RowCount > 0)
            //        {
            //            int[] rows = gvw_main.GetSelectedRows();
            //            if (rows.Length != 0)
            //            {
            //                foreach (var rowNum in rows)
            //                {
            //                    PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
            //                    if (updateEntity.WeightData <= 60)
            //                    {
            //                        var zl = MessageDxUtil.ShowYesNoAndTips("本次有重量小于60！！！");
            //                        if (zl == DialogResult.No)
            //                        {
            //                            return;
            //                        }
            //                    }
            //                    if (updateEntity.CarNo == string.Empty)
            //                    {
            //                        var zl = MessageDxUtil.ShowYesNoAndTips("本次标记的数据存在车号为空!!!");
            //                        if (zl == DialogResult.No)
            //                        {
            //                            return;
            //                        }
            //                        break;
            //                    }
            //                    if (updateEntity.DataFlag.IntValue != 3)
            //                    {
            //                        if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
            //                        {
            //                            Hashtable ht = new Hashtable();
            //                            ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
            //                            var re = pondsuppliesService.ExecuteDB_QueryByDic(ht);
            //                            if (re != null && re.Count != 0)
            //                            {
            //                                PM_Pond_Bill_Supplies movedatamao = re.FirstOrDefault();
            //                                if (movedatamao.TareWgt!=0 && movedatamao.GrossWgt==0)
            //                                {
            //                                    movedatamao.GrossWgt = updateEntity.WeightData;
            //                                    DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
            //                                    movedatamao.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
            //                                    movedatamao.GrossWgtMan = SessionHelper.LogUserNickName;
            //                                    movedatamao.GrossWgtSiteNo = lue_SiteNo.EditValue.ToString();
            //                                    movedatamao.GrossWgtSiteName = lue_SiteNo.Text;
            //                                    movedatamao.UpdateUser = SessionHelper.LogUserNickName;
            //                                    movedatamao.TrainGroupGross = lue_FormationTag.Text;
            //                                    if (movedatamao.GrossWgt - movedatamao.TareWgt >= 0)
            //                                    {
            //                                        movedatamao.NetWgt = movedatamao.GrossWgt - movedatamao.TareWgt;
            //                                    }
            //                                    else
            //                                    {
            //                                        movedatamao.NetWgt = 0;
            //                                    }
            //                                    var rw = pondsuppliesService.ExecuteDB_UpdateSuppliesInfo(movedatamao);
            //                                    if (rw is CustomDBError)
            //                                    {
            //                                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rw).ErrorMsg);
            //                                    }
            //                                    bool bl = matchPlan(movedatamao);
            //                                    if (bl==false)
            //                                    {
            //                                        continue;
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    MessageDxUtil.ShowTips(gvw_main.GetRowCellValue(rowNum, "CarNo").ToString() + "车存在未完成过磅记录，请谨慎保存!");
            //                                    continue;
            //                                }
            //                            }
            //                            else
            //                            {
            //                                pondInfo = new PM_Pond_Bill_Supplies();
            //                                pondInfo.WagNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
            //                                pondInfo.GrossWgt = updateEntity.WeightData;
            //                                DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
            //                                pondInfo.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
            //                                pondInfo.GrossWgtMan = SessionHelper.LogUserNickName;
            //                                pondInfo.GrossWgtSiteNo = lue_SiteNo.EditValue.ToString();
            //                                pondInfo.GrossWgtSiteName = lue_SiteNo.Text;
            //                                pondInfo.CreateUser = SessionHelper.LogUserNickName;
            //                                pondInfo.UpdateUser = SessionHelper.LogUserNickName;
            //                                pondInfo.TrainGroupGross = lue_FormationTag.Text;
            //                                pondInfo.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
            //                                pondInfo.DataFlag = new EntityInt(1);
                                            
            //                                var rw = pondsuppliesService.ExecuteDB_InsertSuppliesInfo(pondInfo);
            //                            }
            //                        }
            //                        updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
            //                        updateEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.GrossActual };
            //                        updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
            //                        updateEntity.UpdateUser = SessionHelper.LogUserNickName;
            //                        var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
            //                        if (rs is CustomDBError)
            //                        {
            //                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
            //                        }
            //                    }
            //                }
            //            }
            //            MessageDxUtil.ShowTips("标记完成！");
            //        }
            //        else
            //        {
            //            MessageDxUtil.ShowTips("请先勾选要标记的数据");
            //        }

            //        btn_select_Click(null, null);
            //        getPond(lue_FormationTag.Text);
            //    }
            //    catch (Exception ep)
            //    {
            //        MessageDxUtil.ShowError(ep.Message);
            //    }

            //}
        }
        /// <summary>
        /// 标记空车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_biaopi_Click(object sender, EventArgs e)
        {
            //var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否为皮重？");
            //if (yn == DialogResult.Yes)
            //{
            //    try
            //    {
            //        gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
            //        if (gvw_main.RowCount > 0)
            //        {
            //            pondInfo = new PM_Pond_Bill_Supplies();
            //            int[] rows = gvw_main.GetSelectedRows();
            //            if (rows.Length != 0)
            //            {
            //                foreach (var rowNum in rows)
            //                {
            //                    PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
            //                    if (updateEntity.WeightData >= 60)
            //                    {
            //                        var zl = MessageDxUtil.ShowYesNoAndTips("本次有重量大于60！！！");
            //                        if (zl == DialogResult.No)
            //                        {
            //                            return;
            //                        }
            //                    }
            //                    if (updateEntity.CarNo == string.Empty)
            //                    {
            //                        var zl = MessageDxUtil.ShowYesNoAndTips("本次标记的数据存在车号为空!!!");
            //                        if (zl == DialogResult.No)
            //                        {
            //                            return;
            //                        }
            //                        break;
            //                    }
            //                    if (updateEntity.DataFlag.IntValue != 3)
            //                    {
            //                        if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
            //                        {

            //                            Hashtable ht = new Hashtable();
            //                            ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
            //                            var re = pondsuppliesService.ExecuteDB_QueryByDic(ht);
            //                            if (re != null && re.Count != 0)
            //                            {
            //                                PM_Pond_Bill_Supplies movedatamao = re.FirstOrDefault();
            //                                if (movedatamao.GrossWgt != 0 && movedatamao.TareWgt==0)
            //                                {
            //                                    movedatamao.TareWgt = updateEntity.WeightData;
            //                                    DateTime date1 = Convert.ToDateTime(updateEntity.WeightTime);
            //                                    movedatamao.TareWgtTime = date1.ToString("yyyyMMddHHmmss");
            //                                    movedatamao.TareWgtMan = SessionHelper.LogUserNickName;
            //                                    movedatamao.TareWgtSiteNo = lue_SiteNo.EditValue.ToString();
            //                                    movedatamao.TareWgtSiteName = lue_SiteNo.Text;
            //                                    movedatamao.UpdateUser = SessionHelper.LogUserNickName;
            //                                    movedatamao.TrainGroupTare = lue_FormationTag.Text;
            //                                    if (movedatamao.GrossWgt - movedatamao.TareWgt >= 0)
            //                                    {
            //                                        movedatamao.NetWgt = movedatamao.GrossWgt - movedatamao.TareWgt;
            //                                    }
            //                                    else
            //                                    {
            //                                        movedatamao.NetWgt = 0;
            //                                    }
            //                                    var rq = pondsuppliesService.ExecuteDB_UpdateSuppliesInfo(movedatamao);
            //                                    if (rq is CustomDBError)
            //                                    {
            //                                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rq).ErrorMsg);
            //                                    }
            //                                    bool bl= matchPlan(movedatamao);
            //                                    if (bl == false)
            //                                    {
            //                                        continue;
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    MessageDxUtil.ShowTips(gvw_main.GetRowCellValue(rowNum, "CarNo").ToString() + "车存在未完成过磅记录，请谨慎保存！");
            //                                    continue;
            //                                }
            //                            }
            //                            else
            //                            {
            //                                pondInfo.WagNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
            //                                pondInfo.TareWgt = updateEntity.WeightData;
            //                                DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
            //                                pondInfo.TareWgtTime = date.ToString("yyyyMMddHHmmss");
            //                                pondInfo.TareWgtMan = SessionHelper.LogUserNickName;
            //                                pondInfo.TareWgtSiteNo = lue_SiteNo.EditValue.ToString();
            //                                pondInfo.TareWgtSiteName = lue_SiteNo.Text;
            //                                pondInfo.CreateUser = SessionHelper.LogUserNickName;
            //                                pondInfo.UpdateUser = SessionHelper.LogUserNickName;
            //                                pondInfo.TrainGroupTare = lue_FormationTag.Text;
            //                                pondInfo.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
            //                                pondInfo.DataFlag = new EntityInt(1);
            //                                var rw = pondsuppliesService.ExecuteDB_InsertSuppliesInfo(pondInfo);
            //                                if (rw is CustomDBError)
            //                                {
            //                                    continue;
            //                                }
            //                            }
                                       
            //                        }
            //                        updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
            //                        updateEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.TareActual };
            //                        updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
            //                        updateEntity.UpdateUser = SessionHelper.LogUserNickName;
            //                        var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
            //                        if (rs is CustomDBError)
            //                        {
            //                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
            //                        }
            //                    }
            //                }
            //                MessageDxUtil.ShowTips("保存完成！");
            //            }
            //            else
            //            {
            //                MessageDxUtil.ShowTips("请先勾选要保存数据");
            //            }
            //        }
            //        btn_select_Click(null, null);
            //        getPond(lue_FormationTag.Text);
            //    }
            //    catch (Exception ep)
            //    {
            //        MessageDxUtil.ShowError(ep.Message);
            //    }
            //}
        }
        #endregion

        /// <summary>
        /// 回退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_return_Click(object sender, EventArgs e)
        {
            var huitui = MessageDxUtil.ShowYesNoAndTips("是否确定回退？");
            if (huitui == DialogResult.Yes)
            {
                int[] rows = gvw_pond.GetSelectedRows();
                if (rows.Length != 0)
                {
                    foreach (var rowNum in rows)
                    {
                        var pondbill = gvw_pond.GetRow(rowNum) as PM_Middle_SuppliesPond_Info;
                        returnMiddle(pondbill);
                        if (pondbill.BillStatus.IntValue == 3)
                        {
                            var re  = pondsuppliesService.ExecuteDB_QueryByPlanNo(pondbill.PlanNo);
                            if (re != null && re.Count!=0)
                            {
                                PM_Pond_Bill_Supplies supplies = re.FirstOrDefault();
                                supplies.DataFlag = new EntityInt(0);
                                supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.InvalidMeasure };
                                supplies.UpdateUser = SessionHelper.LogUserNickName;
                                supplies.PlanStatus = "D";
                                supplies.UpLoadStatus = "N";
                                var rs = pondsuppliesService.ExecuteDB_InvalidSuppliesPondByIntId(supplies);
                            }
                        }
                    }
                    MessageDxUtil.ShowTips("回退成功！");
                    btn_select_Click(null, null);
                    getPond(formationtag);
                }
                else
                {
                    MessageDxUtil.ShowTips("请勾选要回退的数据！");
                }
            }
        }
        /// <summary>
        /// 查询对应的计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qplan_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                string trainos;
                gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                if (gvw_main.RowCount > 0)
                {
                    int[] rows = gvw_main.GetSelectedRows();
                    if (rows.Length != 0)
                    {
                        foreach (var rowNum in rows)
                        {
                            rawData = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                            if (rawData.CarNo != string.Empty)
                            {
                                trainos = String.Format("'{0}'", rawData.CarNo);
                                list.Add(trainos);
                            }
                        }
                    }
                }
                string s = string.Join(",", list.ToArray());
                var carbills = suppliesService.ExecuteDB_QueryIronByCarNo(s);
                if (carbills.Count() < list.Count())
                {
                    MessageDxUtil.ShowError("计划条数与车辆数不匹配");
                }

                gcl_result.DataSource = carbills;
                gvw_result.BestFitColumns();
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 匹配计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pipei_Click(object sender, EventArgs e)
        {
            try
            {
                var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否确定匹配？");
                if (yn == DialogResult.Yes)
                {
                    if (gcl_result.DataSource == null)
                    {
                        btn_qplan_Click(null, null);
                    }
                    int[] rows = gvw_main.GetSelectedRows();
                    int[] row = gvw_result.GetSelectedRows();
                    if (rows.Length != 0 && row.Length!=0)
                    {
                        List<string> list1 = new List<string>();
                        foreach (var items in rows)
                        {
                            rawData = gvw_main.GetRow(items) as PM_RawData_MoveTrain;
                            foreach (var item in row)
                            {
                                PM_Bill_Supplies bill = gvw_result.GetRow(item) as PM_Bill_Supplies;
                                if (rawData.CarNo == bill.WagNo && rawData.DataFlag.IntValue != 2)
                                {
                                    mapping(rawData, bill);
                                }
                            }
                            string car = String.Format("'{0}'", rawData.CarNo);
                            list1.Add(car);
                        }
                        MessageDxUtil.ShowTips("匹配完成！");
                        string s = string.Join(",", list1.ToArray());
                        getPond(formationtag);
                        var iron = suppliesService.ExecuteDB_QueryIronByCarNo(s);
                        gcl_result.DataSource = iron;
                        gvw_result.BestFitColumns();
                        btn_select_Click(null, null);
                    }
                    else
                    {
                        MessageDxUtil.ShowError("请勾选要匹配的数据");
                    }
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                ht.Add("SiteNo", lue_SiteNo.EditValue);
            }
            lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);
        }
        private void PM_Bill_MoveTrain_Mats_Form_Load(object sender, EventArgs e)
        {
            //lue_SiteNo.Properties.DataSource = pondSiteInfoService.ExecuteDB_QueryByPoundType((int)PondType.PondDynamicMaterial);
            Settxt_poundsiteData();
            timer1.Start();
        }
        /// <summary>
        /// 保存原始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否确定保存？");
            if (yn == DialogResult.Yes)
            {
                try
                {
                    gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                    if (gvw_main.RowCount > 0)
                    {
                        List<string> list = new List<string>();
                        int[] rows = gvw_main.GetSelectedRows();
                        foreach (var row in rows)
                        {
                            PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(row) as PM_RawData_MoveTrain;
                            if (updateEntity.WeightData <= 30)
                            {
                                var zl = MessageDxUtil.ShowYesNoAndTips("本次有重量小于30！！！");
                                if (zl == DialogResult.No)
                                {
                                    continue;
                                }
                            }
                            if (updateEntity.CarNo == string.Empty)
                            {
                                var zl = MessageDxUtil.ShowYesNoAndTips("本次标记的数据存在车号为空!!!");
                                if (zl == DialogResult.No)
                                {
                                    return;
                                }
                                break;
                            }
                            if (updateEntity.DataFlag.IntValue!=2)
                            {
                                updateEntity.CarNo = gvw_main.GetRowCellValue(row, "CarNo").ToString();
                                updateEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.GrossActual };
                                updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                                updateEntity.UpdateUser = SessionHelper.LogUserName;
                                var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
                                getPlan1(updateEntity,list);
                            }
                        }
                        if (list.Count>0)
                        {
                            string s = string.Join(",", list.ToArray());
                            MessageDxUtil.ShowTips( s+ "车未正常匹配");
                            btn_qplan_Click(null, null);
                        }
                        else
                        {
                            MessageDxUtil.ShowTips("标记完成！");
                        }

                    }
                    btn_select_Click(null, null);
                    getPond(lue_FormationTag.Text);
                }
                catch (Exception)
                {
                }
            }
        }
        /// <summary>
        /// 保存皮重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_savepond_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否确定保存？");
            if (yn==DialogResult.Yes)
            {
                try
                {
                    gvw_pond.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                    if (gvw_pond.RowCount > 0)
                    {
                        int[] rows = gvw_pond.GetSelectedRows();
                        foreach (var row in rows)
                        {
                            PM_Middle_SuppliesPond_Info updateEntity = gvw_pond.GetRow(row) as PM_Middle_SuppliesPond_Info;
                            if (gvw_pond.GetRowCellValue(row, "TareWgt").ToString()!=string.Empty)
                            {
                                updateEntity.TareWgt = Convert.ToDecimal(gvw_pond.GetRowCellValue(row, "TareWgt").ToString());
                                DateTime date = Convert.ToDateTime(updateEntity.GrossWgtTime);
                                updateEntity.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
                                updateEntity.TareWgtTime = updateEntity.GrossWgtTime;
                                updateEntity.TareWgtMan = updateEntity.GrossWgtMan;
                                updateEntity.TareWgtSiteNo = updateEntity.GrossWgtSiteNo;
                                updateEntity.TareWgtSiteName = updateEntity.GrossWgtSiteName;
                                updateEntity.NetWgt = updateEntity.GrossWgt - updateEntity.TareWgt;
                                updateEntity.TrainGroupTare = updateEntity.TrainGroupGross;
                                updateEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                                updateEntity.UpdateUser = SessionHelper.LogUserNickName;
                                var rs = middleService.ExecuteDB_UpdateMiddleInfo(updateEntity);

                                var rss = suppliesService.ExecuteDB_QuerySuppliesByPlan(updateEntity.PlanNo);
                                if (rss.Count != 0)
                                {
                                    PM_Bill_Supplies supplies = rss.FirstOrDefault();
                                    supplies.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                                    supplies.UpdateUser = SessionHelper.LogUserNickName;
                                    var rw = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);
                                }

                                var re = tareService.ExecuteDB_QueryByCar(updateEntity.WagNo);

                                PM_Standard_Tare_Info tare = new PM_Standard_Tare_Info();
                                if (re.Count == 0)
                                {
                                    tare.TareWgt = updateEntity.TareWgt;
                                    tare.WagNo = updateEntity.WagNo;
                                    tare.TareTime = updateEntity.TareWgtTime;
                                    tare.IsUse = 1;
                                    tare.CreateUser = SessionHelper.LogUserNickName;
                                    tare.UpdateUser = SessionHelper.LogUserNickName;
                                    var rw = tareService.ExecuteDB_InsertTareInfo(tare);
                                }
                                else if(re.Count!=0 && re!=null)
                                {
                                    tare = re.FirstOrDefault();
                                    tare.TareWgt = updateEntity.TareWgt;
                                    tare.WagNo = updateEntity.WagNo;
                                    tare.TareTime = updateEntity.TareWgtTime;
                                    tare.IsUse = 1;
                                    tare.CreateUser = SessionHelper.LogUserNickName;
                                    tare.UpdateUser = SessionHelper.LogUserNickName;
                                    var rw = tareService.ExecuteDB_UpdateTareInfo(tare);
                                }
                            }
                        }
                    }
                    btn_select_Click(null, null);
                    getPond(lue_FormationTag.Text);
                }
                catch (Exception)
                {
                }
            }
        }
        private void gvw_main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Down}");
                SendKeys.Send("{F2}");
            }
        }
        private void gvw_pond_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Down}");
                SendKeys.Send("{F2}");
            }
        }
        /// <summary>
        /// 录像回放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_huifang_Click(object sender, EventArgs e)
        {
            if (_videoStatus == true)
            {
                VideoStop();
            }
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();

            if (m_bInitSDK == false)
            {
                MessageDxUtil.ShowTips("SDK加载失败！");
                return;
            }
            pondSiteInfo = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
            if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
            {
                SM_Dvr_Info dvr = dvrService.ExecuteDB_QueryAllByPondId(pondSiteInfo.IntId);
                if (dvr != null)
                {
                    m_lUserID = CHCNetSDK.NET_DVR_Login_V30(dvr.DvrIP1, 8000, dvr.Username, dvr.Password, ref m_struDeviceInfo);
                    if (m_lUserID == -1)
                    {
                        ShowTxtLog("硬盘录像机连接失败！");
                        return;
                    }

                    DateTime endTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(lue_FormationTag.Text).AddMinutes(MyNumberHelper.ConvertToInt32(c_min.Text));
                    DateTime startTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(lue_FormationTag.Text);

                    dateTimeStart.dwYear = (uint)startTime.Year;
                    dateTimeStart.dwMonth = (uint)startTime.Month;
                    dateTimeStart.dwDay = (uint)startTime.Day;
                    dateTimeStart.dwHour = (uint)startTime.Hour;
                    dateTimeStart.dwMinute = (uint)startTime.Minute;
                    dateTimeStart.dwSecond = (uint)startTime.Second;
                    //设置下载的结束时间 Set the stopping time
                    dateTimeEnd.dwYear = (uint)endTime.Year;
                    dateTimeEnd.dwMonth = (uint)endTime.Month;
                    dateTimeEnd.dwDay = (uint)endTime.Day;
                    dateTimeEnd.dwHour = (uint)endTime.Hour;
                    dateTimeEnd.dwMinute = (uint)endTime.Minute;
                    dateTimeEnd.dwSecond = (uint)endTime.Second;

                    if (lue_vedio.Text != "")
                    {
                        int a = 0;
                        switch (lue_vedio.Text)
                        {
                            case "视频1":
                                a = 33;
                                break;
                            case "视频2":
                                a = 34;
                                break;
                            case "视频3":
                                a = 35;
                                break;
                            case "视频4":
                                a = 36;
                                break;
                            default:
                                break;
                        }
                        m_lRealHandle1 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, a, ref dateTimeStart, ref dateTimeEnd, panelControl1.Handle);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 1, 0, ref lpOutValue);
                        lblVideo1.Visible = false;
                        panelControl1_DoubleClick(null, null);
                        btn_huifang.Enabled = false;
                        btn_shipin.Enabled = false;
                    }
                    else
                    {
                        m_lRealHandle1 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 33, ref dateTimeStart, ref dateTimeEnd, panelControl1.Handle);
                        m_lRealHandle2 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 34, ref dateTimeStart, ref dateTimeEnd, panelControl2.Handle);
                        m_lRealHandle3 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 35, ref dateTimeStart, ref dateTimeEnd, panelControl3.Handle);
                        m_lRealHandle4 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 36, ref dateTimeStart, ref dateTimeEnd, panelControl4.Handle);

                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 1, 0, ref lpOutValue);
                        lblVideo1.Visible = false;
                        lblVideo2.Visible = false;
                        lblVideo3.Visible = false;
                        lblVideo4.Visible = false;
                        lue_vedio.Enabled = false;
                        btn_huifang.Enabled = false;
                        btn_shipin.Enabled = false;
                    }

                }
            }
        }
        /// <summary>
        /// 开始/暂停播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (VideoStatus)
            {
                btn_start.Text = "播放";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 3, 0, ref lpOutValue);
            }
            else
            {
                btn_start.Text = "暂停";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 4, 0, ref lpOutValue);
            }
            VideoStatus = !VideoStatus;
        }
        /// <summary>
        /// 快进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_back_Click(object sender, EventArgs e)
        {
            if (_videoStatus2)
            {
                btn_back.Text = "正常";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 5, 0, ref lpOutValue);
                btn_start.Enabled = false;
            }
            else
            {
                btn_back.Text = "快进";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 7, 0, ref lpOutValue);
                btn_start.Enabled = true;
            }
            _videoStatus2 = !_videoStatus2;
        }
        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stop_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle1);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle2);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle3);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle4);
            CHCNetSDK.NET_DVR_Logout(m_lUserID);
            m_lRealHandle1 = m_lRealHandle2 = m_lRealHandle3 = m_lRealHandle4  = m_lUserID = -1;
            CHCNetSDK.NET_DVR_Cleanup();
            lblVideo1.Visible = true;
            lblVideo2.Visible = true;
            lblVideo3.Visible = true;
            lblVideo4.Visible = true;
            btn_huifang.Enabled = true;
            lue_vedio.Enabled = true;
            btn_shipin.Enabled = true;
        }

        private void panelControl1_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }

        private void panelControl2_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }

        private void panelControl3_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }
        private void panelControl4_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }
        #endregion

        #region 硬盘录像机
        private CHCNetSDK.NET_DVR_TIME dateTimeStart;
        private CHCNetSDK.NET_DVR_TIME dateTimeEnd;
        private CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        private bool VideoStatus = true;
        public bool _videoStatus2 = true;
        private IntPtr pUser;
        private Int32 m_lUserID = -1;
        private Int32 m_lUserID2 = -1;
        private Int32 m_lUserID3 = -1;
        private bool m_bInitSDK = false;

        private Int32 m_lRealHandle1 = -1;
        private Int32 m_lRealHandle2 = -1;
        private Int32 m_lRealHandle3 = -1;
        private Int32 m_lRealHandle4 = -1;
        private uint lpOutValue = 0;

        private bool _videoStatus = false;
        private Int32 _voiceCom = -1;
        private uint iLastErr = 0;
        private string str;

        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private int[] iChannelNum = new int[96];
        private List<Int32> realHandles = new List<Int32>();
        private Int32 realHandle7 = 0;
        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
            iChannelNum = new int[96];
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
            }
            else
            {
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (int i = 0; i < dwAChanTotalNum; i++)
                {
                    iChannelNum[i] = i + (int)m_struDeviceInfo.byStartChan;
                }

                byte byStreamType = 0;
                uint iDChanNum = 64;
                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;
                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;

                    dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[i].uGetStream);
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);

        }
        private void ShowTxtLog(string errStr)
        {
            errStr = String.Format("{0}  {1}{2}", DateTime.Now.ToLocalTime(), errStr, Environment.NewLine);
            synchronizationContext.Send(a =>
            {
                txtStatus.Text = errStr + txtStatus.Text;
                //txtStatus.SelectedText = errStr;
            }, null);

            //_voice.Speak(CutString(errStr));
        }
        public void VideoPlay()
        {
            try
            {
                if (!_videoStatus)
                {
                    _videoStatus = true;
                    m_bInitSDK = CHCNetSDK.NET_DVR_Init();

                    if (m_bInitSDK == false)
                    {
                        ShowTxtLog("SDK加载失败！");
                        return;
                    }
                    if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
                    {
                        SM_Dvr_Info dvr = dvrService.ExecuteDB_QueryAllByPondId(pondSiteInfo.IntId);
                        if (dvr != null)
                        {
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(dvr.DvrIP1, 8000, dvr.Username, dvr.Password, ref m_struDeviceInfo);

                            if (m_lUserID == -1)
                            {
                                ShowTxtLog("硬盘录像机连接失败！");
                                return;
                            }
                            else
                            {
                                dwAChanTotalNum = (uint)m_struDeviceInfo.byChanNum;
                                dwDChanTotalNum = (uint)m_struDeviceInfo.byIPChanNum + 256 * (uint)m_struDeviceInfo.byHighDChanNum;
                                InfoIPChannel();
                            }
                            List<LabelControl> labls = new List<LabelControl>();
                            labls.Add(lblVideo1);
                            labls.Add(lblVideo2);
                            labls.Add(lblVideo3);
                            labls.Add(lblVideo4);

                            List<PanelControl> pannels = new List<PanelControl>();
                            pannels.Add(panelControl1);
                            pannels.Add(panelControl2);
                            pannels.Add(panelControl3);
                            pannels.Add(panelControl4);

                            realHandles.Clear();
                            CHCNetSDK.NET_DVR_SetAudioMode(2);
                            for (int i = 0; i < pannels.Count; i++)
                            {
                                if (iChannelNum[i] > -1)
                                {
                                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                    lpPreviewInfo.lChannel = iChannelNum[i];//预览的设备通道 the device channel number

                                    lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数
                                    IntPtr pUser = IntPtr.Zero;//用户数据 user data 
                                    synchronizationContext.Send(a =>
                                    {
                                        lpPreviewInfo.hPlayWnd = pannels[i].Handle;//预览窗口 live view window
                                        int m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                        if (m_lRealHandle > -1)
                                        {
                                            realHandles.Add(m_lRealHandle);
                                            if (i < 2)
                                            {
                                                CHCNetSDK.NET_DVR_OpenSoundShare(m_lRealHandle);
                                                CHCNetSDK.NET_DVR_SetVolume_Card(m_lRealHandle, 0xffff);
                                            }
                                            labls[i].Visible = false;
                                        }

                                    }, null);
                                }
                            }
                            synchronizationContext.Send(a =>
                            {
                                btn_shipin.Text = @"关闭视频";
                            }, null);
                            //CHCNetSDK.VOICEDATACALLBACKV30 fVoiceDataCallBack = null;//打开对讲
                            //_voiceCom = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, 1, true, fVoiceDataCallBack, IntPtr.Zero);//打开对讲
                            //uint rsInt = CHCNetSDK.NET_DVR_GetLastError();
                            //if (rsInt != 0)
                            //{
                            //    ShowTxtLog("对讲失败" + rsInt);
                            //}
                            //if (_voiceCom == -1)
                            //{
                            //    ShowTxtLog("对讲通道被其他坐席所占，无法开启对讲通道！");
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void VideoStop()
        {
            synchronizationContext.Send(a =>
            {
                btn_shipin.Text = @"视频连接";
                _videoStatus = false;
                lblVideo1.Visible = true;
                lblVideo2.Visible = true;
                lblVideo3.Visible = true;
                lblVideo4.Visible = true;
                foreach (Int32 handel in realHandles)
                {
                    CHCNetSDK.NET_DVR_CloseSoundShare(handel);
                    CHCNetSDK.NET_DVR_StopRealPlay(handel);
                }
                CHCNetSDK.NET_DVR_StopVoiceCom(_voiceCom);
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                CHCNetSDK.NET_DVR_Cleanup();
                panelControl1.Invalidate();
                panelControl2.Invalidate();
                panelControl3.Invalidate();
                panelControl4.Invalidate();
            }, null);
        }


        #endregion

        private void gvw_pond_Click(object sender, EventArgs e)
        {
            middlePond = gvw_pond.GetFocusedRow() as PM_Middle_SuppliesPond_Info;
            string time="";
            DateTime dt;

            if (middlePond!=null)
            {
                if (middlePond.TareWgtTime != "" && middlePond.TareWgtTime != null)
                {
                    dt = Convert.ToDateTime(middlePond.TareWgtTime);
                    time = dt.ToString("yyyyMMddHHmmss");
                }
                
                IList<PM_Standard_Tare_Info> picList = tareService.ExecuteDB_QueryByCar(middlePond.WagNo).Where(x =>(x.TareTime == time)).ToList();
                if (picList != null && picList.Count != 0)
                {
                    Pic_Show(picList.Select(x => x.ImgURL).ToList());
                }
            }
        }
        public void Pic_Show(IList<string> list)
        {
            ClearPic();
            int count = list.Count;
            if (list != null)
            {
                for (int i = 0; i < count; i++)
                {
                    pictureEdit1.Visible = false;
                    MyFTPPictureHelper.ShowFTPPicture(pictureEdit1, list[i],IP);
                }
            }
        }
        public void ClearPic()
        {
            if (pictureEdit1.Image != null)
            {
                pictureEdit1.Image.Dispose();
            }
            pictureEdit1.Image = null;
        }

        private void searchLookUpEdit2View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string IsUse = searchLookUpEdit2View.GetRowCellValue(e.RowHandle, "IsUse").ToString();
            if (IsUse == "1")
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void searchLookUpEdit2View_Click(object sender, EventArgs e)
        {
            QueryForMovedataNum data = searchLookUpEdit2View.GetFocusedRow() as QueryForMovedataNum;

            if (data != null)
            {
                PM_RawData_MoveTrain rawData = new PM_RawData_MoveTrain();
                rawData.FormationTag = data.FormationTag;
                rawData.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = siteno };
                rawData.IsUse = 1;

                var re = rawdatamoveservice.ExecuteDB_UpdateRawDataUse(rawData);
            }
        }

        //
    }
}
