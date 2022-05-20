namespace LTN.CS.Base.BaseForm.BM
{
    partial class BM_DELIVERY_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_DELIVERY_Form));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcl_bottom = new DevExpress.XtraGrid.GridControl();
            this.gvw_bottom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId_bottom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperatorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContinueName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperatorType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPTDate_bottom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remarks_bottom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime_bottom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser_bottom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Refresh = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStripButton2 = new LTN.CS.Core.Helper.GToolStripButton();
            this.txt_FirstDeliveryUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.gToolStripButton3 = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStripButton4 = new LTN.CS.Core.Helper.GToolStripButton();
            this.txt_IsDeliveried = new LTN.CS.Core.Helper.GToolStripCheckEdit();
            this.gcl_left = new DevExpress.XtraGrid.GridControl();
            this.gvw_left = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId_Main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstReporter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserNickName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime_Main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser_Main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime_Main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser_Main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcl_right = new DevExpress.XtraGrid.GridControl();
            this.gvw_right = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_bottom)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcl_bottom);
            this.splitContainerControl1.Panel1.Controls.Add(this.gToolStrip1);
            this.splitContainerControl1.Panel1.Controls.Add(this.gcl_left);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcl_right);
            this.splitContainerControl1.Panel2.Controls.Add(this.textEdit1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 475);
            this.splitContainerControl1.SplitterPosition = 367;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcl_bottom
            // 
            this.gcl_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_bottom.Location = new System.Drawing.Point(0, 287);
            this.gcl_bottom.MainView = this.gvw_bottom;
            this.gcl_bottom.Name = "gcl_bottom";
            this.gcl_bottom.Size = new System.Drawing.Size(367, 188);
            this.gcl_bottom.TabIndex = 16;
            this.gcl_bottom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_bottom});
            // 
            // gvw_bottom
            // 
            this.gvw_bottom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId_bottom,
            this.OperatorName,
            this.ContinueName,
            this.OperatorType,
            this.OPTDate_bottom,
            this.Remarks_bottom,
            this.CreateTime_bottom,
            this.CreateUser_bottom});
            this.gvw_bottom.GridControl = this.gcl_bottom;
            this.gvw_bottom.Name = "gvw_bottom";
            this.gvw_bottom.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_bottom.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_bottom.OptionsBehavior.Editable = false;
            this.gvw_bottom.OptionsView.ColumnAutoWidth = false;
            this.gvw_bottom.OptionsView.ShowGroupPanel = false;
            // 
            // IntId_bottom
            // 
            this.IntId_bottom.Caption = "IntId";
            this.IntId_bottom.FieldName = "IntId";
            this.IntId_bottom.Name = "IntId_bottom";
            // 
            // OperatorName
            // 
            this.OperatorName.Caption = "操作人";
            this.OperatorName.FieldName = "Operator.UserNickName";
            this.OperatorName.Name = "OperatorName";
            this.OperatorName.Visible = true;
            this.OperatorName.VisibleIndex = 0;
            // 
            // ContinueName
            // 
            this.ContinueName.Caption = "接收人";
            this.ContinueName.FieldName = "Continue.UserNickName";
            this.ContinueName.Name = "ContinueName";
            this.ContinueName.Visible = true;
            this.ContinueName.VisibleIndex = 1;
            // 
            // OperatorType
            // 
            this.OperatorType.Caption = "操作类别";
            this.OperatorType.FieldName = "OperatorType";
            this.OperatorType.Name = "OperatorType";
            this.OperatorType.Visible = true;
            this.OperatorType.VisibleIndex = 2;
            // 
            // OPTDate_bottom
            // 
            this.OPTDate_bottom.Caption = "操作时间";
            this.OPTDate_bottom.DisplayFormat.FormatString = "DateTime \"F\"";
            this.OPTDate_bottom.FieldName = "OPTDate";
            this.OPTDate_bottom.Name = "OPTDate_bottom";
            this.OPTDate_bottom.Visible = true;
            this.OPTDate_bottom.VisibleIndex = 3;
            // 
            // Remarks_bottom
            // 
            this.Remarks_bottom.Caption = "备注";
            this.Remarks_bottom.FieldName = "Remarks";
            this.Remarks_bottom.Name = "Remarks_bottom";
            this.Remarks_bottom.Visible = true;
            this.Remarks_bottom.VisibleIndex = 4;
            // 
            // CreateTime_bottom
            // 
            this.CreateTime_bottom.Caption = "新增时间";
            this.CreateTime_bottom.DisplayFormat.FormatString = "F";
            this.CreateTime_bottom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime_bottom.FieldName = "CreateTime";
            this.CreateTime_bottom.Name = "CreateTime_bottom";
            this.CreateTime_bottom.Visible = true;
            this.CreateTime_bottom.VisibleIndex = 5;
            // 
            // CreateUser_bottom
            // 
            this.CreateUser_bottom.Caption = "新增人";
            this.CreateUser_bottom.FieldName = "CreateUser.UserNickName";
            this.CreateUser_bottom.Name = "CreateUser_bottom";
            this.CreateUser_bottom.Visible = true;
            this.CreateUser_bottom.VisibleIndex = 6;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Refresh,
            this.gToolStripButton2,
            this.txt_FirstDeliveryUser,
            this.gToolStripButton3,
            this.gToolStripButton4,
            this.txt_IsDeliveried});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 262);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(367, 25);
            this.gToolStrip1.TabIndex = 15;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.refresh_16;
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(52, 22);
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // gToolStripButton2
            // 
            this.gToolStripButton2.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.update_16;
            this.gToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton2.Name = "gToolStripButton2";
            this.gToolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.gToolStripButton2.Text = "拟准";
            this.gToolStripButton2.Click += new System.EventHandler(this.gToolStripButton2_Click);
            // 
            // txt_FirstDeliveryUser
            // 
            this.txt_FirstDeliveryUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txt_FirstDeliveryUser.Image = ((System.Drawing.Image)(resources.GetObject("txt_FirstDeliveryUser.Image")));
            this.txt_FirstDeliveryUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txt_FirstDeliveryUser.Name = "txt_FirstDeliveryUser";
            this.txt_FirstDeliveryUser.Size = new System.Drawing.Size(69, 22);
            this.txt_FirstDeliveryUser.Text = "拟准对象";
            // 
            // gToolStripButton3
            // 
            this.gToolStripButton3.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.confirm_16;
            this.gToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton3.Name = "gToolStripButton3";
            this.gToolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.gToolStripButton3.Text = "核准";
            this.gToolStripButton3.Click += new System.EventHandler(this.gToolStripButton3_Click);
            // 
            // gToolStripButton4
            // 
            this.gToolStripButton4.Image = global::LTN.CS.Base.BaseForm.Properties.Resources.cancel_16;
            this.gToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gToolStripButton4.Name = "gToolStripButton4";
            this.gToolStripButton4.Size = new System.Drawing.Size(52, 22);
            this.gToolStripButton4.Text = "退回";
            this.gToolStripButton4.Click += new System.EventHandler(this.gToolStripButton4_Click);
            // 
            // txt_IsDeliveried
            // 
            this.txt_IsDeliveried.Name = "txt_IsDeliveried";
            this.txt_IsDeliveried.Size = new System.Drawing.Size(75, 19);
            this.txt_IsDeliveried.Text = "已审批";
            this.txt_IsDeliveried.Click += new System.EventHandler(this.txt_IsDeliveried_Click);
            // 
            // gcl_left
            // 
            this.gcl_left.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcl_left.Location = new System.Drawing.Point(0, 0);
            this.gcl_left.MainView = this.gvw_left;
            this.gcl_left.Name = "gcl_left";
            this.gcl_left.Size = new System.Drawing.Size(367, 262);
            this.gcl_left.TabIndex = 14;
            this.gcl_left.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_left});
            // 
            // gvw_left
            // 
            this.gvw_left.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId_Main,
            this.Title,
            this.ServiceName,
            this.FirstReporter,
            this.UserNickName,
            this.OptDate,
            this.Status,
            this.Remarks,
            this.CreateTime_Main,
            this.CreateUser_Main,
            this.UpdateTime_Main,
            this.UpdateUser_Main});
            this.gvw_left.GridControl = this.gcl_left;
            this.gvw_left.Name = "gvw_left";
            this.gvw_left.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_left.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_left.OptionsBehavior.Editable = false;
            this.gvw_left.OptionsView.ColumnAutoWidth = false;
            this.gvw_left.OptionsView.ShowGroupPanel = false;
            this.gvw_left.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_left_FocusedRowChanged);
            // 
            // IntId_Main
            // 
            this.IntId_Main.Caption = "IntId";
            this.IntId_Main.FieldName = "IntId";
            this.IntId_Main.Name = "IntId_Main";
            // 
            // Title
            // 
            this.Title.Caption = "标题";
            this.Title.FieldName = "Title";
            this.Title.Name = "Title";
            this.Title.Visible = true;
            this.Title.VisibleIndex = 0;
            // 
            // ServiceName
            // 
            this.ServiceName.Caption = "服务名称";
            this.ServiceName.FieldName = "ServiceName";
            this.ServiceName.Name = "ServiceName";
            // 
            // FirstReporter
            // 
            this.FirstReporter.Caption = "单据提交人";
            this.FirstReporter.FieldName = "FirstReporter.UserNickName";
            this.FirstReporter.Name = "FirstReporter";
            this.FirstReporter.Visible = true;
            this.FirstReporter.VisibleIndex = 2;
            // 
            // UserNickName
            // 
            this.UserNickName.Caption = "当前申请人";
            this.UserNickName.FieldName = "Reporter.UserNickName";
            this.UserNickName.Name = "UserNickName";
            this.UserNickName.Visible = true;
            this.UserNickName.VisibleIndex = 1;
            // 
            // OptDate
            // 
            this.OptDate.Caption = "申请日期";
            this.OptDate.DisplayFormat.FormatString = "F";
            this.OptDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.OptDate.FieldName = "OptDate";
            this.OptDate.Name = "OptDate";
            this.OptDate.Visible = true;
            this.OptDate.VisibleIndex = 3;
            // 
            // Status
            // 
            this.Status.Caption = "状态";
            this.Status.FieldName = "Status.DeliveryDes";
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.VisibleIndex = 4;
            // 
            // Remarks
            // 
            this.Remarks.Caption = "备注";
            this.Remarks.FieldName = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Visible = true;
            this.Remarks.VisibleIndex = 5;
            // 
            // CreateTime_Main
            // 
            this.CreateTime_Main.Caption = "新增时间";
            this.CreateTime_Main.DisplayFormat.FormatString = "F";
            this.CreateTime_Main.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime_Main.FieldName = "CreateTime";
            this.CreateTime_Main.Name = "CreateTime_Main";
            this.CreateTime_Main.Visible = true;
            this.CreateTime_Main.VisibleIndex = 6;
            // 
            // CreateUser_Main
            // 
            this.CreateUser_Main.Caption = "新增人员";
            this.CreateUser_Main.FieldName = "CreateUser.UserNickName";
            this.CreateUser_Main.Name = "CreateUser_Main";
            this.CreateUser_Main.Visible = true;
            this.CreateUser_Main.VisibleIndex = 7;
            // 
            // UpdateTime_Main
            // 
            this.UpdateTime_Main.Caption = "修改时间";
            this.UpdateTime_Main.FieldName = "UpdateTime";
            this.UpdateTime_Main.Name = "UpdateTime_Main";
            // 
            // UpdateUser_Main
            // 
            this.UpdateUser_Main.Caption = "修改人员";
            this.UpdateUser_Main.FieldName = "UpdateUser.UserNickName";
            this.UpdateUser_Main.Name = "UpdateUser_Main";
            // 
            // gcl_right
            // 
            this.gcl_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_right.Location = new System.Drawing.Point(0, 0);
            this.gcl_right.MainView = this.gvw_right;
            this.gcl_right.Name = "gcl_right";
            this.gcl_right.Size = new System.Drawing.Size(519, 437);
            this.gcl_right.TabIndex = 15;
            this.gcl_right.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvw_right});
            // 
            // gvw_right
            // 
            this.gvw_right.GridControl = this.gcl_right;
            this.gvw_right.Name = "gvw_right";
            this.gvw_right.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_right.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvw_right.OptionsBehavior.Editable = false;
            this.gvw_right.OptionsView.ColumnAutoWidth = false;
            this.gvw_right.OptionsView.ShowGroupPanel = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textEdit1.Location = new System.Drawing.Point(0, 437);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(519, 38);
            toolTipItem1.Text = "备注信息";
            superToolTip1.Items.Add(toolTipItem1);
            this.textEdit1.SuperTip = superToolTip1;
            this.textEdit1.TabIndex = 16;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup1";
            this.layoutControlGroup2.Size = new System.Drawing.Size(300, 475);
            this.layoutControlGroup2.Text = "layoutControlGroup1";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup1";
            this.layoutControlGroup3.Size = new System.Drawing.Size(300, 475);
            this.layoutControlGroup3.Text = "layoutControlGroup1";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // BM_DELIVERY_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 475);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_DELIVERY_Form";
            this.Text = "审核管理";
            this.Load += new System.EventHandler(this.BM_DELIVERY_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_bottom)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gcl_left;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_left;
        private DevExpress.XtraGrid.GridControl gcl_bottom;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_bottom;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Refresh;
        private Core.Helper.GToolStripButton gToolStripButton2;
        private Core.Helper.GToolStripButton gToolStripButton3;
        private Core.Helper.GToolStripButton gToolStripButton4;
        private Core.Helper.GToolStripCheckEdit txt_IsDeliveried;
        private DevExpress.XtraGrid.GridControl gcl_right;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_right;
        private DevExpress.XtraGrid.Columns.GridColumn IntId_Main;
        private System.Windows.Forms.ToolStripDropDownButton txt_FirstDeliveryUser;
        private DevExpress.XtraGrid.Columns.GridColumn ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn FirstReporter;
        private DevExpress.XtraGrid.Columns.GridColumn UserNickName;
        private DevExpress.XtraGrid.Columns.GridColumn OptDate;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn Remarks;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime_Main;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser_Main;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateTime_Main;
        private DevExpress.XtraGrid.Columns.GridColumn UpdateUser_Main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId_bottom;
        private DevExpress.XtraGrid.Columns.GridColumn OperatorName;
        private DevExpress.XtraGrid.Columns.GridColumn ContinueName;
        private DevExpress.XtraGrid.Columns.GridColumn OperatorType;
        private DevExpress.XtraGrid.Columns.GridColumn OPTDate_bottom;
        private DevExpress.XtraGrid.Columns.GridColumn Remarks_bottom;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime_bottom;
        private DevExpress.XtraGrid.Columns.GridColumn CreateUser_bottom;
        private DevExpress.XtraEditors.MemoEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Title;

    }
}