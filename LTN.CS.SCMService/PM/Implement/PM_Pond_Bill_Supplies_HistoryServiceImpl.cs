using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Pond_Bill_Supplies_HistoryServiceImpl : IPM_Pond_Bill_Supplies_HistoryService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_Supplies_History> ExecuteDB_QueryPM_Pond_Bill_Supplies_HistoryByHashtable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Supplies_History> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Supplies_History>("QueryPM_Pond_Bill_Supplies_HistoryByHashtable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
