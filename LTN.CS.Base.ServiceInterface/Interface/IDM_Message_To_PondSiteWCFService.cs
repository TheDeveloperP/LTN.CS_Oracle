using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract(Namespace = "Spring.WCF")]
    public interface IDM_Message_To_PondSiteWCFService
    {
        /// <summary>
        /// PondId 为必填  TaskId,Command为可选条件
        /// </summary>
        /// <param name="PondId"></param>
        /// <param name="TaskId"></param>
        /// <param name="Command"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DM_Message_To_PondSite_WCF> GetPondSiteMessage(int PondId, int? TaskId, int? Command);
        /// <summary>
        /// PondId,SiteId,TaskId,TaskNo  必须得有 否则无法添加消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [OperationContract]
        int CreatePondSiteMessage(DM_Message_To_PondSite_WCF message,out string errorMsg);
    }
}
