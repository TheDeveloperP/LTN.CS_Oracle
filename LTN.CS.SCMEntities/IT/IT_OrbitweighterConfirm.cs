using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_OrbitweighterConfirm:BaseEntity
    {
        public string T_CALIBRATE_NO { get; set; }//校磅记录唯一标识
        public string T_OPERATE_FLAG { get; set; }//操作标识（I、U、D)
        public Double T_STANDARDWEIGHT { get; set; }//标准重量
        public Double T_BEFORE_CALIBRATE { get; set; }//校准前重量
        public Double T_AFTER_CALIBRATE { get; set; }//校准后重量
        public string T_CALIBRATE_TIME { get; set; }//校准时间
        public string T_CALIBRATE_MAN { get; set; }//校准人员
        public string T_CALIBRATE_MEASURESITE { get; set; }//校准计量点
        public string T_RESERVE_V1 { get; set; }//预留字段1
        public string T_RESERVE_V2 { get; set; }//预留字段2
        public string T_RESERVE_V3 { get; set; }//预留字段3
        public string T_RESERVE_V4 { get; set; }//预留字段4
        public string T_RESERVE_V5 { get; set; }//预留字段5
        public string T_RESERVE_V6 { get; set; }//预留字段6
        public string T_UPLOAD_FLAG { get; set; }//接收状态（N未接受,Y接受）
    }
}
