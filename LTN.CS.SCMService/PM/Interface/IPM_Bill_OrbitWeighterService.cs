using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_OrbitWeighterService
    {
        IList<PM_Pond_Bill_OrbitWeighter> ExecuteDB_QueryOrbitWeighterBillByHashTable(Hashtable ht);
    }
}
