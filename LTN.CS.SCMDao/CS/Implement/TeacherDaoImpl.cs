using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMDao.CS.Interface;
using LTN.CS.SCMEntities.CS;
using LTN.CS.Core.Dao;
using System.Collections;

namespace LTN.CS.SCMDao.CS.Implement
{
    public class TeacherDaoImpl : BaseDaoImp<CS_Teacher>, ITeacherDao
    {
        public IList<CS_Teacher> ExecuteQueryAllList()
        {
            return basedao.ExecuteQueryForList<CS_Teacher>("selectCS_TeacherAll", null);
        }

        public IList<CS_Teacher> ExecuteQueryAllListByName(Hashtable name)
        {
            return basedao.ExecuteQueryForList<CS_Teacher>("selectCS_TeacherAllByName", name);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertCS_Teacher", parameterObject);
        }

        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateCS_Teacher", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteCS_Teacher", parameterObject);
        }
    }
}
