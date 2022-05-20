using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMEntities.CS;
using LTN.CS.SCMForm.API;
using DevExpress.XtraEditors;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PondSupplies_Form : CoreForm
    {
        #region 实例变量
        public PM_Pond_Bill_Supplies SelectMainEntity { get; set; }
        private PM_Bill_Supplies bill { get; set; }
        public IPM_Pond_Bill_SuppliesService MainService { get; set; }
        public IPM_Bill_SuppliesService billService { get; set; }
        public ISM_GczTare_InfoService gczService { get; set; }
        public string strDrass = string.Empty;

        #endregion

        #region 构造函数
        public PM_PondSupplies_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 设定主档编辑区  看是否在这里进行磅点编号的设置
        /// </summary>
        /// <param name="bill"></param>
        private void SetMainEditer(PM_Pond_Bill_Supplies bill)
        {
            if (bill != null)
            {
                sle_PlanNo.EditValue = bill.PlanNo;
                txt_WagNo.Text = bill.WagNo;
                txt_ShipNo.Text = bill.ShipNo;
                txt_FromStation.Text = bill.FromStation;
                txt_SerialNo.Text = bill.SerialNo;
                txt_DeliveryNo.Text = bill.DeliveryNo;
                txt_ContractNo.Text = bill.ContractNo;
                txt_ProjectNo.Text = bill.ProjectNo;
                txt_WayBillNo.Text = bill.WayBillNo;
                txt_MarshallingNo.Text = bill.MarshallingNo;
                txt_PondLimit.Text = bill.PondLimit;
                txt_Remark.Text = bill.Remark;
                if (!string.IsNullOrEmpty(bill.PlanLimitTime))
                {
                    DateTime time = Convert.ToDateTime(bill.PlanLimitTime);
                    dte_PlanLimitTime.Text = time.ToString();
                }
                if (bill.BusinessType != null)
                {
                    lue_BusinessType.EditValue = bill.BusinessType.IntValue;
                }
                else
                {
                    lue_BusinessType.EditValue = null;
                }
                if (bill.WeightType != null)
                {
                    lue_WeightType.EditValue = bill.WeightType.IntValue;
                }
                else
                {
                    lue_WeightType.EditValue = null;
                }
                if (bill.TareType != null)
                {
                    lue_TareType.EditValue = bill.TareType.IntValue;
                }
                else
                {
                    lue_TareType.EditValue = null;
                }
                if (bill.MoveStillType != null)
                {
                    lue_MoveStillType.EditValue = bill.MoveStillType.IntValue;
                }
                else
                {
                    lue_MoveStillType.EditValue = null;
                }
                txt_FromDept.Text = bill.FromDeptName;
                txt_ToDept.Text = bill.ToDeptName;
                txt_FromStore.Text = bill.FromStoreName;
                txt_ToStore.Text = bill.ToStoreName;
                txt_Material.Text = bill.MaterialName;
                txt_Remark.Text = bill.Remark;
                txt_WgtlistNo.Text = bill.WgtlistNo;
                txt_GrossWgt.Text = bill.GrossWgt.ToString();
                txt_TareWgt.Text = bill.TareWgt.ToString();
                txt_NetWgt.Text = bill.NetWgt.ToString();
                txt_GrossWgtSite.Text = bill.GrossWgtSiteName;
                txt_TareWgtSite.Text = bill.TareWgtSiteName;
                dte_GrossWgtTime.Text = string.IsNullOrEmpty(bill.GrossWgtTime) ? "" : Convert.ToDateTime(bill.GrossWgtTime).ToString("yyyy-MM-dd HH:mm:ss");
                dte_TareWgtTime.Text = string.IsNullOrEmpty(bill.TareWgtTime) ? "" : Convert.ToDateTime(bill.TareWgtTime).ToString("yyyy-MM-dd HH:mm:ss");
                txt_GrossWgtMan.Text = bill.GrossWgtMan;
                txt_TareWgtMan.Text = bill.TareWgtMan;
                txt_PondRemark.Text = bill.PondRemark;
            }
        }

        private void setDataSource()
        {
            lue_BusinessType.Properties.DataSource = BusinessTypesObj.GetBusinessTypesData();
            lue_WeightType.Properties.DataSource = WeightTypesObj.GetWeightTypesData();
            lue_TareType.Properties.DataSource = TareTypeObj.GetTareTypeData();
            lue_MoveStillType.Properties.DataSource = MoveStillTypeObj.GetMoveStillTypeData();
            //sle_PlanNo.Properties.DataSource = billService.ExecuteDB_QueryAll();
        }
        /// <summary>
        /// 用户自定义添加     在这里进行修改即可，因为物资轨道衡动轨的磅单形成最终都要经过这一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private Boolean ResetSelectMainEntity()
        {
            Boolean flag = false;
            if (SelectMainEntity == null)
            {
                SelectMainEntity = new PM_Pond_Bill_Supplies();
                SelectMainEntity.CreateUser = SessionHelper.LogUserNickName;
                setBillInfo(bill);
            }            
            SelectMainEntity.PlanStatus = "I";
            if (SelectMainEntity.UpLoadStatus == "Y")
            {
                SelectMainEntity.PlanStatus = "U";
            }
            SelectMainEntity.UpLoadStatus = "N";            

            SelectMainEntity.PlanNo = sle_PlanNo.Text;
            //新增，根据planno 查询委托信息，赋值 物料编码、来源库号编码、去向库号编码、来源单位编码、去向单位编码等
            //PM_Bill_Supplies suppliesPlan = billService.ExecuteDB_QuerySuppliesByPlan(SelectMainEntity.PlanNo).FirstOrDefault();            
            PM_Bill_Supplies suppliesPlan = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == SelectMainEntity.PlanNo).FirstOrDefault();                        
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


            SelectMainEntity.MaterialName = txt_Material.Text;
            SelectMainEntity.FromDeptName = txt_FromDept.Text;
            SelectMainEntity.FromStoreName = txt_FromStore.Text;
            SelectMainEntity.ToDeptName = txt_ToDept.Text;
            SelectMainEntity.ToStoreName = txt_ToStore.Text;

            /*
            SelectMainEntity.MaterialNo = string.IsNullOrEmpty(suppliesPlan.MaterialNo) ? "" : suppliesPlan.MaterialNo;
            SelectMainEntity.FromDeptNo = string.IsNullOrEmpty(suppliesPlan.FromDeptNo) ? "" : suppliesPlan.FromDeptNo;   
            SelectMainEntity.FromStoreNo = string.IsNullOrEmpty(suppliesPlan.FromStoreNo) ? "" : suppliesPlan.FromStoreNo;
            SelectMainEntity.ToDeptNo = string.IsNullOrEmpty(suppliesPlan.ToDeptNo) ? "" : suppliesPlan.ToDeptNo;
            SelectMainEntity.ToStoreNo = string.IsNullOrEmpty(suppliesPlan.ToStoreNo) ? "" : suppliesPlan.ToStoreNo;
            */
            

            DateTime LimitTime = Convert.ToDateTime(dte_PlanLimitTime.Text);
            SelectMainEntity.PlanLimitTime = LimitTime.ToString("yyyyMMddHHmmss");
            if (lue_BusinessType.EditValue != null)
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
            SelectMainEntity.GrossWgt = Convert.ToDecimal(txt_GrossWgt.Text);
            SelectMainEntity.TareWgt = Convert.ToDecimal(txt_TareWgt.Text);
            SelectMainEntity.NetWgt = Convert.ToDecimal(txt_NetWgt.Text);

            if (SelectMainEntity.GrossWgt != 0)
            {
                if (dte_GrossWgtTime.EditValue == null || string.IsNullOrEmpty(dte_GrossWgtTime.EditValue.ToString()))
                {
                    MessageBox.Show("请选择毛重时间", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return flag;
                }
                else
                {
                    DateTime GrossWgtTime = Convert.ToDateTime(dte_GrossWgtTime.EditValue);
                    SelectMainEntity.GrossWgtTime = CommonHelper.TimeToStr14(GrossWgtTime);
                }
            }
            else
            {
                SelectMainEntity.GrossWgtTime = string.Empty;
            }

            if (SelectMainEntity.TareWgt != 0)
            {
                if (dte_TareWgtTime.EditValue == null || string.IsNullOrEmpty(dte_TareWgtTime.EditValue.ToString()))
                {
                    MessageBox.Show("请选择皮重时间", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return flag;
                }
                else
                {
                    DateTime TareWgtTime = Convert.ToDateTime(dte_TareWgtTime.EditValue);
                    SelectMainEntity.TareWgtTime = CommonHelper.TimeToStr14(TareWgtTime);
                }
            }
            else
            {
                SelectMainEntity.TareWgtTime = string.Empty;
            }                                                           
            SelectMainEntity.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");            
            SelectMainEntity.GrossWgtSiteName = txt_GrossWgtSite.Text;
            

            //修改  由于combobox没有配置值，所以需要手动配置
            if (!string.IsNullOrEmpty(txt_GrossWgtSite.Text))
            {
                switch (txt_GrossWgtSite.Text)
                {
                    case "钢厂站":
                        SelectMainEntity.GrossWgtSiteNo = "401";
                        break;
                    case "综合站":
                        SelectMainEntity.GrossWgtSiteNo = "402";
                        break;
                    case "成品1静态轨道衡":
                        SelectMainEntity.GrossWgtSiteNo = "501";
                        break;
                    case "成品2静态轨道衡":
                        SelectMainEntity.GrossWgtSiteNo = "502";
                        break;
                }
            }
            else
            {
                SelectMainEntity.GrossWgtSiteNo = "";
            }
            //SelectMainEntity.GrossWgtSiteNo = "";            
            //SelectMainEntity.TareWgtSiteNo = "";

            SelectMainEntity.TareWgtSiteName = txt_TareWgtSite.Text;

            if (!string.IsNullOrEmpty(txt_TareWgtSite.Text))
            {
                switch (txt_TareWgtSite.Text)
                {
                    case "钢厂站":
                        SelectMainEntity.TareWgtSiteNo = "401";
                        break;
                    case "综合站":
                        SelectMainEntity.TareWgtSiteNo = "402";
                        break;
                    case "成品1静态轨道衡":
                        SelectMainEntity.TareWgtSiteNo = "501";
                        break;
                     
                    case "成品2静态轨道衡":
                        SelectMainEntity.TareWgtSiteNo = "502";
                        break;
                }
            }
            else
            {
                SelectMainEntity.TareWgtSiteNo = "";
            }


            SelectMainEntity.GrossWgtMan = txt_GrossWgtMan.Text;
            SelectMainEntity.TareWgtMan = txt_TareWgtMan.Text;
            //这两个字段赋值有问题，需修改
            //SelectMainEntity.TrainGroupGross = dte_GrossWgtTime.Text;
            //SelectMainEntity.TrainGroupTare = dte_TareWgtTime.Text;
            
            SelectMainEntity.PondRemark = txt_PondRemark.Text;
            /*
            SelectMainEntity.PlanCreateUser = bill.CreateUser;
            SelectMainEntity.PlanCreateTime = bill.CreateTime;    
            */
            /*
            if (bill != null)
            {
                SelectMainEntity.CReserve1 = bill.CReserve1;
                SelectMainEntity.CReserve2 = bill.CReserve2;
                SelectMainEntity.CReserve3 = bill.CReserve3;
            }
            
           
            SelectMainEntity.PlanCreateUser = suppliesPlan.CreateUser;
            SelectMainEntity.PlanCreateTime = suppliesPlan.CreateTime;
            */
            /*
            SelectMainEntity.CReserve1 = suppliesPlan.CReserve1;
            SelectMainEntity.CReserve2 = suppliesPlan.CReserve2;
            SelectMainEntity.CReserve3 = suppliesPlan.CReserve3;
            */       
            /*
            SelectMainEntity.IReserve1 = 0;
            SelectMainEntity.IReserve2 = 0;
            SelectMainEntity.IReserve3 = 0;
            */
            SelectMainEntity.CReserveFlag1 = null;
            SelectMainEntity.CReserveFlag2 = null;
            SelectMainEntity.CReserveFlag3 = null;
            SelectMainEntity.IReserveFlag1 = 0;
            SelectMainEntity.IReserveFlag2 = 0;
            SelectMainEntity.IReserveFlag3 = 0;
            SelectMainEntity.DataFlag = new EntityInt(1);
            
            if (Convert.ToDouble(txt_GrossWgt.Text) > 0 && Convert.ToDouble(txt_TareWgt.Text) > 0 && Convert.ToDouble(txt_NetWgt.Text) > 0)
            {
                SelectMainEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            }
            else
            {
                SelectMainEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
            }

          
            /*
            if (txt_NetWgt.Text == "0")
            {
                SelectMainEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
            }
            else
            {
                SelectMainEntity.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            }
            */
            SelectMainEntity.UpdateUser = SessionHelper.LogUserNickName;
            flag = true;
            return flag;

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
                Boolean flag = ResetSelectMainEntity();
                if (flag == true)
                {
                    var rs = MainService.ExecuteDB_InsertSuppliesInfo(SelectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        UpdateBill(bill);
                    }
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void UpdateBill(PM_Bill_Supplies bill)
        {
            //bill.PlanNo = sle_PlanNo.Text;
            //bill.WagNo = txt_WagNo.Text;
            //bill.ShipNo = txt_ShipNo.Text;
            //bill.FromStation = txt_FromStation.Text;
            //bill.SerialNo = txt_SerialNo.Text;
            //bill.DeliveryNo = txt_DeliveryNo.Text;
            //bill.ContractNo = txt_ContractNo.Text;
            //bill.ProjectNo = txt_ProjectNo.Text;
            //bill.WayBillNo = txt_WayBillNo.Text;
            //bill.MarshallingNo = txt_MarshallingNo.Text;
            //bill.PondLimit = txt_PondLimit.Text;
            //bill.MaterialNo = "";
            //bill.MaterialName = txt_Material.Text;
            //bill.FromDeptNo = "";
            //bill.FromDeptName = txt_FromDept.Text;
            //bill.FromStoreNo = "";
            //bill.FromStoreName = txt_FromStore.Text;
            //bill.ToDeptNo = "";
            //bill.ToDeptName = txt_ToDept.Text;
            //bill.ToStoreNo = "";
            //bill.ToStoreName = txt_ToStore.Text;

            //DateTime LimitTime = Convert.ToDateTime(dte_PlanLimitTime.Text);
            //bill.PlanLimitTime = LimitTime.ToString("yyyyMMddHHmmss");
            //if (lue_BusinessType.EditValue != null)
            //{
            //    bill.BusinessType = new BusinessTypesObj() { IntValue = (int)lue_BusinessType.EditValue };
            //}
            //if (lue_WeightType.EditValue != null)
            //{
            //    bill.WeightType = new WeightTypesObj() { IntValue = (int)lue_WeightType.EditValue };
            //}
            //if (lue_MoveStillType.EditValue != null)
            //{
            //    bill.MoveStillType = new MoveStillTypeObj() { IntValue = (int)lue_MoveStillType.EditValue };
            //}
            //if (lue_TareType.EditValue != null)
            //{
            //    bill.TareType = new TareTypeObj() { IntValue = (int)lue_TareType.EditValue };
            //}
            //bill.Remark = txt_Remark.Text;
            /*
            if (txt_NetWgt.Text == "0")
            {
                bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
            }
            else
            {
                bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
            }
           */
            if (Convert.ToDouble(txt_GrossWgt.Text) > 0 && Convert.ToDouble(txt_TareWgt.Text) > 0 && Convert.ToDouble(txt_NetWgt.Text) > 0)
            {
                bill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            }
            else
            {
                bill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
            }
            //bill.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //bill.UpdateUser = SessionHelper.LogUserNickName;
            var rss = billService.ExecuteDB_UpdateSuppliesInfo(bill);
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
                Boolean flag = ResetSelectMainEntity();
                if (flag == true)
                {
                    var rs = MainService.ExecuteDB_UpdateSuppliesInfo(SelectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        /*
                        if (bill == null)
                        {
                            if (SelectMainEntity.PlanNo != null && !string.IsNullOrEmpty(SelectMainEntity.PlanNo))
                            {
                                bill = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == SelectMainEntity.PlanNo).FirstOrDefault();
                                
                            }     
                        }
                        */
                        if (bill != null)
                        {
                            UpdateBill(bill);
                        }                                           
                    }
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        #endregion
              
        private void PM_PondSupplies_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();           
            if (SelectMainEntity != null)
            {
                //reSetFormValues(SelectMainEntity.PlanNo);
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
            txt_TareWgt.Properties.ReadOnly = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_TareWgt_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetWeight();
        }

        private void CalcNetWeight()
        {
            if (string.IsNullOrEmpty(txt_GrossWgt.Text) || string.IsNullOrEmpty(txt_TareWgt.Text))
            {
                txt_NetWgt.Text = "0";
            }
            else
            {
                txt_NetWgt.Text = (MyNumberHelper.ConvertToDecimal(txt_GrossWgt.Text) - MyNumberHelper.ConvertToDecimal(txt_TareWgt.Text))+"";
            }

        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_WagNo.Text.Trim()))
                {
                    gcl_result.DataSource = billService.ExecuteDB_QueryIronByWgtNo(txt_WagNo.Text.Trim());
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(txt_WagNo.Text.Trim()))
                {
                    gCtrl_TruckMeasurePlan.DataSource = gczService.ExecuteDB_QueryGczTare(txt_WagNo.Text.Trim());
                }
            }
            catch (Exception)
            {
            }
        }

        private void gvw_result_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                sle_PlanNo.Text = gvw_result.GetRowCellValue(gvw_result.FocusedRowHandle, "PlanNo").ToString();
                reSetFormValues(sle_PlanNo.Text);

               
            }
            catch (Exception)
            {
            }
        }

        private void gView_TruckMeasurePlan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //txt_TareWgt.Text = gView_TruckMeasurePlan.GetRowCellValue(gView_TruckMeasurePlan.FocusedRowHandle, "C_TAREWEIGHT").ToString();
                //txt_TareWgtMan.Text = SessionHelper.LogUserNickName;
                //txt_TareWgtSite.Text = "钢厂站";
                //dte_TareWgtTime.EditValue = gView_TruckMeasurePlan.GetRowCellValue(gView_TruckMeasurePlan.FocusedRowHandle, "C_CREATETIME").ToString();
                //CalcNetWeight();
                //strDrass = gView_TruckMeasurePlan.GetRowCellValue(gView_TruckMeasurePlan.FocusedRowHandle, "C_RESERV1").ToString();

                var entity = gView_TruckMeasurePlan.GetFocusedRow() as SM_GczTare_Info;
                if (entity != null)
                {
                    txt_TareWgt.Text = entity.C_TAREWEIGHT.ToString();
                    txt_TareWgtMan.Text = SessionHelper.LogUserNickName;
                    dte_TareWgtTime.EditValue = entity.C_CREATETIME;
                    CalcNetWeight();
                    strDrass = entity.C_RESERV1;

                    if (entity.C_SITENO != null && entity.C_SITENO == "401")
                    {
                        txt_TareWgtSite.Text = "钢厂站";                        
                        // D:\LG\Images\20210722\成功\401202107221409357A.jpg
                        //http://10.200.115.158/LG/Images/20210624/%E6%88%90%E5%8A%9F/401202106240645028A.jpg
                        string path = "http://10.200.115.158/";
                        path = path + strDrass.Replace(@"D:\", "").Replace(@"\", "/");
                        //path = "http://172.18.200.16/2020/901202009/901202009020736574.jpg";
                        PE1.Image = GetImage.getImageFromUrl(path);
                    }
                    else if(entity.C_SITENO != null && entity.C_SITENO == "402")
                    {
                        txt_TareWgtSite.Text = "综合站";
                        string path = "http://10.200.115.190/";
                        path = path + strDrass.Replace(@"D:\", "").Replace(@"\", "/");                        
                        PE1.Image = GetImage.getImageFromUrl(path);
                    }

                    
                    
                   
                }
            }
            catch (Exception)
            {
            }
        }

        private void PE1_DoubleClick(object sender, EventArgs e)
        {

        }
        //新增
        /// <summary>
        /// 毛重值发生改变触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_GrossWgt_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetWeight();
        }
        //委托号回车事件
        private void sle_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bill = new PM_Bill_Supplies();
                if (sle_PlanNo.Text != null && !string.IsNullOrEmpty(sle_PlanNo.Text))
                {
                    reSetFormValues(sle_PlanNo.Text);
                }
            }
        }
        private void reSetFormValues(string newPlanno)
        {
            bill = new PM_Bill_Supplies();
            if (newPlanno != null && !string.IsNullOrEmpty(newPlanno))
            {
                string planno = newPlanno;
                bill = billService.ExecuteDB_QueryAll().Where(x => x.PlanNo == planno).FirstOrDefault();
                if (bill != null)
                {
                    txt_WagNo.Text = bill.WagNo;
                    txt_ShipNo.Text = bill.ShipNo;
                    txt_FromStation.Text = bill.FromStation;
                    txt_SerialNo.Text = bill.SerialNo;
                    txt_DeliveryNo.Text = bill.DeliveryNo;
                    txt_ContractNo.Text = bill.ContractNo;
                    txt_ProjectNo.Text = bill.ProjectNo;
                    txt_WayBillNo.Text = bill.WayBillNo;
                    txt_MarshallingNo.Text = bill.MarshallingNo;
                    txt_PondLimit.Text = bill.PondLimit;
                    txt_Remark.Text = bill.Remark;
                    if (!string.IsNullOrEmpty(bill.PlanLimitTime))
                    {
                        DateTime dt;
                        IFormatProvider ifp = new CultureInfo("zh-CN", true);
                        if (DateTime.TryParseExact(bill.PlanLimitTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                        {
                            dte_PlanLimitTime.Text = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    if (bill.BusinessType != null)
                    {
                        lue_BusinessType.EditValue = bill.BusinessType.IntValue;
                    }
                    else
                    {
                        lue_BusinessType.EditValue = null;
                    }
                    if (bill.WeightType != null)
                    {
                        lue_WeightType.EditValue = bill.WeightType.IntValue;
                    }
                    else
                    {
                        lue_WeightType.EditValue = null;
                    }
                    if (bill.TareType != null)
                    {
                        lue_TareType.EditValue = bill.TareType.IntValue;
                    }
                    else
                    {
                        lue_TareType.EditValue = null;
                    }
                    if (bill.MoveStillType != null)
                    {
                        lue_MoveStillType.EditValue = bill.MoveStillType.IntValue;
                    }
                    else
                    {
                        lue_MoveStillType.EditValue = null;
                    }
                    txt_FromDept.Text = bill.FromDeptName;
                    txt_ToDept.Text = bill.ToDeptName;
                    txt_FromStore.Text = bill.FromStoreName;
                    txt_ToStore.Text = bill.ToStoreName;
                    txt_Material.Text = bill.MaterialName;
                }
                else
                {
                    txt_WagNo.Text = null;
                    txt_ShipNo.Text = null;
                    txt_FromStation.Text = null;
                    txt_SerialNo.Text = null;
                    txt_DeliveryNo.Text = null;
                    txt_ContractNo.Text = null;
                    txt_ProjectNo.Text = null;
                    txt_WayBillNo.Text = null;
                    txt_MarshallingNo.Text = null;
                    txt_PondLimit.Text = null;
                    txt_Remark.Text = null;
                    dte_PlanLimitTime.Text = null;
                    lue_BusinessType.EditValue = null;
                    lue_WeightType.EditValue = null;
                    lue_TareType.EditValue = null;
                    lue_MoveStillType.EditValue = null;
                    txt_FromDept.Text = bill.FromDeptName;
                    txt_ToDept.Text = bill.ToDeptName;
                    txt_FromStore.Text = bill.FromStoreName;
                    txt_ToStore.Text = bill.ToStoreName;
                    txt_Material.Text = bill.MaterialName;
                }

                setBillInfo(bill);
            }
     
            
        }

        private void txt_TareWgt_DoubleClick(object sender, EventArgs e)
        {
            if (SelectMainEntity == null)
            { //这种情况用于联调测试模拟过磅
                var result = XtraInputBox.Show("请输入密码", "密码验证", "");
                if (result != null)
                {
                    if (result.ToString().Trim() == "pp")
                    {
                        txt_GrossWgt.Properties.ReadOnly = false;
                        txt_TareWgt.Properties.ReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show("密码错误");
                    }
                }
            }
            else
            {
                if (SelectMainEntity.BillStatus.IntValue >= 2)
                {
                    var result = XtraInputBox.Show("请输入密码", "密码验证", "");
                    if (result != null)
                    {
                        if (result.ToString().Trim() == "sb2022301")
                        {

                            txt_TareWgt.Properties.ReadOnly = false;
                        }
                        else
                        {
                            MessageBox.Show("密码错误");
                        }
                    }
                }
                else
                {
                    txt_TareWgt.Properties.ReadOnly = false;
                }
            }
        }         
        //新增  
        private void setBillInfo(PM_Bill_Supplies plan)
        {
            if (SelectMainEntity == null)
            {
                return;
            }
            SelectMainEntity.MaterialNo = plan.MaterialNo;
            SelectMainEntity.FromDeptNo = plan.FromDeptNo;
            SelectMainEntity.ToDeptNo = plan.ToDeptNo;
            SelectMainEntity.FromStoreNo = plan.FromStoreNo;
            SelectMainEntity.ToStoreNo = plan.ToStoreNo;
            SelectMainEntity.CReserve1 = plan.CReserve1;
            SelectMainEntity.CReserve2 = plan.CReserve2;
            SelectMainEntity.CReserve3 = plan.CReserve3;
            SelectMainEntity.IReserve1 = plan.IReserve1;
            SelectMainEntity.IReserve2 = plan.IReserve2;
            SelectMainEntity.IReserve3 = plan.IReserve3;
            SelectMainEntity.PlanCreateUser = plan.CreateUser;
            SelectMainEntity.PlanCreateTime = plan.CreateTime;

        }
    }
}
