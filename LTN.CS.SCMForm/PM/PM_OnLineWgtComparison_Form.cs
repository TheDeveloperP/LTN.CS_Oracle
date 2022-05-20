using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using LTN.CS.Base;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_OnLineWgtComparison_Form : CoreForm
    {
        IPM_Bill_OnlineScaleService OnlineScaleService { get; set; }
        public PM_OnLineWgtComparison_Form()
        {
            InitializeComponent();
            CreateGridLevelView();
        }
        private void CreateGridLevelView()
        {
            GridView gridviewdetail = new GridView();
            gridviewdetail.ViewCaption = "在线秤磅单明细";
            gridviewdetail.Name = "grv2";
            gridviewdetail.GridControl = this.gCtrl_TruckBillWithOnlineBills;
            gridviewdetail.OptionsView.ShowGroupPanel = false;
            gridviewdetail.OptionsView.ColumnAutoWidth = false;
            gridviewdetail.OptionsBehavior.Editable = false;
            //构建GridLevelNode并添加到LevelTree集合里面
            GridLevelNode LevelNode = new GridLevelNode();
            LevelNode.LevelTemplate = gridviewdetail;
            LevelNode.RelationName = "OnLineBills";//这里对应集合的属性名称
            gCtrl_TruckBillWithOnlineBills.LevelTree.Nodes.AddRange(new GridLevelNode[]
            {
                LevelNode
            });
            //添加对应的视图集合显示
            this.gCtrl_TruckBillWithOnlineBills.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            LevelNode});
            //创建从表显示的列
            gridviewdetail.Columns.Clear();
            GridColumn gCol_I_IntId = new GridColumn();
            GridColumn gCol_Out_Mat_No = new GridColumn();
            GridColumn gCol_Out_Mat_Name = new GridColumn();
            GridColumn gCol_Mat_Ory_Wt = new GridColumn();
            GridColumn gCol_Mat_Act_Wt = new GridColumn();
            GridColumn gCol_Scale_No = new GridColumn();
            GridColumn gCol_Weight_Time = new GridColumn();
            GridColumn gCol_Weight_Name = new GridColumn();
            GridColumn gCol_Prod_Time = new GridColumn();
            GridColumn gCol_Unit_Code = new GridColumn();
            GridColumn gCol_Mat_Spec = new GridColumn();
            GridColumn gCol_Mat_Num = new GridColumn();
            GridColumn gCol_Sg_Sign = new GridColumn();
            GridColumn gCol_St_No = new GridColumn();
            GridColumn gCol_Remark = new GridColumn();

            // gCol_I_IntId
            gCol_I_IntId.Caption = "主键";
            gCol_I_IntId.FieldName = "I_IntId";
            gCol_I_IntId.Name = "gCol_I_IntId";
            // gCol_Out_Mat_No
            gCol_Out_Mat_No.Caption = "材料号";
            gCol_Out_Mat_No.FieldName = "Out_Mat_No";
            gCol_Out_Mat_No.Name = "gCol_Out_Mat_No";
            gCol_Out_Mat_No.Visible = true;
            gCol_Out_Mat_No.VisibleIndex = 0;
            gCol_Out_Mat_No.Width = 75;
            // gCol_Out_Mat_Name
            gCol_Out_Mat_Name.Caption = "材料名称";
            gCol_Out_Mat_Name.FieldName = "Out_Mat_Name";
            gCol_Out_Mat_Name.Name = "gCol_Out_Mat_Name";
            gCol_Out_Mat_Name.Visible = true;
            gCol_Out_Mat_Name.VisibleIndex = 1;
            gCol_Out_Mat_Name.Width = 75;
            // gCol_Mat_Ory_Wt
            gCol_Mat_Ory_Wt.Caption = "理论重量（KG）";
            gCol_Mat_Ory_Wt.FieldName = "Mat_Ory_Wt";
            gCol_Mat_Ory_Wt.Name = "gCol_Mat_Ory_Wt";
            gCol_Mat_Ory_Wt.Visible = true;
            gCol_Mat_Ory_Wt.VisibleIndex = 2;
            gCol_Mat_Ory_Wt.Width = 100;
            // gCol_Mat_Act_Wt
            gCol_Mat_Act_Wt.Caption = "实际重量（KG）";
            gCol_Mat_Act_Wt.FieldName = "Mat_Act_Wt";
            gCol_Mat_Act_Wt.Name = "gCol_Mat_Act_Wt";
            gCol_Mat_Act_Wt.Visible = true;
            gCol_Mat_Act_Wt.VisibleIndex = 3;
            gCol_Mat_Act_Wt.Width = 100;
            // gCol_Scale_No
            gCol_Scale_No.Caption = "磅号";
            gCol_Scale_No.FieldName = "Scale_No";
            gCol_Scale_No.Name = "gCol_Scale_No";
            gCol_Scale_No.Visible = true;
            gCol_Scale_No.VisibleIndex = 4;
            gCol_Scale_No.Width = 50;
            // gCol_Weight_Time
            gCol_Weight_Time.Caption = "过磅时间";
            gCol_Weight_Time.FieldName = "Weight_Time";
            gCol_Weight_Time.Name = "gCol_Weight_Time";
            gCol_Weight_Time.Visible = true;
            gCol_Weight_Time.VisibleIndex = 5;
            gCol_Weight_Time.Width = 150;
            // gCol_Weight_Name
            gCol_Weight_Name.Caption = "过磅人员";
            gCol_Weight_Name.FieldName = "Weight_Name";
            gCol_Weight_Name.Name = "gCol_Weight_Name";
            gCol_Weight_Name.Visible = true;
            gCol_Weight_Name.VisibleIndex = 6;
            gCol_Weight_Name.Width = 100;
            // gCol_Prod_Time
            gCol_Prod_Time.Caption = "生产时刻";
            gCol_Prod_Time.FieldName = "Prod_Time";
            gCol_Prod_Time.Name = "gCol_Prod_Time";
            gCol_Prod_Time.Visible = true;
            gCol_Prod_Time.VisibleIndex = 8;
            gCol_Prod_Time.Width = 150;
            gCol_Prod_Time.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            gCol_Prod_Time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // gCol_Unit_Code
            gCol_Unit_Code.Caption = "机组代码";
            gCol_Unit_Code.FieldName = "Unit_Code";
            gCol_Unit_Code.Name = "gCol_Unit_Code";
            gCol_Unit_Code.Visible = true;
            gCol_Unit_Code.VisibleIndex = 12;
            gCol_Unit_Code.Width = 75;
            // gCol_Mat_Spec
            gCol_Mat_Spec.Caption = "材料规格";
            gCol_Mat_Spec.FieldName = "Mat_Spec";
            gCol_Mat_Spec.Name = "gCol_Mat_Spec";
            gCol_Mat_Spec.Visible = true;
            gCol_Mat_Spec.VisibleIndex = 13;
            gCol_Mat_Spec.Width = 75;
            // gCol_Mat_Num
            gCol_Mat_Num.Caption = "材料件数";
            gCol_Mat_Num.FieldName = "Mat_Num";
            gCol_Mat_Num.Name = "gCol_Mat_Num";
            gCol_Mat_Num.Visible = true;
            gCol_Mat_Num.VisibleIndex = 14;
            gCol_Mat_Num.Width = 50;
            // gCol_Sg_Sign
            gCol_Sg_Sign.Caption = "牌号（钢级）";
            gCol_Sg_Sign.FieldName = "Sg_Sign";
            gCol_Sg_Sign.Name = "gCol_Sg_Sign";
            gCol_Sg_Sign.Visible = true;
            gCol_Sg_Sign.VisibleIndex = 15;
            gCol_Sg_Sign.Width = 100;
            // gCol_St_No
            gCol_St_No.Caption = "出钢记号";
            gCol_St_No.FieldName = "St_No";
            gCol_St_No.Name = "gCol_St_No";
            gCol_St_No.Visible = true;
            gCol_St_No.VisibleIndex = 16;
            gCol_St_No.Width = 100;
            // gCol_Remark
            gCol_Remark.Caption = "备注";
            gCol_Remark.FieldName = "Remark";
            gCol_Remark.Name = "gCol_Remark";
            gCol_Remark.Visible = true;
            gCol_Remark.VisibleIndex = 17;
            gCol_Remark.Width = 150;

            gridviewdetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                gCol_I_IntId,
                gCol_Out_Mat_No,
                gCol_Out_Mat_Name,
                gCol_Mat_Ory_Wt,
                gCol_Mat_Act_Wt,
                gCol_Scale_No,
                gCol_Weight_Time,
                gCol_Weight_Name,
                gCol_Prod_Time,
                gCol_Unit_Code,
                gCol_Mat_Spec,
                gCol_Mat_Num,
                gCol_Sg_Sign,
                gCol_St_No,
                gCol_Remark});
        }
        private void btn_Query_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("PLANNO", txt_PlanNo.Text.Trim());
            gCtrl_TruckBillWithOnlineBills.DataSource = OnlineScaleService.ExecuteDB_QueryTruckBillWithOnlineBills(ht);
        }
    }
}
