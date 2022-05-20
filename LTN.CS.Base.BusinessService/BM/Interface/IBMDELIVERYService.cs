using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMDELIVERYService
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_DELIVERY page);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Update(BM_DELIVERY entity);

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_QueryEntityByStatus(params int[] args);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="history"></param>
        /// <returns></returns>
        object ExecuteDB_Quasi(BM_DELIVERY entity, BM_DELIVERY_HISTORY history);
        /// 审核取消
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="history"></param>
        /// <returns></returns>
        object ExecuteDB_UnQuasi(BM_DELIVERY entity);

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        object ExecuteDB_Confirm(BM_DELIVERY entity, BM_DELIVERY_HISTORY history);
    }
}
