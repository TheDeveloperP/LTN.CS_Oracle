using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_PoundService_InfoService
    {
        IList<SM_PoundService_Info> ExecuteDB_QueryAll();
        IList<SM_PoundService_Info> ExecuteDB_QueryAllByPoundId(int PoundId);
        IList<SM_PoundService_Info> ExecuteDB_QueryAllByCondition(Hashtable condition);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertPoundInfo(SM_PoundService_Info PoundInfo);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdatePoundInfo(SM_PoundService_Info PoundInfo);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeletePoundInfo(SM_PoundService_Info PoundInfo);

        SM_PoundService_Info ExecuteDB_QueryAllByPondId(int pondid);

    }
}
