using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMUSERDao : IBaseDao<BM_USER>
    {
        /// <summary>
        /// 查询用户By userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        BM_USER ExecuteQueryByName(string userName);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_USER> ExecuteQueryAll();

        IList<BM_USER> ExecuteQueryNotInGroup(int groupId);

        IList<BM_USER> ExecuteQueryInGroup(int groupId);

        IList<BM_USER> ExecuteQueryNotInBusinessManager(int BusinessId);

        IList<BM_USER> ExecuteQueryInBusinessManager(int BusinessId);
    }
}
