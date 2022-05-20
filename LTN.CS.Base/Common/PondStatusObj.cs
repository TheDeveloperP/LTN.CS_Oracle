// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMEntities.Common
// Author:kolio
// Created:2016/7/4 16:15:01
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/4 16:15:01
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class PondStatusObj
    {
        public PondStatusObj() { }
        public PondStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public PondStatus EnumValue
        {
            get
            {
                PondStatus rs = PondStatus.Working;
                try
                {
                    rs = (PondStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<PondStatusObj> GetPondStatusData()
        {
            IList<PondStatusObj> rss = new List<PondStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(PondStatus)))
                {
                    rss.Add(new PondStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string PoundStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(PondStatus), IntValue);
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
