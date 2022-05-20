using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Pond_Bill_Supplies_HistoryService
    {
        IList<PM_Pond_Bill_Supplies_History> ExecuteDB_QueryPM_Pond_Bill_Supplies_HistoryByHashtable(Hashtable ht);
    }
}
