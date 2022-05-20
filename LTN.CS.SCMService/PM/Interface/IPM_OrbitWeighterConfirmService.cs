using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_OrbitWeighterConfirmService
    {
        IList<PM_Bill_OrbitWeighterConfirm> ExecuteDB_QueryOrbitWeighterBillByHashTable(Hashtable ht);

        //IList<PM_Bill_OnlineScale> ExecuteDB_QueryOnlineScaleBillByHashTable2(Hashtable ht);

        
    }
}
