using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;


namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMGROUPUSERDaoImpl : BaseDaoImp<BM_GROUP_USER>, IBMGROUPUSERDao
    {
        public IList<BM_GROUP_USER> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_GROUP_USER>("SelectAllBMGROUPUSER", null);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMGROUPUSER", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMGROUPUSER", parameterObject);
        }
        public IList<BM_GROUP_USER> ExecuteQueryByUserId(int id)
        {
            return basedao.ExecuteQueryForList<BM_GROUP_USER>("SelectBMGROUPUSERBYUSERID", id);
        }
    }
}
