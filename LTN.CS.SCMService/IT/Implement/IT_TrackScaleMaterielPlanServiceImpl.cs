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
   public class IT_TrackScaleMaterielPlanServiceImpl : IIT_TrackScaleMaterielPlanService
    {
        public ICommonDao commonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
       

       public IList<IT_TrackScaleMaterielPlan> ExecuteDB_QueryAll()
       {
            IList<IT_TrackScaleMaterielPlan> rs;
           try
           {
               rs = commonDao.ExecuteQueryForList<IT_TrackScaleMaterielPlan>("SelectIT_TrackScaleIronPlanAll", null);
           }
           catch (Exception ex)
           {
                log.Error(ex.ToString());
                rs = null;

            }
            return rs;
        }

       public IList<IT_TrackScaleMaterielPlan> ExecuteDB_QueryIT_TrackScaleMaterielPlan(Hashtable ht)
       {
            IList<IT_TrackScaleMaterielPlan> rs;
            try
            {
                rs = commonDao.ExecuteQueryForList<IT_TrackScaleMaterielPlan>("SelectIT_TrackScaleMaterielPlanByCondition", ht);
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
