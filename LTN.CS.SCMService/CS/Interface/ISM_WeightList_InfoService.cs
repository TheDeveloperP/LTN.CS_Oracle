using LTN.CS.SCMEntities.CS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.CS.Interface
{
    public interface ISM_WeightList_InfoService
    {
        /// <summary>
        /// 司磅员工作量统计
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<SM_WeightList_Info> ExecuteDB_QueryWeight(Hashtable ht);
        /// <summary>
        /// 磅点过磅量统计
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<SM_WeightList_Info> ExecuteDB_QueryWeight2(Hashtable ht);
    }
}
