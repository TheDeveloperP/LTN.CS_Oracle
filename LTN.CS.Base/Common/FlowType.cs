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
    /// 流向
    /// </summary>
    public enum FlowType
    {
        Select = -1,//请选择
        WaiJin =0,//外进
       ChangJi=1,//厂际
       ChuChang=2,// 出厂
       ZiFei=3,//  自费
       Zhuanzhang=4//   转账

    }
}
