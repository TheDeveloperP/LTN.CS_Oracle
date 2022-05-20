using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMSERVICEUSERDaoImpl : BaseDaoImp<BM_SERVICE_USER>, IBMSERVICEUSERDao
    {
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMSERVICEUSER", parameterObject);
        }

        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMSERVICEUSER", parameterObject);
        }
    }
}
