// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/5 11:25:33
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 11:25:33
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class BaseOperateMethodObj
    {
        
        public BaseOperateMethodObj() { }
        public BaseOperateMethodObj(int methodInt)
        {
            IntValue = methodInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BaseOperateMethod EnumValue
        {
            get
            {
                BaseOperateMethod rs = BaseOperateMethod.OtherOperate;
                try
                {
                    rs = (BaseOperateMethod)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<BaseOperateMethodObj> GetBaseOperateMethodData()
        {
            IList<BaseOperateMethodObj> rss = new List<BaseOperateMethodObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BaseOperateMethod)))
                {
                    rss.Add(new BaseOperateMethodObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BaseOperateMethodDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BaseOperateMethod), IntValue);
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
