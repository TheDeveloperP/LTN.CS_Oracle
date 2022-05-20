using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.ServiceInterface.Entity;
using Spring.Context;
using Spring.Context.Support;
using System.Threading;
using LTN.CS.Base.Common;
using LTN.CS.SCMService.SM.Interface;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Interface;

namespace LTN.CS.SCMForm.CustomUI
{
    public partial class CustomShow : UserControl
    {
        //磅点id
        private int _pondid;
        public int PondId
        {
            get
            {
                return _pondid;
            }
            set
            {
                _pondid = value;
                InitUserControl();
            }
        }
        private bool _IsAutoRefresh = true;
        public bool IsAutoRefresh
        {
            get
            {
                return _IsAutoRefresh;
            }
            set
            {
                _IsAutoRefresh = value;
                if (PondSite_Info == null)
                {
                    throw new Exception("PondSiteId 错误");
                }
                else if (_IsAutoRefresh && PondSite_Info != null)
                {
                    if (PondSite_Info != null)
                    {
                        timer1.Interval = TimerInterval;
                        timer1.Start();
                    }
                }
                else
                {
                    timer1.Stop();
                }
            }
        }
        private int _TimerInterval;
        [Description("设置刷新间隔时间")]　//显示在属性设计视图中的描述
        [DefaultValue(typeof(int), "10000")]//给予初始值
        public int TimerInterval
        {
            get
            {
                return _TimerInterval;
            }
            set
            {
                _TimerInterval = value;
            }
        }
        private DeviceStatusObj _InfraRedOneStatus;
        public DeviceStatusObj InfraRedOneStatus
        {
            get
            {
                return _InfraRedOneStatus;
            }
            set
            {
                _InfraRedOneStatus = value;
                if (value != null)
                {
                    //synchronizationContext.Send(a =>
                    //{
                        if (_InfraRedOneStatus.IntValue == 1)
                        {
                            pnl_AlarmLeft.BackColor = Color.Lime;                            
                        }
                        else
                        {
                            pnl_AlarmLeft.BackColor = Color.Red;                            
                        }                       
                    //}, null);
                }
            }
        }
        private DeviceStatusObj _InfraRedTwoStatus;
        public DeviceStatusObj InfraRedTwoStatus
        {
            get
            {
                return _InfraRedTwoStatus;
            }
            set
            {
                _InfraRedTwoStatus = value;
                if (value != null)
                {
                    //synchronizationContext.Send(a =>
                    //{
                        if (_InfraRedTwoStatus.IntValue == 1)
                        {
                            pnl_AlarmRight.BackColor = Color.Lime;
                        }
                        else
                        {
                            pnl_AlarmRight.BackColor = Color.Red;
                        }
                    //}, null);
                }
            }
        }
        private decimal _Weight;
        public decimal Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
                //synchronizationContext.Send(a =>
                //{
                 lbl_weight.Text = value == 0 ? "000000" : value.ToString();
                //}, null);
            }
        }
        private DeviceStatusObj _PrintOneStatus;
        public DeviceStatusObj PrintOneStatus
        {
            get
            {
                return _PrintOneStatus;
            }
            set
            {
                _PrintOneStatus = value;
                if(_PrintOneStatus == null)
                {
                    _PrintOneStatus = new DeviceStatusObj();
                }
                //synchronizationContext.Send(a =>
                //{
                    lbl_printone.Text = _PrintOneStatus.DeviceStatusDesc;
                //}, null);
                if (lbl_printone.Text == "启用")
                {
                    lbl_printone.ForeColor = Color.Lime;
                }
                else
                {
                    lbl_printone.ForeColor = Color.Red;
                }
               
            }
        }
        private DeviceStatusObj _PrintTwoStatus;
        public DeviceStatusObj PrintTwoStatus
        {
            get
            {
                return _PrintTwoStatus;
            }
            set
            {
                _PrintTwoStatus = value;
                if(_PrintTwoStatus == null)
                {
                    _PrintTwoStatus = new DeviceStatusObj();
                }
                //synchronizationContext.Send(a =>
                //{
                    lbl_printtwo.Text = _PrintTwoStatus.DeviceStatusDesc;
                if (lbl_printtwo.Text == "启用")
                {
                    lbl_printtwo.ForeColor = Color.Lime;
                }
                else
                {
                    lbl_printtwo.ForeColor = Color.Red;
                }
                //}, null);

            }
        }
        private DM_PondSite_Monitor_WCF _PondSite_Monitor;
        public DM_PondSite_Monitor_WCF PondSite_Monitor
        {
            get
            {
                return _PondSite_Monitor;
            }
            set
            {
                _PondSite_Monitor = value;
                if (value != null)
                {
                    Weight = _PondSite_Monitor.MeterSumWeight;
                    InfraRedOneStatus = _PondSite_Monitor.InfraRedOneStatus;
                    InfraRedTwoStatus = _PondSite_Monitor.InfraRedTwoStatus;
                    PrintOneStatus = _PondSite_Monitor.PrintOneStatus;
                    PrintTwoStatus = _PondSite_Monitor.PrintTwoStatus;
                }
                else
                {
                    Weight = 0;
                    InfraRedOneStatus = new DeviceStatusObj(10);
                    InfraRedTwoStatus = new DeviceStatusObj(10);
                    PrintOneStatus = new DeviceStatusObj(10);
                    PrintTwoStatus = new DeviceStatusObj(10);
                }
            }
        }
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        private DM_PondSite_Info_WCF PondSite_Info { get; set; }
        public ISM_PoundSite_InfoService poundSiteService { get; set; }
        private IDM_PondSite_Monitor_WCFService MonitorService { get; set; }
        ChannelFactory<IDM_PondSite_Monitor_WCFService> MonitorFactory { get; set; }
        ChannelFactory<IDM_TaskWCFService> TaskFactory { get; set; }
        private IApplicationContext ctx = ContextRegistry.GetContext();
        public CustomShow()
        {
            InitializeComponent();
        }


        private void InitUserControl()
        {
            poundSiteService = ctx.GetObject("SM_PoundSite_InfoService") as ISM_PoundSite_InfoService;
            if (MonitorFactory == null)
            {
                MonitorFactory = ctx.GetObject("DM_PondSite_Monitor_WCFServiceClient") as ChannelFactory<IDM_PondSite_Monitor_WCFService>;
            }
            if (MonitorService == null)
            {
                MonitorService = MonitorFactory.CreateChannel();
            }


            WaitCallback wc = (o) =>
            {
                try
                {
                    PondSite_Info = poundSiteService.ExecuteDB_QueryByIntId(PondId);
                    if (PondSite_Info != null)
                    {
                        synchronizationContext.Send(a =>
                        {
                            lbl_pondname.Text = PondSite_Info.PondSiteName;
                            timer1_Tick(null, null);
                        }, null);
                        if (IsAutoRefresh)
                        {
                            timer1.Start();
                        }                           
                            
                    }
                    else
                    {
                        throw new Exception("PondSiteId 错误");
                    }
                }
                catch (Exception ex)
                {

                }

            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        private object Locker2 = new object();
        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (Locker2)
            {
                try
                {
                    PondSite_Monitor = MonitorService.QueryMonitorById(PondSite_Info.IntId);
                    if (PondSite_Monitor == null)
                    {
                        PondSite_Monitor = new DM_PondSite_Monitor_WCF();
                    }
                    else
                    {
                        Weight = PondSite_Monitor.MeterOneWeight;
                        InfraRedOneStatus = PondSite_Monitor.InfraRedOneStatus;
                        InfraRedTwoStatus = PondSite_Monitor.InfraRedTwoStatus;
                        PrintOneStatus = PondSite_Monitor.PrintOneStatus;
                        PrintTwoStatus = PondSite_Monitor.PrintTwoStatus;
                                         
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
