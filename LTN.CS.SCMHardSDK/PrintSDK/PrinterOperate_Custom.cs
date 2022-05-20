// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.PrintSDK
// Author:kolio
// Created:2016/11/4 21:57:57
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 21:57:57
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.SDKInterface;
using System.IO.Ports;
using LTN.CS.Base.Helper;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;

namespace LTN.CS.SCMHardSDK.PrintSDK
{
    public class PrinterOperate_Custom : IPrinterOperate
    {
        private PrinterOperate_Custom()
        {

        }
        private readonly static PrinterOperate_Custom Api = new PrinterOperate_Custom();
        public static PrinterOperate_Custom CreateInstance() { return Api; }
        private readonly object locker = new object();

        public void PrintStatus(out string errStr, string comPortName)
        {
            try
            {
                lock (locker)
                {
                    errStr = string.Empty;
                    byte[] data_Write1 = new byte[3] { 0x10, 0x04, 0x14 };
                    MySerialPortHelper.WriteByteData(out errStr, comPortName, data_Write1);
                }
            }
            catch (Exception ex)
            {
                errStr = ex.Message;
                if (comPortName == PondDataBuffer.Print1ComName)
                {
                    PondDataBuffer.Print1ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
                else if (comPortName == PondDataBuffer.Print2ComName)
                {
                    PondDataBuffer.Print2ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
        }

        private void CommDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var _comm1 = sender as SerialPort;
            try
            {
                if (_comm1 != null && _comm1.IsOpen)
                {
                    int n = _comm1.BytesToRead;
                    if (n >= 6)
                    {
                        DeviceStatusObj statusTemp = null;
                        var buf = new byte[n];
                        _comm1.Read(buf, 0, n);
                        if (buf.Length > 5 && buf[0] == 16)
                        {
                            byte rssInt_paper = buf[2];
                            byte rssInt_user = buf[3];
                            byte rssInt_jam = buf[4];
                            byte byteTemp1 = Convert.ToByte(1);
                            byte byteTemp2 = Convert.ToByte(4);
                            byte byteTemp3 = Convert.ToByte(64);
                            int rs1 = rssInt_jam & byteTemp3;
                            if (rs1 == 64)
                            {
                                statusTemp = new DeviceStatusObj((int)DeviceStatus.Jammed);
                            }
                            else
                            {
                                int rs2 = rssInt_paper & byteTemp1;
                                if (rs2 == 1)
                                {
                                    statusTemp = new DeviceStatusObj((int)DeviceStatus.Outaper);
                                }
                                else
                                {
                                    int rs3 = rssInt_paper & byteTemp2;
                                    if (rs3 == 4)
                                    {
                                        statusTemp = new DeviceStatusObj((int)DeviceStatus.Outaper);
                                    }
                                    else
                                    {
                                        if (rssInt_user != 0 || rssInt_jam != 0)
                                        {
                                            statusTemp = new DeviceStatusObj((int)DeviceStatus.Disable);
                                        }
                                        else
                                        {
                                            statusTemp = new DeviceStatusObj((int)DeviceStatus.Working);
                                        }
                                    }
                                }
                            }
                        }
                        if (statusTemp != null && _comm1.PortName == PondDataBuffer.Print1ComName)
                        {
                            PondDataBuffer.Print1Status = statusTemp;
                        }
                        if (statusTemp != null && _comm1.PortName == PondDataBuffer.Print2ComName)
                        {
                            PondDataBuffer.Print2Status = statusTemp;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (_comm1.PortName == PondDataBuffer.Print1ComName)
                {
                    PondDataBuffer.Print1Status = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
                else if (_comm1.PortName == PondDataBuffer.Print2ComName)
                {
                    PondDataBuffer.Print2Status = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
        }
        public bool Print(out string errStr, List<string> strs, string comPortName, Encoding encoding)
        {
            errStr = string.Empty;
            bool rs = false;
            lock (locker)
            {
                try
                {
                    if (strs != null)
                    {
                        foreach (string str in strs)
                        {
                            MySerialPortHelper.WriteByteData(out errStr, comPortName,encoding.GetBytes(str));
                        }
                    }
                }
                catch (Exception ex)
                {
                    errStr = ex.Message;
                    if (comPortName == PondDataBuffer.Print1ComName)
                    {
                        PondDataBuffer.Print1ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                    else if (comPortName == PondDataBuffer.Print2ComName)
                    {
                        PondDataBuffer.Print2ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                }
            }
            return rs;
        }

        public void OpenPort(out string errMsg, int printNo, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            errMsg = string.Empty;
            try
            {
                var rs = MySerialPortHelper.SetSerialPortAndOpen(out errMsg, comPortName, baudRate, dataBits, stopBits, parity, RtsEnable, CommDataReceived);
                if (rs)
                {
                    if (printNo==1)
                    {
                        PondDataBuffer.Print1ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Working);
                    }
                    if (printNo == 2)
                    {
                        PondDataBuffer.Print2ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Working);
                    }
                }
                else
                {
                    if (printNo == 1)
                    {
                        PondDataBuffer.Print1ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                    if (printNo == 2)
                    {
                        PondDataBuffer.Print2ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                if (printNo == 1)
                {
                    PondDataBuffer.Print1Status = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
                if (printNo == 2)
                {
                    PondDataBuffer.Print2Status = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
        }


        public bool Print(out string errStr, List<byte[]> byteDatas, string comPortName, Encoding encoding)
        {
            errStr = string.Empty;
            bool rs = false;
            lock (locker)
            {
                try
                {
                    if (byteDatas != null)
                    {
                        foreach (byte[] data in byteDatas)
                        {
                            MySerialPortHelper.WriteByteData(out errStr, comPortName, data);
                        }
                        rs = true;
                    }
                }
                catch (Exception ex)
                {
                    errStr = ex.Message;
                    if (comPortName == PondDataBuffer.Print1ComName)
                    {
                        PondDataBuffer.Print1ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                    else if (comPortName == PondDataBuffer.Print2ComName)
                    {
                        PondDataBuffer.Print2ConnectStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                    }
                }
            }
            return rs;
        }
    }
}
