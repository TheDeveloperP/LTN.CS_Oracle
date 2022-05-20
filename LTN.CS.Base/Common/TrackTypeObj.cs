using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class TrackTypeObj
    {
        public TrackTypeObj() { }
        public TrackTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public TrackType EnumValue
        {
            get
            {
                TrackType rs = TrackType.MoveTrack;
                try
                {
                    rs = (TrackType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<TrackTypeObj> GetTrackTypeData()
        {
            IList<TrackTypeObj> rss = new List<TrackTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(TrackType)))
                {
                    rss.Add(new TrackTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string TrackTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(TrackType), IntValue);
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
