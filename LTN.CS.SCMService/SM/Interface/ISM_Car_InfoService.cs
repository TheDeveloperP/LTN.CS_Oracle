using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Car_InfoService
    {
        IList<SM_Car_Info> ExecuteDB_QueryAll();
        
        IList<SM_Car_Info> ExecuteDB_QueryAllByCarName(SM_Car_Info carinfo);
        IList<SM_Car_Info> ExecuteDB_QueryAllByCarName2(SM_Car_Info carinfo);
        object ExecuteDB_QueryCarNo();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertCarInfo(SM_Car_Info Site);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateCarInfo(SM_Car_Info Site);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteCarInfo(SM_Car_Info Site);
    }
}
