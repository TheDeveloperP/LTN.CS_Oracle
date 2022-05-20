using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.IT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;
using System.Collections;

namespace LTN.CS.SCMService.IT.Implement
{
    public class IT_BeltScalePlanServiceImpl: IIT_BeltScalePlanService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<IT_BeltScalePlan> ExecuteDB_QueryByPlannoAndTime(Hashtable ht)
        {
            IList<IT_BeltScalePlan> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<IT_BeltScalePlan>("SelectIT_BeltScalePlanByCondition", ht);
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
