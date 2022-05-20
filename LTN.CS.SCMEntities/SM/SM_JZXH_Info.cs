using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_JZXH_Info:BaseEntity
    {
        public int I_INTID { get; set; }
        //车号1
        public string C_CarName { get; set; }
        //车号2
        public string C_CarName2 { get; set; }
        //车号3
        public string C_CarName3 { get; set; }
        //集装箱号
        public string C_ContainerNO { get; set; }
        //集装箱标识
        public int I_ContainerStatus { get; set; }
        //识别时间
        public string C_CameraTime { get; set; }
        //图片地址
        public string C_PhotoAddress { get; set; }
        //磅点编号
        public string C_PondNo { get; set; }
        //预留字段1
        public string C_Reserve1 { get; set; }
        //预留字段2
        public string C_Reserve2 { get; set; }

    }
}
