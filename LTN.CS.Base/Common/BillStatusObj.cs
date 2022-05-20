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
    public class BillStatusObj
    {
        public BillStatusObj() { }
        public BillStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BillStatus EnumValue
        {
            get
            {
                BillStatus rs = BillStatus.NoMeasure;
                try
                {
                    rs = (BillStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<BillStatusObj> GetBillStatusData()
        {
            IList<BillStatusObj> rss = new List<BillStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BillStatus)))
                {
                    rss.Add(new BillStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BillStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BillStatus), IntValue);
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
