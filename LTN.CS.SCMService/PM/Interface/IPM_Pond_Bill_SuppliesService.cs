using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Pond_Bill_SuppliesService
    {
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertSuppliesInfo(PM_Pond_Bill_Supplies pond);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateSuppliesInfo(PM_Pond_Bill_Supplies pond);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteSuppliesInfo(PM_Pond_Bill_Supplies pond);
        /// <summary>
        /// 作废铁水委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidSuppliesPondByIntId(PM_Pond_Bill_Supplies pond);
        /// <summary>
        /// 根据条件查询铁水磅单
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QuerySuppliesPondByHashTable(Hashtable ht);
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByDic(Hashtable dic);
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByGroup(string FormationTag);
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByPlanNo(string planNo);
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryByPond(Hashtable ht);
        PM_Pond_Bill_Supplies ExecuteDB_QueryByWgistonNo(string wgstion);
        /// <summary>
        /// 修改汽车磅单表(打印次数)
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePrint1(PM_Pond_Bill_Supplies TruckBill);
        /// <summary>
        /// 批量修改物资轨道衡磅单
        /// </summary>
        /// <param name="SuppliesBillWgtNos"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        object ExecuteDB_BatchUpdateSuppliesBill(List<string> SuppliesBillWgtNos, Hashtable ht);
        //新增
        IList<PM_Pond_Bill_Supplies> ExecuteDB_QueryHistoryByWagNo(Hashtable ht);


    }
}
