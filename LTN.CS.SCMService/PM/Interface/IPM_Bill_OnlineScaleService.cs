using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_OnlineScaleService
    {
        IList<PM_Bill_OnlineScale> ExecuteDB_QueryOnlineScaleBillByHashTable(Hashtable ht);

        IList<PM_Bill_OnlineScale> ExecuteDB_QueryOnlineScaleBillByHashTable2(Hashtable ht);

        /// <summary>
        /// 查询在线称数据比对
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_TruckBillWithOnlineBill> ExecuteDB_QueryTruckBillWithOnlineBills(Hashtable ht);
    }
}
