namespace LTN.CS.SCMForm.SM
{
    partial class SM_Container_Info
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.de_starttime = new DevExpress.XtraEditors.DateEdit();
            this.txt_LevelOneCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gcl_main = new DevExpress.XtraGrid.GridControl();
            this.gvw_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.I_INTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_PondNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CarName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CarName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_ContainerNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.I_ContainerStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_PhotoAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_CameraTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelOneCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1250, 75);
            this.panelControl1.TabIndex = 21;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.de_starttime);
            this.layoutControl1.Controls.Add(this.txt_LevelOneCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(277, 181, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1246, 71);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(784, 12);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dateEdit1.Size = new System.Drawing.Size(306, 26);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 22;
            // 
            // de_starttime
            // 
            this.de_starttime.EditValue = null;
            this.de_starttime.Location = new System.Drawing.Point(385, 12);
            this.de_starttime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.de_starttime.Name = "de_starttime";
            this.de_starttime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_starttime.Properties.Appearance.Options.UseFont = true;
            this.de_starttime.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.de_starttime.Properties.AppearanceFocused.Options.UseFont = true;
            this.de_starttime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_starttime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_starttime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_starttime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_starttime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.de_starttime.Size = new System.Drawing.Size(328, 26);
            this.de_starttime.StyleController = this.layoutControl1;
            this.de_starttime.TabIndex = 22;
            // 
            // txt_LevelOneCode
            // 
            this.txt_LevelOneCode.Location = new System.Drawing.Point(79, 12);
            this.txt_LevelOneCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LevelOneCode.Name = "txt_LevelOneCode";
            this.txt_LevelOneCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LevelOneCode.Properties.Appearance.Options.UseFont = true;
            this.txt_LevelOneCode.Size = new System.Drawing.Size(235, 26);
            this.txt_LevelOneCode.StyleController = this.layoutControl1;
            this.txt_LevelOneCode.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1246, 71);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_LevelOneCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(306, 51);
            this.layoutControlItem1.Text = "车牌号码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1082, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(144, 51);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.de_starttime;
            this.layoutControlItem2.Location = new System.Drawing.Point(306, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(399, 51);
            this.layoutControlItem2.Text = "开始时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dateEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(705, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(377, 51);
            this.layoutControlItem3.Text = "结束时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 19);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_query});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 75);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.gToolStrip1.Size = new System.Drawing.Size(1250, 45);
            this.gToolStrip1.TabIndex = 22;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_query
            // 
            this.btn_query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(56, 42);
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // gcl_main
            // 
            this.gcl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_main.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(12, 18, 12, 18);
            this.gcl_main.Location = new System.Drawing.Point(0, 120);
            this.gcl_main.MainView = this.gvw_main;
            this.gcl_main.Margin = new System.Windows.Forms.Padding(12, 18, 12, 18);
            this.gcl_main.Name = "gcl_main";
            this.gcl_main.Size = new System.Drawing.Size(1250, 629);
            this.gcl_main.TabIndex = 23;
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
            this.I_INTID,
            this.C_PondNo,
            this.C_CarName,
            this.C_CarName2,
            this.C_CarName3,
            this.C_ContainerNO,
            this.I_ContainerStatus,
            this.C_PhotoAddress,
            this.C_CameraTime});
            this.gvw_main.GridControl = this.gcl_main;
            this.gvw_main.Name = "gvw_main";
            this.gvw_main.OptionsBehavior.Editable = false;
            this.gvw_main.OptionsBehavior.ReadOnly = true;
            this.gvw_main.OptionsView.ColumnAutoWidth = false;
            this.gvw_main.OptionsView.ShowGroupPanel = false;
            this.gvw_main.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvw_main_CustomColumnDisplayText);
            // 
            // I_INTID
            // 
            this.I_INTID.Caption = "主键";
            this.I_INTID.FieldName = "I_INTID";
            this.I_INTID.Name = "I_INTID";
            this.I_INTID.Width = 115;
            // 
            // C_PondNo
            // 
            this.C_PondNo.Caption = "磅点编号";
            this.C_PondNo.FieldName = "C_PondNo";
            this.C_PondNo.Name = "C_PondNo";
            this.C_PondNo.Visible = true;
            this.C_PondNo.VisibleIndex = 0;
            // 
            // C_CarName
            // 
            this.C_CarName.Caption = "车号1";
            this.C_CarName.FieldName = "C_CarName";
            this.C_CarName.Name = "C_CarName";
            this.C_CarName.Visible = true;
            this.C_CarName.VisibleIndex = 1;
            this.C_CarName.Width = 94;
            // 
            // C_CarName2
            // 
            this.C_CarName2.Caption = "车号2";
            this.C_CarName2.FieldName = "C_CarName2";
            this.C_CarName2.Name = "C_CarName2";
            this.C_CarName2.Visible = true;
            this.C_CarName2.VisibleIndex = 2;
            this.C_CarName2.Width = 100;
            // 
            // C_CarName3
            // 
            this.C_CarName3.Caption = "车号3";
            this.C_CarName3.FieldName = "C_CarName3";
            this.C_CarName3.Name = "C_CarName3";
            this.C_CarName3.Visible = true;
            this.C_CarName3.VisibleIndex = 3;
            this.C_CarName3.Width = 100;
            // 
            // C_ContainerNO
            // 
            this.C_ContainerNO.Caption = "识别集装箱号";
            this.C_ContainerNO.FieldName = "C_ContainerNO";
            this.C_ContainerNO.Name = "C_ContainerNO";
            this.C_ContainerNO.Visible = true;
            this.C_ContainerNO.VisibleIndex = 4;
            this.C_ContainerNO.Width = 120;
            // 
            // I_ContainerStatus
            // 
            this.I_ContainerStatus.Caption = "识别结果标识";
            this.I_ContainerStatus.FieldName = "I_ContainerStatus";
            this.I_ContainerStatus.Name = "I_ContainerStatus";
            this.I_ContainerStatus.Visible = true;
            this.I_ContainerStatus.VisibleIndex = 5;
            this.I_ContainerStatus.Width = 113;
            // 
            // C_PhotoAddress
            // 
            this.C_PhotoAddress.Caption = "图片地址";
            this.C_PhotoAddress.FieldName = "C_PhotoAddress";
            this.C_PhotoAddress.Name = "C_PhotoAddress";
            this.C_PhotoAddress.Visible = true;
            this.C_PhotoAddress.VisibleIndex = 7;
            this.C_PhotoAddress.Width = 437;
            // 
            // C_CameraTime
            // 
            this.C_CameraTime.Caption = "识别时间";
            this.C_CameraTime.FieldName = "C_CameraTime";
            this.C_CameraTime.Name = "C_CameraTime";
            this.C_CameraTime.Visible = true;
            this.C_CameraTime.VisibleIndex = 6;
            this.C_CameraTime.Width = 180;
            // 
            // SM_Container_Info
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 749);
            this.Controls.Add(this.gcl_main);
            this.Controls.Add(this.gToolStrip1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SM_Container_Info";
            this.Text = "集装箱号识别记录";
            this.Shown += new System.EventHandler(this.SM_Container_Info_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_starttime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LevelOneCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvw_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_LevelOneCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit de_starttime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_query;
        private DevExpress.XtraGrid.GridControl gcl_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gvw_main;
        private DevExpress.XtraGrid.Columns.GridColumn I_INTID;
        private DevExpress.XtraGrid.Columns.GridColumn C_PondNo;
        private DevExpress.XtraGrid.Columns.GridColumn C_CarName;
        private DevExpress.XtraGrid.Columns.GridColumn C_CarName2;
        private DevExpress.XtraGrid.Columns.GridColumn C_CarName3;
        private DevExpress.XtraGrid.Columns.GridColumn C_ContainerNO;
        private DevExpress.XtraGrid.Columns.GridColumn I_ContainerStatus;
        private DevExpress.XtraGrid.Columns.GridColumn C_PhotoAddress;
        private DevExpress.XtraGrid.Columns.GridColumn C_CameraTime;
    }
}