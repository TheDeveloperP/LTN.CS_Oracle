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
    public class SM_LPRCameraServiceImpl : ISM_LPRCameraService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeleteLPRInfo(SM_LPRCamera LPR)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_LPRCamera", LPR);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertLPRInfo(SM_LPRCamera LPR)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_LPRCamera", LPR);
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

        public IList<SM_LPRCamera> ExecuteDB_QueryAll()
        {
            IList<SM_LPRCamera> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_LPRCamera>("selectSM_LPRCameraAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_LPRCamera> ExecuteDB_QueryByLPRName(string name)
        {
            IList<SM_LPRCamera> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_LPRCamera>("selectSM_LPRCameraByLPRName", name);
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_LPRCamera> ExecuteDB_QueryBySiteIp(string ip)
        {
            throw new NotImplementedException();
        }

        public object ExecuteDB_UpdateLPRInfo(SM_LPRCamera LPR)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_LPRCamera", LPR);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public SM_LPRCamera ExecuteDB_QueryByLprId(int lprId)
        {
            SM_LPRCamera result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<SM_LPRCamera>("QuerySM_LPRCameraBylprId", lprId);
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
