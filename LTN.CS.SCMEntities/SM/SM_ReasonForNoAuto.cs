using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_ReasonForNoAuto:BaseEntity
    {
        public int IntId { get; set; }//业务主键
        public string Planno { get; set; }//委托单号
        public string Materialname { get; set; }//品名名称
        public string Fromdeptname { get; set; }//来源单位名称
        public string Todeptname { get; set; }//去向单位名称
        public string Reason { get; set; }//非自动过磅原因
        public string Poundsiteno { get; set; }//磅点编号
        public string Carno { get; set; }//车辆编号
        public string Createuser { get; set; }//创建人
        public string Createtime { get; set; }//创建时间
        public string Updateuser { get; set; }//修改人
        public string Updatetime { get; set; }//修改时间

    }
}
