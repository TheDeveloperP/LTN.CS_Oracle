using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.SCMEntities.CS;
using System.Collections;

namespace LTN.CS.SCMDao.CS.Interface
{
    public interface IStudentDao: IBaseDao<CS_Student>
    {
        IList<CS_Student> ExecuteQueryAllList();
        IList<CS_Student> ExecuteQueryAllListByName(Hashtable name);
    }
}
