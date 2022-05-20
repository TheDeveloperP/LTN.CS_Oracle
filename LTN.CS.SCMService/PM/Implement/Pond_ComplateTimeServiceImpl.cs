using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Globalization;

namespace LTN.CS.SCMService.PM.Implement
{
    public class Pond_ComplateTimeServiceImpl:IPond_ComplateTimeService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<Pond_ComplateTime> ExecuteDB_QueryAll(Hashtable ht)
        {
            IList<Pond_ComplateTime> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<Pond_ComplateTime>("selectPond_ComplateTimeByConditions", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InsertPondComplateInfo(Pond_ComplateTime obj)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertPond_ComplateTime", obj);
                rs = 1;               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = ex.Message.ToString();
            }
            return rs;
        }


        public object ExecuteDB_UpdatePondComplateInfo(Hashtable ht)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteUpdate("UpdatePond_ComplateTime", ht);
                rs = 1;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = ex.Message;
            }
            return rs;
        }

        public IList<Pond_ComplateTime> ExecuteDB_QueryUnComplecated()
        {
            IList<Pond_ComplateTime> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<Pond_ComplateTime>("selectPond_ComplateTimeUnComplacated", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        //新增皮带秤时长统计
        public IList<PM_BeltTimeCount> ExecuteDB_QueryBeltTimeCountByConditions(Hashtable ht)
        {
            IList<PM_BeltTimeCount> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_BeltTimeCount>("selectPond_ComplateTimeByConditions", ht);
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
