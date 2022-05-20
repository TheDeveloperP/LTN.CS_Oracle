using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.CS
{
    public class CS_Teacher:BaseEntity
    {
        public int IntId { get; set; }
        public string teacherName { get; set; }
        public int teacherAge { get; set; }
        public DateTime createTime { get; set; }
    }
}
