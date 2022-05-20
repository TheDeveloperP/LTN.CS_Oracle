using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class TrainWagonTypeObj
    {
        public TrainWagonTypeObj() { }
        public TrainWagonTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public TrainWagonType EnumValue
        {
            get
            {
                TrainWagonType rs = TrainWagonType.MarkedTare;
                try
                {
                    rs = (TrainWagonType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<TrainWagonTypeObj> GetTrainWagonTypeData()
        {
            IList<TrainWagonTypeObj> rss = new List<TrainWagonTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(TrainWagonType)))
                {
                    rss.Add(new TrainWagonTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string TrainWagonTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(TrainWagonType), IntValue);
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