using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.IT.Interface;

namespace LTN.CS.SCMService.IT.Implement
{
    public class IT_TruckMeasurePlanServiceImpl : IIT_TruckMeasurePlanService
    {
        public ICommonDao commonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<IT_TruckMeasurePlan> ExecuteDB_QueryIT_TruckMeasurePlan(Hashtable ht)
        {
            IList<IT_TruckMeasurePlan> result;
            try
            {
                result = commonDao.ExecuteQueryForList<IT_TruckMeasurePlan>("Select_IT_TruckMeasurePlan", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                result = null;
            }
            return result;
        }
    }
}
