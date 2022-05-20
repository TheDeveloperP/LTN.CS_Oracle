using LTN.CS.SCMEntities.PT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PT.Interface
{
    public interface IPT_BeltScalePlanService
    {
        /// <summary>
        /// 根据条件查询皮带秤委托计划表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PT_BeltScalePlan> ExecuteDB_QueryBeltScalePlanByHashTable(Hashtable ht);
        /// <summary>
        /// 作废皮带秤委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidBeltScalePlanByIntId(PT_BeltScalePlan BeltScalePlan);

        /// <summary>
        /// 修改皮带秤委托计划表
        /// </summary>
        /// <param name="BeltScalePlan"></param>
        /// <returns></returns>
        object ExecuteDB_UpdateBeltScalePlanByPlanNo(PT_BeltScalePlan BeltScalePlan);
        /// <summary>
        /// 
        /// <summary>
        /// 插入皮带秤委托计划表
        /// </summary>
        /// <param name="TruckMeasurePlan"></param>
        /// <returns></returns>
        object ExecuteDB_InsertBeltScalePlan(PT_BeltScalePlan BeltScalePlan);     

        //22-04-10 潘鹏新增
        IList<PT_BeltScalePlan> ExecuteDB_QueryBeltPlanByConditions(Hashtable ht);
    }
}
