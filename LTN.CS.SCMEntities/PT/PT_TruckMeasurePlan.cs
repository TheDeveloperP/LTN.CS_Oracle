using LTN.CS.Core;
using LTN.CS.SCMEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PT
{
    ///PT_TruckMeasurePlan 汽车磅计划委托表
    public class PT_TruckMeasurePlan : BaseEntity
    {

        public int I_INTID { get; set; } //主键  

        #region 自定义字段
        public PLANSTATE C_PLANSTATE { get; set; }//计量状态  0：未完成  1：已完成  2：已作废
        public string C_UPDATEUSERNAME { get; set; }//修改人姓名
        public string C_UPDATETIME { get; set; }//修改时间

        #endregion

        #region 接口字段
        /// <summary>
        /// 委托单号  编码规则例：T1PT1908180001，1-2位代表业务系统：T1:物流系统、IM:铁前MES、M1:钢后MMS等，第3位代表业务类型：P：采购 S：销售 K：内转，第4位代表秤型类型：T:汽车磅、B：物资轨道衡、I:铁水轨道衡、S:皮带秤、C:钢卷秤，第5-10位代表日期，第11-14位代表流水号
        /// </summary>
        public string C_PLANNO { get; set; }
        /// <summary>
        /// 车号编码  
        /// </summary>
        public string C_CARNO { get; set; }
        /// <summary>
        /// 车牌号码  
        /// </summary>
        public string C_CARNAME { get; set; }
        /// <summary>
        /// 汽车进厂流水号
        /// </summary>
        public string C_CARSERIALNUMBER { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string C_CONTRACTNO { get; set; }
        /// <summary>
        /// 品名编码  
        /// </summary>
        public string C_MATERIALNO { get; set; }
        /// <summary>
        /// 品名名称    
        /// </summary>
        public string C_MATERIALNAME { get; set; }
        /// <summary>
        /// 来源单位编码 
        /// </summary>
        public string C_FROMDEPTNO { get; set; }
        /// <summary>
        /// 来源单位名称  
        /// </summary>
        public string C_FROMDEPTNAME { get; set; }
        /// <summary>
        /// 来源库号编码
        /// </summary>
        public string C_FROMSTORENO { get; set; }
        /// <summary>
        /// 来源库号名称   可以理解为装点
        /// </summary>
        public string C_FROMSTORENAME { get; set; }
        /// <summary>
        /// 去向单位编码
        /// </summary>
        public string C_TODEPTNO { get; set; }
        /// <summary>
        /// 去向单位名称 
        /// </summary>
        public string C_TODEPTNAME { get; set; }
        /// <summary>
        /// 去向库号编码
        /// </summary>
        public string C_TOSTORENO { get; set; }
        /// <summary>
        /// 去向库号名称    可以理解为卸点
        /// </summary>
        public string C_TOSTORENAME { get; set; }
        /// <summary>
        /// 业务类型    		0、1、2（进厂、出厂、内倒）
        /// </summary>
        public BUSINESSTYPE I_BUSINESSTYPE { get; set; }
        /// <summary>
        /// 委托类型    		0、1（长期委托、一次委托） 
        /// </summary>
        public PLANTYPE I_PLANTYPE { get; set; }
        /// <summary>
        /// 是否自助过磅  		0、1（否、是）
        /// </summary>
        public int I_ISAUTO { get; set; }
        /// <summary>
        /// 过磅方式   		1.先皮后毛2.先毛后皮3.限期皮重(一皮多毛)
        /// </summary>
        public WEIGHTTYPE I_WEIGHTTYPE { get; set; }
        /// <summary>
        /// 皮重时限      按小时赋值（班皮、日皮、月皮）
        /// </summary>
        public int I_TARETIMELIMIT { get; set; }
        /// <summary>
        /// 一车多货标记  	0、1、2（无、一车多装、一车多卸）
        /// </summary>
        public ONEMORESTOCK I_ONEMORESTOCK { get; set; }
        /// <summary>
        /// 母/子标识    	0、1(子、母)
        /// </summary>
        public ISCHILDIDENFY I_ISCHILDIDENFY { get; set; }
        /// <summary>
        /// 是否生成母码单 	0、1（否、是）
        /// </summary>
        public int I_ISCREATEMOTHERPOND { get; set; }
        /// <summary>
        /// 母/关联计划委托单号 
        /// </summary>
        public string C_CONNECTPLANNO { get; set; }
        /// <summary>
        /// NUMBER(1)    		0、1（否、是）
        /// </summary>
        public int I_ONETWOPLAN { get; set; }
        /// <summary>
        /// 中间单位编码  
        /// </summary>
        public string C_MIDDLEDEPTNO { get; set; }
        /// <summary>
        /// 中间单位名称  
        /// </summary>
        public string C_MIDDLEDEPTNAME { get; set; }
        /// <summary>
        /// 中间库号编码  
        /// </summary>
        public string C_MIDDLESTORENO { get; set; }
        /// <summary>
        /// 中间库号名称  V
        /// </summary>
        public string C_MIDDLESTORENAME { get; set; }
        /// <summary>
        ///    0	Kg 理重
        /// </summary>
        public int I_RETALLYKG { get; set; }
        /// <summary>
        /// 偏差计算方式         0		0、1、2 （无、固定值、百分比）
        /// </summary>
        public COMPUTERTYPE I_COMPUTERTYPE { get; set; }
        /// <summary>
        /// 理重下偏差值      0	Kg 下偏差
        /// </summary>
        public int I_DOWNVALUE { get; set; }
        /// <summary>
        /// 理重上偏差值        0	Kg 上偏差
        /// </summary>
        public int I_UPVALUE { get; set; }
        /// <summary>
        /// 偏差百分比      如5%
        /// </summary>
        public string C_PERCENTAGE { get; set; }
        /// <summary>
        /// 托运号（业务代码）	              业务代码
        /// </summary>
        public string C_SHIPPINGNOTE { get; set; }
        /// <summary>
        /// 复磅标志         0		0:无,1:毛毛皮,2:毛毛皮皮
        /// </summary>
        public REPEATPOUND I_REPEATPOUND { get; set; }
        /// <summary>
        /// 委托失效时间      N yyyyMMddHHmmss
        /// </summary>
        public string C_PLANLIMITTIME { get; set; }
        /// <summary>
        /// 磅点限制  
        /// </summary>
        public string C_PONDLIMIT { get; set; }
        /// <summary>
        /// 委托创建时间     yyyyMMddHHmmss
        /// </summary>
        public string C_CREATETIME { get; set; }
        /// <summary>
        /// 委托创建人姓名    
        /// </summary>
        public string C_CREATEUSERNAME { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        public string C_REMARK { get; set; }
        /// <summary>
        ///  预留字段1  
        /// </summary>
        public string C_RESERVE1 { get; set; }
        /// <summary>
        ///  预留字段2
        /// </summary>
        public string C_RESERVE2 { get; set; }
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string C_RESERVE3 { get; set; }
        /// <summary>
        /// 集装箱号标识
        /// </summary>
        public int I_RESERVE1 { get; set; }
        /// <summary>
        /// 预留字段5
        /// </summary>
        public int I_RESERVE2 { get; set; }
        /// <summary>
        /// 预留字段6
        /// </summary>
        public int I_RESERVE3 { get; set; } 
        /// <summary>
        /// 集装箱号
        /// </summary>
        public string C_CONTAINERNO { get; set; }
        /// <summary>
        /// 预留字段7
        /// </summary>
        public string C_RESERVE4 { get; set; }   
        /// <summary>
        /// 预留字段8
        /// </summary>
        public string C_RESERVE5 { get; set; }    
        /// <summary>
        /// 预留字段9  
        /// </summary>
        public string C_RESERVE6 { get; set; } 
        /// <summary>
        /// 预留字段10
        /// </summary>
        public string C_RESERVE7 { get; set; }  
        
        #endregion
    }
   
}
