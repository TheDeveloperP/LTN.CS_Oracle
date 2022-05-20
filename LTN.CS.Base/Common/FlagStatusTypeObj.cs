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
    public class FlagStatusTypeObj
    {
        public FlagStatusTypeObj() { }
        public FlagStatusTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public FlagStatusType EnumValue
        {
            get
            {
                FlagStatusType rs = FlagStatusType.UnFinished;
                try
                {
                    rs = (FlagStatusType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<FlagStatusTypeObj> GetFlagStatusTypeData()
        {
            IList<FlagStatusTypeObj> rss = new List<FlagStatusTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(FlagStatusType)))
                {
                    rss.Add(new FlagStatusTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string FlagStatusTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(FlagStatusType), IntValue);
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
