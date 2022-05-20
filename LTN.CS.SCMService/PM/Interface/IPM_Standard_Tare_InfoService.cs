using LTN.CS.SCMEntities.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Standard_Tare_InfoService
    {
        IList<PM_Standard_Tare_Info> ExecuteDB_QueryByCar(string CarsNo);
        object ExecuteDB_InsertTareInfo(PM_Standard_Tare_Info Tare);
        object ExecuteDB_UpdateTareInfo(PM_Standard_Tare_Info Tare);
    }
}
