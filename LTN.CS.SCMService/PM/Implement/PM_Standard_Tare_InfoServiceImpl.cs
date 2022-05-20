using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Standard_Tare_InfoServiceImpl: IPM_Standard_Tare_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertTareInfo(PM_Standard_Tare_Info Tare)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Standard_Tare_Info", Tare);
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
        public object ExecuteDB_UpdateTareInfo(PM_Standard_Tare_Info Tare)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("UpdatePM_Standard_Tare_Info", Tare);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public IList<PM_Standard_Tare_Info> ExecuteDB_QueryByCar(string CarsNo)
        {
            IList<PM_Standard_Tare_Info> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Standard_Tare_Info>("selectPM_Standard_Tare_InfoByCar", CarsNo);
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
