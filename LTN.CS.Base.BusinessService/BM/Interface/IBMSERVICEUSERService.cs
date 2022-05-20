using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMSERVICEUSERService
    {
        /// <summary>
        /// 新增用户权限
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_SERVICE_USER obj);
        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_SERVICE_USER obj);

    }
}
