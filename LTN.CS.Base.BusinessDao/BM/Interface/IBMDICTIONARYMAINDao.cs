using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Dao;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMDICTIONARYMAINDao : IBaseDao<BM_DICTIONARY_MAIN>
    {
        IList<BM_DICTIONARY_MAIN> ExecuteQueryAll();
        IList<BM_DICTIONARY_MAIN> ExecuteQueryBYSN(string dicSn);
       
    }
}
