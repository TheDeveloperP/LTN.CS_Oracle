using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_TrackScaleIronPlan:BaseEntity

    {
        public string UPLOADSTATUS { get; set; }//接受状态，Y接受，N未接受
        public string PLANNO { get; set; }//委托单号
        public string HEATNO { get; set; }//炉号(单元号)
        public string BATCHNO { get; set; }//炉批号
        public string LRONNO { get; set; }//铁次号
        public string TANKNO { get; set; }//铁水罐号
        public string TODEPTNO { get; set; }//去向编码
        public string TODEPTNAME { get; set; }//去向名称
        public string CREATETIME { get; set; }//委托时间
        public string CREATENAME { get; set; }//委托人姓名
        public string REMARK { get; set; }//备注
        public string PLANSTATUS { get; set; }//I新增D删除，U更新


    }
}
