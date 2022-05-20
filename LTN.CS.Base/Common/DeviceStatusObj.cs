// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/7/12 15:45:31
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/12 15:45:31
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class DeviceStatusObj
    {
        public DeviceStatusObj() { }
        public DeviceStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public DeviceStatus EnumValue
        {
            get
            {
                DeviceStatus rs = DeviceStatus.Working;
                try
                {
                    rs = (DeviceStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<DeviceStatusObj> GetDeviceStatusData()
        {
            IList<DeviceStatusObj> rss = new List<DeviceStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(DeviceStatus)))
                {
                    rss.Add(new DeviceStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }
        public string DeviceStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(DeviceStatus), IntValue);
                    rs = EnumName;
                    rs = LTN.CS.Base.Properties.Resources.ResourceManager.GetString(EnumName);
                }
                catch (Exception)
                {
                    
                }
                return rs;
            }
        }
    }
}
