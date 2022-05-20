using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_DELIVERY : BaseEntity
    {
        public int IntId { get; set; }
        public string Title { get; set; }
        public string ServiceName { get; set; }
        public BM_USER FirstReporter { get; set; }
        public BM_USER Reporter { get; set; }
        public BM_USER Approver { get; set; }
        public DateTime OptDate { get; set; }
        public DeliveryInt Status { get; set; }
        public int DataId { get; set; }
        public string Remarks { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
    }
}
