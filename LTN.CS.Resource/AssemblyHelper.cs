using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LTN.CS.Core.Helper
{
    public static class AssemblyHelper
    {
        public static Assembly GetResourceAssembly()
        { 
              Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
              return asm;
        }
    }
}
