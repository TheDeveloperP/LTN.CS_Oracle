// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/9/5 21:10:15
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/9/5 21:10:15
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
    [KnownType(typeof(DM_PondSite_Info_WCF))]
    [KnownType(typeof(DM_Site_Info_WCF))]
    [KnownType(typeof(DM_Task_WCF))]
    public class DM_Route_Query_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public DM_PondSite_Info_WCF Pond { get; set; }
        [DataMember]
        public DM_Site_Info_WCF Site { get; set; }
        [DataMember]
        public DM_Task_WCF Task { get; set; }
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
