using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMDICTIONARYDETAILDaoImpl : BaseDaoImp<BM_DICTIONARY_DETAIL>, IBMDICTIONARYDETAILDao
    {
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMDICTIONARYDETAIL", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMDICTIONARYDETAIL", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMDICTIONARYDETAIL", parameterObject);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledBMDICTIONARYDETAIL", parameterObject);
        }
        public IList<BM_DICTIONARY_DETAIL> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_DETAIL>("SelectAllBMDICTIONARYDETAIL", null);
        }


        public IList<BM_DICTIONARY_DETAIL> ExecuteQueryBYSN(string dicSn)
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_DETAIL>("SelectByBMDICTIONARYDETAILSN", dicSn);
        }

        public int ExecuteQueryCountBYSN(BM_DICTIONARY_DETAIL dic)
        {
            return basedao.ExecuteQueryForObject<int>("BMDICTIONARYDETAILBYSNExists", dic);
        }

        public BM_DICTIONARY_DETAIL ExecuteQueryBYSNAndDes(string dicSn, string des)
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_DETAIL>("SelectByBMDICTIONARYDETAILSN", dicSn).FirstOrDefault(e => e.DicDesc == des);
        }

        public BM_DICTIONARY_DETAIL ExecuteQueryBYDESC(BM_DICTIONARY_DETAIL dicDesc)
        {
            return basedao.ExecuteQueryForObject<BM_DICTIONARY_DETAIL>("SelectByBMDICTIONARYDETAILDESC", dicDesc);
        }
        public BM_DICTIONARY_DETAIL ExecuteQueryAllBYDESC(BM_DICTIONARY_DETAIL dicDesc)
        {
            return basedao.ExecuteQueryForObject<BM_DICTIONARY_DETAIL>("SelectAllByBMDICTIONARYDETAILDESC", dicDesc);
        }
        public IList<BM_DICTIONARY_DETAIL> ExecuteQueryBYDICDESC(BM_DICTIONARY_DETAIL dicDesc)
        {
            return basedao.ExecuteQueryForList<BM_DICTIONARY_DETAIL>("SelectSaveTimeByDICDESC", dicDesc);
        }
    }
}
