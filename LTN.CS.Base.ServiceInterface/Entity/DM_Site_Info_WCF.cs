// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/7/7 16:03:48
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/7 16:03:48
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using LTN.CS.BaseEntities.BM;
using System.Runtime.Serialization;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(SiteTypeObj))]
    [KnownType(typeof(SiteStatusObj))]
    [KnownType(typeof(EntityInt))]
    [KnownType(typeof(SiteTaskStatusObj))]
    public class DM_Site_Info_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public string SiteNo { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public SiteTypeObj SiteType { get; set; }
        [DataMember]
        public EntityInt IsAutoWeigh { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string SiteIP { get; set; }
        [DataMember]
        public string SiteAddress { get; set; }
        [DataMember]
        public string IP2 { get; set; }
        [DataMember]
        public SiteStatusObj SiteStatus { get; set; }
        [DataMember(IsRequired = false)]
        public SiteTaskStatusObj SiteTaskStatus { get; set; }
        [DataMember(IsRequired = false)]
        public EntityInt IsUpload { get; set; }
        [DataMember(IsRequired = false)]
        public int? SiteTaskCount { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime SiteStatusDate { get; set; }
        [DataMember(IsRequired=false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
