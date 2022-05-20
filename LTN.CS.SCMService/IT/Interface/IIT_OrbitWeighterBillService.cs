using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LTN.CS.SCMEntities.IT;

namespace LTN.CS.SCMService.IT.Interface
{
    public interface IIT_OrbitWeighterBillService
    {
        IList<IT_OrbitWeighterBill> ExecuteDB_QueryByMatNoAndTime(Hashtable ht);
    }
}
