using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Department_LevelOne_InfoService
    {
        IList<SM_Department_LevelOne_Info> ExecuteDB_QueryAll();
        IList<SM_Department_LevelOne_Info> ExecuteDB_QueryByDeptName(string Deptname);
        object ExecuteDB_QueryDepartmentCode();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertDepartment(SM_Department_LevelOne_Info Site);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateDepartment(SM_Department_LevelOne_Info Site);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteDepartment(SM_Department_LevelOne_Info Site);
    }
}
