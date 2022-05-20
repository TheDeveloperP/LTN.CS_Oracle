using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.BaseEntities.BM_Query;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMMAINGROUPDao : IBaseDao<BM_MAIN_GROUP>
    {
        IList<BM_MAIN_GROUP> ExecuteQueryAllByUserId(SelectBMMAINGROUPAll condition);
        IList<BM_MAIN_GROUP> ExecuteQueryAll();
        IList<BM_MAIN_GROUP> ExecuteQueryByPageId(int pageid);
        IList<BM_MAIN_GROUP> ExecuteQueryByGroupName(string groupName);
        IList<BM_MAIN_GROUP> ExecuteQueryByIntId(int intid);
    }
}
