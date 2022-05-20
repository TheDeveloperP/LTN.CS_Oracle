using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;


namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Car_InfoServiceImpl : ISM_Car_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]

        public IList<SM_Car_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Car_Info> rs;
            try
            {
                
                rs = CommonDao.ExecuteQueryForList<SM_Car_Info>("selectSM_Car_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }


        public object ExecuteDB_InsertCarInfo(SM_Car_Info Site)
        {
            object rs;
            try
            {
                
                rs = CommonDao.ExecuteInsert("InsertSM_Car_Info", Site);
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
        public object ExecuteDB_UpdateCarInfo(SM_Car_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Car_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteCarInfo(SM_Car_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_Car_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_QueryCarNo()
        {
            string rs;
            try
            {
                 rs = CommonDao.ExecuteQueryForObject<string>("selectSM_Car_InfoCarNo", null);
                if (rs == null)
                    rs = "C000000";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Car_Info> ExecuteDB_QueryAllByCarName(SM_Car_Info carinfo)
        {
            IList<SM_Car_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Car_Info>("selectSM_Car_InfoAllByName", carinfo);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
            
        }

        public IList<SM_Car_Info> ExecuteDB_QueryAllByCarName2(SM_Car_Info carinfo)
        {
            IList<SM_Car_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Car_Info>("selectSM_Car_InfoAllByName2", carinfo);

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
