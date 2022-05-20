using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.BaseEntities.BM;


namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMSERVICEDaoImpl : BaseDaoImp<BM_SERVICE>, IBMSERVICEDao
    {
        public IList<BM_SERVICE> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectAllBMSERVICE", null);
        }

        public BM_SERVICE ExecuteQueryByNo(string serviceNo)
        {
            return basedao.ExecuteQueryForObject<BM_SERVICE>("SelectByBMSERVICENO", serviceNo);
        }
        public BM_SERVICE ExecuteQueryById(int serviceId)
        {
            return basedao.ExecuteQueryForObject<BM_SERVICE>("SelectByBMSERVICEId", serviceId);
        }
        public IList<BM_SERVICE> ExecuteQueryByIntId(int serviceId)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectByServiceIntId", serviceId);
        }
        public IList<BM_SERVICE> ExecuteQueryByServerId(int serviceNo)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectByBMSERVICESERVERID", serviceNo);
        }

        public IList<BM_SERVICE> ExecuteQueryInGroup(int GroupId)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectInGroupNo", GroupId);
        }

        public IList<BM_SERVICE> ExecuteQueryNotInGroup(int GroupId)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectNotInGroupNo", GroupId);
        }
        public IList<BM_SERVICE> ExecuteQueryInUser(int UserId)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectInUser", UserId);
        }

        public IList<BM_SERVICE> ExecuteQueryNotInUser(int UserId)
        {
            return basedao.ExecuteQueryForList<BM_SERVICE>("SelectNotInUser", UserId);
        }
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMSERVICE", parameterObject);
        }

        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMSERVICE", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMSERVICE", parameterObject);
        }

        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledSERVICE", parameterObject);
        }

        public override object ExecuteLimited(object parameterObject)
        {
            return basedao.ExecuteDelete("LIMITSERVICE", parameterObject);
        }


        
    }
}
