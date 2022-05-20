using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace LTN.CS.Core.Common
{
    public class BaseDaoContainer
    {
        public static Dictionary<string, ConcurrentQueue<BaseSqlMapDaoImpl>> data = new Dictionary<string, ConcurrentQueue<BaseSqlMapDaoImpl>>();
    }
}
