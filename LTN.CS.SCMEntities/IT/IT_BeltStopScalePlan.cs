using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_BeltStopScalePlan: BaseEntity
    {
        public string c_planstatus{ get; set; }//	委托状态
        public string c_planno { get; set; }//	委托单号
        public string c_starttime { get; set; }//	停止时间
        public string c_createtime{ get; set; }//	创建时间
        public string c_createname { get; set; }//	创建人
        public string c_remark{ get; set; }//	备注
        public string c_uploadstatus  { get; set; }//	获取状态

    }
}
