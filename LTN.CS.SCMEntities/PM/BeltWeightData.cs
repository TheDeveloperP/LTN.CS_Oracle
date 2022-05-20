using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class BeltWeightData
    {
        public string BELTNO { get; set; }  //皮带编号
        public string BELTNAME { get; set; }    //皮带名称
        public DateTime COLLTIME { get; set; }  //启停和整点计划时间
        public decimal ACCUWEIGHT { get; set; } //采集重量
        public DateTime METERTIME { get; set; }// 仪表时间
    }
}
