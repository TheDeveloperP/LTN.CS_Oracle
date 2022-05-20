using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class DataFlagTypeObj
    {
        public DataFlagTypeObj() { }
        public DataFlagTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public DataFlagType EnumValue
        {
            get
            {
                DataFlagType rs = DataFlagType.WeiDeal2;
                try
                {
                    rs = (DataFlagType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<DataFlagTypeObj> GetAuthTypeData()
        {
            IList<DataFlagTypeObj> rss = new List<DataFlagTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(DataFlagType)))
                {
                    rss.Add(new DataFlagTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }


        public string DataFlagTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(DataFlagType), IntValue);
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
