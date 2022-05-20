using LTN.CS.SCMEntities.IT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_TruckMeasurePlanService
    {
        IList<IT_TruckMeasurePlan> ExecuteDB_QueryIT_TruckMeasurePlan(Hashtable ht);
    }
}
