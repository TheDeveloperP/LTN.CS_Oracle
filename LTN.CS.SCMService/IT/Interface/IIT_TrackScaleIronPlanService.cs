using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_TrackScaleIronPlanService
    {
         IList<IT_TrackScaleIronPlan> ExecuteDB_QueryAll();
        IList<IT_TrackScaleIronPlan> ExecuteDB_QueryIT_TrackScaleIronPlan(Hashtable ht);
    }
}
