using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.ConditionEntity
{
    [Serializable]
    public class WeightShow
    {
        public string GrossWeight { get; set; }
        public string TareWeight { get; set; }
        public string NetWeight { get; set; }
    }
}
