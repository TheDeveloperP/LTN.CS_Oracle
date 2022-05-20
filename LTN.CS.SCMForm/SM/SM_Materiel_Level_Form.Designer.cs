namespace LTN.CS.SCMForm.SM
{
    partial class SM_Materiel_Level_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_Materiel_Level_Form));
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterielCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterielName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_LevelModel = new DevExpress.XtraEditors.TextEdit();
            this.txt_LevelSpec = new DevExpress.XtraEditors.TextEdit();
            this.txt_LevelName = new DevExpress.XtraEditors.TextEdit();
            this.txt_LevelCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelSpec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcl_main.Location = new System.Drawing.Point(0, 87);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(2);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(824, 447);
            this.gcl_main.TabIndex = 21;
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
            this.MaterielCode,
            this.MaterielName,
            this.gridColumn1,
            this.gridColumn2,
            this.CreateUser,
            this.CreateTime,
            this.UpdateUser,
            this.UpdateTime});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CreateTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvw_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            // 
            // MaterielCode
            // 
            this.MaterielCode.Caption = "物料编码";
            this.MaterielCode.FieldName = "MaterielCode";
            this.MaterielCode.Name = "MaterielCode";
            this.MaterielCode.Visible = true;
            this.MaterielCode.VisibleIndex = 0;
            this.MaterielCode.Width = 127;
            // 
            // MaterielName
            // 
            this.MaterielName.Caption = "物料名称";
            this.MaterielName.FieldName = "MaterielName";
            this.MaterielName.Name = "MaterielName";
            this.MaterielName.Visible = true;
            this.MaterielName.VisibleIndex = 1;
            this.MaterielName.Width = 205;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "物料规格";
            this.gridColumn1.FieldName = "MaterielSpec";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 81;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "物料型号";
            this.gridColumn2.FieldName = "MaterielModel";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUserName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 4;
            this.CreateUser.Width = 88;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "D";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 5;
            this.CreateTime.Width = 168;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUserName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 6;
            this.UpdateUser.Width = 84;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.DisplayFormat.FormatString = "D";
            this.UpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.FieldName = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 7;
            this.UpdateTime.Width = 194;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.btn_update,
            this.btn_Confirm,
            this.btn_Cancel,
            this.btn_Delete});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 61);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(824, 26);
            this.gToolStrip1.TabIndex = 20;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(66, 23);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(66, 23);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(66, 23);
            this.btn_Confirm.Text = "确认";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(66, 23);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(66, 23);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(824, 61);
            this.panelControl1.TabIndex = 19;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_LevelModel);
            this.layoutControl1.Controls.Add(this.txt_LevelSpec);
            this.layoutControl1.Controls.Add(this.txt_LevelName);
            this.layoutControl1.Controls.Add(this.txt_LevelCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(277, 181, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(820, 57);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_LevelModel
            // 
            this.txt_LevelModel.Location = new System.Drawing.Point(618, 12);
            this.txt_LevelModel.Margin = new System.Windows.Forms.Padding(2);
            this.txt_LevelModel.Name = "txt_LevelModel";
            this.txt_LevelModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_LevelModel.Properties.Appearance.Options.UseFont = true;
            this.txt_LevelModel.Size = new System.Drawing.Size(119, 26);
            this.txt_LevelModel.StyleController = this.layoutControl1;
            this.txt_LevelModel.TabIndex = 13;
            // 
            // txt_LevelSpec
            // 
            this.txt_LevelSpec.Location = new System.Drawing.Point(447, 12);
            this.txt_LevelSpec.Margin = new System.Windows.Forms.Padding(2);
            this.txt_LevelSpec.Name = "txt_LevelSpec";
            this.txt_LevelSpec.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_LevelSpec.Properties.Appearance.Options.UseFont = true;
            this.txt_LevelSpec.Size = new System.Drawing.Size(100, 26);
            this.txt_LevelSpec.StyleController = this.layoutControl1;
            this.txt_LevelSpec.TabIndex = 12;
            // 
            // txt_LevelName
            // 
            this.txt_LevelName.Location = new System.Drawing.Point(239, 12);
            this.txt_LevelName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_LevelName.Name = "txt_LevelName";
            this.txt_LevelName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LevelName.Properties.Appearance.Options.UseFont = true;
            this.txt_LevelName.Size = new System.Drawing.Size(137, 26);
            this.txt_LevelName.StyleController = this.layoutControl1;
            this.txt_LevelName.TabIndex = 11;
            // 
            // txt_LevelCode
            // 
            this.txt_LevelCode.Location = new System.Drawing.Point(79, 12);
            this.txt_LevelCode.Margin = new System.Windows.Forms.Padding(2);
            this.txt_LevelCode.Name = "txt_LevelCode";
            this.txt_LevelCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LevelCode.Properties.Appearance.Options.UseFont = true;
            this.txt_LevelCode.Size = new System.Drawing.Size(89, 26);
            this.txt_LevelCode.StyleController = this.layoutControl1;
            this.txt_LevelCode.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(820, 57);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_LevelCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 37);
            this.layoutControlItem1.Text = "物料编码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_LevelName;
            this.layoutControlItem2.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(208, 37);
            this.layoutControlItem2.Text = "物料名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_LevelModel;
            this.layoutControlItem4.Location = new System.Drawing.Point(539, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(190, 37);
            this.layoutControlItem4.Text = "物料型号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(729, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(71, 37);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_LevelSpec;
            this.layoutControlItem3.Location = new System.Drawing.Point(368, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(171, 37);
            this.layoutControlItem3.Text = "物料规格";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SM_Materiel_Level_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 534);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "SM_Materiel_Level_Form";
            this.ShowIcon = false;
            this.Text = "物料基础信息管理";
            this.Shown += new System.EventHandler(this.SM_Materiel_Level_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelSpec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn MaterielCode;
        private DevExpress.XtraGrid.Columns.GridColumn MaterielName;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Add;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_Confirm;
        private Core.Helper.GToolStripButton btn_Cancel;
        private Core.Helper.GToolStripButton btn_Delete;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_LevelName;
        private DevExpress.XtraEditors.TextEdit txt_LevelCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.TextEdit txt_LevelModel;
        private DevExpress.XtraEditors.TextEdit txt_LevelSpec;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}