using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    //发行状态： 1）注册  2）已发行  3）回收  4）注销
    public enum IssuingState
    {
        Regist = 1,
        Releases = 2,
        Recyle = 3,
        Withdraw = 4
    }
}
