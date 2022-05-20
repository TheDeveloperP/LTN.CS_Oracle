// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/8/5 11:33:33
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 11:33:33
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using System.Runtime.Serialization;
using LTN.CS.Core.Helper;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(EntityInt))]
    public class DM_Route_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public int PondId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int TaskId { get; set; }
        [DataMember]
        public string TaskNo { get; set; }
        [DataMember]
        public EntityInt IsKeep { get; set; }
        [DataMember]
        public DateTime RouteCreateTime { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
