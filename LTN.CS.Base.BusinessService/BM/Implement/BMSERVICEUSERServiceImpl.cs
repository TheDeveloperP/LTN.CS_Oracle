using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessDao.BM.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMSERVICEUSERServiceImpl : IBMSERVICEUSERService
    {
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IBMSERVICEUSERDao serviceUserDao { get; set; }

        #region IBMSERVICEUSERService 成员

        public object ExecuteDB_Insert(BM_SERVICE_USER obj)
        {
            object rs;
            try
            {
                rs = serviceUserDao.ExecuteInsert(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Delete(BM_SERVICE_USER obj)
        {
            object rs;
            try
            {
                rs = serviceUserDao.ExecuteDelete(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

     

        #endregion
    }
}