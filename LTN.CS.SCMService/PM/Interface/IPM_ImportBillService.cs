using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_ImportBillService
    {
         object ExecuteDB_InsertPM_ImportBill(List<PM_ImportBill> ImportBills);
        IList<PM_ImportBill> ExecuteDB_QueryPM_ImportBill(Hashtable ht);
        /// <summary>
        /// 修改汽车磅单表(打印次数)
        /// </summary>
        /// <param name="Bill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePM_ImportBill(PM_ImportBill Bill);

    }
}
