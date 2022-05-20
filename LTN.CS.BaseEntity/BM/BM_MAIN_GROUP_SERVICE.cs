using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_MAIN_GROUP_SERVICE : BaseEntity
    {
        public int IntId { get; set; }
        public BM_MAIN_GROUP Group { get; set; }
        public BM_SERVICE Service { get; set; }
        public int Index { get; set; }
        public BM_MAIN_ASSEMBLY MainAssembly { get; set; }
        public string Glyph { get; set; }
        public string LargeGlyph { get; set; }
        public BM_USER CreateEMPId { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public EntityInt IsForbid { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's GroupId is {0}\n", Group.IntId));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's ServiceId is {0}\n", Service.IntId));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's Index is {0}\n", Index));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's MainAssembly is {0}\n", MainAssembly.IntId));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's Glyph is {0}\n", Glyph));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's LargeGlyph is {0}\n", LargeGlyph));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's CreateEMPId is {0}\n", CreateEMPId.UserName));
            str.Append(String.Format("this BM_MAIN_GROUP_SERVICE's IsForbid is {0}\n", IsForbid.EntityDes));
            return str.ToString(); 
        }
    }
}
