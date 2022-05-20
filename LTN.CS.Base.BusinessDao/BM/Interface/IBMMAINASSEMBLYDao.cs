using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.BaseEntities.BM_Query;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMMAINASSEMBLYDao : IBaseDao<BM_MAIN_ASSEMBLY>
    {
        IList<BM_MAIN_ASSEMBLY> ExecuteQueryAll();
        BM_MAIN_ASSEMBLY ExecuteQueryById(int id);
        IList<BM_MAIN_ASSEMBLY> SelectByAssemblyName(string assemblyName);
    }
}
