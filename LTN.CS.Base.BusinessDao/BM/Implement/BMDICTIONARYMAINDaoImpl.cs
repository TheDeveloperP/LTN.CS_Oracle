using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMDICTIONARYMAINDaoImpl : BaseDaoImp<BM_DICTIONARY_MAIN>, IBMDICTIONARYMAINDao
    {
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMDICTIONARYMAIN", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMDICTIONARYMAIN", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMDICTIONARYMAIN", parameterObject);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledBMDICTIONARYMAIN", parameterObject);
        }
        public IList<BM_DICTIONARY_MAIN> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_MAIN>("SelectAllBMDICTIONARYMAIN", null);
        }


        public IList<BM_DICTIONARY_MAIN> ExecuteQueryBYSN(string dicSn)
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_MAIN>("SelectByBMDICTIONARYMAINSN", dicSn);
        }

       
    }
}
