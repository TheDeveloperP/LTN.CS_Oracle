using LTN.CS.SCMEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Bill_Truck_History
    {
        public int I_INTID { get; set; }//主键

        #region 委托字段          		
        public string C_PLANNO { get; set; }     //委托单号  编码规则例：T1PT1908180001，1-2位代表业务系统：T1:物流系统、IM:铁前MES、M1:钢后MMS等，第3位代表业务类型：P：采购 S：销售 K：内转，第4位代表秤型类型：T:汽车磅、B：物资轨道衡、I:铁水轨道衡、S:皮带秤、C:钢卷秤，第5-10位代表日期，第11-14位代表流水号
        public string C_CARNO { get; set; }      //车号编码    
        public string C_CARNAME { get; set; }    //车牌号码  
        public string C_CARSERIALNUMBER { get; set; }//汽车进厂流水号
        public string C_CONTRACTNO { get; set; }// 合同编号 
        public string C_MATERIALNO { get; set; }   //品名编码    
        public string C_MATERIALNAME { get; set; } //品名名称    
        public string C_FROMDEPTNO { get; set; }   //来源单位编码 
        public string C_FROMDEPTNAME { get; set; } //来源单位名称  
        public string C_FROMSTORENO { get; set; }   //来源库号编码  
        public string C_FROMSTORENAME { get; set; }    //来源库号名称   可以理解为装点
        public string C_TODEPTNO { get; set; }         //去向单位编码  
        public string C_TODEPTNAME { get; set; }       //去向单位名称  
        public string C_TOSTORENO { get; set; }        //去向库号编码  
        public string C_TOSTORENAME { get; set; }      //去向库号名称    可以理解为卸点
        public BUSINESSTYPE I_BUSINESSTYPE { get; set; }    //业务类型    		0、1、2（进厂、出厂、内倒）
        public PLANTYPE I_PLANTYPE { get; set; }            //委托类型    		0、1（长期委托、一次委托）  
        public int I_ISAUTO { get; set; }                   //是否自助过磅  		0、1（是、否）
        public WEIGHTTYPE I_WEIGHTTYPE { get; set; }         //过磅方式   		1.先皮后毛2.先毛后皮3.限期皮重(一皮多毛)
        public int I_TARETIMELIMIT { get; set; }             //皮重时限      按小时赋值（班皮、日皮、月皮）
        public ONEMORESTOCK I_ONEMORESTOCK { get; set; }     //一车多货标记  	0、1、2（无、一车多装、一车多卸）
        public ISCHILDIDENFY I_ISCHILDIDENFY { get; set; }   //母/子标识    	0、1(子、母)
        public int I_ISCREATEMOTHERPOND { get; set; }        //是否生成母码单 	0、1（否、是）
        public string C_CONNECTPLANNO { get; set; }          //母/关联计划委托单号 
        public int I_ONETWOPLAN { get; set; }                //NUMBER(1)    		0、1（否、是）
        public string C_MIDDLEDEPTNO { get; set; }           //中间单位编码  
        public string C_MIDDLEDEPTNAME { get; set; }         //中间单位名称  
        public string C_MIDDLESTORENO { get; set; }           //中间库号编码  
        public string C_MIDDLESTORENAME { get; set; }         // 中间库号名称  V
        public int I_RETALLYKG { get; set; }            //  0	Kg 理重  
        public COMPUTERTYPE I_COMPUTERTYPE { get; set; } //偏差计算方式         0		0、1、2 （无、固定值、百分比）
        public int I_DOWNVALUE { get; set; }             //理重下偏差值      0	Kg 下偏差
        public int I_UPVALUE { get; set; }               //理重上偏差值        0	Kg 上偏差
        public string C_PERCENTAGE { get; set; }             //偏差百分比           如5%
        public string C_SHIPPINGNOTE { get; set; }        //托运号（业务代码）	              业务代码
        public REPEATPOUND I_REPEATPOUND { get; set; }   //复磅标志         0		0:无,1:毛毛皮,2:毛毛皮皮
        public string C_PLANLIMITTIME { get; set; }   //委托失效时间      N yyyyMMddHHmmss
        public string C_PONDLIMIT { get; set; }      //磅点限制    
        public string C_CREATETIME { get; set; } //委托创建时间     yyyyMMddHHmmss
        public string C_CREATEUSERNAME { get; set; } //委托创建人姓名 
        public string C_REMARK { get; set; }         //备注 
        public string C_RESERVE1 { get; set; }       // 预留字段1  
        public string C_RESERVE2 { get; set; }       //预留字段2  
        public string C_RESERVE3 { get; set; }       //预留字段3   
        public int I_RESERVE1 { get; set; }          //预留字段4  	
        public int I_RESERVE2 { get; set; }          //预留字段5   
        public int I_RESERVE3 { get; set; }          //预留字段6   

        public PLANSTATE C_PLANSTATE { get; set; }     //计量状态  0：未完成  1：已完成  2：已作废

        public string C_CONTAINERNO { get; set; } //集装箱号
        public string C_RESERVE4 { get; set; } //预留字段7   
        public string C_RESERVE5 { get; set; } //预留字段8   
        public string C_RESERVE6 { get; set; } //预留字段9  
        public string C_RESERVE7 { get; set; } //预留字段10 

        #endregion
        #region 磅单字段
        public string C_WGTLISTNO { get; set; } //磅单号 VARCHAR2(30)
        public string C_BARCODENO { get; set; } //条码号 VARCHAR2(30)
        public int N_TAREWGT { get; set; } //皮重  NUMBER(10)
        public int N_GROSSWGT { get; set; } // 毛重  NUMBER(10)
        public int N_NETWGT { get; set; } //净重  NUMBER(10)
        public string C_TAREWGTTIME { get; set; } //皮重时间    VARCHAR2(20)
        public string C_GROSSWGTTIME { get; set; } //毛重时间    VARCHAR2(20)
        public string C_NETWGTTIME { get; set; } //净重时间    VARCHAR2(20)
        public string C_TAREWGTSITENO { get; set; } //皮重磅点编码  VARCHAR2(10)
        public string C_TAREWGTSITENAME { get; set; } //皮重磅点名称  VARCHAR2(20)
        public string C_GROSSWGTSITENO { get; set; } //毛重磅点编码  VARCHAR2(10)
        public string C_GROSSWGTSITENAME { get; set; } //毛重磅点名称  VARCHAR2(20)
        public string C_TAREWGTMAN { get; set; } //皮重计量员   VARCHAR2(10)
        public string C_GROSSWGTMAN { get; set; } //毛重计量员   VARCHAR2(10)
        public int I_RETURNFLAG { get; set; } //退货标志    NUMBER(1) 0退货 1正常
        public string C_PONDREMARK { get; set; } // 备注  VARCHAR2(200)
        public string C_RESERVEFLAG1 { get; set; } // 预留字段1   VARCHAR2(200)
        public string C_RESERVEFLAG2 { get; set; } //预留字段2   VARCHAR2(200)
        public string C_RESERVEFLAG3 { get; set; } //预留字段3   VARCHAR2(200)
        public int I_RESERVEFLAG1 { get; set; } //预留字段4   NUMBER(10)
        public int I_RESERVEFLAG2 { get; set; } //预留字段5   NUMBER(10)
        public int I_RESERVEFLAG3 { get; set; } //预留字段6   NUMBER(10)

        #endregion
        #region 自定义字段
        public PLANSTATE C_BILLSTATE { get; set; }//磅单状态

        public string C_UPDATEUSERNAME { get; set; }//修改人姓名
        public string C_UPDATETIME { get; set; }//修改时间
        public string C_BILLCREATETIME { get; set; } //磅单创建时间     yyyyMMddHHmmss
        public string C_BILLCREATEUSERNAME { get; set; } //磅单创建人姓名 

        public int I_REPEATFLAG { get; set; }//复磅标志 0正常 1复磅

        public string C_UPLOADSTATUE { get; set; }  // 未上抛 N 已上抛 Y

        public string C_PLANSTATUS { get; set; } //I 新增  U 修改 D 删除
        public int I_PRINTNUM { get; set; }//打印次数
        public string  C_UPDATECOLUMNS { get; set; }//更新字段拼接
        public string C_UPDATEHISTORYUSER { get; set; }//磅单历史修改人
        public string C_UPDATEHISTORYTIME { get; set; }//磅单历史修改时间
        public string C_COMPUTERIP { get; set; }//修改磅单电脑IP

        #endregion
    }
}
