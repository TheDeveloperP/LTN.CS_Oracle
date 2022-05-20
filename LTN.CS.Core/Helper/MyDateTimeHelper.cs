using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace LTN.CS.Core.Helper
{

    public class MyDateTimeHelper
    {
        public static DateTime Str14ToHourTime(string str)
        {
            try
            {
                DateTime dt = Str14ToTime(str);
                int m = dt.Minute * (-1);    //获取当前时间的分钟部分
                int s = dt.Second * (-1);    //获取当前时间的秒部分
                dt=dt.AddMinutes(m ).AddSeconds(s);
                return dt;
            }
            catch
            {
                return DateTime.Parse("21000000000000");
            }


        }

        public static DateTime Str14ToTime(string str)
        {
            try
            {
                DateTime dt;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                dt = DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                return dt;
            }
            catch
            {
                return new DateTime();
            }

        }
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

        public static DateTime GetDateTimeFromYYYYMM(string year)
        {
            DateTime dt = DateTime.MinValue;
            if (year.Contains("年") && year.Contains("月"))
            {
                StringBuilder strYear = new StringBuilder();
                strYear.Append(year.Split('年')[0]);
                strYear.Append("年");
                string month = year.Split('年')[1].Split('月')[0];
                strYear.Append(month.Length == 1 ? "0" + month : month);
                strYear.Append("月");
                dt = DateTime.ParseExact(strYear.ToString(), "yyyy年MM月", null);
            }
            return dt;
        }
        /// <summary>
        /// 传入日期得到是季度的第一天
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetStartDateOfNowQuarter(object input = null)
        {
            DateTime d = ConvertToDateTimeDefaultNow(input);
            string rtn = d.AddMonths(0 - ( ( d.Month - 1 ) % 3 )).ToString("yyyy-MM-01");

            return rtn;

        }

        /// <summary>
        /// 传入日期得到是季度的最后一天
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetEndDateOfNowQuarter(object input = null)
        {
            DateTime d = ConvertToDateTimeDefaultNow(input);
            return DateTime.Parse(d.AddMonths(3 - ( ( d.Month - 1 ) % 3 )).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();

        }

        /// <summary>
        /// 传入日期得到是哪一季度,格式不对或不传以当前日期为准
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetQuarterOfYearMonth(object input = null)
        {
            int rtn;

            DateTime date = ConvertToDateTimeDefaultNow(input);
            int m = date.Month;
            if (m >= 1 && m < 4)
                rtn = 1;
            else
                rtn = 0;

            if (m >= 4 && m < 7)
            {
                rtn = 2;
            }

            if (m >= 7 && m < 10)
            {
                rtn = 3;
            }

            if (m >= 10 && m < 13)
            {
                rtn = 4;
            }

            return rtn;

        }

        /// <summary>
        /// 传入的字符型日期转换YyyyMMddHHmmss格式字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNowDateTimeYyyyMMddHHmmss(object input = null)
        {
            DateTime date = ConvertToDateTimeDefaultNow(input);
            return date.ToString("yyyyMMddHHmmss");

        }

        /// <summary>
        /// 传入的字符型日期转换YyyyMMddHHmmssffff格式字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNowDateTimeYyyyMMddHHmmssffff(object input = null)
        {
            DateTime date = ConvertToDateTimeDefaultNow(input);
            return date.ToString("yyyyMMddHHmmssffff");

        }

        /// <summary>
        /// 传入的字符型日期转换日期日期型,如果格式返回当前日期
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeDefaultNow(object input)
        {
            DateTime rtn;
            bool flag = DateTime.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
            {
                rtn = DateTime.Now;
            }

            return rtn;

        }

        /// <summary>
        /// 传入的字符型日期转换日期日期型，如果格式有问题,返回DateTime.MinValue
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeDefaultNull(object input)
        {
            DateTime rtn;
            bool flag = DateTime.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
            {
                rtn = DateTime.MinValue;
            }

            return rtn;

        }

        /// <summary>
        /// 传入的字符型日期转换日期日期型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeDefaultException(object input)
        {
            DateTime rtn;
            bool ex = DateTime.TryParse(Convert.ToString(input), out rtn);
            if (!ex)
            {
                throw new Exception("日期格式不对!");
            }
            return rtn;

        }

        /// <summary>
        /// 得到系统当前时间:Date+Time
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSystemNowDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 得到系统当前日期:Date
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSystemNowDate()
        {
            return DateTime.Now.Date;
        }

        /// <summary>
        /// 得到系统当前日期:LongTimeString
        /// </summary>
        /// <returns></returns>
        public static string GetSystemNowLongTimeString()
        {
            return DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 得到系统当前日期:LongTimeString
        /// </summary>
        /// <returns></returns>
        public static string GetSystemNowShortTimeString()
        {
            return DateTime.Now.ToShortTimeString();
        }

        /// <summary>
        /// 得到系统当前日期:Date,返回字符串日期,yyyyMMddHHmmssffff
        /// </summary>
        /// <returns></returns>
        public static String GetSystemNowStrFormatDate(string parttern = "yyyy-MM-dd")
        {
            DateTime date = DateTime.Now;
            return date.ToString(parttern);
        }

        /// <summary>
        /// 得到系统当前日期:Date,返回日期格式,yyyyMMddHHmmssffff
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSystemNowFormatDate(string parttern = "yyyy-MM-dd")
        {
            String format = parttern;
            DateTime date = DateTime.Now;
            return ConvertToDateTimeDefaultNow(date.ToString(format));
        }

        /// <summary>
        /// 得到当前年份,可以传入一个日期格式，如果不传则以当前日期的年份
        /// </summary>
        /// <returns></returns>
        public static int GetYearOfDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            return dt.Year;
        }

        /// <summary>
        /// 得到当前月份,可以传入一个日期格式，如果不传则以当前日期的月份
        /// </summary>
        /// <returns></returns>
        public static int GetMonthOfDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            return dt.Month;
        }


        /// <summary>
        /// 得到当前天数,可以传入一个日期格式，如果不传则以当前日期的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDayOfDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.Day;
        }

        /// <summary>
        /// 得到当前小时,可以传入一个日期格式，如果不传则以当前日期的小时
        /// </summary>
        /// <returns></returns>
        public static int GetHourByDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.Hour;
        }


        /// <summary>
        /// 得到当前分钟,可以传入一个日期格式，如果不传则以当前日期的分钟
        /// </summary>
        /// <returns></returns>
        public static int GeMinuteOfDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.Minute;
        }

        /// <summary>
        /// 得到当前是星期几,可以传入一个日期格式，如果不传则以当前日期的星期
        /// </summary>
        /// <returns></returns>
        public static DayOfWeek GetDayOfWeekByDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.DayOfWeek;
        }

        /// <summary>
        /// 得到当前是第几天,可以传入一个日期格式，如果不传则以当前日期的第几天
        /// </summary>
        /// <returns></returns>
        public static int GetDayOfYearByDateTime(object input = null)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.DayOfYear;
        }

        /// <summary>
        /// 时间加n年,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// num为一个数,可以正整数,也可以负整数
        /// </summary>
        /// <returns></returns>
        public static DateTime AddYearByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddYears(num);
        }

        /// <summary>
        /// 加n天,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// num为一个数,可以正整数,也可以负整数
        /// </summary>
        /// <returns></returns>
        public static DateTime AddDaysByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddDays(num);
        }

        /// <summary>
        /// 加n小时,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// num为一个数,可以正整数,也可以负整数
        /// </summary>
        /// <returns></returns>
        public static DateTime AddHoursByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddHours(num);
        }

        /// <summary>
        /// 加n个月,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// </summary>
        /// <returns></returns>
        public static DateTime AddMonthsByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddMonths(num);
        }


        /// <summary>
        /// /加n分,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// num为一个数,可以正整数,也可以负整数
        /// </summary>
        /// <returns></returns>
        public static DateTime AddMinutesByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddMinutes(num);
        }


        /// <summary>
        /// 加n秒,传入日期,加上天数后是什么日期,可以传入一个日期格式，如果不传则以当前日期
        /// num为一个数,可以正整数,也可以负整数
        /// </summary>
        /// <returns></returns>
        public static DateTime AddSecondsByDateTime(object input = null, int num = 0)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            return dt.AddSeconds(num);
        }

        /// <summary>
        /// 得到某月最后一天,如果格式不对则返回0,传入日期,如果日期格式不对，则以当前日期为准
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetMonthLastDayOfDateTime(object input)
        {
            int rtn = 0;

            DateTime dt = AddMonthsByDateTime(input, 1);
            int year = dt.Year;
            int month = dt.Month;

            DateTime dtOk = new DateTime(year, month, 1);
            DateTime dtRtn = dtOk.AddDays(-1);

            rtn = dtRtn.Day;

            return rtn;

        }

        /// <summary>
        /// 得到当前周是今年的是第几周
        /// </summary>
        /// <returns></returns>
        public static int GetWeekOfYear()
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        /// <summary>
        /// 获取当前日期指定周数的开始日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfWeeks()
        {
            DateTime startDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(DateTime.Now.DayOfWeek) )));

            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取当前日期指定周数的结束日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfWeeks()
        {
            DateTime endDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(DateTime.Now.DayOfWeek) )));

            return endDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定周数的开始日期，如果日期格式不对则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);

            DateTime startDayOfWeeks = dt.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(dt.DayOfWeek) )));

            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定周数的结束日期，如果日期格式不对则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            DateTime endDayOfWeeks = dt.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(dt.DayOfWeek) )));

            return endDayOfWeeks;
        }

        #region 得到指定日期上周的开始与结束日期
        /// <summary>
        /// 获取当前日期指定上周数的开始日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfLastWeeks()
        {
            DateTime startDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(DateTime.Now.DayOfWeek) )) - 7);
            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取当前日期指定上周数的结束日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfLastWeeks()
        {
            DateTime endDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(DateTime.Now.DayOfWeek) )) - 7);
            return endDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定上周数的开始日期,如果日期格式不对，则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfLastWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            DateTime startDayOfWeeks = dt.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(dt.DayOfWeek) )) - 7);
            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定上周数的结束日期，如果日期格式对,则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfLastWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            DateTime endDayOfWeeks = dt.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(dt.DayOfWeek) )) - 7);

            return endDayOfWeeks;
        }
        #endregion


        #region 得到下周的开始与结束日期


        /// <summary>
        /// 获取当前日期指定下周数的开始日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfNextWeeks()
        {
            DateTime startDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(DateTime.Now.DayOfWeek) )) + 7);
            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取当前日期指定下周数的结束日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfNextWeeks()
        {
            DateTime endDayOfWeeks = DateTime.Now.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(DateTime.Now.DayOfWeek) )) + 7);
            return endDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定下周数的开始日期,如果日期格式不对，则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetStartDayOfNextWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            DateTime startDayOfWeeks = dt.AddDays(Convert.ToDouble(( 0 - Convert.ToInt16(dt.DayOfWeek) )) + 7);
            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取指定日期指定下周数的结束日期，如果日期格式对,则使用当前日期
        /// </summary>      
        /// <returns></returns>
        public static DateTime GetEndDayOfNextWeeks(object input)
        {
            DateTime dt = ConvertToDateTimeDefaultNow(input);
            DateTime endDayOfWeeks = dt.AddDays(Convert.ToDouble(( 6 - Convert.ToInt16(dt.DayOfWeek) )) + 7);

            return endDayOfWeeks;
        }

        #endregion

        #region 日期相减
        /// <summary>
        /// 获得两个日期相减后的差的总计天数
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffTotalDaysByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.TotalDays;
        }

        /// <summary>
        /// 获得两个日期相减后的差的总计小时
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffTotalHoursByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.TotalHours;
        }

        /// <summary>
        /// 获得两个日期相减后的差的总计分钟
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffTotalMinutesByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.TotalMinutes;
        }

        /// <summary>
        /// 获得两个日期相减后的差的总计秒钟
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffTotalSecondsByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.TotalSeconds;
        }

        /// <summary>
        /// 获得两个日期相减后的差的总计微秒
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffTotalMillisecondsByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获得两个日期相减后的差的天数
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffDaysByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.Days;
        }

        /// <summary>
        /// 获得两个日期相减后的差的小时
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffHoursByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.Hours;
        }

        /// <summary>
        /// 获得两个日期相减后的差的分钟
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffMinutesByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.Minutes;
        }

        /// <summary>
        /// 获得两个日期相减后的差的秒钟
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffSecondsByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.Seconds;
        }

        /// <summary>
        /// 获得两个日期相减后的差的微秒
        /// </summary>
        /// <param name="dtFrom">小日期</param>
        /// <param name="dtTo">大日期</param>
        /// <returns></returns>
        public static double GetDiffMillisecondsByDate(object dtFrom, object dtTo)
        {
            DateTime dt1 = ConvertToDateTimeDefaultNow(dtFrom);
            DateTime dt2 = ConvertToDateTimeDefaultNow(dtTo);

            TimeSpan ts = dt2 - dt1;

            return ts.Milliseconds;
        }
        #endregion

    }
}
