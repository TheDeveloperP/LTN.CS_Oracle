namespace LTN.CS.SCMForm.CS
{
    partial class SM_WeightList_InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_WeightList_InfoForm));
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Query = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Export = new LTN.CS.Core.Helper.GToolStripButton();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gCtrl_TruckMeasurePlan = new DevExpress.XtraGrid.GridControl();
            this.gView_TruckMeasurePlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAutoCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ISCREATEMOTHERPONDCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ONETWOPLANCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ContainerCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckMeasurePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckMeasurePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsAutoCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISCREATEMOTHERPONDCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ONETWOPLANCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCheckEdit2)).BeginInit();
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
            this.btn_Export});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 59);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1028, 41);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Query.Image = ((System.Drawing.Image)(resources.GetObject("btn_Query.Image")));
            this.btn_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(68, 38);
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Image = ((System.Drawing.Image)(resources.GetObject("btn_Export.Image")));
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(68, 38);
            this.btn_Export.Text = "导出";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1028, 59);
            this.panelControl1.TabIndex = 4;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-6, 180, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1153, 55);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
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
            this.date_StartTime.Size = new System.Drawing.Size(207, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 6;
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(367, 12);
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
            this.date_EndTime.Size = new System.Drawing.Size(208, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1153, 55);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.date_StartTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(283, 35);
            this.layoutControlItem3.Text = "开始时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_EndTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(283, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(284, 35);
            this.layoutControlItem4.Text = "结束时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 21);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(567, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(566, 35);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gCtrl_TruckMeasurePlan
            // 
            this.gCtrl_TruckMeasurePlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_TruckMeasurePlan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_TruckMeasurePlan.Location = new System.Drawing.Point(0, 100);
            this.gCtrl_TruckMeasurePlan.MainView = this.gView_TruckMeasurePlan;
            this.gCtrl_TruckMeasurePlan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_TruckMeasurePlan.Name = "gCtrl_TruckMeasurePlan";
            this.gCtrl_TruckMeasurePlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.IsAutoCheckEdit1,
            this.ISCREATEMOTHERPONDCheckEdit1,
            this.ONETWOPLANCheckEdit1,
            this.ContainerCheckEdit2});
            this.gCtrl_TruckMeasurePlan.Size = new System.Drawing.Size(1028, 483);
            this.gCtrl_TruckMeasurePlan.TabIndex = 5;
            this.gCtrl_TruckMeasurePlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_TruckMeasurePlan});
            // 
            // gView_TruckMeasurePlan
            // 
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gView_TruckMeasurePlan.GridControl = this.gCtrl_TruckMeasurePlan;
            this.gView_TruckMeasurePlan.GroupPanelText = " ";
            this.gView_TruckMeasurePlan.Name = "gView_TruckMeasurePlan";
            this.gView_TruckMeasurePlan.OptionsBehavior.Editable = false;
            this.gView_TruckMeasurePlan.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gView_TruckMeasurePlan.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gView_TruckMeasurePlan.OptionsSelection.MultiSelect = true;
            this.gView_TruckMeasurePlan.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gView_TruckMeasurePlan.OptionsView.ColumnAutoWidth = false;
            this.gView_TruckMeasurePlan.OptionsView.ShowFooter = true;
            this.gView_TruckMeasurePlan.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gView_TruckMeasurePlan_CustomColumnDisplayText);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "司磅员姓名";
            this.gridColumn1.FieldName = "weightName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "毛重过磅量";
            this.gridColumn2.FieldName = "grossNum";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grossNum", "{0:0.##}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "皮重过磅量";
            this.gridColumn3.FieldName = "tareNum";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tareNum", "{0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 118;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "总量";
            this.gridColumn4.FieldName = "totalNum";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalNum", "{0:0.##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 123;
            // 
            // IsAutoCheckEdit1
            // 
            this.IsAutoCheckEdit1.AutoHeight = false;
            this.IsAutoCheckEdit1.Name = "IsAutoCheckEdit1";
            this.IsAutoCheckEdit1.ValueChecked = 1;
            this.IsAutoCheckEdit1.ValueUnchecked = 0;
            // 
            // ISCREATEMOTHERPONDCheckEdit1
            // 
            this.ISCREATEMOTHERPONDCheckEdit1.AutoHeight = false;
            this.ISCREATEMOTHERPONDCheckEdit1.Name = "ISCREATEMOTHERPONDCheckEdit1";
            this.ISCREATEMOTHERPONDCheckEdit1.ValueChecked = 1;
            this.ISCREATEMOTHERPONDCheckEdit1.ValueUnchecked = 0;
            // 
            // ONETWOPLANCheckEdit1
            // 
            this.ONETWOPLANCheckEdit1.AutoHeight = false;
            this.ONETWOPLANCheckEdit1.Name = "ONETWOPLANCheckEdit1";
            this.ONETWOPLANCheckEdit1.ValueChecked = 1;
            this.ONETWOPLANCheckEdit1.ValueUnchecked = 0;
            // 
            // ContainerCheckEdit2
            // 
            this.ContainerCheckEdit2.AutoHeight = false;
            this.ContainerCheckEdit2.Name = "ContainerCheckEdit2";
            this.ContainerCheckEdit2.ValueChecked = 1;
            this.ContainerCheckEdit2.ValueUnchecked = 0;
            // 
            // SM_WeightList_InfoForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 583);
            this.Controls.Add(this.gCtrl_TruckMeasurePlan);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "SM_WeightList_InfoForm";
            this.ShowIcon = false;
            this.Text = "司磅工作量统计";
            this.Shown += new System.EventHandler(this.IT_TruckMeasurePlan_Form_Shown);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckMeasurePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckMeasurePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsAutoCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISCREATEMOTHERPONDCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ONETWOPLANCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Core.Helper.GToolStrip gToolStrip1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Core.Helper.GToolStripButton btn_Query;
        private Core.Helper.GToolStripButton btn_Export;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gCtrl_TruckMeasurePlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_TruckMeasurePlan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit IsAutoCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ISCREATEMOTHERPONDCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ONETWOPLANCheckEdit1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ContainerCheckEdit2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}