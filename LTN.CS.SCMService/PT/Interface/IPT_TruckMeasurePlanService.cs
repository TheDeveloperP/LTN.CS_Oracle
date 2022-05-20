using LTN.CS.SCMEntities.PT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PT.Interface
{
   public  interface IPT_TruckMeasurePlanService
    {
        /// <summary>
        /// 根据条件查询汽车磅委托计划表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PT_TruckMeasurePlan> ExecuteDB_QueryTruckMeasurePlanByHashTable(Hashtable ht);
        /// <summary>
        /// 作废汽车磅委托计划表
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidTruckMeasurePlanByIntId(PT_TruckMeasurePlan TruckMeasurePlan);

        object ExecuteDB_UpdateStatTruckMeasurePlanByPlanNo(PT_TruckMeasurePlan TruckMeasurePlan);
        /// <summary>
        /// 
        /// <summary>
        /// 插入汽车磅委托计划表
        /// </summary>
        /// <param name="TruckMeasurePlan"></param>
        /// <returns></returns>
        object ExecuteDB_InsertTruckMeasurePlan(PT_TruckMeasurePlan TruckMeasurePlan);

        /// <summary>
        /// 
        /// <summary>
        /// 插入汽车磅委托计划表
        /// </summary>
        /// <param name="TruckMeasurePlan"></param>
        /// <returns></returns>
        object ExecuteDB_InsertTruckMeasurePlan2(PT_TruckMeasurePlan TruckMeasurePlan,string[] str);
        /// <summary>
        /// 修改汽车磅委托计划表
        /// </summary>
        /// <param name="TruckMeasurePlan"></param>
        /// <returns></returns>
        object ExecuteDB_UpdateTruckMeasurePlan(PT_TruckMeasurePlan TruckMeasurePlan);
        /// <summary>
        /// 构建流水号
        /// </summary>
        /// <returns></returns>
        string ExecuteDB_QueryPlanNoForCreatePlanNo();

        /// <summary>
        /// 根据车号和时间查询未过期的计划
        /// </summary>
        /// <returns></returns>
        IList<PT_TruckMeasurePlan> ExecuteDB_QueryTruckMeasureUsingPlan(Hashtable ht);
        /// <summary>
        /// 根据委托单号查询计划
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasureUsingPlanByPlanNo(string PlanNo);

        PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanId(int planId);
        PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanNo(string planNo);
        PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByfromdept(string fromdept);
        object ExecuteDB_UpdateTruckMeasurePlanForBatch(IList<PT_TruckMeasurePlan> list);

    }
}
