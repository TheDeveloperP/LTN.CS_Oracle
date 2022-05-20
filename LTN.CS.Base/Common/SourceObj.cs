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
    public class SourceObj
    {
        public SourceObj() { }
        public SourceObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public Source EnumValue
        {
            get
            {
                Source rs = Source.InSysCreate;
                try
                {
                    rs = (Source)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<SourceObj> GetSourceData()
        {
            IList<SourceObj> rss = new List<SourceObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(Source)))
                {
                    rss.Add(new SourceObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string SourceDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(Source), IntValue);
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
