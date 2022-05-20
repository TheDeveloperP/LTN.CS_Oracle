namespace LTN.CS.SCMForm.SM
{
    partial class SM_SiteGrating_Form
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcl_wsq = new DevExpress.XtraGrid.GridControl();
            this.gvw_wsq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcl_ysq = new DevExpress.XtraGrid.GridControl();
            this.gvw_ysq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_wsq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_wsq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_ysq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_ysq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.groupControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1317, 623);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "站点光栅设定";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcl_ysq);
            this.layoutControl1.Controls.Add(this.gcl_wsq);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 42);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1311, 578);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcl_wsq
            // 
            this.gcl_wsq.Location = new System.Drawing.Point(667, 18);
            this.gcl_wsq.MainView = this.gvw_wsq;
            this.gcl_wsq.Name = "gcl_wsq";
            this.gcl_wsq.Size = new System.Drawing.Size(626, 542);
            this.gcl_wsq.TabIndex = 5;
            this.gcl_wsq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_wsq});
            // 
            // gvw_wsq
            // 
            this.gvw_wsq.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_wsq.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_wsq.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_wsq.Appearance.Row.Options.UseFont = true;
            this.gvw_wsq.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_wsq.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_wsq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gvw_wsq.GridControl = this.gcl_wsq;
            this.gvw_wsq.Name = "gvw_wsq";
            this.gvw_wsq.OptionsView.ShowGroupPanel = false;
            this.gvw_wsq.OptionsView.ShowViewCaption = true;
            this.gvw_wsq.ViewCaption = "未授权";
            this.gvw_wsq.DoubleClick += new System.EventHandler(this.gvw_wsq_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "站点编码";
            this.gridColumn3.FieldName = "PoundSiteNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "站点名称";
            this.gridColumn4.FieldName = "PoundSiteName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1311, 578);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcl_wsq;
            this.layoutControlItem2.Location = new System.Drawing.Point(649, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(632, 548);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gcl_ysq
            // 
            this.gcl_ysq.Location = new System.Drawing.Point(18, 18);
            this.gcl_ysq.MainView = this.gvw_ysq;
            this.gcl_ysq.Name = "gcl_ysq";
            this.gcl_ysq.Size = new System.Drawing.Size(628, 542);
            this.gcl_ysq.TabIndex = 6;
            this.gcl_ysq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_ysq});
            this.gcl_ysq.DoubleClick += new System.EventHandler(this.gvw_ysq_DoubleClick);
            // 
            // gvw_ysq
            // 
            this.gvw_ysq.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_ysq.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvw_ysq.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_ysq.Appearance.Row.Options.UseFont = true;
            this.gvw_ysq.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gvw_ysq.Appearance.ViewCaption.Options.UseFont = true;
            this.gvw_ysq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvw_ysq.GridControl = this.gcl_ysq;
            this.gvw_ysq.Name = "gvw_ysq";
            this.gvw_ysq.OptionsView.ShowGroupPanel = false;
            this.gvw_ysq.OptionsView.ShowViewCaption = true;
            this.gvw_ysq.ViewCaption = "已授权";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcl_ysq;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(634, 548);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(634, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(15, 548);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "站点名称";
            this.gridColumn1.FieldName = "PoundSiteName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "站点编码";
            this.gridColumn2.FieldName = "PoundSiteNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // SM_SiteGrating_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 623);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SM_SiteGrating_Form";
            this.Text = "站点光栅设定";
            this.Shown += new System.EventHandler(this.SM_SiteGrating_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_wsq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_wsq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_ysq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_ysq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcl_wsq;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_wsq;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcl_ysq;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_ysq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}