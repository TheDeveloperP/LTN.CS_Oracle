using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
   public  class PM_Bill_Belt
    {
        public int I_Intid { get; set; } //	主键
        public string C_Planno { get; set; }//	委托单号
        public string C_Materialno { get; set; }//	品名编码
        public string C_Materialname { get; set; }//	品名名称
        public string C_Fromdeptno { get; set; }//	来源单位编码
        public string C_Fromdeptname { get; set; }//	来源单位名称
        public string C_Fromstoreno { get; set; }//	来源库号编码
        public string C_Fromstorename { get; set; }//	来源库号名称
        public string C_Todeptno { get; set; }//	去向单位编码
        public string C_Todeptname { get; set; }//	去向单位名称
        public string C_Tostoreno { get; set; }//	去向库号编码
        public string C_Tostorename { get; set; }//	去向库号名称
        public string C_Beltno { get; set; }//	皮带编号
        public string C_Beltname { get; set; }//	皮带名称
        public string C_Shipno { get; set; }//	船号
        public string C_Contractno { get; set; }//	合同号
        public string C_Voyageno { get; set; }//	航次号
        public string C_Starttime { get; set; }//	开始时间
        public string C_Endtime { get; set; }//	结束时间
        public string C_Createtime { get; set; }//	委托创建时间
        public string C_Createname { get; set; }//	委托创建人姓名
        public string C_Remark { get; set; }//	备注
        public string C_Reserve1 { get; set; }//	预留字段1
        public string C_Reserve2 { get; set; }//	预留字段2
        public string C_Reserve3 { get; set; }//	预留字段3
        public int I_Reserve1 { get; set; }//	预留字段4
        public int I_Reserve2 { get; set; }//	预留字段5
        public int I_Reserve3 { get; set; }//	预留字段6
        public string C_Wgtlistno { get; set; }//	码单号
        public decimal N_Startwgt { get; set; }//	开始累计量
        public decimal N_Endwgt { get; set; }//	结束累计量
        public decimal N_Netwgt { get; set; }//	净重
        public string C_Measurestarttime { get; set; }//	计量开始时间
        public string C_Measureendtime { get; set; }//	计量结束时间
        public string C_Measureman { get; set; }//	计量员
        public string C_Updateusername { get; set; }//	修改人姓名
        public string C_Updatetime { get; set; }//	修改时间
        public string C_Billcreatetime { get; set; }//	磅单创建时间     yyyyMMddHHmmss
        public string C_Billcreateusername { get; set; }//	磅单创建人姓名
        public int I_BillStatus { get; set; }	//计量状态 0 已完成 1 已作废
        public string C_Planstatus { get; set; }//	上传标志
        public string C_Uploadstatus { get; set; }//	上抛状态  N未上抛 Y已上抛
        //3-23新增预留字段
        public string C_RESERVE4 { get; set; }
        public string C_RESERVE5 { get; set; }
        public string C_RESERVE6 { get; set; }
        public string C_RESERVE7 { get; set; }
        public string C_RESERVE8 { get; set; }

    }
}
