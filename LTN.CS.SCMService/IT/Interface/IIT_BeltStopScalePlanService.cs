using LTN.CS.SCMEntities.IT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_BeltStopScalePlanService
    {
        IList<IT_BeltStopScalePlan> ExecuteDB_QueryByPlannoAndTime(Hashtable ht);
    }
}
