// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/9/28 8:51:15
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/9/28 8:51:15
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using System.Runtime.Serialization;
using LTN.CS.Base.Common;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    public class PM_RawData_Move_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public string LesNo { get; set; }
        [DataMember]
        public int OrderNo { get; set; }
        [DataMember]
        public string CarriageNo { get; set; }
        [DataMember]
        public DirectionObj Direction { get; set; }
        [DataMember]
        public float WeightData { get; set; }
        [DataMember]
        public DateTime WeightTime { get; set; }
        [DataMember]
        public string Speed { get; set; }
        [DataMember]
        public string FormationTag { get; set; }
        [DataMember]
        public RawDataStatusObj DataStatus { get; set; }
        [DataMember]
        public WeightTypeObj DataType { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
