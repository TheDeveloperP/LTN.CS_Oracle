using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.BaseEntities.BM_Query;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessService.BM.Interface
{
    public interface IBMMAINASSEMBLYService
    {
        /// <summary>
        /// 查询ALL
        /// </summary>
        /// <returns></returns>
        IList<BM_MAIN_ASSEMBLY> ExecuteDB_QueryAll();
        /// <summary>
        /// 根据IntId查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BM_MAIN_ASSEMBLY ExecuteDB_QueryById(int id);
        /// <summary>
        /// 根据程序集名称查询
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        IList<BM_MAIN_ASSEMBLY> SelectByAssemblyName(string assemblyName);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mainAssembly"></param>
        /// <returns></returns>
        object ExecuteDB_InsertmainAssembly(BM_MAIN_ASSEMBLY mainAssembly);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mainAssembly"></param>
        /// <returns></returns>
        object ExecuteDB_UpdatemainAssembly(BM_MAIN_ASSEMBLY mainAssembly);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mainAssembly"></param>
        /// <returns></returns>
        object ExecuteDB_DeletemainAssembly(BM_MAIN_ASSEMBLY mainAssembly);
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="mainAssembly"></param>
        /// <returns></returns>
        object ExecuteDB_Disabled(BM_MAIN_ASSEMBLY mainAssembly);
    }
}
