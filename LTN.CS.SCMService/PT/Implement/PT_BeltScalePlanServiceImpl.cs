using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PT;
using System.Collections;

namespace LTN.CS.SCMService.PT.Implement
{
    public class PT_BeltScalePlanServiceImpl: IPT_BeltScalePlanService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<PT_BeltScalePlan> ExecuteDB_QueryBeltScalePlanByHashTable(Hashtable ht)
        {
            IList<PT_BeltScalePlan> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PT_BeltScalePlan>("QueryBeltScalePlanByHashTable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InvalidBeltScalePlanByIntId(PT_BeltScalePlan BeltScalePlan)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("InvalidBeltScalePlanByIntId", BeltScalePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_UpdateBeltScalePlanByPlanNo(PT_BeltScalePlan BeltScalePlan)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdateBeltScalePlanByPlanNo", BeltScalePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InsertBeltScalePlan(PT_BeltScalePlan BeltScalePlan)
        {
            object result;
            try
            {
                string value = "99" + DateTime.Now.ToString("yyyyMMdd") + "%";
                string MaxNo = CommonDao.ExecuteQueryForObject<string>("QueryBeltPlanNoForCreatePlanNo", value);
                if (string.IsNullOrEmpty(MaxNo))
                {
                    MaxNo = "99" + DateTime.Now.ToString("yyyyMMdd") + "0000";
                }
                Int64 PlanNo = Int64.Parse(MaxNo) + 1;
                BeltScalePlan.C_Planno = PlanNo.ToString();

                result = CommonDao.ExecuteInsert("InsertBeltScalePlan", BeltScalePlan);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        //新增  
        public IList<PT_BeltScalePlan> ExecuteDB_QueryBeltPlanByConditions(Hashtable ht)
        {
            IList<PT_BeltScalePlan> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PT_BeltScalePlan>("QueryBeltScalePlanByConditions1", ht);
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
