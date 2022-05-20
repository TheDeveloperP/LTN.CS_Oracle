using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_DICTIONARY_DETAIL : BaseEntity
    {
        public int IntId { get; set; }
        public int MainId { get; set; }
        public string DicSn { get; set; }
        public string DicDesc { get; set; }
        public string StrDicFieldA { get; set; }
        public string StrDicFieldB { get; set; }
        public decimal DecDICFIELDA { get; set; }
        public decimal DecDICFIELDB { get; set; }
        public EntityInt IsForbid { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's IntId is {0}\r\n", IntId));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's MainId is {0}\r\n", MainId));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's DicSN is {0}\r\n", DicSn));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's DicDesc is {0}\r\n", DicDesc));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's StrDicFieldA is {0}\r\n", StrDicFieldA));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's StrDicFieldB is {0}\r\n", StrDicFieldB));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's DecDICFIELDA is {0}\r\n", DecDICFIELDA));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's DecDICFIELDB is {0}\r\n", DecDICFIELDB));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's DicDesc is {0}\r\n", DicDesc));
            str.Append(String.Format("this BM_DICTIONARY_DETAIL's IsForbid is {0}\r\n", IsForbid.EntityDes));
            return str.ToString();
        }
    }
}
