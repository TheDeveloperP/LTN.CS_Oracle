namespace LTN.CS.SCMForm.PM
{
    partial class PM_OnlineScale_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.txt_MatNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_I_IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Out_Mat_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Out_Mat_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Mat_Ory_Wt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Mat_Act_Wt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Scale_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Weight_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Weight_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_State_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Prod_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Prod_Shift_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Prod_Shift_Group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Prod_Maker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Unit_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Mat_Spec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Mat_Num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Sg_Sign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_St_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_Billstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MatNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(881, 56);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.txt_MatNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(877, 52);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(294, 12);
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(141, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 2;
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(80, 12);
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(142, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 0;
            // 
            // txt_MatNo
            // 
            this.txt_MatNo.Location = new System.Drawing.Point(507, 12);
            this.txt_MatNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_MatNo.Name = "txt_MatNo";
            this.txt_MatNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_MatNo.Properties.Appearance.Options.UseFont = true;
            this.txt_MatNo.Size = new System.Drawing.Size(138, 26);
            this.txt_MatNo.StyleController = this.layoutControl1;
            this.txt_MatNo.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(877, 52);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_MatNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(427, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(210, 32);
            this.layoutControlItem3.Text = "材料号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_StartTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(214, 32);
            this.layoutControlItem4.Text = "开始时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.date_EndTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(214, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(213, 32);
            this.layoutControlItem5.Text = "结束时间";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(637, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(220, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 56);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(881, 35);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query1_32;
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(65, 32);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcl_main.Location = new System.Drawing.Point(0, 91);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(881, 416);
            this.gcl_main.TabIndex = 2;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_I_IntId,
            this.gCol_Out_Mat_No,
            this.gCol_Out_Mat_Name,
            this.gCol_Mat_Ory_Wt,
            this.gCol_Mat_Act_Wt,
            this.gCol_Scale_No,
            this.gCol_Weight_Time,
            this.gCol_Weight_Name,
            this.gCol_State_Id,
            this.gCol_Prod_Time,
            this.gCol_Prod_Shift_No,
            this.gCol_Prod_Shift_Group,
            this.gCol_Prod_Maker,
            this.gCol_Unit_Code,
            this.gCol_Mat_Spec,
            this.gCol_Mat_Num,
            this.gCol_Sg_Sign,
            this.gCol_St_No,
            this.gCol_Remark,
            this.gCol_I_Billstatus});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // gCol_I_IntId
            // 
            this.gCol_I_IntId.Caption = "主键";
            this.gCol_I_IntId.FieldName = "I_IntId";
            this.gCol_I_IntId.Name = "gCol_I_IntId";
            // 
            // gCol_Out_Mat_No
            // 
            this.gCol_Out_Mat_No.Caption = "材料号";
            this.gCol_Out_Mat_No.FieldName = "Out_Mat_No";
            this.gCol_Out_Mat_No.Name = "gCol_Out_Mat_No";
            this.gCol_Out_Mat_No.Visible = true;
            this.gCol_Out_Mat_No.VisibleIndex = 0;
            this.gCol_Out_Mat_No.Width = 175;
            // 
            // gCol_Out_Mat_Name
            // 
            this.gCol_Out_Mat_Name.Caption = "材料名称";
            this.gCol_Out_Mat_Name.FieldName = "Out_Mat_Name";
            this.gCol_Out_Mat_Name.Name = "gCol_Out_Mat_Name";
            this.gCol_Out_Mat_Name.Visible = true;
            this.gCol_Out_Mat_Name.VisibleIndex = 1;
            this.gCol_Out_Mat_Name.Width = 100;
            // 
            // gCol_Mat_Ory_Wt
            // 
            this.gCol_Mat_Ory_Wt.Caption = "理论重量（KG）";
            this.gCol_Mat_Ory_Wt.FieldName = "Mat_Ory_Wt";
            this.gCol_Mat_Ory_Wt.Name = "gCol_Mat_Ory_Wt";
            this.gCol_Mat_Ory_Wt.Visible = true;
            this.gCol_Mat_Ory_Wt.VisibleIndex = 2;
            this.gCol_Mat_Ory_Wt.Width = 125;
            // 
            // gCol_Mat_Act_Wt
            // 
            this.gCol_Mat_Act_Wt.Caption = "实际重量（KG）";
            this.gCol_Mat_Act_Wt.FieldName = "Mat_Act_Wt";
            this.gCol_Mat_Act_Wt.Name = "gCol_Mat_Act_Wt";
            this.gCol_Mat_Act_Wt.Visible = true;
            this.gCol_Mat_Act_Wt.VisibleIndex = 3;
            this.gCol_Mat_Act_Wt.Width = 125;
            // 
            // gCol_Scale_No
            // 
            this.gCol_Scale_No.Caption = "磅号";
            this.gCol_Scale_No.FieldName = "Scale_No";
            this.gCol_Scale_No.Name = "gCol_Scale_No";
            this.gCol_Scale_No.Visible = true;
            this.gCol_Scale_No.VisibleIndex = 4;
            this.gCol_Scale_No.Width = 90;
            // 
            // gCol_Weight_Time
            // 
            this.gCol_Weight_Time.Caption = "过磅时间";
            this.gCol_Weight_Time.FieldName = "Weight_Time";
            this.gCol_Weight_Time.Name = "gCol_Weight_Time";
            this.gCol_Weight_Time.Visible = true;
            this.gCol_Weight_Time.VisibleIndex = 5;
            this.gCol_Weight_Time.Width = 180;
            // 
            // gCol_Weight_Name
            // 
            this.gCol_Weight_Name.Caption = "过磅人员";
            this.gCol_Weight_Name.FieldName = "Weight_Name";
            this.gCol_Weight_Name.Name = "gCol_Weight_Name";
            this.gCol_Weight_Name.Visible = true;
            this.gCol_Weight_Name.VisibleIndex = 6;
            this.gCol_Weight_Name.Width = 100;
            // 
            // gCol_State_Id
            // 
            this.gCol_State_Id.Caption = "状态";
            this.gCol_State_Id.FieldName = "State_Id";
            this.gCol_State_Id.Name = "gCol_State_Id";
            this.gCol_State_Id.Visible = true;
            this.gCol_State_Id.VisibleIndex = 7;
            this.gCol_State_Id.Width = 90;
            // 
            // gCol_Prod_Time
            // 
            this.gCol_Prod_Time.Caption = "生产时刻";
            this.gCol_Prod_Time.FieldName = "Prod_Time";
            this.gCol_Prod_Time.Name = "gCol_Prod_Time";
            this.gCol_Prod_Time.Visible = true;
            this.gCol_Prod_Time.VisibleIndex = 8;
            this.gCol_Prod_Time.Width = 180;
            // 
            // gCol_Prod_Shift_No
            // 
            this.gCol_Prod_Shift_No.Caption = "生产班次";
            this.gCol_Prod_Shift_No.FieldName = "Prod_Shift_No";
            this.gCol_Prod_Shift_No.Name = "gCol_Prod_Shift_No";
            this.gCol_Prod_Shift_No.Visible = true;
            this.gCol_Prod_Shift_No.VisibleIndex = 9;
            this.gCol_Prod_Shift_No.Width = 90;
            // 
            // gCol_Prod_Shift_Group
            // 
            this.gCol_Prod_Shift_Group.Caption = "生产班组";
            this.gCol_Prod_Shift_Group.FieldName = "Prod_Shift_Group";
            this.gCol_Prod_Shift_Group.Name = "gCol_Prod_Shift_Group";
            this.gCol_Prod_Shift_Group.Visible = true;
            this.gCol_Prod_Shift_Group.VisibleIndex = 10;
            this.gCol_Prod_Shift_Group.Width = 90;
            // 
            // gCol_Prod_Maker
            // 
            this.gCol_Prod_Maker.Caption = "生产责任者";
            this.gCol_Prod_Maker.FieldName = "Prod_Maker";
            this.gCol_Prod_Maker.Name = "gCol_Prod_Maker";
            this.gCol_Prod_Maker.Visible = true;
            this.gCol_Prod_Maker.VisibleIndex = 11;
            this.gCol_Prod_Maker.Width = 100;
            // 
            // gCol_Unit_Code
            // 
            this.gCol_Unit_Code.Caption = "机组代码";
            this.gCol_Unit_Code.FieldName = "Unit_Code";
            this.gCol_Unit_Code.Name = "gCol_Unit_Code";
            this.gCol_Unit_Code.Visible = true;
            this.gCol_Unit_Code.VisibleIndex = 12;
            this.gCol_Unit_Code.Width = 90;
            // 
            // gCol_Mat_Spec
            // 
            this.gCol_Mat_Spec.Caption = "材料规格";
            this.gCol_Mat_Spec.FieldName = "Mat_Spec";
            this.gCol_Mat_Spec.Name = "gCol_Mat_Spec";
            this.gCol_Mat_Spec.Visible = true;
            this.gCol_Mat_Spec.VisibleIndex = 13;
            this.gCol_Mat_Spec.Width = 90;
            // 
            // gCol_Mat_Num
            // 
            this.gCol_Mat_Num.Caption = "材料件数";
            this.gCol_Mat_Num.FieldName = "Mat_Num";
            this.gCol_Mat_Num.Name = "gCol_Mat_Num";
            this.gCol_Mat_Num.Visible = true;
            this.gCol_Mat_Num.VisibleIndex = 14;
            this.gCol_Mat_Num.Width = 100;
            // 
            // gCol_Sg_Sign
            // 
            this.gCol_Sg_Sign.Caption = "牌号（钢级）";
            this.gCol_Sg_Sign.FieldName = "Sg_Sign";
            this.gCol_Sg_Sign.Name = "gCol_Sg_Sign";
            this.gCol_Sg_Sign.Visible = true;
            this.gCol_Sg_Sign.VisibleIndex = 15;
            this.gCol_Sg_Sign.Width = 110;
            // 
            // gCol_St_No
            // 
            this.gCol_St_No.Caption = "出钢记号";
            this.gCol_St_No.FieldName = "St_No";
            this.gCol_St_No.Name = "gCol_St_No";
            this.gCol_St_No.Visible = true;
            this.gCol_St_No.VisibleIndex = 16;
            this.gCol_St_No.Width = 100;
            // 
            // gCol_Remark
            // 
            this.gCol_Remark.Caption = "备注";
            this.gCol_Remark.FieldName = "Remark";
            this.gCol_Remark.Name = "gCol_Remark";
            this.gCol_Remark.Visible = true;
            this.gCol_Remark.VisibleIndex = 17;
            this.gCol_Remark.Width = 150;
            // 
            // gCol_I_Billstatus
            // 
            this.gCol_I_Billstatus.Caption = "计量状态";
            this.gCol_I_Billstatus.FieldName = "I_Billstatus";
            this.gCol_I_Billstatus.Name = "gCol_I_Billstatus";
            this.gCol_I_Billstatus.Visible = true;
            this.gCol_I_Billstatus.VisibleIndex = 18;
            this.gCol_I_Billstatus.Width = 100;
            // 
            // PM_OnlineScale_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "PM_OnlineScale_Form";
            this.ShowIcon = false;
            this.Text = "在线秤磅单管理";
            this.Shown += new System.EventHandler(this.PM_OnlineScale_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MatNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_MatNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_query;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_IntId;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Out_Mat_No;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Out_Mat_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Mat_Ory_Wt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Mat_Act_Wt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Scale_No;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Weight_Time;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Weight_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_State_Id;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Prod_Time;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Prod_Shift_No;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Prod_Shift_Group;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Prod_Maker;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Unit_Code;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Mat_Spec;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Mat_Num;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Sg_Sign;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_St_No;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Remark;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_Billstatus;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}