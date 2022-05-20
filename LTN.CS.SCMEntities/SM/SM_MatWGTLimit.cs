using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_MatWGTLimit:BaseEntity
    {
        public int IntId { get; set; }  //	业务主键
        public string Materielcode { get; set; }    //	物料编码
        public string Materielname { get; set; }    //	物料名称
        public int Limitwgt { get; set; }   //	限制重量（KG）
        public int Limitstatus { get; set; }    //	限制状态 0-不限制 1-限制
        public string Createtime { get; set; }  //	创建时间
        public string Createusername { get; set; }  //	创建人
        public string Updatetime { get; set; }  //	修改时间
        public string Updateusername { get; set; }	//	修改人

    }
}
