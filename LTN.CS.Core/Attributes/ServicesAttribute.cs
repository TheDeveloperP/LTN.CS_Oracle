using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LTN.CS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ServicesAttribute : Attribute
    {
        public bool IsOutTransaction { get; set; }
        public IsolationLevel IsoLevel { get; set; }
    }
}
