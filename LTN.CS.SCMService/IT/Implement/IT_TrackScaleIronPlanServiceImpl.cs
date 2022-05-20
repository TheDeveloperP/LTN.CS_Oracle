using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.IT;
using LTN.CS.SCMService.IT.Interface;

namespace LTN.CS.SCMService.IT.Implement
{
   public class IT_TrackScaleIronPlanServiceImpl: IIT_TrackScaleIronPlanService
    {
        public ICommonDao commonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
       

       public IList<IT_TrackScaleIronPlan> ExecuteDB_QueryAll()
       {
            IList<IT_TrackScaleIronPlan> rs;
           try
           {
               rs = commonDao.ExecuteQueryForList<IT_TrackScaleIronPlan>("SelectIT_TrackScaleIronPlanAll", null);
           }
           catch (Exception ex)
           {
                log.Error(ex.ToString());
                rs = null;

            }
            return rs;
        }

       public IList<IT_TrackScaleIronPlan> ExecuteDB_QueryIT_TrackScaleIronPlan(Hashtable ht)
       {
            IList<IT_TrackScaleIronPlan> rs;
            try
            {
                rs = commonDao.ExecuteQueryForList<IT_TrackScaleIronPlan>("SelectIT_TrackScaleIronPlanByCondition", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                rs = null;

            }
            return rs;
        }
    }
}
