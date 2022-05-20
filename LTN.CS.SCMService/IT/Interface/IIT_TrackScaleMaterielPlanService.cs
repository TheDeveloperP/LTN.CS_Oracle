using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_TrackScaleMaterielPlanService
    {
         IList<IT_TrackScaleMaterielPlan> ExecuteDB_QueryAll();
        IList<IT_TrackScaleMaterielPlan> ExecuteDB_QueryIT_TrackScaleMaterielPlan(Hashtable ht);
    }
}
