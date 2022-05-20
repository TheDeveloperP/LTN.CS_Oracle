using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    //IC卡状态： 1）空 0  2）正常使用 1 3） 挂失  2
    public enum ICState
    {
        Empty = 0,  //空
        Use = 1,          //正常使用
        Loss = 2           //挂失
    }
}
