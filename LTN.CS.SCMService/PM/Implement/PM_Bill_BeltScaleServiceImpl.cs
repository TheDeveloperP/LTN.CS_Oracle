using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;

namespace LTN.CS.SCMService.PM.Implement
{
   public  class PM_Bill_BeltScaleServiceImpl: IPM_Bill_BeltScaleService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;            
            if (ht["totalNum"].ToString() == "Y")
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_Totally", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            else
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_All", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }                   
            return rs;
        }

        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable2(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable2", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdatePM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_Bill_Belt", BeltBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertPM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                string WgtNo = CommonDao.ExecuteQueryForObject<string>("CreateWgtNo", null);

                BeltBill.C_Wgtlistno = BeltBill.C_Beltno + WgtNo;
                rs = CommonDao.ExecuteInsert("InsertPM_Bill_Belt", BeltBill);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InvalidPM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("InvalidPM_Bill_Belt", BeltBill);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<PM_Belt_ServerLog> ExecuteDB_QueryBeltServerLog(Hashtable ht)
        {
            IList<PM_Belt_ServerLog> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Belt_ServerLog>("QueryPM_Belt_ServerLog", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
