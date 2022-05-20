using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.CS;
using System.Collections;

namespace LTN.CS.SCMService.CS.Interface
{
    public interface ITeacherService
    {
        IList<CS_Teacher> ExecuteDB_QueryAll();

        IList<CS_Teacher> ExecuteDB_QueryAllByName(Hashtable name);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertStudent(CS_Teacher meter);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateStudent(CS_Teacher meter);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteStudent(CS_Teacher meter);
    }
}
