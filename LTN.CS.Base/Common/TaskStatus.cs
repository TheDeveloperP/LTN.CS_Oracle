// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/5 9:39:36
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 9:39:36
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum TaskStatus
    {
        Assignmenting = 0, //待分配
        Accepting = 1,     // 待受理
        Dealting = 2,       //处理中
        Completed = 3      //完成任务
    }
}
