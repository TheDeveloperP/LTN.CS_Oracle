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
    public class PondTypeObj
    {
        public PondTypeObj() { }
        public PondTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public PondType EnumValue
        {
            get
            {
                PondType rs = PondType.CarPound;
                try
                {
                    rs = (PondType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<PondTypeObj> GetPondTypeData()
        {
            IList<PondTypeObj> rss = new List<PondTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(PondType)))
                {
                    rss.Add(new PondTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string PondTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(PondType), IntValue);
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
