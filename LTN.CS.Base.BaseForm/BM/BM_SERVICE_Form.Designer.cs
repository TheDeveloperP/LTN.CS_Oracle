namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_SERVICE_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_SERVICE_Form));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_chkIsForbid = new DevExpress.XtraEditors.CheckEdit();
            this.txt_lueManageEMPId = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_ServiceDesc = new DevExpress.XtraEditors.TextEdit();
            this.txt_ServiceNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_ServiceName = new DevExpress.XtraEditors.TextEdit();
            this.txt_chkIsLimit = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gcl_center = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManageEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsForbid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_sure = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_ISFORBID = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Limited = new LTN.CS.Core.Helper.GToolStripButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_chkIsForbid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lueManageEMPId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_chkIsLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_chkIsForbid);
            this.layoutControl1.Controls.Add(this.txt_lueManageEMPId);
            this.layoutControl1.Controls.Add(this.txt_ServiceDesc);
            this.layoutControl1.Controls.Add(this.txt_ServiceNo);
            this.layoutControl1.Controls.Add(this.txt_ServiceName);
            this.layoutControl1.Controls.Add(this.txt_chkIsLimit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(90, 335, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1020, 68);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_chkIsForbid
            // 
            this.txt_chkIsForbid.Location = new System.Drawing.Point(560, 36);
            this.txt_chkIsForbid.Name = "txt_chkIsForbid";
            this.txt_chkIsForbid.Properties.Caption = "是否禁用";
            this.txt_chkIsForbid.Size = new System.Drawing.Size(71, 19);
            this.txt_chkIsForbid.StyleController = this.layoutControl1;
            this.txt_chkIsForbid.TabIndex = 8;
            // 
            // txt_lueManageEMPId
            // 
            this.txt_lueManageEMPId.Location = new System.Drawing.Point(612, 12);
            this.txt_lueManageEMPId.Name = "txt_lueManageEMPId";
            this.txt_lueManageEMPId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_lueManageEMPId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntId", "Id", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "用户工号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserNickName", "用户名称")});
            this.txt_lueManageEMPId.Properties.DisplayMember = "UserNickName";
            this.txt_lueManageEMPId.Properties.NullText = "请选择";
            this.txt_lueManageEMPId.Properties.ValueMember = "IntId";
            this.txt_lueManageEMPId.Size = new System.Drawing.Size(151, 20);
            this.txt_lueManageEMPId.StyleController = this.layoutControl1;
            this.txt_lueManageEMPId.TabIndex = 7;
            this.txt_lueManageEMPId.Enter += new System.EventHandler(this.txt_lueManageEMPId_Enter);
            // 
            // txt_ServiceDesc
            // 
            this.txt_ServiceDesc.Location = new System.Drawing.Point(64, 36);
            this.txt_ServiceDesc.Name = "txt_ServiceDesc";
            this.txt_ServiceDesc.Size = new System.Drawing.Size(492, 20);
            this.txt_ServiceDesc.StyleController = this.layoutControl1;
            this.txt_ServiceDesc.TabIndex = 6;
            // 
            // txt_ServiceNo
            // 
            this.txt_ServiceNo.Location = new System.Drawing.Point(64, 12);
            this.txt_ServiceNo.Name = "txt_ServiceNo";
            this.txt_ServiceNo.Size = new System.Drawing.Size(195, 20);
            this.txt_ServiceNo.StyleController = this.layoutControl1;
            this.txt_ServiceNo.TabIndex = 5;
            // 
            // txt_ServiceName
            // 
            this.txt_ServiceName.Location = new System.Drawing.Point(315, 12);
            this.txt_ServiceName.Name = "txt_ServiceName";
            this.txt_ServiceName.Size = new System.Drawing.Size(241, 20);
            this.txt_ServiceName.StyleController = this.layoutControl1;
            this.txt_ServiceName.TabIndex = 4;
            // 
            // txt_chkIsLimit
            // 
            this.txt_chkIsLimit.Location = new System.Drawing.Point(635, 36);
            this.txt_chkIsLimit.Name = "txt_chkIsLimit";
            this.txt_chkIsLimit.Properties.Caption = "是否限制";
            this.txt_chkIsLimit.Size = new System.Drawing.Size(71, 19);
            this.txt_chkIsLimit.StyleController = this.layoutControl1;
            this.txt_chkIsLimit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1020, 68);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_ServiceName;
            this.layoutControlItem1.CustomizationFormText = "服务名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(251, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(297, 24);
            this.layoutControlItem1.Text = "服务名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_ServiceNo;
            this.layoutControlItem2.CustomizationFormText = "服务代码";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(251, 24);
            this.layoutControlItem2.Text = "服务代码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_ServiceDesc;
            this.layoutControlItem3.CustomizationFormText = "服务描述";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(548, 24);
            this.layoutControlItem3.Text = "服务描述";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_lueManageEMPId;
            this.layoutControlItem4.CustomizationFormText = "管理人员";
            this.layoutControlItem4.Location = new System.Drawing.Point(548, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(207, 24);
            this.layoutControlItem4.Text = "管理人员";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt_chkIsForbid;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(548, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(75, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txt_chkIsLimit;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(623, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(75, 24);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(698, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(302, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(755, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(245, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gcl_center
            // 
            this.gcl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_center.Location = new System.Drawing.Point(0, 93);
            this.gcl_center.MainView = this.gvw_main;
            this.gcl_center.Name = "gcl_center";
            this.gcl_center.Size = new System.Drawing.Size(1020, 563);
            this.gcl_center.TabIndex = 5;
            this.gcl_center.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.ServiceNo,
            this.ServiceName,
            this.ServiceDes,
            this.CreateEMPId,
            this.ManageEMPId,
            this.IsForbid,
            this.IsLimit,
            this.CreateUser,
            this.CreateTime,
            this.UpdateUser,
            this.UpdateTime});
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
            // ServiceNo
            // 
            this.ServiceNo.Caption = "服务代码";
            this.ServiceNo.FieldName = "ServiceNo";
            this.ServiceNo.Name = "ServiceNo";
            this.ServiceNo.Visible = true;
            this.ServiceNo.VisibleIndex = 0;
            // 
            // ServiceName
            // 
            this.ServiceName.Caption = "服务名称";
            this.ServiceName.FieldName = "ServiceName";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Visible = true;
            this.ServiceName.VisibleIndex = 1;
            // 
            // ServiceDes
            // 
            this.ServiceDes.Caption = "服务描述";
            this.ServiceDes.FieldName = "ServiceDes";
            this.ServiceDes.Name = "ServiceDes";
            this.ServiceDes.Visible = true;
            this.ServiceDes.VisibleIndex = 2;
            // 
            // CreateEMPId
            // 
            this.CreateEMPId.Caption = "服务新建人";
            this.CreateEMPId.FieldName = "CreateEMPId.UserNickName";
            this.CreateEMPId.Name = "CreateEMPId";
            this.CreateEMPId.Visible = true;
            this.CreateEMPId.VisibleIndex = 3;
            // 
            // ManageEMPId
            // 
            this.ManageEMPId.Caption = "服务管理人";
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
            // IsLimit
            // 
            this.IsLimit.Caption = "是否限制";
            this.IsLimit.FieldName = "IsLimit.EntityDes";
            this.IsLimit.Name = "IsLimit";
            this.IsLimit.Visible = true;
            this.IsLimit.VisibleIndex = 6;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUser.UserNickName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 7;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "F";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 8;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUser.UserNickName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 9;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.DisplayFormat.FormatString = "F";
            this.UpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.FieldName = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 10;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_update,
            this.btn_sure,
            this.btn_cancel,
            this.btn_delete,
            this.btn_ISFORBID,
            this.btn_Limited});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 68);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1020, 25);
            this.gToolStrip1.TabIndex = 4;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 22);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.update_16;
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(52, 22);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Image = ((System.Drawing.Image)(resources.GetObject("btn_sure.Image")));
            this.btn_sure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(52, 22);
            this.btn_sure.Text = "确认";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(52, 22);
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.delete_16;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(52, 22);
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_ISFORBID
            // 
            this.btn_ISFORBID.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16;
            this.btn_ISFORBID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ISFORBID.Name = "btn_ISFORBID";
            this.btn_ISFORBID.Size = new System.Drawing.Size(52, 22);
            this.btn_ISFORBID.Text = "禁用";
            this.btn_ISFORBID.Click += new System.EventHandler(this.btn_ISFORBID_Click);
            // 
            // btn_Limited
            // 
            this.btn_Limited.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.limited_24;
            this.btn_Limited.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Limited.Name = "btn_Limited";
            this.btn_Limited.Size = new System.Drawing.Size(52, 22);
            this.btn_Limited.Text = "限制";
            this.btn_Limited.Click += new System.EventHandler(this.btn_Limited_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // BM_SERVICE_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 656);
            this.Controls.Add(this.gcl_center);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_SERVICE_Form";
            this.Text = "服务管理";
            this.Load += new System.EventHandler(this.BM_SERVICE_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_chkIsForbid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lueManageEMPId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_chkIsLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_ServiceDesc;
        private DevExpress.XtraEditors.TextEdit txt_ServiceNo;
        private DevExpress.XtraEditors.TextEdit txt_ServiceName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit txt_chkIsLimit;
        private DevExpress.XtraEditors.CheckEdit txt_chkIsForbid;
        private DevExpress.XtraEditors.LookUpEdit txt_lueManageEMPId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gcl_center;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceDes;
        private DevExpress.XtraGrid.Columns.GridColumn IsLimit;
        private DevExpress.XtraGrid.Columns.GridColumn CreateEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn ManageEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn IsForbid;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_add;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_sure;
        private Core.Helper.GToolStripButton btn_cancel;
        private Core.Helper.GToolStripButton btn_delete;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private Core.Helper.GToolStripButton btn_ISFORBID;
        private Core.Helper.GToolStripButton btn_Limited;


    }
}