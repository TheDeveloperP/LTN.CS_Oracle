using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_RFID_Info:BaseEntity
    {
        public int IntId { get; set; }  //	业务主键
        public string RFIDno { get; set; }  //	RFID编号
        public string Carname { get; set; } //	车牌号码
        public string Createtime { get; set; }  //	新增时间
        public string Createusername { get; set; }  //	新增人
        public string Updatetime { get; set; }  //	修改时间
        public string Updateusername { get; set; }	//	修改人
        public string Isused { get; set; }  //RFID状态 Y-启用 N-作废
    }
}
