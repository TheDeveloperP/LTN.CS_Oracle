using LTN.CS.Base.Common;
using LTN.CS.SCMEntities.SM;
using System;
using System.Linq;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_RawData_MoveTrain
    {
        public int IntId { get; set; }// 主键
        public SM_PoundSite_Info SiteNo { get; set; }//磅点
        public string OrderNo { get; set; }// 车序
        public string CarNo { get; set; }// 车号
        public string FormationTag { get; set; }// 车组
        public Decimal WeightData { get; set; }// 重量
        public Decimal Speed { get; set; }// 车速
        public string WeightTime { get; set; }// 过磅时间
        public WeightTypeObj WeightFlag { get; set; }// 重量类型
        public RawDataStatusObj DataFlag { get; set; }// 数据状态
        public int IsUse { get; set; }
        public string CreateUser { get; set; }// 新增人员
        public string CreateTime { get; set; }// 新增时间
        public string UpdateUser { get; set; }// 修改人员
        public string UpdateTime { get; set; }// 修改时间

        //新增字段
        /*
        public string Reserve1 { get; set; }
        public string Reserve2 { get; set; }
         * */
        //public string Reserve3 { get; set; }
       
    }
}
