using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMMAINPAGEService
    {
        /// <summary>
        /// 根据用户查询用户拥有权限的菜单页
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<BM_MAIN_PAGE> ExecuteDB_QueryByUser(int userId);
        /// <summary>
        /// 查询所有的菜单页
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_PAGE> ExecuteDB_QueryAllPage();
        IList<BM_MAIN_PAGE> ExecuteDB_QueryAll();
        /// <summary>
        /// 根据菜单页名称查询
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_PAGE> ExecuteDB_QueryByPageName(string pageName);

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_MAIN_PAGE page);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Update(BM_MAIN_PAGE page);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_MAIN_PAGE page);

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        object ExecuteDB_Disabled(BM_MAIN_PAGE page);
    }
}
