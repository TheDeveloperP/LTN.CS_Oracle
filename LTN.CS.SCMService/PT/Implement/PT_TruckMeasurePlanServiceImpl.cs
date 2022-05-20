using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PT;
using System.Collections;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.PT.Implement
{
    public class PT_TruckMeasurePlanServiceImpl: IPT_TruckMeasurePlanService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public object ExecuteDB_InsertTruckMeasurePlan(PT_TruckMeasurePlan TruckMeasurePlan)
        {
            object result;
            try
            {
                //string value = "99" + DateTime.Now.ToString("yyyyMMdd") + "%";
                //string MaxNo = CommonDao.ExecuteQueryForObject<string>("QueryPlanNoForCreatePlanNo", value);
                //if (string.IsNullOrEmpty(MaxNo))
                //{
                //    MaxNo = "99" + DateTime.Now.ToString("yyyyMMdd") + "0000";
                //}
                //Int64 PlanNo = Int64.Parse(MaxNo) + 1;

                TruckMeasurePlan.C_PLANNO = getComputer(TruckMeasurePlan.C_PLANNO);

                result = CommonDao.ExecuteInsert("InsertTruckMeasurePlan", TruckMeasurePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = new CustomDBError(ex.Message);
            }
            return result;
        }

        public object ExecuteDB_InsertTruckMeasurePlan2(PT_TruckMeasurePlan TruckMeasurePlan ,string[] str)
        {
            object result=1;
            try
            {
                string planNo = TruckMeasurePlan.C_PLANNO;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!string.IsNullOrEmpty(str[i].Trim()))
                    {
                        TruckMeasurePlan.C_PLANNO = getComputer(planNo);
                        TruckMeasurePlan.C_CARNAME = str[i].ToUpper().Trim();
                        result = CommonDao.ExecuteInsert("InsertTruckMeasurePlan", TruckMeasurePlan);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = new CustomDBError(ex.Message);
            }
            return result;
        }

        private string getComputer(string str)
        {
            string returnStr = string.Empty;
            switch (str)
            { 
                case "物流":
                    returnStr = "AC";
                    break;
                case "铁前":
                    returnStr = "A0";
                    break;
                case "物资":
                    returnStr = "EP";
                    break;
                case "炼钢":
                    returnStr = "A6";
                    break;
                case "棒线":
                    returnStr = "A9";
                    break;
                case "冷轧":
                    returnStr = "A8";
                    break;
                case "钢后":
                    returnStr = "A1";
                    break;
                case "强实":
                    returnStr = "B3";
                    break;
                default:
                    returnStr = "AC";
                    break;
            }
            string StrPlanNo = CommonDao.ExecuteQueryForObject<string>("SelectFuction", returnStr+"JL");
            return StrPlanNo;
        }

        public object ExecuteDB_InvalidTruckMeasurePlanByIntId(PT_TruckMeasurePlan TruckMeasurePlan)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("InvalidTruckMeasurePlanByIntId", TruckMeasurePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_UpdateStatTruckMeasurePlanByPlanNo(PT_TruckMeasurePlan TruckMeasurePlan)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdateStatTruckMeasurePlanByPlanNo", TruckMeasurePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PT_TruckMeasurePlan> ExecuteDB_QueryTruckMeasurePlanByHashTable(Hashtable ht)
        {
            IList<PT_TruckMeasurePlan> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PT_TruckMeasurePlan>("QueryTruckMeasurePlanByHashTable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public string ExecuteDB_QueryPlanNoForCreatePlanNo()
        {
            string result;
            try
            {
                string value = "99" + DateTime.Now.ToString("yyyyMMdd") + "%";
                string MaxNo = CommonDao.ExecuteQueryForObject<string>("QueryPlanNoForCreatePlanNo", value);
                if (string.IsNullOrEmpty(MaxNo))
                {
                    MaxNo = "99" + DateTime.Now.ToString("yyyyMMdd") + "0000";
                }
                Int64 PlanNo = Int64.Parse(MaxNo) + 1;
                result = PlanNo.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        public object ExecuteDB_UpdateTruckMeasurePlan(PT_TruckMeasurePlan TruckMeasurePlan)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdateTruckMeasurePlan", TruckMeasurePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        /// <summary>
        /// 根据车号和时间查询未过期的计划
        /// </summary>
        /// <returns></returns>
       public  IList<PT_TruckMeasurePlan> ExecuteDB_QueryTruckMeasureUsingPlan(Hashtable ht)
        {
            IList<PT_TruckMeasurePlan> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PT_TruckMeasurePlan>("QueryTruckMeasureUsingPlanByHashTable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 根据委托单号查询委托
        /// </summary>
        /// <param name="PlanNo"></param>
        /// <returns></returns>
        public PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasureUsingPlanByPlanNo(string PlanNo)
        {
            PT_TruckMeasurePlan result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PT_TruckMeasurePlan>("QueryTruckMeasureUsingPlanByPlanNo", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
       public PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanId(int planId)
       {
           PT_TruckMeasurePlan result;
           try
           {
               result = CommonDao.ExecuteQueryForObject<PT_TruckMeasurePlan>("QueryTruckMeasurePlanByPlanID", planId);
           }
           catch (Exception ex)
           {
               log.Error(ex.Message);
               result = null;
           }
           return result;
       }

       public PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanNo(string planId)
       {
           PT_TruckMeasurePlan result;
           try
           {
               result = CommonDao.ExecuteQueryForObject<PT_TruckMeasurePlan>("SelectTruckMeasurePlanByPlanNo", planId);
           }
           catch (Exception ex)
           {
               log.Error(ex.Message);
               result = null;
           }
           return result;
       }

        public PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByfromdept(string fromdept)
        {
            PT_TruckMeasurePlan result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PT_TruckMeasurePlan>("SelectTruckMeasurePlanByfromdept", fromdept);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_UpdateTruckMeasurePlanForBatch(IList<PT_TruckMeasurePlan> list)
        {
            object rs;
            try
            {
                if (list != null && list.Count > 0)
                {
                    foreach (PT_TruckMeasurePlan MM in list)
                    {
                        PT_TruckMeasurePlan m = MM.Clone() as PT_TruckMeasurePlan;
                        rs = CommonDao.ExecuteUpdate("UpdateTruckMeasurePlan", m);
                    }
                }
                rs = 1;
            }catch(Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
          
        }
    }
}
