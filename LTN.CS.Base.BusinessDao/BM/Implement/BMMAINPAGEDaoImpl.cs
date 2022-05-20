using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMMAINPAGEDaoImpl : BaseDaoImp<BM_MAIN_PAGE>, IBMMAINPAGEDao
    {
        public IList<BM_MAIN_PAGE> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_MAIN_PAGE>("SelectByBMMAINPAGEAll", null);
        }
        public IList<BM_MAIN_PAGE> ExecuteQueryByUserId(int userId)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_PAGE>("SelectByBMMAINPAGEUSER", userId);
        }

        public override IList<T> ExecuteQueryForList<T>(object parameterObject)
        {
            return basedao.ExecuteQueryForList<T>("SelectAllBMMAINPAGE", parameterObject);
        }

        public IList<BM_MAIN_PAGE> ExecuteQueryByPageName(string pageName)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_PAGE>("SelectByBMPageName", pageName);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMMAINPAGE", parameterObject);
        }

        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMMAINPAGE", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMMAINPAGE", parameterObject);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteUpdate("DisabledMAINPAGE", parameterObject);
        }
    }
}
