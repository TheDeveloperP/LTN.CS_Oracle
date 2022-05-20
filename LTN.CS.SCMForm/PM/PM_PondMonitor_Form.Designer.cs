namespace LTN.CS.SCMForm.PM
{
    partial class PM_PondMonitor_Form
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
            this.SuspendLayout();
            // 
            // PM_PondMonitor_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 561);
            this.Name = "PM_PondMonitor_Form";
            this.ShowIcon = false;
            this.Text = "磅点设备监控";
            this.Load += new System.EventHandler(this.PM_PondMonitor_Form_Load);
            this.Shown += new System.EventHandler(this.PM_PondMonitor_Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}