using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Bill_Iron
    {
        public int IntId { get; set; }// 业务主键
        public string PlanNo { get; set; }// 委托单号
        public string HeatNo { get; set; }// 炉号(单元号)
        public string BatchNo { get; set; }// 炉批号
        public string LronNo { get; set; }// 铁次号
        public string TankNo { get; set; }// 铁水罐号
        public string ToDeptNo { get; set; }// 去向编码
        public string ToDeptName { get; set; }// 去向名称
        public BillStatusObj BillStatus { get; set; }// 计量状态
        public string Remark { get; set; }// 备注
        public string CReserve1 { get; set; }// 预留字段1
        public string CReserve2 { get; set; }// 预留字段2
        public string CReserve3 { get; set; }// 预留字段3
        public int IReserve1 { get; set; }// 预留字段4
        public int IReserve2 { get; set; }// 预留字段5
        public int IReserve3 { get; set; }// 预留字段6
        public string CreateUserName { get; set; }// 新增人员
        public string CreateTime { get; set; }// 新增时间
        public string UpdateUserName { get; set; }// 修改人员
        public string UpdateTime { get; set; }// 修改时间
    }
}
