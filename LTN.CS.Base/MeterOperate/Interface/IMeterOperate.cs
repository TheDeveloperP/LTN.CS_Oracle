// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Interface
// Author:kolio
// Created:2016/9/29 13:11:31
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/9/29 13:11:31
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.Common;

namespace LTN.CS.Base.MeterOperate.Interface
{
    public interface IMeterOperate
    {
        bool OpenPort(out string errMsg, string comPortName, int baudRate, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false);
        void ReadData(out string errMsg, string comPortName, out int? MeterStatus, out decimal? MeterWeight);
        bool Clear(out string errMsg, string comPortName);
    }
}
