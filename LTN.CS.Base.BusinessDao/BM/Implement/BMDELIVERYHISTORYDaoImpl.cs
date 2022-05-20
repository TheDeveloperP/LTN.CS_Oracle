using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Dao;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMDELIVERYHISTORYDaoImpl : BaseDaoImp<BM_DELIVERY_HISTORY>,IBMDELIVERYHISTORYDao
    {
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMDELIVERYHISTORY", parameterObject);
        }

        public IList<BM_DELIVERY_HISTORY> QueryEntitiesByMainId(int mainId)
        {
            return basedao.ExecuteQueryForList<BM_DELIVERY_HISTORY>("selectBMDELIVERYHISTORYBYMainId", mainId);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("deleteBMDELIVERYHISTORY", parameterObject);
        }


        public object QueryMaxIdByMainId(int mainId)
        {
            return basedao.ExecuteQueryForObject<object>("GetBMDELIVERYHISTORYMaxIDByMainId", mainId);
        }
    }
     
}
