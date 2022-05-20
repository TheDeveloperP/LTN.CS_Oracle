using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_BlackList:BaseEntity
    {
        public int IntId { get; set; }
        public string CarName { get; set; }
        public string CriminalRecord { get; set; }
    }
}
