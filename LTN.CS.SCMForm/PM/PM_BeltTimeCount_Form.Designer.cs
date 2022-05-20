namespace LTN.CS.SCMForm.PM
{
    partial class PM_BeltTimeCount_Form
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
            this.de_endtime = new DevExpress.XtraEditors.DateEdit();
            this.de_starttime = new DevExpress.XtraEditors.DateEdit();
            this.txt_beltNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.皮带编号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_export = new LTN.CS.Core.Helper.GToolStripButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_beltno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_beltInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_BeltTimeTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_planTimeTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_countAbsoluteValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_beltNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.皮带编号)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(954, 64);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.de_endtime);
            this.layoutControl1.Controls.Add(this.de_starttime);
            this.layoutControl1.Controls.Add(this.txt_beltNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(950, 60);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // de_endtime
            // 
            this.de_endtime.EditValue = null;
            this.de_endtime.Location = new System.Drawing.Point(373, 12);
            this.de_endtime.Name = "de_endtime";
            this.de_endtime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_endtime.Properties.Appearance.Options.UseFont = true;
            this.de_endtime.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_endtime.Properties.AppearanceFocused.Options.UseFont = true;
            this.de_endtime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_endtime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_endtime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_endtime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_endtime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_endtime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_endtime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.de_endtime.Size = new System.Drawing.Size(223, 26);
            this.de_endtime.StyleController = this.layoutControl1;
            this.de_endtime.TabIndex = 3;
            // 
            // de_starttime
            // 
            this.de_starttime.EditValue = null;
            this.de_starttime.Location = new System.Drawing.Point(79, 12);
            this.de_starttime.Name = "de_starttime";
            this.de_starttime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_starttime.Properties.Appearance.Options.UseFont = true;
            this.de_starttime.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_starttime.Properties.AppearanceFocused.Options.UseFont = true;
            this.de_starttime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_starttime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_starttime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_starttime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_starttime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Size = new System.Drawing.Size(223, 26);
            this.de_starttime.StyleController = this.layoutControl1;
            this.de_starttime.TabIndex = 2;
            // 
            // txt_beltNo
            // 
            this.txt_beltNo.Location = new System.Drawing.Point(667, 12);
            this.txt_beltNo.Name = "txt_beltNo";
            this.txt_beltNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_beltNo.Properties.Appearance.Options.UseFont = true;
            this.txt_beltNo.Size = new System.Drawing.Size(271, 26);
            this.txt_beltNo.StyleController = this.layoutControl1;
            this.txt_beltNo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.皮带编号});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(950, 60);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.de_starttime;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(294, 40);
            this.layoutControlItem1.Text = "开始时间";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.de_endtime;
            this.layoutControlItem2.Location = new System.Drawing.Point(294, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(294, 40);
            this.layoutControlItem2.Text = "结束时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // 皮带编号
            // 
            this.皮带编号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.皮带编号.AppearanceItemCaption.Options.UseFont = true;
            this.皮带编号.Control = this.txt_beltNo;
            this.皮带编号.Location = new System.Drawing.Point(588, 0);
            this.皮带编号.Name = "皮带编号";
            this.皮带编号.Size = new System.Drawing.Size(342, 40);
            this.皮带编号.TextSize = new System.Drawing.Size(64, 19);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query,
            this.btn_export});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 64);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(954, 42);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_query
            // 
            this.btn_query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(60, 39);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_export
            // 
            this.btn_export.Image = global::LTN.CS.SCMForm.Properties.Resources.Excel_32;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(60, 39);
            this.btn_export.Text = "导出";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Green;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Green;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Green;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Green;
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_beltno,
            this.c_beltInfo,
            this.c_BeltTimeTotalCount,
            this.c_planTimeTotalCount,
            this.c_countAbsoluteValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "皮带秤运行时长统计";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // c_beltno
            // 
            this.c_beltno.Caption = "皮带编号";
            this.c_beltno.FieldName = "c_beltno";
            this.c_beltno.Name = "c_beltno";
            this.c_beltno.Visible = true;
            this.c_beltno.VisibleIndex = 0;
            this.c_beltno.Width = 120;
            // 
            // c_beltInfo
            // 
            this.c_beltInfo.Caption = "皮带位号信息";
            this.c_beltInfo.FieldName = "c_beltInfo";
            this.c_beltInfo.Name = "c_beltInfo";
            this.c_beltInfo.Visible = true;
            this.c_beltInfo.VisibleIndex = 1;
            // 
            // c_BeltTimeTotalCount
            // 
            this.c_BeltTimeTotalCount.Caption = "运行时长";
            this.c_BeltTimeTotalCount.FieldName = "c_beltTimeTotalCount";
            this.c_BeltTimeTotalCount.Name = "c_BeltTimeTotalCount";
            this.c_BeltTimeTotalCount.Visible = true;
            this.c_BeltTimeTotalCount.VisibleIndex = 2;
            // 
            // c_planTimeTotalCount
            // 
            this.c_planTimeTotalCount.Caption = "委托时长";
            this.c_planTimeTotalCount.FieldName = "c_planTimeTotalCount";
            this.c_planTimeTotalCount.Name = "c_planTimeTotalCount";
            this.c_planTimeTotalCount.Visible = true;
            this.c_planTimeTotalCount.VisibleIndex = 3;
            // 
            // c_countAbsoluteValue
            // 
            this.c_countAbsoluteValue.Caption = "差值";
            this.c_countAbsoluteValue.FieldName = "c_countAbsoluteValue";
            this.c_countAbsoluteValue.Name = "c_countAbsoluteValue";
            this.c_countAbsoluteValue.Visible = true;
            this.c_countAbsoluteValue.VisibleIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 106);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(954, 583);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // PM_BeltTimeCount_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 689);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Name = "PM_BeltTimeCount_Form";
            this.Text = "皮带秤运行时长统计页面";
            this.Shown += new System.EventHandler(this.PM_BeltTimeCount_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_beltNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.皮带编号)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit de_endtime;
        private DevExpress.XtraEditors.DateEdit de_starttime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_query;
        private Core.Helper.GToolStripButton btn_export;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn c_beltno;
        private DevExpress.XtraGrid.Columns.GridColumn c_beltInfo;
        private DevExpress.XtraGrid.Columns.GridColumn c_BeltTimeTotalCount;
        private DevExpress.XtraGrid.Columns.GridColumn c_planTimeTotalCount;
        private DevExpress.XtraGrid.Columns.GridColumn c_countAbsoluteValue;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.TextEdit txt_beltNo;
        private DevExpress.XtraLayout.LayoutControlItem 皮带编号;
    }
}