// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.SDKInterface
// Author:kolio
// Created:2016/11/4 15:00:37
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 15:00:37
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.Comm;

namespace LTN.CS.SCMHardSDK.SDKInterface
{
    public interface IIOModelOperate
    {
        bool ModbusSerialRtuMasterWriteRegisters(out string errStr, IList<RtuMasterWriteInfo> infos, string comPortName, int BaudRate = 19200, int DataBits = 8, int Parity = 0, int StopBits = 1);
        bool ModbusSerialAsciiMasterReadRegisters(out string errStr, RtuMasterReadInfo info, string comPortName, int BaudRate = 19200, int DataBits = 8, int Parity = 0, int StopBits = 1);
    }
}
