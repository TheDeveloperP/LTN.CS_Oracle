namespace LTN.CS.SCMForm.SM
{
    partial class SM_Site_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_Site_Form));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lup_SiteType = new DevExpress.XtraEditors.LookUpEdit();
            this.ch_IsAutoWeight = new DevExpress.XtraEditors.CheckEdit();
            this.txt_SiteIP2 = new DevExpress.XtraEditors.TextEdit();
            this.txt_SiteIP1 = new DevExpress.XtraEditors.TextEdit();
            this.txt_SiteAddress = new DevExpress.XtraEditors.TextEdit();
            this.txt_SiteName = new DevExpress.XtraEditors.TextEdit();
            this.txt_SiteNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Refresh = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteIp1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteIp2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAutoWeigh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.siteLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.updateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.updateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lup_SiteType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_IsAutoWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteIP2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteIP1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1159, 137);
            this.panelControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lup_SiteType);
            this.layoutControl1.Controls.Add(this.ch_IsAutoWeight);
            this.layoutControl1.Controls.Add(this.txt_SiteIP2);
            this.layoutControl1.Controls.Add(this.txt_SiteIP1);
            this.layoutControl1.Controls.Add(this.txt_SiteAddress);
            this.layoutControl1.Controls.Add(this.txt_SiteName);
            this.layoutControl1.Controls.Add(this.txt_SiteNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 3);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(277, 181, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1153, 131);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lup_SiteType
            // 
            this.lup_SiteType.Location = new System.Drawing.Point(683, 18);
            this.lup_SiteType.Name = "lup_SiteType";
            this.lup_SiteType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lup_SiteType.Properties.Appearance.Options.UseFont = true;
            this.lup_SiteType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lup_SiteType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lup_SiteType.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lup_SiteType.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lup_SiteType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lup_SiteType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PondTypeDesc", "坐席类别")});
            this.lup_SiteType.Properties.DisplayMember = "PondTypeDesc";
            this.lup_SiteType.Properties.NullText = "";
            this.lup_SiteType.Properties.ValueMember = "IntValue";
            this.lup_SiteType.Size = new System.Drawing.Size(199, 36);
            this.lup_SiteType.StyleController = this.layoutControl1;
            this.lup_SiteType.TabIndex = 28;
            // 
            // ch_IsAutoWeight
            // 
            this.ch_IsAutoWeight.Location = new System.Drawing.Point(584, 60);
            this.ch_IsAutoWeight.Margin = new System.Windows.Forms.Padding(5);
            this.ch_IsAutoWeight.Name = "ch_IsAutoWeight";
            this.ch_IsAutoWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_IsAutoWeight.Properties.Appearance.Options.UseFont = true;
            this.ch_IsAutoWeight.Properties.Caption = "自动过磅";
            this.ch_IsAutoWeight.Size = new System.Drawing.Size(533, 33);
            this.ch_IsAutoWeight.StyleController = this.layoutControl1;
            this.ch_IsAutoWeight.TabIndex = 27;
            // 
            // txt_SiteIP2
            // 
            this.txt_SiteIP2.Location = new System.Drawing.Point(380, 60);
            this.txt_SiteIP2.Margin = new System.Windows.Forms.Padding(5);
            this.txt_SiteIP2.Name = "txt_SiteIP2";
            this.txt_SiteIP2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SiteIP2.Properties.Appearance.Options.UseFont = true;
            this.txt_SiteIP2.Size = new System.Drawing.Size(198, 36);
            this.txt_SiteIP2.StyleController = this.layoutControl1;
            this.txt_SiteIP2.TabIndex = 16;
            // 
            // txt_SiteIP1
            // 
            this.txt_SiteIP1.Location = new System.Drawing.Point(117, 60);
            this.txt_SiteIP1.Margin = new System.Windows.Forms.Padding(5);
            this.txt_SiteIP1.Name = "txt_SiteIP1";
            this.txt_SiteIP1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SiteIP1.Properties.Appearance.Options.UseFont = true;
            this.txt_SiteIP1.Size = new System.Drawing.Size(158, 36);
            this.txt_SiteIP1.StyleController = this.layoutControl1;
            this.txt_SiteIP1.TabIndex = 9;
            // 
            // txt_SiteAddress
            // 
            this.txt_SiteAddress.Location = new System.Drawing.Point(987, 18);
            this.txt_SiteAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txt_SiteAddress.Name = "txt_SiteAddress";
            this.txt_SiteAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SiteAddress.Properties.Appearance.Options.UseFont = true;
            this.txt_SiteAddress.Size = new System.Drawing.Size(130, 36);
            this.txt_SiteAddress.StyleController = this.layoutControl1;
            this.txt_SiteAddress.TabIndex = 13;
            // 
            // txt_SiteName
            // 
            this.txt_SiteName.Location = new System.Drawing.Point(380, 18);
            this.txt_SiteName.Margin = new System.Windows.Forms.Padding(5);
            this.txt_SiteName.Name = "txt_SiteName";
            this.txt_SiteName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SiteName.Properties.Appearance.Options.UseFont = true;
            this.txt_SiteName.Size = new System.Drawing.Size(198, 36);
            this.txt_SiteName.StyleController = this.layoutControl1;
            this.txt_SiteName.TabIndex = 11;
            // 
            // txt_SiteNo
            // 
            this.txt_SiteNo.Location = new System.Drawing.Point(117, 18);
            this.txt_SiteNo.Margin = new System.Windows.Forms.Padding(5);
            this.txt_SiteNo.Name = "txt_SiteNo";
            this.txt_SiteNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SiteNo.Properties.Appearance.Options.UseFont = true;
            this.txt_SiteNo.Size = new System.Drawing.Size(158, 36);
            this.txt_SiteNo.StyleController = this.layoutControl1;
            this.txt_SiteNo.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1153, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_SiteNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(263, 42);
            this.layoutControlItem1.Text = "坐席编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 29);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_SiteName;
            this.layoutControlItem2.Location = new System.Drawing.Point(263, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(303, 42);
            this.layoutControlItem2.Text = "坐席名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 29);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1105, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(18, 101);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_SiteAddress;
            this.layoutControlItem4.Location = new System.Drawing.Point(870, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(235, 42);
            this.layoutControlItem4.Text = "坐席地址";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 29);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_SiteIP1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(263, 59);
            this.layoutControlItem5.Text = "IP地址1";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(96, 29);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.txt_SiteIP2;
            this.layoutControlItem6.Location = new System.Drawing.Point(263, 42);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(303, 59);
            this.layoutControlItem6.Text = "IP地址2";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(96, 29);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.ch_IsAutoWeight;
            this.layoutControlItem8.Location = new System.Drawing.Point(566, 42);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(539, 59);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.lup_SiteType;
            this.layoutControlItem9.Location = new System.Drawing.Point(566, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(304, 42);
            this.layoutControlItem9.Text = "坐席类别";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(96, 29);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Refresh,
            this.btn_Add,
            this.btn_update,
            this.btn_Confirm,
            this.btn_Cancel,
            this.btn_Delete});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 137);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.gToolStrip1.Size = new System.Drawing.Size(1159, 53);
            this.gToolStrip1.TabIndex = 11;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(89, 50);
            this.btn_Refresh.Text = "查询";
            this.btn_Refresh.Visible = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(89, 50);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(89, 50);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(89, 50);
            this.btn_Confirm.Text = "确认";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 50);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(89, 50);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gcl_main.Location = new System.Drawing.Point(0, 190);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(5);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(1159, 385);
            this.gcl_main.TabIndex = 16;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.siteId,
            this.siteName,
            this.siteType,
            this.siteIp1,
            this.siteIp2,
            this.siteLevel,
            this.IsAutoWeigh,
            this.siteLocation,
            this.createUser,
            this.createTime,
            this.updateUser,
            this.updateTime});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            // 
            // siteId
            // 
            this.siteId.Caption = "坐席编号";
            this.siteId.FieldName = "siteId";
            this.siteId.Name = "siteId";
            this.siteId.Visible = true;
            this.siteId.VisibleIndex = 0;
            this.siteId.Width = 124;
            // 
            // siteName
            // 
            this.siteName.Caption = "坐席名称";
            this.siteName.FieldName = "siteName";
            this.siteName.Name = "siteName";
            this.siteName.Visible = true;
            this.siteName.VisibleIndex = 1;
            this.siteName.Width = 111;
            // 
            // siteType
            // 
            this.siteType.Caption = "坐席类别";
            this.siteType.FieldName = "siteType.PondTypeDesc";
            this.siteType.Name = "siteType";
            this.siteType.Visible = true;
            this.siteType.VisibleIndex = 2;
            this.siteType.Width = 124;
            // 
            // siteIp1
            // 
            this.siteIp1.Caption = "坐席IP地址1";
            this.siteIp1.FieldName = "siteIp1";
            this.siteIp1.Name = "siteIp1";
            this.siteIp1.Visible = true;
            this.siteIp1.VisibleIndex = 3;
            this.siteIp1.Width = 157;
            // 
            // siteIp2
            // 
            this.siteIp2.Caption = "坐席IP地址2";
            this.siteIp2.FieldName = "siteIp2";
            this.siteIp2.Name = "siteIp2";
            this.siteIp2.Visible = true;
            this.siteIp2.VisibleIndex = 4;
            this.siteIp2.Width = 143;
            // 
            // siteLevel
            // 
            this.siteLevel.Caption = "优先级";
            this.siteLevel.FieldName = "siteLevel";
            this.siteLevel.Name = "siteLevel";
            // 
            // IsAutoWeigh
            // 
            this.IsAutoWeigh.Caption = "是否自动过磅";
            this.IsAutoWeigh.FieldName = "IsAutoWeigh.EntityDes";
            this.IsAutoWeigh.Name = "IsAutoWeigh";
            this.IsAutoWeigh.Visible = true;
            this.IsAutoWeigh.VisibleIndex = 5;
            // 
            // siteLocation
            // 
            this.siteLocation.Caption = "坐席地址";
            this.siteLocation.FieldName = "siteLocation";
            this.siteLocation.Name = "siteLocation";
            this.siteLocation.Visible = true;
            this.siteLocation.VisibleIndex = 6;
            // 
            // createUser
            // 
            this.createUser.Caption = "新增人员";
            this.createUser.FieldName = "createUser";
            this.createUser.Name = "createUser";
            this.createUser.Visible = true;
            this.createUser.VisibleIndex = 7;
            // 
            // createTime
            // 
            this.createTime.Caption = "新增时间";
            this.createTime.DisplayFormat.FormatString = "G";
            this.createTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.createTime.FieldName = "createTime";
            this.createTime.Name = "createTime";
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 8;
            // 
            // updateUser
            // 
            this.updateUser.Caption = "修改人员";
            this.updateUser.FieldName = "updateUser";
            this.updateUser.Name = "updateUser";
            this.updateUser.Visible = true;
            this.updateUser.VisibleIndex = 9;
            // 
            // updateTime
            // 
            this.updateTime.Caption = "修改时间";
            this.updateTime.DisplayFormat.FormatString = "G";
            this.updateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.updateTime.FieldName = "updateTime";
            this.updateTime.Name = "updateTime";
            this.updateTime.Visible = true;
            this.updateTime.VisibleIndex = 10;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SM_Site_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 575);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SM_Site_Form";
            this.Text = "坐席基础信息管理";
            this.Shown += new System.EventHandler(this.SM_Site_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lup_SiteType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_IsAutoWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteIP2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteIP1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SiteNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckEdit ch_IsAutoWeight;
        private DevExpress.XtraEditors.TextEdit txt_SiteIP2;
        private DevExpress.XtraEditors.TextEdit txt_SiteIP1;
        private DevExpress.XtraEditors.TextEdit txt_SiteAddress;
        private DevExpress.XtraEditors.TextEdit txt_SiteName;
        private DevExpress.XtraEditors.TextEdit txt_SiteNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_Confirm;
        private Core.Helper.GToolStripButton btn_Cancel;
        private Core.Helper.GToolStripButton btn_Delete;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn siteId;
        private DevExpress.XtraGrid.Columns.GridColumn siteName;
        private DevExpress.XtraGrid.Columns.GridColumn siteType;
        private DevExpress.XtraGrid.Columns.GridColumn siteIp1;
        private DevExpress.XtraGrid.Columns.GridColumn siteIp2;
        private DevExpress.XtraGrid.Columns.GridColumn siteLevel;
        private DevExpress.XtraGrid.Columns.GridColumn IsAutoWeigh;
        private DevExpress.XtraGrid.Columns.GridColumn siteLocation;
        private DevExpress.XtraGrid.Columns.GridColumn createUser;
        private DevExpress.XtraGrid.Columns.GridColumn createTime;
        private DevExpress.XtraGrid.Columns.GridColumn updateUser;
        private DevExpress.XtraGrid.Columns.GridColumn updateTime;
        private Core.Helper.GToolStripButton btn_Refresh;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LookUpEdit lup_SiteType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}