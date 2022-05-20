using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Collections;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_TareWeightHistoryServiceImpl : ISM_TareWeightHistoryService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeleteHistoryTare(SM_TareWeightHistory tarehistory)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_TareWeightHistory", tarehistory);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_TareWeightHistory> ExecuteDB_QueryAll()
        {
            IList<SM_TareWeightHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeightHistory>("selectSM_TareWeightHistoryAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_TareWeightHistory> ExecuteDB_QueryByCarnameAndTime(Hashtable ht)
        {
            IList<SM_TareWeightHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeightHistory>("selectSM_TareWeightHistoryAllByCondition", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertHistoryTare(SM_TareWeightHistory TareHistory)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_TareWeightHistory", TareHistory);
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
    }
}
