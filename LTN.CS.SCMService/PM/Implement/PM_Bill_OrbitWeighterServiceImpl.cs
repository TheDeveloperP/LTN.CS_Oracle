using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Globalization;


namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_OrbitWeighterServiceImpl : IPM_Bill_OrbitWeighterService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_OrbitWeighter> ExecuteDB_QueryOrbitWeighterBillByHashTable(Hashtable ht)
        {
            IList<PM_Pond_Bill_OrbitWeighter> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_OrbitWeighter>("SelectPM_OrbitWeighterBillByCondition", ht);
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
