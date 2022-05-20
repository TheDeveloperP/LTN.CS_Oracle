using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMForm.Common
{
   public class CommonHelper
    {
        /// <summary>
        /// 时间格式转为12位数字字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string TimeToStr14(DateTime dt)
        {
            try
            {
                return dt.ToString("yyyyMMddHHmmss");
            }
            catch
            {
                return string.Empty;
            }
          
        }
        /// <summary>
        /// 将数字字符串转为时间格式的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Str14ToTimeFormart(string str)
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
        /// <summary>
        /// 将数字字符串转为时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime Str14ToTime(string str)
        {
            try
            {
                DateTime dt;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                DateTime.TryParseExact(str, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt);
                return dt;
            }
            catch
            {
                return DateTime.Parse("00000000000000") ;
            }
            
        }

    }
}
