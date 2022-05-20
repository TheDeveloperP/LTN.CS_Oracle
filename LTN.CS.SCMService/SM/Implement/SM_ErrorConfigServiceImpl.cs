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
    public class SM_ErrorConfigServiceImpl : ISM_ErrorConfigService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public object ExecuteDB_UpdateErrorConfig(SM_ErrorConfig ErrorConfig)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_ErrorConfig", ErrorConfig);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public object ExecuteDB_DeleteErrorConfig(SM_ErrorConfig ErrorConfig)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteDelete("DeleteSM_ErrorConfig", ErrorConfig);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message); ;
            }
            return rs;

        }

        public object ExecuteDB_InsertErrorConfig(SM_Dvr_Info ErrorConfig)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_ErrorConfig", ErrorConfig);
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

        public IList<SM_ErrorConfig> ExecuteDB_QueryAll()
        {
            IList<SM_ErrorConfig> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_ErrorConfig>("selectSM_ErrorConfigAll", null);
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_ErrorConfig> ExecuteDB_QueryErrorConfigSingle(string GrossWgtError)
        {
           
            IList<SM_ErrorConfig> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_ErrorConfig>("selectSM_ErrorConfigGrossWgtError", GrossWgtError);
                ;
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
   

        public object ExecuteDB_InsertErrorConfig(SM_ErrorConfig ErrorConfig)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_ErrorConfig", ErrorConfig);
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
