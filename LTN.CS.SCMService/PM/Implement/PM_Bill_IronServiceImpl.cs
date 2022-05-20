using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using System.Collections;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_IronServiceImpl : IPM_Bill_IronService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Bill_Iron> ExecuteDB_QueryAll()
        {
            IList<PM_Bill_Iron> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<PM_Bill_Iron>("selectPM_Bill_IronAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertIronInfo(PM_Bill_Iron Iron)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Bill_Iron", Iron);
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
        public object ExecuteDB_UpdateIronInfo(PM_Bill_Iron Iron)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_Bill_Iron", Iron);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteIronInfo(PM_Bill_Iron Iron)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_Bill_Iron", Iron);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InvalidIronPlanByIntId(PM_Bill_Iron Iron)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Bill_IronStatus", Iron);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Iron> ExecuteDB_QueryIronPlanByHashTable(Hashtable ht)
        {
            IList<PM_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Iron>("selectPM_Bill_IronByCond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Iron> ExecuteDB_QueryIronByPlan(string PlanNo)
        {
            IList<PM_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Iron>("selectPM_Bill_IronByPlan", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_Iron> ExecuteDB_QueryIronByCarNo(string CarNo)
        {
            IList<PM_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_Iron>("selectPM_Bill_IronByCarNo", CarNo);
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
