using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_ReasonForNoAutoService
    {
        IList<SM_ReasonForNoAuto> ExecuteDB_QueryAll();
        IList<SM_ReasonForNoAuto> ExecuteDB_QueryByCondition(Hashtable ht);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertReasonInfo(SM_ReasonForNoAuto ReasonInfo);

    }
}
