using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Site_InfoServiceImpl:ISM_Site_InfoService
    {
        public ICommonDao CommonDao { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<SM_Site_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Site_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Site_Info>("selectSM_Site_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Site_Info> ExecuteDB_QueryBySiteId(string name)
        {
            IList<SM_Site_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Site_Info>("selectSM_Site_InfoBySiteId", name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Site_Info> ExecuteDB_QueryBySiteIp(string ip)
        {
            IList<SM_Site_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Site_Info>("selectSM_Site_InfoBySiteIp", ip);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;

        }

        public object ExecuteDB_InsertSiteInfo(SM_Site_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_Site_Info", Site);
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

        public object ExecuteDB_UpdateSiteInfo(SM_Site_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Site_Info", Site);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteSiteInfo(SM_Site_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("DeleteSM_Site_Info", Site);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<DM_Site_Info_WCF> ExecuteDB_QueryBySiteIp2(string ip)
        {
            IList<DM_Site_Info_WCF> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<DM_Site_Info_WCF>("selectSM_Site_InfoBySiteId2", ip);
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
