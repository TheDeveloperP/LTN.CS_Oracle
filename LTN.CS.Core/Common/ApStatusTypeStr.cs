using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public class ApStatusTypeStr
    {
        public static string GetApStatusTypeStr(ApStatusType type)
        {
            switch (type)
            {
                case ApStatusType.Reported:
                    return "已呈核";
                case ApStatusType.Approved:
                    return "已核准";
                case ApStatusType.SendBacked:
                    return "已退回";
                default: return "";
            }
        }
    }
}
