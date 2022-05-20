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
    public enum AreaType
    {
        LimitNull=0,//无限定
        LimitFromArea = 1,  //来源区域限定
        LimitToArea = 2,  //去向区域限定
        LimitPointArea= 3,  //指定磅点
        LimitBothArea=4,  //双区域限定
        LimitAcrossArea=5//跨区域限定

    }
}
