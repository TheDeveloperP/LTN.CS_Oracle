using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_PoundSite_InfoService
    {
        IList<SM_PoundSite_Info> ExecuteDB_QueryAll();
        IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundSiteId(string poundSiteId);
        IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundSiteIp(string poundSiteIp);
        IList<SM_PoundSite_Info> ExecuteDB_QueryByPoundType(int poundType);
        object ExecuteDB_InsertPoundSiteInfo(SM_PoundSite_Info Site);

        object ExecuteDB_UpdatePoundSiteInfo(SM_PoundSite_Info Site);

        object ExecuteDB_DeletePoundSiteInfo(SM_PoundSite_Info Site);

        DM_PondSite_Info_WCF ExecuteDB_QueryByIntId(int intid);

        DM_PondSite_Info_WCF ExecuteDB_QueryByIntPondId(string pondip);

        IList<DM_PondSite_Info_WCF> ExecuteDB_QueryAll2();
        
        /// <summary>
        /// 查询未授权光栅站点
        /// </summary>
        /// <returns></returns>
        IList<SM_PoundSite_Info> ExecuteDB_QueryGuangUnShouQuan();
        
        /// <summary>
        /// 查询已授权光栅
        /// </summary>
        /// <returns></returns>
        IList<SM_PoundSite_Info> ExecuteDB_QueryGuangShouQuan();

    }
}
