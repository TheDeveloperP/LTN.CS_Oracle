// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/8/5 10:08:32
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 10:08:32
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.Common;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(BaseOperateMethodObj))]
    public class DM_Message_To_PondSite_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public int TaskId { get; set; }
        [DataMember]
        public string TaskNo { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int PondId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public BaseOperateMethodObj Command { get; set; }
        [DataMember]
        public DateTime MessageTime { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
