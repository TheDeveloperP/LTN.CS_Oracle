using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_BeltScalePlanOperate_Form : Form
    {
        public IPT_BeltScalePlanService MainService { get; set; }
        public PT_BeltScalePlan BeltScalePlan { get; set; }
        public PT_BeltScalePlanOperate_Form()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            txt_PlanNo.Focus();
            BeltScalePlan.C_Materialname=txt_Materialname.Text.Trim();
            BeltScalePlan.C_Fromdeptname=txt_FromDeptName.Text.Trim() ;
            BeltScalePlan.C_Fromstorename=txt_FromStoreName.Text.Trim();
            BeltScalePlan.C_Todeptname=txt_ToDeptName.Text.Trim();
            BeltScalePlan.C_Tostorename=txt_ToStoreName.Text.Trim() ;
            BeltScalePlan.C_Shipno=txt_ShipNo.Text.Trim() ;
            BeltScalePlan.C_Contractno=txt_Contractno.Text.Trim() ;
            BeltScalePlan.C_Voyageno=txt_Voyageno.Text .Trim();
            BeltScalePlan.C_Beltno=txt_BeltNo.Text.Trim();
            BeltScalePlan.C_Beltname=txt_BeltName.Text.Trim() ;
            BeltScalePlan.C_Remark=memo_Remark.Text.Trim();
            if (date_StartTime.EditValue != null)
            {
                BeltScalePlan.C_Starttime = CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultException(date_StartTime.EditValue));
            }
            if (date_StopTime.EditValue != null)
            {
                BeltScalePlan.C_Stoptime = CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultException(date_StopTime.EditValue));
            }
            if (cBox_PlanState.Text.Trim() == "未完成")
            {
                BeltScalePlan.C_Planstate = 0;
            }
            else
            {
                BeltScalePlan.C_Planstate = 1;
            }

            object result = null;
            if (BeltScalePlan.I_Intid == 0)
            {
                BeltScalePlan.C_Createtime = CommonHelper.TimeToStr14(DateTime.Now);
                BeltScalePlan.C_Createname = SessionHelper.LogUserNickName;
                result = MainService.ExecuteDB_InsertBeltScalePlan(BeltScalePlan);
            }
            else
            {
                BeltScalePlan.C_Updatetime = CommonHelper.TimeToStr14(DateTime.Now);
                BeltScalePlan.C_Updateusername = SessionHelper.LogUserNickName;
                result = MainService.ExecuteDB_UpdateBeltScalePlanByPlanNo(BeltScalePlan);
            }

            if (result == null)
            {
                MessageDxUtil.ShowError("保存异常！");
                return;
            }
            else
            {
                MessageDxUtil.ShowTips("保存成功！");
                this.Close();
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PT_BeltScalePlanOperate_Form_Shown(object sender, EventArgs e)
        {
            if (BeltScalePlan != null&& BeltScalePlan.I_Intid!=0)
            {
                txt_PlanNo.Text = BeltScalePlan.C_Planno;
                txt_Materialname.Text = BeltScalePlan.C_Materialname;
                txt_FromDeptName.Text = BeltScalePlan.C_Fromdeptname;
                txt_FromStoreName.Text = BeltScalePlan.C_Fromstorename;
                txt_ToDeptName.Text = BeltScalePlan.C_Todeptname;
                txt_ToStoreName.Text = BeltScalePlan.C_Tostorename;
                txt_ShipNo.Text = BeltScalePlan.C_Shipno;
                txt_Contractno.Text = BeltScalePlan.C_Contractno;
                txt_Voyageno.Text = BeltScalePlan.C_Voyageno;
                txt_BeltNo.Text = BeltScalePlan.C_Beltno;
                txt_BeltName.Text = BeltScalePlan.C_Beltname;
                memo_Remark.Text = BeltScalePlan.C_Remark;
                if(!string.IsNullOrEmpty(BeltScalePlan.C_Starttime))
                date_StartTime.EditValue = CommonHelper.Str14ToTime(BeltScalePlan.C_Starttime);
                if(!string.IsNullOrEmpty(BeltScalePlan.C_Stoptime))
                date_StopTime.EditValue = CommonHelper.Str14ToTime( BeltScalePlan.C_Stoptime);
                if (BeltScalePlan.C_Planstate == 0)
                {
                    cBox_PlanState.Text = "未完成";
                }
                else if (BeltScalePlan.C_Planstate == 1)
                { 
                    cBox_PlanState.Text = "已完成";
                }
                else if (BeltScalePlan.C_Planstate == 2)
                {
                    cBox_PlanState.Text = "已作废";
                }
            }
        }
    }
}
