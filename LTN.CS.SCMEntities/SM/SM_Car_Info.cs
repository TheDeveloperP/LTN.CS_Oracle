using LTN.CS.BaseEntities.BM;
using LTN.CS.Core;
using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Car_Info
    {
        public int IntId { get; set; }
        public string CarNo { get; set; }
        public string CarName { get; set; }
        public string CarPeople { get; set; }
        public string CarTelephone { get; set; }
        public decimal StandardTare { get; set; }
        public EntityInt IsAuto { get; set; } //是否开启自助计量  1 是  0否
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }

    //public enum AutoEnum
    //{
    //    Yes=1,
    //    No=0
    //}
}
