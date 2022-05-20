using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class WeightTypesObj
    {
        public WeightTypesObj() { }
        public WeightTypesObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public WeightTypes EnumValue
        {
            get
            {
                WeightTypes rs = WeightTypes.FirstTareThenGross;
                try
                {
                    rs = (WeightTypes)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<WeightTypesObj> GetWeightTypesData()
        {
            IList<WeightTypesObj> rss = new List<WeightTypesObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(WeightTypes)))
                {
                    rss.Add(new WeightTypesObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string WeightTypesDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(WeightTypes), IntValue);
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
