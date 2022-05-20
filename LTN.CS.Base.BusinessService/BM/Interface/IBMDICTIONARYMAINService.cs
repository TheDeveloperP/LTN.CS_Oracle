using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMDICTIONARYMAINService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_DICTIONARY_MAIN page);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Update(BM_DICTIONARY_MAIN page);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_DICTIONARY_MAIN page);

        /// <summary>
        /// 禁用服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_DisableService(BM_DICTIONARY_MAIN service);

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_DICTIONARY_MAIN> ExecuteDB_QueryAll();

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<BM_DICTIONARY_MAIN> ExecuteDB_QueryBySn(string dicSn);
    }
}
