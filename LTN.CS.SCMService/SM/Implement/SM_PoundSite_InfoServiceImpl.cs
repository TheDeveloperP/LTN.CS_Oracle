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
    public class SM_PoundSite_InfoServiceImpl : ISM_PoundSite_InfoService
    {
        public ICommonDao CommonDao { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<SM_PoundSite_Info> ExecuteDB_QueryAll()
        {
            IList<SM_PoundSite_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<DM_PondSite_Info_WCF> ExecuteDB_QueryAll2()
        {
            IList<DM_PondSite_Info_WCF> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<DM_PondSite_Info_WCF>("selectDM_PondSite_Info_WCFAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }



        public IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundSiteId(string poundSiteId)
        {
            IList<SM_PoundSite_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoByPoundSiteNo", poundSiteId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundSiteIp(string poundSiteIp)
        {
            IList<SM_PoundSite_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoBySiteIp", poundSiteIp);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;

        }
        public IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundType(int poundType)
        {
            IList<SM_PoundSite_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoByPondType", poundType);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertPoundSiteInfo(SM_PoundSite_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_PoundSite_Info", Site);
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

        public object ExecuteDB_UpdatePoundSiteInfo(SM_PoundSite_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_PoundSite_Info", Site);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeletePoundSiteInfo(SM_PoundSite_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("DeleteSM_PoundSite_Info", Site);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public DM_PondSite_Info_WCF ExecuteDB_QueryByIntId(int intid)
        {
            DM_PondSite_Info_WCF rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<DM_PondSite_Info_WCF>("SelectPondSiteByIntId", intid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public DM_PondSite_Info_WCF ExecuteDB_QueryByIntPondId(string pondip)
        {
            DM_PondSite_Info_WCF rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<DM_PondSite_Info_WCF>("SelectPondSiteBypondip", pondip);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        /// <summary>
        /// 未授权光栅站点
        /// </summary>
        /// <returns></returns>
        public IList<SM_PoundSite_Info> ExecuteDB_QueryGuangUnShouQuan()
        {
            IList<SM_PoundSite_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoGuangShouQ", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        /// <summary>
        /// 光栅授权站点
        /// </summary>
        /// <returns></returns>
        public IList<SM_PoundSite_Info> ExecuteDB_QueryGuangShouQuan()
        {
            IList<SM_PoundSite_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_PoundSite_Info>("selectSM_PoundSite_InfoGuangUnShouQ", null);
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
