using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.SCMEntities.PT;
using DevExpress.XtraEditors.DXErrorProvider;

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_TruckMeasureUsingPlan_Form : Form
    {
        public  IPT_TruckMeasurePlanService MainService { get; set; }

        public PT_TruckMeasurePlan selectEntity { get; set; }

        public PT_TruckMeasureUsingPlan_Form()
        {
            InitializeComponent();
        }

        public PT_TruckMeasureUsingPlan_Form(IPT_TruckMeasurePlanService MainService)
        {
            InitializeComponent();
            this.MainService = MainService;
            //date_StartDate.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            //date_EndDate.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(txt_CarNo.Text.Trim()))
            {
                ht.Add("CarNo", txt_CarNo.Text.Trim());
                gCtrl_TruckMeasurePlan.DataSource = MainService.ExecuteDB_QueryTruckMeasureUsingPlan(ht);
                dxErrorProvider1.ClearErrors();
            }
            else
            {
                dxErrorProvider1.SetError(txt_CarNo, "车号不能为空！", ErrorType.Warning);
            }
            //if (!string.IsNullOrEmpty(date_StartDate.Text) && !string.IsNullOrEmpty(date_EndDate.Text))
            //{
            //    ht.Add("StartTime", date_StartDate.Text);
            //    ht.Add("EndTime", date_EndDate.Text);
            //}
            
        }

        private void gView_TruckMeasurePlan_DoubleClick(object sender, EventArgs e)
        {
            if (gView_TruckMeasurePlan != null && gView_TruckMeasurePlan.GetFocusedRow() != null)
            {
                selectEntity = gView_TruckMeasurePlan.GetFocusedRow() as PT_TruckMeasurePlan;

            }
            this.DialogResult = DialogResult.OK;
        }

        private void PT_TruckMeasureUsingPlan_Form_Shown(object sender, EventArgs e)
        {
            selectEntity = new PT_TruckMeasurePlan();
        }

        private void txt_CarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Hashtable ht = new Hashtable();
                    if (!string.IsNullOrEmpty(txt_CarNo.Text.Trim()))
                    {
                        ht.Add("CarNo", txt_CarNo.Text.Trim());
                        gCtrl_TruckMeasurePlan.DataSource = MainService.ExecuteDB_QueryTruckMeasureUsingPlan(ht);
                        dxErrorProvider1.ClearErrors();
                    }
                    else
                    {
                        dxErrorProvider1.SetError(txt_CarNo, "车号不能为空！", ErrorType.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
