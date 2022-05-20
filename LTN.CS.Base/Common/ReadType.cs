using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum ReadType
    {
        text = 1,  //读text文件 
        access = 2,            //   读access文件
        db2 = 3,         //读db文件
        sqldata = 4,  //读钱江SQL文件
    }
}