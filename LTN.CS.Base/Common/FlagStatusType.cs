// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMEntities.Common
// Author:kolio
// Created:2016/7/4 16:25:02
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/4 16:25:02
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    /// <summary>
    /// 状态标识
    /// </summary>
    public enum FlagStatusType
    {
       Select=-1,//请选择
       UnFinished=0,//未完成
       Finishied=1,//已完成
       CarCompare=3,//汽车比对
       Hejin=4,//合金 
       Excep=9//异常 

    }
}
