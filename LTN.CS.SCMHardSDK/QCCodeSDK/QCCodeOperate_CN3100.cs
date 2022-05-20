// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.QCCodeSDK
// Author:kolio
// Created:2016/11/5 15:42:50
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/5 15:42:50
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
using System.Threading;

namespace LTN.CS.SCMHardSDK.QCCodeSDK
{
    public class QCCodeOperate_CN3100 : IQCCodeOperate
    {
        private QCCodeOperate_CN3100()
        {

        }
        private readonly static QCCodeOperate_CN3100 Api = new QCCodeOperate_CN3100();
        public static QCCodeOperate_CN3100 CreateInstance() { return Api; }
        private readonly object locker = new object();
        public void OpenPort(out string errMsg, string comPortName, int baudRate = 9600, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            errMsg = string.Empty;
            try
            {
                var rs = MySerialPortHelper.SetSerialPortAndOpen(out errMsg, comPortName, baudRate, dataBits, stopBits, parity, RtsEnable, CommDataReceived);
                if (rs)
                {
                    PondDataBuffer.QRCodeStatus = new DeviceStatusObj((int)DeviceStatus.Working);
                }
                else
                {
                    PondDataBuffer.QRCodeStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                PondDataBuffer.QRCodeStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
            }
        }
        private void CommDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var _comm1 = sender as SerialPort;
                if (_comm1 != null && _comm1.IsOpen)
                {
                    Thread.Sleep(200);
                    int n = _comm1.BytesToRead;
                    var buf = new byte[n];
                    _comm1.Read(buf, 0, n);
                    string rss = _comm1.Encoding.GetString(buf);
                    PondDataBuffer.QRCodeStr = rss.TrimEnd((char)(13));
                    PondDataBuffer.QRCodeIsNew = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public bool OpenQC(out string errMsg, string comPortName)
        {
            bool rs = false;
            try
            {
                lock (locker)
                {
                    errMsg = string.Empty;
                    lock (locker)
                    {
                        errMsg = string.Empty;
                        byte[] data_Write1 = new byte[] { 0x02, 0x54, 0x0D };
                        MySerialPortHelper.WriteByteData(out errMsg, comPortName, data_Write1);
                    }
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                PondDataBuffer.QRCodeStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
            }
            return rs;
        }

        public bool CloseQC(out string errMsg, string comPortName)
        {
            bool rs = false;
            try
            {
                lock (locker)
                {
                    errMsg = string.Empty;
                    lock (locker)
                    {
                        errMsg = string.Empty;
                        byte[] data_Write1 = new byte[] { 0x02, 0x55, 0x0D };
                        MySerialPortHelper.WriteByteData(out errMsg, comPortName, data_Write1);
                    }
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                PondDataBuffer.QRCodeStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
            }
            return rs;
        }
    }
}
