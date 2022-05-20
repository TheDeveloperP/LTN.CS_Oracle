using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 用户&服务资料实体
    /// </summary>
    public class BM_SERVICE_USER : BaseEntity
    {
        public int IntId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_SERVICE_USER's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_SERVICE_USER's ServiceId is {0}\n", ServiceId));
            str.Append(String.Format("this BM_SERVICE_USER's UserId is {0}\n", UserId));
            //str.Append(String.Format("this BM_SERVICE_USER's CreateUser is {0}\n", CreateUser));
            //str.Append(String.Format("this BM_SERVICE_USER's UpdateUser is {0}\n", UpdateUser));

            return str.ToString();
        }
    }
}
