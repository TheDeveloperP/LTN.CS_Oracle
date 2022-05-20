using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.ServiceInterface.Gam
{
    [DataContract]
    public class IT_TruckMeasurePlan
    {
        [DataMember]
        public int I_INTID { get; set; }
        [DataMember]
        public string C_PLANSTATUS { get; set; }//I -> 新增数据  D -> 删除数据  U -> 更新数据
        [DataMember]
        public string C_UPLOADSTATUS { get; set; } //接受状态  Y 接受  N 未接受
        [DataMember]
        public string C_PLANNO { get; set; } //委托单号  编码规则例：T1PT1908180001，1-2位代表业务系统：T1:物流系统、IM:铁前MES、M1:钢后MMS等，第3位代表业务类型：P：采购 S：销售 K：内转，第4位代表秤型类型：T:汽车磅、B：物资轨道衡、I:铁水轨道衡、S:皮带秤、C:钢卷秤，第5-10位代表日期，第11-14位代表流水号
        [DataMember]
        public string C_CARNO { get; set; } //车号编码    
        [DataMember]
        public string C_CARNAME { get; set; } //车牌号码   
        [DataMember]
        public string C_CARSERIALNUMBER { get; set; }//汽车进厂流水号
        [DataMember]
        public string C_CONTRACTNO { get; set; }// 合同编号
        [DataMember]
        public string C_MATERIALNO { get; set; } //品名编码    
        [DataMember]
        public string C_MATERIALNAME { get; set; } //品名名称    
        [DataMember]
        public string C_FROMDEPTNO { get; set; } //来源单位编码 
        [DataMember]
        public string C_FROMDEPTNAME { get; set; } //来源单位名称  
        [DataMember]
        public string C_FROMSTORENO { get; set; } //来源库号编码  
        [DataMember]
        public string C_FROMSTORENAME { get; set; } //来源库号名称   可以理解为装点
        [DataMember]
        public string C_TODEPTNO { get; set; } //去向单位编码  
        [DataMember]
        public string C_TODEPTNAME { get; set; } //去向单位名称  
        [DataMember]
        public string C_TOSTORENO { get; set; } //去向库号编码  
        [DataMember]
        public string C_TOSTORENAME { get; set; } //去向库号名称    可以理解为卸点
        [DataMember]
        public int I_BUSINESSTYPE { get; set; } //业务类型    		0、1、2（进厂、出厂、内倒）
        [DataMember]
        public int I_PLANTYPE { get; set; } //委托类型    		0、1（长期委托、一次委托）  
        [DataMember]
        public int I_ISAUTO { get; set; } //是否自助过磅  		0、1（是、否）
        [DataMember]
        public int I_WEIGHTTYPE { get; set; } //过磅方式   		1.先皮后毛2.先毛后皮3.限期皮重(一皮多毛)
        [DataMember]
        public int I_TARETIMELIMIT { get; set; } //皮重时限      按小时赋值（班皮、日皮、月皮）
        [DataMember]
        public int I_ONEMORESTOCK { get; set; } //一车多货标记  	0、1、2（无、一车多装、一车多卸）
        [DataMember]
        public int I_ISCHILDIDENFY { get; set; } //母/子标识    	0、1(子、母)
        [DataMember]
        public int I_ISCREATEMOTHERPOND { get; set; } //是否生成母码单 	0、1（否、是）
        [DataMember]
        public string C_CONNECTPLANNO { get; set; } //母/关联计划委托单号 
        [DataMember]
        public int I_ONETWOPLAN { get; set; } //NUMBER(1)    		0、1（否、是）
        [DataMember]
        public string C_MIDDLEDEPTNO { get; set; } //中间单位编码  
        [DataMember]
        public string C_MIDDLEDEPTNAME { get; set; } //中间单位名称  
        [DataMember]
        public string C_MIDDLESTORENO { get; set; } //中间库号编码  
        [DataMember]
        public string C_MIDDLESTORENAME { get; set; } // 中间库号名称  V
        [DataMember]
        public int I_RETALLYKG { get; set; } //  0	Kg 理重  
        [DataMember]
        public int I_COMPUTERTYPE { get; set; } //偏差计算方式         0		0、1、2 （无、固定值、百分比）
        [DataMember]
        public int I_DOWNVALUE { get; set; } //理重下偏差值      0	Kg 下偏差
        [DataMember]
        public int I_UPVALUE { get; set; } //理重上偏差值        0	Kg 上偏差
        [DataMember]
        public int C_PERCENTAGE { get; set; } //偏差百分比           如5%
        [DataMember]
        public string C_SHIPPINGNOTE { get; set; } //托运号（业务代码）	              业务代码
        [DataMember]
        public int I_REPEATPOUND { get; set; } //复磅标志         0		0:无,1:毛毛皮,2:毛毛皮皮
        [DataMember]
        public string C_PLANLIMITTIME { get; set; } //委托失效时间      N yyyyMMddHHmmss
        [DataMember]
        public string C_PONDLIMIT { get; set; } //磅点限制  
        [DataMember]
        public string C_CREATETIME { get; set; } //委托创建时间     yyyyMMddHHmmss
        [DataMember]
        public string C_CREATENAME { get; set; } //委托创建人姓名
        [DataMember]
        public string C_REMARK { get; set; } //备注 
        [DataMember]
        public string C_RESERVE1 { get; set; } // 预留字段1  
        [DataMember]
        public string C_RESERVE2 { get; set; } //预留字段2  
        [DataMember]
        public string C_RESERVE3 { get; set; } //预留字段3   
        [DataMember]
        public int I_RESERVE1 { get; set; } //预留字段4  	
        [DataMember]
        public int I_RESERVE2 { get; set; } //预留字段5   
        [DataMember]
        public int I_RESERVE3 { get; set; } //预留字段6   
    }
}
