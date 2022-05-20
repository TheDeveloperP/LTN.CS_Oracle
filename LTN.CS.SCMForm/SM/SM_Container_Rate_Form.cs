using LTN.CS.Base;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.Common;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_Container_Rate_Form : CoreForm
    {
        public ISM_PoundSite_InfoService PoundSiteService { get; set; }
        public ISM_Container_RateService MainService { get; set; }
        public SM_Container_Rate_Form()
        {
            InitializeComponent();
        }

        private void SM_Container_Rate_Form_Shown(object sender, EventArgs e)
        {
            InitView(gvw_main);
            slu_pondname.Properties.DataSource = PoundSiteService.ExecuteDB_QueryAll().Where(ee => ee.PoundType != null && ee.PoundType.EnumValue == PondType.CarPound).ToList();
            de_starttime.EditValue= DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            de_endtime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            slu_pondname.Focus();
            gCtrl_main.DataSource = MainService.ExecuteDB_QueryContainerRecognitionRateAll(getCondition());
            gView_main.BestFitColumns();
            gcl_main.DataSource = MainService.ExecuteDB_QueryAllByCondition(getCondition());
            gvw_main.BestFitColumns();
        }
        private Hashtable getCondition()
        {
            Hashtable ht = new Hashtable();
            string pondno = string.Empty;
            string ContainerNo = string.Empty;
            if (!string.IsNullOrEmpty(slu_pondname.Text))
            {
                pondno = slu_pondname.EditValue.ToString().Trim();
            }
            //if (!string.IsNullOrEmpty(txt_ContainerNo.Text))
            //{
            //    ContainerNo = txt_ContainerNo.Text.Trim();
            //}
            string starttime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.EditValue));//de_starttime.Text.Trim();
            string endtime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_endtime.EditValue)); //de_endtime.Text.Trim();
            ht.Add("PondNo", pondno);
            ht.Add("ContainerNo", ContainerNo);
            ht.Add("StartTime", starttime);
            ht.Add("EndTime", endtime);
            return ht;
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "I_RecognitionStatus")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "比对失败"; break;
                        case "1":
                            e.DisplayText = "比对成功"; break;
                    }
                }
            }
            if (e.Column.FieldName == "C_CreateTime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }
    }
}
