using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LTN.CS.SCMEntities.PM
{
    public class PM_Bill_OrbitWeighterConfirm
    {
        public string T_INTID { get; set; }//业务主键
        public int T_BILLSTATUS { get; set; }//计量状态（0 未完成；1 已完成；2 已作废）
        public string T_CALIBRATE_NO { get; set; }//校磅时间
        public int T_STANDARDWEIGHT { get; set; }//标准重量
        public int T_BEFORE_CALIBRATE { get; set; }//校准前重量
        public int T_AFTER_CALIBRATE { get; set; }//校准后重量
        public string T_CALIBRATE_TIME { get; set; }//校准时间
        public string T_CALIBRATE_MAN { get; set; }//校准人
        public string T_CALIBRATE_MEASURESITE { get; set; }//校准计量点
        public string T_RESERVE_V1 { get; set; }//预留字段
        public string T_RESERVE_V2 { get; set; }//预留字段
        public string T_RESERVE_V3 { get; set; }//预留字段
        public string T_RESERVE_V4 { get; set; }//预留字段
        public string T_RESERVE_V5 { get; set; }//预留字段
        public string T_RESERVE_V6 { get; set; }//预留字段
        
    }
}
