using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using System.Data;
using System.Collections;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Container_RateServiceImpl : ISM_Container_RateService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertContainerRateInfo(SM_Container_Rate rate)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_Container_Rate", rate);
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

        public IList<SM_Container_Rate> ExecuteDB_QueryAll()
        {
            IList<SM_Container_Rate> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Container_Rate>("QuerySM_Container_RateAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public DataTable ExecuteDB_QueryContainerRecognitionRateAll(Hashtable condition)
        {
            DataTable rs = null;
            try
            {
                Hashtable ht = new Hashtable();
                rs = CommonDao.ExecuteQueryForDataTable("QueryContainerRateAll", condition, out ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<SM_Container_Rate> ExecuteDB_QueryAllByCondition(Hashtable condition)
        {
            IList<SM_Container_Rate> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Container_Rate>("QuerySM_Container_RateByCondition", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

    }
}
