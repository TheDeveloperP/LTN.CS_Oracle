using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class TrainTypeObj
    {
        public TrainTypeObj() { }
        public TrainTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public TrainType EnumValue
        {
            get
            {
                TrainType rs = TrainType.InsideTrain;
                try
                {
                    rs = (TrainType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<TrainTypeObj> GetTrainTypeData()
        {
            IList<TrainTypeObj> rss = new List<TrainTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(TrainType)))
                {
                    rss.Add(new TrainTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string TrainTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(TrainType), IntValue);
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