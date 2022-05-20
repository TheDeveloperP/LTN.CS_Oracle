// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/8/29 15:12:50
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/29 15:12:50
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    public class DM_Track_Coming
    {
        public string LesNo { get; set; }
        public int Direction { get; set; }
        public string ComingTime { get; set; }
    }
}
