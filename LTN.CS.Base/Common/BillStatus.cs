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
    public enum BillStatus
    {
        NoMeasure = 0,  //未计量
        StareMeasure = 1,  //开始计量
        DoneMeasure = 2,  //完成计量
        InvalidMeasure = 3,  //作废
    }
}
