using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Helper;
using LTN.CS.Base.BusinessService.BM.Interface;

using LTN.CS.Core.Common;

namespace LTN.CS.Base
{
    public partial class NewLoginForm : XtraForm
    {
        #region 实例变量
        private Point mouseOff;                          //鼠标移动位置变量
        private bool leftFlag;                               //标签是否为左键
        private IBMUSERService userService { get; set; }
        public bool isLogined;
        #endregion

        #region 构造函数
        public NewLoginForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 单击拖动
        private void NewLoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                              //点击左键按下时标注为true;
            } 

        }
        private void NewLoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void NewLoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion

        #region 鼠标经过变色
        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureEdit1.BackColor = Color.DarkBlue;
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit1.BackColor = Color.Transparent;
        }

        private void pictureEdit2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureEdit2.BackColor = Color.DarkBlue;
        }

        private void pictureEdit2_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit2.BackColor = Color.Transparent;
        }
        #endregion

        #region 最小化
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 关闭
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 登录
        private void btn_login_Click(object sender, EventArgs e)
        {
            WaitCallback setStatuswc = (o) =>
            {
                Login();
            };
            ThreadPool.QueueUserWorkItem(setStatuswc); 
        }

        private void TxtPwdCallBack()
        {
            Action ac = () =>
            {
                btn_login.Enabled = true;
                txtPwd.Text = string.Empty;
                txtId.Focus();
            };
            Invoke(ac);
        }

        private void Login()
        {
            Action ac_Btn = () =>
            {
                btn_login.Enabled = false;
            };
            Invoke(ac_Btn);
            try
            {
                object rs = userService.ExecuteDB_QueryByName(txtId.Text);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                    Action ac = () =>
                    {
                        btn_login.Enabled = true;
                    };
                    Invoke(ac);
                }
                else
                {
                    BM_USER user = rs as BM_USER;
                    if (user == null)
                    {
                        TxtPwdCallBack();
                        MessageDxUtil.ShowError("用户名不存在，请确认用户名！");
                    }
                    else if (user.IsForbid.EntityValue.Equals((Int32)IntBool.Yes))
                    {
                        TxtPwdCallBack();
                        MessageDxUtil.ShowError("该用户已经禁用，请联系管理员！");
                    }
                    else if (MD5Helper.MD5(txtPwd.EditValue.ToString()).Equals(user.Password))
                    {
                        Action ac = () =>
                        {
                            btn_login.Enabled = true;
                            DialogResult = DialogResult.OK;
                            SessionHelper.ResetLoger(user.IntId, user.UserName, user.UserNickName, user);
                            txtPwd.Text = string.Empty;
                            Hide();
                        };
                        Invoke(ac);
                    }
                    else if (!MD5Helper.MD5(txtPwd.EditValue.ToString()).Equals(user.Password))
                    {
                        Action ac = () =>
                        {
                            btn_login.Enabled = true;
                            txtPwd.Text = string.Empty;
                            txtPwd.Focus();
                        };
                        Invoke(ac);
                        MessageDxUtil.ShowError("密码与用户名不匹配，请确认密码！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
                Action ac_Btn_Enable = () =>
                {
                    btn_login.Enabled = true;
                };
                Invoke(ac_Btn_Enable);
            }
        }
        #endregion

        #region 回车事件

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                txtPwd.Focus();
            }
        }
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                btn_login.Focus();
            }
        }
        #endregion

    }
}