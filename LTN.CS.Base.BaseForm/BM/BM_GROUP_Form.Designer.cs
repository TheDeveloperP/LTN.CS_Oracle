namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_GROUP_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_GROUP_Form));
            this.chk_Isforbiden = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lud_ManaName = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_GroupName = new DevExpress.XtraEditors.TextEdit();
            this.txt_GroupNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_GroupDescription = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_sure = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_ISFORBID = new LTN.CS.Core.Helper.GToolStripButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
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
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chk_Isforbiden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lud_ManaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_Isforbiden
            // 
            this.chk_Isforbiden.Location = new System.Drawing.Point(819, 12);
            this.chk_Isforbiden.Name = "chk_Isforbiden";
            this.chk_Isforbiden.Properties.Caption = "是否禁用";
            this.chk_Isforbiden.Size = new System.Drawing.Size(71, 19);
            this.chk_Isforbiden.StyleController = this.layoutControl1;
            this.chk_Isforbiden.TabIndex = 7;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lud_ManaName);
            this.layoutControl1.Controls.Add(this.txt_GroupName);
            this.layoutControl1.Controls.Add(this.txt_GroupNo);
            this.layoutControl1.Controls.Add(this.txt_GroupDescription);
            this.layoutControl1.Controls.Add(this.chk_Isforbiden);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(173, 368, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1001, 51);
            this.layoutControl1.TabIndex = 0;
            // 
            // lud_ManaName
            // 
            this.lud_ManaName.Location = new System.Drawing.Point(671, 12);
            this.lud_ManaName.Name = "lud_ManaName";
            this.lud_ManaName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lud_ManaName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntId", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "管理员工号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserNickName", "管理员名称")});
            this.lud_ManaName.Properties.DisplayMember = "UserNickName";
            this.lud_ManaName.Properties.NullText = "请选择";
            this.lud_ManaName.Properties.ValueMember = "IntId";
            this.lud_ManaName.Size = new System.Drawing.Size(144, 20);
            this.lud_ManaName.StyleController = this.layoutControl1;
            this.lud_ManaName.TabIndex = 8;
            // 
            // txt_GroupName
            // 
            this.txt_GroupName.Location = new System.Drawing.Point(249, 12);
            this.txt_GroupName.Name = "txt_GroupName";
            this.txt_GroupName.Size = new System.Drawing.Size(146, 20);
            this.txt_GroupName.StyleController = this.layoutControl1;
            this.txt_GroupName.TabIndex = 5;
            // 
            // txt_GroupNo
            // 
            this.txt_GroupNo.Location = new System.Drawing.Point(76, 12);
            this.txt_GroupNo.Name = "txt_GroupNo";
            this.txt_GroupNo.Size = new System.Drawing.Size(105, 20);
            this.txt_GroupNo.StyleController = this.layoutControl1;
            this.txt_GroupNo.TabIndex = 4;
            // 
            // txt_GroupDescription
            // 
            this.txt_GroupDescription.Location = new System.Drawing.Point(463, 12);
            this.txt_GroupDescription.Name = "txt_GroupDescription";
            this.txt_GroupDescription.Size = new System.Drawing.Size(140, 20);
            this.txt_GroupDescription.StyleController = this.layoutControl1;
            this.txt_GroupDescription.TabIndex = 6;
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
            this.emptySpaceItem1,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1001, 51);
            this.layoutControlGroup1.Text = "Root";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_GroupNo;
            this.layoutControlItem1.CustomizationFormText = "群组编号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(173, 31);
            this.layoutControlItem1.Text = "群组编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_GroupName;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(173, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(214, 31);
            this.layoutControlItem2.Text = "群组名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_GroupDescription;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(387, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(208, 31);
            this.layoutControlItem3.Text = "群组描述";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chk_Isforbiden;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(807, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(75, 31);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(882, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(99, 31);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lud_ManaName;
            this.layoutControlItem7.CustomizationFormText = "群组管理员";
            this.layoutControlItem7.Location = new System.Drawing.Point(595, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(212, 31);
            this.layoutControlItem7.Text = "群组管理员";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 14);
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
            // gToolStrip1
            // 
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_update,
            this.btn_sure,
            this.btn_cancel,
            this.btn_delete,
            this.btn_ISFORBID});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 51);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1001, 25);
            this.gToolStrip1.TabIndex = 2;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_ISFORBID
            // 
            this.btn_ISFORBID.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16;
            this.btn_ISFORBID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ISFORBID.Name = "btn_ISFORBID";
            this.btn_ISFORBID.Size = new System.Drawing.Size(52, 22);
            this.btn_ISFORBID.Text = "作废";
            this.btn_ISFORBID.Click += new System.EventHandler(this.btn_ISFORBID_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.CustomizationFormText = "电话号码";
            this.layoutControlItem5.Location = new System.Drawing.Point(310, 0);
            this.layoutControlItem5.Name = "layoutControlItem2";
            this.layoutControlItem5.Size = new System.Drawing.Size(129, 30);
            this.layoutControlItem5.Text = "电话号码";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.CustomizationFormText = "电话号码";
            this.layoutControlItem6.Location = new System.Drawing.Point(310, 0);
            this.layoutControlItem6.Name = "layoutControlItem2";
            this.layoutControlItem6.Size = new System.Drawing.Size(129, 30);
            this.layoutControlItem6.Text = "电话号码";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // gcl_center
            // 
            this.gcl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_center.Location = new System.Drawing.Point(0, 76);
            this.gcl_center.MainView = this.gvw_main;
            this.gcl_center.Name = "gcl_center";
            this.gcl_center.Size = new System.Drawing.Size(1001, 350);
            this.gcl_center.TabIndex = 4;
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
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // BM_GROUP_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 426);
            this.Controls.Add(this.gcl_center);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_GROUP_Form";
            this.Text = "群组管理";
            this.Load += new System.EventHandler(this.BM_GROUP_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chk_Isforbiden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lud_ManaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chk_Isforbiden;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_GroupName;
        private DevExpress.XtraEditors.TextEdit txt_GroupNo;
        private DevExpress.XtraEditors.TextEdit txt_GroupDescription;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Core.Helper.GToolStripButton btn_add;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_sure;
        private Core.Helper.GToolStripButton btn_cancel;
        private Core.Helper.GToolStripButton btn_delete;
        private Core.Helper.GToolStrip gToolStrip1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gcl_center;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn GroupNo;
        private DevExpress.XtraGrid.Columns.GridColumn GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn GroupDes;
        private DevExpress.XtraGrid.Columns.GridColumn CreateEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn ManageEMPId;
        private DevExpress.XtraGrid.Columns.GridColumn IsForbid;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private DevExpress.XtraEditors.LookUpEdit lud_ManaName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private Core.Helper.GToolStripButton btn_ISFORBID;

    }
}