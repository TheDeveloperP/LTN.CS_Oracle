using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_BlackListServiceImpl : ISM_BlackListService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<SM_BlackList> ExecuteDB_QueryAll()
        {
            IList<SM_BlackList> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BlackList>("selectSM_BlackListAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_BlackListHistory> ExecuteDB_QueryHistoryAll()
        {
            IList<SM_BlackListHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BlackListHistory>("selectSM_BlackListHistoryAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertBlackList(SM_BlackList blacklist)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_BlackList", blacklist);
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

        public object ExecuteDB_DeleteBlackList(SM_BlackList blacklist)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_BlackList", blacklist);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertBlackListHistory(SM_BlackListHistory blacklist)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_BlackListHistory", blacklist);
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

        public object ExecuteDB_DeleteBlackListHistory(SM_BlackListHistory blacklist)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_BlackListHistory", blacklist);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_BlackList> ExecuteDB_QueryBlackListByCarName(string name)
        {
            IList<SM_BlackList> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BlackList>("selectSM_BlackListByCarName", name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
            
        }

        public IList<SM_BlackListHistory> ExecuteDB_QueryBlackListHistoryByCarName(string name)
        {
            IList<SM_BlackListHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BlackListHistory>("selectSM_BlackListHistoryAllByCarName", name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_BlackList> ExecuteDB_QueryBlackListByCarName2(string name)
        {
            IList<SM_BlackList> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BlackList>("selectSM_BlackListByCarName2", name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public System.DateTime ExecuteDB_GetDBTimeNow()
        {
            DateTime rs;
            try
            {
                rs = CommonDao.ExecuteDBTime();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = DateTime.Now;
            }
            return rs;
        }
    }
}
