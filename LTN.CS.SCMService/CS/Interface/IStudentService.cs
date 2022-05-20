using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.CS;
using System.Collections;

namespace LTN.CS.SCMService.CS.Interface
{
    public interface IStudentService
    {
        IList<CS_Student> ExecuteDB_QueryAll();

        IList<CS_Student> ExecuteDB_QueryAllByName(Hashtable name);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertStudent(CS_Student meter);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateStudent(CS_Student meter);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteStudent(CS_Student meter);
    }
}
