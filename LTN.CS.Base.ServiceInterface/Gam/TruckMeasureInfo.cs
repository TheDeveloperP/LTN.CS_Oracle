using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.Base.ServiceInterface.Gam
{
    [DataContract]
    public class TruckMeasureInfo
    {
        [DataMember]
        public IT_TruckMeasurePlan BODY { get; set; }
        [DataMember]
        public Head HEAD { get; set; }
    }
}
