using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DevExpress.Utils.About;
using System.Windows.Forms;
using LTN.CS.Base.CustomFrm;
using DevExpress.XtraLayout;
using Spring.Context;
using Spring.Context.Support;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Helper;
using log4net;
using Quartz.Impl;
using Spring.Scheduling.Quartz;
using Quartz;
using LTN.CS.BaseEntities.BM_Query;
using System.Threading;
using DevExpress.XtraTabbedMdi;

namespace LTN.CS.Base
{
    public partial class MainForm : RibbonForm
    {
        #region 实例变量
        public static Size HoverSkinImageSize = new Size(116, 86);
        public static Size SkinImageSize = new Size(58, 43);
        private IBMMAINPAGEService pageService { get; set; }
        private IBMMAINGROUPService groupService { get; set; }
        private IBMMAINGROUPSERVICEService groupServiceService { get; set; }
        private IBMSERVERService serverService { get; set; }
        public bool IsClose = true;
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            mainRibbon.MdiMergeStyle = RibbonMdiMergeStyle.Always;
            InitSkins();
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            WindowState = FormWindowState.Maximized;//将该窗体设置为最大化
            mainRibbon.SelectedPageChanged += mainRibbon_SelectedPageChanged;
            WaitCallback wc = (o) => { RefreshMenu(); };
            ThreadPool.QueueUserWorkItem(wc);
            WaitCallback setStatuswc = (o) => { setStatus(); };
            ThreadPool.QueueUserWorkItem(setStatuswc);

            //WaitCallback setStatusDT = (o) => { timer1_Tick(null, null); };
            //ThreadPool.QueueUserWorkItem(setStatusDT);
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Start();

        }

        /// <summary>
        /// 修改状态栏
        /// </summary>
        private void setStatus()
        {
            barStaticItemleft.Caption = String.Format("欢迎使用 {0} {1}", ProjectConfiguration.CopyRight, ProjectConfiguration.ApplicationName);
            //barStaticItemRight.Caption = String.Format("当前用户：{0}  {1}", SessionHelper.LogUserNickName, DateTime.Now.ToLongDateString());
        }
        /// <summary>
        /// 打印按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage != null)
            {
                Form selectForm = xtraTabbedMdiManager1.SelectedPage.MdiChild;
                if (selectForm.GetType().IsSubclassOf(typeof(CoreForm)))
                {
                    ((CoreForm)selectForm).PrintTable();
                }
            }
        }
        /// <summary>
        /// 导出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage != null)
            {
                Form selectForm = xtraTabbedMdiManager1.SelectedPage.MdiChild;
                if (selectForm.GetType().IsSubclassOf(typeof(CoreForm)))
                {
                    ((CoreForm)selectForm).ExportTable();
                }
            }
        }

        /// <summary>
        /// 选中页切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainRibbon_SelectedPageChanged(object sender, EventArgs e)
        {
            Action readPage = () =>
            {
                if (mainRibbon != null && mainRibbon.SelectedPage != null)
                    SessionHelper.SelectPageName = mainRibbon.SelectedPage.Name;
            };
            Invoke(readPage);
        }
        /// <summary>
        /// 初始化皮肤
        /// </summary>
        void InitSkins()
        {
            SkinHelper.InitSkinGallery(skinGalleryBarItem, true);
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
        /// <summary>
        /// 关于按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAboutItemClick(object sender, ItemClickEventArgs e)
        {
            using (MyFrmAbout dlg = new MyFrmAbout(
                String.Format(ProjectConfiguration.CopyRight + "版权所有{0} 违法必究", Environment.NewLine)))
            {
                dlg.ShowDialog();
            }
        }
        /// <summary>
        /// 系统退出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 系统锁定功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (NewLoginForm lfrm = ctx.GetObject("newLoginForm") as NewLoginForm)
            {

                if (lfrm.ShowDialog() == DialogResult.OK)
                {
                    SessionHelper.IsLogIn = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        /// <summary>
        /// 刷新菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshMenu();
            RefreshSelectForm();
        }



        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IApplicationContext ctxTemp = ContextRegistry.GetContext();
                Form showform = ctxTemp.GetObject("BM_021") as Form;
                DialogResult rs = showform.ShowDialog();
                if (rs == System.Windows.Forms.DialogResult.OK || rs == System.Windows.Forms.DialogResult.Cancel)
                {

                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }

        }
        /// <summary>
        /// 选中菜单页变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            GC.Collect();
        }

        #endregion

        #region 用户自定义方法
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //StdScheduler sts = ctx.GetObject("quartzSchedulerFactory") as StdScheduler;
            //if (sts != null && !sts.IsShutdown)
            //{
            //    sts.Shutdown();
            //}
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// 刷新菜单主方法
        /// </summary>
        public void RefreshMenu()
        {
            if (SessionHelper.IsLogIn)
            {
                try
                {
                    Action clearPage = () =>
                    {
                        if (mainRibbon != null)
                        {
                            RibbonPageCollection pagesTemp = mainRibbon.Pages;
                            mainRibbon.Pages.Clear();
                            foreach (RibbonPage page in pagesTemp)
                            {
                                page.Dispose();
                            }
                        }
                    };
                    Invoke(clearPage);
                    IList<BM_MAIN_PAGE> pages = pageService.ExecuteDB_QueryByUser(SessionHelper.LogUserId);
                    RibbonPage pageTempFirst = null;
                    if (pages != null)
                    {
                        foreach (BM_MAIN_PAGE page in pages)
                        {
                            RibbonPage pageTemp = new RibbonPage();
                            RefreshPage(pageTemp, page);
                            if (pageTempFirst == null)
                            {
                                pageTempFirst = pageTemp;
                            }
                        }
                    }
                    Action RefreshPageAction = () =>
                    {
                        if (mainRibbon != null)
                        {
                            if (mainRibbon.SelectedPage == null && pageTempFirst != null)
                            {
                                mainRibbon.SelectedPage = pageTempFirst;
                            }
                            mainRibbon.Refresh();
                        }
                    };
                    Invoke(RefreshPageAction);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }
        /// <summary>
        /// 刷新菜单方法
        /// </summary>
        /// <param name="pageTemp"></param>
        /// <param name="page"></param>
        private void RefreshPage(RibbonPage pageTemp, BM_MAIN_PAGE page)
        {
            pageTemp.Name = page.PageName + DateTime.Now.Ticks;
            if (SessionHelper.SelectPageName == page.PageName)
            {
                Action selectePage = () => { if (mainRibbon != null)  mainRibbon.SelectedPage = pageTemp; };
                Invoke(selectePage);
            }
            pageTemp.Text = page.Text;
            if (page.KeyTip != null && page.KeyTip.Equals(string.Empty))
            {
                pageTemp.KeyTip = page.KeyTip;
            }
            IList<BM_MAIN_GROUP> groups = groupService.ExecuteDB_QueryAllByUserId(new SelectBMMAINGROUPAll() { UserId = SessionHelper.LogUserId, PageId = page.IntId });
            Action addPage = () =>
            {
                if (mainRibbon != null)
                {
                    RefreshGroup(pageTemp, groups);
                    mainRibbon.Pages.Add(pageTemp);
                }
            };
            Invoke(addPage);
        }
        /// <summary>
        /// 刷新组
        /// </summary>
        /// <param name="pageTemp"></param>
        /// <param name="group"></param>
        private void RefreshGroup(RibbonPage pageTemp, IList<BM_MAIN_GROUP> groups)
        {
            if (groups != null)
            {
                foreach (BM_MAIN_GROUP group in groups)
                {
                    RibbonPageGroup rpg = new RibbonPageGroup() { Name = group.GroupName + DateTime.Now.Ticks, Text = group.Text, KeyTip = group.KeyTip };
                    RefreshItems(rpg, group);
                    pageTemp.Groups.Add(rpg);
                }
            }

        }
        /// <summary>
        /// 刷新组内选项
        /// </summary>
        /// <param name="pageTemp"></param>
        /// <param name="groups"></param>
        private void RefreshItems(RibbonPageGroup pageGroupTemp, BM_MAIN_GROUP group)
        {
            try
            {
                log.Info("-----" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                IList<BM_MAIN_GROUP_SERVICE_MENU> services = groupServiceService.ExecuteDB_QueryAllByUserId(new SelectBMMAINGROUPSERVICEAll() { GroupId = group.IntId, UserId = SessionHelper.LogUserId });
                if (services != null)
                {
                    foreach (BM_MAIN_GROUP_SERVICE_MENU service in services)
                    {
                        if (service != null)
                        {
                            BarButtonItem bbi = new BarButtonItem()
                            {
                                Glyph = ((Image)(ResouresHelper.getResoures(service.AssemblyName,
                                service.AssemblyShortName + ".Properties.Resources", service.Glyph))),
                                LargeGlyph = ((Image)(ResouresHelper.getResoures(service.AssemblyName, service.AssemblyShortName + ".Properties.Resources", service.LargeGlyph))),
                                Caption = service.ServiceDes,
                                Name = service.ServiceName + DateTime.Now.Ticks
                            };
                            string ServiceNo = service.ServiceNo;
                            bbi.ItemClick += (o, e) =>
                            {
                                try
                                {
                                    SplashScreenManager.ShowForm(typeof(MySplashScreenForWait), true, false);
                                    IApplicationContext ctxTemp = ContextRegistry.GetContext();
                                    if (xtraTabbedMdiManager1.Pages.Count > 0)
                                    {
                                        foreach (XtraMdiTabPage xtp in xtraTabbedMdiManager1.Pages)
                                        {
                                            if (xtp.MdiChild.GetType().Equals(ctxTemp.GetType(ServiceNo)))
                                            {
                                                //如果存在了，则查找到当前tabpage页并显示
                                                //((CoreForm)xtp.MdiChild).ReLoadForm();
                                                xtp.MdiChild.Show();
                                                xtraTabbedMdiManager1.SelectedPage = xtp;
                                                SplashScreenManager.CloseForm();
                                                return;
                                            }
                                        }
                                    }
                                    Form showform = ctxTemp.GetObject(ServiceNo) as Form;
                                    showform.MdiParent = this;
                                    showform.Show();
                                    SplashScreenManager.CloseForm();
                                }
                                catch (Exception ex)
                                {
                                    SplashScreenManager.CloseForm();
                                    MessageDxUtil.ShowError(ex.Message);
                                }
                            };
                            pageGroupTemp.ItemLinks.Add(bbi);
                        }
                    }
                }
                log.Info("-----" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        /// <summary>
        /// 刷新当前页
        /// </summary>
        private void RefreshSelectForm()
        {
            if (xtraTabbedMdiManager1.SelectedPage != null)
            {
                Form selectForm = xtraTabbedMdiManager1.SelectedPage.MdiChild;
                if (selectForm.GetType().IsSubclassOf(typeof(CoreForm)))
                {
                    ((CoreForm)selectForm).ReLoadForm();
                }

            }

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            barStaticItemRight.Caption = String.Format("当前用户：{0}  {1}", SessionHelper.LogUserNickName, string.Format("{0:F}", DateTime.Now));
        }

        private void xtraTabbedMdiManager1_BeginFloating(object sender, FloatingCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
