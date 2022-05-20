namespace LTN.CS.SCMForm.IT
{
    partial class IT_OrbitWeighterConfirm_Form_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IT_OrbitWeighterConfirm_Form_New));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.calibrateNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.gToolStripButton1 = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStripButton2 = new LTN.CS.Core.Helper.GToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.calibrate_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.standardWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.beforeCalibrate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.after_calibrate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calibrate_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calibrate_man = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operate_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrateNo.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(879, 59);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.calibrateNo);
            this.groupBox3.Controls.Add(this.labelControl3);
            this.groupBox3.Location = new System.Drawing.Point(553, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 45);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // calibrateNo
            // 
            this.calibrateNo.Location = new System.Drawing.Point(84, 14);
            this.calibrateNo.Name = "calibrateNo";
            this.calibrateNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.calibrateNo.Properties.Appearance.Options.UseFont = true;
            this.calibrateNo.Size = new System.Drawing.Size(181, 24);
            this.calibrateNo.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(6, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 22);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "校磅编号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.date_EndTime);
            this.groupBox2.Location = new System.Drawing.Point(282, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 45);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 22);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "结束时间";
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(84, 14);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(181, 24);
            this.date_EndTime.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_StartTime);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(84, 14);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.Mask.BeepOnError = true;
            this.date_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(181, 24);
            this.date_StartTime.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "开始时间";
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gToolStripButton1,
            this.gToolStripButton2});
            this.gToolStrip1.Location = new System.Drawing.Point(1, 63);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(879, 39);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // gToolStripButton1
            // 
            this.gToolStripButton1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("gToolStripButton1.Image")));
            this.gToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton1.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.gToolStripButton1.Name = "gToolStripButton1";
            this.gToolStripButton1.Size = new System.Drawing.Size(66, 36);
            this.gToolStripButton1.Text = "查询";
            this.gToolStripButton1.Click += new System.EventHandler(this.gToolStripButton1_Click);
            // 
            // gToolStripButton2
            // 
            this.gToolStripButton2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("gToolStripButton2.Image")));
            this.gToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton2.Name = "gToolStripButton2";
            this.gToolStripButton2.Size = new System.Drawing.Size(66, 36);
            this.gToolStripButton2.Text = "导出";
            this.gToolStripButton2.Click += new System.EventHandler(this.gToolStripButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridControl1.Location = new System.Drawing.Point(1, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(879, 303);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.calibrate_no,
            this.standardWeight,
            this.beforeCalibrate,
            this.after_calibrate,
            this.calibrate_time,
            this.calibrate_man,
            this.operate_flag});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // calibrate_no
            // 
            this.calibrate_no.Caption = "校磅编号";
            this.calibrate_no.FieldName = "T_CALIBRATE_NO";
            this.calibrate_no.Name = "calibrate_no";
            this.calibrate_no.Visible = true;
            this.calibrate_no.VisibleIndex = 0;
            // 
            // standardWeight
            // 
            this.standardWeight.Caption = "标准重量";
            this.standardWeight.FieldName = "T_STANDARDWeight";
            this.standardWeight.Name = "standardWeight";
            this.standardWeight.Visible = true;
            this.standardWeight.VisibleIndex = 1;
            // 
            // beforeCalibrate
            // 
            this.beforeCalibrate.Caption = "校准前重量";
            this.beforeCalibrate.FieldName = "T_BEFORE_CALIBRATE";
            this.beforeCalibrate.Name = "beforeCalibrate";
            this.beforeCalibrate.Visible = true;
            this.beforeCalibrate.VisibleIndex = 2;
            // 
            // after_calibrate
            // 
            this.after_calibrate.Caption = "校准后重量";
            this.after_calibrate.FieldName = "T_AFTER_CALIBRATE";
            this.after_calibrate.Name = "after_calibrate";
            this.after_calibrate.Visible = true;
            this.after_calibrate.VisibleIndex = 3;
            // 
            // calibrate_time
            // 
            this.calibrate_time.Caption = "校准时间";
            this.calibrate_time.FieldName = "T_CALIBRATE_TIME";
            this.calibrate_time.Name = "calibrate_time";
            this.calibrate_time.Visible = true;
            this.calibrate_time.VisibleIndex = 4;
            // 
            // calibrate_man
            // 
            this.calibrate_man.Caption = "校准人员";
            this.calibrate_man.FieldName = "T_CALIBRATE_MAN";
            this.calibrate_man.Name = "calibrate_man";
            this.calibrate_man.Visible = true;
            this.calibrate_man.VisibleIndex = 5;
            // 
            // operate_flag
            // 
            this.operate_flag.Caption = "操作标志";
            this.operate_flag.FieldName = "T_OPERATE_FLAG";
            this.operate_flag.Name = "operate_flag";
            this.operate_flag.Visible = true;
            this.operate_flag.VisibleIndex = 6;
            // 
            // IT_OrbitWeighterConfirm_Form_New
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IT_OrbitWeighterConfirm_Form_New";
            this.Text = "辊道秤校磅数据接口查询";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrateNo.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton gToolStripButton1;
        private Core.Helper.GToolStripButton gToolStripButton2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn calibrate_no;
        private DevExpress.XtraGrid.Columns.GridColumn standardWeight;
        private DevExpress.XtraGrid.Columns.GridColumn beforeCalibrate;
        private DevExpress.XtraGrid.Columns.GridColumn after_calibrate;
        private DevExpress.XtraGrid.Columns.GridColumn calibrate_time;
        private DevExpress.XtraGrid.Columns.GridColumn calibrate_man;
        private DevExpress.XtraGrid.Columns.GridColumn operate_flag;
        private DevExpress.XtraEditors.TextEdit calibrateNo;


    }
}