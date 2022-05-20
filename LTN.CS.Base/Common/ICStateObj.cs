using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class ICStateObj
    {
        public ICStateObj() { }
        public ICStateObj(int typeInt)
        {
            IntValue = typeInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public ICState EnumValue
        {
            get
            {
                ICState rs = ICState.Empty;
                try
                {
                    rs = (ICState)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<ICStateObj> GetICStateData()
        {
            IList<ICStateObj> rss = new List<ICStateObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(ICState)))
                {
                    rss.Add(new ICStateObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string ICStateDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(ICState), IntValue);
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
