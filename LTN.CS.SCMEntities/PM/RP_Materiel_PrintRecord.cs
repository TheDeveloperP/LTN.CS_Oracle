using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class RP_Materiel_PrintRecord
    {
        public int IntId { get; set; }//主键
        public string WgtlistNo { get; set; }//码单号
        public string PlanNo { get; set; }//委托单号
        public string MaterialName { get; set; }//品名名称
        public string Printer { get; set; }//打印人
        public string PrintTime { get; set; }//打印时间
        public string WagNo { get; set; }//车皮号
    }
}
