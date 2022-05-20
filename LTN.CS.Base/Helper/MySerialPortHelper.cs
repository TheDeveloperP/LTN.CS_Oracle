// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Helper
// Author:kolio
// Created:2016/9/29 10:20:53
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/9/29 10:20:53
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using IBatisNet.Common.Logging;

namespace LTN.CS.Base.Helper
{
    public class MySerialPortHelper
    {
        public static Dictionary<string, SerialPort> ports = new Dictionary<string, SerialPort>();

        private readonly static ILog log = LogManager.GetLogger("infoAppender");
            /// <summary>
        /// 设置串口参数
        /// </summary>
        /// <param name="comPortName">需要操作的COM口名称</param>
        /// <param name="baudRate">COM的速度</param>
        /// <param name="dataBits">数据长度</param>
        /// <param name="stopBits">停止位</param>
        public static bool SetSerialPortAndOpen(out string errMsg,string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false,SerialDataReceivedEventHandler handler=null)
        {
            bool rs = false;
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            try
            {

                if (ports.ContainsKey(comPortName))
                {
                    _serialPort = ports[comPortName];
                    if (_serialPort != null && _serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = comPortName;
                _serialPort.BaudRate = baudRate;
                _serialPort.Parity = (Parity)parity;
                _serialPort.DataBits = dataBits;
                _serialPort.StopBits = (StopBits)stopBits;
                _serialPort.Handshake = Handshake.None;
                _serialPort.RtsEnable = RtsEnable;
                _serialPort.ReadTimeout = 3000;
                if (handler != null)
                {
                    _serialPort.DataReceived += handler;
                }
                ports[comPortName] = _serialPort;
                _serialPort.Open();
                rs = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                
            }
            return rs;
        }
        /// <summary>
        /// 设置串口参数
        /// </summary>
        /// <param name="comPortName">需要操作的COM口名称</param>
        /// <param name="baudRate">COM的速度</param>
        /// <param name="dataBits">数据长度</param>
        /// <param name="stopBits">停止位</param>
        public static bool SetSerialPortAndOpen(out string errMsg,string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            bool rs = false;
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            try
            {

                if (ports.ContainsKey(comPortName))
                {
                    _serialPort = ports[comPortName];
                    if (_serialPort != null)
                    {
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.Close();
                        }
                        _serialPort.Dispose();
                        _serialPort = null;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (comPortName != null && comPortName != string.Empty)
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = comPortName;
                    _serialPort.BaudRate = baudRate;
                    _serialPort.Parity = (Parity)parity;
                    _serialPort.DataBits = dataBits;
                    _serialPort.StopBits = (StopBits)stopBits;
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.RtsEnable = RtsEnable;
                    _serialPort.ReadTimeout = 3000;
                    _serialPort.Open();
                    ports[comPortName] = _serialPort;
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return rs;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="comPortName"></param>
        /// <returns></returns>
        public static bool CloseSerialPortAndRemove(out string errMsg, string comPortName)
        {
            bool rs = false;
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            try
            {

                if (ports.ContainsKey(comPortName))
                {
                    _serialPort = ports[comPortName];
                    if (_serialPort != null)
                    {
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.Close();
                        }
                        _serialPort.Dispose();
                        _serialPort = null;
                    }
                }
                rs = true;
            }
            catch (Exception)
            {
            }
            return rs;
        }

        /// <summary>
        /// 关闭所有串口
        /// </summary>
        /// <param name="errMsg"></param>
        public static bool CloseAllSerialPort(out string errMsg)
        {
            bool rs = false;
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            List<string> keys = ports.Keys.ToList();
            foreach (string keyStr in keys)
            {
                try
                {
                    _serialPort = ports[keyStr];
                    if (_serialPort != null)
                    {
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.Close();
                        }
                        _serialPort.Dispose();
                        _serialPort = null;
                    }
                }
                catch (Exception)
                {
                }
            }
            return rs;
        }
        /// <summary>
        /// 写串口数据
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="comPortName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool WriteByteData(out string errMsg, string comPortName, byte[] data)
        {
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            bool rs = false;
            try
            {
                if (ports.ContainsKey(comPortName))
                {
                    _serialPort = ports[comPortName];
                    if (_serialPort != null && _serialPort.IsOpen)
                    {
                        _serialPort.Write(data,0,data.Count());
                    }
                    else
                    {
                        errMsg = "串口关闭";
                    }
                }
                else
                {
                    rs = false;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                rs = false;
            }
            return rs;
        }
        /// <summary>
        /// 读取串口数据
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="comPortName"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        public static byte[] ReadByteData(out string errMsg, string comPortName, int minLength)
        {
            SerialPort _serialPort = null;
            errMsg = string.Empty;
            byte[] _data = null;
            try
            {
                if (ports.ContainsKey(comPortName))
                {
                    _serialPort = ports[comPortName];
                    if (_serialPort != null && _serialPort.IsOpen)
                    {
                        if (_serialPort.BytesToRead > minLength)
                        {
                            _data = new byte[_serialPort.BytesToRead];
                            _serialPort.Read(_data, 0, _data.Length);
                        }
                    }
                    else
                    {
                        errMsg = "串口关闭";
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                _data = null;
            }
            return _data;
        }
    }
}
