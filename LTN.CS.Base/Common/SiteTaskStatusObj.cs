// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/8 10:52:44
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/8 10:52:44
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class SiteTaskStatusObj
    {
        public SiteTaskStatusObj() { }
        public SiteTaskStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public SiteTaskStatus EnumValue
        {
            get
            {
                SiteTaskStatus rs = SiteTaskStatus.FreeTask;
                try
                {
                    rs = (SiteTaskStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<SiteTaskStatusObj> GetSiteTaskStatusData()
        {
            IList<SiteTaskStatusObj> rss = new List<SiteTaskStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(SiteTaskStatus)))
                {
                    rss.Add(new SiteTaskStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string SiteTaskStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(SiteTaskStatus), IntValue);
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
