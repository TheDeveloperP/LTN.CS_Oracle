using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMSERVERService
    {
        BM_SERVICE ExecuteDB_QueryByNo(string serviceNo);
        BM_SERVICE ExecuteDB_QueryById(int serviceId);

        IList<BM_SERVICE> ExecuteDB_QueryAll();
        IList<BM_SERVICE> ExecuteDB_QueryByIntId(int intid);
        IList<BM_SERVICE> ExecuteDB_QueryServerId(int serviceId);
        /// <summary>
        /// 查询群组内服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteDB_QueryInGroup(int GroupId);
        /// <summary>
        /// 查询群组外服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteDB_QueryNotInGroup(int GroupId);
        /// <summary>
        /// 查询群组内服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteDB_QueryInUser(int UserId);
        /// <summary>
        /// 查询群组外服务
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        IList<BM_SERVICE> ExecuteDB_QueryNotInUser(int UserId);
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_SERVICE page);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Update(BM_SERVICE page);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_SERVICE page);

        /// <summary>
        /// 禁用服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_DisableService(BM_SERVICE service);


        /// <summary>
        /// 限制服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_LimitedService(BM_SERVICE service); 
    }
}
