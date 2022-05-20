using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_MAIN_PAGE : BaseEntity
    {
        public int IntId { get; set; }
        public int Index { get; set; }
        public string PageName { get; set; }
        public string Text { get; set; }
        public string KeyTip { get; set; }
        public BM_USER CreateEMPId { get; set; }
        public BM_USER ManageEMPId { get; set; }
        public EntityInt IsForbid { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_MAIN_PAGE's IntId is {0}{1}", IntId,Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's Index is {0}{1}", Index, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's PageName is {0}{1}", PageName, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's Text is {0}{1}", Text, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's KeyTip is {0}{1}", KeyTip, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's CreateEMPId is {0}{1}", CreateEMPId.UserName, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's ManageEMPId is {0}{1}", ManageEMPId.UserName, Environment.NewLine));
            str.Append(String.Format("this BM_MAIN_PAGE's IsForbid is {0}{1}", IsForbid.EntityDes, Environment.NewLine));
            return str.ToString(); 
        }
    }
}
