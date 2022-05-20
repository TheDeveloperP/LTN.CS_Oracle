namespace LTN.CS.SCMForm.PT
{
    partial class PT_TruckMeasurePlan_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PT_TruckMeasurePlan_Form));
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Sel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_BatchUpdate = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Invalid = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_BatchInvalid = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Export2 = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStripButton1 = new LTN.CS.Core.Helper.GToolStripButton();
            this.Panel_Query = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.txt_TruckNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gCtrl_TruckMeasurePlan = new DevExpress.XtraGrid.GridControl();
            this.gView_TruckMeasurePlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_I_IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PLANNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CARNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_MATERIALNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_FROMDEPTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_FROMSTORENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_TODEPTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_TOSTORENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_BUSINESSTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_PLANTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_ISAUTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAutoCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gCol_I_WEIGHTTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_TARETIMELIMIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_ONEMORESTOCK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_ISCHILDIDENFY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_ISCREATEMOTHERPOND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISCREATEMOTHERPONDCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gCol_C_CONNECTPLANNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_ONETWOPLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ONETWOPLANCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gCol_C_MIDDLEDEPTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_MIDDLESTORENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CARSERIALNUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CONTRACTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_RETALLYKG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_COMPUTERTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_DOWNVALUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_UPVALUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PERCENTAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_SHIPPINGNOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_I_REPEATPOUND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PLANLIMITTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PONDLIMIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_PLANSTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_UPDATEUSERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_UPDATETIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CREATEUSERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_CREATETIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel_Query)).BeginInit();
            this.Panel_Query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruckNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckMeasurePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckMeasurePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsAutoCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISCREATEMOTHERPONDCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ONETWOPLANCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Sel,
            this.btn_Add,
            this.btn_Update,
            this.btn_BatchUpdate,
            this.btn_Invalid,
            this.btn_BatchInvalid,
            this.btn_Export2,
            this.gToolStripButton1});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 94);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1028, 34);
            this.gToolStrip1.TabIndex = 0;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Sel
            // 
            this.btn_Sel.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sel.Image")));
            this.btn_Sel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Sel.Name = "btn_Sel";
            this.btn_Sel.Size = new System.Drawing.Size(68, 31);
            this.btn_Sel.Text = "查询";
            this.btn_Sel.Click += new System.EventHandler(this.btn_Sel_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(68, 31);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(68, 31);
            this.btn_Update.Text = "修改";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_BatchUpdate
            // 
            this.btn_BatchUpdate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_BatchUpdate.Image = global::LTN.CS.SCMForm.Properties.Resources.Maintenance_32;
            this.btn_BatchUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_BatchUpdate.Name = "btn_BatchUpdate";
            this.btn_BatchUpdate.Size = new System.Drawing.Size(97, 31);
            this.btn_BatchUpdate.Text = "批量修改";
            this.btn_BatchUpdate.Visible = false;
            this.btn_BatchUpdate.Click += new System.EventHandler(this.btn_BatchUpdate_Click);
            // 
            // btn_Invalid
            // 
            this.btn_Invalid.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invalid.Image = ((System.Drawing.Image)(resources.GetObject("btn_Invalid.Image")));
            this.btn_Invalid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Invalid.Name = "btn_Invalid";
            this.btn_Invalid.Size = new System.Drawing.Size(68, 31);
            this.btn_Invalid.Text = "作废";
            this.btn_Invalid.Click += new System.EventHandler(this.btn_Invalid_Click);
            // 
            // btn_BatchInvalid
            // 
            this.btn_BatchInvalid.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_BatchInvalid.Image = global::LTN.CS.SCMForm.Properties.Resources.cancel_16;
            this.btn_BatchInvalid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_BatchInvalid.Name = "btn_BatchInvalid";
            this.btn_BatchInvalid.Size = new System.Drawing.Size(97, 31);
            this.btn_BatchInvalid.Text = "批量作废";
            this.btn_BatchInvalid.Click += new System.EventHandler(this.btn_BatchInvalid_Click);
            // 
            // btn_Export2
            // 
            this.btn_Export2.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export2.Image = ((System.Drawing.Image)(resources.GetObject("btn_Export2.Image")));
            this.btn_Export2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export2.Name = "btn_Export2";
            this.btn_Export2.Size = new System.Drawing.Size(68, 31);
            this.btn_Export2.Text = "导出";
            this.btn_Export2.Click += new System.EventHandler(this.btn_Export2_Click);
            // 
            // gToolStripButton1
            // 
            this.gToolStripButton1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("gToolStripButton1.Image")));
            this.gToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton1.Name = "gToolStripButton1";
            this.gToolStripButton1.Size = new System.Drawing.Size(97, 31);
            this.gToolStripButton1.Text = "复制新增";
            this.gToolStripButton1.Click += new System.EventHandler(this.gToolStripButton1_Click);
            // 
            // Panel_Query
            // 
            this.Panel_Query.Controls.Add(this.layoutControl1);
            this.Panel_Query.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Query.Location = new System.Drawing.Point(0, 0);
            this.Panel_Query.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_Query.Name = "Panel_Query";
            this.Panel_Query.Size = new System.Drawing.Size(1028, 94);
            this.Panel_Query.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Controls.Add(this.txt_TruckNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(379, 344, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(850, 90);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(428, 42);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(280, 26);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 4;
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
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
            this.date_StartTime.Size = new System.Drawing.Size(268, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 2;
            this.date_StartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.date_StartTime_KeyPress);
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(428, 12);
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
            this.date_EndTime.Size = new System.Drawing.Size(280, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 3;
            this.date_EndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.date_EndTime_KeyPress);
            // 
            // txt_TruckNo
            // 
            this.txt_TruckNo.Location = new System.Drawing.Point(84, 42);
            this.txt_TruckNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_TruckNo.Name = "txt_TruckNo";
            this.txt_TruckNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TruckNo.Properties.Appearance.Options.UseFont = true;
            this.txt_TruckNo.Size = new System.Drawing.Size(268, 26);
            this.txt_TruckNo.StyleController = this.layoutControl1;
            this.txt_TruckNo.TabIndex = 0;
            this.txt_TruckNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TruckNo_KeyPress);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(850, 90);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.date_StartTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(344, 30);
            this.layoutControlItem2.Text = "开始时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.date_EndTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(344, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(356, 30);
            this.layoutControlItem3.Text = "结束时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_TruckNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(344, 40);
            this.layoutControlItem1.Text = "车牌号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.textEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(344, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(356, 40);
            this.layoutControlItem4.Text = "委托单号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(700, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(130, 70);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gCtrl_TruckMeasurePlan
            // 
            this.gCtrl_TruckMeasurePlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_TruckMeasurePlan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_TruckMeasurePlan.Location = new System.Drawing.Point(0, 128);
            this.gCtrl_TruckMeasurePlan.MainView = this.gView_TruckMeasurePlan;
            this.gCtrl_TruckMeasurePlan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_TruckMeasurePlan.Name = "gCtrl_TruckMeasurePlan";
            this.gCtrl_TruckMeasurePlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.IsAutoCheckEdit1,
            this.ISCREATEMOTHERPONDCheckEdit1,
            this.ONETWOPLANCheckEdit1});
            this.gCtrl_TruckMeasurePlan.Size = new System.Drawing.Size(1028, 448);
            this.gCtrl_TruckMeasurePlan.TabIndex = 3;
            this.gCtrl_TruckMeasurePlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_TruckMeasurePlan});
            // 
            // gView_TruckMeasurePlan
            // 
            this.gView_TruckMeasurePlan.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gView_TruckMeasurePlan.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gView_TruckMeasurePlan.Appearance.GroupPanel.BackColor = System.Drawing.Color.LightGray;
            this.gView_TruckMeasurePlan.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.Silver;
            this.gView_TruckMeasurePlan.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gView_TruckMeasurePlan.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_TruckMeasurePlan.Appearance.GroupRow.Options.UseFont = true;
            this.gView_TruckMeasurePlan.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_TruckMeasurePlan.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_TruckMeasurePlan.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_TruckMeasurePlan.Appearance.Row.Options.UseFont = true;
            this.gView_TruckMeasurePlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_I_IntId,
            this.gCol_C_PLANNO,
            this.gCol_C_CARNAME,
            this.gCol_C_MATERIALNAME,
            this.gCol_C_FROMDEPTNAME,
            this.gCol_C_FROMSTORENAME,
            this.gCol_C_TODEPTNAME,
            this.gCol_C_TOSTORENAME,
            this.gCol_I_BUSINESSTYPE,
            this.gCol_I_PLANTYPE,
            this.gCol_I_ISAUTO,
            this.gCol_I_WEIGHTTYPE,
            this.gCol_I_TARETIMELIMIT,
            this.gCol_I_ONEMORESTOCK,
            this.gCol_I_ISCHILDIDENFY,
            this.gCol_I_ISCREATEMOTHERPOND,
            this.gCol_C_CONNECTPLANNO,
            this.gCol_I_ONETWOPLAN,
            this.gCol_C_MIDDLEDEPTNAME,
            this.gCol_C_MIDDLESTORENAME,
            this.gCol_C_CARSERIALNUMBER,
            this.gCol_C_CONTRACTNO,
            this.gCol_I_RETALLYKG,
            this.gCol_I_COMPUTERTYPE,
            this.gCol_I_DOWNVALUE,
            this.gCol_I_UPVALUE,
            this.gCol_C_PERCENTAGE,
            this.gCol_C_SHIPPINGNOTE,
            this.gCol_I_REPEATPOUND,
            this.gCol_C_PLANLIMITTIME,
            this.gCol_C_PONDLIMIT,
            this.gCol_C_REMARK,
            this.gCol_C_PLANSTATE,
            this.gCol_C_UPDATEUSERNAME,
            this.gCol_C_UPDATETIME,
            this.gCol_C_CREATEUSERNAME,
            this.gCol_C_CREATETIME,
            this.gridColumn1});
            this.gView_TruckMeasurePlan.GridControl = this.gCtrl_TruckMeasurePlan;
            this.gView_TruckMeasurePlan.GroupPanelText = " ";
            this.gView_TruckMeasurePlan.IndicatorWidth = 20;
            this.gView_TruckMeasurePlan.Name = "gView_TruckMeasurePlan";
            this.gView_TruckMeasurePlan.OptionsBehavior.Editable = false;
            this.gView_TruckMeasurePlan.OptionsCustomization.AllowSort = false;
            this.gView_TruckMeasurePlan.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gView_TruckMeasurePlan.OptionsSelection.MultiSelect = true;
            this.gView_TruckMeasurePlan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gView_TruckMeasurePlan.OptionsView.ColumnAutoWidth = false;
            this.gView_TruckMeasurePlan.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gView_TruckMeasurePlan_CustomDrawCell);
            this.gView_TruckMeasurePlan.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gView_TruckMeasurePlan_RowCellStyle);
            this.gView_TruckMeasurePlan.TopRowChanged += new System.EventHandler(this.gView_TruckMeasurePlan_TopRowChanged);
            this.gView_TruckMeasurePlan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gView_TruckMeasurePlan_FocusedRowChanged);
            this.gView_TruckMeasurePlan.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gView_TruckMeasurePlan_CustomColumnDisplayText);
            this.gView_TruckMeasurePlan.DoubleClick += new System.EventHandler(this.gView_TruckMeasurePlan_DoubleClick);
            // 
            // gCol_I_IntId
            // 
            this.gCol_I_IntId.Caption = "主键";
            this.gCol_I_IntId.FieldName = "I_IntId";
            this.gCol_I_IntId.Name = "gCol_I_IntId";
            // 
            // gCol_C_PLANNO
            // 
            this.gCol_C_PLANNO.Caption = "委托单号";
            this.gCol_C_PLANNO.FieldName = "C_PLANNO";
            this.gCol_C_PLANNO.Name = "gCol_C_PLANNO";
            this.gCol_C_PLANNO.Visible = true;
            this.gCol_C_PLANNO.VisibleIndex = 1;
            this.gCol_C_PLANNO.Width = 170;
            // 
            // gCol_C_CARNAME
            // 
            this.gCol_C_CARNAME.Caption = "车牌号码";
            this.gCol_C_CARNAME.FieldName = "C_CARNAME";
            this.gCol_C_CARNAME.Name = "gCol_C_CARNAME";
            this.gCol_C_CARNAME.Visible = true;
            this.gCol_C_CARNAME.VisibleIndex = 2;
            this.gCol_C_CARNAME.Width = 135;
            // 
            // gCol_C_MATERIALNAME
            // 
            this.gCol_C_MATERIALNAME.Caption = "品名";
            this.gCol_C_MATERIALNAME.FieldName = "C_MATERIALNAME";
            this.gCol_C_MATERIALNAME.Name = "gCol_C_MATERIALNAME";
            this.gCol_C_MATERIALNAME.Visible = true;
            this.gCol_C_MATERIALNAME.VisibleIndex = 3;
            this.gCol_C_MATERIALNAME.Width = 148;
            // 
            // gCol_C_FROMDEPTNAME
            // 
            this.gCol_C_FROMDEPTNAME.Caption = "来源单位";
            this.gCol_C_FROMDEPTNAME.FieldName = "C_FROMDEPTNAME";
            this.gCol_C_FROMDEPTNAME.Name = "gCol_C_FROMDEPTNAME";
            this.gCol_C_FROMDEPTNAME.Visible = true;
            this.gCol_C_FROMDEPTNAME.VisibleIndex = 4;
            this.gCol_C_FROMDEPTNAME.Width = 161;
            // 
            // gCol_C_FROMSTORENAME
            // 
            this.gCol_C_FROMSTORENAME.Caption = "来源仓库";
            this.gCol_C_FROMSTORENAME.FieldName = "C_FROMSTORENAME";
            this.gCol_C_FROMSTORENAME.Name = "gCol_C_FROMSTORENAME";
            this.gCol_C_FROMSTORENAME.Visible = true;
            this.gCol_C_FROMSTORENAME.VisibleIndex = 10;
            this.gCol_C_FROMSTORENAME.Width = 109;
            // 
            // gCol_C_TODEPTNAME
            // 
            this.gCol_C_TODEPTNAME.Caption = "去向单位";
            this.gCol_C_TODEPTNAME.FieldName = "C_TODEPTNAME";
            this.gCol_C_TODEPTNAME.Name = "gCol_C_TODEPTNAME";
            this.gCol_C_TODEPTNAME.Visible = true;
            this.gCol_C_TODEPTNAME.VisibleIndex = 5;
            this.gCol_C_TODEPTNAME.Width = 153;
            // 
            // gCol_C_TOSTORENAME
            // 
            this.gCol_C_TOSTORENAME.Caption = "去向仓库";
            this.gCol_C_TOSTORENAME.FieldName = "C_TOSTORENAME";
            this.gCol_C_TOSTORENAME.Name = "gCol_C_TOSTORENAME";
            this.gCol_C_TOSTORENAME.Visible = true;
            this.gCol_C_TOSTORENAME.VisibleIndex = 11;
            this.gCol_C_TOSTORENAME.Width = 106;
            // 
            // gCol_I_BUSINESSTYPE
            // 
            this.gCol_I_BUSINESSTYPE.Caption = "业务类型";
            this.gCol_I_BUSINESSTYPE.FieldName = "I_BUSINESSTYPE";
            this.gCol_I_BUSINESSTYPE.Name = "gCol_I_BUSINESSTYPE";
            this.gCol_I_BUSINESSTYPE.Visible = true;
            this.gCol_I_BUSINESSTYPE.VisibleIndex = 13;
            this.gCol_I_BUSINESSTYPE.Width = 120;
            // 
            // gCol_I_PLANTYPE
            // 
            this.gCol_I_PLANTYPE.Caption = "委托类型";
            this.gCol_I_PLANTYPE.FieldName = "I_PLANTYPE";
            this.gCol_I_PLANTYPE.Name = "gCol_I_PLANTYPE";
            this.gCol_I_PLANTYPE.Visible = true;
            this.gCol_I_PLANTYPE.VisibleIndex = 14;
            this.gCol_I_PLANTYPE.Width = 98;
            // 
            // gCol_I_ISAUTO
            // 
            this.gCol_I_ISAUTO.Caption = "自助过磅";
            this.gCol_I_ISAUTO.ColumnEdit = this.IsAutoCheckEdit1;
            this.gCol_I_ISAUTO.FieldName = "I_ISAUTO";
            this.gCol_I_ISAUTO.Name = "gCol_I_ISAUTO";
            this.gCol_I_ISAUTO.Visible = true;
            this.gCol_I_ISAUTO.VisibleIndex = 15;
            this.gCol_I_ISAUTO.Width = 97;
            // 
            // IsAutoCheckEdit1
            // 
            this.IsAutoCheckEdit1.AutoHeight = false;
            this.IsAutoCheckEdit1.Name = "IsAutoCheckEdit1";
            this.IsAutoCheckEdit1.ValueChecked = 1;
            this.IsAutoCheckEdit1.ValueUnchecked = 0;
            // 
            // gCol_I_WEIGHTTYPE
            // 
            this.gCol_I_WEIGHTTYPE.Caption = "过磅方式";
            this.gCol_I_WEIGHTTYPE.FieldName = "I_WEIGHTTYPE";
            this.gCol_I_WEIGHTTYPE.Name = "gCol_I_WEIGHTTYPE";
            this.gCol_I_WEIGHTTYPE.Visible = true;
            this.gCol_I_WEIGHTTYPE.VisibleIndex = 16;
            this.gCol_I_WEIGHTTYPE.Width = 100;
            // 
            // gCol_I_TARETIMELIMIT
            // 
            this.gCol_I_TARETIMELIMIT.Caption = "皮重时限(H)";
            this.gCol_I_TARETIMELIMIT.FieldName = "I_TARETIMELIMIT";
            this.gCol_I_TARETIMELIMIT.Name = "gCol_I_TARETIMELIMIT";
            this.gCol_I_TARETIMELIMIT.Visible = true;
            this.gCol_I_TARETIMELIMIT.VisibleIndex = 17;
            this.gCol_I_TARETIMELIMIT.Width = 120;
            // 
            // gCol_I_ONEMORESTOCK
            // 
            this.gCol_I_ONEMORESTOCK.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_I_ONEMORESTOCK.AppearanceCell.Options.UseBackColor = true;
            this.gCol_I_ONEMORESTOCK.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_I_ONEMORESTOCK.Caption = "一车多货";
            this.gCol_I_ONEMORESTOCK.FieldName = "I_ONEMORESTOCK";
            this.gCol_I_ONEMORESTOCK.Name = "gCol_I_ONEMORESTOCK";
            this.gCol_I_ONEMORESTOCK.Visible = true;
            this.gCol_I_ONEMORESTOCK.VisibleIndex = 18;
            this.gCol_I_ONEMORESTOCK.Width = 100;
            // 
            // gCol_I_ISCHILDIDENFY
            // 
            this.gCol_I_ISCHILDIDENFY.Caption = "母/子标识";
            this.gCol_I_ISCHILDIDENFY.FieldName = "I_ISCHILDIDENFY";
            this.gCol_I_ISCHILDIDENFY.Name = "gCol_I_ISCHILDIDENFY";
            this.gCol_I_ISCHILDIDENFY.Visible = true;
            this.gCol_I_ISCHILDIDENFY.VisibleIndex = 19;
            this.gCol_I_ISCHILDIDENFY.Width = 100;
            // 
            // gCol_I_ISCREATEMOTHERPOND
            // 
            this.gCol_I_ISCREATEMOTHERPOND.Caption = "生成母码单";
            this.gCol_I_ISCREATEMOTHERPOND.ColumnEdit = this.ISCREATEMOTHERPONDCheckEdit1;
            this.gCol_I_ISCREATEMOTHERPOND.FieldName = "I_ISCREATEMOTHERPOND";
            this.gCol_I_ISCREATEMOTHERPOND.Name = "gCol_I_ISCREATEMOTHERPOND";
            this.gCol_I_ISCREATEMOTHERPOND.Visible = true;
            this.gCol_I_ISCREATEMOTHERPOND.VisibleIndex = 20;
            this.gCol_I_ISCREATEMOTHERPOND.Width = 120;
            // 
            // ISCREATEMOTHERPONDCheckEdit1
            // 
            this.ISCREATEMOTHERPONDCheckEdit1.AutoHeight = false;
            this.ISCREATEMOTHERPONDCheckEdit1.Name = "ISCREATEMOTHERPONDCheckEdit1";
            this.ISCREATEMOTHERPONDCheckEdit1.ValueChecked = 1;
            this.ISCREATEMOTHERPONDCheckEdit1.ValueUnchecked = 0;
            // 
            // gCol_C_CONNECTPLANNO
            // 
            this.gCol_C_CONNECTPLANNO.Caption = "关联单号";
            this.gCol_C_CONNECTPLANNO.FieldName = "C_CONNECTPLANNO";
            this.gCol_C_CONNECTPLANNO.Name = "gCol_C_CONNECTPLANNO";
            this.gCol_C_CONNECTPLANNO.Visible = true;
            this.gCol_C_CONNECTPLANNO.VisibleIndex = 21;
            this.gCol_C_CONNECTPLANNO.Width = 170;
            // 
            // gCol_I_ONETWOPLAN
            // 
            this.gCol_I_ONETWOPLAN.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_I_ONETWOPLAN.AppearanceCell.Options.UseBackColor = true;
            this.gCol_I_ONETWOPLAN.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_I_ONETWOPLAN.Caption = "一车两单";
            this.gCol_I_ONETWOPLAN.ColumnEdit = this.ONETWOPLANCheckEdit1;
            this.gCol_I_ONETWOPLAN.FieldName = "I_ONETWOPLAN";
            this.gCol_I_ONETWOPLAN.Name = "gCol_I_ONETWOPLAN";
            this.gCol_I_ONETWOPLAN.Visible = true;
            this.gCol_I_ONETWOPLAN.VisibleIndex = 22;
            this.gCol_I_ONETWOPLAN.Width = 100;
            // 
            // ONETWOPLANCheckEdit1
            // 
            this.ONETWOPLANCheckEdit1.AutoHeight = false;
            this.ONETWOPLANCheckEdit1.Name = "ONETWOPLANCheckEdit1";
            this.ONETWOPLANCheckEdit1.ValueChecked = 1;
            this.ONETWOPLANCheckEdit1.ValueUnchecked = 0;
            // 
            // gCol_C_MIDDLEDEPTNAME
            // 
            this.gCol_C_MIDDLEDEPTNAME.Caption = "中间单位名称";
            this.gCol_C_MIDDLEDEPTNAME.FieldName = "C_MIDDLEDEPTNAME";
            this.gCol_C_MIDDLEDEPTNAME.Name = "gCol_C_MIDDLEDEPTNAME";
            this.gCol_C_MIDDLEDEPTNAME.Visible = true;
            this.gCol_C_MIDDLEDEPTNAME.VisibleIndex = 23;
            this.gCol_C_MIDDLEDEPTNAME.Width = 150;
            // 
            // gCol_C_MIDDLESTORENAME
            // 
            this.gCol_C_MIDDLESTORENAME.Caption = "中间仓库名称";
            this.gCol_C_MIDDLESTORENAME.FieldName = "C_MIDDLESTORENAME";
            this.gCol_C_MIDDLESTORENAME.Name = "gCol_C_MIDDLESTORENAME";
            this.gCol_C_MIDDLESTORENAME.Visible = true;
            this.gCol_C_MIDDLESTORENAME.VisibleIndex = 24;
            this.gCol_C_MIDDLESTORENAME.Width = 150;
            // 
            // gCol_C_CARSERIALNUMBER
            // 
            this.gCol_C_CARSERIALNUMBER.Caption = "汽车进厂流水号";
            this.gCol_C_CARSERIALNUMBER.FieldName = "C_CARSERIALNUMBER";
            this.gCol_C_CARSERIALNUMBER.Name = "gCol_C_CARSERIALNUMBER";
            this.gCol_C_CARSERIALNUMBER.Visible = true;
            this.gCol_C_CARSERIALNUMBER.VisibleIndex = 26;
            this.gCol_C_CARSERIALNUMBER.Width = 175;
            // 
            // gCol_C_CONTRACTNO
            // 
            this.gCol_C_CONTRACTNO.Caption = "合同号";
            this.gCol_C_CONTRACTNO.FieldName = "C_CONTRACTNO";
            this.gCol_C_CONTRACTNO.Name = "gCol_C_CONTRACTNO";
            this.gCol_C_CONTRACTNO.Visible = true;
            this.gCol_C_CONTRACTNO.VisibleIndex = 27;
            // 
            // gCol_I_RETALLYKG
            // 
            this.gCol_I_RETALLYKG.Caption = "理重(KG)";
            this.gCol_I_RETALLYKG.FieldName = "I_RETALLYKG";
            this.gCol_I_RETALLYKG.Name = "gCol_I_RETALLYKG";
            this.gCol_I_RETALLYKG.Visible = true;
            this.gCol_I_RETALLYKG.VisibleIndex = 25;
            this.gCol_I_RETALLYKG.Width = 100;
            // 
            // gCol_I_COMPUTERTYPE
            // 
            this.gCol_I_COMPUTERTYPE.Caption = "偏差方式";
            this.gCol_I_COMPUTERTYPE.FieldName = "I_COMPUTERTYPE";
            this.gCol_I_COMPUTERTYPE.Name = "gCol_I_COMPUTERTYPE";
            this.gCol_I_COMPUTERTYPE.Visible = true;
            this.gCol_I_COMPUTERTYPE.VisibleIndex = 28;
            this.gCol_I_COMPUTERTYPE.Width = 100;
            // 
            // gCol_I_DOWNVALUE
            // 
            this.gCol_I_DOWNVALUE.Caption = "下偏差值(KG)";
            this.gCol_I_DOWNVALUE.FieldName = "I_DOWNVALUE";
            this.gCol_I_DOWNVALUE.Name = "gCol_I_DOWNVALUE";
            this.gCol_I_DOWNVALUE.Visible = true;
            this.gCol_I_DOWNVALUE.VisibleIndex = 29;
            this.gCol_I_DOWNVALUE.Width = 150;
            // 
            // gCol_I_UPVALUE
            // 
            this.gCol_I_UPVALUE.Caption = "上偏差值(KG)";
            this.gCol_I_UPVALUE.FieldName = "I_UPVALUE";
            this.gCol_I_UPVALUE.Name = "gCol_I_UPVALUE";
            this.gCol_I_UPVALUE.Visible = true;
            this.gCol_I_UPVALUE.VisibleIndex = 30;
            this.gCol_I_UPVALUE.Width = 150;
            // 
            // gCol_C_PERCENTAGE
            // 
            this.gCol_C_PERCENTAGE.Caption = "偏差百分比";
            this.gCol_C_PERCENTAGE.FieldName = "C_PERCENTAGE";
            this.gCol_C_PERCENTAGE.Name = "gCol_C_PERCENTAGE";
            this.gCol_C_PERCENTAGE.Visible = true;
            this.gCol_C_PERCENTAGE.VisibleIndex = 31;
            this.gCol_C_PERCENTAGE.Width = 120;
            // 
            // gCol_C_SHIPPINGNOTE
            // 
            this.gCol_C_SHIPPINGNOTE.Caption = "托运号";
            this.gCol_C_SHIPPINGNOTE.FieldName = "C_SHIPPINGNOTE ";
            this.gCol_C_SHIPPINGNOTE.Name = "gCol_C_SHIPPINGNOTE";
            this.gCol_C_SHIPPINGNOTE.Visible = true;
            this.gCol_C_SHIPPINGNOTE.VisibleIndex = 32;
            this.gCol_C_SHIPPINGNOTE.Width = 170;
            // 
            // gCol_I_REPEATPOUND
            // 
            this.gCol_I_REPEATPOUND.Caption = "复磅标志";
            this.gCol_I_REPEATPOUND.FieldName = "I_REPEATPOUND";
            this.gCol_I_REPEATPOUND.Name = "gCol_I_REPEATPOUND";
            this.gCol_I_REPEATPOUND.Visible = true;
            this.gCol_I_REPEATPOUND.VisibleIndex = 33;
            this.gCol_I_REPEATPOUND.Width = 100;
            // 
            // gCol_C_PLANLIMITTIME
            // 
            this.gCol_C_PLANLIMITTIME.Caption = "失效时间";
            this.gCol_C_PLANLIMITTIME.FieldName = "C_PLANLIMITTIME";
            this.gCol_C_PLANLIMITTIME.Name = "gCol_C_PLANLIMITTIME";
            this.gCol_C_PLANLIMITTIME.Visible = true;
            this.gCol_C_PLANLIMITTIME.VisibleIndex = 34;
            this.gCol_C_PLANLIMITTIME.Width = 200;
            // 
            // gCol_C_PONDLIMIT
            // 
            this.gCol_C_PONDLIMIT.Caption = "磅点限制";
            this.gCol_C_PONDLIMIT.FieldName = "C_PONDLIMIT";
            this.gCol_C_PONDLIMIT.Name = "gCol_C_PONDLIMIT";
            this.gCol_C_PONDLIMIT.Visible = true;
            this.gCol_C_PONDLIMIT.VisibleIndex = 35;
            this.gCol_C_PONDLIMIT.Width = 100;
            // 
            // gCol_C_REMARK
            // 
            this.gCol_C_REMARK.Caption = "备注";
            this.gCol_C_REMARK.FieldName = "C_REMARK";
            this.gCol_C_REMARK.Name = "gCol_C_REMARK";
            this.gCol_C_REMARK.Visible = true;
            this.gCol_C_REMARK.VisibleIndex = 12;
            this.gCol_C_REMARK.Width = 111;
            // 
            // gCol_C_PLANSTATE
            // 
            this.gCol_C_PLANSTATE.Caption = "计量状态";
            this.gCol_C_PLANSTATE.FieldName = "C_PLANSTATE";
            this.gCol_C_PLANSTATE.Name = "gCol_C_PLANSTATE";
            this.gCol_C_PLANSTATE.Visible = true;
            this.gCol_C_PLANSTATE.VisibleIndex = 7;
            this.gCol_C_PLANSTATE.Width = 100;
            // 
            // gCol_C_UPDATEUSERNAME
            // 
            this.gCol_C_UPDATEUSERNAME.Caption = "修改人";
            this.gCol_C_UPDATEUSERNAME.FieldName = "C_UPDATEUSERNAME";
            this.gCol_C_UPDATEUSERNAME.Name = "gCol_C_UPDATEUSERNAME";
            this.gCol_C_UPDATEUSERNAME.Visible = true;
            this.gCol_C_UPDATEUSERNAME.VisibleIndex = 36;
            this.gCol_C_UPDATEUSERNAME.Width = 120;
            // 
            // gCol_C_UPDATETIME
            // 
            this.gCol_C_UPDATETIME.Caption = "修改时间";
            this.gCol_C_UPDATETIME.FieldName = "C_UPDATETIME";
            this.gCol_C_UPDATETIME.Name = "gCol_C_UPDATETIME";
            this.gCol_C_UPDATETIME.Visible = true;
            this.gCol_C_UPDATETIME.VisibleIndex = 37;
            this.gCol_C_UPDATETIME.Width = 200;
            // 
            // gCol_C_CREATEUSERNAME
            // 
            this.gCol_C_CREATEUSERNAME.Caption = "创建人";
            this.gCol_C_CREATEUSERNAME.FieldName = "C_CREATEUSERNAME";
            this.gCol_C_CREATEUSERNAME.Name = "gCol_C_CREATEUSERNAME";
            this.gCol_C_CREATEUSERNAME.Visible = true;
            this.gCol_C_CREATEUSERNAME.VisibleIndex = 8;
            this.gCol_C_CREATEUSERNAME.Width = 120;
            // 
            // gCol_C_CREATETIME
            // 
            this.gCol_C_CREATETIME.Caption = "创建时间";
            this.gCol_C_CREATETIME.FieldName = "C_CREATETIME";
            this.gCol_C_CREATETIME.Name = "gCol_C_CREATETIME";
            this.gCol_C_CREATETIME.Visible = true;
            this.gCol_C_CREATETIME.VisibleIndex = 9;
            this.gCol_C_CREATETIME.Width = 200;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "集装箱号";
            this.gridColumn1.FieldName = "C_CONTAINERNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 176;
            // 
            // PT_TruckMeasurePlan_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 576);
            this.Controls.Add(this.gCtrl_TruckMeasurePlan);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.Panel_Query);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "PT_TruckMeasurePlan_Form";
            this.ShowIcon = false;
            this.Text = "汽车磅委托管理";
            this.Shown += new System.EventHandler(this.PT_TruckMeasurePlan_Form_Shown);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel_Query)).EndInit();
            this.Panel_Query.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruckNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckMeasurePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckMeasurePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsAutoCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISCREATEMOTHERPONDCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ONETWOPLANCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_Update;
        private Core.Helper.GToolStripButton btn_Sel;
        private Core.Helper.GToolStripButton btn_Invalid;
        private DevExpress.XtraEditors.PanelControl Panel_Query;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gCtrl_TruckMeasurePlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_TruckMeasurePlan;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_IntId;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PLANNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CARNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MATERIALNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_FROMDEPTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_FROMSTORENAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_TODEPTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_TOSTORENAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_BUSINESSTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_PLANTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_ISAUTO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_WEIGHTTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_TARETIMELIMIT;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_ONEMORESTOCK;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_ISCHILDIDENFY;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_ISCREATEMOTHERPOND;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CONNECTPLANNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_ONETWOPLAN;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MIDDLEDEPTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MIDDLESTORENAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_RETALLYKG;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_COMPUTERTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_DOWNVALUE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_UPVALUE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PERCENTAGE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_SHIPPINGNOTE;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_I_REPEATPOUND;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PLANLIMITTIME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PONDLIMIT;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_REMARK;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PLANSTATE;
        private Core.Helper.GToolStripButton btn_Export2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit IsAutoCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ISCREATEMOTHERPONDCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ONETWOPLANCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_UPDATEUSERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_UPDATETIME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CREATEUSERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CREATETIME;
        private DevExpress.XtraEditors.TextEdit txt_TruckNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CARSERIALNUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_CONTRACTNO;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Core.Helper.GToolStripButton gToolStripButton1;
        private Core.Helper.GToolStripButton btn_BatchUpdate;
        private Core.Helper.GToolStripButton btn_BatchInvalid;
    }
}