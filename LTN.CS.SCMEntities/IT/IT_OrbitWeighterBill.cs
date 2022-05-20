using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_OrbitWeighterBill : BaseEntity
    {
        public string T_OPERATE_FLAG { get; set; }//操作标识
        public string T_STATUS { get; set; }//状态（0,自动;1,手动）
        public string T_PRODUCT_TIME { get; set; }//生产时间
        public string T_PRODUCT_SCHEDULE { get; set; }//生产班次
        public string T_PRODUCT_CLASS { get; set; }//生产班组
        public string T_PRODUCT_MAN { get; set; }//生产责任人
        public string T_REMARK { get; set; }//备注
        public string T_POND_ID { get; set; }//磅号
        public string T_MARCHINE_CODE { get; set; }//机组号
        public string T_WEIGHT_TIME { get; set; }//过磅时间
        public string T_MAT_NO { get; set; }//材料号
        public Double T_THEORETICAL_WEIGHT { get; set; }//理论重量
        public Double T_ACTUAL_WEIGHT { get; set; }//实际重量
        public string T_MAT_SPEC { get; set; }//材料规格
        public string T_RESERVE_V1 { get; set; }
        public string T_RESERVE_V2 { get; set; }
        public string T_RESERVE_V3 { get; set; }
        public string T_RESERVE_V4 { get; set; }
        public string T_RESERVE_V5 { get; set; }
        public string T_RESERVE_V6 { get; set; }
        public string T_RESERVE_V7 { get; set; }
        public string T_RESERVE_V8 { get; set; }
        public string T_RESERVE_V9 { get; set; }
        public string T_RESERVE_V10 { get; set; }
        public string T_UPLOAD_FLAG { get; set; }//上传状态  I U D

    }
}
