using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Core.Helper
{
    [DataContract]
    public class EntityInt
    {
        public EntityInt() { }
        public EntityInt(int entityValue) { EntityValue = entityValue; }
        [DataMember]
        public int EntityValue { get; set; }
        public string EntityDes
        {
            get
            {
                return EntityValue.Equals((Int32)IntBool.Yes) ? IntString.Yes : IntString.No;
            }
        }
    }
}
