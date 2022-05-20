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
    public class IT_OrbitWeighterBillServiceImpl:IIT_OrbitWeighterBillService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<IT_OrbitWeighterBill> ExecuteDB_QueryByMatNoAndTime(Hashtable ht)
        {
            IList<IT_OrbitWeighterBill> rs;
            try
            {                
                rs = CommonDao.ExecuteQueryForList<IT_OrbitWeighterBill>("SelectIT_OrbitWeighterBillByCondition", ht);
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
