using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public  static  partial class ProjectConfiguration
    {
        /// <summary>
        /// 当前应用程序的名称
        /// </summary>
        public static string HomePage { get { return ConfigHelper.GetDictonaryConfigSn("HomePage"); } }
        /// <summary>
        /// 当前应用程序的名称
        /// </summary>
        public static string ApplicationName { get { return ConfigHelper.GetDictonaryConfigSn("ApplicationName"); } }

        /// <summary>
        /// 当前应用程序的名称
        /// </summary>
        public static string ShortApplicationName { get { return ConfigHelper.GetDictonaryConfigSn("ShortApplicationName"); } }

        /// <summary>
        /// 当前制造商版权商的名称
        /// </summary>
        public static string Manufacturer { get { return ConfigHelper.GetDictonaryConfigSn("Manufacturer"); } }

        /// <summary>
        /// 当前版权所有名称
        /// </summary>
        public static string CopyRight { get { return ConfigHelper.GetDictonaryConfigSn("CopyRight"); } }

        /// <summary>
        /// 当前初始化密码
        /// </summary>
        public static string DefaultPassword { get { return ConfigHelper.GetDictonaryConfigSn("DefaultPassword"); } }

        /// <summary>
        /// 当前应用程序的开发模式
        /// </summary>
        public static string DevMode { get { return ConfigHelper.GetDictonaryConfigSn("DevMode"); } }

          /// <summary>
        /// 当前应用程序的名称
        /// </summary>
        public static string Providers { get { return ConfigHelper.GetDictonaryConfigSn("providers"); } }

        /// <summary>
        /// 当前应用程序是否允许同时打开多个相同的TabPage
        /// </summary>
        public static bool MultiTabPage { get { return Convert.ToBoolean(ConfigHelper.GetDictonaryConfigSn("MultiTabPage")); } }
    }
    public static partial class ProjectConfiguration
    {
    }
}
