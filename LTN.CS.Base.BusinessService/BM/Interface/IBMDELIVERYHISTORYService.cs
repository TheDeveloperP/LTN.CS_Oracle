using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMDELIVERYHISTORYService
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_DELIVERY_HISTORY page);
        /// <summary>
        /// 根据主表ID查询实体
        /// </summary>
        /// <returns></returns>
        IList<BM_DELIVERY_HISTORY> ExecuteDB_QueryByMainId(int mainId);
    }
}
