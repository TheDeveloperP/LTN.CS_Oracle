using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base;
using LTN.CS.SCMService.SM.Interface;
using System.Collections;
using LTN.CS.SCMForm.Common;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_Container_Info : CoreForm
    {
        public ISM_JZXH_InfoService jzxhService { get; set; }

        public SM_Container_Info()
        {
            InitializeComponent();
        }

        private void SM_Container_Info_Shown(object sender, EventArgs e)
        {
            de_starttime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            dateEdit1.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            txt_LevelOneCode.Focus();
            gcl_main.DataSource = jzxhService.ExecuteDB_QueryByCarName(getCondition());
        }

        private Hashtable getCondition()
        {
            Hashtable ht = new Hashtable();
            string carName = string.Empty;
            
            if (!string.IsNullOrEmpty(txt_LevelOneCode.Text))
            {
                carName = txt_LevelOneCode.Text.Trim();
            }
            string starttime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.EditValue));//de_starttime.Text.Trim();
            string endtime = CommonHelper.TimeToStr14(Convert.ToDateTime(dateEdit1.EditValue)); //de_endtime.Text.Trim();
            ht.Add("carName", carName);
            ht.Add("StartTime", starttime);
            ht.Add("EndTime", endtime);
            return ht;
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "I_ContainerStatus")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "非集装箱号"; break;
                        case "1":
                            e.DisplayText = "是集装箱号"; break;
                    }
                }
            }
            if (e.Column.FieldName == "C_CameraTime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }
    }
}
