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
    public class PM_OrbitWeighterConfirmServiceImpl : IPM_OrbitWeighterConfirmService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Bill_OrbitWeighterConfirm> ExecuteDB_QueryOrbitWeighterBillByHashTable(Hashtable ht)
        {
            IList<PM_Bill_OrbitWeighterConfirm> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Bill_OrbitWeighterConfirm>("SelectPM_OrbitWeighterConfrimByCondition", ht);
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
