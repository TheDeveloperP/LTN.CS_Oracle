namespace LTN.CS.SCMForm.PM
{
    partial class PM_ImportExcel_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM_ImportExcel_Form));
            this.SheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.gToolStrip1 = new LTN.CS.Core.Helper.GToolStrip();
            this.btn_Confirm = new LTN.CS.Core.Helper.GToolStripButton();
            this.gToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SheetControl
            // 
            this.SheetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetControl.Location = new System.Drawing.Point(0, 31);
            this.SheetControl.Name = "SheetControl";
            this.SheetControl.Size = new System.Drawing.Size(1213, 589);
            this.SheetControl.TabIndex = 1;
            this.SheetControl.Text = "spreadsheetControl1";
            // 
            // gToolStrip1
            // 
            this.gToolStrip1.AutoSize = false;
            this.gToolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.gToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Confirm});
            this.gToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.gToolStrip1.Name = "gToolStrip1";
            this.gToolStrip1.Size = new System.Drawing.Size(1213, 31);
            this.gToolStrip1.TabIndex = 0;
            this.gToolStrip1.Text = "gToolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(56, 28);
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // PM_ImportExcel_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 620);
            this.Controls.Add(this.SheetControl);
            this.Controls.Add(this.gToolStrip1);
            this.Name = "PM_ImportExcel_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel导入确认";
            this.gToolStrip1.ResumeLayout(false);
            this.gToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.Helper.GToolStrip gToolStrip1;
        private Core.Helper.GToolStripButton btn_Confirm;
        public DevExpress.XtraSpreadsheet.SpreadsheetControl SheetControl;
    }
}