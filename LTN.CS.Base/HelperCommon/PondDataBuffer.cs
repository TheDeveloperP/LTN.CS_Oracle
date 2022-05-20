using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.Common;

namespace LTN.CS.Base.HelperCommon
{
    public static class PondDataBuffer
    {
        public static DeviceStatusObj PondStatus { get; set; }
        public static decimal MeterOneWeight { get; set; }
        public static decimal MeterTwoWeight { get; set; }
        public static DeviceStatusObj MeterOneStatus { get; set; }
        public static DeviceStatusObj MeterTwoStatus { get; set; }
        public static DeviceStatusObj IOStatus { get; set; }
        public static DeviceStatusObj Grating1Status { get; set; }
        public static DeviceStatusObj Grating2Status { get; set; }
        public static DeviceStatusObj Print1Status { get; set; }//打印机工作状态
        public static DeviceStatusObj Print2Status { get; set; }//打印机工作状态
        public static DeviceStatusObj Print1ConnectStatus { get; set; }//打印机工作状态
        public static DeviceStatusObj Print2ConnectStatus { get; set; }//打印机工作状态
        public static DeviceStatusObj QRCodeStatus { get; set; }
        public static string Print1ComName { get; set; }//打印机com口，通过com口来选择使用哪个打印机来进行打印
        public static string Print2ComName { get; set; }

        public static string QRCodeStr { get; set; }
        public static bool QRCodeIsNew { get; set; }
        public static bool IsCanReadCard { get; set; } //是否可以称重 判断依据为重量大于300KG
        public static bool IsCompleting { get; set; }  //业务线程是否处理中 
        public static bool IsHasTask { get; set; }  //已经创建任务 （为避免拔卡时再次读卡 任务结束后该属性延迟7秒改为false） 
        public static bool IsConnectedDB { get; set; }  //是否连接到数据库
        public static bool IsRed { get; set; }

        public static int CreateTask { get; set; }

        public static int IsIn_MeterOne = 0;
        public static int IsIn_MeterTwo = 0;
        public static int IsIn_IO = 0;
        public static int IsIn_Print1 = 0;
        public static int IsIn_Print2 = 0;
        public static int IsIn_QRCode = 0;
        public static int IsIn_ICCard = 0;

        public static int IsIn_FormBusiness = 0;
        public static int IsIn_FormMessage = 0;

        public static bool IsWorking { get; set; }
    }
}
