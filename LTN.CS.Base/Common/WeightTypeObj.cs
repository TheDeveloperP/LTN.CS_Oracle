using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class WeightTypeObj
    {
        public WeightTypeObj() { }
        public WeightTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public WeightType EnumValue
        {
            get
            {
                WeightType rs = WeightType.GrossActual;
                try
                {
                    rs = (WeightType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<WeightTypeObj> GetWeightTypeData()
        {
            IList<WeightTypeObj> rss = new List<WeightTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(WeightType)))
                {
                    rss.Add(new WeightTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string WeightTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(WeightType), IntValue);
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
