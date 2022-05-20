using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_PoundService_InfoServiceImpl : ISM_PoundService_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeletePoundInfo(SM_PoundService_Info PoundInfo)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_PoundService_Info", PoundInfo);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertPoundInfo(SM_PoundService_Info PoundInfo)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_PoundService_Info", PoundInfo);
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

        public IList<SM_PoundService_Info> ExecuteDB_QueryAll()
        {
            IList<SM_PoundService_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_PoundService_Info>("selectSM_PoundService_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_PoundService_Info> ExecuteDB_QueryAllByCondition(Hashtable condition)
        {
            IList<SM_PoundService_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_PoundService_Info>("selectSM_PoundService_InfoByPound", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdatePoundInfo(SM_PoundService_Info PoundInfo)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_PoundService_Info", PoundInfo);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_PoundService_Info> ExecuteDB_QueryAllByPoundId(int PoundId)
        {
            IList<SM_PoundService_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_PoundService_Info>("selectSM_PoundService_InfoByPoundId", PoundId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public SM_PoundService_Info ExecuteDB_QueryAllByPondId(int pondip)
        {
            SM_PoundService_Info rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<SM_PoundService_Info>("SelectSM_PoundService_InfoByPondId", pondip);
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
