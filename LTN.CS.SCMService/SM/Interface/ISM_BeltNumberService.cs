using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_BeltNumberService
    {
        IList<SM_BeltNumber> ExecuteDB_QueryAll();
        
        IList<SM_BeltNumber> ExecuteDB_QueryBeltNumberByBeltNo(string beltno);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertBeltbitInfo(SM_BeltNumber belt);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateBeltbitInfo(SM_BeltNumber belt);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteBeltbitInfo(SM_BeltNumber belt);
    }
}
