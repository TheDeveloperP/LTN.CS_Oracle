using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMGROUPDao : IBaseDao<BM_GROUP>
    {
        /// <summary>
        /// 查询用户By userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        BM_GROUP ExecuteQueryByName(string userName);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_GROUP> ExecuteQueryAll();
    }
}
