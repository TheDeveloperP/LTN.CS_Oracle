using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_BlackListService
    {
        IList<SM_BlackList> ExecuteDB_QueryAll();
        IList<SM_BlackListHistory> ExecuteDB_QueryHistoryAll();
        IList<SM_BlackList> ExecuteDB_QueryBlackListByCarName(string name);
        IList<SM_BlackList> ExecuteDB_QueryBlackListByCarName2(string name);
        IList<SM_BlackListHistory> ExecuteDB_QueryBlackListHistoryByCarName(string name);
        /// <summary>
        /// 新增黑名单
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertBlackList(SM_BlackList blacklist);
        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteBlackList(SM_BlackList blacklist);

        /// <summary>
        /// 新增黑名单历史
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertBlackListHistory(SM_BlackListHistory blacklist);
        /// <summary>
        /// 删除黑名单历史
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteBlackListHistory(SM_BlackListHistory blacklist);

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        DateTime ExecuteDB_GetDBTimeNow();
    }
}
