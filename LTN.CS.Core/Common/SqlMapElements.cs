using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using IBatisNet.Common;
using System.Collections.Specialized;
using IBatisNet.Common.Utilities;

namespace LTN.CS.Core.Common
{
    public class SqlMapElements
    {
        public string Key { get; set; }
        public XmlDocument Document { get; set; }
        public DataSource DataSourceForKey { get; set; }
        public NameValueCollection Properties { get; set; }
        public SqlMapElements(string key)
        {
            Key = key;
            Document = SQLMapAdapter.GetXmlDocument(key);
            DataSourceForKey = SQLMapAdapter.GetSQLMapDataSource(key, Document);
            Properties = SQLMapAdapter.ParseGlobalProperties(Document, SQLMapAdapter.GetRootManager(Document));
        }
        
    }
}
