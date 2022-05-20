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
    public class AreaTypeObj
    {
        public AreaTypeObj() { }
        public AreaTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public AreaType EnumValue
        {
            get
            {
                AreaType rs = AreaType.LimitNull;
                try
                {
                    rs = (AreaType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<AreaTypeObj> GetAreaTypeData()
        {
            IList<AreaTypeObj> rss = new List<AreaTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(AreaType)))
                {
                    rss.Add(new AreaTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string AreaTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(AreaType), IntValue);
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
