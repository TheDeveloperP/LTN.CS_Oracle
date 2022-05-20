namespace LTN.CS.SCMForm.PM
{
    partial class PM_Bill_Belt_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM_Bill_Belt_Form));
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Query = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Invalid = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Export = new LTN.CS.Core.Helper.GToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_PlanNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_WgtNo = new DevExpress.XtraEditors.TextEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gCtrl_BeltBill = new DevExpress.XtraGrid.GridControl();
            this.gView_BeltBill = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_C_Wgtlistno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Beltno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Beltname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Materialname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_Startwgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_Endwgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_Netwgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Measurestarttime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Measureendtime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Planno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Fromdeptname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Todeptname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Fromstorename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Tostorename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Billstate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Uploadstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Billcreatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Billcreateusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Updatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_Updateusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_Intid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WgtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_BeltBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_BeltBill)).BeginInit();
            this.SuspendLayout();
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Query,
            this.btn_Add,
            this.btn_Update,
            this.btn_Invalid,
            this.btn_Export});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 57);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1028, 42);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Query.Image = ((System.Drawing.Image)(resources.GetObject("btn_Query.Image")));
            this.btn_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(68, 39);
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(68, 39);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(68, 39);
            this.btn_Update.Text = "修改";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Invalid
            // 
            this.btn_Invalid.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invalid.Image = ((System.Drawing.Image)(resources.GetObject("btn_Invalid.Image")));
            this.btn_Invalid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Invalid.Name = "btn_Invalid";
            this.btn_Invalid.Size = new System.Drawing.Size(68, 39);
            this.btn_Invalid.Text = "作废";
            this.btn_Invalid.Click += new System.EventHandler(this.btn_Invalid_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Image = ((System.Drawing.Image)(resources.GetObject("btn_Export.Image")));
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(68, 39);
            this.btn_Export.Text = "导出";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1028, 57);
            this.panelControl1.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_PlanNo);
            this.layoutControl1.Controls.Add(this.txt_WgtNo);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1170, 53);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_PlanNo
            // 
            this.txt_PlanNo.Location = new System.Drawing.Point(659, 12);
            this.txt_PlanNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_PlanNo.Name = "txt_PlanNo";
            this.txt_PlanNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PlanNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PlanNo.Size = new System.Drawing.Size(212, 26);
            this.txt_PlanNo.StyleController = this.layoutControl1;
            this.txt_PlanNo.TabIndex = 3;
            // 
            // txt_WgtNo
            // 
            this.txt_WgtNo.Location = new System.Drawing.Point(947, 12);
            this.txt_WgtNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_WgtNo.Name = "txt_WgtNo";
            this.txt_WgtNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_WgtNo.Properties.Appearance.Options.UseFont = true;
            this.txt_WgtNo.Size = new System.Drawing.Size(211, 26);
            this.txt_WgtNo.StyleController = this.layoutControl1;
            this.txt_WgtNo.TabIndex = 4;
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(84, 12);
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.date_StartTime.Size = new System.Drawing.Size(212, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 0;
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(372, 12);
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.date_EndTime.Size = new System.Drawing.Size(211, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1170, 53);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.date_StartTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(288, 33);
            this.layoutControlItem3.Text = "开始时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_EndTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(288, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(287, 33);
            this.layoutControlItem4.Text = "结束时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_PlanNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(575, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(288, 33);
            this.layoutControlItem1.Text = "委托单号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_WgtNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(863, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(287, 33);
            this.layoutControlItem2.Text = "磅单号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 21);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "labelControl1";
            // 
            // gCtrl_BeltBill
            // 
            this.gCtrl_BeltBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_BeltBill.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_BeltBill.Location = new System.Drawing.Point(0, 99);
            this.gCtrl_BeltBill.MainView = this.gView_BeltBill;
            this.gCtrl_BeltBill.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_BeltBill.Name = "gCtrl_BeltBill";
            this.gCtrl_BeltBill.Size = new System.Drawing.Size(1028, 484);
            this.gCtrl_BeltBill.TabIndex = 3;
            this.gCtrl_BeltBill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_BeltBill});
            // 
            // gView_BeltBill
            // 
            this.gView_BeltBill.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_BeltBill.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_BeltBill.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_BeltBill.Appearance.Row.Options.UseFont = true;
            this.gView_BeltBill.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_C_Wgtlistno,
            this.gCol_C_Beltno,
            this.gCol_C_Beltname,
            this.gCol_C_Materialname,
            this.gCol_N_Startwgt,
            this.gCol_N_Endwgt,
            this.gCol_N_Netwgt,
            this.gCol_C_Measurestarttime,
            this.gCol_C_Measureendtime,
            this.gCol_C_Planno,
            this.gCol_C_Fromdeptname,
            this.gCol_C_Todeptname,
            this.gCol_C_Fromstorename,
            this.gCol_C_Tostorename,
            this.gCol_C_Billstate,
            this.gCol_C_Uploadstatus,
            this.gCol_C_Billcreatetime,
            this.gCol_C_Billcreateusername,
            this.gCol_C_Updatetime,
            this.gCol_C_Updateusername,
            this.gCol_I_Intid});
            this.gView_BeltBill.GridControl = this.gCtrl_BeltBill;
            this.gView_BeltBill.GroupPanelText = " ";
            this.gView_BeltBill.Name = "gView_BeltBill";
            this.gView_BeltBill.OptionsBehavior.Editable = false;
            this.gView_BeltBill.OptionsView.ColumnAutoWidth = false;
            this.gView_BeltBill.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gView_BeltBill_CustomColumnDisplayText);
            this.gView_BeltBill.DoubleClick += new System.EventHandler(this.gView_BeltBill_DoubleClick);
            // 
            // gCol_C_Wgtlistno
            // 
            this.gCol_C_Wgtlistno.Caption = "磅单号";
            this.gCol_C_Wgtlistno.FieldName = "C_Wgtlistno";
            this.gCol_C_Wgtlistno.Name = "gCol_C_Wgtlistno";
            this.gCol_C_Wgtlistno.Visible = true;
            this.gCol_C_Wgtlistno.VisibleIndex = 0;
            this.gCol_C_Wgtlistno.Width = 240;
            // 
            // gCol_C_Beltno
            // 
            this.gCol_C_Beltno.Caption = "皮带编号";
            this.gCol_C_Beltno.FieldName = "C_Beltno";
            this.gCol_C_Beltno.Name = "gCol_C_Beltno";
            this.gCol_C_Beltno.Visible = true;
            this.gCol_C_Beltno.VisibleIndex = 1;
            this.gCol_C_Beltno.Width = 100;
            // 
            // gCol_C_Beltname
            // 
            this.gCol_C_Beltname.Caption = "皮带名称";
            this.gCol_C_Beltname.FieldName = "C_Beltname";
            this.gCol_C_Beltname.Name = "gCol_C_Beltname";
            this.gCol_C_Beltname.Visible = true;
            this.gCol_C_Beltname.VisibleIndex = 2;
            this.gCol_C_Beltname.Width = 100;
            // 
            // gCol_C_Materialname
            // 
            this.gCol_C_Materialname.Caption = "品名";
            this.gCol_C_Materialname.FieldName = "C_Materialname";
            this.gCol_C_Materialname.Name = "gCol_C_Materialname";
            this.gCol_C_Materialname.Visible = true;
            this.gCol_C_Materialname.VisibleIndex = 11;
            this.gCol_C_Materialname.Width = 154;
            // 
            // gCol_N_Startwgt
            // 
            this.gCol_N_Startwgt.Caption = "开始累积量";
            this.gCol_N_Startwgt.FieldName = "N_Startwgt";
            this.gCol_N_Startwgt.Name = "gCol_N_Startwgt";
            this.gCol_N_Startwgt.Visible = true;
            this.gCol_N_Startwgt.VisibleIndex = 3;
            this.gCol_N_Startwgt.Width = 125;
            // 
            // gCol_N_Endwgt
            // 
            this.gCol_N_Endwgt.Caption = "结束累积量";
            this.gCol_N_Endwgt.FieldName = "N_Endwgt";
            this.gCol_N_Endwgt.Name = "gCol_N_Endwgt";
            this.gCol_N_Endwgt.Visible = true;
            this.gCol_N_Endwgt.VisibleIndex = 4;
            this.gCol_N_Endwgt.Width = 125;
            // 
            // gCol_N_Netwgt
            // 
            this.gCol_N_Netwgt.Caption = "净重";
            this.gCol_N_Netwgt.FieldName = "N_Netwgt";
            this.gCol_N_Netwgt.Name = "gCol_N_Netwgt";
            this.gCol_N_Netwgt.Visible = true;
            this.gCol_N_Netwgt.VisibleIndex = 5;
            this.gCol_N_Netwgt.Width = 125;
            // 
            // gCol_C_Measurestarttime
            // 
            this.gCol_C_Measurestarttime.Caption = "计量开始时间";
            this.gCol_C_Measurestarttime.FieldName = "C_Measurestarttime";
            this.gCol_C_Measurestarttime.Name = "gCol_C_Measurestarttime";
            this.gCol_C_Measurestarttime.Visible = true;
            this.gCol_C_Measurestarttime.VisibleIndex = 6;
            this.gCol_C_Measurestarttime.Width = 175;
            // 
            // gCol_C_Measureendtime
            // 
            this.gCol_C_Measureendtime.Caption = "计量结束时间";
            this.gCol_C_Measureendtime.FieldName = "C_Measureendtime";
            this.gCol_C_Measureendtime.Name = "gCol_C_Measureendtime";
            this.gCol_C_Measureendtime.Visible = true;
            this.gCol_C_Measureendtime.VisibleIndex = 7;
            this.gCol_C_Measureendtime.Width = 175;
            // 
            // gCol_C_Planno
            // 
            this.gCol_C_Planno.Caption = "委托单号";
            this.gCol_C_Planno.FieldName = "C_Planno";
            this.gCol_C_Planno.Name = "gCol_C_Planno";
            this.gCol_C_Planno.Visible = true;
            this.gCol_C_Planno.VisibleIndex = 10;
            this.gCol_C_Planno.Width = 184;
            // 
            // gCol_C_Fromdeptname
            // 
            this.gCol_C_Fromdeptname.Caption = "来源单位";
            this.gCol_C_Fromdeptname.FieldName = "C_Fromdeptname";
            this.gCol_C_Fromdeptname.Name = "gCol_C_Fromdeptname";
            this.gCol_C_Fromdeptname.Visible = true;
            this.gCol_C_Fromdeptname.VisibleIndex = 12;
            this.gCol_C_Fromdeptname.Width = 155;
            // 
            // gCol_C_Todeptname
            // 
            this.gCol_C_Todeptname.Caption = "去向单位";
            this.gCol_C_Todeptname.FieldName = "C_Todeptname";
            this.gCol_C_Todeptname.Name = "gCol_C_Todeptname";
            this.gCol_C_Todeptname.Visible = true;
            this.gCol_C_Todeptname.VisibleIndex = 13;
            this.gCol_C_Todeptname.Width = 152;
            // 
            // gCol_C_Fromstorename
            // 
            this.gCol_C_Fromstorename.Caption = "来源仓库";
            this.gCol_C_Fromstorename.FieldName = "C_Fromstorename";
            this.gCol_C_Fromstorename.Name = "gCol_C_Fromstorename";
            this.gCol_C_Fromstorename.Visible = true;
            this.gCol_C_Fromstorename.VisibleIndex = 14;
            this.gCol_C_Fromstorename.Width = 146;
            // 
            // gCol_C_Tostorename
            // 
            this.gCol_C_Tostorename.Caption = "去向仓库";
            this.gCol_C_Tostorename.FieldName = "C_Tostorename";
            this.gCol_C_Tostorename.Name = "gCol_C_Tostorename";
            this.gCol_C_Tostorename.Visible = true;
            this.gCol_C_Tostorename.VisibleIndex = 15;
            this.gCol_C_Tostorename.Width = 151;
            // 
            // gCol_C_Billstate
            // 
            this.gCol_C_Billstate.Caption = "磅单上传标志";
            this.gCol_C_Billstate.FieldName = "C_Planstatus";
            this.gCol_C_Billstate.Name = "gCol_C_Billstate";
            this.gCol_C_Billstate.Visible = true;
            this.gCol_C_Billstate.VisibleIndex = 8;
            this.gCol_C_Billstate.Width = 114;
            // 
            // gCol_C_Uploadstatus
            // 
            this.gCol_C_Uploadstatus.Caption = "上抛状态";
            this.gCol_C_Uploadstatus.FieldName = "C_Uploadstatus";
            this.gCol_C_Uploadstatus.Name = "gCol_C_Uploadstatus";
            this.gCol_C_Uploadstatus.Visible = true;
            this.gCol_C_Uploadstatus.VisibleIndex = 9;
            this.gCol_C_Uploadstatus.Width = 81;
            // 
            // gCol_C_Billcreatetime
            // 
            this.gCol_C_Billcreatetime.Caption = "创建时间";
            this.gCol_C_Billcreatetime.FieldName = "C_Billcreatetime";
            this.gCol_C_Billcreatetime.Name = "gCol_C_Billcreatetime";
            this.gCol_C_Billcreatetime.Visible = true;
            this.gCol_C_Billcreatetime.VisibleIndex = 17;
            this.gCol_C_Billcreatetime.Width = 169;
            // 
            // gCol_C_Billcreateusername
            // 
            this.gCol_C_Billcreateusername.Caption = "创建人";
            this.gCol_C_Billcreateusername.FieldName = "C_Billcreateusername";
            this.gCol_C_Billcreateusername.Name = "gCol_C_Billcreateusername";
            this.gCol_C_Billcreateusername.Visible = true;
            this.gCol_C_Billcreateusername.VisibleIndex = 16;
            this.gCol_C_Billcreateusername.Width = 111;
            // 
            // gCol_C_Updatetime
            // 
            this.gCol_C_Updatetime.Caption = "修改时间";
            this.gCol_C_Updatetime.FieldName = "C_Updatetime";
            this.gCol_C_Updatetime.Name = "gCol_C_Updatetime";
            this.gCol_C_Updatetime.Visible = true;
            this.gCol_C_Updatetime.VisibleIndex = 19;
            this.gCol_C_Updatetime.Width = 158;
            // 
            // gCol_C_Updateusername
            // 
            this.gCol_C_Updateusername.Caption = "修改人";
            this.gCol_C_Updateusername.FieldName = "C_Updateusername";
            this.gCol_C_Updateusername.Name = "gCol_C_Updateusername";
            this.gCol_C_Updateusername.Visible = true;
            this.gCol_C_Updateusername.VisibleIndex = 18;
            this.gCol_C_Updateusername.Width = 83;
            // 
            // gCol_I_Intid
            // 
            this.gCol_I_Intid.Caption = "主键";
            this.gCol_I_Intid.FieldName = "I_Intid";
            this.gCol_I_Intid.Name = "gCol_I_Intid";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.checkBox1.Location = new System.Drawing.Point(345, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 25);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "总量磅单";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // PM_Bill_Belt_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 583);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.gCtrl_BeltBill);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Name = "PM_Bill_Belt_Form";
            this.Text = "皮带秤磅单维护页面";
            this.Shown += new System.EventHandler(this.PM_Bill_Belt_Form_Shown);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WgtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_BeltBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_BeltBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Query;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_Update;
        private Core.Helper.GToolStripButton btn_Invalid;
        private Core.Helper.GToolStripButton btn_Export;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_PlanNo;
        private DevExpress.XtraEditors.TextEdit txt_WgtNo;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gCtrl_BeltBill;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_BeltBill;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Wgtlistno;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Beltno;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Beltname;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Materialname;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_Startwgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_Endwgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_Netwgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Measurestarttime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Measureendtime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Planno;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Fromdeptname;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Todeptname;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Fromstorename;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Tostorename;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Billstate;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Uploadstatus;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Billcreatetime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Billcreateusername;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Updatetime;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_Updateusername;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_Intid;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}