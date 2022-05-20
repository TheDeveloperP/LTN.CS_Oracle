namespace LTN.CS.SCMForm.PM
{
    partial class PM_BeltScaleMeasure_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM_BeltScaleMeasure_Form));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.date_StartTime = new DevExpress.XtraEditors.DateEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateEdit();
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gCtrl_BeltServerLog = new DevExpress.XtraGrid.GridControl();
            this.gView_BeltServerLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCol_BELTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_BELTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_COLLTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_ACCUWEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCol_METERTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt_BeltNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_BeltServerLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_BeltServerLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1022, 65);
            this.panelControl1.TabIndex = 4;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.date_StartTime);
            this.layoutControl1.Controls.Add(this.date_EndTime);
            this.layoutControl1.Controls.Add(this.btn_Query);
            this.layoutControl1.Controls.Add(this.txt_BeltNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(921, 61);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = null;
            this.date_StartTime.Location = new System.Drawing.Point(342, 12);
            this.date_StartTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(195, 26);
            this.date_StartTime.StyleController = this.layoutControl1;
            this.date_StartTime.TabIndex = 2;
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = null;
            this.date_EndTime.Location = new System.Drawing.Point(613, 12);
            this.date_EndTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(196, 26);
            this.date_EndTime.StyleController = this.layoutControl1;
            this.date_EndTime.TabIndex = 3;
            // 
            // btn_Query
            // 
            this.btn_Query.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Query.Appearance.Options.UseFont = true;
            this.btn_Query.Image = ((System.Drawing.Image)(resources.GetObject("btn_Query.Image")));
            this.btn_Query.Location = new System.Drawing.Point(813, 12);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(96, 26);
            this.btn_Query.StyleController = this.layoutControl1;
            this.btn_Query.TabIndex = 4;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(921, 61);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.date_StartTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(258, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(271, 41);
            this.layoutControlItem3.Text = "开始时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.date_EndTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(529, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(272, 41);
            this.layoutControlItem4.Text = "结束时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 21);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.btn_Query;
            this.layoutControlItem1.Location = new System.Drawing.Point(801, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(100, 41);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "labelControl1";
            // 
            // gCtrl_BeltServerLog
            // 
            this.gCtrl_BeltServerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl_BeltServerLog.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_BeltServerLog.Location = new System.Drawing.Point(0, 65);
            this.gCtrl_BeltServerLog.MainView = this.gView_BeltServerLog;
            this.gCtrl_BeltServerLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gCtrl_BeltServerLog.Name = "gCtrl_BeltServerLog";
            this.gCtrl_BeltServerLog.Size = new System.Drawing.Size(1022, 621);
            this.gCtrl_BeltServerLog.TabIndex = 5;
            this.gCtrl_BeltServerLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gView_BeltServerLog});
            // 
            // gView_BeltServerLog
            // 
            this.gView_BeltServerLog.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_BeltServerLog.Appearance.HeaderPanel.Options.UseFont = true;
            this.gView_BeltServerLog.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12.10084F);
            this.gView_BeltServerLog.Appearance.Row.Options.UseFont = true;
            this.gView_BeltServerLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCol_BELTNO,
            this.gCol_BELTNAME,
            this.gCol_COLLTIME,
            this.gCol_ACCUWEIGHT,
            this.gCol_METERTIME});
            this.gView_BeltServerLog.GridControl = this.gCtrl_BeltServerLog;
            this.gView_BeltServerLog.GroupPanelText = " ";
            this.gView_BeltServerLog.Name = "gView_BeltServerLog";
            this.gView_BeltServerLog.OptionsBehavior.Editable = false;
            this.gView_BeltServerLog.OptionsView.ColumnAutoWidth = false;
            // 
            // gCol_BELTNO
            // 
            this.gCol_BELTNO.Caption = "皮带编号";
            this.gCol_BELTNO.FieldName = "BELTNO";
            this.gCol_BELTNO.Name = "gCol_BELTNO";
            this.gCol_BELTNO.Visible = true;
            this.gCol_BELTNO.VisibleIndex = 0;
            this.gCol_BELTNO.Width = 100;
            // 
            // gCol_BELTNAME
            // 
            this.gCol_BELTNAME.Caption = "皮带名称";
            this.gCol_BELTNAME.FieldName = "BELTNAME";
            this.gCol_BELTNAME.Name = "gCol_BELTNAME";
            this.gCol_BELTNAME.Visible = true;
            this.gCol_BELTNAME.VisibleIndex = 1;
            this.gCol_BELTNAME.Width = 150;
            // 
            // gCol_COLLTIME
            // 
            this.gCol_COLLTIME.Caption = "启停时间";
            this.gCol_COLLTIME.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gCol_COLLTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gCol_COLLTIME.FieldName = "COLLTIME";
            this.gCol_COLLTIME.Name = "gCol_COLLTIME";
            this.gCol_COLLTIME.Visible = true;
            this.gCol_COLLTIME.VisibleIndex = 2;
            this.gCol_COLLTIME.Width = 175;
            // 
            // gCol_ACCUWEIGHT
            // 
            this.gCol_ACCUWEIGHT.Caption = "采集重量";
            this.gCol_ACCUWEIGHT.FieldName = "ACCUWEIGHT";
            this.gCol_ACCUWEIGHT.Name = "gCol_ACCUWEIGHT";
            this.gCol_ACCUWEIGHT.Visible = true;
            this.gCol_ACCUWEIGHT.VisibleIndex = 3;
            this.gCol_ACCUWEIGHT.Width = 100;
            // 
            // gCol_METERTIME
            // 
            this.gCol_METERTIME.Caption = "仪表时间";
            this.gCol_METERTIME.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gCol_METERTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gCol_METERTIME.FieldName = "METERTIME";
            this.gCol_METERTIME.Name = "gCol_METERTIME";
            this.gCol_METERTIME.Visible = true;
            this.gCol_METERTIME.VisibleIndex = 4;
            this.gCol_METERTIME.Width = 175;
            // 
            // txt_BeltNo
            // 
            this.txt_BeltNo.Location = new System.Drawing.Point(84, 12);
            this.txt_BeltNo.Name = "txt_BeltNo";
            this.txt_BeltNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BeltNo.Properties.Appearance.Options.UseFont = true;
            this.txt_BeltNo.Size = new System.Drawing.Size(182, 26);
            this.txt_BeltNo.StyleController = this.layoutControl1;
            this.txt_BeltNo.TabIndex = 0;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_BeltNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(258, 41);
            this.layoutControlItem2.Text = "皮带编号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 19);
            // 
            // PM_BeltScaleMeasure_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 686);
            this.Controls.Add(this.gCtrl_BeltServerLog);
            this.Controls.Add(this.panelControl1);
            this.Name = "PM_BeltScaleMeasure_Form";
            this.Text = "皮带秤仪表重量";
            this.Shown += new System.EventHandler(this.PM_BeltScaleMeasure_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrl_BeltServerLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gView_BeltServerLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BeltNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit date_StartTime;
        private DevExpress.XtraEditors.DateEdit date_EndTime;
        private DevExpress.XtraEditors.SimpleButton btn_Query;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gCtrl_BeltServerLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gView_BeltServerLog;
        private DevExpress.XtraEditors.TextEdit txt_BeltNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_BELTNO;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_BELTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_COLLTIME;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_ACCUWEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn gCol_METERTIME;
    }
}