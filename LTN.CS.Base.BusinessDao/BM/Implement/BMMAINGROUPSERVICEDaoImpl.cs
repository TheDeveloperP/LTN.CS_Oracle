using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.BaseEntities.BM_Query;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMMAINGROUPSERVICEDaoImpl : BaseDaoImp<BM_MAIN_GROUP_SERVICE>, IBMMAINGROUPSERVICEDao
    {
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryByServiceId(int serviceid)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP_SERVICE>("SelectByBMSERVICEName", serviceid);
        }
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryByGroupId(int groupid)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP_SERVICE>("SelectByBMGroupName", groupid);
        }
        public BM_MAIN_GROUP_SERVICE ExecuteQueryByName(string groupName)
        {
            return basedao.ExecuteQueryForObject<BM_MAIN_GROUP_SERVICE>("SelectByBMGROUPName", groupName);
        }

        public IList<BM_MAIN_GROUP_SERVICE_MENU> ExecuteQueryAllByUserId(SelectBMMAINGROUPSERVICEAll condition)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP_SERVICE_MENU>("SelectByBMMAINGROUPSERVICEUSER", condition);
        }
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_MAIN_GROUP_SERVICE>("SelectAllBMMAINGROUPSERVICE", null);
        }

        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMMAINGROUPSERVICE", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMMAINGROUPSERVICE", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMMAINGROUPSERVICE", parameterObject);
        }

        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteDelete("DisabledBMMAINGROUPSERVICE", parameterObject);
        }
    }
}
