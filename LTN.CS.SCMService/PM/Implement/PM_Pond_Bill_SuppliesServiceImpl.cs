using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using LTN.CS.Core.Helper;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Pond_Bill_SuppliesServiceImpl : IPM_Pond_Bill_SuppliesService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryAll()
        {
            IList<PM_Pond_Bill_Supplies> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertSuppliesInfo(PM_Pond_Bill_Supplies pond)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Supplies", pond);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateSuppliesInfo(PM_Pond_Bill_Supplies pond)
        {
            object rs;
            try
            {
                //2022.4.25 李佳政
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];//获取IP
                PM_Pond_Bill_Supplies OldPondBill = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Supplies>("QueryBywgiston", pond.WgtlistNo);
                PM_Pond_Bill_Supplies_History HistoryPondBill = new PM_Pond_Bill_Supplies_History();
                SetBillValueToHistoryBill(OldPondBill, HistoryPondBill);
                HistoryPondBill.UpDateColumns = CompareHistoryBill(pond, OldPondBill);
                HistoryPondBill.UpDateHistoryTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                HistoryPondBill.UpDateHistoryUser = SessionHelper.LogUserNickName;
                HistoryPondBill.ComputerIp = ipAddr.ToString();
                //是否修改过数据到磅单历史表？更新此数据：插入新数据
                var IsExist = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies_History>("QueryPM_Pond_Bill_Supplies_History", HistoryPondBill.WgtlistNo);
                if (IsExist.Count != 0)
                {
                    CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Supplies_History", HistoryPondBill);
                }
                else
                {

                    CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Supplies_History", HistoryPondBill);
                }

                rs = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Supplies", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteSuppliesInfo(PM_Pond_Bill_Supplies pond)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_Pond_Bill_Supplies", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InvalidSuppliesPondByIntId(PM_Pond_Bill_Supplies pond)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_SuppliesStatus", pond);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QuerySuppliesPondByHashTable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Supplies> result;
            /*
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesByCond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
             * */
            //修改
            if (string.Equals(ht["isSelected"].ToString(), "Y"))
            {
                try
                {
                    result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesByCond_updateTime", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    result = null;
                }
            }
            else
            {
                try
                {
                    //result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesByCond", ht);
                    result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesByCond2", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    result = null;
                }
            }
            return result;
        }

        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByDic(Hashtable dic)
        {
            IList<PM_Pond_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesbyDic", dic);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByGroup(string FormationTag)
        {
            IList<PM_Pond_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesbyGroup", FormationTag);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByPlanNo(string planNo)
        {
            IList<PM_Pond_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("selectPM_Pond_Bill_SuppliesbyPlanNo", planNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByPond(Hashtable ht)
        {
            IList<PM_Pond_Bill_Supplies> result;
            try
            {
                //result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("Select_LatestByPond", ht);


                //result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("Select_LatestByPond2", ht);
                if (ht["isChecked"].ToString() == "N")
                {
                    result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("Select_LatestByPond2", ht);
                    /*
                     * 修改,按照委托创建时间来排序
                     result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("Select_LatestByPond4", ht);
                     */

                }
                else
                {
                    result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies>("Select_LatestByPond3", ht);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public PM_Pond_Bill_Supplies ExecuteDB_QueryByWgistonNo(string wgiston)
        {
            PM_Pond_Bill_Supplies result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Supplies>("QueryBywgiston", wgiston);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_UpdatePrint1(PM_Pond_Bill_Supplies TruckBill)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdateByPrint", TruckBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        
        //新增物资轨道衡磅单批量修改
        public object ExecuteDB_BatchUpdateSuppliesBill(List<string> SuppliesBillWgtNos, Hashtable ht)
        {
            object result = null;
            try
            {
                string FromDeptName = ht["FromDeptName"].ToString();
                string ToDeptName = ht["ToDeptName"].ToString();
                string ContractNo = ht["ContractNo"].ToString();                
                string Remark = ht["Remark"].ToString();
                string PondRemark = ht["PondRemark"].ToString();
                string MaterialName = ht["MaterialName"].ToString();
                string MaterialNo = ht["MaterialNo"].ToString();

                foreach (string suppliesBillWgtNo in SuppliesBillWgtNos)
                {
                    PM_Pond_Bill_Supplies suppliesBill = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Supplies>("QueryBywgiston", suppliesBillWgtNo);
                    if (!string.IsNullOrEmpty(FromDeptName))
                    {
                        suppliesBill.FromDeptName = FromDeptName;
                    }
                    if (!string.IsNullOrEmpty(ToDeptName))
                    {
                        suppliesBill.ToDeptName = ToDeptName;
                    }
                    if (!string.IsNullOrEmpty(ContractNo))
                    {
                        suppliesBill.ContractNo = ContractNo;
                    }
                    if (!string.IsNullOrEmpty(Remark))
                    {
                        suppliesBill.Remark = Remark;
                    }
                    if (!string.IsNullOrEmpty(PondRemark))
                    {
                        suppliesBill.PondRemark = PondRemark;
                    }
                    if (!string.IsNullOrEmpty(MaterialName))
                    {
                        suppliesBill.MaterialName = MaterialName;
                    }
                    if (!string.IsNullOrEmpty(MaterialNo))
                    {
                        suppliesBill.MaterialNo = MaterialNo;
                    }                    
                    if (suppliesBill.BillStatus.IntValue == 3)
                    {
                        suppliesBill.PlanStatus = "D";
                    }
                    else if (suppliesBill.UpLoadStatus.ToString() == "Y")
                    {
                        suppliesBill.PlanStatus = "U";
                    }
                    suppliesBill.UpLoadStatus = "N";
                    suppliesBill.UpdateUser = SessionHelper.LogUserNickName;
                    suppliesBill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    result = ExecuteDB_UpdateSuppliesInfo(suppliesBill);
                    if (result == null)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        //2022.4.25 李佳政
        public void SetBillValueToHistoryBill(PM_Pond_Bill_Supplies _OldPondBill, PM_Pond_Bill_Supplies_History _HistoryPondBill)
        {
            _HistoryPondBill.PlanNo = _OldPondBill.PlanNo;
            _HistoryPondBill.WagNo = _OldPondBill.WagNo;
            _HistoryPondBill.MaterialNo = _OldPondBill.MaterialNo;
            _HistoryPondBill.MaterialName = _OldPondBill.MaterialName;
            _HistoryPondBill.FromDeptNo = _OldPondBill.FromDeptNo;
            _HistoryPondBill.FromDeptName = _OldPondBill.FromDeptName;
            _HistoryPondBill.FromStoreNo = _OldPondBill.FromStoreNo;
            _HistoryPondBill.FromStoreName = _OldPondBill.FromStoreName;
            _HistoryPondBill.ToDeptNo = _OldPondBill.ToDeptNo;
            _HistoryPondBill.ToDeptName = _OldPondBill.ToDeptName;
            _HistoryPondBill.ToStoreNo = _OldPondBill.ToStoreNo;
            _HistoryPondBill.ToStoreName = _OldPondBill.ToStoreName;
            _HistoryPondBill.ShipNo = _OldPondBill.ShipNo;
            _HistoryPondBill.FromStation = _OldPondBill.FromStation;
            _HistoryPondBill.SerialNo = _OldPondBill.SerialNo;
            _HistoryPondBill.DeliveryNo = _OldPondBill.DeliveryNo;
            _HistoryPondBill.ContractNo = _OldPondBill.ContractNo;
            _HistoryPondBill.ProjectNo = _OldPondBill.ProjectNo;
            _HistoryPondBill.WayBillNo = _OldPondBill.WayBillNo;
            _HistoryPondBill.MarshallingNo = _OldPondBill.MarshallingNo;
            _HistoryPondBill.BusinessType = _OldPondBill.BusinessType;
            _HistoryPondBill.WeightType = _OldPondBill.WeightType;
            _HistoryPondBill.TareType = _OldPondBill.TareType;
            _HistoryPondBill.MoveStillType = _OldPondBill.MoveStillType;
            _HistoryPondBill.PlanLimitTime = _OldPondBill.PlanLimitTime;
            _HistoryPondBill.PondLimit = _OldPondBill.PondLimit;
            _HistoryPondBill.Remark = _OldPondBill.Remark;
            _HistoryPondBill.CReserve1 = _OldPondBill.CReserve1;
            _HistoryPondBill.CReserve2 = _OldPondBill.CReserve2;
            _HistoryPondBill.CReserve3 = _OldPondBill.CReserve3;
            _HistoryPondBill.IReserve1 = _OldPondBill.IReserve1;
            _HistoryPondBill.IReserve2 = _OldPondBill.IReserve2;
            _HistoryPondBill.IReserve3 = _OldPondBill.IReserve3;
            _HistoryPondBill.PlanCreateUser = _OldPondBill.PlanCreateUser;
            _HistoryPondBill.PlanCreateTime = _OldPondBill.PlanCreateTime;
            _HistoryPondBill.IntId = _OldPondBill.IntId;
            _HistoryPondBill.WgtlistNo = _OldPondBill.WgtlistNo;
            _HistoryPondBill.GrossWgt = _OldPondBill.GrossWgt;
            _HistoryPondBill.TareWgt = _OldPondBill.TareWgt;
            _HistoryPondBill.NetWgt = _OldPondBill.NetWgt;
            _HistoryPondBill.GrossWgtTime = _OldPondBill.GrossWgtTime;
            _HistoryPondBill.TareWgtTime = _OldPondBill.TareWgtTime;
            _HistoryPondBill.NetWgtTime = _OldPondBill.NetWgtTime;
            _HistoryPondBill.GrossWgtSiteNo = _OldPondBill.GrossWgtSiteNo;
            _HistoryPondBill.GrossWgtSiteName = _OldPondBill.GrossWgtSiteName;
            _HistoryPondBill.TareWgtSiteNo = _OldPondBill.TareWgtSiteNo;
            _HistoryPondBill.TareWgtSiteName = _OldPondBill.TareWgtSiteName;
            _HistoryPondBill.GrossWgtMan = _OldPondBill.GrossWgtMan;
            _HistoryPondBill.TareWgtMan = _OldPondBill.TareWgtMan;
            _HistoryPondBill.PondRemark = _OldPondBill.PondRemark;
            _HistoryPondBill.CReserveFlag1 = _OldPondBill.CReserveFlag1;
            _HistoryPondBill.CReserveFlag2 = _OldPondBill.CReserveFlag2;
            _HistoryPondBill.CReserveFlag3 = _OldPondBill.CReserveFlag3;
            _HistoryPondBill.IReserveFlag1 = _OldPondBill.IReserveFlag1;
            _HistoryPondBill.IReserveFlag2 = _OldPondBill.IReserveFlag2;
            _HistoryPondBill.IReserveFlag3 = _OldPondBill.IReserveFlag3;
            _HistoryPondBill.CreateUser = _OldPondBill.CreateUser;
            _HistoryPondBill.CreateTime = _OldPondBill.CreateTime;
            _HistoryPondBill.UpdateUser = _OldPondBill.UpdateUser;
            _HistoryPondBill.UpdateTime = _OldPondBill.UpdateTime;
            _HistoryPondBill.DataFlag = _OldPondBill.DataFlag;
            _HistoryPondBill.BillStatus = _OldPondBill.BillStatus;
            _HistoryPondBill.TrainGroupGross = _OldPondBill.TrainGroupGross;
            _HistoryPondBill.TrainGroupTare = _OldPondBill.TrainGroupTare;
            _HistoryPondBill.PlanStatus = _OldPondBill.PlanStatus;
            _HistoryPondBill.UpLoadStatus = _OldPondBill.UpLoadStatus;
            _HistoryPondBill.PrintNum = _OldPondBill.PrintNum;



        }
        //2022.4.25 李佳政
        public string CompareHistoryBill(PM_Pond_Bill_Supplies pond, PM_Pond_Bill_Supplies OldPondBill)
        {
            string Columns = string.Empty;
            Type t1 = pond.GetType();
            Type t2 = OldPondBill.GetType();
            System.Reflection.PropertyInfo[] properties1 = t1.GetProperties();
            System.Reflection.PropertyInfo[] properties2 = t2.GetProperties();
            for (int i = 0; i < properties1.Length; i++)
            {
                if (properties1[i].GetValue(pond, null) == null && properties2[i].GetValue(OldPondBill, null) == null)
                {
                    continue;
                }
                else if (properties1[i].Name == "CreateTime")//过滤此字段
                {
                    continue;
                }

                else if (properties1[i].GetValue(pond, null) == null || properties2[i].GetValue(OldPondBill, null) == null)
                {
                    object p1 = properties1[i].GetValue(pond, null);
                    object p2 = properties2[i].GetValue(OldPondBill, null);
                    string StrValue1 = string.Empty;
                    string StrValue2 = string.Empty;
                    if (p1 != null)
                    {
                        StrValue1 = p1.ToString();
                    }
                    if (p2 != null)
                    {
                        StrValue2 = p2.ToString();
                    }
                    if (!string.IsNullOrEmpty(StrValue1) || !string.IsNullOrEmpty(StrValue2))
                    {
                        Columns += properties1[i].Name.ToString() + "&" + p1 + "‖";
                        continue;
                    }
                }
                else if (properties1[i].GetValue(pond, null).ToString() != properties2[i].GetValue(OldPondBill, null).ToString())
                {
                    object p1 = properties1[i].GetValue(pond, null);
                    object p2 = properties2[i].GetValue(OldPondBill, null);
                    Columns += properties1[i].Name.ToString() + "&" + p1 + "‖";
                }


            }
            return Columns;

        }
    }
}
