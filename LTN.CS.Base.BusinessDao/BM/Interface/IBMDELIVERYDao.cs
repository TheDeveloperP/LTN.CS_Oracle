using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Dao;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMDELIVERYDao : IBaseDao<BM_DELIVERY>
    {
        IList<BM_DELIVERY> QueryEntitiesByStatus(int status);
    }
}
