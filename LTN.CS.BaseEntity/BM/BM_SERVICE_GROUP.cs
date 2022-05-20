using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 用户组用户&服务资料实体
    /// </summary>
    public class BM_SERVICE_GROUP : BaseEntity
    {
        public int IntId { get; set; }
        public int ServiceId { get; set; }
        public int GroupId { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_SERVICE_GROUP's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_SERVICE_GROUP's ServiceId is {0}\n", ServiceId));
            str.Append(String.Format("this BM_SERVICE_GROUP's GroupId is {0}\n", GroupId));
            return str.ToString(); 
        }
    }
}
