// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Entity
// Author:kolio
// Created:2016/8/29 15:41:19
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/29 15:41:19
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    public class DM_Track_End
    {
        public string LesNo { get; set; }
        public string FormationTag { get; set; }
        public int Direction { get; set; }
        public string EndTime { get; set; }
        public string DateNow { get; set; }
    }
}
