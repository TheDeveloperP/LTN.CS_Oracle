using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Common
{
    public class CustomDBError
    { 
        public string ErrorMsg { get; set; }
        public CustomDBError(string msg)
        {
            ErrorMsg = msg;
        }
    
    }
}
