using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Helper;
using LTN.CS.Core;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_DICTIONARY_MAIN : BaseEntity
    {
        public int IntId { get; set; }
        public string DicSn { get; set; }
        public string DicName { get; set; }
        public string DicDesc { get; set; }
        public string DicFieldA { get; set; }
        public string DicFieldB { get; set; }
        public EntityInt IsForbid { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_DICTIONARY_MAIN's IntId is {0}\r\n", IntId));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's DicSn is {0}\r\n", DicSn));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's DicName is {0}\r\n", DicName));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's DicDesc is {0}\r\n", DicDesc));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's DicFieldA is {0}\r\n", DicFieldA));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's DicFieldB is {0}\r\n", DicFieldB));
            str.Append(String.Format("this BM_DICTIONARY_MAIN's IsForbid is {0}\r\n", IsForbid.EntityDes));
            return str.ToString();
        }
    }
}
