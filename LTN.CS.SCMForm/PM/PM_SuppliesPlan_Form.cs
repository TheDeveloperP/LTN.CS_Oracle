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
    public partial class PM_SuppliesPlan_Form : CoreForm
    {
        #region 实例变量
        public PM_Bill_Supplies SelectMainEntity { get; set; }
        public IPM_Bill_SuppliesService MainService { get; set; }
        public List<string> Ponds { get; set; }
        #endregion

        #region 构造函数
        public PM_SuppliesPlan_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 设定主档编辑区
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(PM_Bill_Supplies entity)
        {
            if (entity != null)
            {
                txt_PlanNo.Text = entity.PlanNo;
                txt_WagNo.Text = entity.WagNo;
                txt_ShipNo.Text = entity.ShipNo;
                txt_FromStation.Text = entity.FromStation;
                txt_SerialNo.Text = entity.SerialNo;
                txt_DeliveryNo.Text = entity.DeliveryNo;
                txt_ContractNo.Text = entity.ContractNo;
                txt_ProjectNo.Text = entity.ProjectNo;
                txt_WayBillNo.Text = entity.WayBillNo;
                txt_MarshallingNo.Text = entity.MarshallingNo;
                txt_PondLimit.Text = entity.PondLimit;
                txt_Remark.Text = entity.Remark;
                if (!string.IsNullOrEmpty(entity.PlanLimitTime))
                {
                    DateTime time = Convert.ToDateTime(entity.PlanLimitTime);
                    dte_PlanLimitTime.Text = time.ToString();
                }
                if (entity.BusinessType != null)
                {
                    lue_BusinessType.EditValue = entity.BusinessType.IntValue;
                }
                else
                {
                    lue_BusinessType.EditValue = null;
                }
                if (entity.WeightType != null)
                {
                    lue_WeightType.EditValue = entity.WeightType.IntValue;
                }
                else
                {
                    lue_WeightType.EditValue = null;
                }
                if (entity.TareType != null)
                {
                    lue_TareType.EditValue = entity.TareType.IntValue;
                }
                else
                {
                    lue_TareType.EditValue = null;
                }
                if (entity.MoveStillType != null)
                {
                    lue_MoveStillType.EditValue = entity.MoveStillType.IntValue;
                }
                else
                {
                    lue_MoveStillType.EditValue = null;
                }
                if (entity.BillStatus != null)
                {
                    lue_BillStatus.EditValue = entity.BillStatus.IntValue;
                }
                else
                {
                    lue_BillStatus.EditValue = null;
                }
                txt_FromDept.Text = entity.FromDeptName;
                txt_ToDept.Text = entity.ToDeptName;
                txt_FromStore.Text = entity.FromStoreName;
                txt_ToStore.Text = entity.ToStoreName;
                txt_Material.Text = entity.MaterialName;
                
            }
        }
          private void setDataSource()
        {
            lue_BillStatus.Properties.DataSource = BillStatusObj.GetBillStatusData();
            lue_BusinessType.Properties.DataSource = BusinessTypesObj.GetBusinessTypesData();
            lue_WeightType.Properties.DataSource = WeightTypesObj.GetWeightTypesData();
            lue_TareType.Properties.DataSource = TareTypeObj.GetTareTypeData();
            lue_MoveStillType.Properties.DataSource = MoveStillTypeObj.GetMoveStillTypeData();
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
                SelectMainEntity = new PM_Bill_Supplies();
                SelectMainEntity.CreateUser = SessionHelper.LogUserNickName;
            }
            SelectMainEntity.WagNo = txt_WagNo.Text;
            SelectMainEntity.ShipNo = txt_ShipNo.Text;
            SelectMainEntity.FromStation = txt_FromStation.Text;
            SelectMainEntity.SerialNo = txt_SerialNo.Text;
            SelectMainEntity.DeliveryNo = txt_DeliveryNo.Text;
            SelectMainEntity.ContractNo = txt_ContractNo.Text;
            SelectMainEntity.ProjectNo = txt_ProjectNo.Text;
            SelectMainEntity.WayBillNo = txt_WayBillNo.Text;
            SelectMainEntity.MarshallingNo = txt_MarshallingNo.Text;
            SelectMainEntity.PondLimit = txt_PondLimit.Text;
            //SelectMainEntity.MaterialNo = "";
            SelectMainEntity.MaterialName = txt_Material.Text;
            //SelectMainEntity.FromDeptNo = "";
            SelectMainEntity.FromDeptName = txt_FromDept.Text;
            //SelectMainEntity.FromStoreNo = "";
            SelectMainEntity.FromStoreName = txt_FromStore.Text;
            //SelectMainEntity.ToDeptNo = "";
            SelectMainEntity.ToDeptName = txt_ToDept.Text;
            //SelectMainEntity.ToStoreNo = "";
            SelectMainEntity.ToStoreName = txt_ToStore.Text;
            if (dte_PlanLimitTime.Text != string.Empty) 
            {
                DateTime LimitTime = Convert.ToDateTime(dte_PlanLimitTime.Text);
                SelectMainEntity.PlanLimitTime = LimitTime.ToString("yyyyMMddHHmmss");
            }
           
            if (lue_BillStatus.EditValue!=null)
            {
                SelectMainEntity.BillStatus = new BillStatusObj() { IntValue = (int)lue_BillStatus.EditValue };
            }
            if (lue_BusinessType.EditValue!=null)
            {
                SelectMainEntity.BusinessType = new BusinessTypesObj() { IntValue = (int)lue_BusinessType.EditValue };
            }
            if (lue_WeightType.EditValue != null)
            {
                SelectMainEntity.WeightType = new WeightTypesObj() { IntValue = (int)lue_WeightType.EditValue };
            }
            if (lue_MoveStillType.EditValue != null)
            {
                SelectMainEntity.MoveStillType = new MoveStillTypeObj() { IntValue = (int)lue_MoveStillType.EditValue };
            }
            if (lue_TareType.EditValue != null)
            {
                SelectMainEntity.TareType = new TareTypeObj() { IntValue = (int)lue_TareType.EditValue };
            }
            SelectMainEntity.Remark = txt_Remark.Text;
            /*
            SelectMainEntity.CReserve1 = null;
            SelectMainEntity.CReserve2 = null;
            SelectMainEntity.CReserve3 = null;
            SelectMainEntity.IReserve1 = 0;
            SelectMainEntity.IReserve2 = 0;
            SelectMainEntity.IReserve3 = 0;
            */
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
                var rs = MainService.ExecuteDB_InsertSuppliesInfo(SelectMainEntity);
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
                var rs = MainService.ExecuteDB_UpdateSuppliesInfo(SelectMainEntity);
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

        private void PM_SuppliesPlan_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();
            if (SelectMainEntity != null)
            {
                SetMainEditer(SelectMainEntity);
            }
            else
            {
                lue_BillStatus.EditValue = (int)BillStatus.NoMeasure;
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
    }
}
