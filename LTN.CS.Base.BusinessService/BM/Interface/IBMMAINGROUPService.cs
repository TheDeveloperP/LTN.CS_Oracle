using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM_Query;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMMAINGROUPService
    {
        /// <summary>
        /// 根据用户查询菜单组
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP> ExecuteDB_QueryAllByUserId(SelectBMMAINGROUPAll condition);
        /// <summary>
        /// 根据菜单页查询菜单组
        /// </summary>
        /// <param name="pageid"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP> ExecuteDB_QueryByPageId(int pageid);
        /// <summary>
        /// 查询所有菜单组
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_GROUP> ExecuteDB_QueryAll();
        /// <summary>
        /// 根据IntId查询菜单组
        /// </summary>
        /// <param name="intid"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP> ExecuteDB_QueryByIntId(int intid);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="mainGroup"></param>
        /// <returns></returns>
        object ExecuteDB_InsertMainGroup(BM_MAIN_GROUP mainGroup);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mainGroup"></param>
        /// <returns></returns>
        object ExecuteDB_UpdateMainGroup(BM_MAIN_GROUP mainGroup);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mainGroup"></param>
        /// <returns></returns>
        object ExecuteDB_DeleteMainGroup(BM_MAIN_GROUP mainGroup);
        /// <summary>
        /// 根据分组名称查询菜单组
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        IList<BM_MAIN_GROUP> ExecuteDB_QueryByGroupName(string groupName);

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="mainGroup"></param>
        /// <returns></returns>
        object ExecuteDB_DisabledMainGroup(BM_MAIN_GROUP mainGroup);
    }
}
