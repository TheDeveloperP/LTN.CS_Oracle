// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMEntities.Common
// Author:kolio
// Created:2016/7/4 16:30:20
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/4 16:30:20
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class SiteStatusObj
    {
        public SiteStatusObj() { }
        public SiteStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public SiteStatus EnumValue
        {
            get
            {
                SiteStatus rs = SiteStatus.Working;
                try
                {
                    rs = (SiteStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<SiteStatusObj> GetSiteStatusData()
        {
            IList<SiteStatusObj> rss = new List<SiteStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(SiteStatus)))
                {
                    rss.Add(new SiteStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string SiteStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(SiteStatus), IntValue);
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
