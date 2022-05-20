using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_IronService
    {
        IList<PM_Bill_Iron> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertIronInfo(PM_Bill_Iron Iron);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateIronInfo(PM_Bill_Iron Iron);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteIronInfo(PM_Bill_Iron Iron);
        /// <summary>
        /// 作废铁水委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidIronPlanByIntId(PM_Bill_Iron Iron);
        /// <summary>
        /// 根据条件查询铁水委托计划表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Bill_Iron> ExecuteDB_QueryIronPlanByHashTable(Hashtable ht);
        IList<PM_Bill_Iron> ExecuteDB_QueryIronByPlan(string PlanNo);
        IList<PM_Bill_Iron> ExecuteDB_QueryIronByCarNo(string CarNo);
    }
}
