// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.MeterOperate.Implement
// Author:kolio
// Created:2016/9/29 13:20:57
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/9/29 13:20:57
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.MeterOperate.Interface;
using LTN.CS.Base.Helper;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Common;

namespace LTN.CS.Base.MeterOperate.Implement
{
    public class MeterOperate_KL18k9 : IMeterOperate
    {
        //public bool OpenPort(out string errMsg, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        //{
        //    errMsg = string.Empty;
        //    try
        //    {
        //        var rs = MySerialPortHelper.SetSerialPortAndOpen(out errMsg, comPortName, baudRate, dataBits, stopBits, parity, RtsEnable);
        //        if (rs)
        //        {
        //            PondDataBuffer.MeterOneStatus = new Common.DeviceStatusObj((int)DeviceStatus.Working);
        //        }
        //        else
        //        {
        //            PondDataBuffer.MeterOneStatus = new Common.DeviceStatusObj((int)DeviceStatus.Disable);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errMsg = ex.Message;
        //    }
        //}

        //public void ReadData(out string errMsg, string comPortName)
        //{
        //    errMsg = string.Empty;
        //    try
        //    {
        //        byte[] datas = MySerialPortHelper.ReadByteData(out errMsg, comPortName,50);
        //        if (errMsg != string.Empty)
        //        {
        //            PondDataBuffer.MeterOneStatus = new Common.DeviceStatusObj((int)DeviceStatus.Disable);
        //        }
        //        byte[] datasTemp = new byte[10];
        //        int? startIndex = null;
        //        int? endIndex = null;
        //        if (datas != null)
        //        {
        //            for (int i = datas.Length - 1; i >= 0; i--)
        //            {
        //                if (datas[i] == 3 && startIndex == null)
        //                {
        //                    startIndex = i;
        //                }
        //                if (datas[i] == 2 && endIndex == null && startIndex != null)
        //                {
        //                    endIndex = i;
        //                    break;
        //                }
        //            }
        //            if (startIndex != null && endIndex != null)
        //            {
        //                int num = 0;
        //                if ((startIndex - endIndex - 1) == 10)
        //                {
        //                    for (int i = endIndex.Value + 1; i < startIndex.Value; i++)
        //                    {
        //                        datasTemp[num] = datas[i];
        //                        num++;
        //                    }
        //                }
        //                string laststrData = Encoding.ASCII.GetString(datasTemp);
        //                string plusMinusData = laststrData.Substring(0, 1);
        //                int plusMinus = plusMinusData == "-" ? -1 : 1;
        //                int subData = int.Parse(laststrData.Substring(1, 6)) * plusMinus;
        //                double decimalData = Math.Pow(0.1, int.Parse(laststrData.Substring(6, 1)));
        //                decimal lastData = Convert.ToDecimal(decimalData * subData);
        //                PondDataBuffer.MeterOneWeight = lastData;
        //                PondDataBuffer.MeterOneStatus = new Common.DeviceStatusObj((int)DeviceStatus.Working);
        //                //Console.WriteLine(Encoding.ASCII.GetString(readbuffer));
        //                Console.WriteLine(lastData.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errMsg = ex.Message;
        //        PondDataBuffer.MeterOneStatus = new Common.DeviceStatusObj((int)DeviceStatus.Disable);
        //    }
        //}


        //public bool Clear(out string errMsg, string comPortName)
        //{
        //    throw new NotImplementedException();
        //}
        public bool OpenPort(out string errMsg, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            throw new NotImplementedException();
        }

        public void ReadData(out string errMsg, string comPortName, out int? MeterStatus, out decimal? MeterWeight)
        {
            throw new NotImplementedException();
        }

        public bool Clear(out string errMsg, string comPortName)
        {
            throw new NotImplementedException();
        }
    }
}
