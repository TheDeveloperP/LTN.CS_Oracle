using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.ServiceInterface.Interface;
using LTN.CS.SCMForm.CustomUI;
using LTN.CS.SCMHardSDK.Comm;
using LTN.CS.SCMService.SM.Interface;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PondMonitor_Form : CoreForm
    {
        private ChannelFactory<IDM_PondSite_Monitor_WCFService> PondSite_Monitorfactory { get; set; }
        public IDM_PondSite_Monitor_WCFService pondSiteMonitorWCFservice { get; set; }
        private IList<DM_PondSite_Info_WCF> PondSite_Rs { get; set; }
        private ISM_PoundSite_InfoService pondSiteInfoService { get; set; }
        private IApplicationContext ctx = ContextRegistry.GetContext();
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        private int PondSiteCount = 0;
        private int flag = 0;
        private int culumn = -1;
        public PM_PondMonitor_Form()
        {
            InitializeComponent();
        }


        private void PM_PondMonitor_Form_Shown(object sender, EventArgs e)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    InitForm();
                }; Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        private void InitForm()
        {
            try
            {
                PondSite_Rs = pondSiteInfoService.ExecuteDB_QueryAll2();
                PondSite_Rs = PondSite_Rs == null ? null : PondSite_Rs.Where(e => e.PondSiteType != null && e.PondSiteType.EnumValue == SiteType.CarPound).ToList();
                if (PondSite_Rs != null)
                {
                    PondSiteCount = PondSite_Rs.Count;
                    ShowCustomShowcontrol();
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void ShowCustomShowcontrol()
        {
            int pondSite_X = 20;
            int pondSite_Y = 0;
            if (PondSite_Rs != null)
            {
                for(int i=0;i<PondSiteCount ; i++)
                {
                    CustomShow cs = new CustomShow();
                    cs.PondId = PondSite_Rs[i].IntId;
                    if (i % 4 == 0)
                    {
                        flag = 0;
                        culumn += 1;
                    }
                    else
                    {
                        flag += 1;
                    }
                    //cs.Size = new Size(188, 181);
                    pondSite_X = (cs.Width+20) * flag+80;
                    pondSite_Y = (cs.Height+10) * culumn+10;
                    cs.Location = new Point(pondSite_X, pondSite_Y);                    
                    Controls.Add(cs);
                }
            }
        }

        private void PM_PondMonitor_Form_Load(object sender, EventArgs e)
        {
            //Panel pa = new Panel();
            //pa.Location = new Point(0, 0);
            //pa.Dock = DockStyle.Fill;
            //this.Controls.Add(pa);
        }
    }
}
