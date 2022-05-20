using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMService.SM.Interface
{
   public interface ISM_Dvr_InfoService
    {
        IList<SM_Dvr_Info> ExecuteDB_QueryAll();
        IList<SM_Dvr_Info> ExecuteDB_QuerySingle(string name);
        IList<SM_Dvr_Info> ExecuteDB_QueryBySiteIp(string ip);

        object ExecuteDB_InsertDvrInfo(SM_Dvr_Info Dvr);

       object ExecuteDB_UpdateDvrInfo(SM_Dvr_Info Dvr);

        object ExecuteDB_DeleteDvrInfo(SM_Dvr_Info Dvr);

        SM_Dvr_Info ExecuteDB_QueryAllByPondId(int pondId);
    }
}
