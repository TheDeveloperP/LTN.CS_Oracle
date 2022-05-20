// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.Comm
// Author:kolio
// Created:2016/11/6 20:30:48
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/6 20:30:48
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using LTN.CS.SCMEntities.SM;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.SCMHardSDK.Comm
{
    public static class PondDataBufferLocal
    {
        public static DM_PondSite_Info_WCF PondSite { get; set; }
        //public static SM_PondSiteHardware_Info PondHardInfo { get; set; }


        public static DM_PondSite_Monitor_WCF PondHardInfoForSite { get; set; }
        public static DM_Site_Info_WCF SiteInfo { get; set; }
    }
}
