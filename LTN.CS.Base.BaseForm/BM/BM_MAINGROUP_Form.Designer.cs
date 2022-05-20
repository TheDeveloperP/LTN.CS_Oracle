namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_MAINGROUP_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_MAINGROUP_Form));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_tips = new DevExpress.XtraEditors.TextEdit();
            this.txt_text = new DevExpress.XtraEditors.TextEdit();
            this.txt_ISFORBID = new DevExpress.XtraEditors.CheckEdit();
            this.txt_Index = new DevExpress.XtraEditors.TextEdit();
            this.txt_ManageEMPId = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_GroupName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_sure = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_ISFORBID = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_center = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PageId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Index = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KeyTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsForbid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateEMPId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tips.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_text.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ISFORBID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Index.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ManageEMPId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_tips);
            this.layoutControl1.Controls.Add(this.txt_text);
            this.layoutControl1.Controls.Add(this.txt_ISFORBID);
            this.layoutControl1.Controls.Add(this.txt_Index);
            this.layoutControl1.Controls.Add(this.txt_ManageEMPId);
            this.layoutControl1.Controls.Add(this.txt_GroupName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(51, 166, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1020, 68);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_tips
            // 
            this.txt_tips.Location = new System.Drawing.Point(542, 36);
            this.txt_tips.Name = "txt_tips";
            this.txt_tips.Size = new System.Drawing.Size(466, 20);
            this.txt_tips.StyleController = this.layoutControl1;
            this.txt_tips.TabIndex = 11;
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(75, 36);
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(390, 20);
            this.txt_text.StyleController = this.layoutControl1;
            this.txt_text.TabIndex = 10;
            // 
            // txt_ISFORBID
            // 
            this.txt_ISFORBID.Location = new System.Drawing.Point(740, 12);
            this.txt_ISFORBID.Name = "txt_ISFORBID";
            this.txt_ISFORBID.Properties.Caption = "是否禁用";
            this.txt_ISFORBID.Size = new System.Drawing.Size(268, 19);
            this.txt_ISFORBID.StyleController = this.layoutControl1;
            this.txt_ISFORBID.TabIndex = 8;
            // 
            // txt_Index
            // 
            this.txt_Index.Location = new System.Drawing.Point(347, 12);
            this.txt_Index.Name = "txt_Index";
            this.txt_Index.Properties.Mask.EditMask = "n0";
            this.txt_Index.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_Index.Size = new System.Drawing.Size(128, 20);
            this.txt_Index.StyleController = this.layoutControl1;
            this.txt_Index.TabIndex = 8;
            // 
            // txt_ManageEMPId
            // 
            this.txt_ManageEMPId.Location = new System.Drawing.Point(75, 12);
            this.txt_ManageEMPId.Name = "txt_ManageEMPId";
            this.txt_ManageEMPId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ManageEMPId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntId", "Id", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "菜单页名称")});
            this.txt_ManageEMPId.Properties.DisplayMember = "Text";
            this.txt_ManageEMPId.Properties.NullText = "";
            this.txt_ManageEMPId.Properties.ValueMember = "IntId";
            this.txt_ManageEMPId.Size = new System.Drawing.Size(205, 20);
            this.txt_ManageEMPId.StyleController = this.layoutControl1;
            this.txt_ManageEMPId.TabIndex = 4;
            this.txt_ManageEMPId.Enter += new System.EventHandler(this.txt_ManageEMPId_Enter);
            // 
            // txt_GroupName
            // 
            this.txt_GroupName.EditValue = "";
            this.txt_GroupName.Location = new System.Drawing.Point(542, 12);
            this.txt_GroupName.Name = "txt_GroupName";
            this.txt_GroupName.Properties.NullText = "请选择";
            this.txt_GroupName.Size = new System.Drawing.Size(194, 20);
            this.txt_GroupName.StyleController = this.layoutControl1;
            this.txt_GroupName.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1020, 68);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_ManageEMPId;
            this.layoutControlItem1.CustomizationFormText = "菜单页名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem1.Text = "菜单页名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt_Index;
            this.layoutControlItem5.CustomizationFormText = "分组序号";
            this.layoutControlItem5.Location = new System.Drawing.Point(272, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(195, 24);
            this.layoutControlItem5.Text = "分组序号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_ISFORBID;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(728, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_GroupName;
            this.layoutControlItem2.CustomizationFormText = "分组名称";
            this.layoutControlItem2.Location = new System.Drawing.Point(467, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem2.Text = "分组名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_text;
            this.layoutControlItem3.CustomizationFormText = "分组标题";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(457, 24);
            this.layoutControlItem3.Text = "分组标题";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txt_tips;
            this.layoutControlItem6.CustomizationFormText = "分组提示";
            this.layoutControlItem6.Location = new System.Drawing.Point(467, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(533, 24);
            this.layoutControlItem6.Text = "分组提示";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(457, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            this.gToolStrip1.Location = new System.Drawing.Point(0, 68);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1020, 25);
            this.gToolStrip1.TabIndex = 3;
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
            // gcl_center
            // 
            this.gcl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_center.Location = new System.Drawing.Point(0, 93);
            this.gcl_center.MainView = this.gvw_main;
            this.gcl_center.Name = "gcl_center";
            this.gcl_center.Size = new System.Drawing.Size(1020, 469);
            this.gcl_center.TabIndex = 4;
            this.gcl_center.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_main});
            // 
            // gvw_main
            // 
            this.gvw_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.PageId,
            this.GroupName,
            this.Index,
            this.GroupText,
            this.KeyTip,
            this.IsForbid,
            this.CreateEMPId,
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
            // PageId
            // 
            this.PageId.Caption = "菜单页名称";
            this.PageId.FieldName = "PageId.Text";
            this.PageId.Name = "PageId";
            this.PageId.Visible = true;
            this.PageId.VisibleIndex = 0;
            // 
            // GroupName
            // 
            this.GroupName.Caption = "分组名称";
            this.GroupName.FieldName = "GroupName";
            this.GroupName.Name = "GroupName";
            this.GroupName.Visible = true;
            this.GroupName.VisibleIndex = 1;
            // 
            // Index
            // 
            this.Index.Caption = "分组序号";
            this.Index.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Index.FieldName = "Index";
            this.Index.Name = "Index";
            this.Index.Visible = true;
            this.Index.VisibleIndex = 2;
            // 
            // GroupText
            // 
            this.GroupText.Caption = "分组标题";
            this.GroupText.FieldName = "Text";
            this.GroupText.Name = "GroupText";
            this.GroupText.Visible = true;
            this.GroupText.VisibleIndex = 3;
            // 
            // KeyTip
            // 
            this.KeyTip.Caption = "分组提示";
            this.KeyTip.FieldName = "KeyTip";
            this.KeyTip.Name = "KeyTip";
            this.KeyTip.Visible = true;
            this.KeyTip.VisibleIndex = 4;
            // 
            // IsForbid
            // 
            this.IsForbid.Caption = "是否禁用";
            this.IsForbid.FieldName = "IsForbid.EntityDes";
            this.IsForbid.Name = "IsForbid";
            this.IsForbid.Visible = true;
            this.IsForbid.VisibleIndex = 5;
            // 
            // CreateEMPId
            // 
            this.CreateEMPId.Caption = "创建人员";
            this.CreateEMPId.FieldName = "CreateEMPId.UserNickName";
            this.CreateEMPId.Name = "CreateEMPId";
            this.CreateEMPId.Visible = true;
            this.CreateEMPId.VisibleIndex = 6;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "新增时间";
            this.CreateTime.DisplayFormat.FormatString = "F";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 7;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUser.UserNickName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 8;
            // 
            // UpdateTime
            // 
            this.UpdateTime.Caption = "修改时间";
            this.UpdateTime.DisplayFormat.FormatString = "F";
            this.UpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UpdateTime.FieldName = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Visible = true;
            this.UpdateTime.VisibleIndex = 9;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUser.UserNickName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 10;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // BM_MAINGROUP_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 562);
            this.Controls.Add(this.gcl_center);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_MAINGROUP_Form";
            this.Text = "二级菜单";
            this.Load += new System.EventHandler(this.BM_MAINGROUP_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_tips.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_text.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ISFORBID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Index.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ManageEMPId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_tips;
        private DevExpress.XtraEditors.TextEdit txt_text;
        private DevExpress.XtraEditors.CheckEdit txt_ISFORBID;
        private DevExpress.XtraEditors.TextEdit txt_Index;
        private DevExpress.XtraEditors.LookUpEdit txt_ManageEMPId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txt_GroupName;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_add;
        private Core.Helper.GToolStripButton btn_update;
        private Core.Helper.GToolStripButton btn_sure;
        private Core.Helper.GToolStripButton btn_cancel;
        private Core.Helper.GToolStripButton btn_delete;
        private DevExpress.XtraGrid.GridControl gcl_center;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn Index;
        private DevExpress.XtraGrid.Columns.GridColumn GroupText;
        private DevExpress.XtraGrid.Columns.GridColumn KeyTip;
        private DevExpress.XtraGrid.Columns.GridColumn IsForbid;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn PageId;
        private DevExpress.XtraGrid.Columns.GridColumn CreateEMPId;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private Core.Helper.GToolStripButton btn_ISFORBID;

    }
}