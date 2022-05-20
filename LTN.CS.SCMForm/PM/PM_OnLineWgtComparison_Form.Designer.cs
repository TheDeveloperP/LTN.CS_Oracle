namespace LTN.CS.SCMForm.PM
{
    partial class PM_OnLineWgtComparison_Form
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
            this.txt_PlanNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Query = new LTN.CS.Core.Helper.GToolStripButton();
            this.gView_TruckBillWithOnlineBills = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_C_PLANNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_MATERIALNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_GROSSWGT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_TAREWGT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_N_NETWGT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_Mat_Act_Wgt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_wgt_sub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_FROMDEPTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_TODEPTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_WGTLISTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_C_NETWGTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCtrl_TruckBillWithOnlineBills = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckBillWithOnlineBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckBillWithOnlineBills)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Controls.Add(this.gToolStrip1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1381, 126);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_PlanNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1375, 72);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_PlanNo
            // 
            this.txt_PlanNo.Location = new System.Drawing.Point(18, 18);
            this.txt_PlanNo.Name = "txt_PlanNo";
            this.txt_PlanNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PlanNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PlanNo.Size = new System.Drawing.Size(221, 36);
            this.txt_PlanNo.StyleController = this.layoutControl1;
            this.txt_PlanNo.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1375, 72);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_PlanNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(227, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1118, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Query});
            this.gToolStrip1.Location = new System.Drawing.Point(3, 75);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1375, 48);
            this.gToolStrip1.TabIndex = 0;
            this.gToolStrip1.Text = "查询";
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Query.Image = global::LTN.CS.SCMForm.Properties.Resources.Query_24;
            this.btn_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(85, 45);
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // gView_TruckBillWithOnlineBills
            // 
            this.gView_TruckBillWithOnlineBills.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gView_TruckBillWithOnlineBills.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_TruckBillWithOnlineBills.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gView_TruckBillWithOnlineBills.Appearance.Row.Options.UseFont = true;
            this.gView_TruckBillWithOnlineBills.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_C_PLANNO,
            this.gCol_C_MATERIALNAME,
            this.gCol_N_GROSSWGT,
            this.gCol_N_TAREWGT,
            this.gCol_N_NETWGT,
            this.gCol_Mat_Act_Wgt,
            this.gCol_wgt_sub,
            this.gCol_C_FROMDEPTNAME,
            this.gCol_C_TODEPTNAME,
            this.gCol_C_WGTLISTNO,
            this.gCol_C_NETWGTTIME});
            this.gView_TruckBillWithOnlineBills.GridControl = this.gCtrl_TruckBillWithOnlineBills;
            this.gView_TruckBillWithOnlineBills.Name = "gView_TruckBillWithOnlineBills";
            this.gView_TruckBillWithOnlineBills.OptionsBehavior.Editable = false;
            this.gView_TruckBillWithOnlineBills.OptionsView.ColumnAutoWidth = false;
            this.gView_TruckBillWithOnlineBills.OptionsView.ShowGroupPanel = false;
            // 
            // gCol_C_PLANNO
            // 
            this.gCol_C_PLANNO.Caption = "委托单号";
            this.gCol_C_PLANNO.FieldName = "C_PLANNO";
            this.gCol_C_PLANNO.Name = "gCol_C_PLANNO";
            this.gCol_C_PLANNO.Visible = true;
            this.gCol_C_PLANNO.VisibleIndex = 0;
            this.gCol_C_PLANNO.Width = 175;
            // 
            // gCol_C_MATERIALNAME
            // 
            this.gCol_C_MATERIALNAME.Caption = "物料名";
            this.gCol_C_MATERIALNAME.FieldName = "C_MATERIALNAME";
            this.gCol_C_MATERIALNAME.Name = "gCol_C_MATERIALNAME";
            this.gCol_C_MATERIALNAME.Visible = true;
            this.gCol_C_MATERIALNAME.VisibleIndex = 1;
            this.gCol_C_MATERIALNAME.Width = 100;
            // 
            // gCol_N_GROSSWGT
            // 
            this.gCol_N_GROSSWGT.Caption = "毛重";
            this.gCol_N_GROSSWGT.FieldName = "N_GROSSWGT";
            this.gCol_N_GROSSWGT.Name = "gCol_N_GROSSWGT";
            this.gCol_N_GROSSWGT.Visible = true;
            this.gCol_N_GROSSWGT.VisibleIndex = 2;
            // 
            // gCol_N_TAREWGT
            // 
            this.gCol_N_TAREWGT.Caption = "皮重";
            this.gCol_N_TAREWGT.FieldName = "N_TAREWGT";
            this.gCol_N_TAREWGT.Name = "gCol_N_TAREWGT";
            this.gCol_N_TAREWGT.Visible = true;
            this.gCol_N_TAREWGT.VisibleIndex = 3;
            // 
            // gCol_N_NETWGT
            // 
            this.gCol_N_NETWGT.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_N_NETWGT.AppearanceCell.Options.UseBackColor = true;
            this.gCol_N_NETWGT.Caption = "净重";
            this.gCol_N_NETWGT.FieldName = "N_NETWGT";
            this.gCol_N_NETWGT.Name = "gCol_N_NETWGT";
            this.gCol_N_NETWGT.Visible = true;
            this.gCol_N_NETWGT.VisibleIndex = 4;
            // 
            // gCol_Mat_Act_Wgt
            // 
            this.gCol_Mat_Act_Wgt.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_Mat_Act_Wgt.AppearanceCell.Options.UseBackColor = true;
            this.gCol_Mat_Act_Wgt.Caption = "材料总重量";
            this.gCol_Mat_Act_Wgt.FieldName = "Mat_Act_Wgt";
            this.gCol_Mat_Act_Wgt.Name = "gCol_Mat_Act_Wgt";
            this.gCol_Mat_Act_Wgt.Visible = true;
            this.gCol_Mat_Act_Wgt.VisibleIndex = 5;
            this.gCol_Mat_Act_Wgt.Width = 100;
            // 
            // gCol_wgt_sub
            // 
            this.gCol_wgt_sub.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gCol_wgt_sub.AppearanceCell.Options.UseBackColor = true;
            this.gCol_wgt_sub.Caption = "误差";
            this.gCol_wgt_sub.FieldName = "wgt_sub";
            this.gCol_wgt_sub.Name = "gCol_wgt_sub";
            this.gCol_wgt_sub.Visible = true;
            this.gCol_wgt_sub.VisibleIndex = 6;
            // 
            // gCol_C_FROMDEPTNAME
            // 
            this.gCol_C_FROMDEPTNAME.Caption = "来源单位";
            this.gCol_C_FROMDEPTNAME.FieldName = "C_FROMDEPTNAME";
            this.gCol_C_FROMDEPTNAME.Name = "gCol_C_FROMDEPTNAME";
            this.gCol_C_FROMDEPTNAME.Visible = true;
            this.gCol_C_FROMDEPTNAME.VisibleIndex = 7;
            this.gCol_C_FROMDEPTNAME.Width = 200;
            // 
            // gCol_C_TODEPTNAME
            // 
            this.gCol_C_TODEPTNAME.Caption = "去向单位";
            this.gCol_C_TODEPTNAME.FieldName = "C_TODEPTNAME";
            this.gCol_C_TODEPTNAME.Name = "gCol_C_TODEPTNAME";
            this.gCol_C_TODEPTNAME.Visible = true;
            this.gCol_C_TODEPTNAME.VisibleIndex = 8;
            this.gCol_C_TODEPTNAME.Width = 200;
            // 
            // gCol_C_WGTLISTNO
            // 
            this.gCol_C_WGTLISTNO.Caption = "磅单号";
            this.gCol_C_WGTLISTNO.FieldName = "C_WGTLISTNO";
            this.gCol_C_WGTLISTNO.Name = "gCol_C_WGTLISTNO";
            this.gCol_C_WGTLISTNO.Visible = true;
            this.gCol_C_WGTLISTNO.VisibleIndex = 9;
            this.gCol_C_WGTLISTNO.Width = 175;
            // 
            // gCol_C_NETWGTTIME
            // 
            this.gCol_C_NETWGTTIME.Caption = "净重时间";
            this.gCol_C_NETWGTTIME.FieldName = "C_NETWGTTIME";
            this.gCol_C_NETWGTTIME.Name = "gCol_C_NETWGTTIME";
            this.gCol_C_NETWGTTIME.Visible = true;
            this.gCol_C_NETWGTTIME.VisibleIndex = 10;
            this.gCol_C_NETWGTTIME.Width = 200;
            // 
            // gCtrl_TruckBillWithOnlineBills
            // 
            this.gCtrl_TruckBillWithOnlineBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_TruckBillWithOnlineBills.Location = new System.Drawing.Point(0, 126);
            this.gCtrl_TruckBillWithOnlineBills.MainView = this.gView_TruckBillWithOnlineBills;
            this.gCtrl_TruckBillWithOnlineBills.Name = "gCtrl_TruckBillWithOnlineBills";
            this.gCtrl_TruckBillWithOnlineBills.Size = new System.Drawing.Size(1381, 616);
            this.gCtrl_TruckBillWithOnlineBills.TabIndex = 1;
            this.gCtrl_TruckBillWithOnlineBills.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_TruckBillWithOnlineBills});
            // 
            // PM_OnLineWgtComparison_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 742);
            this.Controls.Add(this.gCtrl_TruckBillWithOnlineBills);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "PM_OnLineWgtComparison_Form";
            this.Text = "在线称重量比对";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gView_TruckBillWithOnlineBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_TruckBillWithOnlineBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_PlanNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Query;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_TruckBillWithOnlineBills;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_PLANNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_MATERIALNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_FROMDEPTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_TODEPTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_WGTLISTNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_TAREWGT;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_GROSSWGT;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_N_NETWGT;
        private DevExpress.XtraGrid.GridControl gCtrl_TruckBillWithOnlineBills;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_Mat_Act_Wgt;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_wgt_sub;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_C_NETWGTTIME;
    }
}