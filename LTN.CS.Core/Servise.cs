using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
/**********************************************************
*	CLR版本：		4.0.30319.235		  *	
*	新建项输入的名称：	Servise		  *
*	机器名称	：		LENOVO-B231EC5C	          *
*	注册组织名：		Lenovo (Beijing) Limited  *
*	命名空间名称：		IBatisNetLib		  *	
*	文件名：			Servise        *
*	当前系统时间按		2011-7-7 16:58:21		          *
*	用户所在域：		LENOVO-B231EC5C		  *
*	当前登录用户名：		Administrator		  *
*	创建年份：		2011		          *
*	作者：LZY				          *
***********************************************************/

namespace IBatisNetLib
{
    public class Servise
    {
        private static ILog log = LogManager.GetLogger("somename");
        public static void DoInitLog4Net() 
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void DoLog(string errorMessage)
        {
            log.Error(errorMessage); 
        }
        public static void DoLog(string errorMessage,string errorName)
        {
            log = LogManager.GetLogger(errorName);
            log.Error(errorMessage);
            log = LogManager.GetLogger("somename");
        }
    }
}
