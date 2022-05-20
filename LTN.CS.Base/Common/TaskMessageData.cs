using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    [Serializable]
    public class TaskMessageData
    {
        /// <summary>
        /// 磅单纸张数 
        /// </summary>
        public int IntData1 { get; set; }  
        /// <summary>
        /// 0自动切换
        /// </summary>
        public int IntData2 { get; set; } 
        /// <summary>
        /// 车号
        /// </summary>
        public string StringData1{ get; set; } 
        /// <summary>
        /// 物资品名
        /// </summary>
        public string StringData2 { get; set; } 
        /// <summary>
        /// 供货单位
        /// </summary>
        public string StringData3 { get; set; }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string StringData4 { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public string StringData5 { get; set; }
        /// <summary>
        /// 毛重时间
        /// </summary>
        public string StringData6 { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public string StringData7 { get; set; }
        /// <summary>
        /// 皮重时间
        /// </summary>
        public string StringData8 { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public string StringData9 { get; set; }
        /// <summary>
        /// 磅单号
        /// </summary>
        public string StringData10{ get; set; }
        /// <summary>
        /// 计量员
        /// </summary>
        public string StringData11{ get; set; }
        /// <summary>
        /// 打印点
        /// </summary>
        public string StringData12 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string StringData13 { get; set; }
        /// <summary>
        /// 委托单号
        /// </summary>
        public string StringData14 { get; set; }
        /// <summary>
        /// 中间单位名称
        /// </summary>
        public string StringData15 { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string StringData16 { get; set; }
    }
}
