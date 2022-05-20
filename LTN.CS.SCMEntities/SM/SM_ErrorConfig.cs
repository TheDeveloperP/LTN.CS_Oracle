using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_ErrorConfig : BaseEntity
    {
        public int IntId { get; set; }
        public string Remark { get; set; }
        public string GrossWgtError { get; set; }
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser                                              
        public string createTime { get; set; } //新增时间
        public string updateTime { get; set; }  //修改时间
    }
}
