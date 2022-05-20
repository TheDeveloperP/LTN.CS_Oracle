// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/7/13 10:43:53
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/13 10:43:53
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using System.Runtime.Serialization;
using LTN.CS.Base.Common;
using LTN.CS.BaseEntities.BM;
using System.Reflection;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    public class DM_PondSite_Monitor_Date_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public int PondId { get; set; }
        [DataMember]
        public string PondSiteNo { get; set; }
        [DataMember]
        public DateTime? MeterOneTime { get; set; }
        [DataMember]
        public DateTime? MeterTwoTime { get; set; }
        [DataMember]
        public DateTime? InfraRedOneTime { get; set; }
        [DataMember]
        public DateTime? InfraRedTwoTime { get; set; }
        [DataMember]
        public DateTime? InfraRedThreeTime { get; set; }
        [DataMember]
        public DateTime? InfraRedFourTime { get; set; }
        [DataMember]
        public DateTime? DVRTime { get; set; }
        [DataMember]
        public DateTime? PrintOneTime { get; set; }
        [DataMember]
        public DateTime? PrintTwoTime { get; set; }
        [DataMember]
        public DateTime? TrafficOneTime { get; set; }
        [DataMember]
        public DateTime? TrafficTwoTime { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }

        public static void CreateEntityForByMonitor(DM_PondSite_Monitor_WCF monitor,ref DM_PondSite_Monitor_Date_WCF rs,bool isInsert)
        {
            try
            {
                Dictionary<string, bool> tempdic = new Dictionary<string, bool>();
                rs = rs ?? new DM_PondSite_Monitor_Date_WCF();
                rs.PondId = monitor.PondId;
                rs.PondSiteNo = monitor.PondSiteNo;
                PropertyInfo[] monitorfields = monitor.GetType().GetProperties();
                foreach (PropertyInfo info in monitorfields)
                {
                    if (info.PropertyType.Equals(typeof(DeviceStatusObj)))
                    {
                        tempdic.Add(info.Name.Replace("Status", ""), info.GetValue(monitor, null) == null);
                    }
                }
                PropertyInfo[] monitorDatefields = rs.GetType().GetProperties();
                foreach (PropertyInfo info in monitorDatefields)
                {
                    if (info.PropertyType.Equals(typeof(DateTime?)))
                    {
                        string nameTemp = info.Name.Replace("Time", "");
                        if (tempdic.ContainsKey(nameTemp))
                        {
                            if (isInsert)
                            {
                                if (!tempdic[nameTemp])
                                {
                                    info.SetValue(rs, null, null);
                                }
                                else
                                {
                                    info.SetValue(rs, DateTime.MinValue, null);
                                }
                            }
                            else
                            {
                                if (!tempdic[nameTemp])
                                {
                                    info.SetValue(rs, null, null);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
