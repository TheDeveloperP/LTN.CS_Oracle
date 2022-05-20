using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public enum ApOperateType
    {
        /// <summary>
        /// 呈核
        /// </summary>
        Report = 0,
        /// <summary>
        /// 核准
        /// </summary>
        Approve = 1,
        /// <summary>
        /// 退回
        /// </summary>
        SendBack = 2,
        /// <summary>
        /// 拟准
        /// </summary>
        BasicApproval = 3
    };
}
