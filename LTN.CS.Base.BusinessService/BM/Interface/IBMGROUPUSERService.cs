using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMGROUPUSERService
    {
        IList<BM_GROUP_USER> ExecuteDB_QueryAll();

        object ExecuteDB_InserGroupUser(BM_GROUP_USER user);

        object ExecuteDB_DeleteGroupUser(BM_GROUP_USER user);

        IList<BM_GROUP_USER> ExecuteDB_QueryByUserId(int id);
    }
}
