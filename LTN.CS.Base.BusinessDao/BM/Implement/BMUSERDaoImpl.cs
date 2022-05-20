using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMUSERDaoImpl : BaseDaoImp<BM_USER>, IBMUSERDao
    {
        public BM_USER ExecuteQueryByName(string userName)
        {
            return basedao.ExecuteQueryForObject<BM_USER>("SelectByBMUSERNAME", userName);
        }

        public IList<BM_USER> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_USER>("SelectAllBMUSER", null);
        }

        public IList<BM_USER> ExecuteQueryNotInGroup(int groupId)
        {
            return basedao.ExecuteQueryForList<BM_USER>("SelectUserNotInGroupNo", groupId);
        }

        public IList<BM_USER> ExecuteQueryInGroup(int groupId)
        {
            return basedao.ExecuteQueryForList<BM_USER>("SelectUserInGroupNo", groupId);
        }

        public IList<BM_USER> ExecuteQueryNotInBusinessManager(int BusinessId)
        {
            return basedao.ExecuteQueryForList<BM_USER>("SelectUserNotInBusinessManager", BusinessId);
        }

        public IList<BM_USER> ExecuteQueryInBusinessManager(int BusinessId)
        {
            return basedao.ExecuteQueryForList<BM_USER>("SelectUserInBusinessManager", BusinessId);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMUSER", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMUSER", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMUSER", parameterObject);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledUser", parameterObject);
        }
    }
}
