using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM_Query;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMMAINGROUPSERVICEService
    {
        /// <summary>
        /// 根据id查询服务名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryById(int id);
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BM_MAIN_GROUP_SERVICE ExecuteDB_QueryByName(string name);
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryAll();
        IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryByGroupId(int groupid);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InserUser(BM_MAIN_GROUP_SERVICE user);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateUser(BM_MAIN_GROUP_SERVICE user);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteUser(BM_MAIN_GROUP_SERVICE user);
        /// <summary>
        /// 根据用户ID查询菜单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP_SERVICE_MENU> ExecuteDB_QueryAllByUserId(SelectBMMAINGROUPSERVICEAll condition);
        /// <summary>
        /// 禁用菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_DisableSERVICEMENU(BM_MAIN_GROUP_SERVICE menu);
    }
}
