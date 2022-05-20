using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    public class Head
    {
        [DataMember]
        public string INTF_ID { get; set; }
        [DataMember]
        public string SEQ_NO { get; set; }
        [DataMember]
        public string SRC_SYSTEM { get; set; }
        [DataMember]
        public string DEST_SYSTEM { get; set; }
        [DataMember]
        public string SEND_TIME { get; set; }
        [DataMember]
        public string BACKUP1 { get; set; }
        [DataMember]
        public string BACKUP2 { get; set; }
    }
}
