using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    public class IssuingStateObj
    {
        public IssuingStateObj() { }
        public IssuingStateObj(int methodInt)
        {
            IntValue = methodInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public IssuingState EnumValue
        {
            get
            {
                IssuingState rs = IssuingState.Regist;
                try
                {
                    rs = (IssuingState)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<IssuingStateObj> GetIssuingStateData()
        {
            IList<IssuingStateObj> rss = new List<IssuingStateObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(IssuingState)))
                {
                    rss.Add(new IssuingStateObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string IssuingStateDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(IssuingState), IntValue);
                    if (EnumName != null)
                    {
                        rs = EnumName;
                        rs = LTN.CS.Base.Properties.Resources.ResourceManager.GetString(EnumName);
                    }
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
    }
}
