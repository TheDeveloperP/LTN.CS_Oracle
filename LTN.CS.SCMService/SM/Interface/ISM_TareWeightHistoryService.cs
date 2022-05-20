using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_TareWeightHistoryService
    {
        IList<SM_TareWeightHistory> ExecuteDB_QueryAll();
        IList<SM_TareWeightHistory> ExecuteDB_QueryByCarnameAndTime(Hashtable ht);
        /// <summary>
        /// 删除皮重库历史
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteHistoryTare(SM_TareWeightHistory tarehistory);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertHistoryTare(SM_TareWeightHistory TareHistory);
    }
}
