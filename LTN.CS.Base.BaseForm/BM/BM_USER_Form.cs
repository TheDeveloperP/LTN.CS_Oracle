using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LTN.CS.Base.BusinessService.BM.Interface;
using System.Threading;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_USER_Form : CoreForm
    {
        #region 实例变量
        public IBMUSERService userService { get; set; }
        private BM_USER userSelect { get; set; }
        //当前执行事件
        private EventHandler eventNow;
        private int selectId { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BM_USER_Form()
        {
            InitializeComponent();  
        }
#endregion

        #region 控件事件
        /// <summary>
        /// 界面加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_USER_Form_Load(object sender, EventArgs e)
        {
            SetGridData(true);
            ResetEditerUI(false,layoutControl1);
            SetBtnEnable();
            userSelect = new BM_USER();

        }
       
        /// <summary>
        /// 新增按钮事件
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
        /// 修改按钮事件
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
            gvw_main_FocusedRowChanged(null,null);
            SetBtnEnable();
            dxErrorProvider1.ClearErrors();
        }
        /// <summary>
        /// 切换页面焦点方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (eventNow == null)
            {
                if (gvw_main != null && gvw_main.GetFocusedRow() != null)
                {
                    userSelect = gvw_main.GetFocusedRow() as BM_USER;
                    selectId = userSelect.IntId;
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
            if (userSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
            {
                if (MessageDxUtil.ShowYesNoAndTips("删除后无法恢复，是否确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    CustomDelete();
                }
            }
            else
            {
                MessageDxUtil.ShowError("该用户为启用状态，无法删除，请先禁用该用户！");
            }
        }
        /// <summary>
        /// 重置密码事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("重置后密码为默认密码，是否确认重置？") == System.Windows.Forms.DialogResult.Yes)
            {
                CustomReset();
            }
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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 改变按钮文本
        /// </summary>
        private void ChangeBtnText()
        {
            if (userSelect != null && userSelect.IsForbid != null)
            {
                btn_ISFORBID.Text = userSelect.IsForbid.EntityValue == 0 ? "禁用" : "启用";
                btn_ISFORBID.Image = userSelect.IsForbid.EntityValue == 0 ? global::LTN.CS.Base.BaseForm.Properties.Resources.disabled_16:global::LTN.CS.Base.BaseForm.Properties.Resources.abled_16;
            }
        }

        /// <summary>
        /// 设定Grid数据
        /// </summary>
        private void SetGridData(bool isFirst)
        {
            WaitCallback wc = (o)=>
            {
                Action ac = () => 
                {
                    int selectIdOld = selectId;
                    gcl_center.DataSource = userService.ExecuteDB_QueryAll();
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
            txt_USERNAME.Text = string.Empty;
            txt_USERNICKNAME.Text = string.Empty;
            txt_MOBILENO.Text = string.Empty;
            txt_ISFORBID.Checked = false;
            txt_EMAIL.Text = string.Empty;
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
            btn_reset.Enabled = true;
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
            btn_reset.Enabled = false;
            btn_ISFORBID.Enabled = false;
        }
        /// <summary>
        /// 更新画面值
        /// </summary>
        private void SetUIValue()
        {
            txt_USERNICKNAME.Text = userSelect.UserNickName;
            txt_USERNAME.Text = userSelect.UserName;
            txt_MOBILENO.Text = userSelect.MobileNo;
            txt_ISFORBID.Checked = userSelect.IsForbid.EntityValue.Equals((Int32)IntBool.Yes) ? true : false;
            txt_EMAIL.Text = userSelect.Email;
        }
        /// <summary>
        /// 更新实体类
        /// </summary>
        /// <param name="isAdd"></param>
        private void ReSetUserSelect(bool isAdd)
        {
            if (isAdd)
            {
                userSelect = new BM_USER() { Password = MD5Helper.MD5(ProjectConfiguration.DefaultPassword), CreateUserId = SessionHelper.LogUserId };
            }
            userSelect.UserName = txt_USERNAME.Text;
            userSelect.MobileNo = txt_MOBILENO.Text;
            userSelect.Email = txt_EMAIL.Text;
            userSelect.IsForbid = txt_ISFORBID.Checked ? new EntityInt(1) : new EntityInt(0);
            userSelect.UserNickName = txt_USERNICKNAME.Text;
            userSelect.UpdateUserId = SessionHelper.LogUserId;
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
            if (txt_USERNAME.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_USERNAME, "用户名不允许为空！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                return;
            }
            object rss = userService.ExecuteDB_QueryByName(txt_USERNAME.Text);
            if (rss != null && rss is BM_USER)
            {
                BM_USER user = rss as BM_USER;
                if (user != null)
                {
                    dxErrorProvider1.SetError(txt_USERNAME, "该用户名已经注册，请更改用户名！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                }
            }
            else if (rss == null)
            {
                try
                {
                    ReSetUserSelect(true);
                    var rs = userService.ExecuteDB_InserUser(userSelect);
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
                        btn_sure.Click -= eventNow;
                        eventNow = null;
                        ResetEditerUI(false, layoutControl1);
                        SetBtnEnable();
                    }
                }
            }
            else
            {
                MessageDxUtil.ShowError(((CustomDBError)rss).ErrorMsg);
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
            if (txt_USERNAME.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_USERNAME, "用户名不允许为空！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                return;
            }
            object rss = userService.ExecuteDB_QueryByName(txt_USERNAME.Text);
            if (rss is BM_USER || rss == null)
            {
                if (rss != null)
                {
                    BM_USER user = rss as BM_USER;
                    if (user != null && txt_USERNAME.Text != userSelect.UserName)
                    {
                        dxErrorProvider1.SetError(txt_USERNAME, "该用户名已经注册，请更改用户名！", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        return;
                    }
                }
                try
                {
                    ReSetUserSelect(false);
                    var rs = userService.ExecuteDB_UpdateUser(userSelect);
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
                        btn_sure.Click -= eventNow;
                        eventNow = null;
                        ResetEditerUI(false, layoutControl1);
                        SetBtnEnable();
                    }
                }
            }
            else if (rss != null)
            {
                MessageDxUtil.ShowError(((CustomDBError)rss).ErrorMsg);
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
                ReSetUserSelect(false);
                var rs = userService.ExecuteDB_DeleteUser(userSelect);
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
        /// 用户自定义重置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomReset()
        {
            try
            {
                userSelect.Password = MD5Helper.MD5(ProjectConfiguration.DefaultPassword);
                var rs = userService.ExecuteDB_UpdateUser(userSelect);
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
                if (userSelect != null && userSelect.IsForbid != null)
                {
                    userSelect.IsForbid = userSelect.IsForbid.EntityValue == 0 ? new EntityInt(1) : new EntityInt(0);
                    var rs = userService.ExecuteDB_DisableUser(userSelect);
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
                    BM_USER user = gvw_main.GetRow(i) as BM_USER;
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