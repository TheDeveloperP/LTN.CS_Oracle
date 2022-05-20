using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.SCMService.PM.Interface;
using System.Collections;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.PM;
using LTN.CS.SCMForm.Common;

namespace LTN.CS.SCMForm.RP
{
    public partial class RP_Materiel_PrintRecord_Form : CoreForm
    {
        public IRP_Print_RecordService printService { get; set; }
        public RP_Materiel_PrintRecord_Form()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void btn_SimpleQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(txt_WgtlistNo.Text))
                {
                    ht.Add("WgtNo", txt_WgtlistNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_WagNo.Text))
                {
                    ht.Add("WagNo", txt_WagNo.Text.Trim());
                }
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
                var result = printService.ExecuteDB_QueryByPrintInfo(ht);
                gridControl1.DataSource = result;
            }
            else
            {
                MessageDxUtil.ShowTips("开始时间或结束时间不能为空！");
            }
        }

        private void txt_WgtlistNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void date_StartTime_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_WagNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            InitView(gridView1);
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void date_EndTime_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void RP_Materiel_PrintRecord_Form_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }


    }
}