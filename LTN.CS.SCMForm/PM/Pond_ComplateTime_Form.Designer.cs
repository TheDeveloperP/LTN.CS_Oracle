namespace LTN.CS.SCMForm.PM
{
    partial class Pond_ComplateTime_Form
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
            this.txt_CarName = new DevExpress.XtraEditors.TextEdit();
            this.slu_pondname = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PoundSiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PoundSiteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.de_endtime = new DevExpress.XtraEditors.DateEdit();
            this.de_starttime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pondSiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.carName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.startTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.endTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pondTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_export = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(953, 64);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_CarName);
            this.layoutControl1.Controls.Add(this.slu_pondname);
            this.layoutControl1.Controls.Add(this.de_endtime);
            this.layoutControl1.Controls.Add(this.de_starttime);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(949, 60);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CarName
            // 
            this.txt_CarName.Location = new System.Drawing.Point(659, 12);
            this.txt_CarName.Name = "txt_CarName";
            this.txt_CarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CarName.Properties.Appearance.Options.UseFont = true;
            this.txt_CarName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CarName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_CarName.Size = new System.Drawing.Size(60, 26);
            this.txt_CarName.StyleController = this.layoutControl1;
            this.txt_CarName.TabIndex = 4;
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
            this.slu_pondname.Size = new System.Drawing.Size(83, 26);
            this.slu_pondname.StyleController = this.layoutControl1;
            this.slu_pondname.TabIndex = 0;
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
            // de_endtime
            // 
            this.de_endtime.EditValue = null;
            this.de_endtime.Location = new System.Drawing.Point(452, 12);
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
            this.de_endtime.Size = new System.Drawing.Size(136, 26);
            this.de_endtime.StyleController = this.layoutControl1;
            this.de_endtime.TabIndex = 3;
            // 
            // de_starttime
            // 
            this.de_starttime.EditValue = null;
            this.de_starttime.Location = new System.Drawing.Point(233, 12);
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
            this.de_starttime.Size = new System.Drawing.Size(148, 26);
            this.de_starttime.StyleController = this.layoutControl1;
            this.de_starttime.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(949, 60);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(919, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.slu_pondname;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(154, 40);
            this.layoutControlItem3.Text = "站点名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_CarName;
            this.layoutControlItem4.CustomizationFormText = "车牌号";
            this.layoutControlItem4.Location = new System.Drawing.Point(580, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(131, 40);
            this.layoutControlItem4.Text = "车牌号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.de_starttime;
            this.layoutControlItem1.Location = new System.Drawing.Point(154, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(219, 40);
            this.layoutControlItem1.Text = "开始时间";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.de_endtime;
            this.layoutControlItem2.Location = new System.Drawing.Point(373, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(207, 40);
            this.layoutControlItem2.Text = "结束时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.Location = new System.Drawing.Point(0, 106);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(953, 583);
            this.gcl_main.TabIndex = 2;
            this.gcl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.pondSiteNo,
            this.carName,
            this.startTime,
            this.endTime,
            this.pondTime});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.GroupPanelText = "过磅时长信息";
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // pondSiteNo
            // 
            this.pondSiteNo.Caption = "磅点名称";
            this.pondSiteNo.FieldName = "pondSiteNo";
            this.pondSiteNo.Name = "pondSiteNo";
            this.pondSiteNo.Visible = true;
            this.pondSiteNo.VisibleIndex = 0;
            this.pondSiteNo.Width = 161;
            // 
            // carName
            // 
            this.carName.Caption = "车牌号";
            this.carName.FieldName = "carName";
            this.carName.Name = "carName";
            this.carName.Visible = true;
            this.carName.VisibleIndex = 1;
            this.carName.Width = 161;
            // 
            // startTime
            // 
            this.startTime.Caption = "上磅时间";
            this.startTime.FieldName = "startTime";
            this.startTime.Name = "startTime";
            this.startTime.Visible = true;
            this.startTime.VisibleIndex = 2;
            this.startTime.Width = 257;
            // 
            // endTime
            // 
            this.endTime.Caption = "下磅时间";
            this.endTime.FieldName = "endTime";
            this.endTime.Name = "endTime";
            this.endTime.Visible = true;
            this.endTime.VisibleIndex = 3;
            this.endTime.Width = 257;
            // 
            // pondTime
            // 
            this.pondTime.Caption = "过磅时长";
            this.pondTime.FieldName = "pondTime";
            this.pondTime.Name = "pondTime";
            this.pondTime.Visible = true;
            this.pondTime.VisibleIndex = 4;
            this.pondTime.Width = 120;
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
            this.btn_export.Image = global::LTN.CS.SCMForm.Properties.Resources.Excel2_32;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(60, 39);
            this.btn_export.Text = "导出";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
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
            this.gToolStrip1.Size = new System.Drawing.Size(953, 42);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(790, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(137, 26);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.textEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(711, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(208, 40);
            this.layoutControlItem5.Text = "平均时长";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 19);
            // 
            // Pond_ComplateTime_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 689);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Pond_ComplateTime_Form";
            this.Text = "过磅时长统计页面";
            this.Shown += new System.EventHandler(this.Pond_ComplateTime_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txt_CarName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn PoundSiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn PoundSiteName;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn pondSiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn carName;
        private DevExpress.XtraGrid.Columns.GridColumn startTime;
        private DevExpress.XtraGrid.Columns.GridColumn endTime;
        private DevExpress.XtraGrid.Columns.GridColumn pondTime;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private Core.Helper.GToolStripButton btn_query;
        private Core.Helper.GToolStripButton btn_export;
        private Core.Helper.GToolStrip gToolStrip1;
    }
}