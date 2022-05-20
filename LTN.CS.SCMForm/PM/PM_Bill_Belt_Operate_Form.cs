using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
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
using DevExpress.XtraEditors;
namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_Belt_Operate_Form : Form
    {
        public IPM_Bill_BeltScaleService MainService { get; set; }
        public IPT_BeltScalePlanService PT_BeltScalePlanService { get; set; }

        public PM_Bill_Belt BeltBill;
        public PM_Bill_Belt_Operate_Form()
        {
            InitializeComponent();
        }

        private void txt_PlanNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                string txt = txt_PlanNo.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                    return;
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());

                PT_BeltScalePlan BeltScalePlan = PT_BeltScalePlanService.ExecuteDB_QueryBeltScalePlanByHashTable(ht).FirstOrDefault();
                if (BeltScalePlan == null)
                {
                    MessageDxUtil.ShowTips("未获取到该单号对应的委托！");
                }
                else
                {
                    RefreshPlan( BeltScalePlan);
                }
            }
        }

        private void RefreshPlan(PT_BeltScalePlan BeltScalePlan)
        {
            if (BeltScalePlan != null )
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
                date_StartTime.EditValue = CommonHelper.Str14ToTime(BeltScalePlan.C_Starttime);
                date_StopTime.EditValue = CommonHelper.Str14ToTime(BeltScalePlan.C_Stoptime);

               //绑定计划信息到实体
                BeltBill.C_Planno = BeltScalePlan.C_Planno;
                BeltBill.C_Materialno = BeltScalePlan.C_Materialno;
                BeltBill.C_Materialname = BeltScalePlan.C_Materialname;
                BeltBill.C_Fromdeptno = BeltScalePlan.C_Fromdeptno;
                BeltBill.C_Fromdeptname = BeltScalePlan.C_Fromdeptname;
                BeltBill.C_Fromstoreno = BeltScalePlan.C_Fromstoreno;
                BeltBill.C_Fromstorename = BeltScalePlan.C_Fromstorename;
                BeltBill.C_Todeptno = BeltScalePlan.C_Todeptno;
                BeltBill.C_Todeptname = BeltScalePlan.C_Todeptname;
                BeltBill.C_Tostoreno = BeltScalePlan.C_Tostoreno;
                BeltBill.C_Tostorename = BeltScalePlan.C_Tostorename;
                BeltBill.C_Beltno = BeltScalePlan.C_Beltno;
                BeltBill.C_Beltname = BeltScalePlan.C_Beltname;
                BeltBill.C_Shipno = BeltScalePlan.C_Shipno;
                BeltBill.C_Contractno = BeltScalePlan.C_Contractno;
                BeltBill.C_Voyageno = BeltScalePlan.C_Voyageno;
                BeltBill.C_Starttime = BeltScalePlan.C_Starttime;
                BeltBill.C_Endtime = BeltScalePlan.C_Stoptime;
                BeltBill.C_Createtime = BeltScalePlan.C_Createtime;
                BeltBill.C_Createname = BeltScalePlan.C_Createname;
                BeltBill.C_Remark = BeltScalePlan.C_Remark;
                BeltBill.C_Reserve1 = BeltScalePlan.C_Reserve1;
                BeltBill.C_Reserve2 = BeltScalePlan.C_Reserve2;
                BeltBill.C_Reserve3 = BeltScalePlan.C_Reserve3;
                //该字段作为计量磅单类型标志字段，不能在修改时赋值
                //BeltBill.I_Reserve1 = BeltScalePlan.I_Reserve1; 
                BeltBill.I_Reserve2 = BeltScalePlan.I_Reserve2;
                BeltBill.I_Reserve3 = BeltScalePlan.I_Reserve3;
                //
                BeltBill.C_RESERVE4 = BeltScalePlan.C_RESERVE4;
                BeltBill.C_RESERVE5 = BeltScalePlan.C_RESERVE5;
                BeltBill.C_RESERVE6 = BeltScalePlan.C_RESERVE6;
                BeltBill.C_RESERVE7 = BeltScalePlan.C_RESERVE7;
                BeltBill.C_RESERVE8 = BeltScalePlan.C_RESERVE8;
               
               
            }
        }

        private void PM_Bill_Belt_Operate_Form_Shown(object sender, EventArgs e)
        {
            if (BeltBill!=null&&!string.IsNullOrEmpty(BeltBill.C_Wgtlistno))
            {
                //计划信息
                txt_PlanNo.Text = BeltBill.C_Planno;
                txt_Materialname.Text = BeltBill.C_Materialname;
                txt_FromDeptName.Text = BeltBill.C_Fromdeptname;
                txt_FromStoreName.Text = BeltBill.C_Fromstorename;
                txt_ToDeptName.Text = BeltBill.C_Todeptname;
                txt_ToStoreName.Text = BeltBill.C_Tostorename;
                txt_ShipNo.Text = BeltBill.C_Shipno;
                txt_Contractno.Text = BeltBill.C_Contractno;
                txt_Voyageno.Text = BeltBill.C_Voyageno;
                txt_BeltNo.Text = BeltBill.C_Beltno;
                txt_BeltName.Text = BeltBill.C_Beltname;
                memo_Remark.Text = BeltBill.C_Remark;
                if(!string.IsNullOrEmpty(BeltBill.C_Starttime))
                date_StartTime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Starttime);
                if(!string.IsNullOrEmpty(BeltBill.C_Endtime))
                date_StopTime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Endtime);

                //重量信息
                txt_Wgtlistno.Text = BeltBill.C_Wgtlistno;
                txt_Netwgt.Text = BeltBill.N_Netwgt.ToString();
                txt_Startwgt.Text = BeltBill.N_Startwgt.ToString();
                txt_Endwgt.Text = BeltBill.N_Endwgt.ToString();
                date_Measurestarttime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Measurestarttime);
                date_Measureendtime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Measureendtime);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_PlanNo.Text))
            {
                MessageDxUtil.ShowTips("计划信息不能为空！");
                return;
            }
            txt_PlanNo.Focus();
            //计划信息
            BeltBill.C_Planno=txt_PlanNo.Text.Trim() ;
            BeltBill.C_Materialname = txt_Materialname == null?string.Empty:txt_Materialname.Text.Trim();
            BeltBill.C_Fromdeptname = txt_FromDeptName == null?string.Empty:txt_FromDeptName.Text.Trim();
            BeltBill.C_Fromstorename = txt_FromStoreName == null ? string.Empty : txt_FromStoreName.Text.Trim();
            BeltBill.C_Todeptname = txt_ToDeptName==null?string.Empty:txt_ToDeptName.Text.Trim();
            BeltBill.C_Tostorename = txt_ToStoreName == null ? string.Empty : txt_ToStoreName.Text.Trim();
            BeltBill.C_Shipno = txt_ShipNo== null?string.Empty:txt_ShipNo.Text.Trim();
            BeltBill.C_Contractno = txt_Contractno==null?string.Empty:txt_Contractno.Text.Trim();
            BeltBill.C_Voyageno = txt_Voyageno == null?string.Empty:txt_Voyageno.Text.Trim();
            BeltBill.C_Beltno = txt_BeltNo == null?string.Empty:txt_BeltNo.Text.Trim();
            BeltBill.C_Beltname = txt_BeltName == null?string.Empty:txt_BeltName.Text.Trim();
            BeltBill.C_Remark = memo_Remark ==null?string.Empty:memo_Remark.Text.Trim(); 
            date_StartTime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Starttime);
            date_StopTime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Endtime);

            //重量信息
            BeltBill.C_Wgtlistno=txt_Wgtlistno.Text.Trim();
            BeltBill.N_Netwgt =MyNumberHelper.ConvertToDecimal(txt_Netwgt.Text.Trim()) ;
            BeltBill.N_Startwgt= MyNumberHelper.ConvertToDecimal(txt_Startwgt.Text.Trim()) ;
            BeltBill.N_Endwgt= MyNumberHelper.ConvertToDecimal(txt_Endwgt.Text.Trim());
            BeltBill.N_Netwgt = BeltBill.N_Endwgt - BeltBill.N_Startwgt;
            //date_Measurestarttime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Measurestarttime);
            //date_Measureendtime.EditValue = CommonHelper.Str14ToTime(BeltBill.C_Measureendtime);
            if (date_Measurestarttime.EditValue != null)
            {
                BeltBill.C_Measurestarttime = CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultException(date_Measurestarttime.EditValue));
            }
            if (date_Measureendtime.EditValue != null)
            {
                BeltBill.C_Measureendtime = CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultException(date_Measureendtime.EditValue));
            }

            if (string.IsNullOrEmpty(BeltBill.C_Wgtlistno))
            {
                BeltBill.C_Billcreatetime = CommonHelper.TimeToStr14(DateTime.Now);
                BeltBill.C_Billcreateusername = SessionHelper.LogUserNickName;
                object result = null;
                result = MainService.ExecuteDB_InsertPM_Bill_Belt(BeltBill);
                if (result == null)
                {
                    MessageDxUtil.ShowError("保存异常！");
                }
                else
                {
                    MessageDxUtil.ShowTips("保存成功！");
                    this.Close();
                }
            }
            else
            {
                BeltBill.C_Updatetime = CommonHelper.TimeToStr14(DateTime.Now);
                BeltBill.C_Updateusername = SessionHelper.LogUserNickName;
                if (BeltBill.C_Uploadstatus == "Y")
                {
                    BeltBill.C_Planstatus = "U";
                }
                object result = null;
                result = MainService.ExecuteDB_UpdatePM_Bill_Belt(BeltBill);
                if (result == null)
                {
                    MessageDxUtil.ShowError("保存异常！");
                }
                else
                {
                    MessageDxUtil.ShowTips("保存成功！");
                    this.Close();
                }
            }
            txt_Startwgt.Properties.ReadOnly = true;
            txt_Endwgt.Properties.ReadOnly = true;
        }

        private void txt_Startwgt_DoubleClick(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("请输入密码", "密码验证", "");
            if (result != null)
            {
                if (result.ToString().Trim() == "sb2022301")
                {
                    txt_Startwgt.Properties.ReadOnly = false;
                    txt_Endwgt.Properties.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            } 
        }

        private void txt_Endwgt_DoubleClick(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("请输入密码", "密码验证", "");
            if (result != null)
            {
                if (result.ToString().Trim() == "sb2022301")
                {
                    txt_Startwgt.Properties.ReadOnly = false;
                    txt_Endwgt.Properties.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            } 
        }
    }
}
