namespace LTN.CS.SCMForm.PM
{
    partial class PM_OrbitWeighterConfirm_Form
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
            this.txt_CalibrateNo = new DevExpress.XtraEditors.TextEdit();
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
            this.T_BILLSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_STANDARDWEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_BEFORE_CALIBRATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_AFTER_CALIBRATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_MAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.T_CALIBRATE_MEASURESITE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalibrateNo.Properties)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.txt_CalibrateNo);
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
            // txt_CalibrateNo
            // 
            this.txt_CalibrateNo.Location = new System.Drawing.Point(507, 12);
            this.txt_CalibrateNo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalibrateNo.Name = "txt_CalibrateNo";
            this.txt_CalibrateNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CalibrateNo.Properties.Appearance.Options.UseFont = true;
            this.txt_CalibrateNo.Size = new System.Drawing.Size(138, 26);
            this.txt_CalibrateNo.StyleController = this.layoutControl1;
            this.txt_CalibrateNo.TabIndex = 3;
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
            this.layoutControlItem3.Control = this.txt_CalibrateNo;
            this.layoutControlItem3.CustomizationFormText = "校磅编号";
            this.layoutControlItem3.Location = new System.Drawing.Point(427, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(210, 32);
            this.layoutControlItem3.Text = "校磅编号";
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
            this.T_BILLSTATUS,
            this.T_CALIBRATE_NO,
            this.T_STANDARDWEIGHT,
            this.T_BEFORE_CALIBRATE,
            this.T_AFTER_CALIBRATE,
            this.T_CALIBRATE_TIME,
            this.T_CALIBRATE_MAN,
            this.T_CALIBRATE_MEASURESITE});
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
            // T_BILLSTATUS
            // 
            this.T_BILLSTATUS.Caption = "状态";
            this.T_BILLSTATUS.FieldName = "T_BILLSTATUS";
            this.T_BILLSTATUS.Name = "T_BILLSTATUS";
            this.T_BILLSTATUS.Visible = true;
            this.T_BILLSTATUS.VisibleIndex = 0;
            // 
            // T_CALIBRATE_NO
            // 
            this.T_CALIBRATE_NO.Caption = "校磅编号";
            this.T_CALIBRATE_NO.FieldName = "T_CALIBRATE_NO";
            this.T_CALIBRATE_NO.Name = "T_CALIBRATE_NO";
            this.T_CALIBRATE_NO.Visible = true;
            this.T_CALIBRATE_NO.VisibleIndex = 1;
            this.T_CALIBRATE_NO.Width = 300;
            // 
            // T_STANDARDWEIGHT
            // 
            this.T_STANDARDWEIGHT.Caption = "标准重量(KG)";
            this.T_STANDARDWEIGHT.FieldName = "T_STANDARDWEIGHT";
            this.T_STANDARDWEIGHT.Name = "T_STANDARDWEIGHT";
            this.T_STANDARDWEIGHT.Visible = true;
            this.T_STANDARDWEIGHT.VisibleIndex = 2;
            this.T_STANDARDWEIGHT.Width = 140;
            // 
            // T_BEFORE_CALIBRATE
            // 
            this.T_BEFORE_CALIBRATE.Caption = "校准前重量";
            this.T_BEFORE_CALIBRATE.FieldName = "T_BEFORE_CALIBRATE";
            this.T_BEFORE_CALIBRATE.Name = "T_BEFORE_CALIBRATE";
            this.T_BEFORE_CALIBRATE.Visible = true;
            this.T_BEFORE_CALIBRATE.VisibleIndex = 3;
            this.T_BEFORE_CALIBRATE.Width = 120;
            // 
            // T_AFTER_CALIBRATE
            // 
            this.T_AFTER_CALIBRATE.Caption = "校准后重量";
            this.T_AFTER_CALIBRATE.FieldName = "T_AFTER_CALIBRATE";
            this.T_AFTER_CALIBRATE.Name = "T_AFTER_CALIBRATE";
            this.T_AFTER_CALIBRATE.Visible = true;
            this.T_AFTER_CALIBRATE.VisibleIndex = 4;
            this.T_AFTER_CALIBRATE.Width = 120;
            // 
            // T_CALIBRATE_TIME
            // 
            this.T_CALIBRATE_TIME.Caption = "校准时间";
            this.T_CALIBRATE_TIME.FieldName = "T_CALIBRATE_TIME";
            this.T_CALIBRATE_TIME.Name = "T_CALIBRATE_TIME";
            this.T_CALIBRATE_TIME.Visible = true;
            this.T_CALIBRATE_TIME.VisibleIndex = 5;
            this.T_CALIBRATE_TIME.Width = 200;
            // 
            // T_CALIBRATE_MAN
            // 
            this.T_CALIBRATE_MAN.Caption = "校准人";
            this.T_CALIBRATE_MAN.FieldName = "T_CALIBRATE_MAN";
            this.T_CALIBRATE_MAN.Name = "T_CALIBRATE_MAN";
            this.T_CALIBRATE_MAN.Visible = true;
            this.T_CALIBRATE_MAN.VisibleIndex = 6;
            this.T_CALIBRATE_MAN.Width = 100;
            // 
            // T_CALIBRATE_MEASURESITE
            // 
            this.T_CALIBRATE_MEASURESITE.Caption = "校准计量点";
            this.T_CALIBRATE_MEASURESITE.FieldName = "T_CALIBRATE_MEASURESITE";
            this.T_CALIBRATE_MEASURESITE.Name = "T_CALIBRATE_MEASURESITE";
            this.T_CALIBRATE_MEASURESITE.Visible = true;
            this.T_CALIBRATE_MEASURESITE.VisibleIndex = 7;
            this.T_CALIBRATE_MEASURESITE.Width = 160;
            // 
            // PM_OrbitWeighterConfirm_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "PM_OrbitWeighterConfirm_Form";
            this.ShowIcon = false;
            this.Text = "辊道秤校磅数据管理";
            this.Shown += new System.EventHandler(this.PM_OrbitWeighterConfirm_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalibrateNo.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txt_CalibrateNo;
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
        private DevExpress.XtraGrid.Columns.GridColumn T_BILLSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn T_STANDARDWEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn T_BEFORE_CALIBRATE;
        private DevExpress.XtraGrid.Columns.GridColumn T_AFTER_CALIBRATE;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_MAN;
        private DevExpress.XtraGrid.Columns.GridColumn T_CALIBRATE_MEASURESITE;
    }
}