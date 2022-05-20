// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Helper
// Author:kolio
// Created:2016/7/4 15:48:47
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/4 15:48:47
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class RawDataStatusObj
    {
        public RawDataStatusObj() { }
        public RawDataStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public RawDataStatus EnumValue
        {
            get
            {
                RawDataStatus rs = RawDataStatus.receive;
                try
                {
                    rs = (RawDataStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<RawDataStatusObj> GetRawDataStatusData()
        {
            IList<RawDataStatusObj> rss = new List<RawDataStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(RawDataStatus)))
                {
                    rss.Add(new RawDataStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string RawDataStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(RawDataStatus), IntValue);
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
