using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 服务实体
    /// </summary>
    public class BM_SERVICE : BaseEntity
    {
        public int IntId { get; set; }
        public string ServiceNo { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDes { get; set; }
        public BM_USER CreateEMPId { get; set; }
        public BM_USER ManageEMPId { get; set; }
        public EntityInt IsForbid { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public EntityInt IsLimit { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_SERVICE's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_SERVICE's ServiceNo is {0}\n", ServiceNo));
            str.Append(String.Format("this BM_SERVICE's ServiceName is {0}\n", ServiceName));
            str.Append(String.Format("this BM_SERVICE's ServiceDes is {0}\n", ServiceDes));
            str.Append(String.Format("this BM_SERVICE's CreateEMPId is {0}\n", CreateEMPId.UserName));
            str.Append(String.Format("this BM_SERVICE's ManageEMPId is {0}\n", ManageEMPId.UserName));
            str.Append(String.Format("this BM_SERVICE's IsForbid is {0}\n", IsForbid.EntityDes));
            str.Append(String.Format("this BM_SERVICE's IsLimit is {0}\n", IsLimit.EntityDes));
            return str.ToString();
        }
    }
}
