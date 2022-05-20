using DevExpress.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.Enum;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Core.Common;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_TruckMeasurePlanOperate_Form : CoreForm
    {
        #region 属性
        public PT_TruckMeasurePlan TruckMeasurePlan { get; set; }
        public IPT_TruckMeasurePlanService MainService { get; set; }
        public PT_TruckMeasurePlan TruckMeasurePlan2 { get; set; }
        public bool isFuzhi = false;

        #endregion

        #region 下拉框数据源

        public List<string> Depts { get; set; }
        public List<string> Stores { get; set; }
        public List<string> CarsNums { get; set; }
        public List<string> Products { get; set; }
        public List<SM_Materiel_Level> Materiels { get; set; }
        public List<string> Pounds { get; set; }

        #endregion




        public PT_TruckMeasurePlanOperate_Form()
        {
            InitializeComponent();
        }
        private void PT_TruckMeasurePlanOperate_Form_Shown(object sender, EventArgs e)
        {
            InitControl();
            InitEvent();
            if (TruckMeasurePlan != null)
            {
                this.Text += "_修改";
                simpleButton1.Visible = false;
                SetControlValue();
            }
            else
            {
                if (isFuzhi)
                {
                    TruckMeasurePlan = TruckMeasurePlan2;
                    SetControlValue();
                    comboBox1.Text = getPlanNo(txt_PlanNo.Text.Trim().Substring(0, 2));
                    txt_PlanNo.Text = string.Empty;
                    TruckMeasurePlan = null;
                }
                this.Text += "_新增";
                date_PlanLimitTime.Text = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd 23:59:59");

                txt_UpdateUserName.Text = SessionHelper.LogUserNickName;
                txt_UpdateTime.Text = DateTime.Now.ToString();
                txt_CreateUserName.Text = SessionHelper.LogUserNickName;
                txt_CreateTime.Text = DateTime.Now.ToString();

                cBox_PlanState.Text = "未完成";
                cBox_RepeatPound.Text = "无";
                simpleButton1.Visible = true;
            }
        }
        public string getPlanNo(string str)
        {
            try
            {
                string returnStr = string.Empty;
                switch (str)
                {
                    case "AC":
                        returnStr = "物流";
                        break;
                    case "A0":
                        returnStr = "铁前";
                        break;
                    case "EP":
                        returnStr = "物资";
                        break;
                    case "A6":
                        returnStr = "炼钢";
                        break;
                    case "A9":
                        returnStr = "棒线";
                        break;
                    case "A8":
                        returnStr = "冷轧";
                        break;
                    case "A1":
                        returnStr = "钢后";
                        break;
                    case "B3":
                        returnStr = "强实";
                        break;
                    default:
                        returnStr = "物流";
                        break;
                }
                return returnStr;
            }
            catch (Exception)
            {
                return "物流";
            }
        }

        #region  逻辑方法
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!VerificatControl())
                return;
            if (TruckMeasurePlan == null)
            {
                InsertTruckMeasurePlan();
            }
            else
            {
                UpdateTruckMeasurePlan();
            }
        }
        /// <summary>
        /// 插入方法
        /// </summary>
        private void InsertTruckMeasurePlan()
        {
            TruckMeasurePlan = new PT_TruckMeasurePlan();
            //基础信息
            //TruckMeasurePlan.C_PLANNO= txt_PlanNo.Text;
            TruckMeasurePlan.C_PLANNO = comboBox1.Text.Trim();
            TruckMeasurePlan.C_CARSERIALNUMBER = txt_CARSERIALNUMBER.Text.Trim();
            TruckMeasurePlan.C_CONTRACTNO = txt_CONTRACTNO.Text.Trim();


            if (cBox_PlanState.Text == "已完成")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已完成; }
            else if (cBox_PlanState.Text == "已作废")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已作废; }
            else
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.未完成; }
            TruckMeasurePlan.C_SHIPPINGNOTE = txt_ShippingNote.Text.Trim();
            TruckMeasurePlan.I_ISAUTO = check_IsAuto.Checked == true ? 1 : 0;
            TruckMeasurePlan.I_RESERVE1 = check_IsContainer.Checked == true ? 1 : 0;
            if (radio_EnterFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.进厂;
            else if (radio_OutFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.出厂;
            else if (radio_Transfer.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒;
            else if (radio_Tain.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车进厂;
            else if (radio_cgnz.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.采购内转;
            else if (radio_ndw.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒_外;
            else if (radio_hcjzx.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车集装箱;

            if (radio_LongTerm.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.长期委托; }
            else if (radio_Once.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.一次委托; }

            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();

            if (radio_PiFirst.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先皮后毛; }
            else if (radio_MaoFirst1.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先毛后皮; }
            else if (radio_LimitPi.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.限期皮重; }

            TruckMeasurePlan.I_TARETIMELIMIT = int.Parse(Spin_TareTimeLimit.Value.ToString());
            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();
            TruckMeasurePlan.C_CARNAME = cBox_CarName.Text.ToUpper().Trim();
            TruckMeasurePlan.C_MATERIALNAME = CsTB_MaterialName.Text.Trim();
            TruckMeasurePlan.C_MATERIALNO = CsTB_MaterialName.SelectKey;
            TruckMeasurePlan.C_PLANLIMITTIME = CommonHelper.TimeToStr14(Convert.ToDateTime(date_PlanLimitTime.Text));
            TruckMeasurePlan.C_FROMDEPTNAME = cBox_FromDeptName.Text.Trim();
            TruckMeasurePlan.C_FROMSTORENAME = cBox_FromStoreName.Text.Trim();
            TruckMeasurePlan.C_CONTAINERNO = txt_memoContainer.Text.Trim();
            if (cBox_RepeatPound.Text == "毛毛皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮; }
            else if (cBox_RepeatPound.Text == "毛毛皮皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮皮; }
            else { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.无; }

            TruckMeasurePlan.C_TODEPTNAME = cBox_ToDeptName.Text.Trim();
            TruckMeasurePlan.C_TOSTORENAME = cBox_ToStoreName.Text.Trim();

            //特殊业务
            if (radio_NoMore.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.无;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreLoad.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多装;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreUnload.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多卸;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (cBox_Ischildidenfy.Text == "母标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.母标识; }
            else if (cBox_Ischildidenfy.Text == "子标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.子标识; }
            else
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.正常; }

            TruckMeasurePlan.I_ISCREATEMOTHERPOND = check_IsCreateMotherpond.Checked == true ? 1 : 0;
            TruckMeasurePlan.C_CONNECTPLANNO = txt_ConnectPlanNo.Text.Trim();


            if (radio_TwoPlan.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = 0;
                TruckMeasurePlan.I_ONETWOPLAN = 1;
            }
            TruckMeasurePlan.C_MIDDLEDEPTNAME = cBox_MiddleDeptName.Text.Trim();
            TruckMeasurePlan.C_MIDDLESTORENAME = cBox_MiddleStoreName.Text.Trim();


            //理重
            TruckMeasurePlan.I_RETALLYKG = int.Parse(Spin_RetallyKg.Value.ToString());
            if (radio_ComputerTypeNo.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = 0; }
            else if (radio_ComputerTypeFix.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.固定值; }
            else if (radio_ComputerTypePer.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.百分比; }


            TruckMeasurePlan.I_DOWNVALUE = int.Parse(Spin_DownValue.Value.ToString());
            TruckMeasurePlan.I_UPVALUE = int.Parse(Spin_UpValue.Value.ToString());
            TruckMeasurePlan.C_PERCENTAGE = Spin_PercenTage.Text;

            //其他
            TruckMeasurePlan.C_REMARK = memo_Remark.Text.Trim();
            //TruckMeasurePlan.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
            //TruckMeasurePlan.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            TruckMeasurePlan.C_CREATEUSERNAME = SessionHelper.LogUserNickName;
            TruckMeasurePlan.C_CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);

            var result = MainService.ExecuteDB_InsertTruckMeasurePlan(TruckMeasurePlan);
            if (result == null || result is CustomDBError)
            {
                MessageDxUtil.ShowError("新增异常！！！" + ((CustomDBError)result).ErrorMsg);
                TruckMeasurePlan = null;
            }
            else
            {
                MessageDxUtil.ShowTips("新增成功！");
                this.Close();
            }
        }

        private void InsertTruckMeasurePlan2()
        {
            TruckMeasurePlan = new PT_TruckMeasurePlan();
            //基础信息
            //TruckMeasurePlan.C_PLANNO= txt_PlanNo.Text;
            TruckMeasurePlan.C_PLANNO = comboBox1.Text.Trim();
            TruckMeasurePlan.C_CARSERIALNUMBER = txt_CARSERIALNUMBER.Text.Trim();
            TruckMeasurePlan.C_CONTRACTNO = txt_CONTRACTNO.Text.Trim();


            if (cBox_PlanState.Text == "已完成")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已完成; }
            else if (cBox_PlanState.Text == "已作废")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已作废; }
            else
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.未完成; }
            TruckMeasurePlan.C_SHIPPINGNOTE = txt_ShippingNote.Text.Trim();
            TruckMeasurePlan.I_ISAUTO = check_IsAuto.Checked == true ? 1 : 0;
            TruckMeasurePlan.I_RESERVE1 = check_IsContainer.Checked == true ? 1 : 0;
            if (radio_EnterFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.进厂;
            else if (radio_OutFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.出厂;
            else if (radio_Transfer.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒;
            else if (radio_Tain.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车进厂;
            else if (radio_cgnz.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.采购内转;
            else if (radio_ndw.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒_外;
            else if (radio_hcjzx.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车集装箱;

            if (radio_LongTerm.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.长期委托; }
            else if (radio_Once.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.一次委托; }

            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();

            if (radio_PiFirst.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先皮后毛; }
            else if (radio_MaoFirst1.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先毛后皮; }
            else if (radio_LimitPi.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.限期皮重; }

            TruckMeasurePlan.I_TARETIMELIMIT = int.Parse(Spin_TareTimeLimit.Value.ToString());
            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();
            //TruckMeasurePlan.C_CARNAME = cBox_CarName.Text.ToUpper().Trim();
            string str = memoEdit1.Text;
            string[] strs = str.Replace("\r\n", ".").Trim().Split('.');

            TruckMeasurePlan.C_MATERIALNAME = CsTB_MaterialName.Text.Trim();
            TruckMeasurePlan.C_MATERIALNO = CsTB_MaterialName.SelectKey;
            TruckMeasurePlan.C_PLANLIMITTIME = CommonHelper.TimeToStr14(Convert.ToDateTime(date_PlanLimitTime.Text));
            TruckMeasurePlan.C_FROMDEPTNAME = cBox_FromDeptName.Text.Trim();
            TruckMeasurePlan.C_FROMSTORENAME = cBox_FromStoreName.Text.Trim();
            TruckMeasurePlan.C_CONTAINERNO = txt_memoContainer.Text.Trim();
            if (cBox_RepeatPound.Text == "毛毛皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮; }
            else if (cBox_RepeatPound.Text == "毛毛皮皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮皮; }
            else { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.无; }

            TruckMeasurePlan.C_TODEPTNAME = cBox_ToDeptName.Text.Trim();
            TruckMeasurePlan.C_TOSTORENAME = cBox_ToStoreName.Text.Trim();

            //特殊业务
            if (radio_NoMore.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.无;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreLoad.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多装;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreUnload.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多卸;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (cBox_Ischildidenfy.Text == "母标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.母标识; }
            else if (cBox_Ischildidenfy.Text == "子标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.子标识; }
            else
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.正常; }

            TruckMeasurePlan.I_ISCREATEMOTHERPOND = check_IsCreateMotherpond.Checked == true ? 1 : 0;
            TruckMeasurePlan.C_CONNECTPLANNO = txt_ConnectPlanNo.Text.Trim();


            if (radio_TwoPlan.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = 0;
                TruckMeasurePlan.I_ONETWOPLAN = 1;
            }
            TruckMeasurePlan.C_MIDDLEDEPTNAME = cBox_MiddleDeptName.Text.Trim();
            TruckMeasurePlan.C_MIDDLESTORENAME = cBox_MiddleStoreName.Text.Trim();


            //理重
            TruckMeasurePlan.I_RETALLYKG = int.Parse(Spin_RetallyKg.Value.ToString());
            if (radio_ComputerTypeNo.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = 0; }
            else if (radio_ComputerTypeFix.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.固定值; }
            else if (radio_ComputerTypePer.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.百分比; }


            TruckMeasurePlan.I_DOWNVALUE = int.Parse(Spin_DownValue.Value.ToString());
            TruckMeasurePlan.I_UPVALUE = int.Parse(Spin_UpValue.Value.ToString());
            TruckMeasurePlan.C_PERCENTAGE = Spin_PercenTage.Text;

            //其他
            TruckMeasurePlan.C_REMARK = memo_Remark.Text.Trim();
            //TruckMeasurePlan.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
            //TruckMeasurePlan.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);
            TruckMeasurePlan.C_CREATEUSERNAME = SessionHelper.LogUserNickName;
            TruckMeasurePlan.C_CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);

            var result = MainService.ExecuteDB_InsertTruckMeasurePlan2(TruckMeasurePlan, strs);
            if (result == null || result is CustomDBError)
            {
                MessageDxUtil.ShowError("批量新增异常！！！" + ((CustomDBError)result).ErrorMsg);
                TruckMeasurePlan = null;
            }
            else
            {
                MessageDxUtil.ShowTips("批量新增成功！");
                this.Close();
            }
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        private void UpdateTruckMeasurePlan()
        {
            TruckMeasurePlan.C_CARSERIALNUMBER = txt_CARSERIALNUMBER.Text.Trim();
            TruckMeasurePlan.C_CONTRACTNO = txt_CONTRACTNO.Text.Trim();

            TruckMeasurePlan.I_ISAUTO = check_IsAuto.Checked == true ? 1 : 0;
            TruckMeasurePlan.I_RESERVE1 = check_IsContainer.Checked == true ? 1 : 0;
            if (cBox_PlanState.Text == "已完成")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已完成; }
            else if (cBox_PlanState.Text == "已作废")
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.已作废; }
            else
            { TruckMeasurePlan.C_PLANSTATE = PLANSTATE.未完成; }

            if (radio_EnterFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.进厂;
            else if (radio_OutFactory.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.出厂;
            else if (radio_Transfer.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒;
            else if (radio_Tain.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车进厂;
            else if (radio_cgnz.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.采购内转;
            else if (radio_ndw.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.内倒_外;
            else if (radio_hcjzx.Checked == true)
                TruckMeasurePlan.I_BUSINESSTYPE = BUSINESSTYPE.火车集装箱;


            if (radio_LongTerm.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.长期委托; }
            else if (radio_Once.Checked == true)
            { TruckMeasurePlan.I_PLANTYPE = PLANTYPE.一次委托; }

            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();

            if (radio_PiFirst.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先皮后毛; }
            else if (radio_MaoFirst1.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.先毛后皮; }
            else if (radio_LimitPi.Checked == true)
            { TruckMeasurePlan.I_WEIGHTTYPE = WEIGHTTYPE.限期皮重; }

            TruckMeasurePlan.I_TARETIMELIMIT = int.Parse(Spin_TareTimeLimit.Value.ToString());
            TruckMeasurePlan.C_PONDLIMIT = txt_PondLimit.Text.Trim();
            TruckMeasurePlan.C_CARNAME = cBox_CarName.Text.Trim();
            TruckMeasurePlan.C_MATERIALNAME = CsTB_MaterialName.Text.Trim();
            TruckMeasurePlan.C_MATERIALNO = CsTB_MaterialName.SelectKey;
            TruckMeasurePlan.C_PLANLIMITTIME = CommonHelper.TimeToStr14(Convert.ToDateTime(date_PlanLimitTime.Text));
            TruckMeasurePlan.C_FROMDEPTNAME = cBox_FromDeptName.Text.Trim();
            TruckMeasurePlan.C_FROMSTORENAME = cBox_FromStoreName.Text.Trim();
            TruckMeasurePlan.C_CONTAINERNO = txt_memoContainer.Text.Trim();
            if (cBox_RepeatPound.Text == "毛毛皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮; }
            else if (cBox_RepeatPound.Text == "毛毛皮皮") { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.毛毛皮皮; }
            else { TruckMeasurePlan.I_REPEATPOUND = REPEATPOUND.无; }

            TruckMeasurePlan.C_TODEPTNAME = cBox_ToDeptName.Text.Trim();
            TruckMeasurePlan.C_TOSTORENAME = cBox_ToStoreName.Text.Trim();

            //特殊业务
            if (radio_NoMore.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.无;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreLoad.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多装;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (radio_MoreUnload.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = ONEMORESTOCK.一车多卸;
                TruckMeasurePlan.I_ONETWOPLAN = 0;
            }
            if (cBox_Ischildidenfy.Text == "母标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.母标识; }
            else if (cBox_Ischildidenfy.Text == "子标识")
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.子标识; }
            else
            { TruckMeasurePlan.I_ISCHILDIDENFY = ISCHILDIDENFY.正常; }

            TruckMeasurePlan.I_ISCREATEMOTHERPOND = check_IsCreateMotherpond.Checked == true ? 1 : 0;
            TruckMeasurePlan.C_CONNECTPLANNO = txt_ConnectPlanNo.Text.Trim();


            if (radio_TwoPlan.Checked == true)
            {
                TruckMeasurePlan.I_ONEMORESTOCK = 0;
                TruckMeasurePlan.I_ONETWOPLAN = 1;
            }
            TruckMeasurePlan.C_MIDDLEDEPTNAME = cBox_MiddleDeptName.Text.Trim();
            TruckMeasurePlan.C_MIDDLESTORENAME = cBox_MiddleStoreName.Text.Trim();


            //理重
            TruckMeasurePlan.I_RETALLYKG = int.Parse(Spin_RetallyKg.Value.ToString());
            if (radio_ComputerTypeNo.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = 0; }
            else if (radio_ComputerTypeFix.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.固定值; }
            else if (radio_ComputerTypePer.Checked == true)
            { TruckMeasurePlan.I_COMPUTERTYPE = COMPUTERTYPE.百分比; }


            TruckMeasurePlan.I_DOWNVALUE = int.Parse(Spin_DownValue.Value.ToString());
            TruckMeasurePlan.I_UPVALUE = int.Parse(Spin_UpValue.Value.ToString());
            TruckMeasurePlan.C_PERCENTAGE = Spin_PercenTage.Text;

            //其他
            TruckMeasurePlan.C_REMARK = memo_Remark.Text.Trim();
            TruckMeasurePlan.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
            TruckMeasurePlan.C_UPDATETIME = CommonHelper.TimeToStr14(DateTime.Now);

            var result = MainService.ExecuteDB_UpdateTruckMeasurePlan(TruckMeasurePlan);
            if (result == null)
            {
                MessageDxUtil.ShowError("修改异常！！！");
            }
            else
            {
                MessageDxUtil.ShowTips("修改成功！");
                this.Close();
            }
        }

        /// <summary>
        /// 给控件赋值
        /// </summary>
        private void SetControlValue()
        {
            //基础信息
            txt_PlanNo.Text = TruckMeasurePlan.C_PLANNO;
            cBox_PlanState.Text = TruckMeasurePlan.C_PLANSTATE.ToString();
            txt_ShippingNote.Text = TruckMeasurePlan.C_SHIPPINGNOTE;

            txt_CARSERIALNUMBER.Text = TruckMeasurePlan.C_CARSERIALNUMBER;
            txt_CONTRACTNO.Text = TruckMeasurePlan.C_CONTRACTNO;
            txt_memoContainer.Text = TruckMeasurePlan.C_CONTAINERNO;
            switch (TruckMeasurePlan.I_BUSINESSTYPE)
            {
                case BUSINESSTYPE.进厂:
                    radio_EnterFactory.Checked = true; break;
                case BUSINESSTYPE.出厂:
                    radio_OutFactory.Checked = true; break;
                case BUSINESSTYPE.内倒:
                    radio_Transfer.Checked = true; break;                    
                case BUSINESSTYPE.火车进厂:
                    radio_Tain.Checked = true; break;
                case BUSINESSTYPE.采购内转:
                    radio_cgnz.Checked = true; break;
                case BUSINESSTYPE.内倒_外:
                    radio_ndw.Checked = true; break;
                case BUSINESSTYPE.火车集装箱:
                    radio_hcjzx.Checked = true; break;
            }
            switch (TruckMeasurePlan.I_ISAUTO)
            {
                case 0:
                    check_IsAuto.Checked = false; break;
                case 1:
                    check_IsAuto.Checked = true; break;
            }
            switch (TruckMeasurePlan.I_RESERVE1)
            {
                case 0:
                    check_IsContainer.Checked = false; break;
                case 1:
                    check_IsContainer.Checked = true; break;
            }
            switch (TruckMeasurePlan.I_PLANTYPE)
            {
                case PLANTYPE.长期委托:
                    radio_LongTerm.Checked = true; break;
                case PLANTYPE.一次委托:
                    radio_Once.Checked = true; break;
            }
            txt_PondLimit.Text = TruckMeasurePlan.C_PONDLIMIT;
            switch (TruckMeasurePlan.I_WEIGHTTYPE)
            {
                case WEIGHTTYPE.先皮后毛:
                    radio_PiFirst.Checked = true; break;
                case WEIGHTTYPE.先毛后皮:
                    radio_MaoFirst1.Checked = true; break;
                case WEIGHTTYPE.限期皮重:
                    radio_LimitPi.Checked = true; break;
            }
            Spin_TareTimeLimit.Value = TruckMeasurePlan.I_TARETIMELIMIT;
            txt_PondLimit.Text = TruckMeasurePlan.C_PONDLIMIT;
            cBox_CarName.Text = TruckMeasurePlan.C_CARNAME;
            CsTB_MaterialName.Text = TruckMeasurePlan.C_MATERIALNAME;
            CsTB_MaterialName.SelectKey = TruckMeasurePlan.C_MATERIALNO;
            date_PlanLimitTime.Text = CommonHelper.Str14ToTimeFormart(TruckMeasurePlan.C_PLANLIMITTIME); ;
            cBox_FromDeptName.Text = TruckMeasurePlan.C_FROMDEPTNAME;
            cBox_FromStoreName.Text = TruckMeasurePlan.C_FROMSTORENAME;
            switch (TruckMeasurePlan.I_REPEATPOUND)
            {
                case REPEATPOUND.无:
                    cBox_RepeatPound.Text = "无"; break;
                case REPEATPOUND.毛毛皮:
                    cBox_RepeatPound.Text = "毛毛皮"; break;
                case REPEATPOUND.毛毛皮皮:
                    cBox_RepeatPound.Text = "毛毛皮皮"; break;
            }

            cBox_ToDeptName.Text = TruckMeasurePlan.C_TODEPTNAME;
            cBox_ToStoreName.Text = TruckMeasurePlan.C_TOSTORENAME;

            //特殊业务
            switch (TruckMeasurePlan.I_ONEMORESTOCK)
            {
                case ONEMORESTOCK.无:
                    radio_NoMore.Checked = true;
                    break;
                case ONEMORESTOCK.一车多装:
                    radio_MoreLoad.Checked = true;
                    break;
                case ONEMORESTOCK.一车多卸:
                    radio_MoreUnload.Checked = true;
                    break;
            }
            if (TruckMeasurePlan.I_ONETWOPLAN == 1)
            {
                radio_TwoPlan.Checked = true;
            }
            switch (TruckMeasurePlan.I_ISCHILDIDENFY)
            {
                case ISCHILDIDENFY.子标识:
                    cBox_Ischildidenfy.Text = "子标识";
                    break;
                case ISCHILDIDENFY.母标识:
                    cBox_Ischildidenfy.Text = "母标识";
                    break;
                default:
                    cBox_Ischildidenfy.Text = "";
                    break;
            }
            check_IsCreateMotherpond.Checked = TruckMeasurePlan.I_ISCREATEMOTHERPOND == 1 ? true : false;
            txt_ConnectPlanNo.Text = TruckMeasurePlan.C_CONNECTPLANNO;
            cBox_MiddleDeptName.Text = TruckMeasurePlan.C_MIDDLEDEPTNAME;
            cBox_MiddleStoreName.Text = TruckMeasurePlan.C_MIDDLESTORENAME;


            //理重

            Spin_RetallyKg.Value = TruckMeasurePlan.I_RETALLYKG;
            switch (TruckMeasurePlan.I_COMPUTERTYPE)
            {
                case COMPUTERTYPE.无:
                    radio_ComputerTypeNo.Checked = true;
                    break;
                case COMPUTERTYPE.固定值:
                    radio_ComputerTypeFix.Checked = true;
                    break;
                case COMPUTERTYPE.百分比:
                    radio_ComputerTypePer.Checked = true;
                    break;
            }

            Spin_DownValue.Value = TruckMeasurePlan.I_DOWNVALUE;
            Spin_UpValue.Value = TruckMeasurePlan.I_UPVALUE;
            Spin_PercenTage.Text = TruckMeasurePlan.C_PERCENTAGE;

            //其他
            memo_Remark.Text = TruckMeasurePlan.C_REMARK;
            txt_UpdateUserName.Text = TruckMeasurePlan.C_UPDATEUSERNAME;
            txt_UpdateTime.Text = CommonHelper.Str14ToTimeFormart(TruckMeasurePlan.C_UPDATETIME);
            txt_CreateTime.Text = CommonHelper.Str14ToTimeFormart(TruckMeasurePlan.C_CREATETIME);
            txt_CreateUserName.Text = TruckMeasurePlan.C_CREATEUSERNAME;
        }

        /// <summary>
        /// 控件的基本设置及绑定数据源
        /// </summary>
        private void InitControl()
        {
            //cBox_PondLimit.Properties.Items.AddRange(Pounds.ToArray());
            cBox_CarName.Items.AddRange(CarsNums.ToArray());
            //cBox_MaterialName.Items.AddRange(Products.ToArray());
            CsTB_MaterialName.Datasources = Materiels;


            cBox_FromDeptName.Items.AddRange(Depts.ToArray());
            cBox_ToDeptName.Items.AddRange(Depts.ToArray());
            cBox_MiddleDeptName.Properties.Items.AddRange(Depts);

            cBox_ToStoreName.Items.AddRange(Stores.ToArray());
            cBox_FromStoreName.Items.AddRange(Stores.ToArray());
            cBox_MiddleStoreName.Properties.Items.AddRange(Stores.ToArray());
        }

        /// <summary>
        /// 控件事件绑定
        /// </summary>
        private void InitEvent()
        {
            //groupBox1.Paint += groupBox_Paint;
            //groupBox5.Paint += groupBox_Paint;
            //groupBox6.Paint += groupBox_Paint;
            //groupBox7.Paint += groupBox_Paint;
            this.radio_EnterFactory.CheckedChanged += new System.EventHandler(this.radio_EnterFactory_CheckedChanged);
            this.radio_OutFactory.CheckedChanged += new System.EventHandler(this.radio_OutFactory_CheckedChanged);
            this.radio_Transfer.CheckedChanged += new System.EventHandler(this.radio_Transfer_CheckedChanged);
            this.radio_Tain.CheckedChanged += new System.EventHandler(this.radio_Tain_CheckedChanged);
        }
        #endregion



        #region 业务控制
        /// <summary>
        /// 验证控件不能为空
        /// </summary>
        private bool VerificatControl()
        {
            DxError.ClearErrors();
            errorProvider1.Clear();
            bool IsOk = true;
            //基础信息
            if (string.IsNullOrEmpty(comboBox1.Text.Trim()) && TruckMeasurePlan == null)
            {
                errorProvider1.SetError(comboBox1, "此栏不能为空！");
                IsOk = false;
            }
            if (string.IsNullOrEmpty(cBox_CarName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_CarName, "此栏不能为空！");
                IsOk = false;
            }
            if (string.IsNullOrEmpty(CsTB_MaterialName.Text.Trim()))
            {
                errorProvider1.SetError(CsTB_MaterialName, "此栏不能为空！");
                IsOk = false;
            }

            if (string.IsNullOrEmpty(cBox_FromDeptName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_FromDeptName, "此栏不能为空！");
                IsOk = false;
            }
            //if (string.IsNullOrEmpty(cBox_FromStoreName.Text))
            //{
            //    errorProvider1.SetError(cBox_FromStoreName, "此栏不能为空！");
            //    IsOk = false;
            //}
            if (string.IsNullOrEmpty(cBox_ToDeptName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_ToDeptName, "此栏不能为空！");
                IsOk = false;
            }
            //if (string.IsNullOrEmpty(cBox_ToStoreName.Text))
            //{
            //    errorProvider1.SetError(cBox_ToStoreName, "此栏不能为空！");
            //    IsOk = false;
            //}

            if (radio_LimitPi.Checked == true)
            {
                if (Spin_TareTimeLimit.Value <= 0)
                {
                    errorProvider1.SetError(Spin_TareTimeLimit, "皮重时限不能为0！");
                    IsOk = false;
                }
            }

            if (string.IsNullOrEmpty(date_PlanLimitTime.Text.Trim()))
            {
                errorProvider1.SetError(date_PlanLimitTime, "失效时间不能为空！");
                IsOk = false;
            }

            //特殊业务
            if (radio_MoreLoad.Checked == true || radio_MoreUnload.Checked == true)
            {
                if (cBox_Ischildidenfy.Text != "母标识")
                {
                    if (string.IsNullOrEmpty(txt_ConnectPlanNo.Text))
                    {
                        DxError.SetError(txt_ConnectPlanNo, "关联单号不能为空！", ErrorType.Information);
                        IsOk = false;
                    }
                }
            }
            if (radio_TwoPlan.Checked == true)
            {
                if (string.IsNullOrEmpty(cBox_MiddleDeptName.Text.Trim()))
                {
                    DxError.SetError(cBox_MiddleDeptName, "中间单位不能为空！", ErrorType.Information);
                    IsOk = false;
                }
                //if (string.IsNullOrEmpty(cBox_MiddleStoreName.Text))
                //{
                //    DxError.SetError(cBox_MiddleStoreName, "中间仓库不能为空！", ErrorType.Information);
                //    IsOk = false;
                //}
            }
            if (radio_ComputerTypeFix.Checked == true)
            {
                if (Spin_RetallyKg.Value == 0)
                {
                    errorProvider1.SetError(Spin_RetallyKg, "理重不能为0！");
                    IsOk = false;
                }
            }
            if (radio_ComputerTypePer.Checked == true)
            {
                if (Spin_RetallyKg.Value == 0)
                {
                    errorProvider1.SetError(Spin_RetallyKg, "理重不能为0！");
                    IsOk = false;
                }
                //if (Spin_PercenTage.Value == 0)
                //{
                //    errorProvider1.SetError(Spin_PercenTage, "偏差百分比不能为0！");
                //    IsOk = false;
                //}
            }
            return IsOk;
        }

        /// <summary>
        /// 验证控件不能为空
        /// </summary>
        private bool VerificatControl2()
        {
            DxError.ClearErrors();
            errorProvider1.Clear();
            bool IsOk = true;
            //基础信息
            if (string.IsNullOrEmpty(comboBox1.Text.Trim()) && TruckMeasurePlan == null)
            {
                errorProvider1.SetError(comboBox1, "此栏不能为空！");
                IsOk = false;
            }
            if (string.IsNullOrEmpty(memoEdit1.Text.Trim()))
            {
                errorProvider1.SetError(memoEdit1, "此栏不能为空！");
                IsOk = false;
            }
            if (string.IsNullOrEmpty(CsTB_MaterialName.Text.Trim()))
            {
                errorProvider1.SetError(CsTB_MaterialName, "此栏不能为空！");
                IsOk = false;
            }

            if (string.IsNullOrEmpty(cBox_FromDeptName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_FromDeptName, "此栏不能为空！");
                IsOk = false;
            }
            //if (string.IsNullOrEmpty(cBox_FromStoreName.Text))
            //{
            //    errorProvider1.SetError(cBox_FromStoreName, "此栏不能为空！");
            //    IsOk = false;
            //}
            if (string.IsNullOrEmpty(cBox_ToDeptName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_ToDeptName, "此栏不能为空！");
                IsOk = false;
            }
            //if (string.IsNullOrEmpty(cBox_ToStoreName.Text))
            //{
            //    errorProvider1.SetError(cBox_ToStoreName, "此栏不能为空！");
            //    IsOk = false;
            //}

            if (radio_LimitPi.Checked == true)
            {
                if (Spin_TareTimeLimit.Value <= 0)
                {
                    errorProvider1.SetError(Spin_TareTimeLimit, "皮重时限不能为0！");
                    IsOk = false;
                }
            }

            if (string.IsNullOrEmpty(date_PlanLimitTime.Text.Trim()))
            {
                errorProvider1.SetError(date_PlanLimitTime, "失效时间不能为空！");
                IsOk = false;
            }

            //特殊业务
            if (radio_MoreLoad.Checked == true || radio_MoreUnload.Checked == true)
            {
                if (cBox_Ischildidenfy.Text != "母标识")
                {
                    if (string.IsNullOrEmpty(txt_ConnectPlanNo.Text))
                    {
                        DxError.SetError(txt_ConnectPlanNo, "关联单号不能为空！", ErrorType.Information);
                        IsOk = false;
                    }
                }
            }
            if (radio_TwoPlan.Checked == true)
            {
                if (string.IsNullOrEmpty(cBox_MiddleDeptName.Text.Trim()))
                {
                    DxError.SetError(cBox_MiddleDeptName, "中间单位不能为空！", ErrorType.Information);
                    IsOk = false;
                }
                //if (string.IsNullOrEmpty(cBox_MiddleStoreName.Text))
                //{
                //    DxError.SetError(cBox_MiddleStoreName, "中间仓库不能为空！", ErrorType.Information);
                //    IsOk = false;
                //}
            }
            if (radio_ComputerTypeFix.Checked == true)
            {
                if (Spin_RetallyKg.Value == 0)
                {
                    errorProvider1.SetError(Spin_RetallyKg, "理重不能为0！");
                    IsOk = false;
                }
            }
            if (radio_ComputerTypePer.Checked == true)
            {
                if (Spin_RetallyKg.Value == 0)
                {
                    errorProvider1.SetError(Spin_RetallyKg, "理重不能为0！");
                    IsOk = false;
                }
                //if (Spin_PercenTage.Value == 0)
                //{
                //    errorProvider1.SetError(Spin_PercenTage, "偏差百分比不能为0！");
                //    IsOk = false;
                //}
            }
            return IsOk;
        }

        #region 业务类型
        /// <summary>
        /// 进厂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_EnterFactory_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_EnterFactory.Checked == true)
            {
                radio_MaoFirst1.Checked = true;
            }
        }
        /// <summary>
        /// 出厂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_OutFactory_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_OutFactory.Checked == true)
            {
                radio_PiFirst.Checked = true;
            }
        }
        /// <summary>
        /// 内倒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_Transfer_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Transfer.Checked == true)
            {
                radio_LimitPi.Checked = true;
            }
        }

        private void radio_Tain_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Tain.Checked == true)
            {
                radio_MaoFirst1.Checked = true;
            }
        }

        #endregion

        #region 特殊业务
        /// <summary>
        /// 无特殊业务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_NoMore_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_NoMore.Checked == true)
            {
                layoutControl2.Enabled = false;
                layoutControl1.Enabled = false;

                cBox_MiddleDeptName.Text = "";
                cBox_MiddleStoreName.Text = "";
                cBox_Ischildidenfy.Text = "";
                check_IsCreateMotherpond.Checked = false;
                txt_ConnectPlanNo.Text = "";
            }
        }
        /// <summary>
        /// 一车多装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_MoreLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_MoreLoad.Checked == true)
            {
                layoutControl2.Enabled = true;
                layoutControl1.Enabled = false;
                cBox_MiddleDeptName.Text = "";
                cBox_MiddleStoreName.Text = "";

                cBox_Ischildidenfy.Text = "";
                cBox_Ischildidenfy.Enabled = false;
                check_IsCreateMotherpond.Enabled = false;
            }
            else
            {
                cBox_Ischildidenfy.Text = "";
                cBox_Ischildidenfy.Enabled = true;
                check_IsCreateMotherpond.Enabled = true;
            }
        }
        /// <summary>
        /// 一车多卸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_MoreUnload_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_MoreUnload.Checked == true)
            {
                layoutControl2.Enabled = true;
                layoutControl1.Enabled = false;
                cBox_MiddleDeptName.Text = "";
                cBox_MiddleStoreName.Text = "";
            }
        }
        /// <summary>
        /// 一车两单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_TwoPlan_CheckedChanged(object sender, EventArgs e)
        {
            layoutControl2.Enabled = false;
            layoutControl1.Enabled = true;

            cBox_Ischildidenfy.Text = "";
            check_IsCreateMotherpond.Checked = false;
            txt_ConnectPlanNo.Text = "";
        }

        private void cBox_Ischildidenfy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBox_Ischildidenfy.Text == "母标识")
            {
                check_IsCreateMotherpond.Checked = false;
                check_IsCreateMotherpond.Enabled = false;
                txt_ConnectPlanNo.Text = "";
                txt_ConnectPlanNo.Enabled = false;
            }
            else
            {
                check_IsCreateMotherpond.Checked = false;
                check_IsCreateMotherpond.Enabled = true;
                txt_ConnectPlanNo.Text = "";
                txt_ConnectPlanNo.Enabled = true;
            }
        }
        #endregion

        #region 理重
        /// <summary>
        /// 无理重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ComputerTypeNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_ComputerTypeNo.Checked == true)
            {
                Spin_UpValue.Enabled = false;
                Spin_DownValue.Enabled = false;
                Spin_PercenTage.Enabled = false;
            }
        }
        /// <summary>
        /// 固定值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ComputerTypeFix_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_ComputerTypeFix.Checked == true)
            {
                Spin_UpValue.Enabled = true;
                Spin_DownValue.Enabled = true;
                Spin_PercenTage.Enabled = false;
            }
        }
        /// <summary>
        /// 百分比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ComputerTypePer_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_ComputerTypePer.Checked == true)
            {
                Spin_UpValue.Enabled = false;
                Spin_DownValue.Enabled = false;
                Spin_PercenTage.Enabled = true;
            }
        }

        #endregion

        #region 页面颜色控制

        private void date_PlanLimitTime_EditValueChanged(object sender, EventArgs e)
        {
            if (date_PlanLimitTime.EditValue == null)
                return;
            DateTime dt = Convert.ToDateTime(date_PlanLimitTime.EditValue);
            if (dt < DateTime.Now)
            {
                date_PlanLimitTime.ForeColor = Color.Red;
            }
            else
            {
                date_PlanLimitTime.ForeColor = Color.Black;
            }
        }

        private void cBox_PlanState_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBox_PlanState.Text != "未完成")
            {
                cBox_PlanState.ForeColor = Color.Red;
            }
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;
            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.DarkTurquoise, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.DarkTurquoise, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.DarkTurquoise, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.DarkTurquoise, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.DarkTurquoise, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.DarkTurquoise, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }






        #endregion

        #endregion

        private void cBox_RepeatPound_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBox_RepeatPound.Text.Trim() == "毛毛皮" || cBox_RepeatPound.Text.Trim() == "毛毛皮皮")
            {
                radio_NoMore.Checked = true;
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //string str = memoEdit1.Text;
        //string[] strs = str.Replace("\r\n",".").Trim().Split('.');
        //cBox_MaterialName.Text = "白云石粉";
        //cBox_FromDeptName.Text = "广西柳钢新材料科技有限公司";
        //cBox_ToDeptName.Text = "广西钢铁集团有限公司";
        //cBox_FromStoreName.Text = "广西柳钢新材料科技有限公司仓库";
        //cBox_ToStoreName.Text = "广西钢铁集团有限公司烧结料场";
        //comboBox1.Text = "物流";
        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!VerificatControl2())
                return;
            if (TruckMeasurePlan == null)
            {
                InsertTruckMeasurePlan2();
            }
        }
    }
}
