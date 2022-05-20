using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMGROUPService
    {
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BM_GROUP ExecuteDB_QueryByName(string name);
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_GROUP> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InserGROUP(BM_GROUP group);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateGROUP(BM_GROUP group);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteGROUP(BM_GROUP group);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DisableDGROUP(BM_GROUP group);
    }
}
