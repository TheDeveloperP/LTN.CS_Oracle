// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/7/12 14:56:44
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/12 14:56:44
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum DeviceStatus
    {
        Disable = 0,  //停用
        Working = 1,  //启用
        Blocking = 2,  //红外遮挡
        Outaper = 3,  //缺纸
        Jammed = 4,  //卡纸
        PaperWillOut = 5,  //纸将尽
        RedLight = 6,  //红灯
        GreenLight = 7,   //绿灯
        OutLoad = 8,  //超欠载
        Dynamic = 9 //动态
    }
}
