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
    public class SM_MatWGTLimitServiceImpl : ISM_MatWGTLimitService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeleteWGTLimitInfo(SM_MatWGTLimit Info)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_MatWGTLimit", Info);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertWGTLimitInfo(SM_MatWGTLimit Info)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_MatWGTLimit", Info);
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

        public IList<SM_MatWGTLimit> ExecuteDB_QueryAll()
        {
            IList<SM_MatWGTLimit> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_MatWGTLimit>("selectSM_MatWGTLimitAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdateWGTLimitInfo(SM_MatWGTLimit Info)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_MatWGTLimit", Info);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_MatWGTLimit> ExecuteDB_QueryMatName(string MatName)
        {
            IList<SM_MatWGTLimit> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_MatWGTLimit>("selectSM_MatWGTLimitForJudgeMatName", MatName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_MatWGTLimit> ExecuteDB_QueryMatCode(string MatCode)
        {
            IList<SM_MatWGTLimit> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_MatWGTLimit>("selectSM_MatWGTLimitForJudgeMatCode", MatCode);
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
