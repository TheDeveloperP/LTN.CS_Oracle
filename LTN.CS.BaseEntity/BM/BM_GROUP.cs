using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 用户组实体
    /// </summary>
    public class BM_GROUP : BaseEntity
    {
        public int IntId { get; set; }
        public string GroupNo { get; set; }
        public string GroupName { get; set; }
        public string GroupDes { get; set; }
        public BM_USER CreateEMPId { get; set; }
        public BM_USER ManageEMPId { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public EntityInt IsForbid { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_GROUP's IntId is {0}\r\n", IntId));
            str.Append(String.Format("this BM_GROUP's GroupNo is {0}\r\n", GroupNo));
            str.Append(String.Format("this BM_GROUP's GroupName is {0}\r\n", GroupName));
            str.Append(String.Format("this BM_GROUP's GroupDes is {0}\r\n", GroupDes));
            str.Append(String.Format("this BM_GROUP's CreateEMPId is {0}\r\n", CreateEMPId.UserName));
            str.Append(String.Format("this BM_GROUP's ManageEMPId is {0}\r\n", ManageEMPId.UserName));
            str.Append(String.Format("this BM_GROUP's IsForbid is {0}\r\n", IsForbid.EntityDes));
            return str.ToString(); 
        }
    }
}
