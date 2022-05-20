using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.BaseEntities.BM_Query;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMMAINGROUPSERVICEDao : IBaseDao<BM_MAIN_GROUP_SERVICE>
    {
        /// <summary>
        /// 查询服务名称
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryByServiceId(int serviceId);
        IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryByGroupId(int groupid);
        /// <summary>
        /// 查询用户By userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        BM_MAIN_GROUP_SERVICE ExecuteQueryByName(string userName);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryAll();
        /// <summary>
        /// 根据用户ID查询菜单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE_MENU> ExecuteQueryAllByUserId(SelectBMMAINGROUPSERVICEAll condition);

    }
}
