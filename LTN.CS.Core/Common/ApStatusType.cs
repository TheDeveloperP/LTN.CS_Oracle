using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public enum ApStatusType
    {
        /// <summary>
        /// 已呈核
        /// </summary>
        Reported = 0,
        /// <summary>
        /// 已核准
        /// </summary>
        Approved = 1,
        /// <summary>
        /// 已退回
        /// </summary>
        SendBacked = 2
    };
}
