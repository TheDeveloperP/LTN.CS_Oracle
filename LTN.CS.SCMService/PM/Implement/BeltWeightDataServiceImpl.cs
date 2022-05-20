using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.SCMEntities.PM;
using System.Collections;

namespace LTN.CS.SCMService.PM.Implement
{
    public class BeltWeightDataServiceImpl : IBeltWeightDataService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<BeltWeightData> ExecuteDB_QueryBeltWeightDataByHashtable(Hashtable ht)
        {
            IList<BeltWeightData> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<BeltWeightData>("QueryBeltWeightDataByHashtable", ht);
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
