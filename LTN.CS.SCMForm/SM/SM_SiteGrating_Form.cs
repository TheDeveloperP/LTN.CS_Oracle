using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LTN.CS.Base;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_SiteGrating_Form : CoreForm
    {
        #region 变量

        public ISM_PoundSite_InfoService MainService { get; set; }

        #endregion

        #region 构造函数

        public SM_SiteGrating_Form()
        {
            InitializeComponent();
        }


        #endregion

        #region 自定义方法

        #endregion

        #region 控件事件


        #endregion




        private void SM_SiteGrating_Form_Shown(object sender, EventArgs e)
        {
            SetGridDataGuangUnShouQuan();
            SetGridDataGuangShouQuan();
        }

        /// <summary>
        /// 已授权光栅查询
        /// </summary>
        private void SetGridDataGuangShouQuan()
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {

                    var rss = MainService.ExecuteDB_QueryGuangShouQuan();

                    gcl_ysq.DataSource = rss;

                    gvw_ysq.BestFitColumns();

                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 未授权光栅查询
        /// </summary>
        private void SetGridDataGuangUnShouQuan()
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {

                    var rss = MainService.ExecuteDB_QueryGuangUnShouQuan();

                    gcl_wsq.DataSource = rss;

                    gvw_wsq.BestFitColumns();

                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        private void gvw_ysq_DoubleClick(object sender, EventArgs e)
        {
            if (gvw_ysq.GetFocusedRow() != null)
            {
                SM_PoundSite_Info poundSite = gvw_ysq.GetFocusedRow() as SM_PoundSite_Info;
                poundSite.IsRedOpen.EntityValue = '1';
                try
                {
                    var rss = MainService.ExecuteDB_UpdatePoundSiteInfo(poundSite);
                    if (rss is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rss).ErrorMsg);
                        return;
                    }
                    else
                    {
                        SetGridDataGuangUnShouQuan();
                        SetGridDataGuangShouQuan();
                    }
                }
                catch (Exception ex)
                {
                    MessageDxUtil.ShowError(ex.Message);
                }

            }
        }

        private void gvw_wsq_DoubleClick(object sender, EventArgs e)
        {
            if (gvw_wsq.GetFocusedRow() != null)
            {
                SM_PoundSite_Info poundSite = gvw_wsq.GetFocusedRow() as SM_PoundSite_Info;

                poundSite.IsRedOpen.EntityValue = '0';
                try
                {
                    var rss = MainService.ExecuteDB_UpdatePoundSiteInfo(poundSite);
                    if (rss is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rss).ErrorMsg);
                        return;
                    }
                    else
                    {
                        SetGridDataGuangUnShouQuan();
                        SetGridDataGuangShouQuan();
                    }

                }
                catch (Exception ex)
                {
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
        }
    }
}
