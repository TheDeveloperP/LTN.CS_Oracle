using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMHardSDK.SDKInterface
{
    public interface IQCCodeOperate
    {
        void OpenPort(out string errMsg, string comPortName, int baudRate=9600, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false);
        bool OpenQC(out string errMsg, string comPortName);
        bool CloseQC(out string errMsg, string comPortName);
    }
}
