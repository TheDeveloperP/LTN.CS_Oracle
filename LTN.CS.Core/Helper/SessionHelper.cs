using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Common;

namespace LTN.CS.Core.Helper
{

    public class SessionHelper
    {
        /// <summary>
        /// 登录的用户
        /// </summary>
        public static object LogUser;
        /// <summary>
        /// 登录后的用户ID
        /// </summary>
        public static int LogUserId;
        /// <summary>
        /// 登录后的用户名
        /// </summary>
        public static string LogUserName;
        /// <summary>
        /// 登录后的用户别名
        /// </summary>
        public static string LogUserNickName;
        /// <summary>
        /// 选中的分组页名
        /// </summary>
        public static string SelectPageName;
        /// <summary>
        /// 刷新菜单历史事件
        /// </summary>
        public static DateTime RefMenuTimed = DateTime.MinValue;
        /// <summary>
        /// 登录机器Mac地址
        /// </summary>
        public static string MacAddress = ComputerInfo.GetNetCardMacAddress();
        /// <summary>
        /// 登录机器的IP
        /// </summary>
        public static string IP = ComputerInfo.GetIPAddress();

        /// <summary>
        /// 当前商家ID
        /// </summary>
        public static int BusinessId;

        /// <summary>
        /// 当前商家名称
        /// </summary>
        public static string BusinessName;

        public static bool IsLogIn = false;
        public static void ResetLoger(int logUserId, string logUserName, string logUserNickName, object logUser)
        {
            LogUserId = logUserId;
            LogUserName = logUserName;
            LogUserNickName = logUserNickName;
            LogUser = logUser;
        }
    }
}
