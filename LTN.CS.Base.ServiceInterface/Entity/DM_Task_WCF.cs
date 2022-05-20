// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/8/5 9:32:03
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 9:32:03
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using System.Runtime.Serialization;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(SiteTypeObj))]
    [KnownType(typeof(TaskStatusObj))]
    [KnownType(typeof(EntityInt))]
    public class DM_Task_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public string TaskNo { get; set; }
        [DataMember]
        public SiteTypeObj TaskType { get; set; }
        [DataMember]
        public string TaskData { get; set; }
        [DataMember]
        public int? PondId { get; set; }
        [DataMember]
        public int? SiteId { get; set; }
        [DataMember]
        public int? ToPondId { get; set; }
        [DataMember]
        public EntityInt IsKeep { get; set; }
        [DataMember]
        public EntityInt IsAutoWeight { get; set; }
        [DataMember(IsRequired = false)]
        public TaskStatusObj TaskStatus { get; set; }
        [DataMember]
        public DateTime TaskCreateTime { get; set; }
        [DataMember]
        public DateTime? RouteCreateTime { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
