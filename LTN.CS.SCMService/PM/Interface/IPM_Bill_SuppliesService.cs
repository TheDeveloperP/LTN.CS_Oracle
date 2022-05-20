using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_SuppliesService
    {
        IList<PM_Bill_Supplies> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertSuppliesInfo(PM_Bill_Supplies Supplies);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateSuppliesInfo(PM_Bill_Supplies Supplies);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteSuppliesInfo(PM_Bill_Supplies Supplies);
        /// <summary>
        /// 作废物资委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidSuppliesPlanByIntId(PM_Bill_Supplies Supplies);
        /// <summary>
        /// 根据条件查询物资委托计划表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Bill_Supplies> ExecuteDB_QuerySuppliesPlanByHashTable(Hashtable ht);
        IList<PM_Bill_Supplies> ExecuteDB_QuerySuppliesByPlan(string PlanNo);
        IList<PM_Bill_Supplies> ExecuteDB_QueryIronByCarNo(string CarNo);
        IList<PM_Bill_Supplies> ExecuteDB_QueryIronByWgtNo(string WgtNo);
        /// <summary>
        /// 查询静轨计划
        /// </summary>
        /// <param name="Hashtable"></param>
        /// <param name=""></param>
        /// <returns></returns>
        IList<PM_Bill_Supplies> ExecuteDB_QueryIronByStatic(Hashtable ht);
    }
}
