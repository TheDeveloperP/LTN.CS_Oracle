using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using LTN.CS.Base;
using LTN.CS.Base.CustomFrm;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
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
    public partial class PM_BillMultiUpdate_Supplies : CoreForm
    {
        public IPM_Pond_Bill_SuppliesService MainService { get; set; }
        //待修改的数据源
        public List<string> SuppliesBillWgtNos;
        public List<SM_Materiel_Level> Materiels { get; set; }
        public PM_BillMultiUpdate_Supplies()
        {
            InitializeComponent();
            this.Shown += PM_BillMultiUpdate_Supplies_Shown;
        }

        private void PM_BillMultiUpdate_Supplies_Shown(object sender, EventArgs e)
        {
            this.customSearchTextBox1.Datasources = Materiels;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (string.IsNullOrEmpty(txt_FromDeptName.Text.Trim()) && string.IsNullOrEmpty(txt_ToDeptName.Text.Trim()) && string.IsNullOrEmpty(txt_ContractNo.Text.Trim()) && string.IsNullOrEmpty(Memo_Remark.Text.Trim()) && string.IsNullOrEmpty(customSearchTextBox1.Text.Trim()) && string.IsNullOrEmpty(Memo_PondRemark.Text.Trim()))
            {
                return;
            }
            SplashScreenManager.ShowForm(typeof(MySplashScreenForWait), true, false);
            ht.Add("FromDeptName", txt_FromDeptName.Text.Trim());
            ht.Add("ToDeptName", txt_ToDeptName.Text.Trim());
            ht.Add("ContractNo", txt_ContractNo.Text.Trim());            
            ht.Add("Remark", Memo_Remark.Text.Trim());
            ht.Add("PondRemark", Memo_PondRemark.Text.Trim());
            ht.Add("MaterialName", customSearchTextBox1.Text.Trim());
            if (!string.IsNullOrEmpty(customSearchTextBox1.SelectKey))
            {
                ht.Add("MaterialNo", customSearchTextBox1.SelectKey);
            }
            else
            {
                ht.Add("MaterialNo", "");
            }
            object result = MainService.ExecuteDB_BatchUpdateSuppliesBill(SuppliesBillWgtNos, ht);
            SplashScreenManager.CloseForm();
            if (result == null)
            {
                MessageDxUtil.ShowError("保存异常");
                return;
            }
            else
            {
                MessageDxUtil.ShowTips("保存成功");
                this.Close();
            }
        }
    }
}
