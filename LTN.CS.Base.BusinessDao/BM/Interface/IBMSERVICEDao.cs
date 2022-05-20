using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Dao;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMSERVICEDao : IBaseDao<BM_SERVICE>
    {
        BM_SERVICE ExecuteQueryByNo(string serviceNo);
        BM_SERVICE ExecuteQueryById(int serviceId);
        IList<BM_SERVICE> ExecuteQueryByServerId(int serviceNo);
        IList<BM_SERVICE> ExecuteQueryByIntId(int intid);
        IList<BM_SERVICE> ExecuteQueryAll();
        /// <summary>
        /// 查询出群组内的服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteQueryInGroup(int GroupId);
        /// <summary>
        /// 查询出群组外的服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteQueryNotInGroup(int GroupId);
        /// <summary>
        /// 查询出群组内的服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteQueryInUser(int UserId);
        /// <summary>
        /// 查询出群组外的服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteQueryNotInUser(int UserId);



        object ExecuteLimited(object parameterObject);
    }
}
