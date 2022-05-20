using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using System.Reflection;
using System.Xml;
using System.IO;

namespace LTN.CS.Core.Helper
{
    public class ConfigHelper
    {

        //定义一个读取单独运行程序中独立配置属性文件
        private readonly static NameValueCollection appSettings = new NameValueCollection();
        /// <summary>
        /// 静态构造函数，便于系统一启动加载时读取配置参数
        /// </summary>
        static ConfigHelper()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            ConfigurationSectionCollection collection = config.Sections;
            Stream sm = null;
            try
            {
                foreach (ConfigurationSection key in collection)
                {

                    if (key.SectionInformation.Type.Contains("DictionarySectionHandler")) 
                    {
                        //读取单独配置文件部分
                        IDictionary o = (IDictionary)ConfigurationManager.GetSection(key.SectionInformation.Name);
                        foreach (string keyStr in o.Keys)
                        {
                            Assembly asm = Assembly.GetExecutingAssembly();
                            string filePath = String.Format("{0}.{1}", asm.FullName.Split(',')[0], o[keyStr]);
                            using (sm = asm.GetManifestResourceStream(filePath))
                            {
                                XmlDocument document = new XmlDocument();
                                document.Load(sm);
                                foreach (XmlNode node in document.LastChild.ChildNodes)
                                {
                                    if (!node.OuterXml.Contains("<!") && node.OuterXml.Contains("key") && node.OuterXml.Contains("value"))
                                    {
                                        appSettings.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("项目配置文件读取失败！");
            }
            finally
            {
                if (sm!=null)
                {
                    sm.Dispose();
                }
            }
            
        }

        /// <summary>
        /// 自定义的方法可以使用此方法得出自己配置的数据字典键值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDictonaryConfigSn(string key)
        {
            string rtn;

            if (appSettings != null)
                rtn = appSettings[key];
            else
                rtn = "";

            return rtn;

        }
        /// <summary>
        /// 获取config文档中AppSetting中配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defultvalue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetAppSetting<T>(T defultvalue, string key)
        {
            // 定义Configuration类对象，读取与主应用程序可执行文件相同文件夹下的配置文件
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            string value = config.AppSettings.Settings[key].Value;
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    defultvalue = (T)Convert.ChangeType(value, typeof(T));
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
            return defultvalue;
        }

    }
}
