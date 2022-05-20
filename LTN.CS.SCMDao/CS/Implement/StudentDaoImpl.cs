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
    public class StudentDaoImpl : BaseDaoImp<CS_Student>, IStudentDao
    {

        public IList<CS_Student> ExecuteQueryAllList()
        {
            return basedao.ExecuteQueryForList<CS_Student>("selectCS_StudentAll", null);
        }

        public IList<CS_Student> ExecuteQueryAllListByName(Hashtable name)
        {
            return basedao.ExecuteQueryForList<CS_Student>("selectCS_StudentAllByName", name);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertCS_Student", parameterObject);
        }

        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateCS_Student", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteCS_Student", parameterObject);
        }
    }
}
