namespace LTN.CS.SCMForm.PM
{
    partial class PM_Bill_OrbitWeighter_Form
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
            this.gToolStripButton1 = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.T_INTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_MAT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_PRODUCT_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_PRODUCT_SCHEDULE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_PRODUCT_CLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_PRODUCT_MAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_WEIGHT_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_POND_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_MAT_SPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_THEORETICAL_WEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_ACTUAL_WEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_MARCHINE_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_BILL_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
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
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
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
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(2);
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
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(2);
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
            this.txt_MatNo.Margin = new System.Windows.Forms.Padding(2);
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
            this.layoutControlItem3.CustomizationFormText = "材料号";
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
            this.btn_query,
            this.gToolStripButton1});
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
            // gToolStripButton1
            // 
            this.gToolStripButton1.Image = global::LTN.CS.SCMForm.Properties.Resources.ExportExcel1_32;
            this.gToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton1.Name = "gToolStripButton1";
            this.gToolStripButton1.Size = new System.Drawing.Size(60, 32);
            this.gToolStripButton1.Text = "导出";
            this.gToolStripButton1.Click += new System.EventHandler(this.gToolStripButton1_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcl_main.Location = new System.Drawing.Point(0, 91);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(2);
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
            this.T_INTID,
            this.T_MAT_NO,
            this.T_STATUS,
            this.T_PRODUCT_TIME,
            this.T_PRODUCT_SCHEDULE,
            this.T_PRODUCT_CLASS,
            this.T_PRODUCT_MAN,
            this.T_WEIGHT_TIME,
            this.T_POND_ID,
            this.T_MAT_SPEC,
            this.T_THEORETICAL_WEIGHT,
            this.T_ACTUAL_WEIGHT,
            this.T_MARCHINE_CODE,
            this.T_REMARK,
            this.T_BILL_STATUS});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // T_INTID
            // 
            this.T_INTID.Caption = "业务主键";
            this.T_INTID.FieldName = "T_INTID";
            this.T_INTID.Name = "T_INTID";
            // 
            // T_MAT_NO
            // 
            this.T_MAT_NO.Caption = "材料号";
            this.T_MAT_NO.FieldName = "T_MAT_NO";
            this.T_MAT_NO.Name = "T_MAT_NO";
            this.T_MAT_NO.Visible = true;
            this.T_MAT_NO.VisibleIndex = 1;
            this.T_MAT_NO.Width = 100;
            // 
            // T_STATUS
            // 
            this.T_STATUS.Caption = "状态";
            this.T_STATUS.FieldName = "T_STATUS";
            this.T_STATUS.Name = "T_STATUS";
            this.T_STATUS.Visible = true;
            this.T_STATUS.VisibleIndex = 0;
            this.T_STATUS.Width = 60;
            // 
            // T_PRODUCT_TIME
            // 
            this.T_PRODUCT_TIME.Caption = "生产时刻";
            this.T_PRODUCT_TIME.FieldName = "T_PRODUCT_TIME";
            this.T_PRODUCT_TIME.Name = "T_PRODUCT_TIME";
            this.T_PRODUCT_TIME.Visible = true;
            this.T_PRODUCT_TIME.VisibleIndex = 2;
            this.T_PRODUCT_TIME.Width = 100;
            // 
            // T_PRODUCT_SCHEDULE
            // 
            this.T_PRODUCT_SCHEDULE.Caption = "生产班次";
            this.T_PRODUCT_SCHEDULE.FieldName = "T_PRODUCT_SCHEDULE";
            this.T_PRODUCT_SCHEDULE.Name = "T_PRODUCT_SCHEDULE";
            this.T_PRODUCT_SCHEDULE.Visible = true;
            this.T_PRODUCT_SCHEDULE.VisibleIndex = 3;
            this.T_PRODUCT_SCHEDULE.Width = 100;
            // 
            // T_PRODUCT_CLASS
            // 
            this.T_PRODUCT_CLASS.Caption = "生产班组";
            this.T_PRODUCT_CLASS.FieldName = "T_PRODUCT_CLASS";
            this.T_PRODUCT_CLASS.Name = "T_PRODUCT_CLASS";
            this.T_PRODUCT_CLASS.Visible = true;
            this.T_PRODUCT_CLASS.VisibleIndex = 4;
            this.T_PRODUCT_CLASS.Width = 100;
            // 
            // T_PRODUCT_MAN
            // 
            this.T_PRODUCT_MAN.Caption = "生产责任者";
            this.T_PRODUCT_MAN.FieldName = "T_PRODUCT_MAN";
            this.T_PRODUCT_MAN.Name = "T_PRODUCT_MAN";
            this.T_PRODUCT_MAN.Visible = true;
            this.T_PRODUCT_MAN.VisibleIndex = 5;
            this.T_PRODUCT_MAN.Width = 100;
            // 
            // T_WEIGHT_TIME
            // 
            this.T_WEIGHT_TIME.Caption = "过磅时间";
            this.T_WEIGHT_TIME.FieldName = "T_WEIGHT_TIME";
            this.T_WEIGHT_TIME.Name = "T_WEIGHT_TIME";
            this.T_WEIGHT_TIME.Visible = true;
            this.T_WEIGHT_TIME.VisibleIndex = 7;
            this.T_WEIGHT_TIME.Width = 100;
            // 
            // T_POND_ID
            // 
            this.T_POND_ID.Caption = "磅号";
            this.T_POND_ID.FieldName = "T_POND_ID";
            this.T_POND_ID.Name = "T_POND_ID";
            this.T_POND_ID.Visible = true;
            this.T_POND_ID.VisibleIndex = 6;
            // 
            // T_MAT_SPEC
            // 
            this.T_MAT_SPEC.Caption = "材料规格";
            this.T_MAT_SPEC.FieldName = "T_MAT_SPEC";
            this.T_MAT_SPEC.Name = "T_MAT_SPEC";
            this.T_MAT_SPEC.Visible = true;
            this.T_MAT_SPEC.VisibleIndex = 8;
            this.T_MAT_SPEC.Width = 100;
            // 
            // T_THEORETICAL_WEIGHT
            // 
            this.T_THEORETICAL_WEIGHT.Caption = "理论重量(KG)";
            this.T_THEORETICAL_WEIGHT.FieldName = "T_THEORETICAL_WEIGHT";
            this.T_THEORETICAL_WEIGHT.Name = "T_THEORETICAL_WEIGHT";
            this.T_THEORETICAL_WEIGHT.Visible = true;
            this.T_THEORETICAL_WEIGHT.VisibleIndex = 9;
            this.T_THEORETICAL_WEIGHT.Width = 110;
            // 
            // T_ACTUAL_WEIGHT
            // 
            this.T_ACTUAL_WEIGHT.Caption = "实际重量";
            this.T_ACTUAL_WEIGHT.FieldName = "T_ACTUAL_WEIGHT";
            this.T_ACTUAL_WEIGHT.Name = "T_ACTUAL_WEIGHT";
            this.T_ACTUAL_WEIGHT.Visible = true;
            this.T_ACTUAL_WEIGHT.VisibleIndex = 10;
            this.T_ACTUAL_WEIGHT.Width = 100;
            // 
            // T_MARCHINE_CODE
            // 
            this.T_MARCHINE_CODE.Caption = "机组号";
            this.T_MARCHINE_CODE.FieldName = "T_MARCHINE_CODE";
            this.T_MARCHINE_CODE.Name = "T_MARCHINE_CODE";
            this.T_MARCHINE_CODE.Visible = true;
            this.T_MARCHINE_CODE.VisibleIndex = 11;
            // 
            // T_REMARK
            // 
            this.T_REMARK.Caption = "备注";
            this.T_REMARK.FieldName = "T_REMARK";
            this.T_REMARK.Name = "T_REMARK";
            this.T_REMARK.Visible = true;
            this.T_REMARK.VisibleIndex = 12;
            this.T_REMARK.Width = 100;
            // 
            // T_BILL_STATUS
            // 
            this.T_BILL_STATUS.Caption = "计量状态";
            this.T_BILL_STATUS.FieldName = "T_BILL_STATUS";
            this.T_BILL_STATUS.Name = "T_BILL_STATUS";
            this.T_BILL_STATUS.Visible = true;
            this.T_BILL_STATUS.VisibleIndex = 13;
            // 
            // PM_Bill_OrbitWeighter_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "PM_Bill_OrbitWeighter_Form";
            this.ShowIcon = false;
            this.Text = "辊道秤过磅数据管理";
            this.Shown += new System.EventHandler(this.PM_Bill_OrbitWeighter_Shown);
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Core.Helper.GToolStripButton gToolStripButton1;
        private DevExpress.XtraGrid.Columns.GridColumn T_INTID;
        private DevExpress.XtraGrid.Columns.GridColumn T_MAT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn T_STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn T_PRODUCT_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn T_PRODUCT_SCHEDULE;
        private DevExpress.XtraGrid.Columns.GridColumn T_PRODUCT_CLASS;
        private DevExpress.XtraGrid.Columns.GridColumn T_PRODUCT_MAN;
        private DevExpress.XtraGrid.Columns.GridColumn T_POND_ID;
        private DevExpress.XtraGrid.Columns.GridColumn T_MAT_SPEC;
        private DevExpress.XtraGrid.Columns.GridColumn T_THEORETICAL_WEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_ACTUAL_WEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_MARCHINE_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn T_REMARK;
        private DevExpress.XtraGrid.Columns.GridColumn T_BILL_STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn T_WEIGHT_TIME;
    }
}