namespace LTN.CS.SCMForm.SM
{
    partial class SM_Car_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SM_Car_Form));
            this.gCtrl_main = new DevExpress.XtraGrid.GridControl();
            this.gView_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IntId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CarPeople = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CarTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StandardTare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAuto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Search = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Add = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_update = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Delete = new LTN.CS.Core.Helper.GToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ch_IsAuto = new DevExpress.XtraEditors.CheckEdit();
            this.txt_CarTelePhone = new DevExpress.XtraEditors.TextEdit();
            this.txt_StandardTare = new DevExpress.XtraEditors.TextEdit();
            this.txt_CarPeople = new DevExpress.XtraEditors.TextEdit();
            this.txt_CarName = new DevExpress.XtraEditors.TextEdit();
            this.txt_CarNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_searchCarName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_main)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_IsAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarTelePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StandardTare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarPeople.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_searchCarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gCtrl_main
            // 
            this.gCtrl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_main.Location = new System.Drawing.Point(0, 165);
            this.gCtrl_main.MainView = this.gView_main;
            this.gCtrl_main.Name = "gCtrl_main";
            this.gCtrl_main.Size = new System.Drawing.Size(1260, 499);
            this.gCtrl_main.TabIndex = 20;
            this.gCtrl_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_main});
            // 
            // gView_main
            // 
            this.gView_main.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gView_main.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_main.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gView_main.Appearance.Row.Options.UseFont = true;
            this.gView_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IntId,
            this.CarNo,
            this.CarName,
            this.CarPeople,
            this.CarTelephone,
            this.StandardTare,
            this.IsAuto,
            this.CreateUser,
            this.CreateTime,
            this.UpdateUser,
            this.UpdateTime});
            this.gView_main.GridControl = this.gCtrl_main;
            this.gView_main.Name = "gView_main";
            this.gView_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gView_main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gView_main.OptionsBehavior.Editable = false;
            this.gView_main.OptionsView.ColumnAutoWidth = false;
            this.gView_main.OptionsView.ShowGroupPanel = false;
            this.gView_main.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CreateTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gView_main.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvw_main_CustomDrawCell);
            this.gView_main.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvw_main_FocusedRowChanged);
            // 
            // IntId
            // 
            this.IntId.Caption = "主键";
            this.IntId.FieldName = "IntId";
            this.IntId.Name = "IntId";
            // 
            // CarNo
            // 
            this.CarNo.Caption = "车辆编号";
            this.CarNo.FieldName = "CarNo";
            this.CarNo.Name = "CarNo";
            this.CarNo.Visible = true;
            this.CarNo.VisibleIndex = 0;
            // 
            // CarName
            // 
            this.CarName.Caption = "车号";
            this.CarName.FieldName = "CarName";
            this.CarName.Name = "CarName";
            this.CarName.Visible = true;
            this.CarName.VisibleIndex = 1;
            // 
            // CarPeople
            // 
            this.CarPeople.Caption = "车主姓名";
            this.CarPeople.FieldName = "CarPeople";
            this.CarPeople.Name = "CarPeople";
            this.CarPeople.Visible = true;
            this.CarPeople.VisibleIndex = 2;
            // 
            // CarTelephone
            // 
            this.CarTelephone.Caption = "联系方式";
            this.CarTelephone.FieldName = "CarTelephone";
            this.CarTelephone.Name = "CarTelephone";
            this.CarTelephone.Visible = true;
            this.CarTelephone.VisibleIndex = 3;
            // 
            // StandardTare
            // 
            this.StandardTare.Caption = "标准皮重";
            this.StandardTare.FieldName = "StandardTare";
            this.StandardTare.Name = "StandardTare";
            // 
            // IsAuto
            // 
            this.IsAuto.Caption = "是否自动过磅";
            this.IsAuto.FieldName = "IsAuto.EntityDes";
            this.IsAuto.Name = "IsAuto";
            this.IsAuto.Width = 86;
            // 
            // CreateUser
            // 
            this.CreateUser.Caption = "新增人员";
            this.CreateUser.FieldName = "CreateUserName";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Visible = true;
            this.CreateUser.VisibleIndex = 4;
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
            this.CreateTime.Width = 115;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Caption = "修改人员";
            this.UpdateUser.FieldName = "UpdateUserName";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = true;
            this.UpdateUser.VisibleIndex = 6;
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
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Search,
            this.btn_Add,
            this.btn_update,
            this.btn_Confirm,
            this.btn_Cancel,
            this.btn_Delete});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 132);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.gToolStrip1.Size = new System.Drawing.Size(1260, 33);
            this.gToolStrip1.TabIndex = 19;
            this.gToolStrip1.Text = "gToolStrip3";
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(74, 30);
            this.btn_Search.Text = "查询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(73, 30);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(73, 30);
            this.btn_update.Text = "修改";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(73, 30);
            this.btn_Confirm.Text = "确认";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 30);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(73, 30);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1260, 132);
            this.panelControl1.TabIndex = 18;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ch_IsAuto);
            this.layoutControl1.Controls.Add(this.txt_CarTelePhone);
            this.layoutControl1.Controls.Add(this.txt_StandardTare);
            this.layoutControl1.Controls.Add(this.txt_CarPeople);
            this.layoutControl1.Controls.Add(this.txt_CarName);
            this.layoutControl1.Controls.Add(this.txt_CarNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(324, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(277, 181, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(934, 128);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ch_IsAuto
            // 
            this.ch_IsAuto.Enabled = false;
            this.ch_IsAuto.Location = new System.Drawing.Point(463, 16);
            this.ch_IsAuto.Name = "ch_IsAuto";
            this.ch_IsAuto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_IsAuto.Properties.Appearance.Options.UseFont = true;
            this.ch_IsAuto.Properties.Caption = "是否自动过磅(皮重)";
            this.ch_IsAuto.Size = new System.Drawing.Size(216, 28);
            this.ch_IsAuto.StyleController = this.layoutControl1;
            this.ch_IsAuto.TabIndex = 28;
            this.ch_IsAuto.Visible = false;
            // 
            // txt_CarTelePhone
            // 
            this.txt_CarTelePhone.Location = new System.Drawing.Point(276, 52);
            this.txt_CarTelePhone.Name = "txt_CarTelePhone";
            this.txt_CarTelePhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarTelePhone.Properties.Appearance.Options.UseFont = true;
            this.txt_CarTelePhone.Size = new System.Drawing.Size(89, 30);
            this.txt_CarTelePhone.StyleController = this.layoutControl1;
            this.txt_CarTelePhone.TabIndex = 18;
            // 
            // txt_StandardTare
            // 
            this.txt_StandardTare.Location = new System.Drawing.Point(546, 50);
            this.txt_StandardTare.Name = "txt_StandardTare";
            this.txt_StandardTare.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StandardTare.Properties.Appearance.Options.UseFont = true;
            this.txt_StandardTare.Size = new System.Drawing.Size(133, 30);
            this.txt_StandardTare.StyleController = this.layoutControl1;
            this.txt_StandardTare.TabIndex = 16;
            // 
            // txt_CarPeople
            // 
            this.txt_CarPeople.Location = new System.Drawing.Point(99, 52);
            this.txt_CarPeople.Name = "txt_CarPeople";
            this.txt_CarPeople.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarPeople.Properties.Appearance.Options.UseFont = true;
            this.txt_CarPeople.Size = new System.Drawing.Size(88, 30);
            this.txt_CarPeople.StyleController = this.layoutControl1;
            this.txt_CarPeople.TabIndex = 13;
            // 
            // txt_CarName
            // 
            this.txt_CarName.Location = new System.Drawing.Point(276, 16);
            this.txt_CarName.Name = "txt_CarName";
            this.txt_CarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarName.Properties.Appearance.Options.UseFont = true;
            this.txt_CarName.Size = new System.Drawing.Size(89, 30);
            this.txt_CarName.StyleController = this.layoutControl1;
            this.txt_CarName.TabIndex = 11;
            // 
            // txt_CarNo
            // 
            this.txt_CarNo.Enabled = false;
            this.txt_CarNo.Location = new System.Drawing.Point(99, 16);
            this.txt_CarNo.Name = "txt_CarNo";
            this.txt_CarNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CarNo.Properties.Appearance.Options.UseFont = true;
            this.txt_CarNo.Size = new System.Drawing.Size(88, 30);
            this.txt_CarNo.StyleController = this.layoutControl1;
            this.txt_CarNo.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(934, 128);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_CarNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(177, 36);
            this.layoutControlItem1.Text = "车辆编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_CarPeople;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(177, 66);
            this.layoutControlItem4.Text = "车主姓名";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.txt_CarTelePhone;
            this.layoutControlItem7.Location = new System.Drawing.Point(177, 36);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(178, 66);
            this.layoutControlItem7.Text = "车主电话";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_CarName;
            this.layoutControlItem2.Location = new System.Drawing.Point(177, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(178, 36);
            this.layoutControlItem2.Text = "车号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ch_IsAuto;
            this.layoutControlItem3.Location = new System.Drawing.Point(447, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(222, 34);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.txt_StandardTare;
            this.layoutControlItem6.Location = new System.Drawing.Point(447, 34);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(222, 68);
            this.layoutControlItem6.Text = "标准皮重";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(80, 24);
            this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(669, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(239, 102);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(355, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(92, 102);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(322, 128);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "车号查询条件";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txt_searchCarName);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 33);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(318, 93);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txt_searchCarName
            // 
            this.txt_searchCarName.Location = new System.Drawing.Point(60, 16);
            this.txt_searchCarName.Name = "txt_searchCarName";
            this.txt_searchCarName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_searchCarName.Properties.Appearance.Options.UseFont = true;
            this.txt_searchCarName.Size = new System.Drawing.Size(242, 30);
            this.txt_searchCarName.StyleController = this.layoutControl2;
            this.txt_searchCarName.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(318, 93);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_searchCarName;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(292, 67);
            this.layoutControlItem5.Text = "车号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(40, 24);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SM_Car_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 664);
            this.Controls.Add(this.gCtrl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "SM_Car_Form";
            this.ShowIcon = false;
            this.Text = "车辆基础信息管理";
            this.Shown += new System.EventHandler(this.SM_Car_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_main)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_IsAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarTelePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StandardTare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarPeople.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_searchCarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gCtrl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_main;
        private DevExpress.XtraGrid.Columns.GridColumn IntId;
        private DevExpress.XtraGrid.Columns.GridColumn CarNo;
        private DevExpress.XtraGrid.Columns.GridColumn CarName;
        private DevExpress.XtraGrid.Columns.GridColumn CarPeople;
        private DevExpress.XtraGrid.Columns.GridColumn CarTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn StandardTare;
        private DevExpress.XtraGrid.Columns.GridColumn IsAuto;
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
        private DevExpress.XtraEditors.CheckEdit ch_IsAuto;
        private DevExpress.XtraEditors.TextEdit txt_CarTelePhone;
        private DevExpress.XtraEditors.TextEdit txt_StandardTare;
        private DevExpress.XtraEditors.TextEdit txt_CarPeople;
        private DevExpress.XtraEditors.TextEdit txt_CarName;
        private DevExpress.XtraEditors.TextEdit txt_CarNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private Core.Helper.GToolStripButton btn_Search;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit txt_searchCarName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}