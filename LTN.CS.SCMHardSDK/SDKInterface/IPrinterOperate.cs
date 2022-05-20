// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.SDKInterface
// Author:kolio
// Created:2016/11/4 21:57:12
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 21:57:12
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMHardSDK.SDKInterface
{
    public interface IPrinterOperate
    {
        void OpenPort(out string errMsg,int printNo, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false);
        void PrintStatus(out string errStr, string comPortName);
        bool Print(out string errStr, List<string> strs, string comPortName, Encoding encoding);
        bool Print(out string errStr, List<byte[]> byteData, string comPortName, Encoding encoding);
    }
}
