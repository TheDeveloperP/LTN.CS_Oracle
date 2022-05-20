using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPond_ComplateTimeService
    {
        IList<Pond_ComplateTime> ExecuteDB_QueryAll(Hashtable ht);

        object ExecuteDB_InsertPondComplateInfo(Pond_ComplateTime obj);

        object ExecuteDB_UpdatePondComplateInfo(Hashtable ht);

        IList<Pond_ComplateTime> ExecuteDB_QueryUnComplecated();
        
        //新增皮带秤时长统计页面
        IList<PM_BeltTimeCount> ExecuteDB_QueryBeltTimeCountByConditions(Hashtable ht);
    }
}
