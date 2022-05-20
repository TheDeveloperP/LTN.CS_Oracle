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

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_SuppliesServiceImpl:IPM_Bill_SuppliesService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Bill_Supplies> ExecuteDB_QueryAll()
        {
            IList<PM_Bill_Supplies> rs;
            try
            {
                //对铁运委托的查询修改
                rs = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesUseable", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertSuppliesInfo(PM_Bill_Supplies Supplies)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Bill_Supplies", Supplies);
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
        public object ExecuteDB_UpdateSuppliesInfo(PM_Bill_Supplies Supplies)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_Bill_Supplies", Supplies);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteSuppliesInfo(PM_Bill_Supplies Supplies)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_Bill_Supplies", Supplies);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InvalidSuppliesPlanByIntId(PM_Bill_Supplies Supplies)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Bill_SuppliesStatus", Supplies);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Supplies> ExecuteDB_QuerySuppliesPlanByHashTable(Hashtable ht)
        {
            IList<PM_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesByCond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Supplies> ExecuteDB_QuerySuppliesByPlan(string PlanNo)
        {
            IList<PM_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesByPlan", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Supplies> ExecuteDB_QueryIronByCarNo(string CarNo)
        {
            IList<PM_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesByCarNo", CarNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Supplies> ExecuteDB_QueryIronByWgtNo(string CarNo)
        {
            IList<PM_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesByWgtNo", CarNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Supplies> ExecuteDB_QueryIronByStatic(Hashtable ht)
        {
            IList<PM_Bill_Supplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Supplies>("selectPM_Bill_SuppliesByStatic", ht);
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
