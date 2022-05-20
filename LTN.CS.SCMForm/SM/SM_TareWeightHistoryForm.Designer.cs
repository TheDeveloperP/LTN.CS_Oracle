namespace LTN.CS.SCMForm.SM
{
    partial class SM_TareWeightHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_TareWeightHistoryForm));
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HistoryTare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PondSiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PondSiteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_PoundNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_PoundName = new DevExpress.XtraEditors.TextEdit();
            this.txt_tare = new DevExpress.XtraEditors.TextEdit();
            this.txt_CarName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.de_endTime = new DevExpress.XtraEditors.DateEdit();
            this.de_startTime = new DevExpress.XtraEditors.DateEdit();
            this.txt_CarNamequery = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_fresh = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_export = new LTN.CS.Core.Helper.GToolStripButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btn_ToUse = new LTN.CS.Core.Helper.GToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PoundNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PoundName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_endTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_startTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_startTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNamequery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Location = new System.Drawing.Point(0, 183);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(4);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(1028, 400);
            this.gcl_main.TabIndex = 24;
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
            this.IntId,
            this.CarName,
            this.HistoryTare,
            this.PondSiteNo,
            this.PondSiteName,
            this.CreateUserName,
            this.CreateTime});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsCustomization.AllowFilter = false;
            this.gvw_main.OptionsCustomization.AllowSort = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowFooter = true;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.OptionsView.ShowViewCaption = true;
            this.gvw_main.ViewCaption = "汽车磅历史皮重库";
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            // 
            // CarName
            // 
            this.CarName.Caption = "实际车牌";
            this.CarName.FieldName = "CarName";
            this.CarName.Name = "CarName";
            this.CarName.OptionsColumn.AllowEdit = false;
            this.CarName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "realcarrierno", "{0}")});
            this.CarName.Visible = true;
            this.CarName.VisibleIndex = 0;
            this.CarName.Width = 157;
            // 
            // HistoryTare
            // 
            this.HistoryTare.Caption = "皮重(kg)";
            this.HistoryTare.FieldName = "HistoryTare";
            this.HistoryTare.Name = "HistoryTare";
            this.HistoryTare.OptionsColumn.AllowEdit = false;
            this.HistoryTare.Visible = true;
            this.HistoryTare.VisibleIndex = 1;
            this.HistoryTare.Width = 170;
            // 
            // PondSiteNo
            // 
            this.PondSiteNo.Caption = "磅点编号";
            this.PondSiteNo.FieldName = "SiteNo";
            this.PondSiteNo.Name = "PondSiteNo";
            this.PondSiteNo.Visible = true;
            this.PondSiteNo.VisibleIndex = 2;
            this.PondSiteNo.Width = 110;
            // 
            // PondSiteName
            // 
            this.PondSiteName.Caption = "磅点名称";
            this.PondSiteName.FieldName = "SiteName";
            this.PondSiteName.Name = "PondSiteName";
            this.PondSiteName.Visible = true;
            this.PondSiteName.VisibleIndex = 3;
            this.PondSiteName.Width = 210;
            // 
            // CreateUserName
            // 
            this.CreateUserName.Caption = "新增人";
            this.CreateUserName.FieldName = "CreateUserName";
            this.CreateUserName.Name = "CreateUserName";
            this.CreateUserName.Visible = true;
            this.CreateUserName.VisibleIndex = 4;
            this.CreateUserName.Width = 122;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "d";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CREATETIME";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 5;
            this.CreateTime.Width = 240;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_PoundNo);
            this.layoutControl1.Controls.Add(this.txt_PoundName);
            this.layoutControl1.Controls.Add(this.txt_tare);
            this.layoutControl1.Controls.Add(this.txt_CarName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 26);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 334, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(706, 113);
            this.layoutControl1.TabIndex = 22;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_PoundNo
            // 
            this.txt_PoundNo.Location = new System.Drawing.Point(251, 12);
            this.txt_PoundNo.Name = "txt_PoundNo";
            this.txt_PoundNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_PoundNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PoundNo.Size = new System.Drawing.Size(100, 26);
            this.txt_PoundNo.StyleController = this.layoutControl1;
            this.txt_PoundNo.TabIndex = 10;
            // 
            // txt_PoundName
            // 
            this.txt_PoundName.Location = new System.Drawing.Point(251, 42);
            this.txt_PoundName.Name = "txt_PoundName";
            this.txt_PoundName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_PoundName.Properties.Appearance.Options.UseFont = true;
            this.txt_PoundName.Size = new System.Drawing.Size(100, 26);
            this.txt_PoundName.StyleController = this.layoutControl1;
            this.txt_PoundName.TabIndex = 11;
            // 
            // txt_tare
            // 
            this.txt_tare.Location = new System.Drawing.Point(79, 42);
            this.txt_tare.Name = "txt_tare";
            this.txt_tare.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_tare.Properties.Appearance.Options.UseFont = true;
            this.txt_tare.Size = new System.Drawing.Size(101, 26);
            this.txt_tare.StyleController = this.layoutControl1;
            this.txt_tare.TabIndex = 9;
            // 
            // txt_CarName
            // 
            this.txt_CarName.Location = new System.Drawing.Point(79, 12);
            this.txt_CarName.Name = "txt_CarName";
            this.txt_CarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CarName.Properties.Appearance.Options.UseFont = true;
            this.txt_CarName.Size = new System.Drawing.Size(101, 26);
            this.txt_CarName.StyleController = this.layoutControl1;
            this.txt_CarName.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(706, 113);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_CarName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(172, 30);
            this.layoutControlItem2.Text = "车牌号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(343, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(343, 93);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.txt_PoundNo;
            this.layoutControlItem6.Location = new System.Drawing.Point(172, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(171, 30);
            this.layoutControlItem6.Text = "磅点编号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.txt_PoundName;
            this.layoutControlItem7.Location = new System.Drawing.Point(172, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(171, 63);
            this.layoutControlItem7.Text = "磅点名称";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_tare;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(172, 63);
            this.layoutControlItem5.Text = "皮重(kg)";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 19);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(314, 141);
            this.groupControl1.TabIndex = 25;
            this.groupControl1.Text = "查询条件";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.de_endTime);
            this.layoutControl2.Controls.Add(this.de_startTime);
            this.layoutControl2.Controls.Add(this.txt_CarNamequery);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 26);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(310, 113);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // de_endTime
            // 
            this.de_endTime.EditValue = null;
            this.de_endTime.Location = new System.Drawing.Point(79, 72);
            this.de_endTime.Name = "de_endTime";
            this.de_endTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.de_endTime.Properties.Appearance.Options.UseFont = true;
            this.de_endTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_endTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_endTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_endTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_endTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_endTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_endTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.de_endTime.Size = new System.Drawing.Size(219, 26);
            this.de_endTime.StyleController = this.layoutControl2;
            this.de_endTime.TabIndex = 6;
            // 
            // de_startTime
            // 
            this.de_startTime.EditValue = null;
            this.de_startTime.Location = new System.Drawing.Point(79, 42);
            this.de_startTime.Name = "de_startTime";
            this.de_startTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.de_startTime.Properties.Appearance.Options.UseFont = true;
            this.de_startTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_startTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_startTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_startTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_startTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_startTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_startTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.de_startTime.Size = new System.Drawing.Size(219, 26);
            this.de_startTime.StyleController = this.layoutControl2;
            this.de_startTime.TabIndex = 5;
            // 
            // txt_CarNamequery
            // 
            this.txt_CarNamequery.Location = new System.Drawing.Point(79, 12);
            this.txt_CarNamequery.Name = "txt_CarNamequery";
            this.txt_CarNamequery.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarNamequery.Properties.Appearance.Options.UseFont = true;
            this.txt_CarNamequery.Size = new System.Drawing.Size(219, 26);
            this.txt_CarNamequery.StyleController = this.layoutControl2;
            this.txt_CarNamequery.TabIndex = 4;
            this.txt_CarNamequery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CarNamequery_KeyPress);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(310, 113);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_CarNamequery;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(290, 30);
            this.layoutControlItem1.Text = "车牌号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.de_startTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(290, 30);
            this.layoutControlItem3.Text = "开始时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.de_endTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(290, 33);
            this.layoutControlItem4.Text = "结束时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1028, 145);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(316, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(710, 141);
            this.groupControl2.TabIndex = 27;
            this.groupControl2.Text = "数据展示";
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_fresh,
            this.btn_Delete,
            this.btn_export,
            this.btn_ToUse});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 145);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1028, 38);
            this.gToolStrip1.TabIndex = 26;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_fresh
            // 
            this.btn_fresh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_fresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_fresh.Image")));
            this.btn_fresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_fresh.Name = "btn_fresh";
            this.btn_fresh.Size = new System.Drawing.Size(65, 35);
            this.btn_fresh.Text = "查询";
            this.btn_fresh.Click += new System.EventHandler(this.btn_fresh_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(65, 35);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Visible = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(65, 35);
            this.btn_export.Text = "导出";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // btn_ToUse
            // 
            this.btn_ToUse.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_ToUse.Image = global::LTN.CS.SCMForm.Properties.Resources.Weight_unlock_48;
            this.btn_ToUse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ToUse.Name = "btn_ToUse";
            this.btn_ToUse.Size = new System.Drawing.Size(97, 35);
            this.btn_ToUse.Text = "选择皮重";
            this.btn_ToUse.Click += new System.EventHandler(this.btn_ToUse_Click);
            // 
            // SM_TareWeightHistoryForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 583);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "SM_TareWeightHistoryForm";
            this.ShowIcon = false;
            this.Text = "皮重库历史记录";
            this.Shown += new System.EventHandler(this.SM_TareWeightHistoryForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PoundNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PoundName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_endTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_startTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_startTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNamequery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn CarName;
        private DevExpress.XtraGrid.Columns.GridColumn HistoryTare;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_CarName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn PondSiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn PondSiteName;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUserName;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.DateEdit de_endTime;
        private DevExpress.XtraEditors.DateEdit de_startTime;
        private DevExpress.XtraEditors.TextEdit txt_CarNamequery;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_fresh;
        private Core.Helper.GToolStripButton btn_Delete;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.TextEdit txt_PoundNo;
        private DevExpress.XtraEditors.TextEdit txt_PoundName;
        private DevExpress.XtraEditors.TextEdit txt_tare;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private Core.Helper.GToolStripButton btn_export;
        private Core.Helper.GToolStripButton btn_ToUse;
    }
}