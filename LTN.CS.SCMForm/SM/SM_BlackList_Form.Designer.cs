namespace LTN.CS.SCMForm.SM
{
    partial class SM_BlackList_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_BlackList_Form));
            this.gcl_hty = new DevExpress.XtraGrid.GridControl();
            this.gvw_hty = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SiteType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_fresh = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_CarName = new DevExpress.XtraEditors.TextEdit();
            this.txt_CriminalRecord = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.站点名称 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_hty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_hty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CriminalRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.站点名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcl_hty
            // 
            this.gcl_hty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_hty.Location = new System.Drawing.Point(249, 95);
            this.gcl_hty.MainView = this.gvw_hty;
            this.gcl_hty.Name = "gcl_hty";
            this.gcl_hty.Size = new System.Drawing.Size(745, 439);
            this.gcl_hty.TabIndex = 21;
            this.gcl_hty.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_hty});
            // 
            // gvw_hty
            // 
            this.gvw_hty.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_hty.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_hty.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvw_hty.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_hty.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_hty.Appearance.Row.Options.UseFont = true;
            this.gvw_hty.Appearance.Row.Options.UseTextOptions = true;
            this.gvw_hty.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_hty.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_hty.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_hty.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn7});
            this.gvw_hty.GridControl = this.gcl_hty;
            this.gvw_hty.Name = "gvw_hty";
            this.gvw_hty.OptionsBehavior.Editable = false;
            this.gvw_hty.OptionsView.ColumnAutoWidth = false;
            this.gvw_hty.OptionsView.ShowFooter = true;
            this.gvw_hty.OptionsView.ShowGroupPanel = false;
            this.gvw_hty.OptionsView.ShowViewCaption = true;
            this.gvw_hty.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvw_hty.ViewCaption = "历史记录";
            this.gvw_hty.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_hty_CustomDrawCell);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "车牌";
            this.gridColumn5.FieldName = "CarName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "realcarrierno", "{0}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 141;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "操作记录";
            this.gridColumn8.FieldName = "OperationRecord";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 316;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "修改人";
            this.gridColumn6.FieldName = "UpdateUserName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 160;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "修改时间";
            this.gridColumn7.DisplayFormat.FormatString = "d";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "UPDATETIME";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 164;
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Location = new System.Drawing.Point(0, 95);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(249, 439);
            this.gcl_main.TabIndex = 20;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.GroupFooter.Options.UseFont = true;
            this.gvw_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_main.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvw_main.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.Row.Options.UseFont = true;
            this.gvw_main.Appearance.Row.Options.UseTextOptions = true;
            this.gvw_main.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvw_main.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_main.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SiteNo,
            this.SiteType});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsCustomization.AllowFilter = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowFooter = true;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.OptionsView.ShowViewCaption = true;
            this.gvw_main.ViewCaption = "黑名单车辆";
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            this.gvw_main.DoubleClick += new System.EventHandler(this.gvw_main_DoubleClick);
            // 
            // SiteNo
            // 
            this.SiteNo.Caption = "实际车牌";
            this.SiteNo.FieldName = "CarName";
            this.SiteNo.Name = "SiteNo";
            this.SiteNo.OptionsColumn.AllowEdit = false;
            this.SiteNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "realcarrierno", "{0}")});
            this.SiteNo.Visible = true;
            this.SiteNo.VisibleIndex = 0;
            this.SiteNo.Width = 117;
            // 
            // SiteType
            // 
            this.SiteType.Caption = "违规记录";
            this.SiteType.FieldName = "CriminalRecord";
            this.SiteType.Name = "SiteType";
            this.SiteType.OptionsColumn.AllowEdit = false;
            this.SiteType.Visible = true;
            this.SiteType.VisibleIndex = 1;
            this.SiteType.Width = 140;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_fresh,
            this.btn_Add,
            this.btn_Confirm,
            this.btn_Cancel,
            this.btn_Delete});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 57);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(994, 38);
            this.gToolStrip1.TabIndex = 19;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_fresh
            // 
            this.btn_fresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_fresh.Image")));
            this.btn_fresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_fresh.Name = "btn_fresh";
            this.btn_fresh.Size = new System.Drawing.Size(72, 35);
            this.btn_fresh.Text = "查询";
            this.btn_fresh.Click += new System.EventHandler(this.btn_fresh_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(72, 35);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(72, 35);
            this.btn_Confirm.Text = "确认";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 35);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(72, 35);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_CarName);
            this.layoutControl1.Controls.Add(this.txt_CriminalRecord);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 334, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(994, 57);
            this.layoutControl1.TabIndex = 18;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CarName
            // 
            this.txt_CarName.Location = new System.Drawing.Point(87, 12);
            this.txt_CarName.Name = "txt_CarName";
            this.txt_CarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_CarName.Properties.Appearance.Options.UseFont = true;
            this.txt_CarName.Size = new System.Drawing.Size(162, 28);
            this.txt_CarName.StyleController = this.layoutControl1;
            this.txt_CarName.TabIndex = 8;
            // 
            // txt_CriminalRecord
            // 
            this.txt_CriminalRecord.Location = new System.Drawing.Point(328, 12);
            this.txt_CriminalRecord.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CriminalRecord.Name = "txt_CriminalRecord";
            this.txt_CriminalRecord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_CriminalRecord.Properties.Appearance.Options.UseFont = true;
            this.txt_CriminalRecord.Size = new System.Drawing.Size(196, 28);
            this.txt_CriminalRecord.StyleController = this.layoutControl1;
            this.txt_CriminalRecord.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.站点名称});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(994, 57);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(516, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(458, 37);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_CarName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(241, 37);
            this.layoutControlItem2.Text = "实际车牌";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 站点名称
            // 
            this.站点名称.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.站点名称.AppearanceItemCaption.Options.UseFont = true;
            this.站点名称.Control = this.txt_CriminalRecord;
            this.站点名称.CustomizationFormText = "layoutControlItem3";
            this.站点名称.Location = new System.Drawing.Point(241, 0);
            this.站点名称.Name = "站点名称";
            this.站点名称.Size = new System.Drawing.Size(275, 37);
            this.站点名称.Text = "违规记录";
            this.站点名称.TextSize = new System.Drawing.Size(72, 22);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SM_BlackList_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 534);
            this.Controls.Add(this.gcl_hty);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "SM_BlackList_Form";
            this.Text = "黑名单管理";
            this.Shown += new System.EventHandler(this.SM_BlackList_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_hty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_hty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CriminalRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.站点名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcl_hty;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_hty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn 计量车牌;
        private DevExpress.XtraGrid.Columns.GridColumn SiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn SiteType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_fresh;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_Confirm;
        private Core.Helper.GToolStripButton btn_Cancel;
        private Core.Helper.GToolStripButton btn_Delete;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_CarName;
        private DevExpress.XtraEditors.TextEdit txt_CriminalRecord;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem 站点名称;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}