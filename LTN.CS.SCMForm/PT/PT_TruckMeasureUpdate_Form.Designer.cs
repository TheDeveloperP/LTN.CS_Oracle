namespace LTN.CS.SCMForm.PT
{
    partial class PT_TruckMeasureUpdate_Form
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_CONTAINERNO = new DevExpress.XtraEditors.TextEdit();
            this.txt_MATERIALNAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_todept = new DevExpress.XtraEditors.TextEdit();
            this.txt_fromdept = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Save = new LTN.CS.Core.Helper.GToolStripButton();
            this.btn_cancle = new LTN.CS.Core.Helper.GToolStripButton();
            this.txt_REMARK = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CONTAINERNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MATERIALNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_todept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fromdept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.gToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_REMARK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(674, 218);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_REMARK);
            this.layoutControl1.Controls.Add(this.txt_CONTAINERNO);
            this.layoutControl1.Controls.Add(this.txt_MATERIALNAME);
            this.layoutControl1.Controls.Add(this.txt_todept);
            this.layoutControl1.Controls.Add(this.txt_fromdept);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(670, 214);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CONTAINERNO
            // 
            this.txt_CONTAINERNO.Location = new System.Drawing.Point(100, 124);
            this.txt_CONTAINERNO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_CONTAINERNO.Name = "txt_CONTAINERNO";
            this.txt_CONTAINERNO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CONTAINERNO.Properties.Appearance.Options.UseFont = true;
            this.txt_CONTAINERNO.Size = new System.Drawing.Size(554, 30);
            this.txt_CONTAINERNO.StyleController = this.layoutControl1;
            this.txt_CONTAINERNO.TabIndex = 7;
            // 
            // txt_MATERIALNAME
            // 
            this.txt_MATERIALNAME.Location = new System.Drawing.Point(100, 16);
            this.txt_MATERIALNAME.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MATERIALNAME.Name = "txt_MATERIALNAME";
            this.txt_MATERIALNAME.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_MATERIALNAME.Properties.Appearance.Options.UseFont = true;
            this.txt_MATERIALNAME.Size = new System.Drawing.Size(554, 30);
            this.txt_MATERIALNAME.StyleController = this.layoutControl1;
            this.txt_MATERIALNAME.TabIndex = 6;
            // 
            // txt_todept
            // 
            this.txt_todept.Location = new System.Drawing.Point(100, 88);
            this.txt_todept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_todept.Name = "txt_todept";
            this.txt_todept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_todept.Properties.Appearance.Options.UseFont = true;
            this.txt_todept.Size = new System.Drawing.Size(554, 30);
            this.txt_todept.StyleController = this.layoutControl1;
            this.txt_todept.TabIndex = 5;
            // 
            // txt_fromdept
            // 
            this.txt_fromdept.Location = new System.Drawing.Point(100, 52);
            this.txt_fromdept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_fromdept.Name = "txt_fromdept";
            this.txt_fromdept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_fromdept.Properties.Appearance.Options.UseFont = true;
            this.txt_fromdept.Size = new System.Drawing.Size(554, 30);
            this.txt_fromdept.StyleController = this.layoutControl1;
            this.txt_fromdept.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(670, 214);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_fromdept;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(644, 36);
            this.layoutControlItem1.Text = "来源单位";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_MATERIALNAME;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(644, 36);
            this.layoutControlItem3.Text = "品名名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_todept;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(644, 36);
            this.layoutControlItem2.Text = "去向单位";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 24);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_CONTAINERNO;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(644, 36);
            this.layoutControlItem4.Text = "集装箱号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 24);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_cancle});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(674, 45);
            this.gToolStrip1.TabIndex = 4;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::LTN.CS.SCMForm.Properties.Resources.Save1_32;
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(68, 42);
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Image = global::LTN.CS.SCMForm.Properties.Resources.cancel_161;
            this.btn_cancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(68, 42);
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // txt_REMARK
            // 
            this.txt_REMARK.Location = new System.Drawing.Point(100, 160);
            this.txt_REMARK.Name = "txt_REMARK";
            this.txt_REMARK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_REMARK.Properties.Appearance.Options.UseFont = true;
            this.txt_REMARK.Size = new System.Drawing.Size(554, 30);
            this.txt_REMARK.StyleController = this.layoutControl1;
            this.txt_REMARK.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_REMARK;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(644, 44);
            this.layoutControlItem5.Text = "备注";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 24);
            // 
            // PT_TruckMeasureUpdate_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 263);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gToolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "PT_TruckMeasureUpdate_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汽车磅委托批量修改";
            this.Shown += new System.EventHandler(this.PT_TruckMeasureUpdate_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CONTAINERNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MATERIALNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_todept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fromdept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_REMARK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_CONTAINERNO;
        private DevExpress.XtraEditors.TextEdit txt_MATERIALNAME;
        private DevExpress.XtraEditors.TextEdit txt_todept;
        private DevExpress.XtraEditors.TextEdit txt_fromdept;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Save;
        private Core.Helper.GToolStripButton btn_cancle;
        private DevExpress.XtraEditors.TextEdit txt_REMARK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}