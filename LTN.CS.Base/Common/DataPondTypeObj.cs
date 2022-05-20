using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class DataPondTypeObj
    {
        public DataPondTypeObj() { }
        public DataPondTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }

        public DataPondType EnumValue
        {
            get
            {
                DataPondType rs = DataPondType.CarPond;
                try
                {
                    rs = (DataPondType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }


        public static IList<DataPondTypeObj> GetAuthTypeData()
        {
            IList<DataPondTypeObj> rss = new List<DataPondTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(DataPondType)))
                {
                    rss.Add(new DataPondTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }


        public string DataPondTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(DataPondType), IntValue);
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

