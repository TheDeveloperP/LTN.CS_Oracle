using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_JZX_Huda_Message:BaseEntity
    {
        public string T_ID { get; set; }
        public string T_JZXH { get; set; }
        public string T_PONDID { get; set; }
        public string T_JZXHPICADDRESS_1 { get; set; }
        public string T_JZXHPICADDRESS_2 { get; set; }
        public string T_DISTINGUISHTIME { get; set; }
        public string T_ISERVER_V1 { get; set; }
        public int T_ISERVER_I1 { get; set; }
        public string T_CARNAME_1 { get; set; }
        public string T_CARNAME_2 { get; set; }
    }
}
