using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMGROUPDaoImpl : BaseDaoImp<BM_GROUP>, IBMGROUPDao
    {

        public BM_GROUP ExecuteQueryByName(string groupName)
        {
            return basedao.ExecuteQueryForObject<BM_GROUP>("SelectByBMGROUPName", groupName);
        }


        public IList<BM_GROUP> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_GROUP>("SelectAllBMGROUP", null);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMGROUP", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMGROUP", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMGROUP", parameterObject);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledGROUP", parameterObject);
        }
    }
}
