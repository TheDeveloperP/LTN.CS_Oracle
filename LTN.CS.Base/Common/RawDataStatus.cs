using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum RawDataStatus
    {
        receive = 1,  //接受
        marked = 2,            //已匹配
        save = 3,         // 保存
        obsolete = 4,            //  作废
    }
}
