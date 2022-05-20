using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMSERVICEGROUPDaoImpl : BaseDaoImp<BM_SERVICE_GROUP>,IBMSERVICEGROUPDao
    {
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMSERVICEGROUPUSER", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMSERVICEGROUPUSER", parameterObject);
        }
    }
}
