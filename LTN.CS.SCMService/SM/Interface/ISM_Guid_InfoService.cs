using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Guid_InfoService
    {
        object ExecuteDB_InsertGuidInfo(SM_Guid_Info Dvr);
    }
}
