using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.Helper;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using LTN.CS.Base.MeterOperate.Interface;
using System.IO.Ports;

namespace LTN.CS.Base.MeterOperate.Implement
{
    public class MaterOperate_YY2116 : IMeterOperate
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
                        byte[] datasTemp = new byte[8];
                        int? startIndex = null;
                        for (int i = datas.Length - 1; i >= 0; i--)
                        {
                            if (datas[i] == 107 && startIndex == null)
                            {
                                startIndex = i;
                            }
                            //if (datas[i] == 2 && endIndex == null && startIndex != null)
                            //{
                            //    endIndex = i;
                            //    break;
                            //}
                        }
                        if (startIndex != null)
                        {
                            int num = 0;

                            for (int i = startIndex.Value-8 ; i < startIndex.Value; i++)
                            {
                                datasTemp[num] = datas[i];
                                num++;
                            }
                            string laststrData = Encoding.ASCII.GetString(datasTemp).Trim();
                            MeterWeight = int.Parse(laststrData);
                            //byte[] datasTemp_2 = (byte[])datasTemp.SubArray(0, 3);
                            //byte[] datasTemp_3 = (byte[])datasTemp.SubArray(3, 6);
                            //string laststrData = Encoding.ASCII.GetString(datasTemp_3);
                            //byte byteTempA = Convert.ToByte(7);
                            //byte byteTempB = Convert.ToByte(2);
                            //byte statusA = datasTemp_2[0];
                            //byte statusB = datasTemp_2[1];
                            //int statusA_Int = statusA & byteTempA;

                            //decimal statusA_decimal = 1;
                            //int statusB_Int = statusB & byteTempB;
                            //int plusMinus = statusB_Int == 2 ? -1 : 1;
                            //int lastIntData = int.Parse(laststrData);
                            //decimal lastData = Math.Round(lastIntData * plusMinus * statusA_decimal, 4);
                            //MeterWeight = lastData;
                            ////Console.WriteLine(Encoding.ASCII.GetString(readbuffer));
                            ////检查是否动态
                            //bool isNotWork = false;
                            //byteTempB = Convert.ToByte(8);
                            //int statusB_DynamicInt = statusB & byteTempB;
                            //if (statusB_DynamicInt == 8)
                            //{
                            //    MeterStatus = (int)DeviceStatus.Dynamic;
                            //    isNotWork = true;
                            //}
                            ////检查是否过载
                            //byteTempB = Convert.ToByte(4);
                            //int statusB_OutLoadInt = statusB & byteTempB;
                            //if (statusB_OutLoadInt == 4)
                            //{
                            //    MeterStatus = (int)DeviceStatus.OutLoad;
                            //    isNotWork = true;
                            //}
                            //if (!isNotWork)
                            //{
                            //    MeterStatus = (int)DeviceStatus.Working;
                            //}
                            //Console.WriteLine(lastData.ToString());
                        }
                    }
                    else
                    {
                        //MeterStatus = (int)DeviceStatus.Disable;
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
