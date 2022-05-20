// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Interface
// Author:kolio
// Created:2016/7/7 16:39:03
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/7 16:39:03
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.Common;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract(Namespace = "Spring.WCF")]
    public interface IDM_Site_InfoWCFService
    {
        [OperationContract]
        int UpdateSite(DM_Site_Info_WCF Site);
        [OperationContract]
        int DeleteSite(DM_Site_Info_WCF Site);
        [OperationContract]
        int UpdateSiteStatus(int intId, SiteStatusObj status);
        /// <summary>
        /// 查询所有坐席
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DM_Site_Info_WCF> QueryAllSite(out string errorMsg);
    }
}
