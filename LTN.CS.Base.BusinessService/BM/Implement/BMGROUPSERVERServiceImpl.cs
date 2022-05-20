using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMGROUPSERVERServiceImpl : IBMGROUPSERVERService
    {
        public IBMSERVICEGROUPDao serviceGroupDap { get; set; }
        public object ExecuteDB_Insert(BM_SERVICE_GROUP obj)
        {
            object rs;
            try
            {
                rs = serviceGroupDap.ExecuteInsert(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Delete(BM_SERVICE_GROUP obj)
        {
            object rs;
            try
            {
                rs = serviceGroupDap.ExecuteDelete(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
