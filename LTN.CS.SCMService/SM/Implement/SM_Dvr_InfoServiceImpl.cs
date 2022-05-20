using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Dvr_InfoServiceImpl : ISM_Dvr_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]
        public object ExecuteDB_DeleteDvrInfo(SM_Dvr_Info Dvr)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteDelete("DeleteSM_Dvr_Info", Dvr);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message); ;
            }
            return rs;

        }

        public object ExecuteDB_InsertDvrInfo(SM_Dvr_Info Dvr)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_Dvr_Info", Dvr);
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

        public IList<SM_Dvr_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Dvr_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Dvr_Info>("selectSM_Dvr_InfoAll", null);
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Dvr_Info> ExecuteDB_QuerySingle(string dvrName)
        {
            IList<SM_Dvr_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Dvr_Info>("selectSM_Dvr_InfoDvrName", dvrName);
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
            
        }

        public IList<SM_Dvr_Info> ExecuteDB_QueryBySiteId(string name)
        {
            throw new NotImplementedException();
        }

        public IList<SM_Dvr_Info> ExecuteDB_QueryBySiteIp(string ip)
        {
            throw new NotImplementedException();
        }

        public object ExecuteDB_UpdateDvrInfo(SM_Dvr_Info Dvr)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Dvr_Info", Dvr);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public SM_Dvr_Info ExecuteDB_QueryAllByPondId(int pondip)
        {
            SM_Dvr_Info rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<SM_Dvr_Info>("SelectSM_Dvr_InfoBypondip", pondip);
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
