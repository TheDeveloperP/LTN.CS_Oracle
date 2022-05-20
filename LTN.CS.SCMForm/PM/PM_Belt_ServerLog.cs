using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.Common;
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
    public partial class PM_Belt_ServerLog : Form
    {
        public IPM_Bill_BeltScaleService MainService { get; set; }
        public PM_Belt_ServerLog()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                Hashtable ht = new Hashtable();
                ht.Add("StartTime",MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text));
                ht.Add("EndTime", MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text));
                var result = MainService.ExecuteDB_QueryBeltServerLog(ht);
                gCtrl_BeltServerLog.DataSource = result;
            }
            else
            {
                MessageDxUtil.ShowTips("开始时间或结束时间不能为空！");
            }
        }

        private void PM_Belt_ServerLog_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            simpleButton1_Click(null,null);
        }
    }
}
