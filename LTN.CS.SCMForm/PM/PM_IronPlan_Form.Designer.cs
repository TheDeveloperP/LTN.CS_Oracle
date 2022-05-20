namespace LTN.CS.SCMForm.PM
{
    partial class PM_IronPlan_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM_IronPlan_Form));
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_Cancel = new LTN.CS.Core.Helper.GToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_ToDept = new DevExpress.XtraEditors.TextEdit();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.lue_BillStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_TankNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_LronNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_BatchNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_HeatNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_PlanNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.委托单号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.炉号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.铁次号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.计量状态 = new DevExpress.XtraLayout.LayoutControlItem();
            this.备注 = new DevExpress.XtraLayout.LayoutControlItem();
            this.炉批号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.铁水罐号 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.去向单位 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ToDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_BillStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TankNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LronNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_HeatNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁次号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.计量状态)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.备注)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉批号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁水罐号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.去向单位)).BeginInit();
            this.SuspendLayout();
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Confirm,
            this.btn_Cancel});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(519, 35);
            this.gToolStrip1.TabIndex = 4;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(76, 32);
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(76, 32);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_ToDept);
            this.layoutControl1.Controls.Add(this.txt_Remark);
            this.layoutControl1.Controls.Add(this.lue_BillStatus);
            this.layoutControl1.Controls.Add(this.txt_TankNo);
            this.layoutControl1.Controls.Add(this.txt_LronNo);
            this.layoutControl1.Controls.Add(this.txt_BatchNo);
            this.layoutControl1.Controls.Add(this.txt_HeatNo);
            this.layoutControl1.Controls.Add(this.txt_PlanNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 35);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(747, 23, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(519, 276);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_ToDept
            // 
            this.txt_ToDept.Location = new System.Drawing.Point(336, 76);
            this.txt_ToDept.Name = "txt_ToDept";
            this.txt_ToDept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_ToDept.Properties.Appearance.Options.UseFont = true;
            this.txt_ToDept.Size = new System.Drawing.Size(171, 28);
            this.txt_ToDept.StyleController = this.layoutControl1;
            this.txt_ToDept.TabIndex = 14;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(87, 140);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(420, 124);
            this.txt_Remark.TabIndex = 13;
            // 
            // lue_BillStatus
            // 
            this.lue_BillStatus.Location = new System.Drawing.Point(87, 108);
            this.lue_BillStatus.Name = "lue_BillStatus";
            this.lue_BillStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lue_BillStatus.Properties.Appearance.Options.UseFont = true;
            this.lue_BillStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_BillStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntValue", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BillStatusDesc", "计量状态")});
            this.lue_BillStatus.Properties.DisplayMember = "BillStatusDesc";
            this.lue_BillStatus.Properties.NullText = "";
            this.lue_BillStatus.Properties.ValueMember = "IntValue";
            this.lue_BillStatus.Size = new System.Drawing.Size(170, 28);
            this.lue_BillStatus.StyleController = this.layoutControl1;
            this.lue_BillStatus.TabIndex = 12;
            // 
            // txt_TankNo
            // 
            this.txt_TankNo.Location = new System.Drawing.Point(87, 76);
            this.txt_TankNo.Name = "txt_TankNo";
            this.txt_TankNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_TankNo.Properties.Appearance.Options.UseFont = true;
            this.txt_TankNo.Size = new System.Drawing.Size(170, 28);
            this.txt_TankNo.StyleController = this.layoutControl1;
            this.txt_TankNo.TabIndex = 10;
            // 
            // txt_LronNo
            // 
            this.txt_LronNo.Location = new System.Drawing.Point(336, 44);
            this.txt_LronNo.Name = "txt_LronNo";
            this.txt_LronNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_LronNo.Properties.Appearance.Options.UseFont = true;
            this.txt_LronNo.Size = new System.Drawing.Size(171, 28);
            this.txt_LronNo.StyleController = this.layoutControl1;
            this.txt_LronNo.TabIndex = 9;
            // 
            // txt_BatchNo
            // 
            this.txt_BatchNo.Location = new System.Drawing.Point(87, 44);
            this.txt_BatchNo.Name = "txt_BatchNo";
            this.txt_BatchNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_BatchNo.Properties.Appearance.Options.UseFont = true;
            this.txt_BatchNo.Size = new System.Drawing.Size(170, 28);
            this.txt_BatchNo.StyleController = this.layoutControl1;
            this.txt_BatchNo.TabIndex = 8;
            // 
            // txt_HeatNo
            // 
            this.txt_HeatNo.Location = new System.Drawing.Point(336, 12);
            this.txt_HeatNo.Name = "txt_HeatNo";
            this.txt_HeatNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_HeatNo.Properties.Appearance.Options.UseFont = true;
            this.txt_HeatNo.Size = new System.Drawing.Size(171, 28);
            this.txt_HeatNo.StyleController = this.layoutControl1;
            this.txt_HeatNo.TabIndex = 7;
            // 
            // txt_PlanNo
            // 
            this.txt_PlanNo.Location = new System.Drawing.Point(87, 12);
            this.txt_PlanNo.Name = "txt_PlanNo";
            this.txt_PlanNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txt_PlanNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PlanNo.Properties.ReadOnly = true;
            this.txt_PlanNo.Size = new System.Drawing.Size(170, 28);
            this.txt_PlanNo.StyleController = this.layoutControl1;
            this.txt_PlanNo.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.委托单号,
            this.炉号,
            this.铁次号,
            this.计量状态,
            this.备注,
            this.炉批号,
            this.铁水罐号,
            this.emptySpaceItem1,
            this.去向单位});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(519, 276);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // 委托单号
            // 
            this.委托单号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.委托单号.AppearanceItemCaption.Options.UseFont = true;
            this.委托单号.Control = this.txt_PlanNo;
            this.委托单号.Location = new System.Drawing.Point(0, 0);
            this.委托单号.Name = "委托单号";
            this.委托单号.Size = new System.Drawing.Size(249, 32);
            this.委托单号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 炉号
            // 
            this.炉号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.炉号.AppearanceItemCaption.Options.UseFont = true;
            this.炉号.Control = this.txt_HeatNo;
            this.炉号.Location = new System.Drawing.Point(249, 0);
            this.炉号.Name = "炉号";
            this.炉号.Size = new System.Drawing.Size(250, 32);
            this.炉号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 铁次号
            // 
            this.铁次号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.铁次号.AppearanceItemCaption.Options.UseFont = true;
            this.铁次号.Control = this.txt_LronNo;
            this.铁次号.Location = new System.Drawing.Point(249, 32);
            this.铁次号.Name = "铁次号";
            this.铁次号.Size = new System.Drawing.Size(250, 32);
            this.铁次号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 计量状态
            // 
            this.计量状态.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.计量状态.AppearanceItemCaption.Options.UseFont = true;
            this.计量状态.Control = this.lue_BillStatus;
            this.计量状态.Location = new System.Drawing.Point(0, 96);
            this.计量状态.Name = "计量状态";
            this.计量状态.Size = new System.Drawing.Size(249, 32);
            this.计量状态.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 备注
            // 
            this.备注.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.备注.AppearanceItemCaption.Options.UseFont = true;
            this.备注.Control = this.txt_Remark;
            this.备注.Location = new System.Drawing.Point(0, 128);
            this.备注.Name = "备注";
            this.备注.Size = new System.Drawing.Size(499, 128);
            this.备注.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 炉批号
            // 
            this.炉批号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.炉批号.AppearanceItemCaption.Options.UseFont = true;
            this.炉批号.Control = this.txt_BatchNo;
            this.炉批号.Location = new System.Drawing.Point(0, 32);
            this.炉批号.Name = "炉批号";
            this.炉批号.Size = new System.Drawing.Size(249, 32);
            this.炉批号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // 铁水罐号
            // 
            this.铁水罐号.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.铁水罐号.AppearanceItemCaption.Options.UseFont = true;
            this.铁水罐号.Control = this.txt_TankNo;
            this.铁水罐号.Location = new System.Drawing.Point(0, 64);
            this.铁水罐号.Name = "铁水罐号";
            this.铁水罐号.Size = new System.Drawing.Size(249, 32);
            this.铁水罐号.TextSize = new System.Drawing.Size(72, 22);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(249, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(250, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // 去向单位
            // 
            this.去向单位.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F);
            this.去向单位.AppearanceItemCaption.Options.UseFont = true;
            this.去向单位.Control = this.txt_ToDept;
            this.去向单位.Location = new System.Drawing.Point(249, 64);
            this.去向单位.Name = "去向单位";
            this.去向单位.Size = new System.Drawing.Size(250, 32);
            this.去向单位.TextSize = new System.Drawing.Size(72, 22);
            // 
            // PM_IronPlan_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 311);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Name = "PM_IronPlan_Form";
            this.Text = "铁水计划制作";
            this.Shown += new System.EventHandler(this.PM_IronPlan_Form_Shown);
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ToDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_BillStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TankNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LronNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_HeatNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.委托单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁次号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.计量状态)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.备注)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.炉批号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.铁水罐号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.去向单位)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Confirm;
        private Core.Helper.GToolStripButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt_PlanNo;
        private DevExpress.XtraLayout.LayoutControlItem 委托单号;
        private DevExpress.XtraEditors.TextEdit txt_HeatNo;
        private DevExpress.XtraLayout.LayoutControlItem 炉号;
        private DevExpress.XtraEditors.TextEdit txt_BatchNo;
        private DevExpress.XtraLayout.LayoutControlItem 炉批号;
        private DevExpress.XtraEditors.TextEdit txt_LronNo;
        private DevExpress.XtraLayout.LayoutControlItem 铁次号;
        private DevExpress.XtraEditors.TextEdit txt_TankNo;
        private DevExpress.XtraLayout.LayoutControlItem 铁水罐号;
        private DevExpress.XtraEditors.LookUpEdit lue_BillStatus;
        private DevExpress.XtraLayout.LayoutControlItem 计量状态;
        private System.Windows.Forms.TextBox txt_Remark;
        private DevExpress.XtraLayout.LayoutControlItem 备注;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txt_ToDept;
        private DevExpress.XtraLayout.LayoutControlItem 去向单位;
    }
}