using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class TareTypeObj
    {
        public TareTypeObj() { }
        public TareTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public TareType EnumValue
        {
            get
            {
                TareType rs = TareType.ActualTare;
                try
                {
                    rs = (TareType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<TareTypeObj> GetTareTypeData()
        {
            IList<TareTypeObj> rss = new List<TareTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(TareType)))
                {
                    rss.Add(new TareTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string TareTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(TareType), IntValue);
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
