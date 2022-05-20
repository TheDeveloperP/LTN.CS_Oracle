using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.BaseEntities.BM_Query;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMMAINGROUPDaoImpl : BaseDaoImp<BM_MAIN_GROUP>, IBMMAINGROUPDao
    {
        public IList<BM_MAIN_GROUP> ExecuteQueryAllByUserId(SelectBMMAINGROUPAll condition)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP>("SelectByBMMAINGROUPUSER", condition);
        }

        public IList<BM_MAIN_GROUP> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP>("SelectAllBMMAINGROUP", null);
        }
        public IList<BM_MAIN_GROUP> ExecuteQueryByPageId(int pageid)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP>("SelectByPageId", pageid);
        }
        public IList<BM_MAIN_GROUP> ExecuteQueryByIntId(int pageid)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP>("SelectByIntId", pageid);
        }
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMMAINGROUP", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMMAINGROUP", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMMAINGROUP", parameterObject);
        }

        public IList<BM_MAIN_GROUP> ExecuteQueryByGroupName(string groupName)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP>("SelectByGroupName", groupName);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteUpdate("DisabledBMMAINGROUP", parameterObject);
        }
    }
}
