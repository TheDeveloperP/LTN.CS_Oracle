namespace LTN.CS.SCMForm.PM
{
    partial class PM_ImportBill_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_CarNo = new DevExpress.XtraEditors.TextEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gCtrl_ImportBill = new DevExpress.XtraGrid.GridControl();
            this.gView_ImportBill = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_C_CarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_GrossWgtTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_TareWgtTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_MaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_GrossWgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_TareWgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_NetWgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_FromDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_ToDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_NetWgtMan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_GrossWgtSite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_QueryData = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_ImportData = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_PrintData = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStripButton1 = new LTN.CS.Core.Helper.GToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_ImportBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_ImportBill)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 57);
            this.panel1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_CarNo);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(881, 57);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CarNo
            // 
            this.txt_CarNo.Location = new System.Drawing.Point(79, 12);
            this.txt_CarNo.Name = "txt_CarNo";
            this.txt_CarNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarNo.Properties.Appearance.Options.UseFont = true;
            this.txt_CarNo.Size = new System.Drawing.Size(68, 26);
            this.txt_CarNo.StyleController = this.layoutControl1;
            this.txt_CarNo.TabIndex = 0;
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(218, 12);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.date_StartTime.Size = new System.Drawing.Size(117, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 2;
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(406, 12);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.date_EndTime.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(881, 57);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_CarNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(139, 37);
            this.layoutControlItem1.Text = "车号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.date_StartTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(139, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(188, 37);
            this.layoutControlItem2.Text = "开始时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.date_EndTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(327, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(191, 37);
            this.layoutControlItem3.Text = "结束时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(518, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(343, 37);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gCtrl_ImportBill
            // 
            this.gCtrl_ImportBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_ImportBill.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gCtrl_ImportBill.Location = new System.Drawing.Point(0, 86);
            this.gCtrl_ImportBill.MainView = this.gView_ImportBill;
            this.gCtrl_ImportBill.Margin = new System.Windows.Forms.Padding(2);
            this.gCtrl_ImportBill.Name = "gCtrl_ImportBill";
            this.gCtrl_ImportBill.Size = new System.Drawing.Size(881, 421);
            this.gCtrl_ImportBill.TabIndex = 0;
            this.gCtrl_ImportBill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_ImportBill});
            // 
            // gView_ImportBill
            // 
            this.gView_ImportBill.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gView_ImportBill.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_ImportBill.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gView_ImportBill.Appearance.Row.Options.UseFont = true;
            this.gView_ImportBill.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_C_CarNo,
            this.gCol_C_GrossWgtTime,
            this.gCol_C_TareWgtTime,
            this.gCol_C_MaterialName,
            this.gCol_N_GrossWgt,
            this.gCol_N_TareWgt,
            this.gCol_N_NetWgt,
            this.gCol_C_FromDeptName,
            this.gCol_C_ToDeptName,
            this.gCol_C_NetWgtMan,
            this.gCol_C_GrossWgtSite,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gView_ImportBill.GridControl = this.gCtrl_ImportBill;
            this.gView_ImportBill.Name = "gView_ImportBill";
            this.gView_ImportBill.OptionsBehavior.Editable = false;
            this.gView_ImportBill.OptionsView.ColumnAutoWidth = false;
            this.gView_ImportBill.OptionsView.ShowFooter = true;
            this.gView_ImportBill.OptionsView.ShowGroupPanel = false;
            this.gView_ImportBill.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gView_ImportBill_CustomDrawCell);
            this.gView_ImportBill.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gView_ImportBill_FocusedRowChanged);
            // 
            // gCol_C_CarNo
            // 
            this.gCol_C_CarNo.Caption = "车号";
            this.gCol_C_CarNo.FieldName = "C_CarNo";
            this.gCol_C_CarNo.Name = "gCol_C_CarNo";
            this.gCol_C_CarNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "C_CarNo", "共{0}条")});
            this.gCol_C_CarNo.Visible = true;
            this.gCol_C_CarNo.VisibleIndex = 1;
            this.gCol_C_CarNo.Width = 100;
            // 
            // gCol_C_GrossWgtTime
            // 
            this.gCol_C_GrossWgtTime.Caption = "毛重时间";
            this.gCol_C_GrossWgtTime.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.gCol_C_GrossWgtTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gCol_C_GrossWgtTime.FieldName = "C_GrossWgtTime";
            this.gCol_C_GrossWgtTime.Name = "gCol_C_GrossWgtTime";
            this.gCol_C_GrossWgtTime.Visible = true;
            this.gCol_C_GrossWgtTime.VisibleIndex = 2;
            this.gCol_C_GrossWgtTime.Width = 175;
            // 
            // gCol_C_TareWgtTime
            // 
            this.gCol_C_TareWgtTime.Caption = "皮重时间";
            this.gCol_C_TareWgtTime.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.gCol_C_TareWgtTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gCol_C_TareWgtTime.FieldName = "C_TareWgtTime";
            this.gCol_C_TareWgtTime.Name = "gCol_C_TareWgtTime";
            this.gCol_C_TareWgtTime.Visible = true;
            this.gCol_C_TareWgtTime.VisibleIndex = 3;
            this.gCol_C_TareWgtTime.Width = 175;
            // 
            // gCol_C_MaterialName
            // 
            this.gCol_C_MaterialName.Caption = "品名";
            this.gCol_C_MaterialName.FieldName = "C_MaterialName";
            this.gCol_C_MaterialName.Name = "gCol_C_MaterialName";
            this.gCol_C_MaterialName.Visible = true;
            this.gCol_C_MaterialName.VisibleIndex = 4;
            this.gCol_C_MaterialName.Width = 100;
            // 
            // gCol_N_GrossWgt
            // 
            this.gCol_N_GrossWgt.Caption = "毛重";
            this.gCol_N_GrossWgt.FieldName = "N_GrossWgt";
            this.gCol_N_GrossWgt.Name = "gCol_N_GrossWgt";
            this.gCol_N_GrossWgt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "N_GrossWgt", "{0:0.##}")});
            this.gCol_N_GrossWgt.Visible = true;
            this.gCol_N_GrossWgt.VisibleIndex = 5;
            // 
            // gCol_N_TareWgt
            // 
            this.gCol_N_TareWgt.Caption = "皮重";
            this.gCol_N_TareWgt.FieldName = "N_TareWgt";
            this.gCol_N_TareWgt.Name = "gCol_N_TareWgt";
            this.gCol_N_TareWgt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "N_TareWgt", "{0:0.##}")});
            this.gCol_N_TareWgt.Visible = true;
            this.gCol_N_TareWgt.VisibleIndex = 6;
            // 
            // gCol_N_NetWgt
            // 
            this.gCol_N_NetWgt.Caption = "净重";
            this.gCol_N_NetWgt.FieldName = "N_NetWgt";
            this.gCol_N_NetWgt.Name = "gCol_N_NetWgt";
            this.gCol_N_NetWgt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "N_NetWgt", "{0:0.##}")});
            this.gCol_N_NetWgt.Visible = true;
            this.gCol_N_NetWgt.VisibleIndex = 7;
            // 
            // gCol_C_FromDeptName
            // 
            this.gCol_C_FromDeptName.Caption = "供货单位";
            this.gCol_C_FromDeptName.FieldName = "C_FromDeptName";
            this.gCol_C_FromDeptName.Name = "gCol_C_FromDeptName";
            this.gCol_C_FromDeptName.Visible = true;
            this.gCol_C_FromDeptName.VisibleIndex = 9;
            this.gCol_C_FromDeptName.Width = 150;
            // 
            // gCol_C_ToDeptName
            // 
            this.gCol_C_ToDeptName.Caption = "收货单位";
            this.gCol_C_ToDeptName.FieldName = "C_ToDeptName";
            this.gCol_C_ToDeptName.Name = "gCol_C_ToDeptName";
            this.gCol_C_ToDeptName.Visible = true;
            this.gCol_C_ToDeptName.VisibleIndex = 10;
            this.gCol_C_ToDeptName.Width = 150;
            // 
            // gCol_C_NetWgtMan
            // 
            this.gCol_C_NetWgtMan.Caption = "司磅员";
            this.gCol_C_NetWgtMan.FieldName = "C_NetWgtMan";
            this.gCol_C_NetWgtMan.Name = "gCol_C_NetWgtMan";
            this.gCol_C_NetWgtMan.Visible = true;
            this.gCol_C_NetWgtMan.VisibleIndex = 11;
            // 
            // gCol_C_GrossWgtSite
            // 
            this.gCol_C_GrossWgtSite.Caption = "毛重站点";
            this.gCol_C_GrossWgtSite.FieldName = "C_GrossWgtSite";
            this.gCol_C_GrossWgtSite.Name = "gCol_C_GrossWgtSite";
            this.gCol_C_GrossWgtSite.Visible = true;
            this.gCol_C_GrossWgtSite.VisibleIndex = 12;
            this.gCol_C_GrossWgtSite.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "打印次数";
            this.gridColumn1.FieldName = "I_PrintNum";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "磅单号";
            this.gridColumn2.FieldName = "C_PondNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 122;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "备注";
            this.gridColumn3.FieldName = "C_Remark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 13;
            this.gridColumn3.Width = 156;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_QueryData,
            this.btn_ImportData,
            this.btn_PrintData,
            this.gToolStripButton1});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 57);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(881, 29);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_QueryData
            // 
            this.btn_QueryData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QueryData.Image = global::LTN.CS.SCMForm.Properties.Resources.Query1_32;
            this.btn_QueryData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_QueryData.Name = "btn_QueryData";
            this.btn_QueryData.Size = new System.Drawing.Size(69, 26);
            this.btn_QueryData.Text = "查询";
            this.btn_QueryData.Click += new System.EventHandler(this.btn_QueryData_Click);
            // 
            // btn_ImportData
            // 
            this.btn_ImportData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ImportData.Image = global::LTN.CS.SCMForm.Properties.Resources.Excel_32;
            this.btn_ImportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ImportData.Name = "btn_ImportData";
            this.btn_ImportData.Size = new System.Drawing.Size(69, 26);
            this.btn_ImportData.Text = "导入";
            this.btn_ImportData.Click += new System.EventHandler(this.btn_ImportData_Click);
            // 
            // btn_PrintData
            // 
            this.btn_PrintData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PrintData.Image = global::LTN.CS.SCMForm.Properties.Resources.Print_16;
            this.btn_PrintData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PrintData.Name = "btn_PrintData";
            this.btn_PrintData.Size = new System.Drawing.Size(69, 26);
            this.btn_PrintData.Text = "针打";
            this.btn_PrintData.Click += new System.EventHandler(this.btn_PrintData_Click);
            // 
            // gToolStripButton1
            // 
            this.gToolStripButton1.Image = global::LTN.CS.SCMForm.Properties.Resources.Sheet10_32;
            this.gToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton1.Name = "gToolStripButton1";
            this.gToolStripButton1.Size = new System.Drawing.Size(134, 26);
            this.gToolStripButton1.Text = "临时磅单纸针对";
            this.gToolStripButton1.Click += new System.EventHandler(this.gToolStripButton1_Click);
            // 
            // PM_ImportBill_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.gCtrl_ImportBill);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "PM_ImportBill_Form";
            this.Text = "北二数据导入";
            this.Load += new System.EventHandler(this.PM_ImportBill_Form_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_ImportBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_ImportBill)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt_CarNo;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl gCtrl_ImportBill;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_ImportBill;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CarNo;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_GrossWgtTime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_TareWgtTime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_GrossWgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_TareWgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_NetWgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_FromDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_ToDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_NetWgtMan;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_GrossWgtSite;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_QueryData;
        private Core.Helper.GToolStripButton btn_ImportData;
        private Core.Helper.GToolStripButton btn_PrintData;
        private Core.Helper.GToolStripButton gToolStripButton1;
    }
}