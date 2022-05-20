using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class IcCarTypeObj
    {
        public IcCarTypeObj() { }
        public IcCarTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public IcCarType EnumValue
        {
            get
            {
                IcCarType rs = IcCarType.LongTermCard;
                try
                {
                    rs = (IcCarType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<IcCarTypeObj> GetBillTypeData()
        {
            IList<IcCarTypeObj> rss = new List<IcCarTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(IcCarType)))
                {
                    rss.Add(new IcCarTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string IcCarTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(IcCarType), IntValue);
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
