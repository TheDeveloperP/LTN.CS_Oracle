using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_MatWGTLimit_Form : CoreForm
    {
        private EventHandler eventMainNow;
        public ISM_MatWGTLimitService MainService { get; set; }
        private SM_MatWGTLimit selectMainEntity { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        public SM_MatWGTLimit_Form()
        {
            InitializeComponent();
        }
        private void ClearMainEditer()
        {
            txt_Materielcode.EditValue = string.Empty;
            txt_Materielname.EditValue = string.Empty;
            txt_Limitwgt.EditValue = string.Empty;
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_Materielcode.Enabled = enabled;
            txt_Materielname.Enabled = enabled;
            txt_Limitwgt.Enabled = enabled;
            dxErrorProvider1.ClearErrors();
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            btn_insert.Enabled = enabled;
            btn_update.Enabled = enabled;
            btn_delete.Enabled = enabled;
            btn_confirm.Enabled = !enabled;
            btn_cancel.Enabled = !enabled;
        }
        /// <summary>
        /// 页面数据及样式显示
        /// </summary>
        /// <param name="isFirst"></param>
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAll();

                    gc_main.DataSource = rss;

                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        //SetMainFocusRow();
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
        /// 展示选中行数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_MatWGTLimit;
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
        private void SetMainEditer(SM_MatWGTLimit entity)
        {
            if (entity != null)
            {
                txt_Materielcode.EditValue = entity.Materielcode;
                txt_Materielname.EditValue = entity.Materielname;
                txt_Limitwgt.EditValue = entity.Limitwgt;
            }
        }
        #region 自定义方法
        /// <summary>
        /// 自定义添加方法
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
                    var rs = MainService.ExecuteDB_InsertWGTLimitInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
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
        /// 自定义修改方法
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
                    var rs = MainService.ExecuteDB_UpdateWGTLimitInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void CustomMainDelete()
        {
            try
            {
                var rs = MainService.ExecuteDB_DeleteWGTLimitInfo(selectMainEntity);
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
        private void ResetSelectMainEntity()
        {

            if (txt_Materielname.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_Materielname, "物料名称为必填！", ErrorType.Information);
                return;
            }
            if (txt_Limitwgt.EditValue == string.Empty)
            {
                dxErrorProvider1.SetError(txt_Limitwgt, "限制重量为必填！", ErrorType.Information);
                return;
            }
            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new SM_MatWGTLimit()
                {
                    Createusername = SessionHelper.LogUserNickName,
                    Updateusername = SessionHelper.LogUserNickName
                };
                var querycarnoResult = MainService.ExecuteDB_QueryMatName(txt_Materielname.EditValue.ToString().Trim());
                if (querycarnoResult != null && querycarnoResult.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_Materielname, "该物料编码已存在！", ErrorType.Information);
                    return;
                }

                if (txt_Materielcode.EditValue != string.Empty)
                {
                    var querycarnoResult2 = MainService.ExecuteDB_QueryMatCode(txt_Materielcode.EditValue.ToString().Trim());
                    if (querycarnoResult2 != null && querycarnoResult2.Count() > 0)
                    {
                        dxErrorProvider1.SetError(txt_Materielcode, "该物料编码已存在！", ErrorType.Information);
                        return;
                    }
                    selectMainEntity.Materielcode = txt_Materielcode.Text.Trim();
                }
                if (txt_Limitwgt.EditValue != string.Empty)
                {
                    selectMainEntity.Limitwgt = MyNumberHelper.ConvertToInt32(txt_Limitwgt.Text.Trim());
                }
                selectMainEntity.Materielname = txt_Materielname.Text.Trim();
                selectMainEntity.Limitstatus = 1;

            }
            if (eventMainNow.Method.Name == "CustomMainUpdate")
            {
                var querycarnoResult = MainService.ExecuteDB_QueryMatName(txt_Materielname.EditValue.ToString().Trim());
                if (querycarnoResult != null && querycarnoResult.Count() > 0 && querycarnoResult[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_Materielname, "该物料已经设置了重量限制！", ErrorType.Information);
                    return;
                }
                var querycarnoResult2 = MainService.ExecuteDB_QueryMatCode(txt_Materielcode.EditValue.ToString().Trim());
                if (querycarnoResult2 != null && querycarnoResult2.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_Materielcode, "该物料编码已存在！", ErrorType.Information);
                    return;
                }
                if (txt_Materielcode.EditValue != string.Empty)
                {
                    selectMainEntity.Materielcode = txt_Materielcode.Text.Trim();
                }
                if (txt_Limitwgt.EditValue != string.Empty)
                {
                    selectMainEntity.Limitwgt = MyNumberHelper.ConvertToInt32(txt_Limitwgt.Text.Trim());
                }
                selectMainEntity.Materielname = txt_Materielname.Text.Trim();                
                selectMainEntity.Updateusername = SessionHelper.LogUserNickName;
            }
        }
        #endregion
        private void btn_query_Click(object sender, EventArgs e)
        {
            SetMainGridData(true);
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {            
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_confirm.Click += eventMainNow;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {            
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_confirm.Click += eventMainNow;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SM_MatWGTLimit mat = gvw_main.GetFocusedRow() as SM_MatWGTLimit;
            if (mat == null)
            {
                MessageDxUtil.ShowWarning("没有数据可以删除!");
                return;
            }
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_confirm.Click -= eventMainNow;
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
            SetMainGridData(false);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_MatWGTLimit;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);

            }
        }

        private void SM_MatWGTLimit_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(true);
        }
    }
}
