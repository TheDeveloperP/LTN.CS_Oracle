using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_ErrorConfig_Form : CoreForm
    {
      

        #region  实例变量
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_ErrorConfig selectMainEntity { get; set; }      
        private bool queryMain { get; set; }
        public ISM_ErrorConfigService MainService { get; set; }
        
        string AliasMeterName;

        #endregion
        #region 构造函数
        public SM_ErrorConfig_Form()
        {
            InitializeComponent();
        }
        #endregion


        #region  控件事件

        public void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_ErrorConfig;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
                //  SetMainGridData(true);
            }
        }
        private void SM_ErrorConfig_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(true);
            this.txt_GrossWgtError.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_GrossWgtError.Properties.Mask.MaskType = MaskType.RegEx;
           



        }
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }

        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
            SetMainGridData(false);
        }

       
        #endregion


        #region 自定义事件
        /// <summary>
        /// 设定主档编辑区
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(SM_ErrorConfig entity)
        {
            if (entity != null)
            {                
                txt_GrossWgtError.EditValue = entity.GrossWgtError;
                txt_Remark.EditValue = entity.Remark;
                // AliasMeterName = entity.MeterName;
            }
        }

        /// <summary>
        /// 设定操作区数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_ErrorConfig;
                if (entity != null)
                {
                    SetMainEditer(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                selectMainEntity = entity;
                queryMain = true;
            }
        }
        /// <summary>
        /// 设定UI不可用
        /// </summary>
        private void ClearMainEditer()
        {
            txt_GrossWgtError.EditValue = string.Empty;
            txt_Remark.EditValue = string.Empty;

        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSelectMainEntity()
        {

            if (txt_GrossWgtError.EditValue == null || txt_GrossWgtError.EditValue == "")
            {
                dxErrorProvider1.SetError(txt_GrossWgtError, "毛重误差值为必填！", ErrorType.Information);
                return;
            }         

            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_ErrorConfig()
                {
                    createUser = SessionHelper.LogUserNickName,
                    updateUser = SessionHelper.LogUserNickName
                };

                Boolean b = IsNotExist(txt_GrossWgtError.EditValue.ToString());
                if (b == false)
                {
                    dxErrorProvider1.SetError(txt_GrossWgtError, "毛重误差值已存在！", ErrorType.Information);
                    return;
                }
            }

           
            selectMainEntity.GrossWgtError = txt_GrossWgtError.Text;
            selectMainEntity.Remark = txt_Remark.Text;
            selectMainEntity.updateUser = SessionHelper.LogUserNickName;         
        }
        /// <summary>
        /// 设定主档Grid数据
        /// 获取数据
        /// </summary>
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAll();

                    gcl_main.DataSource = rss;

                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
                    }
                    queryMain = true;
                    SetMainEditerData();
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 主档按钮状态
        /// </summary>
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Add.Enabled = true;
                btn_update.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else
            {
                btn_Add.Enabled = false;
                btn_update.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;

            }
        }


        /// <summary>
        /// 设定编辑区状态
        /// </summary>
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_GrossWgtError.Enabled = enabled;
            txt_Remark.Enabled = enabled;
            

            if (enabled)
            {
                txt_GrossWgtError.Focus();
            }
            dxErrorProvider1.ClearErrors();

        }

        /// <summary>
        /// 主档焦点行转换
        /// 修改后默认选中
        /// </summary>
        private void SetMainFocusRow()
        {

            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_ErrorConfig group = gvw_main.GetRow(i) as SM_ErrorConfig;
                    if (group.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        selectMainRowNum = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (!isFocused)
            {
                if (rowcount - 1 < selectMainRowNum)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
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
                dxErrorProvider1.ClearErrors();

                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {


                    var rs = MainService.ExecuteDB_InsertErrorConfig(selectMainEntity);

                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="GrossWgtError"></param>
        /// <returns></returns>
        private Boolean IsNotExist(string GrossWgtError)
        {
            Boolean b = false;
            var list = MainService.ExecuteDB_QueryErrorConfigSingle(GrossWgtError);
            if (list == null || list.Count == 0)
            {
                b = true;
            }
            return b;
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
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    
                    var rs = MainService.ExecuteDB_UpdateErrorConfig(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                       
                    }
                    //else
                    //{

                    //     Boolean b = IsNotExist(selectMainEntity);

                    //    if (b == true)
                    //    {

                    //        var rs = HK_Meter_InfoMainService.ExecuteDB_UpdateMeter(selectMainEntity);
                    //        if (rs is CustomDBError)
                    //        {
                    //            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    //        }
                    //        else
                    //        {
                    //            SetMainGridData(false);
                    //            btn_Confirm.Click -= eventMainNow;
                    //            eventMainNow = null;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageDxUtil.ShowTips("该仪表名称已经存在，请重新输入");
                    //        SetMainGridData(false);
                    //        btn_Confirm.Click -= eventMainNow;
                    //        eventMainNow = null;
                    //    }
                    //}


                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeleteErrorConfig(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        #endregion

        private void gvw_main_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gvw_main.FocusedRowHandle)
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.RoyalBlue;
            }
        }

    }
}
