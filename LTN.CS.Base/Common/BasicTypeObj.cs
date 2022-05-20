using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class BasicTypeObj
    {
        public BasicTypeObj() { }
        public BasicTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BasicType EnumValue
        {
            get
            {
                BasicType rs = BasicType.OutSource;
                try
                {
                    rs = (BasicType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<BasicTypeObj> GetBasicTypeData()
        {
            IList<BasicTypeObj> rss = new List<BasicTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BasicType)))
                {
                    rss.Add(new BasicTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BasicTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BasicType), IntValue);
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
