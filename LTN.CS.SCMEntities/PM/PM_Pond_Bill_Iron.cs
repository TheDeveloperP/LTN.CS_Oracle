using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Pond_Bill_Iron
    {
        #region 计划委托字段
        public string PlanNo { get; set; }// 委托单号
        public string HeatNo { get; set; }// 炉号(单元号)
        public string BatchNo { get; set; }// 炉批号
        public string LronNo { get; set; }// 铁次号
        public string TankNo { get; set; }// 铁水罐号
        public string ToDeptNo { get; set; }// 去向编码
        public string ToDeptName { get; set; }// 去向名称
        public string Remark { get; set; }// 备注
        public string CReserve1 { get; set; }// 预留字段1
        public string CReserve2 { get; set; }// 预留字段2
        public string CReserve3 { get; set; }// 预留字段3
        public int IReserve1 { get; set; }// 预留字段4
        public int IReserve2 { get; set; }// 预留字段5
        public int IReserve3 { get; set; }// 预留字段6
        public string PlanCreateUser { get; set; }// 委托人姓名
        public string PlanCreateTime { get; set; }// 委托时间
        #endregion
        #region 磅单字段
        public int IntId { get; set; }// 业务主键
        public string WgtlistNo { get; set; }// 码单号
        public decimal GrossWgt { get; set; }// 毛重
        public decimal TareWgt { get; set; }// 皮重
        public decimal TareWgt1 { get; set; }// 钢皮重
        public decimal NetWgt { get; set; }// 净重
        public decimal NetWgt1 { get; set; }// 钢净重
        public decimal SlagNum { get; set; }//扣杂量
        public decimal NetWgt2 { get; set; }// 扣杂后重量
        public string GrossWgtTime { get; set; }// 毛重时间
        public string TareWgtTime { get; set; }// 皮重时间
        public string GrossWgtSiteNo { get; set; }// 毛重磅点编号
        public string GrossWgtSiteName { get; set; }// 毛重磅点名称
        public string TareWgtSiteNo { get; set; }// 皮重磅点编号
        public string TareWgtSiteName { get; set; }// 皮重磅点名称
        public string GrossWgtMan { get; set; }// 毛重计量员
        public string TareWgtMan { get; set; }// 皮重计量员
        public string PondRemark { get; set; }// 磅单备注
        public string CReserveFlag1 { get; set; }// 预留字段1
        public string CReserveFlag2 { get; set; }// 预留字段2
        public string CReserveFlag3 { get; set; }// 预留字段3
        public int IReserveFlag1 { get; set; }// 预留字段4
        public int IReserveFlag2 { get; set; }// 预留字段5
        public int IReserveFlag3 { get; set; }// 预留字段6
        public string CreateUser { get; set; }// 新增人员
        public string CreateTime { get; set; }// 新增时间
        public string UpdateUser { get; set; }// 修改人员
        public string UpdateTime { get; set; }// 修改时间
        public EntityInt DataFlag { get; set; }// 数据状态
        public BillStatusObj BillStatus { get; set; }// 计量状态
        public string TrainGroupGross { get; set; }// 毛重车组
        public string TrainGroupTare { get; set; }// 皮重车组
        public string PlanStatus { get; set; }// 上传标志
        public string UpLoadStatus { get; set; }// 上传状态
        #endregion
    }
}
