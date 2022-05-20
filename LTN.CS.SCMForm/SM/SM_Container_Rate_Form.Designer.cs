namespace LTN.CS.SCMForm.SM
{
    partial class SM_Container_Rate_Form
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
            this.txt_ContainerNo = new DevExpress.XtraEditors.TextEdit();
            this.slu_pondname = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.de_endtime = new DevExpress.XtraEditors.DateEdit();
            this.de_starttime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gCtrl_main = new DevExpress.XtraGrid.GridControl();
            this.gView_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_ContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_PlanContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_ContainerTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.I_RecognitionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_PondNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CreateUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PoundSiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PoundSiteName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ContainerNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slu_pondname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_main)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(915, 64);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_ContainerNo);
            this.layoutControl1.Controls.Add(this.slu_pondname);
            this.layoutControl1.Controls.Add(this.de_endtime);
            this.layoutControl1.Controls.Add(this.de_starttime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(911, 60);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_ContainerNo
            // 
            this.txt_ContainerNo.Location = new System.Drawing.Point(835, 12);
            this.txt_ContainerNo.Name = "txt_ContainerNo";
            this.txt_ContainerNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_ContainerNo.Properties.Appearance.Options.UseFont = true;
            this.txt_ContainerNo.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_ContainerNo.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_ContainerNo.Size = new System.Drawing.Size(50, 26);
            this.txt_ContainerNo.StyleController = this.layoutControl1;
            this.txt_ContainerNo.TabIndex = 7;
            this.txt_ContainerNo.Visible = false;
            // 
            // slu_pondname
            // 
            this.slu_pondname.EditValue = "";
            this.slu_pondname.Location = new System.Drawing.Point(79, 12);
            this.slu_pondname.Name = "slu_pondname";
            this.slu_pondname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.slu_pondname.Properties.Appearance.Options.UseFont = true;
            this.slu_pondname.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.slu_pondname.Properties.AppearanceDropDown.Options.UseFont = true;
            this.slu_pondname.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.slu_pondname.Properties.AppearanceFocused.Options.UseFont = true;
            this.slu_pondname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slu_pondname.Properties.DisplayMember = "PoundSiteName";
            this.slu_pondname.Properties.NullText = "";
            this.slu_pondname.Properties.ValueMember = "PoundSiteNo";
            this.slu_pondname.Properties.View = this.searchLookUpEdit1View;
            this.slu_pondname.Size = new System.Drawing.Size(149, 26);
            this.slu_pondname.StyleController = this.layoutControl1;
            this.slu_pondname.TabIndex = 6;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PoundSiteNo,
            this.PoundSiteName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // de_endtime
            // 
            this.de_endtime.EditValue = null;
            this.de_endtime.Location = new System.Drawing.Point(558, 12);
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
            this.de_endtime.Size = new System.Drawing.Size(206, 26);
            this.de_endtime.StyleController = this.layoutControl1;
            this.de_endtime.TabIndex = 5;
            // 
            // de_starttime
            // 
            this.de_starttime.EditValue = null;
            this.de_starttime.Location = new System.Drawing.Point(299, 12);
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
            this.de_starttime.Size = new System.Drawing.Size(188, 26);
            this.de_starttime.StyleController = this.layoutControl1;
            this.de_starttime.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(911, 60);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(877, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(14, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.slu_pondname;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(220, 40);
            this.layoutControlItem3.Text = "站点名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_ContainerNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(756, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(121, 40);
            this.layoutControlItem4.Text = "集装箱号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.de_starttime;
            this.layoutControlItem1.Location = new System.Drawing.Point(220, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(259, 40);
            this.layoutControlItem1.Text = "开始时间";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.de_endtime;
            this.layoutControlItem2.Location = new System.Drawing.Point(479, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(277, 40);
            this.layoutControlItem2.Text = "结束时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 64);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(915, 32);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_query
            // 
            this.btn_query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(56, 29);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // gCtrl_main
            // 
            this.gCtrl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_main.Location = new System.Drawing.Point(0, 0);
            this.gCtrl_main.MainView = this.gView_main;
            this.gCtrl_main.Name = "gCtrl_main";
            this.gCtrl_main.Size = new System.Drawing.Size(360, 587);
            this.gCtrl_main.TabIndex = 2;
            this.gCtrl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_main});
            // 
            // gView_main
            // 
            this.gView_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gView_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gView_main.Appearance.Row.Options.UseFont = true;
            this.gView_main.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gView_main.Appearance.SelectedRow.Options.UseFont = true;
            this.gView_main.GridControl = this.gCtrl_main;
            this.gView_main.Name = "gView_main";
            this.gView_main.OptionsBehavior.Editable = false;
            this.gView_main.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 96);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 593);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcl_main);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 587);
            this.panel1.TabIndex = 3;
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.gcl_main.Location = new System.Drawing.Point(0, 0);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(543, 587);
            this.gcl_main.TabIndex = 16;
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
            this.IntId,
            this.C_ContainerNo,
            this.C_PlanContainerNo,
            this.C_ContainerTime,
            this.I_RecognitionStatus,
            this.C_PondNo,
            this.C_CreateTime,
            this.C_CreateUserName});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsBehavior.ReadOnly = true;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            this.IntId.Width = 115;
            // 
            // C_ContainerNo
            // 
            this.C_ContainerNo.Caption = "识别集装箱号";
            this.C_ContainerNo.FieldName = "C_ContainerNo";
            this.C_ContainerNo.Name = "C_ContainerNo";
            this.C_ContainerNo.Visible = true;
            this.C_ContainerNo.VisibleIndex = 1;
            this.C_ContainerNo.Width = 123;
            // 
            // C_PlanContainerNo
            // 
            this.C_PlanContainerNo.Caption = "委托集装箱号";
            this.C_PlanContainerNo.FieldName = "C_PlanContainerNo";
            this.C_PlanContainerNo.Name = "C_PlanContainerNo";
            this.C_PlanContainerNo.Visible = true;
            this.C_PlanContainerNo.VisibleIndex = 2;
            this.C_PlanContainerNo.Width = 136;
            // 
            // C_ContainerTime
            // 
            this.C_ContainerTime.Caption = "集装箱号识别时间";
            this.C_ContainerTime.FieldName = "C_ContainerTime";
            this.C_ContainerTime.Name = "C_ContainerTime";
            this.C_ContainerTime.Visible = true;
            this.C_ContainerTime.VisibleIndex = 4;
            this.C_ContainerTime.Width = 141;
            // 
            // I_RecognitionStatus
            // 
            this.I_RecognitionStatus.Caption = "识别结果";
            this.I_RecognitionStatus.FieldName = "I_RecognitionStatus";
            this.I_RecognitionStatus.Name = "I_RecognitionStatus";
            this.I_RecognitionStatus.Visible = true;
            this.I_RecognitionStatus.VisibleIndex = 3;
            this.I_RecognitionStatus.Width = 175;
            // 
            // C_PondNo
            // 
            this.C_PondNo.Caption = "磅点编号";
            this.C_PondNo.FieldName = "C_PondNo";
            this.C_PondNo.Name = "C_PondNo";
            this.C_PondNo.Visible = true;
            this.C_PondNo.VisibleIndex = 0;
            // 
            // C_CreateTime
            // 
            this.C_CreateTime.Caption = "新增时间";
            this.C_CreateTime.FieldName = "C_CreateTime";
            this.C_CreateTime.Name = "C_CreateTime";
            this.C_CreateTime.Visible = true;
            this.C_CreateTime.VisibleIndex = 5;
            // 
            // C_CreateUserName
            // 
            this.C_CreateUserName.Caption = "新增人";
            this.C_CreateUserName.FieldName = "C_CreateUserName";
            this.C_CreateUserName.Name = "C_CreateUserName";
            this.C_CreateUserName.Visible = true;
            this.C_CreateUserName.VisibleIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gCtrl_main);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(552, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 587);
            this.panel2.TabIndex = 4;
            // 
            // PoundSiteNo
            // 
            this.PoundSiteNo.Caption = "磅点编号";
            this.PoundSiteNo.FieldName = "PoundSiteNo";
            this.PoundSiteNo.Name = "PoundSiteNo";
            this.PoundSiteNo.Visible = true;
            this.PoundSiteNo.VisibleIndex = 0;
            // 
            // PoundSiteName
            // 
            this.PoundSiteName.Caption = "磅点名称";
            this.PoundSiteName.FieldName = "PoundSiteName";
            this.PoundSiteName.Name = "PoundSiteName";
            this.PoundSiteName.Visible = true;
            this.PoundSiteName.VisibleIndex = 1;
            // 
            // SM_Container_Rate_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 689);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Name = "SM_Container_Rate_Form";
            this.Text = "集装箱号识别率";
            this.Shown += new System.EventHandler(this.SM_Container_Rate_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ContainerNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slu_pondname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_endtime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_main)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit de_endtime;
        private DevExpress.XtraEditors.DateEdit de_starttime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SearchLookUpEdit slu_pondname;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txt_ContainerNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_query;
        private DevExpress.XtraGrid.GridControl gCtrl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn C_ContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn C_ContainerTime;
        private DevExpress.XtraGrid.Columns.GridColumn C_PlanContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn I_RecognitionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn C_PondNo;
        private DevExpress.XtraGrid.Columns.GridColumn C_CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn C_CreateUserName;
        private DevExpress.XtraGrid.Columns.GridColumn PoundSiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn PoundSiteName;
    }
}