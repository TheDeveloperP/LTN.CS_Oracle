using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMDICTIONARYDETAILDao : IBaseDao<BM_DICTIONARY_DETAIL>
    {
        IList<BM_DICTIONARY_DETAIL> ExecuteQueryAll();
        IList<BM_DICTIONARY_DETAIL> ExecuteQueryBYSN(string dicSn);
        /// <summary>
        /// 查询实体数量
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        int ExecuteQueryCountBYSN(BM_DICTIONARY_DETAIL dic);
        /// <summary>
        /// 根据SN和Des查询实体
        /// </summary>
        /// <param name="dicSn"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        BM_DICTIONARY_DETAIL ExecuteQueryBYSNAndDes(string dicSn, string des);
        BM_DICTIONARY_DETAIL ExecuteQueryBYDESC(BM_DICTIONARY_DETAIL dicDesc);
        BM_DICTIONARY_DETAIL ExecuteQueryAllBYDESC(BM_DICTIONARY_DETAIL dicDesc);
        IList<BM_DICTIONARY_DETAIL> ExecuteQueryBYDICDESC(BM_DICTIONARY_DETAIL dicDesc);
    }
}
