using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum BusinessType
    {
        LimitFromArea = 0,  //来源区域限定
        LimitToArea = 1,  //去向区域限定
        LimitPointArea= 2,  //指定磅点
        LimitBothArea=3,  //双区域限定
        LimitAcrossArea=4//跨区域限定

    }
}