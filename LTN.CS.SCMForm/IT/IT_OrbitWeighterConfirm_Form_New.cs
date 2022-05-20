using LTN.CS.Base;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.IT.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LTN.CS.SCMForm.IT
{
    public partial class IT_OrbitWeighterConfirm_Form_New : DevExpress.XtraEditors.XtraForm
    {
        public IIT_OrbitWeighterConfirmService MainService { get; set; }
        public IT_OrbitWeighterConfirm_Form_New()
        {
            InitializeComponent();
        }
        public void IT_OrbitWeighterConfirm_Shown(object sender, EventArgs e)
        {
            date_StartTime.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        public void Query()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(date_StartTime.Text))
            {
                condition.Add("StartTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_StartTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(date_EndTime.Text))
            {
                condition.Add("EndTime", CommonHelper.TimeToStr14(Convert.ToDateTime(date_EndTime.EditValue)));
            }
            if (!string.IsNullOrEmpty(calibrateNo.Text))
            {
                condition.Add("Calibrate_no", calibrateNo.Text);
            }
            gridControl1.DataSource = MainService.ExecuteDB_QueryByCalibrateAndTime(condition);

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            Query();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}