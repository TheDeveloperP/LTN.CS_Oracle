// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.Comm
// Author:kolio
// Created:2016/11/4 14:56:18
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 14:56:18
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMHardSDK.Comm
{
    public class RtuMasterWriteInfo
    {
        public ushort CoilAddress { get; set; }
        public bool CoilValue { get; set; }
    }
}
