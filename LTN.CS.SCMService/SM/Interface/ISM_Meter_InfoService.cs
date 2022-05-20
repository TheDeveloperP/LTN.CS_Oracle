using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Meter_InfoService
    {
        IList<SM_Meter_Info> ExecuteDB_QueryAll();
        IList<SM_Meter_Info> ExecuteDB_QueryMeterSingle(string name);
     
        object ExecuteDB_InsertMeterInfo(SM_Meter_Info Meter);

        object ExecuteDB_UpdateMeterInfo(SM_Meter_Info Meter);

        object ExecuteDB_DeleteMeterInfo(SM_Meter_Info Meter);
    }
}
