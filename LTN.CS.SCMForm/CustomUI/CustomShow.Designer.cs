namespace LTN.CS.SCMForm.CustomUI
{
    partial class CustomShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_AlarmLeft = new System.Windows.Forms.Panel();
            this.pnl_AlarmRight = new System.Windows.Forms.Panel();
            this.lbl_printtwo = new DevExpress.XtraEditors.LabelControl();
            this.lbl_pondname = new DevExpress.XtraEditors.LabelControl();
            this.lbl_printone = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_weight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panel1);
            this.panelControl2.Controls.Add(this.pnl_AlarmLeft);
            this.panelControl2.Controls.Add(this.pnl_AlarmRight);
            this.panelControl2.Location = new System.Drawing.Point(12, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(238, 62);
            this.panelControl2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(19, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 62);
            this.panel1.TabIndex = 4;
            // 
            // pnl_AlarmLeft
            // 
            this.pnl_AlarmLeft.BackColor = System.Drawing.Color.Lime;
            this.pnl_AlarmLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_AlarmLeft.Location = new System.Drawing.Point(0, 0);
            this.pnl_AlarmLeft.Name = "pnl_AlarmLeft";
            this.pnl_AlarmLeft.Size = new System.Drawing.Size(19, 62);
            this.pnl_AlarmLeft.TabIndex = 0;
            // 
            // pnl_AlarmRight
            // 
            this.pnl_AlarmRight.BackColor = System.Drawing.Color.Lime;
            this.pnl_AlarmRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_AlarmRight.Location = new System.Drawing.Point(219, 0);
            this.pnl_AlarmRight.Name = "pnl_AlarmRight";
            this.pnl_AlarmRight.Size = new System.Drawing.Size(19, 62);
            this.pnl_AlarmRight.TabIndex = 1;
            // 
            // lbl_printtwo
            // 
            this.lbl_printtwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_printtwo.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lbl_printtwo.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.lbl_printtwo.Appearance.Options.UseFont = true;
            this.lbl_printtwo.Appearance.Options.UseForeColor = true;
            this.lbl_printtwo.Location = new System.Drawing.Point(187, 149);
            this.lbl_printtwo.Name = "lbl_printtwo";
            this.lbl_printtwo.Size = new System.Drawing.Size(14, 24);
            this.lbl_printtwo.TabIndex = 5;
            this.lbl_printtwo.Text = "--";
            // 
            // lbl_pondname
            // 
            this.lbl_pondname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_pondname.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lbl_pondname.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_pondname.Appearance.Options.UseFont = true;
            this.lbl_pondname.Appearance.Options.UseForeColor = true;
            this.lbl_pondname.Location = new System.Drawing.Point(105, 3);
            this.lbl_pondname.Name = "lbl_pondname";
            this.lbl_pondname.Size = new System.Drawing.Size(48, 29);
            this.lbl_pondname.TabIndex = 2;
            this.lbl_pondname.Text = "磅房";
            // 
            // lbl_printone
            // 
            this.lbl_printone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_printone.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lbl_printone.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.lbl_printone.Appearance.Options.UseFont = true;
            this.lbl_printone.Appearance.Options.UseForeColor = true;
            this.lbl_printone.Location = new System.Drawing.Point(38, 149);
            this.lbl_printone.Name = "lbl_printone";
            this.lbl_printone.Size = new System.Drawing.Size(14, 24);
            this.lbl_printone.TabIndex = 4;
            this.lbl_printone.Text = "--";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.panelControl2);
            this.panel2.Controls.Add(this.lbl_printone);
            this.panel2.Controls.Add(this.lbl_printtwo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 194);
            this.panel2.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_pondname, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 41);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Honeydew;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(170, 121);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 24);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "打印机2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Honeydew;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 24);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "打印机1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_weight, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 62);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lbl_weight
            // 
            this.lbl_weight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Font = new System.Drawing.Font("Tahoma", 36F);
            this.lbl_weight.ForeColor = System.Drawing.Color.PowderBlue;
            this.lbl_weight.Location = new System.Drawing.Point(3, 0);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(194, 62);
            this.lbl_weight.TabIndex = 20;
            this.lbl_weight.Text = "000000";
            this.lbl_weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Name = "CustomShow";
            this.Size = new System.Drawing.Size(259, 194);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_printtwo;
        private DevExpress.XtraEditors.LabelControl lbl_printone;
        private DevExpress.XtraEditors.LabelControl lbl_pondname;
        private System.Windows.Forms.Panel pnl_AlarmRight;
        private System.Windows.Forms.Panel pnl_AlarmLeft;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_weight;
    }
}
