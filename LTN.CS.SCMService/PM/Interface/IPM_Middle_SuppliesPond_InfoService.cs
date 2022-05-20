using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Middle_SuppliesPond_InfoService
    {
        IList<PM_Middle_SuppliesPond_Info> ExecuteDB_QueryByGroup(Hashtable ht);
        object ExecuteDB_InsertMiddleInfo(PM_Middle_SuppliesPond_Info Middle);
        object ExecuteDB_UpdateMiddleInfo(PM_Middle_SuppliesPond_Info Middle);
        object ExecuteDB_InvalidSuppliesMiddleByIntId(PM_Middle_SuppliesPond_Info Middle);
    }
}
