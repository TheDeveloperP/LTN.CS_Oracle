using LTN.CS.SCMService.IT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;

namespace LTN.CS.SCMService.IT.Implement
{
    public class IT_BeltStopScalePlanServiceImpl : IIT_BeltStopScalePlanService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<IT_BeltStopScalePlan> ExecuteDB_QueryByPlannoAndTime(Hashtable ht)
        {
            IList<IT_BeltStopScalePlan> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<IT_BeltStopScalePlan>("SelectIT_BeltStopScalePlanByCondition", ht);
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
