using LTN.CS.SCMEntities.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_ReeferContainerNo_InfoService
    {
        IList<SM_ReeferContainerNo_Info> ExecuteDB_QueryAll();
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertReeferContainerRateInfo(SM_ReeferContainerNo_Info rate);
        /// <summary>
        /// 查询集装箱号识别率Hashtable ht
        /// </summary>
        /// <returns></returns>
        DataTable ExecuteDB_QueryReeferContainerRecognitionRateAll(Hashtable ht);

        IList<SM_ReeferContainerNo_Info> ExecuteDB_QueryAllByCondition(Hashtable ht);


        //关于湖大上传的集装箱信息        
       // SM_JZX_Huda_Message ExecuteDB_QueryAllByCondition_Huda(Hashtable ht);
        IList<SM_JZX_Huda_Message> ExecuteDB_QueryAllByCondition_Huda(Hashtable ht);
    }
}
