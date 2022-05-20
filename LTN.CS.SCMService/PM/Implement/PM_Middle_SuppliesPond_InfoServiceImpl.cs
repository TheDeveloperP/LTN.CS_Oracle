using IBatisNet.Common.Logging;
using LTN.CS.Base.Common;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Middle_SuppliesPond_InfoServiceImpl: IPM_Middle_SuppliesPond_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertMiddleInfo(PM_Middle_SuppliesPond_Info Middle)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Middle_SuppliesPond_Info", Middle);
                if (rs == null)
                {
                    rs = 1;
                }
                CreatePond(Middle);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateMiddleInfo(PM_Middle_SuppliesPond_Info Middle)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("UpdatePM_Middle_SuppliesPond_Info", Middle);
                CreatePond(Middle);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public IList<PM_Middle_SuppliesPond_Info> ExecuteDB_QueryByGroup(Hashtable ht)
        {
            IList<PM_Middle_SuppliesPond_Info> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Middle_SuppliesPond_Info>("selectPM_Middle_SuppliesPond_InfobyGroup", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        private void CreatePond(PM_Middle_SuppliesPond_Info Middle)
        {
            var rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesbyPlanNo", Middle.PlanNo);
            PM_Pond_Bill_Supplies supplies = new PM_Pond_Bill_Supplies();
            if (rs != null && rs.Count != 0)
            {
                supplies = rs.FirstOrDefault();
                if (Middle.TareWgt != 0)
                {
                    if (supplies.UpLoadStatus == "Y")
                    {
                        supplies.PlanStatus = "U";
                    }
                    else
                    {
                        supplies.PlanStatus = "I";
                    }
                    supplies.UpLoadStatus = "N";
                    supplies.GrossWgt = Middle.GrossWgt;
                    supplies.TareWgt = Middle.TareWgt;
                    supplies.NetWgt = Middle.NetWgt;
                    supplies.GrossWgtTime = Middle.GrossWgtTime;
                    supplies.TareWgtTime = Middle.TareWgtTime;
                    supplies.GrossWgtMan = Middle.GrossWgtMan;
                    supplies.TareWgtMan = Middle.TareWgtMan;
                    supplies.GrossWgtSiteNo = Middle.GrossWgtSiteNo;
                    supplies.GrossWgtSiteName = Middle.GrossWgtSiteName;
                    supplies.TareWgtSiteNo = Middle.TareWgtSiteNo;
                    supplies.TareWgtSiteName = Middle.TareWgtSiteName;
                    supplies.TrainGroupGross = Middle.TrainGroupGross;
                    supplies.TrainGroupTare = Middle.TrainGroupTare;
                    supplies.PlanNo = Middle.PlanNo;
                    supplies.WagNo = Middle.WagNo;
                    supplies.MaterialNo = Middle.MaterialNo;
                    supplies.MaterialName = Middle.MaterialName;
                    supplies.FromDeptNo = Middle.FromDeptNo;
                    supplies.FromDeptName = Middle.FromDeptName;
                    supplies.FromStoreNo = Middle.FromStoreNo;
                    supplies.FromStoreName = Middle.FromStoreName;
                    supplies.ToDeptNo = Middle.ToDeptNo;
                    supplies.ToDeptName = Middle.ToDeptName;
                    supplies.ToStoreNo = Middle.ToStoreNo;
                    supplies.ToStoreName = Middle.ToStoreName;
                    supplies.ShipNo = Middle.ShipNo;
                    supplies.FromStation = Middle.FromStation;
                    supplies.SerialNo = Middle.SerialNo;
                    supplies.DeliveryNo = Middle.DeliveryNo;
                    supplies.ContractNo = Middle.ContractNo;
                    supplies.ProjectNo = Middle.ProjectNo;
                    supplies.WayBillNo = Middle.WayBillNo;
                    supplies.MarshallingNo = Middle.MarshallingNo;
                    supplies.BusinessType = Middle.BusinessType;
                    supplies.WeightType = Middle.WeightType;
                    supplies.TareType = Middle.TareType;
                    supplies.MoveStillType = Middle.MoveStillType;
                    supplies.PlanLimitTime = Middle.PlanLimitTime;
                    supplies.PondLimit = Middle.PlanLimitTime;
                    supplies.Remark = Middle.Remark;
                    supplies.PondRemark = Middle.PondRemark;
                    supplies.CReserve1 = Middle.CReserve1;
                    supplies.CReserve2 = Middle.CReserve2;
                    supplies.CReserve3 = Middle.CReserve3;
                    supplies.IReserve1 = Middle.IReserve1;
                    supplies.IReserve2 = Middle.IReserve2;
                    supplies.IReserve3 = Middle.IReserve3;
                    supplies.PlanCreateUser = Middle.CreateUser;
                    supplies.PlanCreateTime = Middle.CreateTime;
                    supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                    supplies.CreateUser = Middle.CreateUser;
                    supplies.UpdateUser = Middle.UpdateUser;
                    supplies.DataFlag = Middle.DataFlag;
                    var rw = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Supplies", supplies);
                }
            }
            else
            {
                supplies.GrossWgt = Middle.GrossWgt;
                supplies.TareWgt = Middle.TareWgt;
                supplies.NetWgt = Middle.NetWgt;
                supplies.GrossWgtTime = Middle.GrossWgtTime;
                supplies.TareWgtTime = Middle.TareWgtTime;
                supplies.GrossWgtMan = Middle.GrossWgtMan;
                supplies.TareWgtMan = Middle.TareWgtMan;
                supplies.GrossWgtSiteNo = Middle.GrossWgtSiteNo;
                supplies.GrossWgtSiteName = Middle.GrossWgtSiteName;
                supplies.TareWgtSiteNo = Middle.TareWgtSiteNo;
                supplies.TareWgtSiteName = Middle.TareWgtSiteName;
                supplies.TrainGroupGross = Middle.TrainGroupGross;
                supplies.TrainGroupTare = Middle.TrainGroupTare;
                supplies.PlanNo = Middle.PlanNo;
                supplies.WagNo = Middle.WagNo;
                supplies.MaterialNo = Middle.MaterialNo;
                supplies.MaterialName = Middle.MaterialName;
                supplies.FromDeptNo = Middle.FromDeptNo;
                supplies.FromDeptName = Middle.FromDeptName;
                supplies.FromStoreNo = Middle.FromStoreNo;
                supplies.FromStoreName = Middle.FromStoreName;
                supplies.ToDeptNo = Middle.ToDeptNo;
                supplies.ToDeptName = Middle.ToDeptName;
                supplies.ToStoreNo = Middle.ToStoreNo;
                supplies.ToStoreName = Middle.ToStoreName;
                supplies.ShipNo = Middle.ShipNo;
                supplies.FromStation = Middle.FromStation;
                supplies.SerialNo = Middle.SerialNo;
                supplies.DeliveryNo = Middle.DeliveryNo;
                supplies.ContractNo = Middle.ContractNo;
                supplies.ProjectNo = Middle.ProjectNo;
                supplies.WayBillNo = Middle.WayBillNo;
                supplies.MarshallingNo = Middle.MarshallingNo;
                supplies.BusinessType = Middle.BusinessType;
                supplies.WeightType = Middle.WeightType;
                supplies.TareType = Middle.TareType;
                supplies.MoveStillType = Middle.MoveStillType;
                supplies.PlanLimitTime = Middle.PlanLimitTime;
                supplies.PondLimit = Middle.PlanLimitTime;
                supplies.Remark = Middle.Remark;
                supplies.PondRemark = Middle.PondRemark;
                supplies.CReserve1 = Middle.CReserve1;
                supplies.CReserve2 = Middle.CReserve2;
                supplies.CReserve3 = Middle.CReserve3;
                supplies.IReserve1 = Middle.IReserve1;
                supplies.IReserve2 = Middle.IReserve2;
                supplies.IReserve3 = Middle.IReserve3;
                supplies.PlanCreateUser = Middle.CreateUser;
                supplies.PlanCreateTime = Middle.CreateTime;
                supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                supplies.CreateUser = Middle.CreateUser;
                supplies.UpdateUser = Middle.UpdateUser;
                supplies.DataFlag = Middle.DataFlag;
                supplies.UpLoadStatus = "N";
                supplies.PlanStatus = "I";
                var re = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Supplies", supplies);
            }
        }

        public object ExecuteDB_InvalidSuppliesMiddleByIntId(PM_Middle_SuppliesPond_Info Middle)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Middle_SuppliesPond_InfoStatus", Middle);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
    }
}
