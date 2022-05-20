// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/7/13 8:48:37
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/13 8:48:37
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LTN.CS.Base.Common;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(DeviceStatusObj))]
    public class DM_PondSite_Monitor_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public int PondId { get; set; }
        [DataMember]
        public string PondSiteNo { get; set; }
        [DataMember]
        public decimal MeterOneWeight { get; set; }
        [DataMember]
        public decimal MeterTwoWeight { get; set; }
        [DataMember]
        public decimal MeterSumWeight { get; set; }
        [DataMember]
        public DeviceStatusObj MeterOneStatus { get; set; }
        [DataMember]
        public DeviceStatusObj MeterTwoStatus { get; set; }
        [DataMember]
        public DeviceStatusObj InfraRedOneStatus { get; set; }
        [DataMember]
        public DeviceStatusObj InfraRedTwoStatus { get; set; }
        [DataMember]
        public DeviceStatusObj InfraRedThreeStatus { get; set; }
        [DataMember]
        public DeviceStatusObj InfraRedFourStatus { get; set; }
        [DataMember]
        public DeviceStatusObj DVRStatus { get; set; }
        [DataMember]
        public DeviceStatusObj PrintOneStatus { get; set; }
        [DataMember]
        public DeviceStatusObj PrintTwoStatus { get; set; }
        [DataMember]
        public DeviceStatusObj TrafficOneStatus { get; set; }
        [DataMember]
        public DeviceStatusObj TrafficTwoStatus { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
    }
}
