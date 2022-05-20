using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PT;
using LTN.CS.Core.Common;
using LTN.CS.SCMEntities.Enum;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMEntities.SM;
using LTN.CS.Core.Helper;
using System.Net;


namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_MultiUpdate_SuppliesServiceImpl:IPM_MultiUpdate_SuppliesService
    {
        public ICommonDao CommonDao { get; set; }

        /// <summary>
        /// 根据条件内容执行批量更新
        /// </summary>
        /// <param name="wgtListNos"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public Object multiUpdate_SuppliesBills(List<string> wgtListNos, Hashtable ht)
        {
            //如果要修改来源/去向单位、品名，则需要修改委托（司磅员手动创建委托和系统收到的委托有差异，是否需要和上游系统确认）
            Object result = null;
            string materialName = ht["materialName"].ToString();
            string fromDeptName = ht["fromDeptName"].ToString();
            string toDeptName = ht["toDeptName"].ToString();
            string contractNo = ht["contractNo"].ToString();
            string requestRemark = ht["requestRemark"].ToString();
            string remark = ht["remark"].ToString();

            for (int i = 0; i < wgtListNos.Count(); i++)
            {
                string wgtListNo = wgtListNos[i];
                PM_Pond_Bill_Supplies suppliesBill = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Supplies>("QueryBywgiston", wgtListNo);
                if (!string.IsNullOrEmpty(materialName))
                {
                    suppliesBill.MaterialName = materialName;
                }
                if (!string.IsNullOrEmpty(fromDeptName))
                {
                    suppliesBill.FromDeptName = fromDeptName;
                }
                if (!string.IsNullOrEmpty(toDeptName))
                {
                    suppliesBill.ToDeptName = toDeptName;
                }
                if (!string.IsNullOrEmpty(contractNo))
                {
                    suppliesBill.ContractNo = contractNo;
                }
                if (!string.IsNullOrEmpty(requestRemark))
                {
                    suppliesBill.Remark = requestRemark;
                }
                if (!string.IsNullOrEmpty(remark))
                {
                    suppliesBill.PondRemark = remark;
                }  
                //需结合委托内容对磅单字段进行更新
                                                              
            }

        return result;
        }
    }
}
