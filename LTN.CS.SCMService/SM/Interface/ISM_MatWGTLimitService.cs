using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_MatWGTLimitService
    {
        /// <summary>
        /// 查询物料重量限制信息
        /// </summary>
        /// <returns></returns>
        IList<SM_MatWGTLimit> ExecuteDB_QueryAll();
        /// <summary>
        /// 查询物料名称是否限定重量
        /// </summary>
        /// <param name="CarNo"></param>
        /// <returns></returns>
        IList<SM_MatWGTLimit> ExecuteDB_QueryMatName(string MatName);
        /// <summary>
        /// 查询物料编码是否限定重量
        /// </summary>
        /// <param name="CarNo"></param>
        /// <returns></returns>
        IList<SM_MatWGTLimit> ExecuteDB_QueryMatCode(string MatCode);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        object ExecuteDB_InsertWGTLimitInfo(SM_MatWGTLimit Info);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateWGTLimitInfo(SM_MatWGTLimit Info);
        /// <summary>
        /// 作废RFID
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteWGTLimitInfo(SM_MatWGTLimit Info);
    }
}
