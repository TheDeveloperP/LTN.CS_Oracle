using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PT;
using LTN.CS.Core.Common;
using LTN.CS.SCMEntities.Enum;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMEntities.SM;
using LTN.CS.Core.Helper;
using System.Net;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_TruckServiceImpl : IPM_Bill_TruckService
    {
        public ICommonDao CommonDao { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertPM_Bill_Truck(PM_Bill_Truck TruckBill)
        {
            object result;
            try
            {
                //string value = "9999" + DateTime.Now.ToString("yyMMdd") + "%";
                //string MaxNo = CommonDao.ExecuteQueryForObject<string>("QueryTruckBillForCreateBillNo", value);
                //if (string.IsNullOrEmpty(MaxNo))
                //{
                //    MaxNo = "9999" + DateTime.Now.ToString("yyMMdd") + "0000";
                //}
                //Int64 BillNo = Int64.Parse(MaxNo) + 1;
                //TruckBill.C_WGTLISTNO = BillNo.ToString();
                ////TruckBill.C_BARCODENO = BillNo.ToString().Substring(2);
                //TruckBill.C_BARCODENO = string.Empty; ;
                result = CommonDao.ExecuteInsert("Insert_PM_Bill_Truck", TruckBill);  
                //result = CommonDao.ExecuteInsert("Insert_PM_Bill_Truck_New", TruckBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InsertPM_Bill_Truck2(PM_Bill_Truck TruckBill,bool isUpdate,PM_Bill_Truck TruckBill2)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteInsert("Insert_PM_Bill_Truck2", TruckBill);

                if (TruckBill.C_BILLSTATE == PLANSTATE.已完成)
                { 
                    //修改计划委托状态为已完成
                    PT_TruckMeasurePlan planMeasure = new PT_TruckMeasurePlan();
                    planMeasure.C_PLANNO = TruckBill.C_PLANNO;
                    planMeasure.C_PLANSTATE = PLANSTATE.已完成;
                    result = CommonDao.ExecuteUpdate("UpdateStatTruckMeasurePlanByPlanNo", planMeasure);
                    //修改皮重最新为已完成
                    SM_TareWeight tareWeight = new SM_TareWeight();
                    tareWeight.CarName = TruckBill.C_CARNAME;
                    tareWeight.IsUsed = new EntityInt() { EntityValue = 1 };
                    result = CommonDao.ExecuteUpdate("UpdateSM_TareWeightByCarNo3", tareWeight);
                }
                //if (isUpdate)
                //{
                //    if (TruckBill2 != null)
                //    {
                //        TruckBill2.I_REPEATFLAG = 1;
                //    }
                //    //已选用第二条毛重，将第一条毛重改为复磅标志
                //    result=CommonDao.ExecuteUpdate("UpdatePM_Bill_TruckByWgListNo", TruckBill2);
                //}
            }
            catch (Exception ex)
            {
                result = new CustomDBError(ex.Message);
            }
            return result;
        }

        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByHashtable(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_PM_Bill_TruckByHashTable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        public IList<PM_Bill_Truck> ExecuteDB_QueryLatestPM_Bill_TruckByCarNo(string carNo)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByCarNo", carNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPond(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                //result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPond", ht);
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPond3", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForAFourOne(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPondAFourOne", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForAFourTwo(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPondAFourTwo", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPond2(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPond2", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// 根据车号查询未完成磅单
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByCarNo(string ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_PM_Bill_TruckByCarNo", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByCarNo2(string ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_PM_Bill_TruckByCarNo2", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public PM_Bill_Truck ExecuteDB_QueryBillTruckByPlanNo(Hashtable PlanNo)
        {
            PM_Bill_Truck result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("QueryBillTruckByCarNoAndPlanNo", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public PM_Bill_Truck ExecuteDB_QueryBillTruckByWgistonNo(string wgiston)
        {
            PM_Bill_Truck result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("QueryBillTruckBywgiston", wgiston);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_UpdatePM_Bill_Truck(PM_Bill_Truck TruckBill)
        {
            object result;
             
            try
            {
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                PM_Bill_Truck OldTruckBill = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("QueryBillTruckBywgiston", TruckBill.C_WGTLISTNO);
                PM_Bill_Truck_History HistoryTruckBill= new PM_Bill_Truck_History();
                SetBillValueToHistoryBill(OldTruckBill, HistoryTruckBill);
                HistoryTruckBill.C_UPDATECOLUMNS = CompareTruckBill(TruckBill,OldTruckBill);
                HistoryTruckBill.C_UPDATEHISTORYTIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                HistoryTruckBill.C_UPDATEHISTORYUSER = SessionHelper.LogUserNickName;
                HistoryTruckBill.C_COMPUTERIP = ipAddr.ToString();
                //插入修改前数据到历史表
                CommonDao.ExecuteInsert("Insert_PM_Bill_Truck_History",HistoryTruckBill);
                result = CommonDao.ExecuteUpdate("Update_PM_Bill_Truck", TruckBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 获取修改前后磅单数据不同的字段
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <param name="OldTruckBill"></param>
        /// <returns></returns>
        public string CompareTruckBill(PM_Bill_Truck TruckBill, PM_Bill_Truck OldTruckBill)
        {
            string Columns = string.Empty;
            Type t1 = TruckBill.GetType();
            Type t2 = OldTruckBill.GetType();
            System.Reflection.PropertyInfo[] properties1 = t1.GetProperties();
            System.Reflection.PropertyInfo[] properties2 = t2.GetProperties();
            for(int i=0; i<properties1.Length;i++)
            {
                if (properties1[i].GetValue(TruckBill, null) == null && properties2[i].GetValue(OldTruckBill, null) == null)
                {
                    continue;   
                }
                else if (properties1[i].GetValue(TruckBill, null) == null || properties2[i].GetValue(OldTruckBill, null) == null)
                {
                    object p1 = properties1[i].GetValue(TruckBill, null);
                    object p2 = properties2[i].GetValue(OldTruckBill, null);
                    string StrValue1 = string.Empty;
                    string StrValue2 = string.Empty;
                    if (p1 != null)
                    {
                        StrValue1 = p1.ToString();
                    }
                    if (p2!= null)
                    {
                        StrValue2 = p2.ToString();
                    }

                    if (!string.IsNullOrEmpty(StrValue1) || !string.IsNullOrEmpty(StrValue2))
                    {
                        Columns += properties1[i].Name.ToString() + "|";
                        continue;
                    }
                }
                else if (properties1[i].GetValue(TruckBill, null).ToString() != properties2[i].GetValue(OldTruckBill, null).ToString())
                {
                    object p1 = properties1[i].GetValue(TruckBill, null);
                    object p2 = properties2[i].GetValue(OldTruckBill, null);
                    Columns += properties1[i].Name.ToString() + "|";
                }

            }
            return Columns;

        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="Columns"></param>
        public void SetBillValueToHistoryBill(PM_Bill_Truck _OldTruckBill, PM_Bill_Truck_History _HistoryTruckBill)
        {
            _HistoryTruckBill.I_INTID = _OldTruckBill.I_INTID;
            _HistoryTruckBill.C_PLANNO = _OldTruckBill.C_PLANNO;
            _HistoryTruckBill.C_CARNO = _OldTruckBill.C_CARNO;
            _HistoryTruckBill.C_CARNAME = _OldTruckBill.C_CARNAME;
            _HistoryTruckBill.C_MATERIALNO = _OldTruckBill.C_MATERIALNO;
            _HistoryTruckBill.C_MATERIALNAME = _OldTruckBill.C_MATERIALNAME;
            _HistoryTruckBill.C_FROMDEPTNO = _OldTruckBill.C_FROMDEPTNO;
            _HistoryTruckBill.C_FROMDEPTNAME = _OldTruckBill.C_FROMDEPTNAME;
            _HistoryTruckBill.C_FROMSTORENO = _OldTruckBill.C_FROMSTORENO;
            _HistoryTruckBill.C_FROMSTORENAME = _OldTruckBill.C_FROMSTORENAME;
            _HistoryTruckBill.C_TODEPTNO = _OldTruckBill.C_TODEPTNO;
            _HistoryTruckBill.C_TODEPTNAME = _OldTruckBill.C_TODEPTNAME;
            _HistoryTruckBill.C_TOSTORENO = _OldTruckBill.C_TOSTORENO;
            _HistoryTruckBill.C_TOSTORENAME = _OldTruckBill.C_TOSTORENAME;
            _HistoryTruckBill.I_BUSINESSTYPE = _OldTruckBill.I_BUSINESSTYPE;
            _HistoryTruckBill.I_PLANTYPE = _OldTruckBill.I_PLANTYPE;
            _HistoryTruckBill.I_ISAUTO = _OldTruckBill.I_ISAUTO;
            _HistoryTruckBill.I_WEIGHTTYPE = _OldTruckBill.I_WEIGHTTYPE;
            _HistoryTruckBill.I_TARETIMELIMIT = _OldTruckBill.I_TARETIMELIMIT;
            _HistoryTruckBill.I_ONEMORESTOCK = _OldTruckBill.I_ONEMORESTOCK;
            _HistoryTruckBill.I_ISCHILDIDENFY = _OldTruckBill.I_ISCHILDIDENFY;
            _HistoryTruckBill.I_ISCREATEMOTHERPOND = _OldTruckBill.I_ISCREATEMOTHERPOND;
            _HistoryTruckBill.C_CONNECTPLANNO = _OldTruckBill.C_CONNECTPLANNO;
            _HistoryTruckBill.I_ONETWOPLAN = _OldTruckBill.I_ONETWOPLAN;
            _HistoryTruckBill.C_MIDDLEDEPTNO = _OldTruckBill.C_MIDDLEDEPTNO;
            _HistoryTruckBill.C_MIDDLEDEPTNAME = _OldTruckBill.C_MIDDLEDEPTNAME;
            _HistoryTruckBill.C_MIDDLESTORENO = _OldTruckBill.C_MIDDLESTORENO;
            _HistoryTruckBill.C_MIDDLESTORENAME = _OldTruckBill.C_MIDDLESTORENAME;
            _HistoryTruckBill.I_RETALLYKG = _OldTruckBill.I_RETALLYKG;
            _HistoryTruckBill.I_COMPUTERTYPE = _OldTruckBill.I_COMPUTERTYPE;
            _HistoryTruckBill.I_DOWNVALUE = _OldTruckBill.I_DOWNVALUE;
            _HistoryTruckBill.I_UPVALUE = _OldTruckBill.I_UPVALUE;
            _HistoryTruckBill.C_PERCENTAGE = _OldTruckBill.C_PERCENTAGE;
            _HistoryTruckBill.C_SHIPPINGNOTE = _OldTruckBill.C_SHIPPINGNOTE;
            _HistoryTruckBill.I_REPEATPOUND = _OldTruckBill.I_REPEATPOUND;
            _HistoryTruckBill.C_PLANLIMITTIME = _OldTruckBill.C_PLANLIMITTIME;
            _HistoryTruckBill.C_PONDLIMIT = _OldTruckBill.C_PONDLIMIT;
            _HistoryTruckBill.C_CREATETIME = _OldTruckBill.C_CREATETIME;
            _HistoryTruckBill.C_CREATEUSERNAME = _OldTruckBill.C_CREATEUSERNAME;
            _HistoryTruckBill.C_REMARK = _OldTruckBill.C_REMARK;
            _HistoryTruckBill.C_RESERVE1 = _OldTruckBill.C_RESERVE1;
            _HistoryTruckBill.C_RESERVE2 = _OldTruckBill.C_RESERVE2;
            _HistoryTruckBill.C_RESERVE3 = _OldTruckBill.C_RESERVE3;
            _HistoryTruckBill.I_RESERVE1 = _OldTruckBill.I_RESERVE1;
            _HistoryTruckBill.I_RESERVE2 = _OldTruckBill.I_RESERVE2;
            _HistoryTruckBill.I_RESERVE3 = _OldTruckBill.I_RESERVE3;
            _HistoryTruckBill.C_PLANSTATE = _OldTruckBill.C_PLANSTATE;
            _HistoryTruckBill.C_WGTLISTNO = _OldTruckBill.C_WGTLISTNO;
            _HistoryTruckBill.C_BARCODENO = _OldTruckBill.C_BARCODENO;
            _HistoryTruckBill.N_TAREWGT = _OldTruckBill.N_TAREWGT;
            _HistoryTruckBill.N_GROSSWGT = _OldTruckBill.N_GROSSWGT;
            _HistoryTruckBill.N_NETWGT = _OldTruckBill.N_NETWGT;
            _HistoryTruckBill.C_TAREWGTTIME = _OldTruckBill.C_TAREWGTTIME;
            _HistoryTruckBill.C_GROSSWGTTIME = _OldTruckBill.C_GROSSWGTTIME;
            _HistoryTruckBill.C_TAREWGTSITENO = _OldTruckBill.C_TAREWGTSITENO;
            _HistoryTruckBill.C_TAREWGTSITENAME = _OldTruckBill.C_TAREWGTSITENAME;
            _HistoryTruckBill.C_GROSSWGTSITENO = _OldTruckBill.C_GROSSWGTSITENO;
            _HistoryTruckBill.C_GROSSWGTSITENAME = _OldTruckBill.C_GROSSWGTSITENAME;
            _HistoryTruckBill.C_TAREWGTMAN = _OldTruckBill.C_TAREWGTMAN;
            _HistoryTruckBill.C_GROSSWGTMAN = _OldTruckBill.C_GROSSWGTMAN;
            _HistoryTruckBill.I_RETURNFLAG = _OldTruckBill.I_RETURNFLAG;
            _HistoryTruckBill.C_PONDREMARK = _OldTruckBill.C_PONDREMARK;
            _HistoryTruckBill.C_RESERVEFLAG1 = _OldTruckBill.C_RESERVEFLAG1;
            _HistoryTruckBill.C_RESERVEFLAG2 = _OldTruckBill.C_RESERVEFLAG2;
            _HistoryTruckBill.C_RESERVEFLAG3 = _OldTruckBill.C_RESERVEFLAG3;
            _HistoryTruckBill.I_RESERVEFLAG1 = _OldTruckBill.I_RESERVEFLAG1;
            _HistoryTruckBill.I_RESERVEFLAG2 = _OldTruckBill.I_RESERVEFLAG2;
            _HistoryTruckBill.I_RESERVEFLAG3 = _OldTruckBill.I_RESERVEFLAG3;
            _HistoryTruckBill.C_UPDATEUSERNAME = _OldTruckBill.C_UPDATEUSERNAME;
            _HistoryTruckBill.C_UPDATETIME = _OldTruckBill.C_UPDATETIME;
            _HistoryTruckBill.C_BILLCREATETIME = _OldTruckBill.C_BILLCREATETIME;
            _HistoryTruckBill.C_BILLCREATEUSERNAME = _OldTruckBill.C_BILLCREATEUSERNAME;
            _HistoryTruckBill.C_BILLSTATE = _OldTruckBill.C_BILLSTATE;
            _HistoryTruckBill.C_NETWGTTIME = _OldTruckBill.C_NETWGTTIME;
            _HistoryTruckBill.I_REPEATFLAG = _OldTruckBill.I_REPEATFLAG;
            _HistoryTruckBill.C_CARSERIALNUMBER = _OldTruckBill.C_CARSERIALNUMBER;
            _HistoryTruckBill.C_CONTRACTNO = _OldTruckBill.C_CONTRACTNO;
            _HistoryTruckBill.C_UPLOADSTATUE = _OldTruckBill.C_UPLOADSTATUE;
            _HistoryTruckBill.C_PLANSTATUS = _OldTruckBill.C_PLANSTATUS;
            _HistoryTruckBill.I_PRINTNUM = _OldTruckBill.I_PRINTNUM;
            _HistoryTruckBill.C_CONTAINERNO = _OldTruckBill.C_CONTAINERNO;
            _HistoryTruckBill.C_RESERVE4 = _OldTruckBill.C_RESERVE4;
            _HistoryTruckBill.C_RESERVE5 = _OldTruckBill.C_RESERVE5;
            _HistoryTruckBill.C_RESERVE6 = _OldTruckBill.C_RESERVE6;
            _HistoryTruckBill.C_RESERVE7 = _OldTruckBill.C_RESERVE7;
            
        }
        public object ExecuteDB_UpdatePM_Bill_Truck2(PM_Bill_Truck TruckBill,bool isFu)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("Update_PM_Bill_Truck2", TruckBill);
                //将未完成磅单-->已完成磅单（一条复磅毛重）
                if (isFu)
                {
                    PM_Bill_Truck fuTruck = new PM_Bill_Truck();
                    fuTruck.C_CARNAME = TruckBill.C_CARNAME;
                    fuTruck.C_BILLSTATE = PLANSTATE.已完成;
                    result = CommonDao.ExecuteUpdate("UpdatePM_Bill_TruckByCarName", fuTruck);
                }
                if (TruckBill.C_BILLSTATE == PLANSTATE.已完成)
                {
                    //修改计划委托状态为已完成
                    PT_TruckMeasurePlan planMeasure = new PT_TruckMeasurePlan();
                    planMeasure.C_PLANNO = TruckBill.C_PLANNO;
                    planMeasure.C_PLANSTATE = PLANSTATE.已完成;
                    result = CommonDao.ExecuteUpdate("UpdateStatTruckMeasurePlanByPlanNo", planMeasure);
                }
            }
            catch (Exception ex)
            {
                result = new CustomDBError(ex.Message);
            }
            return result;
        }


        public object ExecuteDB_UpdatePM_Bill_Truck3(PM_Bill_Truck TruckBill)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Bill_TruckByPrint", TruckBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanNo(string PlanNo)
        {
            PT_TruckMeasurePlan result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PT_TruckMeasurePlan>("QueryTruckMeasurePlanByPlanNo", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InvalidPM_Bill_Truck(PM_Bill_Truck TruckBillNew)
        {
            object result;
            try
            {
                
                
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];//获取IP
                PM_Bill_Truck OldTruckBill = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("Select_PM_BILL_TRUCKByIntId", TruckBillNew.I_INTID);
                PM_Bill_Truck_History HistoryTruckBill = new PM_Bill_Truck_History();
                SetBillValueToHistoryBill(OldTruckBill, HistoryTruckBill);
                //HistoryTruckBill.C_UPDATECOLUMNS = "作废";
                HistoryTruckBill.C_UPDATEHISTORYTIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                HistoryTruckBill.C_UPDATEHISTORYUSER = SessionHelper.LogUserNickName;
                HistoryTruckBill.C_COMPUTERIP = ipAddr.ToString();
                
                //正常作废功能
                result = CommonDao.ExecuteUpdate("Invalid_PM_Bill_TruckByHashTable", TruckBillNew);
                //查出作废后的数据，和之前比较
                PM_Bill_Truck TruckBill = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("Select_PM_BILL_TRUCKByIntId", TruckBillNew.I_INTID);
                HistoryTruckBill.C_UPDATECOLUMNS = CompareTruckBill(TruckBill, OldTruckBill);//
                //插入修改前数据到历史表
                CommonDao.ExecuteInsert("Insert_PM_Bill_Truck_History", HistoryTruckBill);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InvalidPM_TruckMeasure(string planno, int state)
        {
            object result;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", planno);
                ht.Add("State", state);
                //result = CommonDao.ExecuteUpdate("Invalid_PM_TruckMeasureByHashTable", IntId);
                result = CommonDao.ExecuteUpdate("Invalid_PM_TruckMeasureByHashTable_New", ht);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        //查询汽车磅磅单历史表
        public IList<PM_Bill_Truck_History> ExecuteDB_QueryPM_Bill_TruckHistoryByHashtable(Hashtable ht)
        {
            IList<PM_Bill_Truck_History> result;
            try
            {
                //result = CommonDao.ExecuteQueryForList<PM_Bill_Truck_History>("Select_PM_Bill_Truck_HistoryForCompare", ht);
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck_History>("Select_PM_Bill_Truck_HistoryForCompare2", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_BatchUpdateTruckBill(List<string> TruckBillWgtNos, Hashtable ht)
        {
            object result=null;
            try
            {
                string FromDeptName=ht["FromDeptName"].ToString();
                string ToDeptName = ht["ToDeptName"].ToString();
                string ContractNo = ht["ContractNo"].ToString();
                string ContainerNo = ht["ContainerNo"].ToString();
                string Remark = ht["Remark"].ToString();
                string PondRemark = ht["PondRemark"].ToString();
                string MaterialName = ht["MaterialName"].ToString();
                string MaterialNo = ht["MaterialNo"].ToString();
               foreach (string TruckBillWgtNo in TruckBillWgtNos)
               {
                    PM_Bill_Truck TruckBill = CommonDao.ExecuteQueryForObject<PM_Bill_Truck>("QueryBillTruckBywgiston", TruckBillWgtNo);
                    if (!string.IsNullOrEmpty(FromDeptName))
                    {
                        TruckBill.C_FROMDEPTNAME = FromDeptName;
                    }
                    if (!string.IsNullOrEmpty(ToDeptName))
                    {
                        TruckBill.C_TODEPTNAME = ToDeptName;
                    }
                    if (!string.IsNullOrEmpty(ContractNo))
                    {
                        TruckBill.C_CONTRACTNO = ContractNo;
                    }
                    if (!string.IsNullOrEmpty(ContainerNo))
                    {
                        TruckBill.C_CONTAINERNO = ContainerNo;
                    }
                    if (!string.IsNullOrEmpty(Remark))
                    {
                        TruckBill.C_REMARK = Remark;
                    }
                    if (!string.IsNullOrEmpty(PondRemark))
                    {
                        TruckBill.C_PONDREMARK = PondRemark;
                    }
                    if (!string.IsNullOrEmpty(MaterialName))
                    {
                        TruckBill.C_MATERIALNAME = MaterialName;
                    }
                    if (!string.IsNullOrEmpty(MaterialNo))
                    {
                        TruckBill.C_MATERIALNO = MaterialNo;
                    }


                    if (TruckBill.C_BILLSTATE == PLANSTATE.已作废)
                    {
                        TruckBill.C_PLANSTATUS = "D";
                    }
                    else if (TruckBill.C_UPLOADSTATUE == "Y")
                    {
                        TruckBill.C_PLANSTATUS = "U";
                    }

                    TruckBill.C_UPLOADSTATUE = "N";
                    TruckBill.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                    result = ExecuteDB_UpdatePM_Bill_Truck(TruckBill);
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

        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForjincai(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_LatestPM_Bill_TruckByPondForjincai", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByHashtable_ForHuda(Hashtable ht)
        {
            IList<PM_Bill_Truck> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Truck>("Select_PM_Bill_TruckByHashTable_ForHuda", ht);
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
