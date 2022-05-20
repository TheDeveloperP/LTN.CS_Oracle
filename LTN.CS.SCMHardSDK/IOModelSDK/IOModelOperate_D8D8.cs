// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.IOModelSDK
// Author:kolio
// Created:2016/11/4 15:36:18
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 15:36:18
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.SDKInterface;
using System.IO.Ports;
using Modbus.Device;
using LTN.CS.SCMHardSDK.Comm;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Common;

namespace LTN.CS.SCMHardSDK.IOModelSDK
{
    public class IOModelOperate_D8D8 : IIOModelOperate
    {
        private readonly static IIOModelOperate Api = new IOModelOperate_D8D8();
        public static IIOModelOperate CreateInstance() { return Api; }
        private readonly object locker = new object();
        public bool ModbusSerialRtuMasterWriteRegisters(out string errStr, IList<Comm.RtuMasterWriteInfo> infos, string comPortName,int BaudRate = 19200, int DataBits = 8, int Parity = 0, int StopBits = 1)
        {
            errStr = string.Empty;
            bool rs = false;
            lock (locker)
            {
                try
                {
                    using (SerialPort port = new SerialPort(comPortName))
                    {
                        // configure serial port
                        port.BaudRate = BaudRate;
                        port.DataBits = DataBits;
                        port.Parity = (Parity)Parity;
                        port.StopBits = (StopBits)StopBits;
                        port.ReadTimeout = 2000;
                        port.Open();
                        // create modbus master
                        IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                        const byte slaveId = 1;
                        // write three registers
                        if (infos != null)
                        {
                            foreach (RtuMasterWriteInfo info in infos)
                            {
                                master.WriteSingleCoil(slaveId, info.CoilAddress, info.CoilValue);
                            }
                        }
                        rs = true;
                    }
                }
                catch (Exception ex)
                {
                    errStr = ex.Message;
                    PondDataBuffer.IOStatus = new Base.Common.DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
            return rs;
        }


        public bool ModbusSerialAsciiMasterReadRegisters(out string errStr, RtuMasterReadInfo info, string comPortName, int BaudRate = 19200, int DataBits = 8, int Parity = 0, int StopBits = 1)
        {
           errStr = string.Empty;
            bool rs = false;
            lock (locker)
            {
                try
                {
                    using (SerialPort port = new SerialPort(comPortName))
                    {
                        // configure serial port
                        port.BaudRate = BaudRate;
                        port.DataBits = DataBits;
                        port.Parity = (Parity)Parity;
                        port.StopBits = (StopBits)StopBits;
                        port.ReadTimeout = 2000;
                        port.Open();
                        IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                        byte slaveId = 1;
                        ushort startAddress = 0;
                        ushort numRegisters = 8;
                        bool[] registers = master.ReadInputs(slaveId, startAddress, numRegisters);
                        if (-1 < info.Grating1No && info.Grating1No < 8)
                        {
                            if (registers[info.Grating1No])
                            {
                                PondDataBuffer.Grating1Status = new Base.Common.DeviceStatusObj((int)DeviceStatus.Blocking);
                            }
                            else
                            {
                                PondDataBuffer.Grating1Status = new Base.Common.DeviceStatusObj((int)DeviceStatus.Working);
                            }
                        }
                        if (0 < info.Grating2No && info.Grating2No < 8)
                        {
                            if (registers[info.Grating2No])
                            {
                                PondDataBuffer.Grating2Status = new Base.Common.DeviceStatusObj((int)DeviceStatus.Blocking);
                            }
                            else
                            {
                                PondDataBuffer.Grating2Status = new Base.Common.DeviceStatusObj((int)DeviceStatus.Working);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errStr = ex.Message;
                    PondDataBuffer.IOStatus = new Base.Common.DeviceStatusObj((int)DeviceStatus.Disable);
                }
            }
            return rs;
        }
    }
}
