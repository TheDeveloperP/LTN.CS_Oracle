using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_TruckBillWithOnlineBill
    {
        public string C_PLANNO { get; set; }     //委托单号 
        public string C_MATERIALNAME { get; set; } //品名名称   
        public string C_FROMDEPTNAME { get; set; } //来源单位名称  
        public string C_TODEPTNAME { get; set; }       //去向单位名称  
        public string C_WGTLISTNO { get; set; } //磅单号 VARCHAR2(30)
        public int N_TAREWGT { get; set; } //皮重  NUMBER(10)
        public int N_GROSSWGT { get; set; } // 毛重  NUMBER(10)
        public int N_NETWGT { get; set; } //净重  NUMBER(10)
        /// <summary>
        /// 材料总重量
        /// </summary>
        public int Mat_Act_Wgt { get; set; }
        /// <summary>
        /// 净重与材料总重量的差值
        /// </summary>
        public int wgt_sub { get; set; }
        public string C_TAREWGTTIME { get; set; } //皮重时间    VARCHAR2(20)
        public string C_GROSSWGTTIME { get; set; } //毛重时间    VARCHAR2(20)
        public string C_NETWGTTIME { get; set; } //净重时间    VARCHAR2(20)
        public List<PM_Bill_OnlineScale> OnLineBills { get; set; } //在线称磅单
    }
}
