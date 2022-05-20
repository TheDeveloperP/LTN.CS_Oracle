using LTN.CS.Core;
using LTN.CS.SCMEntities.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_BeltNumber: BaseEntity
    {
        public PM_Bill_Belt BeltId { get; set; }    //皮带主键
        public int IntId { get; set; }  //业务主键
        public string BITNO { get; set; }  //累积量位号
        public string C_CreateTime { get; set; }//创建时间
        public string C_CreateUserName { get; set; }//创建人
        public string C_UpdateTime { get; set; }//修改时间
        public string C_UpdateUserName { get; set; }//修改人

    }
}
