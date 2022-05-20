using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
     [DataContract]
    public class PlanbillStatusObj
    {
        public PlanbillStatusObj() { }
        public PlanbillStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public PlanbillStatus EnumValue
        {
            get
            {
                PlanbillStatus rs = PlanbillStatus.NoPlan;
                try
                {
                    rs = (PlanbillStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<PlanbillStatusObj> GetBillStatusData()
        {
            IList<PlanbillStatusObj> rss = new List<PlanbillStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(PlanbillStatus)))
                {
                    rss.Add(new PlanbillStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string BillStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(PlanbillStatus), IntValue);
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
