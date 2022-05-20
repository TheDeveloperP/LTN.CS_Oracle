using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public class ApOperateTypeStr
    {
        public static string GetApOperateTypeStr(ApOperateType type)
        {
            switch (type)
            {
            		case ApOperateType.Report:
                    return "呈核";
                	case ApOperateType.Approve:
                    return "核准";
                	case ApOperateType.SendBack:
                    return "退回";
                    case ApOperateType.BasicApproval:
                    return "拟准";
                default : return  "";
            }
        }
    }
}
