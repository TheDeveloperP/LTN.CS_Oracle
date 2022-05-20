using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PondInfo_Form : CoreForm
    {
        #region 实例变量
        public PM_Pond_Bill_Iron SelectMainEntity { get; set; }
        private PM_Bill_Iron bill { get; set; }
        //public ISM_Department_LevelTwo_InfoService departmentTwoService { get; set; }
        public IPM_Pond_Bill_IronService MainService { get; set; }
        public IPM_Bill_IronService billService { get; set; }
        //public ISM_PoundSite_InfoService siteService { get; set; }

        #endregion

        #region 构造函数
        public PM_PondInfo_Form()
        {
            InitializeComponent();
        }
        #endregion
        #region 自定义方法
        /// <summary>
        /// 设定主档编辑区
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(PM_Pond_Bill_Iron entity)
        {
            if (entity != null)
            {
                sle_PlanNo.EditValue = entity.PlanNo;
                txt_HeatNo.Text = entity.HeatNo;
                txt_BatchNo.Text = entity.BatchNo;
                txt_LronNo.Text = entity.LronNo;
                txt_TankNo.EditValue = entity.TankNo;
                txt_ToDept.Text = entity.ToDeptName;
                txt_Remark.Text = entity.Remark;
                txt_WgtlistNo.Text = entity.WgtlistNo;
                txt_GrossWgt.Text = entity.GrossWgt.ToString() ;
                txt_TareWgt.Text = entity.TareWgt.ToString();
                txt_NetWgt.Text = entity.NetWgt.ToString();
                txt_GrossWgtSite.Text = entity.GrossWgtSiteName;
                txt_TareWgtSite.Text = entity.TareWgtSiteName;
                dte_GrossWgtTime.Text = string.IsNullOrEmpty(entity.GrossWgtTime)?"":Convert.ToDateTime(entity.GrossWgtTime).ToString("yyyy-MM-dd HH:mm:ss");
                dte_TareWgtTime.Text = string.IsNullOrEmpty(entity.TareWgtTime)?"": Convert.ToDateTime(entity.TareWgtTime).ToString("yyyy-MM-dd HH:mm:ss");
                txt_GrossWgtMan.Text = entity.GrossWgtMan;
                txt_TareWgtMan.Text = entity.TareWgtMan;
                txt_PondRemark.Text = entity.PondRemark;
            }
        }

        private void setDataSource()
        {
            //lue_GrossWgtSiteName.Properties.DataSource = siteService.ExecuteDB_QueryAll();
            //lue_TareWgtSiteName.Properties.DataSource = siteService.ExecuteDB_QueryAll();
            //sle_PlanNo.Properties.DataSource = billService.ExecuteDB_QueryAll();
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSelectMainEntity()
        {
            bill = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == sle_PlanNo.Text).FirstOrDefault();
            if (SelectMainEntity == null)
            {
                SelectMainEntity = new PM_Pond_Bill_Iron();
                SelectMainEntity.CreateUser = SessionHelper.LogUserNickName;

                SelectMainEntity.ToDeptNo = "";
            }
            SelectMainEntity.PlanStatus = "I";
            if (SelectMainEntity.UpLoadStatus=="Y")
            {
                SelectMainEntity.PlanStatus = "U";
            }
            SelectMainEntity.UpLoadStatus = "N";
            SelectMainEntity.PlanNo = sle_PlanNo.Text;
            SelectMainEntity.HeatNo = txt_HeatNo.Text;
            SelectMainEntity.BatchNo = txt_BatchNo.Text;
            SelectMainEntity.LronNo = txt_LronNo.Text;
            SelectMainEntity.TankNo = txt_TankNo.Text;
            SelectMainEntity.ToDeptName = txt_ToDept.Text;
            SelectMainEntity.Remark = txt_Remark.Text;
            SelectMainEntity.GrossWgt = Convert.ToDecimal(txt_GrossWgt.Text);
            SelectMainEntity.TareWgt = Convert.ToDecimal(txt_TareWgt.Text);
            SelectMainEntity.TareWgt1 = 0;
            SelectMainEntity.NetWgt = Convert.ToDecimal(txt_NetWgt.Text);
            SelectMainEntity.NetWgt1 = 0;
            SelectMainEntity.SlagNum = 0;
            SelectMainEntity.NetWgt2 = SelectMainEntity.NetWgt - SelectMainEntity.SlagNum;
            DateTime GrossWgtTime = Convert.ToDateTime(dte_GrossWgtTime.Text);
            DateTime TareWgtTime = Convert.ToDateTime(dte_TareWgtTime.Text);
            SelectMainEntity.GrossWgtTime = GrossWgtTime.ToString("yyyyMMddHHmmss");
            SelectMainEntity.TareWgtTime = TareWgtTime.ToString("yyyyMMddHHmmss");
            SelectMainEntity.TrainGroupGross = dte_GrossWgtTime.Text;
            SelectMainEntity.TrainGroupTare = dte_TareWgtTime.Text;
            SelectMainEntity.GrossWgtSiteName = txt_GrossWgtSite.Text;
            SelectMainEntity.GrossWgtSiteNo = "";
            SelectMainEntity.TareWgtSiteNo = "";
            SelectMainEntity.TareWgtSiteName = txt_TareWgtSite.Text;
            SelectMainEntity.GrossWgtMan = txt_GrossWgtMan.Text;
            SelectMainEntity.TareWgtMan = txt_TareWgtMan.Text;
            SelectMainEntity.PondRemark = txt_PondRemark.Text;
            if (bill!=null)
            {
                SelectMainEntity.PlanCreateUser = bill.CreateUserName;
                SelectMainEntity.PlanCreateTime = bill.CreateTime;
            }
            SelectMainEntity.CReserve1 = null;
            SelectMainEntity.CReserve2 = null;
            SelectMainEntity.CReserve3 = null;
            SelectMainEntity.IReserve1 = 0;
            SelectMainEntity.IReserve2 = 0;
            SelectMainEntity.IReserve3 = 0;
            SelectMainEntity.CReserveFlag1 = null;
            SelectMainEntity.CReserveFlag2 = null;
            SelectMainEntity.CReserveFlag3 = null;
            SelectMainEntity.IReserveFlag1 = 0;
            SelectMainEntity.IReserveFlag2 = 0;
            SelectMainEntity.IReserveFlag3 = 0;
            SelectMainEntity.DataFlag = new EntityInt(1);
            SelectMainEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            SelectMainEntity.UpdateUser = SessionHelper.LogUserNickName;


        }
        /// <summary>
        /// 自定义新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();

                var rs = MainService.ExecuteDB_InsertIronInfo(SelectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    bill.PlanNo = sle_PlanNo.Text;
                    bill.HeatNo = txt_HeatNo.Text;
                    bill.BatchNo = txt_BatchNo.Text;
                    bill.LronNo = txt_LronNo.Text;
                    bill.ToDeptName = txt_ToDept.Text;
                    bill.TankNo = txt_TankNo.Text;
                    bill.Remark = txt_Remark.Text;
                    bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                    bill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    bill.UpdateUserName = SessionHelper.LogUserNickName;
                    var rss = billService.ExecuteDB_UpdateIronInfo(bill);
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// 自定义修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                var rs = MainService.ExecuteDB_UpdateIronInfo(SelectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    bill.PlanNo = sle_PlanNo.Text;
                    bill.HeatNo = txt_HeatNo.Text;
                    bill.BatchNo = txt_BatchNo.Text;
                    bill.LronNo = txt_LronNo.Text;
                    bill.ToDeptName = txt_ToDept.Text;
                    bill.TankNo = txt_TankNo.Text;
                    bill.Remark = txt_Remark.Text;
                    bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                    bill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    bill.UpdateUserName = SessionHelper.LogUserNickName;
                    var rss = billService.ExecuteDB_UpdateIronInfo(bill);
                }
               
                this.Close();
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        #endregion

        private void sle_PlanNo_EditValueChanged(object sender, EventArgs e)
        {
            bill = new PM_Bill_Iron();
            if (sle_PlanNo.EditValue != null)
            {
                string planno = sle_PlanNo.EditValue.ToString();
                bill = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == planno).FirstOrDefault();
                if (bill != null)
                {
                    txt_HeatNo.Text = bill.HeatNo;
                    txt_LronNo.Text = bill.LronNo;
                    txt_ToDept.Text  = bill.ToDeptName;
                    txt_BatchNo.Text = bill.BatchNo;
                    txt_TankNo.Text = bill.TankNo;
                    txt_Remark.Text = bill.Remark;
                }
                else
                {
                    txt_HeatNo.Text = null;
                    txt_LronNo.Text = null;
                    txt_ToDept.Text = null;
                    txt_BatchNo.Text = null;
                    txt_TankNo.Text = null;
                    txt_Remark.Text = null;
                }
            }
        }

        private void PM_PondInfo_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();
            if (SelectMainEntity != null)
            {
                SetMainEditer(SelectMainEntity);
            }
            else
            {
                txt_GrossWgtMan.Text = SessionHelper.LogUserNickName;
                txt_TareWgtMan.Text = SessionHelper.LogUserNickName;
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (SelectMainEntity == null)
            {
                CustomMainInsert(null, null);
            }
            else
            {
                CustomMainUpdate(null, null);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sle_PlanNo_KeyUp(object sender, KeyEventArgs e)
        {

           if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                string txt = sle_PlanNo.Text;
                if (string.IsNullOrEmpty(txt))
                    return;
                var rs = billService.ExecuteDB_QueryIronByPlan(txt);
                if (rs.Count == 0)
                {
                    MessageDxUtil.ShowTips("未获取到该单号对应的委托！");
                }
                else
                {
                    bill = rs.FirstOrDefault();
                    txt_HeatNo.Text = bill.HeatNo;
                    txt_BatchNo.Text = bill.BatchNo;
                    txt_LronNo.Text = bill.LronNo;
                    //bill.ToDeptNo = "";
                    txt_ToDept.Text = bill.ToDeptName;
                    txt_TankNo.Text = bill.TankNo;
                    txt_Remark.Text = bill.Remark;
                    //bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                }
            }
        }
    }
}
