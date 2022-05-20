using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_TareWeightService
    {
        IList<SM_TareWeight> ExecuteDB_QueryAll();
        IList<SM_TareWeightHistory> ExecuteDB_QueryHistoryAll();
        IList<SM_TareWeight> ExecuteDB_QueryAllByCondition(Hashtable condition);

        IList<SM_TareWeight> ExecuteDB_QueryAllByCarNo(string carNo);
        //2022.4.24 李佳政
        IList<SM_TareWeightHistory> ExecuteDB_QueryHistoryByCarName(string CarName);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertTareWeight(SM_TareWeight TareWeight);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateTareWeight(SM_TareWeight TareWeight);
        /// <summary>
        /// 修改使用状态
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateTareWeight2(SM_TareWeight TareWeight);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteTareWeight(SM_TareWeight TareWeight);

        SM_TareWeight ExecuteDB_QueryUsedByCarNo(string carNo);

        object ExecuteDB_InsertTareWeight2(SM_TareWeight TareWeight, string status, int IsExceed);

        //新增
        object ExecuteDB_UpdateTareWeight3(SM_TareWeight tareWeight);
    }
}
