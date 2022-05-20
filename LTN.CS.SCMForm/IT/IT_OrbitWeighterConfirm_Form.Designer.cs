namespace LTN.CS.SCMForm.IT
{
    partial class IT_OrbitWeighterConfirm_Form
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
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.T_CALIBRATE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_STANDARDWEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_BEFORE_CALIBRATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_AFTER_CALIBRATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_MAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_MEASURESITE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_OPERATE_FLAG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_UPLOAD_FLAG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.calibrateNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calibrateNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Query});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 56);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(881, 37);
            this.gToolStrip1.TabIndex = 9;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Query
            // 
            this.btn_Query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.btn_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Query.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(60, 34);
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcl_main.Location = new System.Drawing.Point(0, 93);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(2);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(881, 414);
            this.gcl_main.TabIndex = 10;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.GroupRow.Options.UseFont = true;
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.T_CALIBRATE_NO,
            this.T_STANDARDWEIGHT,
            this.T_BEFORE_CALIBRATE,
            this.T_AFTER_CALIBRATE,
            this.T_CALIBRATE_TIME,
            this.T_CALIBRATE_MAN,
            this.T_CALIBRATE_MEASURESITE,
            this.T_OPERATE_FLAG,
            this.T_UPLOAD_FLAG});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // T_CALIBRATE_NO
            // 
            this.T_CALIBRATE_NO.Caption = "校磅编号";
            this.T_CALIBRATE_NO.FieldName = "T_CALIBRATE_NO";
            this.T_CALIBRATE_NO.Name = "T_CALIBRATE_NO";
            this.T_CALIBRATE_NO.Visible = true;
            this.T_CALIBRATE_NO.VisibleIndex = 0;
            this.T_CALIBRATE_NO.Width = 160;
            // 
            // T_STANDARDWEIGHT
            // 
            this.T_STANDARDWEIGHT.Caption = "标准重量(KG)";
            this.T_STANDARDWEIGHT.FieldName = "T_STANDARDWEIGHT";
            this.T_STANDARDWEIGHT.Name = "T_STANDARDWEIGHT";
            this.T_STANDARDWEIGHT.Visible = true;
            this.T_STANDARDWEIGHT.VisibleIndex = 1;
            this.T_STANDARDWEIGHT.Width = 120;
            // 
            // T_BEFORE_CALIBRATE
            // 
            this.T_BEFORE_CALIBRATE.Caption = "校准前重量";
            this.T_BEFORE_CALIBRATE.FieldName = "T_BEFORE_CALIBRATE";
            this.T_BEFORE_CALIBRATE.Name = "T_BEFORE_CALIBRATE";
            this.T_BEFORE_CALIBRATE.Visible = true;
            this.T_BEFORE_CALIBRATE.VisibleIndex = 2;
            this.T_BEFORE_CALIBRATE.Width = 100;
            // 
            // T_AFTER_CALIBRATE
            // 
            this.T_AFTER_CALIBRATE.Caption = "校准后重量";
            this.T_AFTER_CALIBRATE.FieldName = "T_AFTER_CALIBRATE";
            this.T_AFTER_CALIBRATE.Name = "T_AFTER_CALIBRATE";
            this.T_AFTER_CALIBRATE.Visible = true;
            this.T_AFTER_CALIBRATE.VisibleIndex = 3;
            this.T_AFTER_CALIBRATE.Width = 100;
            // 
            // T_CALIBRATE_TIME
            // 
            this.T_CALIBRATE_TIME.Caption = "校准时间";
            this.T_CALIBRATE_TIME.FieldName = "T_CALIBRATE_TIME";
            this.T_CALIBRATE_TIME.Name = "T_CALIBRATE_TIME";
            this.T_CALIBRATE_TIME.Visible = true;
            this.T_CALIBRATE_TIME.VisibleIndex = 4;
            this.T_CALIBRATE_TIME.Width = 160;
            // 
            // T_CALIBRATE_MAN
            // 
            this.T_CALIBRATE_MAN.Caption = "校准人员";
            this.T_CALIBRATE_MAN.FieldName = "T_CALIBRATE_MAN";
            this.T_CALIBRATE_MAN.Name = "T_CALIBRATE_MAN";
            this.T_CALIBRATE_MAN.Visible = true;
            this.T_CALIBRATE_MAN.VisibleIndex = 5;
            this.T_CALIBRATE_MAN.Width = 100;
            // 
            // T_CALIBRATE_MEASURESITE
            // 
            this.T_CALIBRATE_MEASURESITE.Caption = "校准计量点";
            this.T_CALIBRATE_MEASURESITE.FieldName = "T_CALIBRATE_MEASURESITE";
            this.T_CALIBRATE_MEASURESITE.Name = "T_CALIBRATE_MEASURESITE";
            this.T_CALIBRATE_MEASURESITE.Visible = true;
            this.T_CALIBRATE_MEASURESITE.VisibleIndex = 6;
            this.T_CALIBRATE_MEASURESITE.Width = 100;
            // 
            // T_OPERATE_FLAG
            // 
            this.T_OPERATE_FLAG.Caption = "操作标识";
            this.T_OPERATE_FLAG.FieldName = "T_OPERATE_FLAG";
            this.T_OPERATE_FLAG.Name = "T_OPERATE_FLAG";
            this.T_OPERATE_FLAG.Visible = true;
            this.T_OPERATE_FLAG.VisibleIndex = 7;
            this.T_OPERATE_FLAG.Width = 80;
            // 
            // T_UPLOAD_FLAG
            // 
            this.T_UPLOAD_FLAG.Caption = "接收状态";
            this.T_UPLOAD_FLAG.FieldName = "T_UPLOAD_FLAG";
            this.T_UPLOAD_FLAG.Name = "T_UPLOAD_FLAG";
            this.T_UPLOAD_FLAG.Visible = true;
            this.T_UPLOAD_FLAG.VisibleIndex = 8;
            this.T_UPLOAD_FLAG.Width = 80;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(881, 56);
            this.panelControl1.TabIndex = 11;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.calibrateNo);
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
            this.date_EndTime.Location = new System.Drawing.Point(271, 12);
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
            this.date_EndTime.Size = new System.Drawing.Size(120, 26);
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
            this.date_StartTime.Size = new System.Drawing.Size(119, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 0;
            // 
            // calibrateNo
            // 
            this.calibrateNo.Location = new System.Drawing.Point(463, 12);
            this.calibrateNo.Margin = new System.Windows.Forms.Padding(2);
            this.calibrateNo.Name = "calibrateNo";
            this.calibrateNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.calibrateNo.Properties.Appearance.Options.UseFont = true;
            this.calibrateNo.Size = new System.Drawing.Size(136, 26);
            this.calibrateNo.StyleController = this.layoutControl1;
            this.calibrateNo.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(877, 52);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            this.LayoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LayoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.LayoutControlItem6.Control = this.calibrateNo;
            this.LayoutControlItem6.CustomizationFormText = "校磅编号";
            this.LayoutControlItem6.Location = new System.Drawing.Point(383, 0);
            this.LayoutControlItem6.Name = "LayoutControlItem6";
            this.LayoutControlItem6.Size = new System.Drawing.Size(208, 32);
            this.LayoutControlItem6.Text = "校磅编号";
            this.LayoutControlItem6.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_StartTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(191, 32);
            this.layoutControlItem4.Text = "开始时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.date_EndTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(191, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(192, 32);
            this.layoutControlItem5.Text = "结束时间";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(591, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(266, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.calibrateNo;
            this.layoutControlItem3.CustomizationFormText = "校磅编号";
            this.layoutControlItem3.Location = new System.Drawing.Point(383, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(208, 32);
            this.layoutControlItem3.Text = "校磅编号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // IT_OrbitWeighterConfirm_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IT_OrbitWeighterConfirm_Form";
            this.ShowIcon = false;
            this.Text = "辊道秤校磅数据接口查询";
            this.Shown += new System.EventHandler(this.IT_OrbitWeighterConfirm_Form_Shown);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calibrateNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Core.Helper.GToolStrip gToolStrip1;
        //private Core.Helper.GToolStripButton btn_Export;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn T_STANDARDWEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_BEFORE_CALIBRATE;
        private DevExpress.XtraGrid.Columns.GridColumn T_AFTER_CALIBRATE;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_MAN;
        private DevExpress.XtraGrid.Columns.GridColumn T_OPERATE_FLAG;
        private DevExpress.XtraGrid.Columns.GridColumn T_UPLOAD_FLAG;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.TextEdit calibrateNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Core.Helper.GToolStripButton btn_Query;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_MEASURESITE;
    }
}