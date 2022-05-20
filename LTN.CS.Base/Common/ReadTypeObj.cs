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
    public class ReadTypeObj
    {
        public ReadTypeObj() { }
        public ReadTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public ReadType EnumValue
        {
            get
            {
                ReadType rs = ReadType.text;
                try
                {
                    rs = (ReadType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<ReadTypeObj> GetReadTypeData()
        {
            IList<ReadTypeObj> rss = new List<ReadTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(ReadType)))
                {
                    rss.Add(new ReadTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string ReadTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(ReadType), IntValue);
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
