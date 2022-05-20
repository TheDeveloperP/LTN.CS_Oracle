using System;
using System.Collections.Generic;

using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMGROUPUSERDao : IBaseDao<BM_GROUP_USER>
    {
        IList<BM_GROUP_USER> ExecuteQueryAll();
        IList<BM_GROUP_USER> ExecuteQueryByUserId(int id);
    }
}
