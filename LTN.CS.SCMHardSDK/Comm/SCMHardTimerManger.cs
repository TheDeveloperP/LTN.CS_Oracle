// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.Comm
// Author:kolio
// Created:2016/11/7 10:36:56
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/7 10:36:56
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Common;
using LTN.CS.SCMEntities.SM;
using Spring.Context;
using Spring.Context.Support;
using LTN.CS.Base.MeterOperate.Interface;
using LTN.CS.Core.Helper;
using LTN.CS.SCMHardSDK.SDKInterface;
using LTN.CS.SCMHardSDK.IOModelSDK;
using LTN.CS.SCMHardSDK.PrintSDK;
using LTN.CS.SCMHardSDK.ICSDK;
using LTN.CS.SCMHardSDK.QCCodeSDK;
using LTN.CS.Base.ServiceInterface.Interface;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Entity;
using Common.Logging;

namespace LTN.CS.SCMHardSDK.Comm
{
    public class SCMHardTimerManger : IDisposable
    {
        #region Timers
        private Timer timer_MeterOne = null;
        private Timer timer_MeterTwo = null;
        private Timer timer_IO = null;
        private Timer timer_Print1 = null;
        private Timer timer_Print2 = null;
        private Timer timer_QRCode = null;
        private Timer timer_ICCard = null;
        private Timer timer_ForUpLoad = null;
        private Timer timer_ForClearMemory = null;
        private readonly IApplicationContext ctx = ContextRegistry.GetContext();
        private IDM_PondSite_Monitor_WCFService pondSiteMonitorWCFservice { get; set; }
        private ChannelFactory<IDM_PondSite_Monitor_WCFService> PondSite_Monitorfactory { get; set; }
        private static IMeterOperate MeterOne { get; set; }
        private static IMeterOperate MeterTwo { get; set; }
        public static decimal DefuleWeight = 300;
        public static bool CanChangeLight = true;
        private IList<RtuMasterWriteInfo> infos = new List<RtuMasterWriteInfo>();
        /// <summary>
        /// 日志
        /// </summary>
        private readonly static ILog log = LogManager.GetLogger("infoAppender");
        #endregion

        #region 单例模式
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (timer_MeterOne != null)
                {
                    timer_MeterOne.Dispose();
                    timer_MeterOne = null;
                }
                if (timer_MeterTwo != null)
                {
                    timer_MeterTwo.Dispose();
                    timer_MeterTwo = null;
                }
                if (timer_IO != null)
                {
                    timer_IO.Dispose();
                    timer_IO = null;
                }
                if (timer_Print1 != null)
                {
                    timer_Print1.Dispose();
                    timer_Print1 = null;
                }
                if (timer_Print2 != null)
                {
                    timer_Print2.Dispose();
                    timer_Print2 = null;
                }
                if (timer_QRCode != null)
                {
                    timer_QRCode.Dispose();
                    timer_QRCode = null;
                }
                if (timer_ICCard != null)
                {
                    timer_ICCard.Dispose();
                    timer_ICCard = null;
                }
                if (timer_ForUpLoad != null)
                {
                    timer_ForUpLoad.Dispose();
                    timer_ForUpLoad = null;
                }
                if (timer_ForClearMemory != null)
                {
                    timer_ForClearMemory.Dispose();
                    timer_ForClearMemory = null;
                }
                if (PondSite_Monitorfactory != null)
                {
                    try
                    {
                        PondSite_Monitorfactory.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        ~SCMHardTimerManger()
        {
            Dispose(false);
        }
        private SCMHardTimerManger()
        {

        }
        private readonly static SCMHardTimerManger Api = new SCMHardTimerManger();
        public static SCMHardTimerManger CreateInstance() { return Api; }
        #endregion 单例模式

        #region 初始化

        public void Init()
        {
            try
            {
                if (PondDataBuffer.PondStatus != null && PondDataBufferLocal.PondSite != null)
                {
                    if (PondDataBufferLocal.PondSite != null && PondDataBufferLocal.PondSite.PondSiteStatus.EnumValue == PondStatus.Working)
                    {
                        PondDataBuffer.IsWorking = true;
                    }
                    else
                    {
                        PondDataBuffer.IsWorking = false;
                    }
                    if (PondDataBufferLocal.PondHardInfo != null)
                    {
                        PondDataBuffer.IsRed = true;
                        SM_PondSiteHardware_Info hardInfo = PondDataBufferLocal.PondHardInfo;
                        PondDataBuffer.MeterOneStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                        PondDataBuffer.MeterTwoStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                        if (hardInfo.MeterType1 != null && hardInfo.MeterType1.IntId > 0)
                        {
                            if (hardInfo.MeterType1.AnalysisNo != null && ctx.ContainsObject(hardInfo.MeterType1.AnalysisNo))
                            {
                                var objTemp = ctx.GetObject(hardInfo.MeterType1.AnalysisNo);
                                if (objTemp is IMeterOperate)
                                {
                                    MeterOne = objTemp as IMeterOperate;
                                    timer_MeterOne = new Timer(Timer_MeterOneCallBack, hardInfo, 5000, 500);
                                }
                            }
                        }
                        if (hardInfo.MeterType2 != null && hardInfo.MeterType2.IntId > 0)
                        {
                            if (hardInfo.MeterType2.AnalysisNo != null && ctx.ContainsObject(hardInfo.MeterType2.AnalysisNo))
                            {
                                var objTemp = ctx.GetObject(hardInfo.MeterType2.AnalysisNo);
                                if (objTemp is IMeterOperate)
                                {
                                    MeterTwo = objTemp as IMeterOperate;
                                    timer_MeterTwo = new Timer(Timer_MeterTwoCallBack, hardInfo, 5000, 800);
                                }
                            }
                        }
                        PondDataBuffer.Print1ComName = hardInfo.Painter1;
                        PondDataBuffer.Print2ComName = hardInfo.Painter2;
                        PondDataBuffer.IsCompleting = false;
                        PondDataBuffer.IsHasTask = false;
                        timer_IO = new Timer(Timer_IOCallBack, hardInfo, 7000, 1500);
                        if (hardInfo.Painter1 != null && hardInfo.Painter1 != string.Empty)
                        {
                            timer_Print1 = new Timer(Timer_Print1CallBack, hardInfo, 7000, 10000);
                        }
                        if (hardInfo.Painter2 != null && hardInfo.Painter2 != string.Empty)
                        {
                            timer_Print2 = new Timer(Timer_Print2CallBack, hardInfo, 7000, 10000);
                        }
                        timer_ICCard = new Timer(Timer_ICCardCallBack, hardInfo, 6000, 150);
                        if (hardInfo.ErWeiMa != null && hardInfo.ErWeiMa != string.Empty)
                        {
                            timer_QRCode = new Timer(Timer_QRCodeCallBack, hardInfo, 6000, 10000);
                        }
                        timer_ForUpLoad = new Timer(Timer_ForUpLoadeCallBack, hardInfo, 10000, 600);
                        timer_ForClearMemory = new Timer(Timer_ForClearMemory, null, 5000, 30000);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 磅房停用
        /// </summary>
        public void StopPondSite()
        {
            if (PondDataBuffer.PondStatus != null && PondDataBuffer.PondStatus.EnumValue != DeviceStatus.Working)
            {
                if (PondDataBufferLocal.PondHardInfo != null)
                {
                    PondDataBuffer.IsRed = true;
                    SM_PondSiteHardware_Info hardInfo = PondDataBufferLocal.PondHardInfo;
                    IIOModelOperate ioModel = IOModelOperate_D8D8.CreateInstance();
                    RtuMasterWriteInfo infoRed = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight1), CoilValue = true };
                    RtuMasterWriteInfo infoGreen = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight2), CoilValue = false };
                    IList<RtuMasterWriteInfo> infos = new List<RtuMasterWriteInfo>();
                    infos.Add(infoGreen);
                    infos.Add(infoRed);
                    string errStr;
                    ioModel.ModbusSerialRtuMasterWriteRegisters(out errStr, infos, hardInfo.IODNo);
                }
            }
        }
        public void CloseTimer()
        {
            if (timer_MeterOne != null)
            {
                timer_MeterOne.Dispose();
            }
            if (timer_MeterTwo != null)
            {
                timer_MeterTwo.Dispose();
            }
            if (timer_IO != null)
            {
                timer_IO.Dispose();
            }
            if (timer_Print1 != null)
            {
                timer_Print1.Dispose();
            }
            if (timer_Print2 != null)
            {
                timer_Print2.Dispose();
            }
            if (timer_ICCard != null)
            {
                timer_ICCard.Dispose();
            }
            if (timer_QRCode != null)
            {
                timer_QRCode.Dispose();
            }
        }

        private void Timer_ForUpLoadeCallBack(object args)
        {
            try
            {
                if (PondDataBufferLocal.PondHardInfo != null)
                {
                    SM_PondSiteHardware_Info hardInfo = PondDataBufferLocal.PondHardInfo;
                    if (PondSite_Monitorfactory == null)
                    {
                        PondSite_Monitorfactory = ctx.GetObject("DM_PondSite_Monitor_WCFServiceClient") as ChannelFactory<IDM_PondSite_Monitor_WCFService>;
                    }
                    if (PondSite_Monitorfactory != null)
                    {
                        if (pondSiteMonitorWCFservice == null) pondSiteMonitorWCFservice = PondSite_Monitorfactory.CreateChannel();
                    }
                    DM_PondSite_Monitor_WCF PondSite_Monitor = new DM_PondSite_Monitor_WCF();
                    PondSite_Monitor.PondId = hardInfo.PondSiteId;
                    PondSite_Monitor.PondSiteNo = hardInfo.PondSiteNo;
                    if (PondDataBuffer.MeterOneStatus != null && PondDataBuffer.MeterOneStatus.EnumValue == DeviceStatus.Working)
                    {
                        PondSite_Monitor.MeterOneWeight = PondDataBuffer.MeterOneWeight;
                    }
                    else
                    {
                        PondSite_Monitor.MeterOneWeight = PondDataBuffer.MeterOneWeight;
                    }
                    if (PondDataBuffer.MeterTwoStatus != null && PondDataBuffer.MeterTwoStatus.EnumValue == DeviceStatus.Working)
                    {
                        PondSite_Monitor.MeterTwoWeight = PondDataBuffer.MeterTwoWeight;
                    }
                    else
                    {
                        PondSite_Monitor.MeterTwoWeight = PondDataBuffer.MeterTwoWeight;
                    }
                    PondSite_Monitor.MeterSumWeight = PondSite_Monitor.MeterOneWeight + PondSite_Monitor.MeterTwoWeight;
                    PondSite_Monitor.MeterOneStatus = PondDataBuffer.MeterOneStatus;
                    PondSite_Monitor.MeterTwoStatus = PondDataBuffer.MeterTwoStatus;
                    PondSite_Monitor.InfraRedOneStatus = PondDataBuffer.Grating1Status;
                    PondSite_Monitor.InfraRedTwoStatus = PondDataBuffer.Grating2Status;
                    PondSite_Monitor.PrintOneStatus = PondDataBuffer.Print1Status;
                    PondSite_Monitor.PrintTwoStatus = PondDataBuffer.Print2Status;
                    PondSite_Monitor.TrafficOneStatus = new DeviceStatusObj((int)(PondDataBuffer.IsRed ? DeviceStatus.RedLight : DeviceStatus.GreenLight));
                    PondSite_Monitor.TrafficTwoStatus = PondSite_Monitor.TrafficOneStatus;
                    int rs = pondSiteMonitorWCFservice.UpdateSiteMonitor(PondSite_Monitor);
                    PondSite_Monitor = null;
                }
            }
            catch (Exception ex)
            {
                if (PondSite_Monitorfactory != null)
                {
                    try
                    {
                        PondSite_Monitorfactory.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
                PondSite_Monitorfactory = null;
                pondSiteMonitorWCFservice = null;
            }
        }

        private void Timer_ForClearMemory(object args)
        {
            try
            {
                FlushMemory.FlushMemoryEx();
            }
            catch (Exception ex)
            {

            }
        }

        private void Timer_QRCodeCallBack(object args)
        {
            try
            {
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_QRCode, 1) == 0)
                {
                    string errStr = string.Empty;
                    if (PondDataBufferLocal.PondHardInfo != null)
                    {
                        SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                        if (PondDataBuffer.IsCanReadCard && !PondDataBuffer.IsCompleting && !PondDataBuffer.IsHasTask && !PondDataBuffer.QRCodeIsNew)
                        {
                            IQCCodeOperate api = QCCodeOperate_CN3100.CreateInstance();
                            if (PondDataBuffer.QRCodeStatus == null || PondDataBuffer.QRCodeStatus.EnumValue == DeviceStatus.Disable)
                            {
                                api.OpenPort(out errStr, hardInfo.ErWeiMa);
                            }
                            api.OpenQC(out errStr, hardInfo.ErWeiMa);
                        }
                        else if (PondDataBuffer.IsHasTask)
                        {
                            IQCCodeOperate api = QCCodeOperate_CN3100.CreateInstance();
                            api.CloseQC(out errStr, hardInfo.ErWeiMa);
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_QRCode, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_QRCode, 0);
            }
        }

        private void Timer_ICCardCallBack(object args)
        {
            try
            {
                //log.Info("PondDataBuffer.IsWorking:" + PondDataBuffer.IsWorking);
                //log.Info("PondDataBuffer.IsCanReadCard:" + PondDataBuffer.IsCanReadCard);
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_ICCard, 1) == 0)
                {
                    if (PondDataBufferLocal.PondHardInfo != null)
                    {
                        IICOperate Api = ICOperateImpl.CreateInstance();
                        if (PondDataBuffer.IsCanReadCard && !PondDataBuffer.IsCompleting && !PondDataBuffer.IsHasTask && !PondDataBuffer.ICStrIsNew)
                        {
                            //log.Error("读卡器状态：Timer");
                            string str = Api.ICRead(0);
                            if (str != string.Empty)
                            {
                                PondDataBuffer.ICStr = str;
                                PondDataBuffer.ICStrIsNew = true;
                                Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            log.Error("NO");
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_ICCard, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_ICCard, 0);
            }
        }


        private void Timer_MeterOneCallBack(object args)
        {
            try
            {
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterOne, 1) == 0)
                {
                    SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                    string errStr = string.Empty;
                    if (MeterOne != null)
                    {
                        bool rs = true;
                        if (PondDataBuffer.MeterOneStatus == null || PondDataBuffer.MeterOneStatus.EnumValue == DeviceStatus.Disable)
                        {
                            rs = MeterOne.OpenPort(out errStr, hardInfo.ProtNo1, hardInfo.Prot1BaudRate.Value, hardInfo.Prot1DataBits.Value, hardInfo.Prot1StopBits.Value, hardInfo.Prot1Parity.Value, false);
                            if (!rs)
                            {
                                PondDataBuffer.MeterOneStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                            }
                            else
                            {
                                PondDataBuffer.MeterOneStatus = new DeviceStatusObj((int)DeviceStatus.Working);
                            }
                        }
                        if (rs)
                        {
                            int? MeterStatus;
                            decimal? MeterWeight;
                            MeterOne.ReadData(out errStr, hardInfo.ProtNo1, out MeterStatus, out MeterWeight);
                            if (MeterStatus != null)
                            {
                                PondDataBuffer.MeterOneStatus = new DeviceStatusObj(MeterStatus.Value);
                            }
                            if (MeterWeight != null)
                            {
                                PondDataBuffer.MeterOneWeight = MeterWeight.Value;
                            }
                            if (CanChangeLight)
                            {
                                if ((PondDataBuffer.MeterOneWeight + PondDataBuffer.MeterTwoWeight) > DefuleWeight)
                                {
                                    PondDataBuffer.IsCanReadCard = true;
                                }
                                else
                                {
                                    PondDataBuffer.IsCanReadCard = false;
                                }
                            }
                        }

                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterOne, 0);
                }

            }
            catch (Exception ex)
            {
                PondDataBuffer.IsCanReadCard = false;
                Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterOne, 0);
            }
        }
        private void Timer_MeterTwoCallBack(object args)
        {
            try
            {
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterTwo, 1) == 0)
                {
                    SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                    string errStr = string.Empty;
                    if (MeterTwo != null)
                    {
                        bool rs = true;
                        if (PondDataBuffer.MeterTwoStatus == null || PondDataBuffer.MeterTwoStatus.EnumValue == DeviceStatus.Disable)
                        {
                            rs = MeterTwo.OpenPort(out errStr, hardInfo.ProtNo2, hardInfo.Prot2BaudRate.Value, hardInfo.Prot2DataBits.Value, hardInfo.Prot2StopBits.Value, hardInfo.Prot2Parity.Value, false);
                            if (!rs)
                            {
                                PondDataBuffer.MeterTwoStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                            }
                            else
                            {
                                PondDataBuffer.MeterTwoStatus = new DeviceStatusObj((int)DeviceStatus.Working);
                            }
                        }
                        if (rs)
                        {
                            int? MeterStatus;
                            decimal? MeterWeight;
                            MeterTwo.ReadData(out errStr, hardInfo.ProtNo1, out MeterStatus, out MeterWeight);
                            if (MeterStatus != null)
                            {
                                PondDataBuffer.MeterTwoStatus = new DeviceStatusObj(MeterStatus.Value);
                            }
                            if (MeterWeight != null)
                            {
                                PondDataBuffer.MeterTwoWeight = MeterWeight.Value;
                            }
                            if (CanChangeLight)
                            {
                                if ((PondDataBuffer.MeterOneWeight + PondDataBuffer.MeterTwoWeight) > DefuleWeight)
                                {
                                    PondDataBuffer.IsCanReadCard = true;
                                }
                                else
                                {
                                    PondDataBuffer.IsCanReadCard = false;
                                }
                            }
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterTwo, 0);
                }
            }
            catch (Exception ex)
            {
                PondDataBuffer.IsCanReadCard = false;
                Interlocked.Exchange(ref PondDataBuffer.IsIn_MeterTwo, 0);
            }
        }


        private void Timer_IOCallBack(object args)
        {
            try
            {

                string errStr = string.Empty;
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_IO, 1) == 0)
                {
                    SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                    if (hardInfo != null && hardInfo.Grating1 != string.Empty && hardInfo.Grating2 != string.Empty)
                    {
                        RtuMasterReadInfo info = new RtuMasterReadInfo();
                        info.Grating1No = MyNumberHelper.ConvertToInt32(hardInfo.Grating1);
                        info.Grating2No = MyNumberHelper.ConvertToInt32(hardInfo.Grating2);
                        IIOModelOperate ioModel = IOModelOperate_D8D8.CreateInstance();
                        ioModel.ModbusSerialAsciiMasterReadRegisters(out errStr, info, hardInfo.IODNo);
                    }
                    if (PondDataBuffer.IsWorking)
                    {
                        if (PondDataBuffer.IsCanReadCard && !PondDataBuffer.IsRed)
                        {
                            IIOModelOperate ioModel = IOModelOperate_D8D8.CreateInstance();
                            PondDataBuffer.IsRed = true;
                            RtuMasterWriteInfo infoRed = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight1), CoilValue = true };
                            RtuMasterWriteInfo infoGreen = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight2), CoilValue = false };
                            IList<RtuMasterWriteInfo> infos = new List<RtuMasterWriteInfo>();
                            infos.Add(infoGreen);
                            infos.Add(infoRed);
                            ioModel.ModbusSerialRtuMasterWriteRegisters(out errStr, infos, hardInfo.IODNo);
                        }
                        else if (!PondDataBuffer.IsCanReadCard && PondDataBuffer.IsRed)
                        {
                            if (CanChangeLight)
                            {
                                if ((PondDataBuffer.MeterOneWeight + PondDataBuffer.MeterTwoWeight) < 30 && (PondDataBuffer.MeterOneWeight + PondDataBuffer.MeterTwoWeight) > -30)
                                {
                                    IIOModelOperate ioModel = IOModelOperate_D8D8.CreateInstance();
                                    PondDataBuffer.IsRed = false;
                                    RtuMasterWriteInfo infoRed = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight1), CoilValue = false };
                                    RtuMasterWriteInfo infoGreen = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight2), CoilValue = true };
                                    if (infos == null)
                                    {
                                        infos = new List<RtuMasterWriteInfo>();
                                    }
                                    infos.Clear();
                                    infos.Add(infoRed);
                                    infos.Add(infoGreen);
                                    ioModel.ModbusSerialRtuMasterWriteRegisters(out errStr, infos, hardInfo.IODNo);
                                }
                            }
                            else
                            {
                                IIOModelOperate ioModel = IOModelOperate_D8D8.CreateInstance();
                                PondDataBuffer.IsRed = false;
                                RtuMasterWriteInfo infoRed = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight1), CoilValue = false };
                                RtuMasterWriteInfo infoGreen = new RtuMasterWriteInfo() { CoilAddress = MyNumberHelper.ConvertToUnShort(hardInfo.TrafficLight2), CoilValue = true };
                                if (infos == null)
                                {
                                    infos = new List<RtuMasterWriteInfo>();
                                }
                                infos.Clear();
                                infos.Add(infoRed);
                                infos.Add(infoGreen);
                                ioModel.ModbusSerialRtuMasterWriteRegisters(out errStr, infos, hardInfo.IODNo);
                            }
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_IO, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_IO, 0);
            }
        }

        private void Timer_Print1CallBack(object args)
        {
            try
            {
                string errStr = string.Empty;
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_Print1, 1) == 0)
                {
                    SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                    if (hardInfo != null)
                    {
                        IPrinterOperate printer = PrinterOperate_Custom.CreateInstance();
                        if (PondDataBuffer.Print1ConnectStatus == null || PondDataBuffer.Print1ConnectStatus.EnumValue != DeviceStatus.Working)
                        {
                            printer.OpenPort(out errStr, 1, hardInfo.Painter1, 9600);
                        }
                        else
                        {
                            printer.PrintStatus(out errStr, hardInfo.Painter1);
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_Print1, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_Print1, 0);
            }
        }
        private void Timer_Print2CallBack(object args)
        {
            try
            {
                string errStr = string.Empty;
                if (Interlocked.Exchange(ref PondDataBuffer.IsIn_Print2, 1) == 0)
                {
                    SM_PondSiteHardware_Info hardInfo = args as SM_PondSiteHardware_Info;
                    if (hardInfo != null)
                    {
                        IPrinterOperate printer = PrinterOperate_Custom.CreateInstance();
                        if (PondDataBuffer.Print2ConnectStatus == null || PondDataBuffer.Print2ConnectStatus.EnumValue != DeviceStatus.Working)
                        {
                            printer.OpenPort(out errStr, 2, hardInfo.Painter2, 9600);
                        }
                        else
                        {
                            printer.PrintStatus(out errStr, hardInfo.Painter2);
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_Print2, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_Print2, 0);
            }
        }
        #endregion

        #region 仪表清零
        public static bool ClearMetar1(out string errMsg)
        {
            bool rs = false;
            errMsg = string.Empty;
            try
            {
                if (MeterOne != null && PondDataBufferLocal.PondHardInfo != null && PondDataBufferLocal.PondHardInfo.ProtNo1 != string.Empty)
                {
                    rs = MeterOne.Clear(out errMsg, PondDataBufferLocal.PondHardInfo.ProtNo1);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_Print2, 0);
            }
            return rs;
        }
        public static bool ClearMetar2(out string errMsg)
        {
            bool rs = false;
            errMsg = string.Empty;
            try
            {
                if (MeterTwo != null && PondDataBufferLocal.PondHardInfo != null && PondDataBufferLocal.PondHardInfo.ProtNo2 != string.Empty)
                {
                    rs = MeterTwo.Clear(out errMsg, PondDataBufferLocal.PondHardInfo.ProtNo2);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_Print2, 0);
            }
            return rs;
        }
        #endregion
    }

}
