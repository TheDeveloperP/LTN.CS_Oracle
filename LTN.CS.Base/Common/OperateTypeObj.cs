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
    public class OperateTypeObj
    {
        public OperateTypeObj() { }
        public OperateTypeObj(int typeInt)
        {
            IntValue = typeInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public OperateType EnumValue
        {
            get
            {
                OperateType rs = OperateType.Insert;
                try
                {
                    rs = (OperateType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<OperateTypeObj> GetOperateTypeData()
        {
            IList<OperateTypeObj> rss = new List<OperateTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(OperateType)))
                {
                    rss.Add(new OperateTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string OperateTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(OperateType), IntValue);
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
