using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_PoundService_Info: BaseEntity
    {
        public int IntId { get; set; }           //主键
        public SM_Dvr_Info DVRID { get; set; }      //硬盘录像机主键
        public SM_PoundSite_Info PoundId { get; set; }         //磅房主键
        public SM_Meter_Info MeterId1 { get; set; }   //仪表标识1
        public SM_Meter_Info MeterId2 { get; set; }   //仪表标识2
        public SM_LPRCamera LPRCAMERAID1 { get; set; }      //车牌识别标识1
        public SM_LPRCamera LPRCAMERAID2 { get; set; }      //车牌识别标识2
        public string SignalCOM1 { get; set; } //红绿灯串口1
        public string SignalCOM2 { get; set; } //红绿灯串口2
        public string PrintCOM1 { get; set; }  //打印机串口1
        public string PrintCOM2 { get; set; }  //打印机串口2
        public int PrintBAUD1 { get; set; } //打印机1波特率
        public int PrintBAUD2 { get; set; } //打印机2波特率
        public string RFIDCOM { get; set; }    //RFID串口
        public int RFIDBAUD { get; set; }   //RFID波特率
        public string RESERVE1 { get; set; }   //预留字段1
        public string RESERVE2 { get; set; }   //预留字段2
        public string METERCOM1 { get; set; }  //仪表1串口号
        public int METERBAUD1 { get; set; }    //仪表1波特率
        public int METERCHECK1 { get; set; }   //仪表1校验方式，默认为0
        public int METERSTARTBIT1 { get; set; } //仪表1开始位，默认为0
        public int METERSTOPBIT1 { get; set; }  //仪表1停止位，默认为0
        public string METERCOM2 { get; set; }  //仪表2串口号
        public int METERBAUD2 { get; set; }    //仪表2波特率
        public int METERCHECK2 { get; set; }   //仪表2校验方式，默认为0
        public int METERSTARTBIT2 { get; set; } //仪表2开始位，默认为0
        public int METERSTOPBIT2 { get; set; }  //仪表2停止位，默认为0
        public string INFRAREDGRATING1 { get; set; }    //红外光栅1通道号
        public string INFRAREDGRATING2 { get; set; }    //红外光栅2通道号
        public string IOCOMNO { get; set; } //IO设备串口编号
        public int IOBAUD { get; set; } //IO设备串口波特率
        public int IOCHECK { get; set; } //IO设备串口校验方式
        public int IOSTARTBIT { get; set; } //IO设备串口数据位
        public int IOSTOPBIT { get; set; } //IO设备串口数据停止位
        public string CreateUserName { get; set; }//创建人员
        public string UpdateUserName { get; set; }//修改人员
        public string createTime { get; set; }//创建时间
        public string updateTime { get; set; }//修改时间















    }
}
