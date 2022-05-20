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
    public class BillTypeObj
    {
        public BillTypeObj() { }
        public BillTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BillType EnumValue
        {
            get
            {
                BillType rs = BillType.OutLine;
                try
                {
                    rs = (BillType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<BillTypeObj> GetBillTypeData()
        {
            IList<BillTypeObj> rss = new List<BillTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BillType)))
                {
                    rss.Add(new BillTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BillTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BillType), IntValue);
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
