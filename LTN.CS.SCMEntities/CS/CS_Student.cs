using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.CS
{
    public class CS_Student:BaseEntity
    {
        public int IntId { get; set; }
        public string studentNo { get; set; }
        public string studentName { get; set; }
        public int studentAge { get; set; }
        public string studentSex { get; set; }
        public string studentAddress { get; set; }
        public string studentTelphone { get; set; }
        public string createName { get; set; }
        public string createTime { get; set; }
        public string updateName { get; set; }
        public string updateTime { get; set; }
    }
}
