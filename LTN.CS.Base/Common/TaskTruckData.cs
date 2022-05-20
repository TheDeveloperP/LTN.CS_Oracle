using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LTN.CS.Base.Common
{
    [Serializable]
    public class TaskTruckData
    {
        /// <summary>
        /// 称重类型 0求助 1皮重 2毛重
        /// </summary>
        public int WeightType { get; set; }
        /// <summary>
        /// 计划ID
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 司机手动选择车号
        /// </summary>
        public string SelectCarNo { get; set; }
        /// <summary>
        /// 车牌识别车号
        /// </summary>
        public string CameraCarNo { get; set; }
        /// <summary>
        /// RFID车号
        /// </summary>
        public string RfidCarNo { get; set; }
        /// <summary>
        /// 非自动过磅理由
        /// </summary>
        public string Reason{ get; set; }
    }
}
