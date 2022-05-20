using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Container_RateService
    {
        IList<SM_Container_Rate> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertContainerRateInfo(SM_Container_Rate rate);
        /// <summary>
        /// 查询集装箱号识别率Hashtable ht
        /// </summary>
        /// <returns></returns>
        DataTable ExecuteDB_QueryContainerRecognitionRateAll(Hashtable ht);

        IList<SM_Container_Rate> ExecuteDB_QueryAllByCondition(Hashtable ht);
    }
}
