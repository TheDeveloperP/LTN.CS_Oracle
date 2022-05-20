using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public class SqlMapElementsFactory
    {
        private static readonly Dictionary<string, SqlMapElements> elements = new Dictionary<string, SqlMapElements>();
        public static SqlMapElements CreateInstance(string key)
        {
            if (elements.ContainsKey(key))
            {
                return elements[key];
            }
            else
            {
                SqlMapElements rs= new SqlMapElements(key);
                elements[key] = rs;
                return rs;
            }
        }
    }
}
