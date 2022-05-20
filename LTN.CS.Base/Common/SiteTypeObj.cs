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
    public class SiteTypeObj
    {
        public SiteTypeObj() { }
        public SiteTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public SiteType EnumValue
        {
            get
            {
                SiteType rs = SiteType.CarPound;
                try
                {
                    rs = (SiteType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<SiteTypeObj> GetSiteTypeData()
        {
            IList<SiteTypeObj> rss = new List<SiteTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(SiteType)))
                {
                    rss.Add(new SiteTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string SiteTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(SiteType), IntValue);
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
