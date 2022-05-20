// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/5 11:21:42
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 11:21:42
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum BaseOperateMethod
    {
        ReciveNewTask = 0,//接收任务
        PrintPondBill = 1,//打印磅单
        ShowMsg = 2,//更新提示信息
        TaskEnd = 3,//任务结束
        Warning = 4,//声光报警
        PowerOut = 5,//断电
        ClearZero = 6,//清零
        OtherOperate = 7,//其他操作（备用）
        TaskBreak = 8,//任务中断
        TrackComing = 9, //来车提醒
        TrackEnd = 10, //车组结束
        TrackWeight = 11, //车皮重量信息
        PondToSiteEndTask = 12, //磅房发给坐席中断任务指令
    }
}
