using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.PT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_MultiUpdate_SuppliesService
    {
        //批量修改物资轨道衡磅单
        Object multiUpdate_SuppliesBills(List<string> wgtListNos, Hashtable ht);
    }
}
