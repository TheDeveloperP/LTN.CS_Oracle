using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.IT
{
    public class IT_TrackScaleMaterielPlan : BaseEntity
    {
        public string PLANSTATUS { get; set; }//	I -> 新增数据  D -> 删除数据  U -> 更新数据
        public string PLANNO { get; set; }//	编码规则例：T1PT1908180001，1-2位代表业务系统：T1:物流系统、IM:铁前MES、M1:钢后MMS等，第3位代表业务类型：P：采购 S：销售 K：内转，第4位代表秤型类型：T:汽车磅、B：物资轨道衡、I:铁水轨道衡、S:皮带秤、C:钢卷秤，第5-10位代表日期，第11-14位代表流水号
        public string WAGNO { get; set; }//	车皮号
        public string MATERIALNO { get; set; }//	品名编码
        public string MATERIALNAME { get; set; }//	品名名称
        public string FROMDEPTNO { get; set; }//	来源单位编码
        public string FROMDEPTNAME { get; set; }//	来源单位名称
        public string FROMSTORENO { get; set; }//	来源库号编码
        public string FROMSTORENAME { get; set; }//	来源库号名称
        public string TODEPTNO { get; set; }//	去向单位编码
        public string TODEPTNAME { get; set; }//	去向单位名称
        public string TOSTORENO { get; set; }//	去向库号编码
        public string TOSTORENAME { get; set; }//	去向库号名称
        public string SHIPNO { get; set; }//	船号
        public string FROMSTATION { get; set; }//	发站
        public string SERIALNO { get; set; }//	流水号
        public string DELIVERYNO { get; set; }//	发货单号
        public string CONTRACTNO { get; set; }//	合同号
        public string PROJECTNO { get; set; }//	计划号
        public string WAYBILLNO { get; set; }//	货票运单ID
        public string MARSHALLINGNO { get; set; }//	车次编组号
        public int    BUSINESSTYPE { get; set; }//	业务类型（0:进厂;1:出厂）
        public int    WEIGHTTYPE { get; set; }//	过磅方式（1.先皮后毛 2.先毛后皮 3.限期皮重，单过毛）
        public int    TARETYPE { get; set; }//	皮重方式（0:实际皮重 1:标准皮重 2.历史皮重）
        public int    MOVESTILLTYPE { get; set; }//	动静态（0:静 1:动 2:合）
        public string PLANLIMITTIME { get; set; }//	委托失效时间 yyyyMMddHHmmss
        public string PONDLIMIT { get; set; }//	磅点限制
        public string CREATETIME { get; set; }//	委托创建时间     yyyyMMddHHmmss
        public string CREATENAME { get; set; }//	委托创建人姓名
        public string REMARK { get; set; }//	备注
        public string UPLOADSTATUS { get; set; }//	接受状态  Y 接受  N 未接受
    }
}
