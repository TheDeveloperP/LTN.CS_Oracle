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
    public class SM_Meter_InfoServiceImpl : ISM_Meter_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]

        public IList<SM_Meter_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Meter_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Meter_Info>("selectSM_Meter_InfoAll", null);
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Meter_Info> ExecuteDB_QueryMeterSingle(string name)
        {
            IList<SM_Meter_Info> rs;
            try
            {
                rs=CommonDao.ExecuteQueryForList<SM_Meter_Info>("selectSM_Meter_InfoName", name);
            }
            catch (Exception ex)
            {
                
               log.Error(ex.Message);
                rs = null;   
            }
            return rs;
        }

        public object ExecuteDB_InsertMeterInfo(SM_Meter_Info Meter)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_Meter_Info", Meter);
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

        public object ExecuteDB_UpdateMeterInfo(SM_Meter_Info Meter)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Meter_Info", Meter);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteMeterInfo(SM_Meter_Info Meter)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteDelete("DeleteSM_Meter_Info", Meter);

            }
            catch (Exception ex)
            {

                rs = new CustomDBError(ex.Message); ;
            }
            return rs;
        }
    }
}
