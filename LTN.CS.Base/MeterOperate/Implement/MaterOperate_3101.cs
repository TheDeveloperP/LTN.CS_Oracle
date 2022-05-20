// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.MeterOperate.Implement
// Author:kolio
// Created:2016/12/12 21:26:03
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/12/12 21:26:03
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.MeterOperate.Interface;
using LTN.CS.Base.Helper;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;

namespace LTN.CS.Base.MeterOperate.Implement
{
    public class MaterOperate_3101 : IMeterOperate
    {
        private readonly object locker = new object();
        public bool OpenPort(out string errMsg, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            errMsg = string.Empty;
            bool rs = false;
            try
            {
                rs = MySerialPortHelper.SetSerialPortAndOpen(out errMsg, comPortName, baudRate, dataBits, stopBits, parity, RtsEnable);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return rs;
        }

        public void ReadData(out string errMsg, string comPortName, out int? MeterStatus, out decimal? MeterWeight)
        {
            errMsg = string.Empty;
            MeterWeight = null;
            MeterStatus = null;
            try
            {
                lock (locker)
                {
                    byte[] datas = MySerialPortHelper.ReadByteData(out errMsg, comPortName, 50);
                    if (errMsg != string.Empty)
                    {
                        MeterStatus = (int)DeviceStatus.Disable;
                    }
                    if (datas != null)
                    {
                        byte[] datasTemp = new byte[10];
                        int? startIndex = null;
                        int? endIndex = null;
                        for (int i = datas.Length - 1; i >= 0; i--)
                        {
                            if (datas[i] == 3 && startIndex == null)
                            {
                                startIndex = i;
                            }
                            if (datas[i] == 255 && endIndex == null && startIndex != null)
                            {
                                endIndex = i;
                                break;
                            }
                        }
                        if (startIndex != null && endIndex != null)
                        {
                            int num = 0;
                            if ((startIndex - endIndex - 1) == 10)
                            {
                                for (int i = endIndex.Value + 1; i < startIndex.Value; i++)
                                {
                                    datasTemp[num] = datas[i];
                                    num++;
                                }
                            }
                            int num1 = 0;
                            if (datas[0] == 45)
                            {
                                num1 = -1;
                                byte[] datasTemp_2 = (byte[])datasTemp.SubArray(1, 6);
                                string tempStr = Encoding.ASCII.GetString(datasTemp_2);
                                MeterWeight = MyNumberHelper.ConvertToDecimal(tempStr) * num1;
                                if (MeterWeight < -10)
                                {
                                    MeterWeight = MeterWeight * -1;
                                }
                                MeterStatus = (int)DeviceStatus.Working;
                            }
                            else 
                            {
                                byte[] datasTemp_2 = (byte[])datasTemp.SubArray(0, 7);
                                string tempStr = Encoding.ASCII.GetString(datasTemp_2);
                                MeterWeight = MyNumberHelper.ConvertToDecimal(tempStr);
                                MeterStatus = (int)DeviceStatus.Working;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MeterStatus = (int)DeviceStatus.Disable;
            }
        }

        public bool Clear(out string errMsg, string comPortName)
        {
            bool rs = false;
            errMsg = string.Empty;
            lock (locker)
            {
                byte[] data_Write1 = new byte[1] { 0x5A };
                MySerialPortHelper.WriteByteData(out errMsg, comPortName, data_Write1);
                rs = true;
            }
            return rs;
        }
    }
}
