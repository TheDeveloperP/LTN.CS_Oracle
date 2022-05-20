using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LTN.CS.Base.Common
{
    public enum WeightType
    {
        Null=0,
        GrossActual = 1,    //毛重-实际 
        TareActual = 2,     //皮重-实际 
        TareStandard = 3,   //皮重-标准 
        NetActual = 4,      //净重-实际
        GrossComparison = 5 ,//毛重-比对
        TareComparison=6    //皮重比对

        
    }
}
