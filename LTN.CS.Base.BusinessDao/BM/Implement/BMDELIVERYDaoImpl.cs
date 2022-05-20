using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Dao;
using LTN.CS.Base.BusinessDao.BM.Interface;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMDELIVERYDaoImpl : BaseDaoImp<BM_DELIVERY>, IBMDELIVERYDao
    {
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMDELIVERY", parameterObject);
        }
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMDELIVERY", parameterObject);
        }
       
        public IList<BM_DELIVERY> QueryEntitiesByStatus(int status)
        {
            return basedao.ExecuteQueryForList<BM_DELIVERY>("selectBMDELIVERYBYStatus", status);
        }
    }
}
