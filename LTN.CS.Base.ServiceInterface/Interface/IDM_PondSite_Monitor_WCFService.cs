using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract(Namespace = "Spring.WCF")]
    public interface IDM_PondSite_Monitor_WCFService
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int UpdateSiteMonitor(DM_PondSite_Monitor_WCF site);

        /// <summary>
        /// 根据磅房ID查询磅房设备状态
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        [OperationContract]
        DM_PondSite_Monitor_WCF QueryMonitorById(int siteId);

        /// <summary>
        /// 查询所有磅房设备数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DM_PondSite_Monitor_WCF> QueryMonitorForAll();

    }
}
