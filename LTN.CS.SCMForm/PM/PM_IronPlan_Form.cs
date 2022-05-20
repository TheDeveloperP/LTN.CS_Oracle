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
    
    public partial class PM_IronPlan_Form : CoreForm
    {
        #region 实例变量
        public PM_Bill_Iron SelectMainEntity { get; set; }
        //public ISM_Department_LevelTwo_InfoService departmentTwoService { get; set; }
        public IPM_Bill_IronService MainService { get; set; }
        #endregion

        #region 构造函数
        public PM_IronPlan_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 设定主档编辑区
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(PM_Bill_Iron entity)
        {
            if (entity != null)
            {
                txt_PlanNo.Text = entity.PlanNo;
                txt_HeatNo.Text = entity.HeatNo;
                txt_BatchNo.Text = entity.BatchNo;
                txt_LronNo.Text = entity.LronNo;
                txt_TankNo.Text = entity.TankNo;
                txt_ToDept.Text = entity.ToDeptName;
                if (entity.BillStatus != null)
                {
                    lue_BillStatus.EditValue = entity.BillStatus.IntValue;
                }
                else
                {
                    lue_BillStatus.EditValue = null;
                }
                txt_Remark.Text = entity.Remark;
            }
        }

        private void setDataSource()
        {
            lue_BillStatus.Properties.DataSource = BillStatusObj.GetBillStatusData();
            //sle_ToDept.Properties.DataSource = departmentTwoService.ExecuteDB_QueryAll();
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSelectMainEntity()
        {
            if (SelectMainEntity==null)
            {
                SelectMainEntity = new PM_Bill_Iron();
                SelectMainEntity.ToDeptNo = "";
                SelectMainEntity.CreateUserName = SessionHelper.LogUserNickName;
            }
            SelectMainEntity.HeatNo = txt_HeatNo.Text;
            SelectMainEntity.BatchNo = txt_BatchNo.Text;
            SelectMainEntity.LronNo = txt_LronNo.Text;
            SelectMainEntity.TankNo = txt_TankNo.Text;
            //SelectMainEntity.ToDeptNo = "";
            SelectMainEntity.ToDeptName = txt_ToDept.Text;
            if (lue_BillStatus.EditValue != null)
            {
                SelectMainEntity.BillStatus = new BillStatusObj() { IntValue = (int)lue_BillStatus.EditValue };
            }
            SelectMainEntity.Remark = txt_Remark.Text;
            SelectMainEntity.CReserve1 = null;
            SelectMainEntity.CReserve2 = null;
            SelectMainEntity.CReserve3 = null;
            SelectMainEntity.IReserve1 = 0;
            SelectMainEntity.IReserve2 = 0;
            SelectMainEntity.IReserve3 = 0;
            SelectMainEntity.UpdateUserName = SessionHelper.LogUserNickName;

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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        #endregion

        #region 控件事件
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (SelectMainEntity==null)
            {
                CustomMainInsert(null,null);
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
       

        private void PM_IronPlan_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();
            if (SelectMainEntity!=null)
            {
                SetMainEditer(SelectMainEntity);
            }
            else
            {
                lue_BillStatus.EditValue = (int)BillStatus.NoMeasure;
            }
        }
        #endregion
    }
}
