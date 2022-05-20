using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 用户&用户组资料实体
    /// </summary>
    public class BM_GROUP_USER : BaseEntity
    {
        public int IntId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_GROUP_USER's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_GROUP_USER's GroupId is {0}\n", GroupId));
            str.Append(String.Format("this BM_GROUP_USER's UserId is {0}\n", UserId));
            return str.ToString(); 
        }
    }
}
