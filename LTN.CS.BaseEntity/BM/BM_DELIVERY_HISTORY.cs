using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_DELIVERY_HISTORY : BaseEntity
    {
        public int IntId { get; set; }
        public int MainId { get; set; }
        public BM_USER Operator { get; set; }
        public BM_USER Continue { get; set; }
        public string OperatorType { get; set; }
        public DateTime OPTDate { get; set; }
        public string Remarks { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }

    }
}
