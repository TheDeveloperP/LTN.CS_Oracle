using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Globalization;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_OnlineScaleServiceImpl : IPM_Bill_OnlineScaleService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Bill_OnlineScale> ExecuteDB_QueryOnlineScaleBillByHashTable(Hashtable ht)
        {
            IList<PM_Bill_OnlineScale> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_OnlineScale>("SelectPM_Bill_OnlineScaleByCondition", ht);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Bill_OnlineScale> ExecuteDB_QueryOnlineScaleBillByHashTable2(Hashtable ht)
        {
            IList<PM_Bill_OnlineScale> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_OnlineScale>("SelectPM_Bill_OnlineScaleByCondition2", ht);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        public IList<PM_TruckBillWithOnlineBill> ExecuteDB_QueryTruckBillWithOnlineBills(Hashtable ht)
        {
            IList<PM_TruckBillWithOnlineBill> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_TruckBillWithOnlineBill>("SelectPM_TruckBillWithOnlineBills", ht);
                result.ToList().ForEach(r =>
                {
                    r.Mat_Act_Wgt = r.OnLineBills.Sum(s => s.Mat_Act_Wt);
                    r.wgt_sub = r.N_NETWGT - r.Mat_Act_Wgt;
                    r.C_NETWGTTIME = Str14ToTimeFormart(r.C_NETWGTTIME);
                    r.C_TAREWGTTIME = Str14ToTimeFormart(r.C_TAREWGTTIME);
                    r.OnLineBills.ToList().ForEach(t => t.Prod_Time = Str14ToTimeFormart(t.Prod_Time));
                    r.OnLineBills.ToList().ForEach(w => w.Weight_Time = Str14ToTimeFormart(w.Weight_Time));
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;

        }
        private string Str14ToTimeFormart(string str)
        {
            try
            {
                DateTime dt;
                string result = null;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                if (DateTime.TryParseExact(str, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                {
                    result = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                }
                return result;
            }
            catch
            {
                return string.Empty;
            }

        }
    }
}
