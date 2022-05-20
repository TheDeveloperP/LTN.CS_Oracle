using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_MAIN_GROUP : BaseEntity
    {
        public int IntId { get; set; }
        public BM_MAIN_PAGE PageId { get; set; }
        public int Index { get; set; }
        public string GroupName { get; set; }
        public string Text { get; set; }
        public string KeyTip { get; set;} 
        public BM_USER CreateEMPId { get; set; }
        public EntityInt IsForbid { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_MAIN_GROUP's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_MAIN_GROUP's PageId is {0}\n", PageId));
            str.Append(String.Format("this BM_MAIN_GROUP's Index is {0}\n", Index));
            str.Append(String.Format("this BM_MAIN_GROUP's GroupName is {0}\n", GroupName));
            str.Append(String.Format("this BM_MAIN_GROUP's Text is {0}\n", Text));
            str.Append(String.Format("this BM_MAIN_GROUP's KeyTip is {0}\n", KeyTip));
            str.Append(String.Format("this BM_MAIN_GROUP's CreateEMPId is {0}\n", CreateEMPId.UserName));
            str.Append(String.Format("this BM_MAIN_GROUP's IsForbid is {0}\n", IsForbid.EntityDes));
            return str.ToString(); 
        }
    }
}
