using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.PT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_TruckService
    {
        /// <summary>
        /// 根据条件查询汽车磅单表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByHashtable(Hashtable ht);

        /// <summary>
        /// 修改汽车磅单表
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePM_Bill_Truck(PM_Bill_Truck TruckBill);


        /// <summary>
        /// 修改汽车磅单表
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePM_Bill_Truck2(PM_Bill_Truck TruckBill,bool isFu);
        /// <summary>
        /// 修改汽车磅单表(打印次数)
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePM_Bill_Truck3(PM_Bill_Truck TruckBill);

        /// <summary>
        /// 画面自定义新增汽车磅单
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_InsertPM_Bill_Truck(PM_Bill_Truck TruckBill);

        /// <summary>
        /// 坐席新增汽车磅单
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_InsertPM_Bill_Truck2(PM_Bill_Truck TruckBill, bool isUpdate, PM_Bill_Truck TruckBill2);

        /// <summary>
        /// 查询计划
        /// </summary>
        /// <param name="PlanNo"></param>
        /// <returns></returns>
        PT_TruckMeasurePlan ExecuteDB_QueryTruckMeasurePlanByPlanNo(string PlanNo);

        /// <summary>
        /// 作废磅单
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidPM_Bill_Truck(PM_Bill_Truck TruckBill);

        object ExecuteDB_InvalidPM_TruckMeasure(string planNo,int state);

        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByCarNo(string ht);
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByCarNo2(string ht);
        PM_Bill_Truck ExecuteDB_QueryBillTruckByPlanNo(Hashtable ht);

        IList<PM_Bill_Truck> ExecuteDB_QueryLatestPM_Bill_TruckByCarNo(string carNo);

        PM_Bill_Truck ExecuteDB_QueryBillTruckByWgistonNo(string wgstion);

        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPond(Hashtable ht);
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForAFourOne(Hashtable ht);
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForAFourTwo(Hashtable ht);
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPond2(Hashtable ht);
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByPondForjincai(Hashtable ht);
        /// <summary>
        /// 根据条件查询汽车磅单历史表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Bill_Truck_History> ExecuteDB_QueryPM_Bill_TruckHistoryByHashtable(Hashtable ht);

        object ExecuteDB_BatchUpdateTruckBill(List<string> TruckBillWgtNos, Hashtable ht);

        //新增
        IList<PM_Bill_Truck> ExecuteDB_QueryPM_Bill_TruckByHashtable_ForHuda(Hashtable ht);
    }
}
