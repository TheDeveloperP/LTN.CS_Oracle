using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMMAINPAGEDao : IBaseDao<BM_MAIN_PAGE>
    {
        IList<BM_MAIN_PAGE> ExecuteQueryByUserId(int userId);
        IList<BM_MAIN_PAGE> ExecuteQueryByPageName(string pageName);
        IList<BM_MAIN_PAGE> ExecuteQueryAll();
    }
}
