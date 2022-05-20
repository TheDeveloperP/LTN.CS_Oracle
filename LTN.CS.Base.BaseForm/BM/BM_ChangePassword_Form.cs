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
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;
using System.Xml;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_CHANGEPASSWORD_Form : CoreForm
    {
        #region 实例变量
        public IBMUSERService userService { get; set; }
        private readonly BM_USER logUser = SessionHelper.LogUser as BM_USER;
        #endregion

        #region 构造函数
        public BM_CHANGEPASSWORD_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string newPassword = MD5Helper.MD5(txt_passwordNew.Text);
            string oldPassword = MD5Helper.MD5(txt_oldPassword.Text);
            if(!txt_passwordNew.Text.Equals(txt_passwordNewCheck.Text))
            {
                MessageDxUtil.ShowError("两次输入密码不一致,请修改后再确认！");
                return;
            }
            if (!oldPassword.Equals(logUser.Password))
            {
                MessageDxUtil.ShowError("本次输入的原有密码错误，请填写正确的原有密码！");
                return;
            }
            try
            {
                logUser.Password = newPassword;
                var rs = userService.ExecuteDB_UpdateUser(logUser);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    logUser.Password = newPassword;
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
            finally 
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_ChangePassword_Form_Load(object sender, EventArgs e)
        {
            txt_user.Text = logUser.UserNickName;
        }
        #endregion


    }
}
