using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Spring.Context;
using Spring.Context.Support;
using DevExpress.XtraSplashScreen;
using LTN.CS.Base;
using LTN.CS.Core.Helper;


namespace LTN.CS.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out flag);
            if (flag)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SplashScreenManager.ShowForm(typeof(LTN.CS.Base.CustomFrm.MySplashScreen), true, false);
                SkinManager.EnableFormSkins();
                BonusSkins.Register();
            //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                IApplicationContext ctx = ContextRegistry.GetContext();
                MainForm mainform = ctx.GetObject("mainForm") as MainForm;
                using (NewLoginForm lfrm = ctx.GetObject("newLoginForm") as NewLoginForm)
                {
                    SplashScreenManager.CloseForm();
                    if (lfrm.ShowDialog() == DialogResult.OK)
                    {
                        SessionHelper.IsLogIn = true;
                    //获取系统信息
                    System.OperatingSystem osInfo = System.Environment.OSVersion;
                    //获取操作系统ID
                    System.PlatformID platformID = osInfo.Platform;
                    //获取主版本号
                    int versionMajor = osInfo.Version.Major;
                    if (versionMajor == 6)
                    {
                        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new System.Drawing.Font("新宋体", 9);
                        DevExpress.XtraEditors.WindowsFormsSettings.DefaultPrintFont = new System.Drawing.Font("新宋体", 9);

                    }
                   // Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
                  //  Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
                    Application.Run(mainform);
                    }
                    else
                    {
                        mainform.Dispose();
                        Application.Exit();
                    }
                }
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(null, "相同的程序已经在运行了,请不要同时运行多个程序!\n\n这个程序即将退出!",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            //bool flag;
            //System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out flag);
            //if (flag)
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    SplashScreenManager.ShowForm(typeof(LTN.CS.Base.CustomFrm.MySplashScreen), true, false);
            //    SkinManager.EnableFormSkins();
            //    BonusSkins.Register();
            //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");

            //    DevExpress.Skins.SkinManager.EnableFormSkins();
            //    DevExpress.UserSkins.BonusSkins.Register();
            //    UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //    IApplicationContext ctx = ContextRegistry.GetContext();
            //    MainForm mainform = ctx.GetObject("mainForm") as MainForm;
                //string str=MD5Helper.DESEncrypt("server=172.18.43.89;database=CS_Frame;uid=sa;pwd=cmmiml3", "87654321");
                //Person person = new Person() { FirstName = "123" };
                //IPersonService personService = ctx.GetObject("PersonService") as IPersonService;
                //personService.ExecuteDB_Insert(person);

                //ITS_Site_InfoService siteService = ctx.GetObject("TS_Site_InfoService") as ITS_Site_InfoService;
                //IList<TS_Site_Info> rss = siteService.ExecuteDB_QueryAll();

                //IDeptService siteService = ctx.GetObject("DeptService") as IDeptService;
                //IList<DEPT1> rss = siteService.ExecuteDB_QueryAll();

                //DM_PondSite_Monitor_WCF site = new DM_PondSite_Monitor_WCF();
                //site.PondId = 5;
                //site.PondSiteNo = "222234555";
                //site.PrintOneStatus = new DeviceStatusObj((Int32)DeviceStatus.GreenLight);
                //Random rd = new Random();
                //site.IntId = rd.Next(10000);
                //site.PondSiteName = "123456";
                //ThreadStart ts = () =>
                //{
                //    while (true)
                //    {
                //        using (ChannelFactory<IDM_PondSite_Monitor_WCFService> factory = ctx.GetObject("DM_PondSite_Monitor_WCFServiceClient") as ChannelFactory<IDM_PondSite_Monitor_WCFService>)
                //        {
                //            IDM_PondSite_Monitor_WCFService service = factory.CreateChannel();
                //            int rs = service.UpdateSiteMonitor(site);
                //            factory.Close();
                //        }
                //        Thread.Sleep(1000);
                //    }
                //};
                //Thread td =new Thread(ts);

                //td.Start();

                //Random rd = new Random();
                //DM_PondSite_Info_WCF site = new DM_PondSite_Info_WCF();
                //site.IntId = rd.Next(10000);
                //using (ChannelFactory<IDM_PondSite_InfoWCFService> factory = ctx.GetObject("DM_PondSite_InfoWCFServiceClient") as ChannelFactory<IDM_PondSite_InfoWCFService>)
                //{
                //    IDM_PondSite_InfoWCFService service = factory.CreateChannel();
                //    service.UpdatePondSite(site);
                //    factory.Close();
                //}
                //IDM_Site_InfoWCFService service = factory.CreateChannel();
                //service.CreateSite(site);
                //factory.Close();
                //ChannelFactoryObject<IDM_Site_InfoWCFService> factory2 = siteService2 as ChannelFactoryObject<IDM_Site_InfoWCFService>;
                //IDM_Site_InfoWCFService service2 = factory2.CreateChannel();
                //service2.CreateSite(site);
                //factory2.Close(); 
                //IList<DeviceStatusObj> rss = DeviceStatusObj.GetDeviceStatusData();

                //Stopwatch stopwatch = new Stopwatch();


                //DM_Message_To_Site_WCF message = new DM_Message_To_Site_WCF();
                //message.PondId = 1;
                //message.TaskId = 2;
                //message.SiteId = 3;
                //message.Command = new BaseOperateMethodObj((int)BaseOperateMethod.ClearZero);
                //message.Message = "55555555555555555555555";
                //using (ChannelFactory<IDM_Message_To_SiteWCFService> factory = ctx.GetObject("DM_Message_To_SiteWCFServiceClient") as ChannelFactory<IDM_Message_To_SiteWCFService>)
                //{
                //    IDM_Message_To_SiteWCFService service = factory.CreateChannel();
                //    string msg = string.Empty;
                //    stopwatch.Start(); //  开始监视代码运行时间
                //    int rs = service.CreateSiteMessage(message, out msg);
                //    stopwatch.Stop(); //  停止监视
                //    IList<DM_Message_To_Site_WCF> msgs = service.GetSiteMessage(3, 2, null);
                //    factory.Close();
                //}
                //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
                //double hours = timespan.TotalHours; // 总小时
                //double minutes = timespan.TotalMinutes;  // 总分钟
                //double seconds = timespan.TotalSeconds;  //  总秒数
                //double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数

                //Console.WriteLine("Elapsed: {0}", timespan);
                //Console.WriteLine("in hours       :" + hours);
                //Console.WriteLine("in minutes     :" + minutes);
                //Console.WriteLine("in seconds     :" + seconds);
                //Console.WriteLine("in milliseconds:" + milliseconds); 


                //using (ChannelFactory<IDM_TaskWCFService> factory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>)
                //{
                //    IDM_TaskWCFService service = factory.CreateChannel();
                //    DM_Task_WCF task = new DM_Task_WCF();
                //    task.PondId = 2;
                //    task.TaskData = "111111111";
                //    task.IsKeep = new EntityInt(0);
                //    //task.SiteId = 2;
                //    task.TaskType = new SiteTypeObj((int)SiteType.StaticMaterial);
                //    task.IsAutoWeight = new EntityInt(0);
                //    int taskid;
                //    string errmsg;
                //    //service.DeleteTaskRoute(83,2,2,out errmsg);
                //    service.CreateTask(task,out taskid,out errmsg);
                //    string msg = string.Empty;
                //    //stopwatch.Start(); //  开始监视代码运行时间
                //    //int rs = service.CreateSiteMessage(message, out msg);
                //    //stopwatch.Stop(); //  停止监视
                //    //IList<DM_Message_To_Site_WCF> msgs = service.GetSiteMessage(3, 2, null);
                //    factory.Close();
                //}
            //    using (NewLoginForm lfrm = ctx.GetObject("newLoginForm") as NewLoginForm)
            //    {
            //        SplashScreenManager.CloseForm();
            //        if (lfrm.ShowDialog() == DialogResult.OK)
            //        {
            //            SessionHelper.IsLogIn = true;
            //            Application.Run(mainform);
            //        }
            //        else
            //        {
            //            mainform.Dispose();
            //            Application.Exit();
            //        }
            //    }
            //    mutex.ReleaseMutex();
            //}
            //else
            //{
            //    MessageBox.Show(null, "相同的程序已经在运行了,请不要同时运行多个程序!\n\n这个程序即将退出!",
            //        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    Application.Exit();
            //}
        }
    }
}