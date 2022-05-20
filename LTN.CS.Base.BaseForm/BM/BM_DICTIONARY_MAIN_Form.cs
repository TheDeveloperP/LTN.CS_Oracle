using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using System.Threading;
using DevExpress.XtraEditors;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_DICTIONARY_MAIN_Form : CoreForm
    {
        #region 实例变量
        public IBMDICTIONARYMAINService dicService { get; set; }
        private BM_DICTIONARY_MAIN dicSelect { get; set; }
        private int selectId { get; set; }
        private EventHandler eventNow;
        #endregion

        #region 构造函数
        public BM_DICTIONARY_MAIN_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 控件事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_DICTIONARY_MAIN_Form_Load(object sender, EventArgs e)
        {
            SetGridData(true);
            ResetEditerUI(false, layoutControl1);
            SetBtnEnable();
            dicSelect = new BM_DICTIONARY_MAIN();
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            ClearUI();
            SetBtnNoEnable();
            eventNow = CustomAdd;
            btn_sure.Click += eventNow;
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            ResetEditerUI(true, layoutControl1);
            SetBtnNoEnable();
            eventNow = CustomUpdate;
            btn_sure.Click += eventNow;
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_sure.Click -= eventNow;
            eventNow = null;
            ResetEditerUI(false, layoutControl1);
            gvw_main_FocusedRowChanged(null, null);
            SetBtnEnable();
            dxErrorProvider1.ClearErrors();
        }

        /// <summary>
        /// 禁用按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ISFORBID_Click(object sender, EventArgs e)
        {
            CustomDisable();
        }



        /// <summary>
        /// 焦点行切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    dicSelect = gvw_main.GetFocusedRow() as   BM_DICTIONARY_MAIN ;
                    selectId = dicSelect.IntId;
                    SetUIValue();
                    ChangeBtnText();
                }
            }
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dicSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
            {
                if (MessageDxUtil.ShowYesNoAndTips("删除后无法恢复，是否确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    CustomDelete();
                }
            }
            else
            {
                MessageDxUtil.ShowError("该用户为启用状态，无法删除，请先禁用该字典！");
            }
        }

        #endregion

        #region 自定义方法

        /// <summary>
        /// 改变按钮文本
        /// </summary>
        private void ChangeBtnText()
        {
            if (dicSelect != null && dicSelect.IsForbid != null)
            {
                btn_ISFORBID.Text = dicSelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = dicSelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16 : global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
        }
        /// <summary>
        /// 设定Grid数据
        /// </summary>
        private void SetGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectIdOld = selectId;
                    gcl_center.DataSource = dicService.ExecuteDB_QueryAll();
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectId = selectIdOld;
                        SetLeftFocusRow();
                        gvw_main_FocusedRowChanged(null, null);
                    }
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);

        }

        /// <summary>
        /// 设定UI不可用
        /// </summary>
        private void ClearUI()
        {
            txt_DicSn.Text = string.Empty;
            txt_DicName.Text = string.Empty;
            txt_DicFieldA.Text = string.Empty;
            txt_DicFieldB.Text = string.Empty;
            txt_DicDesc.Text = string.Empty;
            txt_IsForbid.Checked = false;
        }

        /// <summary>
        /// 设定编辑区是否可用
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="cc"></param>
        protected virtual void ResetEditerUI(bool flag, Control cc)
        {
            Control.ControlCollection ccs = cc.Controls;
            int n;
            if ((n = ccs.Count) > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Control ctl = ccs[i];
                    if (ctl.GetType().IsSubclassOf(typeof(BaseEdit)))
                    {
                        ctl.Enabled = flag;
                    }
                }
            }
        }
        /// <summary>
        /// 设定按钮
        /// </summary>
        private void SetBtnEnable()
        {
            btn_add.Enabled = true;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            btn_sure.Enabled = false;
            btn_cancel.Enabled = false;
            btn_ISFORBID.Enabled = true;
        }
        /// <summary>
        /// 设定按钮
        /// </summary>
        private void SetBtnNoEnable()
        {
            btn_add.Enabled = false;
            btn_update.Enabled = false;
            btn_sure.Enabled = true;
            btn_cancel.Enabled = true;
            btn_delete.Enabled = false;
            btn_ISFORBID.Enabled = false;
        }

        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValue()
        {
            txt_DicSn.Text = dicSelect.DicSn;
            txt_DicName.Text = dicSelect.DicName;
            txt_DicFieldA.Text = dicSelect.DicFieldA;
            txt_DicFieldB.Text = dicSelect.DicFieldB;
            txt_DicDesc.Text = dicSelect.DicDesc;
            txt_IsForbid.Checked = dicSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
        }

        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetDicSelect(bool isAdd)
        {
            if (isAdd)
            {
                dicSelect = new BM_DICTIONARY_MAIN() { CreateUserId = SessionHelper.LogUserId };
            }
            dicSelect.DicSn = txt_DicSn.Text;
            dicSelect.DicName = txt_DicName.Text;
            dicSelect.DicFieldA = txt_DicFieldA.Text;
            dicSelect.DicFieldB = txt_DicFieldB.Text;
            dicSelect.DicDesc = txt_DicDesc.Text;
            dicSelect.UpdateUserId = SessionHelper.LogUserId;
            dicSelect.IsForbid = txt_IsForbid.Checked ? new EntityInt(1) : new EntityInt(0);
        }
        /// <summary>
        /// 用户自定义添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomAdd(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            bool isexception = false;
            if (txt_DicSn.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_DicSn, "字典编号不允许为空！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                return;
            }
            else 
            {
                IList<BM_DICTIONARY_MAIN> rsTemp = dicService.ExecuteDB_QueryBySn(txt_DicSn.Text);
                if (rsTemp != null && rsTemp.Count>0)
                {
                    dxErrorProvider1.SetError(txt_DicSn, "字典编号不允许重复！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                    return;
                }
            }
            try
            {
                ReSetDicSelect(true);
                var rs = dicService.ExecuteDB_Insert(dicSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                selectId = MyNumberHelper.ConvertToInt32(rs);
                SetGridData(false);
            }
            catch (Exception ep)
            {
                isexception = true;
                MessageDxUtil.ShowError(ep.Message);
            }
            finally
            {
                if (!isexception)
                {
                    ResetEditerUI(false, layoutControl1);
                    SetBtnEnable();
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
        }
        /// <summary>
        /// 用户自定义修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomUpdate(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            bool isexception = false;
            if (txt_DicSn.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_DicSn, "字典编号不允许为空！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                return;
            }
            try
            {
                ReSetDicSelect(false);
                var rs = dicService.ExecuteDB_Update(dicSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    isexception = true;
                    return;
                }
                SetGridData(false);
            }
            catch (Exception ep)
            {
                isexception = true;
                MessageDxUtil.ShowError(ep.Message);
            }
            finally
            {
                if (!isexception)
                {
                    ResetEditerUI(false, layoutControl1);
                    SetBtnEnable();
                    btn_sure.Click -= eventNow;
                    eventNow = null;
                }
            }
        }

        /// <summary>
        /// 用户自定义删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDelete()
        {
            try
            {
                ReSetDicSelect(false);
                var rs = dicService.ExecuteDB_Delete(dicSelect);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    return;
                }
                SetGridData(false);
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }
        /// <summary>
        /// 用户自定义禁用
        /// </summary>
        private void CustomDisable()
        {
            try
            {
                if (dicSelect != null && dicSelect.IsForbid != null)
                {
                    dicSelect.IsForbid = dicSelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = dicService.ExecuteDB_DisableService(dicSelect);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                        return;
                    }
                    SetGridData(false);
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }

        /// <summary>
        /// 焦点行转换
        /// </summary>
        private void SetLeftFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    BM_DICTIONARY_MAIN user = gvw_main.GetRow(i) as BM_DICTIONARY_MAIN;
                    if (user.IntId == selectId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectId)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectId = rowcount - 1;
                }
                else if (selectId == 0)
                {
                    gvw_main.FocusedRowHandle = 0;
                    selectId = 0;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectId;
                }
            }
        }
        #endregion

    }
}
