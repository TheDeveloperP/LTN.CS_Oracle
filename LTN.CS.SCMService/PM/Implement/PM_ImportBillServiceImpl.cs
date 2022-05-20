using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using System.Collections;
using System.Data;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_ImportBillServiceImpl : IPM_ImportBillService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertPM_ImportBill(List<PM_ImportBill> ImportBills)
        {
            object result;
            try
            {
                foreach (var item in ImportBills)
                {
                    CommonDao.ExecuteInsert("Insert_PM_ImportBill", item);
                }
                result = ImportBills.Count;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_ImportBill> ExecuteDB_QueryPM_ImportBill(Hashtable ht)
        {
            IList<PM_ImportBill> rs = null;
            try
            {
                rs=CommonDao.ExecuteQueryForList<PM_ImportBill>("QueryPM_ImportBill", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_UpdatePM_ImportBill(PM_ImportBill Bill)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_ImportBillByPrint", Bill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
    }
}
