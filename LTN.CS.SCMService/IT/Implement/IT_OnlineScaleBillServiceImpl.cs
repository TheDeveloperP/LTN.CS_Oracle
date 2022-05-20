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
    public class IT_OnlineScaleBillServiceImpl : IIT_OnlineScaleBillService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<IT_OnlineScaleBill> ExecuteDB_QueryByMatNoAndTime(Hashtable ht)
        {
            IList<IT_OnlineScaleBill> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<IT_OnlineScaleBill>("SelectIT_OnlineScaleBillByCondition", ht);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
