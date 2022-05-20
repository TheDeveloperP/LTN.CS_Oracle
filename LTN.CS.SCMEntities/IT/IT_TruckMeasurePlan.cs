using LTN.CS.SCMEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.IT
{
    /// <summary>
    /// 汽车磅接口实体类
    /// </summary>
   public  class IT_TruckMeasurePlan
    {
        public string C_PLANSTATUS { get; set; }// 委托状态  I 新增  U 修改 D 删除
        public string C_PLANNO { get; set; }// 委托单号
        public string C_CARNO { get; set; }// 车号编码
        public string C_CARNAME { get; set; }// 车牌号码
        public string C_CARSERIALNUMBER  { get; set; }//汽车进厂流水号
        public string C_CONTRACTNO { get; set; }// 合同编号
        public string C_MATERIALNO { get; set; }// 品名编码
        public string C_MATERIALNAME { get; set; }//品名名称
        public string C_FROMDEPTNO { get; set; }//来源单位编码
        public string C_FROMDEPTNAME { get; set; }// 来源单位名称
        public string C_FROMSTORENO { get; set; }//来源库号编码
        public string C_FROMSTORENAME { get; set; }//来源库号名称
        public string C_TODEPTNO { get; set; }//去向单位编码
        public string C_TODEPTNAME { get; set; }//去向单位名称
        public string C_TOSTORENO { get; set; }// 去向库号编码
        public string C_TOSTORENAME { get; set; }//去向库号名称
        public BUSINESSTYPE I_BUSINESSTYPE { get; set; }//业务类型
        public PLANTYPE I_PLANTYPE { get; set; }//委托类型
        public int  I_ISAUTO { get; set; }//是否自助过磅
        public WEIGHTTYPE I_WEIGHTTYPE { get; set; }//过磅方式
        public int  I_TARETIMELIMIT { get; set; }//皮重时限
        public ONEMORESTOCK I_ONEMORESTOCK { get; set; }//一车多货标记
        public ISCHILDIDENFY I_ISCHILDIDENFY { get; set; }//母/子标识
        public int  I_ISCREATEMOTHERPOND { get; set; }//是否生成母码单
        public string C_CONNECTPLANNO { get; set; }//母/关联计划委托单号
        public int I_ONETWOPLAN { get; set; }//一车两单标记
        public string C_MIDDLEDEPTNO { get; set; }//中间单位编码
        public string C_MIDDLEDEPTNAME { get; set; }//中间单位名称
        public string C_MIDDLESTORENO { get; set; }//  中间库号编码
        public string C_MIDDLESTORENAME { get; set; }// 中间库号名称
        public int I_RETALLYKG { get; set; }//理重
        public COMPUTERTYPE I_COMPUTERTYPE { get; set; }//偏差计算方式
        public int I_DOWNVALUE { get; set; }//理重下偏差值
        public int I_UPVALUE { get; set; }//理重上偏差值
        public string C_PERCENTAGE { get; set; }//偏差百分比
        public string C_SHIPPINGNOTE { get; set; }// 托运号（业务代码）
        public REPEATPOUND I_REPEATPOUND { get; set; }//复磅标志
        public string C_PLANLIMITTIME { get; set; }//委托失效时间
        public string C_PONDLIMIT { get; set; }//磅点限制
        public string C_CREATETIME { get; set; }//委托创建时间
        public string C_CREATENAME { get; set; }//委托创建人姓名
        public string C_REMARK { get; set; }//备注
        public string C_RESERVE1 { get; set; }//预留字段1
        public string C_RESERVE2 { get; set; }//预留字段2
        public string C_RESERVE3 { get; set; }//预留字段3
        public int I_RESERVE1 { get; set; }//预留字段4
        public int I_RESERVE2 { get; set; }//预留字段5
        public int I_RESERVE3 { get; set; }//预留字段6
        public string  C_UPLOADSTATUS { get; set; }// 接受状态  Y 接受  N 未接受
        public string C_CONTAINERNO { get; set; } //集装箱号
        public string C_RESERVE4 { get; set; } //预留字段7   
        public string C_RESERVE5 { get; set; } //预留字段8   
        public string C_RESERVE6 { get; set; } //预留字段9  
        public string C_RESERVE7 { get; set; } //预留字段10 

        
    }

    public enum UPLOADSTATUS
    {
        接受='Y',
        未接受='N' 
    }
    public enum PLANSTATUS
    {
        新增 ='I' ,
        修改 = 'U',
        删除 = 'D'
    }
}
