using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_TareWeightHistory:BaseEntity
    {
        public int IntId { get; set; }
        public string CarName { get; set; }
        public int HistoryTare { get; set; }
        public SM_PoundSite_Info PoundSite { get; set; }
        public string SiteNo { get; set; }
        public string SiteName { get; set; }
        public string CREATETIME { get; set; }
        public string CreateUserName { get; set; }
        public int IsExceed { get; set; }
    }
}
