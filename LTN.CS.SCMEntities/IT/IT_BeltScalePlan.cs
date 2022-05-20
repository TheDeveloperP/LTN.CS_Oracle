using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_BeltScalePlan: BaseEntity
    {
        public string c_planstatus { get; set; }//委托状态
        public string c_planno { get; set; }//		委托单号 编码规则例：T1PT1908180001，1-2位代表业务系统：T1:物流系统、IM:铁前MES、M1:钢后MMS等，第3位代表业务类型：P：采购 S：销售 K：内转，第4位代表秤型类型：T:汽车磅、B：物资轨道衡、I:铁水轨道衡、S:皮带秤、C:钢卷秤，第5-10位代表日期，第11-14位代表流水号
        public string c_materialno { get; set; }//		品名编码
        public string c_materialname { get; set; }//		品名名称
        public string c_fromdeptno { get; set; }//		来源单位编码
        public string c_fromdeptname { get; set; }//		来源单位名称
        public string c_fromstoreno { get; set; }//		来源库号编码
        public string c_fromstorename { get; set; }//		来源库号名称
        public string c_todeptno { get; set; }//		去向单位编码
        public string c_todeptname { get; set; }//		去向单位名称
        public string c_tostoreno { get; set; }//		去向库号编码
        public string c_tostorename { get; set; }//		去向库号名称
        public string c_shipno { get; set; }//		船号
        public string c_contractno { get; set; }//		合同号
        public string c_createtime { get; set; }//		委托创建时间
        public string c_createname { get; set; }//		委托创建人姓名
        public string c_remark { get; set; }//		备注
        public string c_reserve1 { get; set; }//		预留字段1
        public string c_reserve2 { get; set; }//		预留字段2
        public string c_reserve3 { get; set; }//		预留字段3
        public int i_reserve1 { get; set; }//		预留字段4
        public int i_reserve2 { get; set; }//		预留字段5
        public int i_reserve3 { get; set; }//		预留字段6
        public string c_uploadstatus { get; set; }//		接受状态  Y 接受  N 未接受
        public string c_beltno { get; set; }//		皮带编号
        public string c_beltname { get; set; }//		皮带名称
        public string c_starttime { get; set; }//		开始时间
        public string c_voyageno { get; set; }//		航次号

    }
}
