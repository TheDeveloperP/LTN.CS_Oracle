using LTN.CS.Base.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Bill_Supplies
    {
        public int IntId { get; set; }// 业务主键
        public string PlanNo { get; set; }// 委托单号
        public string WagNo { get; set; }// 车皮号
        public string MaterialNo { get; set; }// 品名编码
        public string MaterialName { get; set; }// 品名名称
        public string FromDeptNo { get; set; }// 来源单位编码
        public string FromDeptName { get; set; }// 来源单位名称
        public string FromStoreNo { get; set; }// 来源库号编码
        public string FromStoreName { get; set; }// 来源库号名称
        public string ToDeptNo { get; set; }// 去向单位编码
        public string ToDeptName { get; set; }// 去向单位名称
        public string ToStoreNo { get; set; }// 去向库号编码
        public string ToStoreName { get; set; }// 去向库号名称
        public string ShipNo { get; set; }// 船号
        public string FromStation { get; set; }// 发站
        public string SerialNo { get; set; }// 流水号
        public string DeliveryNo { get; set; }// 发货单号
        public string ContractNo { get; set; }// 合同号
        public string ProjectNo { get; set; }// 计划号
        public string WayBillNo { get; set; }// 货票运单ID
        public string MarshallingNo { get; set; }// 车次编组号
        public BusinessTypesObj BusinessType { get; set; }// 业务类型（0:进厂;1:出厂）
        public WeightTypesObj WeightType { get; set; }// 过磅方式（1.先皮后毛 2.先毛后皮 3.限期皮重，单过毛）
        public TareTypeObj TareType { get; set; }// 皮重方式（0:实际皮重 1:标准皮重 2.历史皮重）
        public MoveStillTypeObj MoveStillType { get; set; }// 动静态（0:静 1:动 2:合）
        public BillStatusObj BillStatus { get; set; }// 计量状态
        public string PlanLimitTime { get; set; }// 委托失效时间
        public string PondLimit { get; set; }// 磅点限制
        public string Remark { get; set; }// 备注
        public string CReserve1 { get; set; }// 预留字段1
        public string CReserve2 { get; set; }// 预留字段2
        public string CReserve3 { get; set; }// 预留字段3
        public int IReserve1 { get; set; }// 预留字段4
        public int IReserve2 { get; set; }// 预留字段5
        public int IReserve3 { get; set; }// 预留字段6
        public string CreateUser { get; set; }// 新增人员
        public string CreateTime { get; set; }// 新增时间
        public string UpdateUser { get; set; }// 修改人员
        public string UpdateTime { get; set; }// 修改时间

    }
}
