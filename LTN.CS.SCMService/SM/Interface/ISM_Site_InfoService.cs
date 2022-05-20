using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.SCMService.SM.Interface
{
   public interface ISM_Site_InfoService
    {
        IList<SM_Site_Info> ExecuteDB_QueryAll();
        IList<SM_Site_Info> ExecuteDB_QueryBySiteId(string name);
        IList<SM_Site_Info> ExecuteDB_QueryBySiteIp(string ip);

        object ExecuteDB_InsertSiteInfo(SM_Site_Info Site);

       object ExecuteDB_UpdateSiteInfo(SM_Site_Info Site);

        object ExecuteDB_DeleteSiteInfo(SM_Site_Info Site);

        IList<DM_Site_Info_WCF> ExecuteDB_QueryBySiteIp2(string ip);
    }
}
