using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMUSERService
    {
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object ExecuteDB_QueryByName(string name);
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_USER> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InserUser(BM_USER user);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateUser(BM_USER user);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteUser(BM_USER user);

        /// <summary>
        /// 查询群组外用户
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IList<BM_USER> ExecuteDB_QueryNotInGroup(int groupId);

        /// <summary>
        /// 查询群组内用户
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IList<BM_USER> ExecuteDB_QueryInGroup(int groupId);
        /// <summary>
        /// 查询商家管理员外用户
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IList<BM_USER> ExecuteDB_QueryNotInBusinessManager(int BusinessId);

        /// <summary>
        /// 查询商家管理员内用户
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IList<BM_USER> ExecuteDB_QueryInBusinessManager(int BusinessId);
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_DisableUser(BM_USER user); 
    }
}
