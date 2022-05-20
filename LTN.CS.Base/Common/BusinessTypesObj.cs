using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class BusinessTypesObj
    {
        public BusinessTypesObj() { }
        public BusinessTypesObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public BusinessTypes EnumValue
        {
            get
            {
                BusinessTypes rs = BusinessTypes.InFactory;
                try
                {
                    rs = (BusinessTypes)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<BusinessTypesObj> GetBusinessTypesData()
        {
            IList<BusinessTypesObj> rss = new List<BusinessTypesObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(BusinessTypes)))
                {
                    rss.Add(new BusinessTypesObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BusinessTypesDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(BusinessTypes), IntValue);
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
