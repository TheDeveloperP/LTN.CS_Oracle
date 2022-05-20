using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.PM;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMForm.Common;
using DevExpress.XtraEditors.DXErrorProvider;

namespace LTN.CS.SCMForm.Comm
{
    public partial class TruckPrintQuery : UserControl
    {
        public IPM_Bill_TruckService billTruckService2 { get; set; }
        private TruckMeasureForm_New MainForm { get; set; }

        public TruckPrintQuery()
        {
            InitializeComponent();
        }
        public TruckPrintQuery(IPM_Bill_TruckService billTruckService, TruckMeasureForm_New mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            billTruckService2 = billTruckService;
        }
        private void TruckPrintQuery_Load(object sender, EventArgs e)
        {
            dte_end.EditValue = DateTime.Now.AddDays(1);
            dte_begin.EditValue = DateTime.Now.AddDays(-2);
            //SetGridData();
        }

        private void SetGridData()
        {
            try
            {
                txt_CarNoFirst.Focus();
                if (string.IsNullOrEmpty(sle_CarNo_ref.Text.Trim()))
                {
                    dxErrorProvider1.SetError(sle_CarNo_ref,"车号为必填!",ErrorType.Warning);
                    return;
                }
                Hashtable ht = new Hashtable();
                ht.Add("CarName", sle_CarNo_ref.Text.Trim());
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(dte_begin.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(dte_end.Text)));
                var result = billTruckService2.ExecuteDB_QueryPM_Bill_TruckByPond2(ht);
                gridCtrl.DataSource = result;

            }
            catch (Exception ex)
            {
                
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            SetGridData();
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainForm != null)
                {
                    PM_Bill_Truck billTruck = (gridView.GetFocusedRow()) as PM_Bill_Truck;

                    if (billTruck != null)
                    {
                        MainForm.PrintBillForEnd(billTruck,false);
                        MessageDxUtil.ShowTips("打印成功");
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.ClosePanelControl8();
            }
            catch (Exception ex)
            {
                
            }
        }


        private void sle_CarNo_ref_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8)
                    {
                        if (e.KeyChar >= 97 && e.KeyChar <= 122)
                        {
                            e.KeyChar = (char)(e.KeyChar - 32);
                        }
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
            }
            catch (Exception)
            {
            }
        }

        private void txt_CarNoFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            sle_CarNo_ref.Focus();
            sle_CarNo_ref.Text = txt_CarNoFirst.Text;
            sle_CarNo_ref.SelectionStart = sle_CarNo_ref.Text.Length;
        }
    }
}
