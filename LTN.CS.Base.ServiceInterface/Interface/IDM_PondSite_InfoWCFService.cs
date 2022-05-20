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
    public interface IDM_PondSite_InfoWCFService
    {
        [OperationContract]
        int UpdatePondSite(DM_PondSite_Info_WCF PondSite);
        [OperationContract]
        int DeletePondSite(DM_PondSite_Info_WCF PondSite);
        [OperationContract]
        int UpdatePondSiteStatus(int intId, PondStatusObj status);
        /// <summary>
        /// 查询所有磅点
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DM_PondSite_Info_WCF> QueryAllPond(out string errorMsg);
    }
}
