using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMService.SM.Interface
{
   public interface ISM_ErrorConfigService
    {
        IList<SM_ErrorConfig> ExecuteDB_QueryAll();
        IList<SM_ErrorConfig> ExecuteDB_QueryErrorConfigSingle(string GrossWgtError);
        object ExecuteDB_InsertErrorConfig(SM_ErrorConfig ErrorConfig);

       object ExecuteDB_UpdateErrorConfig(SM_ErrorConfig ErrorConfig);

        object ExecuteDB_DeleteErrorConfig(SM_ErrorConfig ErrorConfig);
    }
}
