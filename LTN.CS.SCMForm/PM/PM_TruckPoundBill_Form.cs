using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.Enum;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress;

using DevExpress.XtraEditors;


namespace LTN.CS.SCMForm.PM
{
    public partial class PM_TruckPoundBill_Form : CoreForm
    {
        public IPM_Bill_TruckService MainService { get; set; }
        public PM_Bill_Truck TruckBill { get; set; }

        private PT_TruckMeasurePlan TruckMeasurePlan;

        public bool ResetFlag = false;
        #region 下拉框数据源
        public List<string> Depts { get; set; }
        public List<string> Stores { get; set; }
        public List<string> CarsNums { get; set; }
        public List<string> Products { get; set; }
        public List<SM_Materiel_Level> Materiels { get; set; }
        public List<SM_PoundSite_Info> Pounds { get; set; }

        #endregion
        public PM_TruckPoundBill_Form()
        {
            InitializeComponent();
        }


        #region radio的checkedchange事件
        private void InitEvent()
        {
            this.radio_EnterFactory.CheckedChanged += new System.EventHandler(this.radio_EnterFactory_CheckedChanged);
            this.radio_OutFactory.CheckedChanged += new System.EventHandler(this.radio_OutFactory_CheckedChanged);
            this.radio_Transfer.CheckedChanged += new System.EventHandler(this.radio_Transfer_CheckedChanged);
            this.radio_Tain.CheckedChanged += new System.EventHandler(this.radio_Tain_CheckedChanged);

            this.radio_NoMore.CheckedChanged += new System.EventHandler(this.radio_NoMore_CheckedChanged);
            this.radio_MoreLoad.CheckedChanged += new System.EventHandler(this.radio_MoreLoad_CheckedChanged);
            this.radio_MoreUnload.CheckedChanged += new System.EventHandler(this.radio_MoreUnload_CheckedChanged);
            this.radio_TwoPlan.CheckedChanged += new System.EventHandler(this.radio_TwoPlan_CheckedChanged);

            this.radio_ComputerTypeNo.CheckedChanged += new System.EventHandler(this.radio_ComputerTypeNo_CheckedChanged);
            this.radio_ComputerTypeFix.CheckedChanged += new System.EventHandler(this.radio_ComputerTypeFix_CheckedChanged);
            this.radio_ComputerTypePer.CheckedChanged += new System.EventHandler(this.radio_ComputerTypePer_CheckedChanged);
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
        private void radio_Tain_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Tain.Checked == true)
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

        #endregion

        /// <summary>
        /// 控件绑定数据源
        /// </summary>
        private void InitControl()
        {
            // cBox_PondLimit.Properties.Items.AddRange(Pounds.Select(r=>r.PoundSiteName).ToArray());
            cBox_CarName.Items.AddRange(CarsNums.ToArray());
            CsTB_MaterialName.Datasources = Materiels;

            cBox_FromDeptName.Items.AddRange(Depts.ToArray());
            cBox_ToDeptName.Items.AddRange(Depts.ToArray());
            cBox_MiddleDeptName.Properties.Items.AddRange(Depts);

            cBox_ToStoreName.Items.AddRange(Stores.ToArray());
            cBox_FromStoreName.Items.AddRange(Stores.ToArray());
            cBox_MiddleStoreName.Properties.Items.AddRange(Stores.ToArray());

            LookUpColumnInfo gCol_SiteNo = new LookUpColumnInfo();
            gCol_SiteNo.FieldName = "PoundSiteNo";
            gCol_SiteNo.Caption = "磅点编号";
            LookUpColumnInfo PoundSiteName = new LookUpColumnInfo();
            PoundSiteName.FieldName = "PoundSiteName";
            PoundSiteName.Caption = "磅点名称";

            LookUp_GrossWgtSite.Properties.DataSource = Pounds;
            LookUp_GrossWgtSite.Properties.DisplayMember = "PoundSiteName";
            LookUp_GrossWgtSite.Properties.ValueMember = "PoundSiteNo";
            LookUp_GrossWgtSite.Properties.Columns.Add(gCol_SiteNo);
            LookUp_GrossWgtSite.Properties.Columns.Add(PoundSiteName);

            LookUp_TareWgtSite.Properties.DataSource = Pounds;
            LookUp_TareWgtSite.Properties.DisplayMember = "PoundSiteName";
            LookUp_TareWgtSite.Properties.ValueMember = "PoundSiteNo";
            LookUp_TareWgtSite.Properties.Columns.Add(gCol_SiteNo);
            LookUp_TareWgtSite.Properties.Columns.Add(PoundSiteName);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!VerificatControl())
                return;
            if (TruckBill == null)
            {
                InsertPM_Bill_Truck();
            }
            else
            {
                UpdatePM_Bill_Truck();
            }
            if (TruckBill != null)
            {
                //更新委托状态（已作废状态暂时不用考虑）
                if (TruckBill.C_BILLSTATE == PLANSTATE.已完成)
                {
                    MainService.ExecuteDB_InvalidPM_TruckMeasure(TruckBill.C_PLANNO, (int)PLANSTATE.已完成);
                }
                else if (TruckBill.C_BILLSTATE == PLANSTATE.未完成)
                {
                    MainService.ExecuteDB_InvalidPM_TruckMeasure(TruckBill.C_PLANNO, (int)PLANSTATE.未完成);
                }
            }
            //Spin_TareWgt.Enabled = false;
            Spin_TareWgt.Properties.ReadOnly = false;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        private void InsertPM_Bill_Truck()
        {
            TruckBill = new PM_Bill_Truck();
            if (TruckMeasurePlan == null)
            {
                MessageDxUtil.ShowTips("该委托单号未确认！");
                return;
            }
            else
            {
                BindPlan();
            }
            //基础信息
            TruckBill.C_CARSERIALNUMBER = txt_CARSERIALNUMBER.Text.Trim();
            TruckBill.C_CONTRACTNO = txt_CONTRACTNO.Text.Trim();
            TruckBill.C_PLANNO = txt_PlanNo.Text.Trim();
            TruckBill.C_CONTAINERNO = txt_containerNo.Text.Trim();
            if (cBox_PlanState.Text == "已完成")
            { TruckBill.C_PLANSTATE = PLANSTATE.已完成; }
            else if (cBox_PlanState.Text == "已作废")
            { TruckBill.C_PLANSTATE = PLANSTATE.已作废; }
            else
            { TruckBill.C_PLANSTATE = PLANSTATE.未完成; }
            TruckBill.C_SHIPPINGNOTE = txt_ShippingNote.Text;
            TruckBill.I_ISAUTO = check_IsAuto.Checked == true ? 1 : 0;
            TruckBill.I_RESERVE1 = check_IsContainer.Checked == true ? 1 : 0;
            if (radio_EnterFactory.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.进厂;
            else if (radio_OutFactory.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.出厂;
            else if (radio_Transfer.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.内倒;
            else if (radio_Tain.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.火车进厂;
            else if (radio_cgnz.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.采购内转;
            else if (radio_ndw.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.内倒_外;
            else if (radio_hcjzx.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.火车集装箱;

            if (radio_LongTerm.Checked == true)
            { TruckBill.I_PLANTYPE = PLANTYPE.长期委托; }
            else if (radio_Once.Checked == true)
            { TruckBill.I_PLANTYPE = PLANTYPE.一次委托; }

            TruckBill.C_PONDLIMIT = cBox_PondLimit.Text.Trim();

            if (radio_PiFirst.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.先皮后毛; }
            else if (radio_MaoFirst1.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.先毛后皮; }
            else if (radio_LimitPi.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.限期皮重; }

            TruckBill.I_TARETIMELIMIT = int.Parse(Spin_TareTimeLimit.Value.ToString());
            TruckBill.C_PONDLIMIT = cBox_PondLimit.Text.Trim();
            TruckBill.C_CARNAME = cBox_CarName.Text.Trim();
            TruckBill.C_MATERIALNAME = CsTB_MaterialName.Text.Trim();
            TruckBill.C_MATERIALNO = CsTB_MaterialName.SelectKey;
            TruckBill.C_PLANLIMITTIME = CommonHelper.TimeToStr14(Convert.ToDateTime(date_PlanLimitTime.Text.Trim()));
            TruckBill.C_FROMDEPTNAME = cBox_FromDeptName.Text.Trim();
            TruckBill.C_FROMSTORENAME = cBox_FromStoreName.Text.Trim();

            if (cBox_RepeatPound.Text == "毛毛皮") { TruckBill.I_REPEATPOUND = REPEATPOUND.毛毛皮; }
            else if (cBox_RepeatPound.Text == "毛毛皮皮") { TruckBill.I_REPEATPOUND = REPEATPOUND.毛毛皮皮; }
            else { TruckBill.I_REPEATPOUND = REPEATPOUND.无; }

            TruckBill.C_TODEPTNAME = cBox_ToDeptName.Text.Trim();
            TruckBill.C_TOSTORENAME = cBox_ToStoreName.Text.Trim();

            //特殊业务
            if (radio_NoMore.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.无;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (radio_MoreLoad.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.一车多装;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (radio_MoreUnload.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.一车多卸;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (cBox_Ischildidenfy.Text == "母标识")
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.母标识; }
            else if (cBox_Ischildidenfy.Text == "子标识")
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.子标识; }
            else
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.正常; }

            TruckBill.I_ISCREATEMOTHERPOND = check_IsCreateMotherpond.Checked == true ? 1 : 0;
            TruckBill.C_CONNECTPLANNO = txt_ConnectPlanNo.Text;


            if (radio_TwoPlan.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = 0;
                TruckBill.I_ONETWOPLAN = 1;
            }
            TruckBill.C_MIDDLEDEPTNAME = cBox_MiddleDeptName.Text.Trim();
            TruckBill.C_MIDDLESTORENAME = cBox_MiddleStoreName.Text.Trim();


            //理重
            TruckBill.I_RETALLYKG = int.Parse(Spin_RetallyKg.Value.ToString());
            if (radio_ComputerTypeNo.Checked == true)
            { TruckBill.I_COMPUTERTYPE = 0; }
            else if (radio_ComputerTypeFix.Checked == true)
            { TruckBill.I_COMPUTERTYPE = COMPUTERTYPE.固定值; }
            else if (radio_ComputerTypePer.Checked == true)
            { TruckBill.I_COMPUTERTYPE = COMPUTERTYPE.百分比; }


            TruckBill.I_DOWNVALUE = int.Parse(Spin_DownValue.Value.ToString());
            TruckBill.I_UPVALUE = int.Parse(Spin_UpValue.Value.ToString());
            TruckBill.C_PERCENTAGE = Spin_PercenTage.Text;

            //其他
            TruckBill.C_REMARK = memo_Remark.Text.Trim();
            TruckBill.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;

            //重量信息
            TruckBill.N_TAREWGT = int.Parse(Spin_TareWgt.Value.ToString());
            TruckBill.N_GROSSWGT = int.Parse(Spin_GrossWgt.Value.ToString());
            TruckBill.N_NETWGT = int.Parse(Spin_NetWgt.Value.ToString());
            if (LookUp_TareWgtSite.EditValue != null)
            {
                TruckBill.C_TAREWGTSITENO = LookUp_TareWgtSite.EditValue.ToString();
                TruckBill.C_TAREWGTSITENAME = LookUp_TareWgtSite.Text.Trim();
            }
            if (LookUp_GrossWgtSite.EditValue != null)
            {
                TruckBill.C_GROSSWGTSITENO = LookUp_GrossWgtSite.EditValue.ToString();
                TruckBill.C_GROSSWGTSITENAME = LookUp_GrossWgtSite.Text.Trim();
            }
            DateTime TareTime = Convert.ToDateTime(date_TareWgtTime.EditValue);
            DateTime GrossTime = Convert.ToDateTime(date_GrossWgtTime.EditValue);
            TruckBill.C_TAREWGTTIME = CommonHelper.TimeToStr14(TareTime);
            TruckBill.C_GROSSWGTTIME = CommonHelper.TimeToStr14(GrossTime);
            if (TareTime > GrossTime)
            {
                TruckBill.C_NETWGTTIME = CommonHelper.TimeToStr14(TareTime);
            }
            else
            {
                TruckBill.C_NETWGTTIME = CommonHelper.TimeToStr14(GrossTime);
            }

            TruckBill.C_TAREWGTMAN = txt_TareWgtMan.Text.Trim();
            TruckBill.C_GROSSWGTMAN = txt_GrossWgtMan.Text.Trim();
            TruckBill.I_RETURNFLAG = checkEdit_ReturnFlag.Checked ? 0 : 1;
            TruckBill.I_REPEATFLAG = checkEdit_RepeatFlag.Checked ? 1 : 0;

            TruckBill.C_PONDREMARK = memo_PondRemark.Text.Trim();
            if (cBox_BillState.Text == "已完成")
            { TruckBill.C_BILLSTATE = PLANSTATE.已完成; }
            else if (cBox_BillState.Text == "已作废")
            { TruckBill.C_BILLSTATE = PLANSTATE.已作废; }
            else
            { TruckBill.C_BILLSTATE = PLANSTATE.未完成; }
            TruckBill.C_UPLOADSTATUE = "N";
            TruckBill.C_PLANSTATUS = "I";
            /*
            //修改 设置c_wgtlistno属性值   磅点编号+时间
            string str = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            //看是先毛后皮还是先皮后毛或者限期皮重
            string weightType = TruckBill.I_WEIGHTTYPE.ToString();
            string site = "";
            switch (weightType)
            {
                case "先皮后毛":
                    site = LookUp_TareWgtSite.EditValue.ToString();
                    break;
                case "先毛后皮":
                    site = LookUp_GrossWgtSite.EditValue.ToString();
                    break;
                case "限期皮重":
                    site = LookUp_GrossWgtSite.EditValue.ToString();
                    break;
            }
            TruckBill.C_WGTLISTNO = site + str;
            */

            var result = MainService.ExecuteDB_InsertPM_Bill_Truck(TruckBill);
            if (result == null)
            {
                MessageDxUtil.ShowError("新增异常！！！");
                TruckBill = null;
            }
            else
            {
                MessageDxUtil.ShowTips("新增成功！");
                this.Close();
            }
        }

        /// <summary>
        /// 绑定计划
        /// </summary>
        private void BindPlan()
        {
            TruckBill.C_PLANNO = TruckMeasurePlan.C_PLANNO;
            TruckBill.C_CONTAINERNO = TruckMeasurePlan.C_CONTAINERNO;
            TruckBill.C_CARNO = TruckMeasurePlan.C_CARNO;
            TruckBill.C_CARNAME = TruckMeasurePlan.C_CARNAME;
            TruckBill.C_MATERIALNO = TruckMeasurePlan.C_MATERIALNO;
            TruckBill.C_MATERIALNAME = TruckMeasurePlan.C_MATERIALNAME;
            TruckBill.C_FROMDEPTNO = TruckMeasurePlan.C_FROMDEPTNO;
            TruckBill.C_FROMDEPTNAME = TruckMeasurePlan.C_FROMDEPTNAME;
            TruckBill.C_FROMSTORENO = TruckMeasurePlan.C_FROMSTORENO;
            TruckBill.C_FROMSTORENAME = TruckMeasurePlan.C_FROMSTORENAME;
            TruckBill.C_TODEPTNO = TruckMeasurePlan.C_TODEPTNO;
            TruckBill.C_TODEPTNAME = TruckMeasurePlan.C_TODEPTNAME;
            TruckBill.C_TOSTORENO = TruckMeasurePlan.C_TOSTORENO;
            TruckBill.C_TOSTORENAME = TruckMeasurePlan.C_TOSTORENAME;
            TruckBill.I_BUSINESSTYPE = TruckMeasurePlan.I_BUSINESSTYPE;
            TruckBill.I_PLANTYPE = TruckMeasurePlan.I_PLANTYPE;
            TruckBill.I_ISAUTO = TruckMeasurePlan.I_ISAUTO;
            TruckBill.I_WEIGHTTYPE = TruckMeasurePlan.I_WEIGHTTYPE;
            TruckBill.I_TARETIMELIMIT = TruckMeasurePlan.I_TARETIMELIMIT;
            TruckBill.I_ONEMORESTOCK = TruckMeasurePlan.I_ONEMORESTOCK;
            TruckBill.I_ISCHILDIDENFY = TruckMeasurePlan.I_ISCHILDIDENFY;
            TruckBill.I_ISCREATEMOTHERPOND = TruckMeasurePlan.I_ISCREATEMOTHERPOND;
            TruckBill.C_CONNECTPLANNO = TruckMeasurePlan.C_CONNECTPLANNO;
            TruckBill.I_ONETWOPLAN = TruckMeasurePlan.I_ONETWOPLAN;
            TruckBill.C_MIDDLEDEPTNO = TruckMeasurePlan.C_MIDDLEDEPTNO;
            TruckBill.C_MIDDLEDEPTNAME = TruckMeasurePlan.C_MIDDLEDEPTNAME;
            TruckBill.C_MIDDLESTORENO = TruckMeasurePlan.C_MIDDLESTORENO;
            TruckBill.C_MIDDLESTORENAME = TruckMeasurePlan.C_MIDDLESTORENAME;
            TruckBill.I_RETALLYKG = TruckMeasurePlan.I_RETALLYKG;
            TruckBill.I_COMPUTERTYPE = TruckMeasurePlan.I_COMPUTERTYPE;
            TruckBill.I_DOWNVALUE = TruckMeasurePlan.I_DOWNVALUE;
            TruckBill.I_UPVALUE = TruckMeasurePlan.I_UPVALUE;
            TruckBill.C_PERCENTAGE = TruckMeasurePlan.C_PERCENTAGE;
            TruckBill.C_SHIPPINGNOTE = TruckMeasurePlan.C_SHIPPINGNOTE;
            TruckBill.I_REPEATPOUND = TruckMeasurePlan.I_REPEATPOUND;
            TruckBill.C_PLANLIMITTIME = TruckMeasurePlan.C_PLANLIMITTIME;
            TruckBill.C_PONDLIMIT = TruckMeasurePlan.C_PONDLIMIT;
            TruckBill.C_REMARK = TruckMeasurePlan.C_REMARK;
            TruckBill.C_RESERVE1 = TruckMeasurePlan.C_RESERVE1;
            TruckBill.C_RESERVE2 = TruckMeasurePlan.C_RESERVE2;
            TruckBill.C_RESERVE3 = TruckMeasurePlan.C_RESERVE3;
            TruckBill.I_RESERVE1 = TruckMeasurePlan.I_RESERVE1;
            TruckBill.I_RESERVE2 = TruckMeasurePlan.I_RESERVE2;
            TruckBill.I_RESERVE3 = TruckMeasurePlan.I_RESERVE3;
            TruckBill.C_PLANSTATE = TruckMeasurePlan.C_PLANSTATE;
            TruckBill.C_CREATETIME = TruckMeasurePlan.C_CREATETIME;
            TruckBill.C_CREATEUSERNAME = TruckMeasurePlan.C_CREATEUSERNAME;
            TruckBill.C_CARSERIALNUMBER = TruckMeasurePlan.C_CARSERIALNUMBER;
            TruckBill.C_CONTRACTNO = TruckMeasurePlan.C_CONTRACTNO;
            //2022-3-29 修改  潘鹏
            TruckBill.C_RESERVE4 = TruckMeasurePlan.C_RESERVE4;
            TruckBill.C_RESERVE5 = TruckMeasurePlan.C_RESERVE5;
            TruckBill.C_RESERVE6 = TruckMeasurePlan.C_RESERVE6;
            TruckBill.C_RESERVE7 = TruckMeasurePlan.C_RESERVE7;

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        private void UpdatePM_Bill_Truck()
        {
            if (TruckMeasurePlan != null)
            {
                BindPlan();
            }
            //基础信息
            TruckBill.C_CARSERIALNUMBER = txt_CARSERIALNUMBER.Text.Trim();
            TruckBill.C_CONTRACTNO = txt_CONTRACTNO.Text.Trim();

            TruckBill.C_PLANNO = txt_PlanNo.Text.Trim();
            TruckBill.C_CONTAINERNO = txt_containerNo.Text.Trim();
            if (cBox_PlanState.Text == "已完成")
            { TruckBill.C_PLANSTATE = PLANSTATE.已完成; }
            else if (cBox_PlanState.Text == "已作废")
            { TruckBill.C_PLANSTATE = PLANSTATE.已作废; }
            else
            { TruckBill.C_PLANSTATE = PLANSTATE.未完成; }
            TruckBill.C_SHIPPINGNOTE = txt_ShippingNote.Text.Trim();
            TruckBill.I_ISAUTO = check_IsAuto.Checked == true ? 1 : 0;
            TruckBill.I_RESERVE1 = check_IsContainer.Checked == true ? 1 : 0;
            if (radio_EnterFactory.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.进厂;
            else if (radio_OutFactory.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.出厂;
            else if (radio_Transfer.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.内倒;
            else if (radio_Tain.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.火车进厂;
            else if (radio_cgnz.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.采购内转;
            else if (radio_ndw.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.内倒_外;
            else if (radio_hcjzx.Checked == true)
                TruckBill.I_BUSINESSTYPE = BUSINESSTYPE.火车集装箱;

            if (radio_LongTerm.Checked == true)
            { TruckBill.I_PLANTYPE = PLANTYPE.长期委托; }
            else if (radio_Once.Checked == true)
            { TruckBill.I_PLANTYPE = PLANTYPE.一次委托; }

            TruckBill.C_PONDLIMIT = cBox_PondLimit.Text.Trim();

            if (radio_PiFirst.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.先皮后毛; }
            else if (radio_MaoFirst1.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.先毛后皮; }
            else if (radio_LimitPi.Checked == true)
            { TruckBill.I_WEIGHTTYPE = WEIGHTTYPE.限期皮重; }

            TruckBill.I_TARETIMELIMIT = int.Parse(Spin_TareTimeLimit.Value.ToString());
            TruckBill.C_PONDLIMIT = cBox_PondLimit.Text.Trim();
            TruckBill.C_CARNAME = cBox_CarName.Text.Trim();
            TruckBill.C_MATERIALNAME = CsTB_MaterialName.Text.Trim();
            TruckBill.C_MATERIALNO = CsTB_MaterialName.SelectKey;
            TruckBill.C_PLANLIMITTIME = CommonHelper.TimeToStr14(Convert.ToDateTime(date_PlanLimitTime.Text));
            TruckBill.C_FROMDEPTNAME = cBox_FromDeptName.Text.Trim();
            TruckBill.C_FROMSTORENAME = cBox_FromStoreName.Text.Trim();

            if (cBox_RepeatPound.Text == "毛毛皮") { TruckBill.I_REPEATPOUND = REPEATPOUND.毛毛皮; }
            else if (cBox_RepeatPound.Text == "毛毛皮皮") { TruckBill.I_REPEATPOUND = REPEATPOUND.毛毛皮皮; }
            else { TruckBill.I_REPEATPOUND = REPEATPOUND.无; }

            TruckBill.C_TODEPTNAME = cBox_ToDeptName.Text.Trim();
            TruckBill.C_TOSTORENAME = cBox_ToStoreName.Text.Trim();

            //特殊业务
            if (radio_NoMore.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.无;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (radio_MoreLoad.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.一车多装;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (radio_MoreUnload.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = ONEMORESTOCK.一车多卸;
                TruckBill.I_ONETWOPLAN = 0;
            }
            if (cBox_Ischildidenfy.Text == "母标识")
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.母标识; }
            else if (cBox_Ischildidenfy.Text == "子标识")
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.子标识; }
            else
            { TruckBill.I_ISCHILDIDENFY = ISCHILDIDENFY.正常; }


            TruckBill.I_ISCREATEMOTHERPOND = check_IsCreateMotherpond.Checked == true ? 1 : 0;
            TruckBill.C_CONNECTPLANNO = txt_ConnectPlanNo.Text.Trim();


            if (radio_TwoPlan.Checked == true)
            {
                TruckBill.I_ONEMORESTOCK = 0;
                TruckBill.I_ONETWOPLAN = 1;
            }
            TruckBill.C_MIDDLEDEPTNAME = cBox_MiddleDeptName.Text.Trim();
            TruckBill.C_MIDDLESTORENAME = cBox_MiddleStoreName.Text.Trim();


            //理重
            TruckBill.I_RETALLYKG = int.Parse(Spin_RetallyKg.Value.ToString());
            if (radio_ComputerTypeNo.Checked == true)
            { TruckBill.I_COMPUTERTYPE = 0; }
            else if (radio_ComputerTypeFix.Checked == true)
            { TruckBill.I_COMPUTERTYPE = COMPUTERTYPE.固定值; }
            else if (radio_ComputerTypePer.Checked == true)
            { TruckBill.I_COMPUTERTYPE = COMPUTERTYPE.百分比; }


            TruckBill.I_DOWNVALUE = int.Parse(Spin_DownValue.Value.ToString());
            TruckBill.I_UPVALUE = int.Parse(Spin_UpValue.Value.ToString());
            TruckBill.C_PERCENTAGE = Spin_PercenTage.Text;

            //其他
            TruckBill.C_REMARK = memo_Remark.Text.Trim();
            TruckBill.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;

            //重量信息
            TruckBill.N_TAREWGT = int.Parse(Spin_TareWgt.Value.ToString());
            TruckBill.N_GROSSWGT = int.Parse(Spin_GrossWgt.Value.ToString());
            TruckBill.N_NETWGT = int.Parse(Spin_NetWgt.Value.ToString());
            DateTime TareTime = Convert.ToDateTime(date_TareWgtTime.EditValue);


            DateTime GrossTime = Convert.ToDateTime(date_GrossWgtTime.EditValue);
            TruckBill.C_TAREWGTTIME = CommonHelper.TimeToStr14(TareTime);
            TruckBill.C_GROSSWGTTIME = CommonHelper.TimeToStr14(GrossTime);
            if (TareTime > GrossTime)
            {
                TruckBill.C_NETWGTTIME = CommonHelper.TimeToStr14(TareTime);
            }
            else
            {
                TruckBill.C_NETWGTTIME = CommonHelper.TimeToStr14(GrossTime);
            }
            TruckBill.C_TAREWGTSITENO = LookUp_TareWgtSite.EditValue == null ? "" : LookUp_TareWgtSite.EditValue.ToString();
            TruckBill.C_TAREWGTSITENAME = LookUp_TareWgtSite.Text.Trim();
            TruckBill.C_GROSSWGTSITENO = LookUp_GrossWgtSite.EditValue == null ? "" : LookUp_GrossWgtSite.EditValue.ToString();
            TruckBill.C_GROSSWGTSITENAME = LookUp_GrossWgtSite.Text.Trim();
            TruckBill.C_TAREWGTMAN = txt_TareWgtMan.Text.Trim();
            TruckBill.C_GROSSWGTMAN = txt_GrossWgtMan.Text.Trim();
            TruckBill.I_RETURNFLAG = checkEdit_ReturnFlag.Checked ? 0 : 1;
            TruckBill.I_REPEATFLAG = checkEdit_RepeatFlag.Checked ? 1 : 0;
            TruckBill.C_PONDREMARK = memo_PondRemark.Text.Trim();
            if (cBox_BillState.Text == "已完成")
            { TruckBill.C_BILLSTATE = PLANSTATE.已完成; }
            else if (cBox_BillState.Text == "已作废")
            { TruckBill.C_BILLSTATE = PLANSTATE.已作废; }
            else
            { TruckBill.C_BILLSTATE = PLANSTATE.未完成; }


            if (TruckBill.C_BILLSTATE == PLANSTATE.已作废)
            {
                TruckBill.C_PLANSTATUS = "D";
            }
            else if (TruckBill.C_UPLOADSTATUE == "Y")
            {
                TruckBill.C_PLANSTATUS = "U";
            }

            TruckBill.C_UPLOADSTATUE = "N";
            var result = MainService.ExecuteDB_UpdatePM_Bill_Truck(TruckBill);
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
        /// 验证控件不能为空
        /// </summary>
        private bool VerificatControl()
        {
            DxError.ClearErrors();
            errorProvider1.Clear();
            bool IsOk = true;

            //验证委托号是否正确
            if (string.IsNullOrEmpty(txt_PlanNo.Text.Trim()))
            {
                errorProvider1.SetError(txt_PlanNo, "此栏不能为空！");
                IsOk = false;
            }
            else
            {
                string txt = txt_PlanNo.Text;
                var TruckPlan = MainService.ExecuteDB_QueryTruckMeasurePlanByPlanNo(txt);
                if (TruckPlan == null)
                {
                    errorProvider1.SetError(txt_PlanNo, "该委托单号不存在！");
                    IsOk = false;
                }
            }

            //基础信息
            if (string.IsNullOrEmpty(CsTB_MaterialName.Text.Trim()))
            {
                errorProvider1.SetError(cBox_CarName, "此栏不能为空！");
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
                    if (string.IsNullOrEmpty(txt_ConnectPlanNo.Text.Trim()))
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
            if (string.IsNullOrEmpty(Spin_GrossWgt.Text) || MyNumberHelper.ConvertToInt32(Spin_GrossWgt.Text) == 0)
            {
                errorProvider1.SetError(Spin_GrossWgt, "毛重不能为0！");
                IsOk = false;
            }
            return IsOk;
        }


        private void RefreshPlan()
        {
            //基础信息
            txt_PlanNo.Text = TruckMeasurePlan.C_PLANNO;
            cBox_PlanState.Text = TruckMeasurePlan.C_PLANSTATE.ToString();
            txt_ShippingNote.Text = TruckMeasurePlan.C_SHIPPINGNOTE;
            txt_CARSERIALNUMBER.Text = TruckMeasurePlan.C_CARSERIALNUMBER;
            txt_CONTRACTNO.Text = TruckMeasurePlan.C_CONTRACTNO;
            txt_containerNo.Text = TruckMeasurePlan.C_CONTAINERNO;
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
            cBox_PondLimit.Text = TruckMeasurePlan.C_PONDLIMIT;
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
            cBox_PondLimit.Text = TruckMeasurePlan.C_PONDLIMIT;
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
        }

        private void PM_TruckPoundBill_Form_Shown(object sender, EventArgs e)
        {
            InitEvent();
            InitControl();

            if (TruckBill != null)
            {
                SetControlValue();
                //设置三重是否可编辑
                SetWeightUseable(false);
            }
            else
            {
                cBox_BillState.Text = "未完成";
                date_GrossWgtTime.Text = DateTime.Now.ToString();
                date_TareWgtTime.Text = DateTime.Now.ToString();
                txt_GrossWgtMan.Text = SessionHelper.LogUserNickName;
                txt_TareWgtMan.Text = SessionHelper.LogUserNickName;
                SetWeightUseable(true);
            }
        }
        private void SetControlValue()
        {
            txt_PlanNo.Text = TruckBill.C_PLANNO;
            cBox_PlanState.Text = TruckBill.C_PLANSTATE.ToString();
            txt_ShippingNote.Text = TruckBill.C_SHIPPINGNOTE;
            txt_CARSERIALNUMBER.Text = TruckBill.C_CARSERIALNUMBER;
            txt_CONTRACTNO.Text = TruckBill.C_CONTRACTNO;
            switch (TruckBill.I_BUSINESSTYPE)
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
            switch (TruckBill.I_ISAUTO)
            {
                case 0:
                    check_IsAuto.Checked = false; break;
                case 1:
                    check_IsAuto.Checked = true; break;
            }
            switch (TruckBill.I_RESERVE1)
            {
                case 0:
                    check_IsContainer.Checked = false; break;
                case 1:
                    check_IsContainer.Checked = true; break;
            }
            switch (TruckBill.I_PLANTYPE)
            {
                case PLANTYPE.长期委托:
                    radio_LongTerm.Checked = true; break;
                case PLANTYPE.一次委托:
                    radio_Once.Checked = true; break;
            }
            cBox_PondLimit.Text = TruckBill.C_PONDLIMIT;
            switch (TruckBill.I_WEIGHTTYPE)
            {
                case WEIGHTTYPE.先皮后毛:
                    radio_PiFirst.Checked = true; break;
                case WEIGHTTYPE.先毛后皮:
                    radio_MaoFirst1.Checked = true; break;
                case WEIGHTTYPE.限期皮重:
                    radio_LimitPi.Checked = true; break;
            }
            Spin_TareTimeLimit.Value = TruckBill.I_TARETIMELIMIT;
            cBox_PondLimit.Text = TruckBill.C_PONDLIMIT;
            cBox_CarName.Text = TruckBill.C_CARNAME;
            CsTB_MaterialName.Text = TruckBill.C_MATERIALNAME;
            CsTB_MaterialName.SelectKey = TruckBill.C_MATERIALNO;
            date_PlanLimitTime.Text = CommonHelper.Str14ToTimeFormart(TruckBill.C_PLANLIMITTIME); ;
            cBox_FromDeptName.Text = TruckBill.C_FROMDEPTNAME;
            cBox_FromStoreName.Text = TruckBill.C_FROMSTORENAME;
            switch (TruckBill.I_REPEATPOUND)
            {
                case REPEATPOUND.无:
                    cBox_RepeatPound.Text = "无"; break;
                case REPEATPOUND.毛毛皮:
                    cBox_RepeatPound.Text = "毛毛皮"; break;
                case REPEATPOUND.毛毛皮皮:
                    cBox_RepeatPound.Text = "毛毛皮皮"; break;
            }

            cBox_ToDeptName.Text = TruckBill.C_TODEPTNAME;
            cBox_ToStoreName.Text = TruckBill.C_TOSTORENAME;

            //特殊业务
            switch (TruckBill.I_ONEMORESTOCK)
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
            if (TruckBill.I_ONETWOPLAN == 1)
            {
                radio_TwoPlan.Checked = true;
            }
            switch (TruckBill.I_ISCHILDIDENFY)
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
            check_IsCreateMotherpond.Checked = TruckBill.I_ISCREATEMOTHERPOND == 1 ? true : false;
            txt_ConnectPlanNo.Text = TruckBill.C_CONNECTPLANNO;
            cBox_MiddleDeptName.Text = TruckBill.C_MIDDLEDEPTNAME;
            cBox_MiddleStoreName.Text = TruckBill.C_MIDDLESTORENAME;
            txt_containerNo.Text = TruckBill.C_CONTAINERNO;

            //理重

            Spin_RetallyKg.Value = TruckBill.I_RETALLYKG;
            switch (TruckBill.I_COMPUTERTYPE)
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

            Spin_DownValue.Value = TruckBill.I_DOWNVALUE;
            Spin_UpValue.Value = TruckBill.I_UPVALUE;
            Spin_PercenTage.Text = TruckBill.C_PERCENTAGE;

            //其他
            memo_Remark.Text = TruckBill.C_REMARK;

            //磅单信息
            txt_WgtlistNo.Text = TruckBill.C_WGTLISTNO;
            txt_BarcodeNo.Text = TruckBill.C_BARCODENO;
            Spin_TareWgt.Value = TruckBill.N_TAREWGT;
            Spin_GrossWgt.Value = TruckBill.N_GROSSWGT;
            Spin_NetWgt.Value = TruckBill.N_NETWGT;
            LookUp_TareWgtSite.EditValue = TruckBill.C_TAREWGTSITENO;
            LookUp_GrossWgtSite.EditValue = TruckBill.C_GROSSWGTSITENO;
            txt_TareWgtMan.Text = TruckBill.C_TAREWGTMAN;
            date_GrossWgtTime.Text = CommonHelper.Str14ToTimeFormart(TruckBill.C_GROSSWGTTIME);
            date_TareWgtTime.Text = CommonHelper.Str14ToTimeFormart(TruckBill.C_TAREWGTTIME);
            txt_GrossWgtMan.Text = TruckBill.C_GROSSWGTMAN;
            checkEdit_ReturnFlag.Checked = (TruckBill.I_RETURNFLAG == 0);
            checkEdit_RepeatFlag.Checked = (TruckBill.I_REPEATFLAG == 1);
            memo_PondRemark.Text = TruckBill.C_PONDREMARK;
            if (TruckBill.C_BILLSTATE == PLANSTATE.已完成)
            { cBox_BillState.Text = "已完成"; }
            else if (TruckBill.C_BILLSTATE == PLANSTATE.已作废)
            { cBox_BillState.Text = "已作废"; }
            else
            { cBox_BillState.Text = "未完成"; }
        }

        private void txt_PlanNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                string txt = txt_PlanNo.Text;
                if (string.IsNullOrEmpty(txt))
                    return;

                TruckMeasurePlan = MainService.ExecuteDB_QueryTruckMeasurePlanByPlanNo(txt);
                if (TruckMeasurePlan == null)
                {
                    MessageDxUtil.ShowTips("未获取到该单号对应的委托！");
                }
                else
                {
                    RefreshPlan();
                }
            }
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

        private void Spin_GrossWgt_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetWeight();
        }

        private void Spin_TareWgt_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetWeight();
        }
        private void CalcNetWeight()
        {
            if (Spin_GrossWgt.Value == 0 || Spin_TareWgt.Value == 0)
            {
                Spin_NetWgt.Value = 0;
            }
            else
            {
                Spin_NetWgt.Value = Spin_GrossWgt.Value - Spin_TareWgt.Value;
            }

        }

        private void SetWeightUseable(bool flag)
        {
            if (flag)
            {
                //Spin_GrossWgt.Enabled = true;
                //Spin_TareWgt.Enabled = true;
                btn_ResetTare.Visible = false;
            }
            else
            {
                //Spin_GrossWgt.Enabled = false;
                //Spin_TareWgt.Enabled = false;
                btn_ResetTare.Visible = true;
            }

        }
        //重新回皮  
        private void btn_ResetTare_Click(object sender, EventArgs e)
        {
            //清空皮重相关信息，修改委托状态为未完成
            Spin_TareWgt.Value = 0;
            LookUp_TareWgtSite.Text = "";
            LookUp_TareWgtSite.EditValue = null;
            date_TareWgtTime.EditValue = null;
            //date_TareWgtTime.Text = "";                 
            txt_TareWgtMan.Text = "";
            if (radio_LongTerm.Checked == false)
            {
                cBox_BillState.Text = "未完成";
            }            
        }
       

        private void Spin_TareWgt_DoubleClick(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("请输入密码", "密码验证", "");
            if (result != null)
            {
                if (result.ToString().Trim() == "sb2022301")
                {
                    Spin_TareWgt.Properties.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }           
        }

        private void Spin_GrossWgt_Click(object sender, EventArgs e)
        {
            if (TruckBill == null)
            {
                Spin_GrossWgt.Properties.ReadOnly = false;
            }
        }

        private void Spin_TareWgt_Click(object sender, EventArgs e)
        {
            if (TruckBill == null)
            {
                Spin_TareWgt.Properties.ReadOnly = false;
            }
        }


    }
}
