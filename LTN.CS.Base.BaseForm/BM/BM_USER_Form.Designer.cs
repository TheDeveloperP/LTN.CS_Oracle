namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_USER_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_USER_Form));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_USERNICKNAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_ISFORBID = new DevExpress.XtraEditors.CheckEdit();
            this.txt_EMAIL = new DevExpress.XtraEditors.TextEdit();
            this.txt_MOBILENO = new DevExpress.XtraEditors.TextEdit();
            this.txt_USERNAME = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_sure = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_reset = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_ISFORBID = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_center = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserNickName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsForbid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_USERNICKNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ISFORBID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EMAIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MOBILENO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_USERNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_USERNICKNAME);
            this.layoutControl1.Controls.Add(this.txt_ISFORBID);
            this.layoutControl1.Controls.Add(this.txt_EMAIL);
            this.layoutControl1.Controls.Add(this.txt_MOBILENO);
            this.layoutControl1.Controls.Add(this.txt_USERNAME);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1137, 75);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_USERNICKNAME
            // 
            this.txt_USERNICKNAME.Location = new System.Drawing.Point(257, 12);
            this.txt_USERNICKNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_USERNICKNAME.Name = "txt_USERNICKNAME";
            this.txt_USERNICKNAME.Size = new System.Drawing.Size(152, 20);
            this.txt_USERNICKNAME.StyleController = this.layoutControl1;
            this.txt_USERNICKNAME.TabIndex = 8;
            // 
            // txt_ISFORBID
            // 
            this.txt_ISFORBID.Location = new System.Drawing.Point(749, 12);
            this.txt_ISFORBID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_ISFORBID.Name = "txt_ISFORBID";
            this.txt_ISFORBID.Properties.Caption = "是否禁用";
            this.txt_ISFORBID.Size = new System.Drawing.Size(114, 19);
            this.txt_ISFORBID.StyleController = this.layoutControl1;
            this.txt_ISFORBID.TabIndex = 7;
            // 
            // txt_EMAIL
            // 
            this.txt_EMAIL.Location = new System.Drawing.Point(631, 12);
            this.txt_EMAIL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_EMAIL.Name = "txt_EMAIL";
            this.txt_EMAIL.Size = new System.Drawing.Size(114, 20);
            this.txt_EMAIL.StyleController = this.layoutControl1;
            this.txt_EMAIL.TabIndex = 6;
            // 
            // txt_MOBILENO
            // 
            this.txt_MOBILENO.Location = new System.Drawing.Point(464, 12);
            this.txt_MOBILENO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_MOBILENO.Name = "txt_MOBILENO";
            this.txt_MOBILENO.Size = new System.Drawing.Size(112, 20);
            this.txt_MOBILENO.StyleController = this.layoutControl1;
            this.txt_MOBILENO.TabIndex = 5;
            // 
            // txt_USERNAME
            // 
            this.txt_USERNAME.Location = new System.Drawing.Point(63, 12);
            this.txt_USERNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_USERNAME.Name = "txt_USERNAME";
            this.txt_USERNAME.Properties.Mask.EditMask = "\\w{2,20}";
            this.txt_USERNAME.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_USERNAME.Size = new System.Drawing.Size(139, 20);
            this.txt_USERNAME.StyleController = this.layoutControl1;
            this.txt_USERNAME.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1137, 75);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(855, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(262, 55);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_USERNAME;
            this.layoutControlItem1.CustomizationFormText = "用户名";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(194, 55);
            this.layoutControlItem1.Text = "用户工号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_MOBILENO;
            this.layoutControlItem2.CustomizationFormText = "电话号码";
            this.layoutControlItem2.Location = new System.Drawing.Point(401, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(167, 55);
            this.layoutControlItem2.Text = "电话号码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_EMAIL;
            this.layoutControlItem3.CustomizationFormText = "电子邮件";
            this.layoutControlItem3.Location = new System.Drawing.Point(568, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(169, 55);
            this.layoutControlItem3.Text = "部门名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_ISFORBID;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(737, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(118, 55);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt_USERNICKNAME;
            this.layoutControlItem5.CustomizationFormText = "人员别称";
            this.layoutControlItem5.Location = new System.Drawing.Point(194, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(207, 55);
            this.layoutControlItem5.Text = "人员名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_update,
            this.btn_sure,
            this.btn_cancel,
            this.btn_delete,
            this.btn_reset,
            this.btn_ISFORBID});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 75);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1137, 38);
            this.gToolStrip1.TabIndex = 1;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(56, 35);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.update_16;
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(56, 35);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Image = ((System.Drawing.Image)(resources.GetObject("btn_sure.Image")));
            this.btn_sure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(56, 35);
            this.btn_sure.Text = "确认";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(56, 35);
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.delete_16;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(56, 35);
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.Reset_16;
            this.btn_reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(84, 35);
            this.btn_reset.Text = "重置密码";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_ISFORBID
            // 
            this.btn_ISFORBID.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16;
            this.btn_ISFORBID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ISFORBID.Name = "btn_ISFORBID";
            this.btn_ISFORBID.Size = new System.Drawing.Size(56, 35);
            this.btn_ISFORBID.Text = "禁用";
            this.btn_ISFORBID.Click += new System.EventHandler(this.btn_ISFORBID_Click);
            // 
            // gcl_center
            // 
            this.gcl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_center.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcl_center.Location = new System.Drawing.Point(0, 113);
            this.gcl_center.MainView = this.gvw_main;
            this.gcl_center.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcl_center.Name = "gcl_center";
            this.gcl_center.Size = new System.Drawing.Size(1137, 610);
            this.gcl_center.TabIndex = 2;
            this.gcl_center.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.UserName,
            this.UserNickName,
            this.MobileNo,
            this.Email,
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
            // UserName
            // 
            this.UserName.Caption = "用户工号";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 0;
            // 
            // UserNickName
            // 
            this.UserNickName.Caption = "人员名称";
            this.UserNickName.FieldName = "UserNickName";
            this.UserNickName.Name = "UserNickName";
            this.UserNickName.Visible = true;
            this.UserNickName.VisibleIndex = 1;
            // 
            // MobileNo
            // 
            this.MobileNo.Caption = "电话号码";
            this.MobileNo.FieldName = "MobileNo";
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.Visible = true;
            this.MobileNo.VisibleIndex = 2;
            // 
            // Email
            // 
            this.Email.Caption = "部门名称";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 3;
            // 
            // IsForbid
            // 
            this.IsForbid.Caption = "是否禁用";
            this.IsForbid.FieldName = "IsForbid.EntityDes";
            this.IsForbid.Name = "IsForbid";
            this.IsForbid.Visible = true;
            this.IsForbid.VisibleIndex = 4;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "F";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 5;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUserName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 6;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.DisplayFormat.FormatString = "F";
            this.UpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.FieldName = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 7;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUserName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 8;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // BM_USER_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 723);
            this.Controls.Add(this.gcl_center);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "BM_USER_Form";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.BM_USER_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_USERNICKNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ISFORBID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EMAIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MOBILENO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_USERNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Core.Helper.GToolStrip gToolStrip1;
        private DevExpress.XtraGrid.GridControl gcl_center;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private Core.Helper.GToolStripButton btn_add;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txt_USERNAME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txt_MOBILENO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txt_EMAIL;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit txt_ISFORBID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Core.Helper.GToolStripButton btn_sure;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn MobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn IsForbid;
        private Core.Helper.GToolStripButton btn_cancel;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_delete;
        private DevExpress.XtraEditors.TextEdit txt_USERNICKNAME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn UserNickName;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private Core.Helper.GToolStripButton btn_reset;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private Core.Helper.GToolStripButton btn_ISFORBID;











    }
}