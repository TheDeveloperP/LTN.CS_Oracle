using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;

namespace LTN.CS.Core.Aspects
{
    public class SqlMapDaoThrowAdvice : IThrowsAdvice
    {
        public void AfterThrowing(Exception ex)
        {
            
        }
    }
}
