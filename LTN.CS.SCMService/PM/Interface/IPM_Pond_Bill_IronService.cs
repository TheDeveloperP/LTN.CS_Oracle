using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Pond_Bill_IronService
    {
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertIronInfo(PM_Pond_Bill_Iron pond);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateIronInfo(PM_Pond_Bill_Iron pond);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteIronInfo(PM_Pond_Bill_Iron pond);
        /// <summary>
        /// 作废铁水委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidIronPondByIntId(PM_Pond_Bill_Iron pond);
        /// <summary>
        /// 根据条件查询铁水磅单
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryIronPondByHashTable(Hashtable ht);
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByDic(Hashtable dic);
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByGroup(string FormationTag);
        //新增
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryBySiteAndTagFormation(Hashtable ht);
    }
}
