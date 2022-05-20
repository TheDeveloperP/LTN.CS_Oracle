using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IBeltWeightDataService
    {
        /// <summary>
        /// 根据条件查询皮带秤实时数据表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<BeltWeightData> ExecuteDB_QueryBeltWeightDataByHashtable(Hashtable ht);

    }
}
