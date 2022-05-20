using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Helper;
using System.Configuration;
using System.Xml;
using IBatisNet.Common;
using IBatisNet.Common.Utilities;
using System.Collections.Specialized;
using IBatisNet.Common.Xml;
using System.Reflection;
using System.IO;

namespace LTN.CS.Core.Common
{
    public static class SQLMapAdapter
    {
 
        private const string DATAMAPPER_NAMESPACE_PREFIX = "mapper";
        private const string PROVIDERS_NAMESPACE_PREFIX = "provider";
        private const string MAPPING_NAMESPACE_PREFIX = "mapping";
        private const string DATAMAPPER_XML_NAMESPACE = "http://ibatis.apache.org/dataMapper";
        private const string PROVIDER_XML_NAMESPACE = "http://ibatis.apache.org/providers";
        private const string MAPPING_XML_NAMESPACE = "http://ibatis.apache.org/mapping";
        private const string PROPERTY_ELEMENT_KEY_ATTRIB = "key";
        private const string PROPERTY_ELEMENT_VALUE_ATTRIB = "value";

        /// <summary>
        /// Token for SqlMapConfig xml root element.
        /// </summary>
        private const string XML_DATAMAPPER_CONFIG_ROOT = "sqlMapConfig";
        /// <summary>
        /// Token for xml path to global properties elements.
        /// </summary>
        private const string XML_GLOBAL_PROPERTIES = "*/add";
        /// <summary>
        /// Token for xml path to settings add elements.
        /// </summary>
        private const string XML_SETTINGS_ADD = "/*/add";
        /// <summary>
        /// Token for xml path to properties elements.
        /// </summary>
        private const string XML_PROPERTIES = "properties";

        /// <summary>
        /// Token for xml path to property elements.
        /// </summary>
        private const string XML_PROPERTY = "property";
        /// <summary>
        /// 获取SQLMap的键值用于寻找
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string GetSQLMapKey(string key)
        {
            string rs = string.Empty;
            try
            {
                rs = ConfigHelper.GetDictonaryConfigSn(key);
            }
            catch (Exception)
            {
                throw new Exception("获取SQLMap的键值失败");
            }
            return rs;
        }
        /// <summary>
        /// 获取SQLMap的文件路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSQLMapFileName(string key)
        {
            string rs = string.Empty;
            try
            {
                string Mapkey = GetSQLMapKey(key) + "_FilePath";
                rs = ConfigHelper.GetDictonaryConfigSn(Mapkey);
            }
            catch (Exception)
            {
                throw new Exception("获取SQLMap的文件路径失败");
            }
            return rs;
        }
        /// <summary>
        /// 获取SQLMap的连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSQLMapconnectionString(string key)
        {
            string rs = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                string Mapkey = GetSQLMapKey(key);
                rs = config.ConnectionStrings.ConnectionStrings[String.Format("{0}_{1}", Mapkey, ProjectConfiguration.DevMode)].ConnectionString;
                rs = AESHelper.Decrypt(rs);
            }
            catch (Exception)
            {
                throw new Exception("获取SQLMap的文件路径失败");
            }
            return rs;
        }
        /// <summary>
        /// 获取SQLMap的驱动名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSQLMapProviderName(string key)
        {
            string rs = string.Empty;
            try
            {
                string Mapkey = GetSQLMapKey(key) + "_DbProvider";
                rs = ConfigHelper.GetDictonaryConfigSn(Mapkey);
            }
            catch (Exception)
            {
                throw new Exception("获取SQLMap的文件路径失败");
            }
            return rs;
        }
        public static XmlNamespaceManager GetRootManager(XmlDocument root)
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(root.NameTable);
            manager.AddNamespace(DATAMAPPER_NAMESPACE_PREFIX, DATAMAPPER_XML_NAMESPACE);
            manager.AddNamespace(PROVIDERS_NAMESPACE_PREFIX, PROVIDER_XML_NAMESPACE);
            manager.AddNamespace(MAPPING_NAMESPACE_PREFIX, MAPPING_XML_NAMESPACE);
            return manager;
        }
        /// <summary>
        ///  获取SQLMap的驱动
        /// </summary>
        /// <param name="key"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IDbProvider GetSQLMapProvider(string key,XmlDocument root)
        {
            IDbProvider rs = null;
            Stream sm = null;
            try
            {
                Assembly asm = AssemblyHelper.GetResourceAssembly();
                string providersPath = String.Format("{0}.{1}", asm.FullName.Split(',')[0], ProjectConfiguration.Providers);
                sm = asm.GetManifestResourceStream(providersPath);
                XmlDocument xmlProviders = new XmlDocument();
                XmlNamespaceManager manager = GetRootManager(root);
                xmlProviders.Load(sm);
                XmlNodeList nodes = xmlProviders.SelectNodes(ApplyProviderNamespacePrefix("providers/provider"), manager);
                XmlNode providerNode = null;
                foreach (XmlNode node in nodes)
                {
                    NameValueCollection prop = NodeUtils.ParseAttributes(node);
                    if (prop["Name"] == GetSQLMapProviderName(key))
                    {
                        providerNode = node;
                    }
                }
                rs = ProviderDeSerializer.Deserialize(providerNode);
                rs.Initialize();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sm != null)
                {
                    sm.Dispose();
                }
            }
            return rs;
        }
        public static DataSource GetSQLMapDataSource(string key, XmlDocument root)
        {
            DataSource dataSource = new DataSource() 
            { 
                Name = String.Format("{0}_{1}", SQLMapAdapter.GetSQLMapKey(key), 
                ProjectConfiguration.DevMode),
                ConnectionString = SQLMapAdapter.GetSQLMapconnectionString(key), 
                DbProvider = GetSQLMapProvider(key, root)
                
            };
            return dataSource;
        }
        /// <summary>
        /// Apply the dataMapper namespace prefix
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static string ApplyDataMapperNamespacePrefix(string elementName)
        {
            return String.Format("mapper:{0}", elementName.
                                   Replace("/", "/" + "mapper" + ":"));
        }
        /// <summary>
        /// Apply the provider namespace prefix
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static string ApplyProviderNamespacePrefix(string elementName)
        {
            return String.Format("provider:{0}", elementName.
                                   Replace("/", "/" + "provider" + ":"));
        }
        /// <summary>
        /// Initialize the list of variables defined in the
        /// properties file.
        /// </summary>
        public static NameValueCollection ParseGlobalProperties(XmlNode root, XmlNamespaceManager manager)
        {
            NameValueCollection rs = new NameValueCollection();
            XmlNode nodeProperties = root.SelectSingleNode( ApplyDataMapperNamespacePrefix(XML_DATAMAPPER_CONFIG_ROOT),manager).SelectSingleNode(ApplyDataMapperNamespacePrefix(XML_PROPERTIES), manager);

            if (nodeProperties != null)
            {
                if (nodeProperties.HasChildNodes)
                {
                    foreach (XmlNode propertyNode in nodeProperties.SelectNodes(ApplyDataMapperNamespacePrefix(XML_PROPERTY), manager))
                    {
                        XmlAttribute keyAttrib = propertyNode.Attributes[PROPERTY_ELEMENT_KEY_ATTRIB];
                        XmlAttribute valueAttrib = propertyNode.Attributes[PROPERTY_ELEMENT_VALUE_ATTRIB];

                        if (keyAttrib != null && valueAttrib != null)
                        {
                            rs.Add(keyAttrib.Value, valueAttrib.Value);

                        }
                        else
                        {
                            // Load the file defined by the attribute
                            XmlDocument propertiesConfig = Resources.GetAsXmlDocument(propertyNode, rs);

                            foreach (XmlNode node in propertiesConfig.SelectNodes(XML_GLOBAL_PROPERTIES, manager))
                            {
                                rs[node.Attributes[PROPERTY_ELEMENT_KEY_ATTRIB].Value] = node.Attributes[PROPERTY_ELEMENT_VALUE_ATTRIB].Value;
                            }
                        }
                    }
                }
                else
                {

                    // Load the file defined by the attribute
                    XmlDocument propertiesConfig = Resources.GetAsXmlDocument(nodeProperties,rs);

                    foreach (XmlNode node in propertiesConfig.SelectNodes(XML_SETTINGS_ADD))
                    {
                        rs[node.Attributes[PROPERTY_ELEMENT_KEY_ATTRIB].Value] = node.Attributes[PROPERTY_ELEMENT_VALUE_ATTRIB].Value;
                    }
                }
            }
            return rs;
        }
        public static XmlDocument GetXmlDocument(string  key)
        {
            Stream sm = null;
            try
            {
                Assembly asm = AssemblyHelper.GetResourceAssembly();
                string filePath = SQLMapAdapter.GetSQLMapFileName(key);
                string path = String.Format("{0}.{1}", asm.FullName.Split(',')[0], filePath);
                sm = asm.GetManifestResourceStream(path);
                XmlDocument document = new XmlDocument();
                if (filePath.StartsWith("file://"))
                {
                    document = Resources.GetUrlAsXmlDocument(filePath.Remove(0, 7));
                }
                else
                {
                    document.Load(sm);
                }
                return document;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sm != null)
                {
                    sm.Dispose();
                }
            }
        }
    }
}
