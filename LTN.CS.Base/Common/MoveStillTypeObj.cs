using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class MoveStillTypeObj
    {
        public MoveStillTypeObj() { }
        public MoveStillTypeObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public MoveStillType EnumValue
        {
            get
            {
                MoveStillType rs = MoveStillType.StaticState;
                try
                {
                    rs = (MoveStillType)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<MoveStillTypeObj> GetMoveStillTypeData()
        {
            IList<MoveStillTypeObj> rss = new List<MoveStillTypeObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(MoveStillType)))
                {
                    rss.Add(new MoveStillTypeObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string MoveStillTypeDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(MoveStillType), IntValue);
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
