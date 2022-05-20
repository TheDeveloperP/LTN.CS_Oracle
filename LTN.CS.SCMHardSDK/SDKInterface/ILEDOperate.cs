using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.LEDSDK;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMHardSDK.SDKInterface
{
    public interface ILEDOperate
    {
        bool OpenCom(out string errStr, byte com, uint baudrate, Led5kSDK.serial_parity Parity, Led5kSDK.serial_databits DataBits, Led5kSDK.serial_stopbits StopBits, Led5kSDK.bx_5k_card_type card_type, ushort ScreenID);
        bool CloseCom(out string errStr);
        bool SendTextToLED(out string errStr, SCMEntities.SM.SM_LED_Template ledTemp, string showText, int i);
    }
}
