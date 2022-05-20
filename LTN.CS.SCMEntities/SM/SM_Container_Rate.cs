using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Container_Rate
    {
        public int IntId { get; set; }    //	主键
        public int I_RecognitionStatus { get; set; }    //	集装箱识别情况 0失败 1成功
        public string C_ContainerTime { get; set; } //	识别时间
        public string C_ContainerNo { get; set; }   //	集装箱号（识别）
        public string C_PlanContainerNo { get; set; }   //	集装箱号（委托）
        public string C_CreateTime { get; set; }    //	创建时间
        public string C_CreateUserName { get; set; }    //	创建人
        public string C_PondNo { get; set; }	//	磅点编号


    }
}
