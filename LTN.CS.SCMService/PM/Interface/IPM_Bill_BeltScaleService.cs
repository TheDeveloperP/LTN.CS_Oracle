using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_BeltScaleService
    {
        /// <summary>
        /// 根据条件查询皮带秤磅单表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable(Hashtable ht);

        IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable2(Hashtable ht);

        /// <summary>
        /// 修改皮带秤磅单表
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatePM_Bill_Belt(PM_Bill_Belt TruckBill);


        /// <summary>
        /// 新增皮带秤磅单
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <returns></returns>
        object ExecuteDB_InsertPM_Bill_Belt(PM_Bill_Belt TruckBill);



        /// <summary>
        /// 作废皮带秤磅单
        /// </summary>
        /// <param name="IntId"></param>
        /// <returns></returns>
        object ExecuteDB_InvalidPM_Bill_Belt(PM_Bill_Belt TruckBill);

        /// <summary>
        /// 查询皮带秤服务日志记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_Belt_ServerLog> ExecuteDB_QueryBeltServerLog(Hashtable ht);
    }
}
