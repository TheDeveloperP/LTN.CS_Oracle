using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.CS;
using LTN.CS.Core.Dao;
using System.Collections;

namespace LTN.CS.SCMDao.CS.Interface
{
    public interface ITeacherDao : IBaseDao<CS_Teacher>
    {
        IList<CS_Teacher> ExecuteQueryAllList();
        IList<CS_Teacher> ExecuteQueryAllListByName(Hashtable name);
    }
}
