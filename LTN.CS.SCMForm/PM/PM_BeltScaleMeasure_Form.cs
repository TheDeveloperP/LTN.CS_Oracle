using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_BeltScaleMeasure_Form : CoreForm
    {
        IBeltWeightDataService MainService { get; set; }
        public PM_BeltScaleMeasure_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(txt_BeltNo.Text))
                {
                    ht.Add("BELTNO", txt_BeltNo.Text.Trim());
                }
                ht.Add("StartTime", MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text));
                ht.Add("EndTime", MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text));
                var result = MainService.ExecuteDB_QueryBeltWeightDataByHashtable(ht);
                gCtrl_BeltServerLog.DataSource = result;
            }
            else
            {
                MessageDxUtil.ShowTips("开始时间或结束时间不能为空！");
            }
        }

        private void PM_BeltScaleMeasure_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            btn_Query_Click(null, null);
        }
    }
}
