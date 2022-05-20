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
    public class DirectionObj
    {
        public DirectionObj() { }
        public DirectionObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public Direction EnumValue
        {
            get
            {
                Direction rs = Direction.left;
                try
                {
                    rs = (Direction)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<DirectionObj> GetDirectionData()
        {
            IList<DirectionObj> rss = new List<DirectionObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(Direction)))
                {
                    rss.Add(new DirectionObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string DirectionDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(Direction), IntValue);
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
