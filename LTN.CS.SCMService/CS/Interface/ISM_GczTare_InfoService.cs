using LTN.CS.SCMEntities.CS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.CS.Interface
{
    public interface ISM_GczTare_InfoService
    {
        /// <summary>
        /// 钢厂站皮重信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<SM_GczTare_Info> ExecuteDB_QueryGczTare(Hashtable ht);

        IList<SM_GczTare_Info> ExecuteDB_QueryGczTare(string ht);

        //新增 潘鹏  用于皮重匹配
        IList<SM_GczTare_Info> ExecuteDB_QueryGczTareForMatch(Hashtable ht);        

    }
}
