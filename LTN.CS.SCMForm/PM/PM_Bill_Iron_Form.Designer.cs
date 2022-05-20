namespace LTN.CS.SCMForm.PM
{
    partial class PM_Bill_Iron_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM_Bill_Iron_Form));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dte_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.dte_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.lue_BillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_TankNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_HeatNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_PlanNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.委托单号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.铁水罐号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.计量状态 = new DevExpress.XtraLayout.LayoutControlItem();
            this.炉号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Invalid = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dte_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_BillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TankNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_HeatNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁水罐号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.计量状态)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉号)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dte_EndTime);
            this.layoutControl1.Controls.Add(this.dte_StartTime);
            this.layoutControl1.Controls.Add(this.lue_BillStatus);
            this.layoutControl1.Controls.Add(this.txt_TankNo);
            this.layoutControl1.Controls.Add(this.txt_HeatNo);
            this.layoutControl1.Controls.Add(this.txt_PlanNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(56, 157, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(912, 77);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dte_EndTime
            // 
            this.dte_EndTime.EditValue = null;
            this.dte_EndTime.Location = new System.Drawing.Point(655, 44);
            this.dte_EndTime.Name = "dte_EndTime";
            this.dte_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dte_EndTime.Properties.Appearance.Options.UseFont = true;
            this.dte_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_EndTime.Properties.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.dte_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dte_EndTime.Properties.EditFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.dte_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dte_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dte_EndTime.Size = new System.Drawing.Size(228, 28);
            this.dte_EndTime.StyleController = this.layoutControl1;
            this.dte_EndTime.TabIndex = 13;
            // 
            // dte_StartTime
            // 
            this.dte_StartTime.EditValue = null;
            this.dte_StartTime.Location = new System.Drawing.Point(349, 44);
            this.dte_StartTime.Name = "dte_StartTime";
            this.dte_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dte_StartTime.Properties.Appearance.Options.UseFont = true;
            this.dte_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_StartTime.Properties.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.dte_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dte_StartTime.Properties.EditFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.dte_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dte_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dte_StartTime.Size = new System.Drawing.Size(227, 28);
            this.dte_StartTime.StyleController = this.layoutControl1;
            this.dte_StartTime.TabIndex = 12;
            // 
            // lue_BillStatus
            // 
            this.lue_BillStatus.Location = new System.Drawing.Point(87, 44);
            this.lue_BillStatus.Name = "lue_BillStatus";
            this.lue_BillStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lue_BillStatus.Properties.Appearance.Options.UseFont = true;
            this.lue_BillStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_BillStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntValue", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BillStatusDesc", "计量状态")});
            this.lue_BillStatus.Properties.DisplayMember = "BillStatusDesc";
            this.lue_BillStatus.Properties.NullText = "";
            this.lue_BillStatus.Properties.ValueMember = "IntValue";
            this.lue_BillStatus.Size = new System.Drawing.Size(183, 28);
            this.lue_BillStatus.StyleController = this.layoutControl1;
            this.lue_BillStatus.TabIndex = 11;
            // 
            // txt_TankNo
            // 
            this.txt_TankNo.Location = new System.Drawing.Point(655, 12);
            this.txt_TankNo.Name = "txt_TankNo";
            this.txt_TankNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_TankNo.Properties.Appearance.Options.UseFont = true;
            this.txt_TankNo.Size = new System.Drawing.Size(228, 28);
            this.txt_TankNo.StyleController = this.layoutControl1;
            this.txt_TankNo.TabIndex = 7;
            // 
            // txt_HeatNo
            // 
            this.txt_HeatNo.Location = new System.Drawing.Point(349, 12);
            this.txt_HeatNo.Name = "txt_HeatNo";
            this.txt_HeatNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_HeatNo.Properties.Appearance.Options.UseFont = true;
            this.txt_HeatNo.Size = new System.Drawing.Size(227, 28);
            this.txt_HeatNo.StyleController = this.layoutControl1;
            this.txt_HeatNo.TabIndex = 6;
            // 
            // txt_PlanNo
            // 
            this.txt_PlanNo.Location = new System.Drawing.Point(87, 12);
            this.txt_PlanNo.Name = "txt_PlanNo";
            this.txt_PlanNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_PlanNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PlanNo.Size = new System.Drawing.Size(183, 28);
            this.txt_PlanNo.StyleController = this.layoutControl1;
            this.txt_PlanNo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.委托单号,
            this.layoutControlItem2,
            this.铁水罐号,
            this.layoutControlItem1,
            this.计量状态,
            this.炉号});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(895, 84);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // 委托单号
            // 
            this.委托单号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.委托单号.AppearanceItemCaption.Options.UseFont = true;
            this.委托单号.Control = this.txt_PlanNo;
            this.委托单号.Location = new System.Drawing.Point(0, 0);
            this.委托单号.Name = "委托单号";
            this.委托单号.Size = new System.Drawing.Size(262, 32);
            this.委托单号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dte_EndTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(568, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(307, 32);
            this.layoutControlItem2.Text = "结束时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 铁水罐号
            // 
            this.铁水罐号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.铁水罐号.AppearanceItemCaption.Options.UseFont = true;
            this.铁水罐号.Control = this.txt_TankNo;
            this.铁水罐号.Location = new System.Drawing.Point(568, 0);
            this.铁水罐号.Name = "铁水罐号";
            this.铁水罐号.Size = new System.Drawing.Size(307, 32);
            this.铁水罐号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.dte_StartTime;
            this.layoutControlItem1.Location = new System.Drawing.Point(262, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(306, 32);
            this.layoutControlItem1.Text = "开始时间";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 计量状态
            // 
            this.计量状态.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.计量状态.AppearanceItemCaption.Options.UseFont = true;
            this.计量状态.Control = this.lue_BillStatus;
            this.计量状态.Location = new System.Drawing.Point(0, 32);
            this.计量状态.Name = "计量状态";
            this.计量状态.Size = new System.Drawing.Size(262, 32);
            this.计量状态.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 炉号
            // 
            this.炉号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.炉号.AppearanceItemCaption.Options.UseFont = true;
            this.炉号.Control = this.txt_HeatNo;
            this.炉号.Location = new System.Drawing.Point(262, 0);
            this.炉号.Name = "炉号";
            this.炉号.Size = new System.Drawing.Size(306, 32);
            this.炉号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query,
            this.btn_Add,
            this.btn_update,
            this.btn_Invalid});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 77);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(912, 35);
            this.gToolStrip1.TabIndex = 3;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_query.Image = ((System.Drawing.Image)(resources.GetObject("btn_query.Image")));
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(80, 32);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 32);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(80, 32);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Invalid
            // 
            this.btn_Invalid.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Invalid.Image = ((System.Drawing.Image)(resources.GetObject("btn_Invalid.Image")));
            this.btn_Invalid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Invalid.Name = "btn_Invalid";
            this.btn_Invalid.Size = new System.Drawing.Size(80, 32);
            this.btn_Invalid.Text = "作废";
            this.btn_Invalid.Click += new System.EventHandler(this.btn_Invalid_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.Location = new System.Drawing.Point(0, 112);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(912, 471);
            this.gcl_main.TabIndex = 4;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvw_main.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            this.gvw_main.DoubleClick += new System.EventHandler(this.gvw_main_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "委托单号";
            this.gridColumn1.FieldName = "PlanNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "炉号";
            this.gridColumn2.FieldName = "HeatNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 51;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "炉批号";
            this.gridColumn3.FieldName = "BatchNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 64;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "铁次号";
            this.gridColumn4.FieldName = "LronNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 73;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "铁水罐号";
            this.gridColumn5.FieldName = "TankNo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "去向单位";
            this.gridColumn6.FieldName = "ToDeptName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 81;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "计量状态";
            this.gridColumn7.FieldName = "BillStatus.BillStatusDesc";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 84;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "备注";
            this.gridColumn8.FieldName = "Remark";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 86;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "新增人员";
            this.gridColumn9.FieldName = "CreateUserName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 98;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "新增时间";
            this.gridColumn10.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "CreateTime";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 140;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "修改人员";
            this.gridColumn11.FieldName = "UpdateUserName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 89;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "修改时间";
            this.gridColumn12.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "UpdateTime";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 36;
            // 
            // PM_Bill_Iron_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 583);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PM_Bill_Iron_Form";
            this.Text = "铁水轨道衡计划委托管理";
            this.Load += new System.EventHandler(this.PM_Bill_Iron_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dte_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_BillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TankNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_HeatNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁水罐号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.计量状态)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉号)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt_TankNo;
        private DevExpress.XtraEditors.TextEdit txt_HeatNo;
        private DevExpress.XtraEditors.TextEdit txt_PlanNo;
        private DevExpress.XtraLayout.LayoutControlItem 委托单号;
        private DevExpress.XtraLayout.LayoutControlItem 铁水罐号;
        private DevExpress.XtraLayout.LayoutControlItem 炉号;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_query;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_update;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LookUpEdit lue_BillStatus;
        private DevExpress.XtraLayout.LayoutControlItem 计量状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private Core.Helper.GToolStripButton btn_Invalid;
        private DevExpress.XtraEditors.DateEdit dte_EndTime;
        private DevExpress.XtraEditors.DateEdit dte_StartTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}