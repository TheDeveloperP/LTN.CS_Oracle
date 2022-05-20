using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_JZXH_InfoService
    {
        IList<SM_JZXH_Info> ExecuteDB_QueryAll();
        SM_JZXH_Info ExecuteDB_QueryByCarNameAndPond(Hashtable ht);
        IList<SM_JZXH_Info> ExecuteDB_QueryByCarName(Hashtable ht);
    }
}
