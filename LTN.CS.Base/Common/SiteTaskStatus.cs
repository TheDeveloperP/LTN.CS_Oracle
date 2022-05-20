// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/8 10:48:16
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/8 10:48:16
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum SiteTaskStatus
    {
        FreeTask = 0,  //空闲
        DistributedTask = 1,  //已分配任务
        ReceivedTask = 2  //接收任务
    }
}
