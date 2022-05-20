using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_BlackListHistory:BaseEntity
    {
        public int IntId { get; set; }
        public string CarName { get; set; }//车牌号
        public string OperationRecord { get; set; }//操作记录
        public string UpdateUserName { get; set; }
        public string UPDATETIME { get; set; }
    }
}
