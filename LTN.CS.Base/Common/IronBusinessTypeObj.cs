using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
     [DataContract]
    public class IronBusinessTypeObj
    {
          public IronBusinessTypeObj() { }
          public IronBusinessTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public IronBusinessType EnumValue
        {
            get
            {
                IronBusinessType rs = IronBusinessType.chongdui;
                try
                {
                    rs = (IronBusinessType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<IronBusinessTypeObj> GetBusinessTypeData()
        {
            IList<IronBusinessTypeObj> rss = new List<IronBusinessTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(IronBusinessType)))
                {
                    rss.Add(new IronBusinessTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string IronBusinessTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(IronBusinessType), IntValue);
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
