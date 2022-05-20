using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Meter_Info : BaseEntity
    {
        public int IntId { get; set; }  //业务主键
                                        //   public SM_PondSite_Info PondId { get; set; } //磅点ID   

        public string MeterName { get; set; }//仪表名称
        public string Factory { get; set; }//厂家
        public string MeterSpec { get; set; }//仪表规格       
        public string AnalysisNo { get; set; }//解析程序编号
        public string ClearNo { get; set; }//清零程序编号
        public string MeterModel { get; set; }//型号
        public decimal UpperLimit { get; set; }//零点上限
        public decimal LowerLimit { get; set; }//零点下限
        public decimal Range { get; set; }//量程            
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser
                                                
        public string createTime { get; set; } //新增时间
        public string updateTime { get; set; }  //修改时间

    }
}
