using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Bill_OnlineScale:BaseEntity
    {
        public int I_IntId { get; set; }    //	业务主键
        public string Out_Mat_No { get; set; }  //	材料号
        public string Out_Mat_Name { get; set; }    //	材料名称
        public int Mat_Ory_Wt { get; set; } //	材料理论重量（KG）
        public int Mat_Act_Wt { get; set; } //	材料实际重量（KG）
        public string Scale_No { get; set; }    //	磅号
        public string Weight_Time { get; set; } //	过磅时间
        public string Weight_Name { get; set; } //	过磅人员
        public string State_Id { get; set; }    //	状态  0(自动)，1(手动)
        public string Prod_Time { get; set; }   //	生产时刻
        public string Prod_Shift_No { get; set; }   //	生产班次
        public string Prod_Shift_Group { get; set; }    //	生产班组
        public string Prod_Maker { get; set; }  //	生产责任者
        public string Unit_Code { get; set; }   //	机组代码
        public string Mat_Spec { get; set; }    //	材料规格
        public int Mat_Num { get; set; }    //	材料件数（根数）
        public string Sg_Sign { get; set; } //	牌号（钢级）
        public string St_No { get; set; }   //	出钢记号
        public string Remark { get; set; }  //	备注
        public string Reserve1 { get; set; }    //	预留字段1
        public string Reserve2 { get; set; }    //	预留字段2
        public string Reserve3 { get; set; }    //	预留字段3
        public string Reserve4 { get; set; }    //	预留字段4
        public string Reserve5 { get; set; }    //	预留字段5
        public string Reserve6 { get; set; }    //	预留字段6
        public string Reserve7 { get; set; }    //	预留字段7
        public string Reserve8 { get; set; }    //	预留字段8
        public string Reserve9 { get; set; }    //	预留字段9
        public string Reserve10 { get; set; }   //	预留字段10
        public int I_Billstatus { get; set; }	//	计量状态 0未完成 1完成 2作废

    }
}
