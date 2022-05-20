namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_SERVICE_GROUP_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_SERVICE_GROUP_Form));
            this.gcl_center = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManageEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsForbid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_refresh = new LTN.CS.Core.Helper.GToolStripButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.right_IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.right_ServiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.right_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.right_ServiceDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.right_CreateEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.right_ManageEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.left_IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.left_ServiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.left_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.left_ServiceDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.left_CreateEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.left_ManageEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcl_center
            // 
            this.gcl_center.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcl_center.Location = new System.Drawing.Point(0, 0);
            this.gcl_center.MainView = this.gvw_main;
            this.gcl_center.Name = "gcl_center";
            this.gcl_center.Size = new System.Drawing.Size(908, 191);
            this.gcl_center.TabIndex = 3;
            this.gcl_center.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.GroupNo,
            this.GroupName,
            this.GroupDes,
            this.CreateEMPId,
            this.ManageEMPId,
            this.IsForbid,
            this.CreateTime,
            this.CreateUser,
            this.UpdateTime,
            this.UpdateUser});
            this.gvw_main.GridControl = this.gcl_center;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            // 
            // GroupNo
            // 
            this.GroupNo.Caption = "群组编号";
            this.GroupNo.FieldName = "GroupNo";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.Visible = true;
            this.GroupNo.VisibleIndex = 0;
            // 
            // GroupName
            // 
            this.GroupName.Caption = "群组名称";
            this.GroupName.FieldName = "GroupName";
            this.GroupName.Name = "GroupName";
            this.GroupName.Visible = true;
            this.GroupName.VisibleIndex = 1;
            // 
            // GroupDes
            // 
            this.GroupDes.Caption = "群组描述";
            this.GroupDes.FieldName = "GroupDes";
            this.GroupDes.Name = "GroupDes";
            this.GroupDes.Visible = true;
            this.GroupDes.VisibleIndex = 2;
            // 
            // CreateEMPId
            // 
            this.CreateEMPId.Caption = "群组新建人";
            this.CreateEMPId.FieldName = "CreateEMPId.UserNickName";
            this.CreateEMPId.Name = "CreateEMPId";
            this.CreateEMPId.Visible = true;
            this.CreateEMPId.VisibleIndex = 3;
            // 
            // ManageEMPId
            // 
            this.ManageEMPId.Caption = "群组管理员";
            this.ManageEMPId.FieldName = "ManageEMPId.UserNickName";
            this.ManageEMPId.Name = "ManageEMPId";
            this.ManageEMPId.Visible = true;
            this.ManageEMPId.VisibleIndex = 4;
            // 
            // IsForbid
            // 
            this.IsForbid.Caption = "是否禁用";
            this.IsForbid.FieldName = "IsForbid.EntityDes";
            this.IsForbid.Name = "IsForbid";
            this.IsForbid.Visible = true;
            this.IsForbid.VisibleIndex = 5;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "F";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 6;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUser.UserNickName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 7;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.DisplayFormat.FormatString = "F";
            this.UpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.FieldName = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 8;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUser.UserNickName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 9;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_refresh});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 191);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(908, 25);
            this.gToolStrip1.TabIndex = 4;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.refresh_16;
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(52, 22);
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(908, 260);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(429, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(459, 240);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(441, 12);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(455, 236);
            this.gridControl2.TabIndex = 8;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.right_IntId,
            this.right_ServiceNo,
            this.right_ServiceName,
            this.right_ServiceDes,
            this.right_CreateEMPId,
            this.gridColumn16,
            this.right_ManageEMPId});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // right_IntId
            // 
            this.right_IntId.Caption = "主键";
            this.right_IntId.FieldName = "IntId";
            this.right_IntId.Name = "right_IntId";
            // 
            // right_ServiceNo
            // 
            this.right_ServiceNo.Caption = "可选服务编号";
            this.right_ServiceNo.FieldName = "ServiceNo";
            this.right_ServiceNo.Name = "right_ServiceNo";
            this.right_ServiceNo.Visible = true;
            this.right_ServiceNo.VisibleIndex = 0;
            // 
            // right_ServiceName
            // 
            this.right_ServiceName.Caption = "服务名称";
            this.right_ServiceName.FieldName = "ServiceName";
            this.right_ServiceName.Name = "right_ServiceName";
            this.right_ServiceName.Visible = true;
            this.right_ServiceName.VisibleIndex = 1;
            // 
            // right_ServiceDes
            // 
            this.right_ServiceDes.Caption = "服务描述";
            this.right_ServiceDes.FieldName = "ServiceDes";
            this.right_ServiceDes.Name = "right_ServiceDes";
            this.right_ServiceDes.Visible = true;
            this.right_ServiceDes.VisibleIndex = 2;
            // 
            // right_CreateEMPId
            // 
            this.right_CreateEMPId.Caption = "新增人员";
            this.right_CreateEMPId.FieldName = "CreateEMPId.UserNickName";
            this.right_CreateEMPId.Name = "right_CreateEMPId";
            this.right_CreateEMPId.Visible = true;
            this.right_CreateEMPId.VisibleIndex = 3;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "是否禁用";
            this.gridColumn16.FieldName = "IsForbid.EntityDes";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // right_ManageEMPId
            // 
            this.right_ManageEMPId.Caption = "管理人员";
            this.right_ManageEMPId.FieldName = "ManageEMPId.UserNickName";
            this.right_ManageEMPId.Name = "right_ManageEMPId";
            this.right_ManageEMPId.Visible = true;
            this.right_ManageEMPId.VisibleIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(429, 240);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(425, 236);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.left_IntId,
            this.left_ServiceNo,
            this.left_ServiceName,
            this.left_ServiceDes,
            this.left_CreateEMPId,
            this.left_ManageEMPId,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // left_IntId
            // 
            this.left_IntId.Caption = "主键";
            this.left_IntId.FieldName = "IntId";
            this.left_IntId.Name = "left_IntId";
            // 
            // left_ServiceNo
            // 
            this.left_ServiceNo.Caption = "已有服务编号";
            this.left_ServiceNo.FieldName = "ServiceNo";
            this.left_ServiceNo.Name = "left_ServiceNo";
            this.left_ServiceNo.Visible = true;
            this.left_ServiceNo.VisibleIndex = 0;
            // 
            // left_ServiceName
            // 
            this.left_ServiceName.Caption = "服务名称";
            this.left_ServiceName.FieldName = "ServiceName";
            this.left_ServiceName.Name = "left_ServiceName";
            this.left_ServiceName.Visible = true;
            this.left_ServiceName.VisibleIndex = 1;
            // 
            // left_ServiceDes
            // 
            this.left_ServiceDes.Caption = "服务描述";
            this.left_ServiceDes.FieldName = "ServiceDes";
            this.left_ServiceDes.Name = "left_ServiceDes";
            this.left_ServiceDes.Visible = true;
            this.left_ServiceDes.VisibleIndex = 2;
            // 
            // left_CreateEMPId
            // 
            this.left_CreateEMPId.Caption = "新增人员";
            this.left_CreateEMPId.FieldName = "CreateEMPId.UserNickName";
            this.left_CreateEMPId.Name = "left_CreateEMPId";
            this.left_CreateEMPId.Visible = true;
            this.left_CreateEMPId.VisibleIndex = 3;
            // 
            // left_ManageEMPId
            // 
            this.left_ManageEMPId.Caption = "管理人员";
            this.left_ManageEMPId.FieldName = "ManageEMPId.UserNickName";
            this.left_ManageEMPId.Name = "left_ManageEMPId";
            this.left_ManageEMPId.Visible = true;
            this.left_ManageEMPId.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "是否禁用";
            this.gridColumn6.FieldName = "IsForbid.EntityDes";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 216);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(140, 198, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(908, 260);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BM_SERVICE_GROUP_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 476);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.gcl_center);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_SERVICE_GROUP_Form";
            this.Text = "服务群组管理";
            this.Load += new System.EventHandler(this.BM_SERVICE_GROUP_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcl_center;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn GroupNo;
        private DevExpress.XtraGrid.Columns.GridColumn GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn GroupDes;
        private DevExpress.XtraGrid.Columns.GridColumn CreateEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn IsForbid;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private Core.Helper.GToolStrip gToolStrip1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Core.Helper.GToolStripButton btn_refresh;
        private DevExpress.XtraGrid.Columns.GridColumn ManageEMPId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn right_IntId;
        private DevExpress.XtraGrid.Columns.GridColumn right_ServiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn right_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn right_ServiceDes;
        private DevExpress.XtraGrid.Columns.GridColumn right_CreateEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn right_ManageEMPId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn left_IntId;
        private DevExpress.XtraGrid.Columns.GridColumn left_ServiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn left_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn left_ServiceDes;
        private DevExpress.XtraGrid.Columns.GridColumn left_CreateEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn left_ManageEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;


    }
}