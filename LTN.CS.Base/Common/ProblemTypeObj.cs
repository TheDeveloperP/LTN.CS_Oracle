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
    public class ProblemTypeObj
    {
        public ProblemTypeObj() { }
        public ProblemTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public ProblemType EnumValue
        {
            get
            {
                ProblemType rs = ProblemType.NoProblem;
                try
                {
                    rs = (ProblemType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<ProblemTypeObj> GetProblemTypeData()
        {
            IList<ProblemTypeObj> rss = new List<ProblemTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(ProblemType)))
                {
                    rss.Add(new ProblemTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string ProblemTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(ProblemType), IntValue);
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
