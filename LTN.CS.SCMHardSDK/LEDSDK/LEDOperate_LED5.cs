// ***********************************************************************
// Copyright (c) 2017 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.LEDSDK
// Author:kolio
// Created:2017/3/31 13:54:11
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2017/3/31 13:54:11
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.SDKInterface;

namespace LTN.CS.SCMHardSDK.LEDSDK
{
    public class LEDOperate_LED5 : ILEDOperate
    {
        public static uint m_dwCurHand { get; set; }
        private static Led5kSDK.bx_5k_area_header bx_5k;
        public bool OpenCom(out string errStr, byte com, uint baudrate, Led5kSDK.serial_parity Parity, Led5kSDK.serial_databits DataBits, Led5kSDK.serial_stopbits StopBits, Led5kSDK.bx_5k_card_type card_type, ushort ScreenID)
        {
            bool rs = false;
            errStr = string.Empty;
            try
            {
                uint rsTemp = Led5kSDK.CreateComModbus(com, baudrate, Parity, DataBits, StopBits, card_type, ScreenID);
                if (rsTemp == 0)
                {
                    rs = false;
                }
                else
                {
                    m_dwCurHand = rsTemp;
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                errStr = ex.Message;
            }
            return rs;
        }

        public bool CloseCom(out string errStr)
        {
            bool rs = false;
            errStr = string.Empty;
            try
            {
                if (m_dwCurHand != 0)
                {
                    Led5kSDK.Destroy(m_dwCurHand);
                    m_dwCurHand = 0;
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                errStr = ex.Message;
            }
            return rs;
        }

        public bool SendTextToLED(out string errStr, SCMEntities.SM.SM_LED_Template ledTemp,string showText,int i)
        {
            bool rs = false;
            errStr = string.Empty;
            try
            {
                if (m_dwCurHand != 0)
                {
                    bx_5k.AreaType = 0x00;
                    bx_5k.AreaX = Convert.ToInt16(ledTemp.Xcoor);
                    bx_5k.AreaX /= 8;
                    bx_5k.AreaY = Convert.ToInt16(ledTemp.Ycoor);
                    bx_5k.AreaWidth = Convert.ToInt16(ledTemp.Width);
                    bx_5k.AreaWidth /= 8;
                    bx_5k.AreaHeight = Convert.ToInt16(ledTemp.Height);

                    bx_5k.Lines_sizes = Convert.ToByte(ledTemp.WrapSpacing);

                    byte[] RunMode_list = new byte[3];
                    RunMode_list[0] = 0;
                    RunMode_list[1] = 1;
                    RunMode_list[2] = 2;
                    int rl = ledTemp.Mode.IntValue;
                    bx_5k.RunMode = RunMode_list[rl];
                    //bx_5k.RunMode = Convert.ToByte(comboBox3.SelectedIndex+1);

                    bx_5k.Timeout = Convert.ToInt16(ledTemp.TimeOut);

                    byte[] SoundMode_list = new byte[3];
                    SoundMode_list[0] = 0;
                    SoundMode_list[1] = 1;
                    SoundMode_list[2] = 2;
                    int sml = 0;
                    byte SoundMode = SoundMode_list[sml];

                    byte[] SoundPerson_list = new byte[6];
                    SoundPerson_list[0] = 0;
                    SoundPerson_list[1] = 1;
                    SoundPerson_list[2] = 2;
                    SoundPerson_list[3] = 3;
                    SoundPerson_list[4] = 4;
                    SoundPerson_list[5] = 5;
                    int spl = 0;
                    byte SoundPerson = SoundPerson_list[spl];

                    byte SoundVolume = (byte)0;

                    byte SoundSpeed = (byte)0;

                    byte[] SoundAreaText = System.Text.Encoding.Default.GetBytes(string.Empty);
                    int SoundDataLen = SoundAreaText.Length;


                    bx_5k.Reserved1 = 0;
                    bx_5k.Reserved2 = 0;
                    bx_5k.Reserved3 = 0;

                    byte[] SingleLine_list = new byte[2];
                    SingleLine_list[0] = 0x01;
                    SingleLine_list[1] = 0x02;
                    int sll = ledTemp.IsSingle.EntityValue == 1 ? 0 : 1;
                    bx_5k.SingleLine = SingleLine_list[sll];
                    //bx_5k.SingleLine = Convert.ToByte(comboBox1.SelectedIndex);

                    byte[] NewLine_list = new byte[2];
                    NewLine_list[0] = 0x01;
                    NewLine_list[1] = 0x02;
                    int nl = ledTemp.WrapType.EntityValue;
                    bx_5k.NewLine = NewLine_list[nl];
                    //bx_5k.NewLine = Convert.ToByte(comboBox2.SelectedIndex);


                    byte[] DisplayMode_list = new byte[6];
                    DisplayMode_list[0] = 0x01;
                    DisplayMode_list[1] = 0x02;
                    DisplayMode_list[2] = 0x03;
                    DisplayMode_list[3] = 0x04;
                    DisplayMode_list[4] = 0x05;
                    DisplayMode_list[5] = 0x06;
                    int dml = ledTemp.ShowStunt.IntValue;
                    bx_5k.DisplayMode = DisplayMode_list[dml];
                    //bx_5k.DisplayMode = Convert.ToByte(comboBox4.SelectedIndex);

                    bx_5k.ExitMode = 0x00;


                    bx_5k.Speed = (byte)ledTemp.RunningSpeed;
                    //bx_5k.Speed=Convert.ToByte(comboBox5.SelectedIndex);

                    bx_5k.StayTime = Convert.ToByte(ledTemp.ResidenceTime);
                    string showTextAll = string.Format("{0}{1}{2}", ledTemp.AddTextHead, showText, ledTemp.AddTextTail);
                    byte[] AreaText = Encoding.Default.GetBytes(showTextAll);
                    bx_5k.DataLen = AreaText.Length;
                    bx_5k.DynamicAreaLoc = (byte)i;
                    int x = Led5kSDK.SCREEN_SendDynamicArea(m_dwCurHand, bx_5k, (ushort)bx_5k.DataLen, SoundAreaText);
                    if (x == 0)
                    {
                        rs = true;
                    }
                    else
                    {
                        rs = false;
                    }
                }
            }
            catch (Exception ex)
            {
                errStr = ex.Message;
            }
            return rs;
        }
    }
}
