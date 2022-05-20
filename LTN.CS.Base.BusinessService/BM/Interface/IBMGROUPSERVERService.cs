using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMGROUPSERVERService
    {
        /// <summary>
        /// 新增服务
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_SERVICE_GROUP obj);
        /// <summary>
        /// 删除服务
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_SERVICE_GROUP obj);
    }
}
