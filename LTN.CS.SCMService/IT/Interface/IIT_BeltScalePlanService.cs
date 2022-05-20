using LTN.CS.SCMEntities.IT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_BeltScalePlanService
    {
        IList<IT_BeltScalePlan> ExecuteDB_QueryByPlannoAndTime(Hashtable ht);
    }
}
