using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_RawData_MoveTrainService
    {
        IList<PM_RawData_MoveTrain> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertRawDataInfo(PM_RawData_MoveTrain RawData);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateRawDataInfo(PM_RawData_MoveTrain RawData);

        object ExecuteDB_UpdateRawDataUse(PM_RawData_MoveTrain RawData);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteRawDataInfo(PM_RawData_MoveTrain RawData);
        /// <summary>
        /// 根据条件查询原始数据表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<PM_RawData_MoveTrain> ExecuteDB_QueryByHashTable(Hashtable ht);
        IList<QueryForMovedataNum> ExecuteDB_QueryBytag(Hashtable ht);
        IList<PM_RawData_MoveTrain> ExecuteDB_QueryBytagdata(Hashtable dic);
        IList<PM_RawData_MoveTrain> ExecuteDB_QueryByCar(string CarsNo);

        object ExecuteDB_InvalidRawDatByIntId(PM_RawData_MoveTrain RawData);
        //新增
        IList<PM_RawData_MoveTrain_New> ExecuteDB_QueryByHashTable_New(Hashtable ht);

        object ExecuteDB_InvalidRawDatByIntId_New(PM_RawData_MoveTrain_New RawData);

        object ExecuteDB_DeleteRawDataInfo_New(PM_RawData_MoveTrain_New RawData);
        object ExecuteDB_UpdateRawDataInfo_New(PM_RawData_MoveTrain_New RawData);

        object ExecuteDB_InsertRawDataInfo_New(PM_RawData_MoveTrain_New RawData);
    }
}
