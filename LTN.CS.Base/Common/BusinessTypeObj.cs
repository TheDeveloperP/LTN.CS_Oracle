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
    public class BusinessTypeObj
    {
        public BusinessTypeObj() { }
        public BusinessTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BusinessType EnumValue
        {
            get
            {
                BusinessType rs = BusinessType.LimitFromArea;
                try
                {
                    rs = (BusinessType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<BusinessTypeObj> GetBusinessTypeData()
        {
            IList<BusinessTypeObj> rss = new List<BusinessTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BusinessType)))
                {
                    rss.Add(new BusinessTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BusinessTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BusinessType), IntValue);
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
