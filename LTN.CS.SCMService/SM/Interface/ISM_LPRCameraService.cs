using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_LPRCameraService
    {
        IList<SM_LPRCamera> ExecuteDB_QueryAll();
        IList<SM_LPRCamera> ExecuteDB_QueryByLPRName(string name);
        IList<SM_LPRCamera> ExecuteDB_QueryBySiteIp(string ip);

        SM_LPRCamera ExecuteDB_QueryByLprId(int lprId);

        object ExecuteDB_InsertLPRInfo(SM_LPRCamera LPR);

        object ExecuteDB_UpdateLPRInfo(SM_LPRCamera LPR);

        object ExecuteDB_DeleteLPRInfo(SM_LPRCamera LPR);
    }
}
