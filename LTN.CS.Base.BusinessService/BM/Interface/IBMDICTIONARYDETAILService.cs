using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMDICTIONARYDETAILService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Insert(BM_DICTIONARY_DETAIL page);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Update(BM_DICTIONARY_DETAIL page);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_Delete(BM_DICTIONARY_DETAIL page);

        /// <summary>
        /// 禁用服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object ExecuteDB_DisableService(BM_DICTIONARY_DETAIL service);

        /// <summary>
        /// 查找所有实体
        /// </summary>
        /// <returns></returns>
        IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryAll();

        /// <summary>
        /// 根据ID查找所有实体
        /// </summary>
        /// <returns></returns>
        IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryBySn(string dicId);
        /// <summary>
        /// 根据父ID和编号查找所有实体
        /// </summary>
        /// <returns></returns>
        int ExecuteDB_QueryCountBySn(BM_DICTIONARY_DETAIL dic);
        BM_DICTIONARY_DETAIL ExecuteDB_QueryByDesc(BM_DICTIONARY_DETAIL dicDesc);
        BM_DICTIONARY_DETAIL ExecuteDB_QueryAllByDesc(BM_DICTIONARY_DETAIL dicDesc);
        IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryByDICDESC(BM_DICTIONARY_DETAIL dicDesc);
    }
}
