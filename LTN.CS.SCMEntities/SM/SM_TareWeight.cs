using LTN.CS.Core;
using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_TareWeight: BaseEntity
    {
        public int IntId { get; set; }
        public string CarName { get; set; }
        public int NewTare { get; set; }
        public string SiteNo { get; set; }
        public string SiteName { get; set; }
        public EntityInt IsUsed { get; set; }
        public string CREATETIME { get; set; }
        public string CreateUserName { get; set; }
        public string UPDATETIME { get; set; }
        public string UpdateUserName { get; set; }
    }
}
