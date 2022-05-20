using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using IBatisNet.Common.Logging;

namespace LTN.CS.Core.Helper
{
    public static class ResouresHelper
    {
        /// <summary>
        /// 日志
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("infoAppender");
        private readonly static CultureInfo resourceCulture = CultureInfo.CreateSpecificCulture("en-US");
        public static object getResoures(string assemblyName, string baseName,string resourceName)
        {
            try
            {
                object obj = MyResourceManagerPool.getManager(assemblyName, baseName).GetObject(resourceName, resourceCulture);
                return obj;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }

        }
        public static T getResoures<T>(string assemblyName, string baseName, string resourceName)
        {
            try
            {
                object obj = ResouresHelper.getResoures(assemblyName, baseName, resourceName);
                return (T)obj;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return default(T);
            }
        }
    }
}
