using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Base.Common;
using LTN.CS.Base.Helper;
using LTN.CS.Base.HelperCommon;
using LTN.CS.Base.Interface;
using LTN.CS.Base.ServiceInterface.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.API;
using LTN.CS.SCMHardSDK.Comm;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.SCMForm.SM;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.Enum;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.PT;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMForm.Comm;
using System.Net;
using System.IO;

namespace LTN.CS.SCMForm.PM
{
    public partial class TruckMeasureForm_New : CoreForm, IBaseOperate
    {
        private object IsWorkingLock = new object();
        private ChannelFactory<IDM_Site_InfoWCFService> Site_Infofactory { get; set; }
        private ChannelFactory<IDM_PondSite_Monitor_WCFService> PondSite_Monitorfactory { get; set; }
        private ChannelFactory<IDM_Message_To_SiteWCFService> Message_To_Sitefactory { get; set; }
        private ChannelFactory<IDM_Message_To_PondSiteWCFService> Message_To_PondSitefactory { get; set; }
        private ChannelFactory<IDM_TaskWCFService> Taskfactory { get; set; }
        public IDM_Site_InfoWCFService SiteInfoService { get; set; }
        public IDM_PondSite_Monitor_WCFService pondSiteMonitorWCFservice { get; set; }
        public IDM_Message_To_SiteWCFService messageToSiteWCFservice { get; set; }
        public IDM_Message_To_PondSiteWCFService messageTopondWCFservice { get; set; }
        public IDM_TaskWCFService taskWCFservice { get; set; }
        private DM_Route_WCF route { get; set; }
        private DM_PondSite_Info_WCF pondSiteInfo { get; set; }
        private string DialogStr = "任务提示";
        private string BreakTaskStr = "计量任务中断请重新计量";
        [DllImportAttribute("Kernel32.dll")]
        public static extern void GetLocalTime(SystemTime st);
        [DllImportAttribute("Kernel32.dll")]
        public static extern void SetLocalTime(SystemTime st);
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        private IApplicationContext ctx = ContextRegistry.GetContext();
        private System.Threading.Timer timer_FormMessage = null;
        private System.Threading.Timer timer_SiteUpload = null;
        private System.Threading.Timer timer_ForDownLoad = null;
        private int IsCan_Down = 0;
        private int IsCan_Upload = 0;
        private bool isUnrecive = false;
        private bool isCanEnd = false;
        private TaskTruckData taskTruckData { get; set; }
        private PT_TruckMeasurePlan truckMeasure { get; set; }
        private PM_Bill_Truck billTruck { get; set; }
        private PM_Bill_Truck ptruck { get; set; }
        private PM_Bill_Truck oneMoreTruck { get; set; }
        private SM_TareWeight tareWeight { get; set; }
        private string carName = string.Empty;
        private string logic = string.Empty;
        private bool IsAutoWeight = false;
        private SpeechSynthesizer _voice = new SpeechSynthesizer();
        private string strFilePath = string.Empty;

        private ISM_Site_InfoService seatService { get; set; }
        private ISM_PoundSite_InfoService pondSiteInfoService { get; set; }
        private IPM_Bill_TruckService billTruckService { get; set; }
        private ISM_TareWeightService tareWeightService { get; set; }
        private IPT_TruckMeasurePlanService truckMeasureService { get; set; }
        private ISM_BlackListService blackService { get; set; }
        public ISM_Dvr_InfoService dvrService { get; set; }
        public ISM_ReasonForNoAutoService reasonForService { get; set; }
        public ISM_JZXH_InfoService JZXHService { get; set; }
        //湖大集装箱服务
        public ISM_ReeferContainerNo_InfoService HudaJZXHService { get; set; }
        public ISM_Container_RateService ContainerRateService { get; set; }
        public SM_JZXH_Info jzxhInfo { get; set; }
        private bool isJzxh = false;
        //湖大集装箱信息
        public SM_JZX_Huda_Message hudaJzxInfo { get; set; }
        private bool isHudaJzxh = false;
        public bool isNeedTips = true;
        //皮重均值提醒标识
        public int isExceed = 0;

        public TruckMeasureForm_New()
        {
            InitializeComponent();
        }

        private void btn_Requery_Click(object sender, EventArgs e)
        {
            //SpeakTxtLog("您有新任务请接收"); //语音提示
            //ReciveNewTask("{\"<WeightType>k__BackingField\":1,\"<PlanId>k__BackingField\":0,\"<SelectCarNo>k__BackingField\":\"苏A12345\",\"<CameraCarNo>k__BackingField\":\"\",\"<RfidCarNo>k__BackingField\":\"\",\"<Reason>k__BackingField\":\"12345\"}", 1, 1, 1, "");

            /*
            TaskTruckData ts = new TaskTruckData();
            ts.WeightType = 2;
            ts.PlanId = 1770;
            ts.SelectCarNo = "苏A12345";
            ts.CameraCarNo = string.Empty;
            ts.RfidCarNo = string.Empty;
            ts.Reason = string.Empty;
            string str = MyJsonHelper.SerializeObject(ts);
            ReciveNewTask(str, 1, 270, 1, "");
             * */
        }

        #region  处理错磅
        private static object locker = new object();

        private static bool _IsTasking = false;

        private bool IsTasking()
        {

            lock (locker)
            {
                if (_IsTasking == true)
                {
                    return _IsTasking;
                }
                else
                {
                    _IsTasking = true;
                    return false;
                }
            }

        }
        //private object locker = new object();

        //private bool _IsTasking = false;

        //private bool IsTasking
        //{
        //    get
        //    {
        //        lock (locker)
        //        {
        //            if (_IsTasking == true)
        //            {
        //                return _IsTasking;
        //            }
        //            else
        //            {
        //                _IsTasking = true;
        //                return false;
        //            }
        //        }
        //    }
        //    set { _IsTasking = value; }
        //}

        #endregion
        #region  任务调度接口实现-常用
        public void ReciveNewTask(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            synchronizationContext.Send(a =>
            {
                if (!IsTasking() || (pondId == MyNumberHelper.ConvertToInt32(txt_poundsite.EditValue)))
                {
                    SpeakTxtLog("您有新任务请接收"); //语音提示
                    var rs = DialogResult.Yes;
                    DM_Route_WCF routeIskeep = null;
                    if (!(route != null && route.IsKeep != null && route.IsKeep.EntityValue == 1))
                    {
                        rs = ShowYesOrNo();
                    }
                    else
                    {
                        routeIskeep = route;
                    }
                    if (rs == DialogResult.Yes)
                    {
                        try
                        {
                            ClearBuffData();
                            if (routeIskeep != null)
                            {
                                route = routeIskeep;
                            }
                            if (route == null || (route.IsKeep != null && route.IsKeep.EntityValue == 0))
                            {
                                route = new DM_Route_WCF() { TaskId = taskId, PondId = pondId, SiteId = siteId, TaskNo = taskNo, IsKeep = new EntityInt(0) };
                            }
                            if (route != null && (route.IsKeep != null && route.IsKeep.EntityValue == 0))
                            {
                                ReceiveTaskStart();
                            }
                            //司磅员选择连接的磅房
                            txt_poundsite.EditValue = pondId;
                            pondSiteInfo = pondSiteInfoService.ExecuteDB_QueryByIntId(pondId);

                            if (pondSiteInfo != null)
                            {
                                if (_videoStatus)
                                {
                                    VideoStop();
                                    Thread.Sleep(1000);
                                }
                                VideoPlay();
                            }
                            //taskTruckData = (TaskTruckData)MyJsonHelper.JsonToObject(data, taskTruckData);//0求助 1皮重 2毛重
                            taskTruckData = MyJsonHelper.DeserializeJsonToObject<TaskTruckData>(data);
                            if (taskTruckData != null)
                            {
                                //接受到任务，显示任务信息
                                if (taskTruckData.WeightType == 0) //求助任务
                                {
                                    showHelp();
                                }
                                else if (taskTruckData.WeightType == 1)//皮重
                                {
                                    showSelectTare();
                                }
                                else if (taskTruckData.WeightType == 2)//毛重
                                {
                                    //根据计划id计划
                                    truckMeasure = truckMeasureService.ExecuteDB_QueryTruckMeasurePlanByPlanId(taskTruckData.PlanId);
                                    showSelectPlan(truckMeasure, pondSiteInfo.PondSiteNo);
                                }
                                if (pondSiteInfo == null || pondSiteInfo.IntId < 1)
                                {
                                    ShowTxtLog("磅点信息不存在，请结束任务重新过磅！");
                                    btnGrossWeight.Enabled = false;
                                    btnTareWeight.Enabled = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _IsTasking = false;
                            ShowTxtLog(ex.Message);
                            ShowTxtLog("任务接收失败");
                        }
                    }
                    else
                    {
                        if (!isUnrecive)
                        {
                            if (route == null || (route.IsKeep != null && route.IsKeep.EntityValue == 0))
                            {
                                route = new DM_Route_WCF() { TaskId = taskId, PondId = pondId, SiteId = siteId, TaskNo = taskNo, IsKeep = new EntityInt(0) };
                            }
                            UnReceiveTaskStart();
                            ClearBuffData();
                            ClearUI();
                        }
                        isUnrecive = false;
                    }
                }
            }, null);
        }
        #endregion

        private void SpeakTxtLog(string errStr)
        {
            Thread rs = new Thread(() =>
            {
                try
                {
                    _voice.Speak(errStr);
                }
                catch (Exception ex)
                {

                }
            });
            rs.Start();
        }

        #region  界面操作
        //选择计划单号--毛重
        private void txt_PlanNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (route != null)
            {
                PT_TruckMeasureUsingPlan_Form sos = new PT_TruckMeasureUsingPlan_Form(truckMeasureService);
                if (sos.ShowDialog() == DialogResult.OK)
                {
                    if (sos.selectEntity != null && sos.selectEntity.I_INTID != 0)
                    {
                        ClearUI();
                        truckMeasure = sos.selectEntity;
                        string pondid = pondSiteInfo.PondSiteNo;
                        showSelectPlan(truckMeasure, pondid);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        //画面关闭
        private void TruckMeasureForm_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (PondDataBufferLocal.SiteInfo != null)
                {
                    PondDataBufferLocal.SiteInfo.SiteStatus = new SiteStatusObj((int)SiteStatus.Disable);
                }
                CloseSite();
                EndRoute(route == null ? 0 : route.TaskId, BreakTaskStr);
                if (timer_FormMessage != null)
                {
                    timer_FormMessage.Dispose();
                }
                if (timer_SiteUpload != null)
                {
                    timer_SiteUpload.Dispose();
                }
                if (timer_ForDownLoad != null)
                {
                    timer_ForDownLoad.Dispose();
                }
                try
                {
                    if (Message_To_PondSitefactory != null && Message_To_PondSitefactory.State == CommunicationState.Opened)
                    {
                        Message_To_PondSitefactory.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    if (Message_To_Sitefactory != null && Message_To_Sitefactory.State == CommunicationState.Opened)
                    {
                        Message_To_Sitefactory.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    if (Site_Infofactory != null)
                    {
                        Site_Infofactory.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    if (PondSite_Monitorfactory != null)
                    {
                        PondSite_Monitorfactory.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    if (Taskfactory != null)
                    {
                        Taskfactory.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {

            }
        }

        //画面加载
        private void TruckMeasureForm_New_Shown(object sender, EventArgs e)
        {
            if (SessionHelper.IP == "unknow")
            {
                PondDataBuffer.PondStatus = new DeviceStatusObj((int)DeviceStatus.Disable);
                PondDataBuffer.IsConnectedDB = false;
                groupBox4.Enabled = false;
            }
            else
            {
                try
                {
                    taskTruckData = new TaskTruckData();
                    truckMeasure = new PT_TruckMeasurePlan();
                    billTruck = new PM_Bill_Truck();
                    ptruck = new PM_Bill_Truck();
                    oneMoreTruck = new PM_Bill_Truck();
                    tareWeight = new SM_TareWeight();
                    jzxhInfo = new SM_JZXH_Info();
                    //湖大集装箱
                    hudaJzxInfo = new SM_JZX_Huda_Message();

                    IList<DM_Site_Info_WCF> sites = seatService.ExecuteDB_QueryBySiteIp2(SessionHelper.IP);
                    //IList<DM_Site_Info_WCF> sites = seatService.ExecuteDB_QueryBySiteIp2("10.199.13.178");
                    if (sites != null && sites.Count == 1)
                    {
                        PondDataBufferLocal.SiteInfo = sites[0];
                        PondDataBufferLocal.SiteInfo.SiteStatus = new SiteStatusObj((int)SiteStatus.HangUp);
                        Thread td = new Thread(() =>
                        {
                            Settxt_poundsiteData();
                        });
                        td.Start();
                        PondDataBuffer.IsConnectedDB = true;
                        timer_FormMessage = new System.Threading.Timer(Timer_ForFormMessageCallBack, null, 4000, 900); //定时接收消息
                        timer_SiteUpload = new System.Threading.Timer(Timer_ForUploadCallBack, null, 2000, 5000);//修改坐席状态
                        timer_ForDownLoad = new System.Threading.Timer(Timer_ForDownLoadCallBack, null, 2000, 1000);//获取仪表重量 和红外光栅状态
                        InitSite();
                        SetDBTime();
                        //设置打印机选择栏
                        setPrintSelector();
                    }
                    else
                    {
                        groupBox4.Enabled = false;
                        ShowTxtLog("无法找到该坐席信息");
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        #region 任务操作
        // 定时接收任务调度消息
        private void Timer_ForFormMessageCallBack(object args)
        {
            //lock (IsWorkingLock)
            //{
            try
            {
                if (PondDataBuffer.IsConnectedDB)
                {
                    if (Message_To_Sitefactory == null)
                    {
                        Message_To_Sitefactory = ctx.GetObject("DM_Message_To_SiteWCFServiceClient") as ChannelFactory<IDM_Message_To_SiteWCFService>;
                    }
                    if (messageToSiteWCFservice == null)
                    {
                        messageToSiteWCFservice = Message_To_Sitefactory.CreateChannel();
                    }
                    if (PondDataBufferLocal.SiteInfo != null)
                    {
                        var rs = messageToSiteWCFservice.GetSiteMessage(PondDataBufferLocal.SiteInfo.IntId, null, null);//获取磅点消息
                        if (rs != null && rs.Count > 0)
                        {
                            for (int i = 0; i < rs.Count(); i++)
                            {
                                var testMethod = typeof(IBaseOperate).GetMethod(rs[i].Command.BaseOperateMethodDesc);
                                testMethod.Invoke(this, new object[] { rs[i].Message, rs[i].TaskId, rs[i].PondId, rs[i].SiteId, rs[i].TaskNo });
                            }
                        }
                    }
                    Interlocked.Exchange(ref PondDataBuffer.IsIn_FormMessage, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref PondDataBuffer.IsIn_FormMessage, 0);
                if (Message_To_Sitefactory != null)
                {
                    try
                    {
                        Message_To_Sitefactory.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
                Message_To_Sitefactory = null;
                messageToSiteWCFservice = null;
            }
            //}
        }

        // 修改坐席状态
        private void Timer_ForUploadCallBack(object args)
        {
            try
            {
                if (PondDataBuffer.IsConnectedDB)
                {
                    if (Interlocked.Exchange(ref IsCan_Upload, 1) == 0)
                    {
                        if (PondDataBufferLocal.SiteInfo != null)
                        {
                            if (Site_Infofactory == null)
                            {
                                Site_Infofactory = ctx.GetObject("DM_Site_InfoWCFServiceClient") as ChannelFactory<IDM_Site_InfoWCFService>;
                            }
                            if (Site_Infofactory != null)
                            {
                                if (SiteInfoService == null) SiteInfoService = Site_Infofactory.CreateChannel();
                            }
                            SiteInfoService.UpdateSiteStatus(PondDataBufferLocal.SiteInfo.IntId, PondDataBufferLocal.SiteInfo.SiteStatus);
                        }
                        Interlocked.Exchange(ref IsCan_Upload, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref IsCan_Upload, 0);
                SiteInfoService = null;
                Site_Infofactory = null;
            }
        }
        
        // 连接磅房后定时获取磅房仪表重量、红外光栅信息
        private void Timer_ForDownLoadCallBack(object args)
        {
            try
            {
                if (PondDataBuffer.IsConnectedDB)
                {
                    if (Interlocked.Exchange(ref IsCan_Down, 1) == 0)
                    {
                        if (route != null)
                        {
                            if (PondSite_Monitorfactory == null)
                            {
                                PondSite_Monitorfactory = ctx.GetObject("DM_PondSite_Monitor_WCFServiceClient") as ChannelFactory<IDM_PondSite_Monitor_WCFService>;
                            }
                            if (PondSite_Monitorfactory != null)
                            {
                                if (pondSiteMonitorWCFservice == null) pondSiteMonitorWCFservice = PondSite_Monitorfactory.CreateChannel();
                            }
                            DM_PondSite_Monitor_WCF monitor = pondSiteMonitorWCFservice.QueryMonitorById(route.PondId);
                            if (monitor != null && monitor.PondId > 0)
                            {
                                PondDataBufferLocal.PondHardInfoForSite = monitor;
                                if (PondDataBufferLocal.PondHardInfoForSite != null)
                                {
                                    synchronizationContext.Send(a =>
                                    {
                                        try
                                        {
                                            if (PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight.ToString() != null)
                                            {

                                                //新增重量不稳定时进行提醒
                                                if (!string.IsNullOrEmpty(lblWeight.Text) && isNeedTips == true && taskTruckData != null)
                                                {
                                                    decimal oldWeightValue = Convert.ToDecimal(lblWeight.Text);
                                                    decimal newWeightValue = Convert.ToDecimal(PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight);
                                                    if (oldWeightValue > 0 && ((newWeightValue - oldWeightValue) > 100 || (newWeightValue - oldWeightValue < -100)))
                                                    {
                                                        SpeakTxtLog("过磅重量不稳定");
                                                        MessageBox.Show("该车过磅重量不稳定，请注意");
                                                        isNeedTips = false;
                                                    }
                                                }
                                                
                                                lblWeight.Text = Convert.ToDecimal(PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight).ToString();


                                            }
                                            if (PondDataBufferLocal.PondHardInfoForSite.MeterOneStatus != null)
                                            {
                                                //if (PondDataBufferLocal.PondHardInfoForSite.MeterOneStatus.EnumValue == DeviceStatus.Working)
                                                //{
                                                //    lbl_MetalStatus.Text = "仪表：正常";
                                                //}
                                                //else if (PondDataBufferLocal.PondHardInfoForSite.MeterOneStatus.EnumValue == DeviceStatus.Dynamic)
                                                //{
                                                //    lbl_MetalStatus.Text = "仪表：动态";
                                                //}
                                                //else if (PondDataBufferLocal.PondHardInfoForSite.MeterOneStatus.EnumValue == DeviceStatus.OutLoad)
                                                //{
                                                //    lbl_MetalStatus.Text = "仪表：超载";
                                                //}
                                                //else if (PondDataBufferLocal.PondHardInfoForSite.MeterOneStatus.EnumValue == DeviceStatus.Disable)
                                                //{
                                                //    lbl_MetalStatus.Text = "仪表：离线";
                                                //}
                                            }
                                            if (PondDataBufferLocal.PondHardInfoForSite.InfraRedOneStatus.IntValue == 1)
                                            {
                                                txtAlarmLeft.BackColor = Color.Lime;
                                            }
                                            else
                                            {
                                                txtAlarmLeft.BackColor = Color.Red;
                                            }
                                            if (PondDataBufferLocal.PondHardInfoForSite.InfraRedTwoStatus.IntValue == 1)
                                            {
                                                txtAlarmRight.BackColor = Color.Lime;
                                            }
                                            else
                                            {
                                                txtAlarmRight.BackColor = Color.Red;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }, null);
                                }
                                else   //未查询到重量时显示离线
                                {
                                    synchronizationContext.Send(a =>
                                    {
                                        lblWeight.Text = "000000";//string.Format("{0:n2}", Math.Round(0D, 0));
                                        //lbl_MetalStatus.Text = "仪表：离线";
                                    }, null);
                                }
                            }
                        }
                        else
                        {
                            synchronizationContext.Send(a =>
                            {
                                lblWeight.Text = "000000";
                            }, null);
                        }
                    }
                    Interlocked.Exchange(ref IsCan_Down, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref IsCan_Down, 0);
                if (PondSite_Monitorfactory != null)
                {
                    try
                    {
                        PondSite_Monitorfactory.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                PondSite_Monitorfactory = null;
                pondSiteMonitorWCFservice = null;
            }
        }

        // 初始化坐席
        private void InitSite()
        {
            bool isSucess = false;
            int numTemp = 0;
            if (PondDataBufferLocal.SiteInfo != null)
            {
                while (!isSucess)
                {
                    numTemp++;
                    if (numTemp > 5)
                    {
                        ShowTxtLog("初始化失败");
                        break;
                    }
                    try
                    {
                        string errStr;
                        if (Taskfactory == null)
                        {
                            Taskfactory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>;
                            taskWCFservice = Taskfactory.CreateChannel();
                        }
                        int rs = taskWCFservice.InitSiteForLoad(PondDataBufferLocal.SiteInfo.IntId, out errStr);
                        if (rs == 1)
                        {
                            ShowTxtLog("初始化成功");
                            isSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Taskfactory != null)
                        {
                            try
                            {
                                Taskfactory.Close();
                            }
                            catch (Exception e)
                            {
                            }
                            Taskfactory = null;
                        }
                    }

                }
            }
        }

        //结束任务
        private void btnStopTask_Click(object sender, EventArgs e)
        {
            try
            {
                MessageToPondSite(BaseOperateMethod.PowerOut, "");
                EndRoute(route == null ? 0 : route.TaskId, BreakTaskStr);
            }
            catch (Exception ex)
            {
            }
        }

        private void EndRoute(int taskId, string data)
        {
            //isNeedTips = true;
            ClearUI();
            if (route != null && taskId == route.TaskId)
            {
                PondDataBufferLocal.PondHardInfoForSite = null;  //清除硬件信息
                DeleteTaskRoute(data);
            }
            ClearBuffData();
            PondDataBufferLocal.PondHardInfoForSite = null;  //清除硬件信息
            synchronizationContext.Send(a =>
            {
                VideoStop();
            }, null);
        }

        // 拒绝任务
        private void UnReceiveTaskStart()
        {
            bool isSucess = false;
            int numTemp = 0;
            if (PondDataBufferLocal.SiteInfo != null)
            {
                while (!isSucess)
                {
                    numTemp++;
                    if (numTemp > 5)
                    {
                        ShowTxtLog("任务拒绝失败");
                        break;
                    }
                    try
                    {
                        string errStr;
                        int rs = 0;
                        if (route != null && route.IsKeep != null)
                        {
                            if (Taskfactory == null)
                            {
                                Taskfactory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>;
                                taskWCFservice = Taskfactory.CreateChannel();
                            }
                            rs = taskWCFservice.UnReciveTask(route.TaskId, route.SiteId, route.PondId, out errStr, route.IsKeep.EntityValue == 1);
                        }
                        if (rs == 1)
                        {
                            ShowTxtLog("拒绝任务成功");
                            isSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Taskfactory != null)
                        {
                            try
                            {
                                Taskfactory.Close();
                            }
                            catch (Exception e)
                            {
                            }
                            Taskfactory = null;
                        }
                    }

                }
            }
        }

        // 发送计量任务接收信息
        private void ReceiveTaskStart()
        {
            bool isSucess = false;
            int numTemp = 0;
            if (PondDataBufferLocal.SiteInfo != null)
            {
                while (!isSucess)
                {
                    numTemp++;
                    if (numTemp > 5)
                    {
                        ShowTxtLog("任务接收失败");
                        UnReceiveTaskStart();
                        ClearBuffData();
                        ClearUI();
                        break;
                    }
                    try
                    {
                        string errStr;
                        int rs = 0;
                        if (route != null && route.IsKeep != null)
                        {
                            if (Taskfactory == null)
                            {
                                Taskfactory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>;
                                taskWCFservice = Taskfactory.CreateChannel();
                            }
                            rs = taskWCFservice.ReciveTask(route.TaskId, route.SiteId, route.PondId, out errStr, route.IsKeep.EntityValue == 1);
                        }
                        if (rs == 1)
                        {
                            ShowTxtLog("任务接收成功");
                            isSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Taskfactory != null)
                        {
                            try
                            {
                                Taskfactory.Close();
                            }
                            catch (Exception e)
                            {
                            }
                            Taskfactory = null;
                        }
                    }

                }
            }
        }

        // 创建长连接任务
        private void CreateTask()
        {
            bool isSucess = false;
            int n = 0;
            if (txt_poundsite.EditValue != null && PondDataBufferLocal.SiteInfo != null)
            {
                while (!isSucess)
                {
                    if (n > 2)
                    {
                        ShowTxtLog("强制连接失败");
                        break;
                    }
                    try
                    {
                        int taskIdTemp = 0;
                        string errStr;
                        if (Taskfactory == null)
                        {
                            Taskfactory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>;
                            taskWCFservice = Taskfactory.CreateChannel();
                        }
                        DM_Task_WCF task = new DM_Task_WCF();
                        task.ToPondId = MyNumberHelper.ConvertToInt32(txt_poundsite.EditValue);
                        task.SiteId = PondDataBufferLocal.SiteInfo.IntId;
                        task.IsKeep = new EntityInt(1);
                        task.TaskType = new SiteTypeObj((int)SiteType.CarPound);
                        task.IsAutoWeight = new EntityInt(0);
                        task.TaskData = MyJsonHelper.SerializeObject(string.Empty);
                        int rs = taskWCFservice.CreateTask(task, out taskIdTemp, out errStr);
                        task.IntId = taskIdTemp;
                        ShowTxtLog("强制连接中请稍后");
                        if (rs == 1)
                        {
                            pondSiteInfo = txt_poundsite.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                            route = new DM_Route_WCF() { TaskId = taskIdTemp, SiteId = task.SiteId.Value, PondId = task.ToPondId.Value, IsKeep = task.IsKeep };
                            isSucess = true;
                            ShowTxtLog("连接成功");
                        }
                        else
                        {
                            ShowTxtLog(errStr);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Taskfactory != null)
                        {
                            try
                            {
                                Taskfactory.Close();
                            }
                            catch (Exception e)
                            {
                            }
                            Taskfactory = null;
                        }
                    }
                    n++;
                }
            }
        }

        //关闭坐席
        private void CloseSite()
        {
            try
            {
                if (PondDataBufferLocal.SiteInfo != null)
                {
                    if (Site_Infofactory == null)
                    {
                        Site_Infofactory = ctx.GetObject("DM_Site_InfoWCFServiceClient") as ChannelFactory<IDM_Site_InfoWCFService>;
                    }
                    if (Site_Infofactory != null)
                    {
                        if (SiteInfoService == null) SiteInfoService = Site_Infofactory.CreateChannel();
                    }
                    SiteInfoService.UpdateSiteStatus(PondDataBufferLocal.SiteInfo.IntId, PondDataBufferLocal.SiteInfo.SiteStatus);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSiteStatus_Click(object sender, EventArgs e)
        {
            if (btnSiteStatus.Text == "离线状态")
            {
                if (PondDataBufferLocal.SiteInfo != null)
                {
                    btnSiteStatus.Text = "工作状态";
                    btnSiteStatus.BackColor = Color.Lime;
                    PondDataBufferLocal.SiteInfo.SiteStatus = new SiteStatusObj((int)SiteStatus.Working);
                    Timer_ForUploadCallBack(null);
                }
            }
            else
            {
                if (PondDataBufferLocal.SiteInfo != null)
                {
                    PondDataBufferLocal.SiteInfo.SiteStatus = new SiteStatusObj((int)SiteStatus.HangUp);
                    Timer_ForUploadCallBack(null);
                    btnSiteStatus.Text = "离线状态";
                    btnSiteStatus.BackColor = Color.Red;
                }
            }
        }

        private void DeleteTaskRoute(string data)
        {
            bool isSucess = false;
            if (route != null)
            {
                while (!isSucess)
                {
                    try
                    {
                        string errStr;
                        if (Taskfactory == null)
                        {
                            Taskfactory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>;
                            taskWCFservice = Taskfactory.CreateChannel();
                        }
                        int rs = taskWCFservice.DeleteTaskRoute(route.TaskId, route.SiteId, route.PondId, out errStr, true, data);
                        ShowTxtLog("计量结束");
                        if (rs == 1)
                        {
                            isSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Taskfactory != null)
                        {
                            try
                            {
                                Taskfactory.Close();
                            }
                            catch (Exception e)
                            {
                            }
                            Taskfactory = null;
                        }

                    }
                }
            }
        }

        private void btnVideoSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnVideoSend.Text == "视频连接")
                {
                    if (txt_poundsite.EditValue != null)
                    {
                        pondSiteInfo = txt_poundsite.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                        if (pondSiteInfo != null)
                        {
                            VideoPlay();
                        }
                        btnVideoSend.Text = "中断连接";
                    }
                }
                else
                {
                    if (pondSiteInfo != null)
                    {
                        VideoStop();
                    }
                    pondSiteInfo = null;
                    btnVideoSend.Text = "视频连接";
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog("视频连接失败");
            }
        }
        //强连磅房
        private void btnConnectPond_Click(object sender, EventArgs e)
        {
            if (!IsTasking())
            {
                try
                {
                    if (route == null)
                    {
                        CreateTask();
                        MessageToPondSite(BaseOperateMethod.PowerOut, "强连");
                        if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
                        {
                            VideoPlay();
                        }
                    }
                    else
                    {
                        ShowTxtLog("请先结束当前任务再进行连接");
                    }
                }
                catch (Exception ex)
                {
                    _IsTasking = false;
                    ShowTxtLog("强制连接失败");
                }
            }
            else
            {
                ShowTxtLog("请先结束当前任务再进行连接");
            }
        }
        #endregion

        #region 硬盘录像机


        private CHCNetSDK.REALDATACALLBACK m_fRealData = null;
        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        private CHCNetSDK.NET_DVR_CLIENTINFO lpClientInfo;
        private IntPtr pUser;
        private Int32 m_lUserID = -1;
        private Int32 m_lUserID2 = -1;
        private Int32 m_lUserID3 = -1;
        private bool m_bInitSDK = false;

        private bool _videoStatus = false;
        private Int32 _voiceCom = -1;
        private uint iLastErr = 0;
        private string str;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private int[] iChannelNum = new int[96];
        private List<Int32> realHandles = new List<Int32>();
        private Int32 realHandle7 = 0;
        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
            iChannelNum = new int[96];
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
            }
            else
            {
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (int i = 0; i < dwAChanTotalNum; i++)
                {
                    iChannelNum[i] = i + (int)m_struDeviceInfo.byStartChan;
                }
                byte byStreamType = 0;
                uint iDChanNum = 64;
                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;
                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;

                    dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[i].uGetStream);
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);

        }

        public void VideoPlay()
        {
            try
            {
                if (!_videoStatus)
                {
                    _videoStatus = true;
                    m_bInitSDK = CHCNetSDK.NET_DVR_Init();

                    if (m_bInitSDK == false)
                    {
                        ShowTxtLog("SDK加载失败！");
                        return;
                    }
                    if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
                    {
                        SM_Dvr_Info dvr = dvrService.ExecuteDB_QueryAllByPondId(pondSiteInfo.IntId);
                        if (dvr != null)
                        {
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(dvr.DvrIP1, 8000, dvr.Username, dvr.Password, ref m_struDeviceInfo);

                            if (m_lUserID == -1)
                            {
                                ShowTxtLog("硬盘录像机连接失败！");
                                return;
                            }
                            else
                            {
                                dwAChanTotalNum = (uint)m_struDeviceInfo.byChanNum;
                                dwDChanTotalNum = (uint)m_struDeviceInfo.byIPChanNum + 256 * (uint)m_struDeviceInfo.byHighDChanNum;
                                InfoIPChannel();
                            }
                            List<LabelControl> labls = new List<LabelControl>();
                            labls.Add(lblVideo1);
                            labls.Add(lblVideo2);
                            labls.Add(lblVideo3);
                            labls.Add(lblVideo4);
                            labls.Add(lblVideo5);
                            labls.Add(lblVideo6);
                            labls.Add(lblVideo11);
                            labls.Add(lblVideo12);

                            List<PanelControl> pannels = new List<PanelControl>();
                            pannels.Add(panelControl1);
                            pannels.Add(panelControl2);
                            pannels.Add(panelControl3);
                            pannels.Add(panelControl4);
                            pannels.Add(panelControl5);
                            pannels.Add(panelControl6);
                            pannels.Add(panelControl11);
                            pannels.Add(panelControl12);

                            realHandles.Clear();
                            //CHCNetSDK.NET_DVR_SetAudioMode(2);
                            for (int i = 0; i < pannels.Count; i++)
                            {
                                if (iChannelNum[i] > -1)
                                {
                                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                    lpPreviewInfo.lChannel = iChannelNum[i];//预览的设备通道 the device channel number
                                    lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数
                                    IntPtr pUser = IntPtr.Zero;//用户数据 user data 
                                    synchronizationContext.Send(a =>
                                    {
                                        lpPreviewInfo.hPlayWnd = pannels[i].Handle;//预览窗口 live view window
                                        int m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                        if (m_lRealHandle > -1)
                                        {
                                            realHandles.Add(m_lRealHandle);
                                            //if (i < 2)
                                            //{
                                            //    CHCNetSDK.NET_DVR_OpenSoundShare(m_lRealHandle);
                                            //    CHCNetSDK.NET_DVR_SetVolume_Card(m_lRealHandle, 0xffff);
                                            //}
                                            labls[i].Visible = false;
                                        }

                                    }, null);
                                }
                            }
                            synchronizationContext.Send(a =>
                            {
                                btnVideoSend.Text = @"关闭视频";
                            }, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void VideoStop()
        {
            synchronizationContext.Send(a =>
            {
                btnVideoSend.Text = @"视频连接";
                _videoStatus = false;
                lblVideo1.Visible = true;
                lblVideo2.Visible = true;
                lblVideo3.Visible = true;
                lblVideo4.Visible = true;
                lblVideo5.Visible = true;
                lblVideo6.Visible = true;
                lblVideo11.Visible = true;
                lblVideo12.Visible = true;
                foreach (Int32 handel in realHandles)
                {
                    CHCNetSDK.NET_DVR_CloseSoundShare(handel);
                    CHCNetSDK.NET_DVR_StopRealPlay(handel);
                }
                CHCNetSDK.NET_DVR_StopVoiceCom(_voiceCom);
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                CHCNetSDK.NET_DVR_Cleanup();
                panelControl1.Invalidate();
                panelControl2.Invalidate();
                panelControl3.Invalidate();
                panelControl4.Invalidate();
                panelControl5.Invalidate();
                panelControl6.Invalidate();
                panelControl11.Invalidate();
                panelControl12.Invalidate();
            }, null);
        }

        #endregion

        #region  通用方法
        private void ShowWeightType(BUSINESSTYPE I_BUSINESSTYPE)
        {
            if (I_BUSINESSTYPE == BUSINESSTYPE.进厂) radioButton2.Checked = true;
            if (I_BUSINESSTYPE == BUSINESSTYPE.出厂) radioButton3.Checked = true;
            if (I_BUSINESSTYPE == BUSINESSTYPE.内倒) radioButton4.Checked = true;
        }
        private void GetContainerRate(SM_JZXH_Info info, bool istrue)
        {
            SM_Container_Rate rate = new SM_Container_Rate();
            if (info != null)
            {

                if (!string.IsNullOrEmpty(info.C_ContainerNO))
                {
                    rate.C_ContainerNo = info.C_ContainerNO;
                }
                rate.C_ContainerTime = info.C_CameraTime;
                rate.C_CreateUserName = SessionHelper.LogUserNickName;
                if (!string.IsNullOrEmpty(info.C_PondNo))
                {
                    rate.C_PondNo = info.C_PondNo;
                }
                if (!string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
                {
                    rate.C_PlanContainerNo = truckMeasure.C_CONTAINERNO;
                }
                if (istrue)
                {
                    rate.I_RecognitionStatus = 1;
                }
                else
                {
                    rate.I_RecognitionStatus = 0;
                }

            }
            else
            {
                rate.I_RecognitionStatus = 0;
                rate.C_PondNo = pondSiteInfo.PondSiteNo;
                rate.C_CreateUserName = SessionHelper.LogUserNickName;
                if (!string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
                {
                    rate.C_PlanContainerNo = truckMeasure.C_CONTAINERNO;
                }
                rate.C_ContainerNo = string.Empty;

            }
            ContainerRateService.ExecuteDB_InsertContainerRateInfo(rate);


        }
        /// <summary>
        /// 湖大集装箱识别率记录
        /// </summary>
        /// <param name="info"></param>
        /// <param name="istrue"></param>
        private void InsertContainerRate(SM_JZX_Huda_Message info, bool istrue)
        {
            SM_ReeferContainerNo_Info rate = new SM_ReeferContainerNo_Info();
            if (info != null)
            {
                if (!string.IsNullOrEmpty(info.T_PONDID))
                {
                    rate.T_PONDID = info.T_PONDID;
                }
                if (!string.IsNullOrEmpty(info.T_CARNAME_1))
                {
                    rate.T_CARNAME1 = info.T_CARNAME_1;
                }
                if (!string.IsNullOrEmpty(info.T_CARNAME_2))
                {
                    rate.T_CARNAME2 = info.T_CARNAME_2;
                }
                if (!string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
                {
                    rate.T_JZXH_PLAN = truckMeasure.C_CONTAINERNO;
                }
                if (!string.IsNullOrEmpty(info.T_JZXH))
                {
                    rate.T_JZXH = info.T_JZXH;
                }
                if (istrue)
                {
                    rate.T_DISTINGUISH_RESULT = "Y";
                }
                else
                {
                    rate.T_DISTINGUISH_RESULT = "N";
                }
                rate.T_DISTINGUISH_TIME = info.T_DISTINGUISHTIME;
                //rate.C_CreateUserName = SessionHelper.LogUserNickName;                                                               
                if (!string.IsNullOrEmpty(info.T_JZXHPICADDRESS_1))
                {
                    rate.T_JZXH_PICADDRESS1 = info.T_JZXHPICADDRESS_1;
                }
                if (!string.IsNullOrEmpty(info.T_JZXHPICADDRESS_2))
                {
                    rate.T_JZXH_PICADDRESS2 = info.T_JZXHPICADDRESS_2;
                }
                rate.T_RESERVE1 = string.Empty;
                rate.T_RESERVE2 = string.Empty;
                rate.T_RESERVE3 = string.Empty;
                rate.T_RESERVE4 = string.Empty;
            }
            else
            {
                rate.T_CARNAME1 = string.Empty;
                rate.T_CARNAME2 = string.Empty;
                rate.T_PONDID = pondSiteInfo.PondSiteNo;
                if (!string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
                {
                    rate.T_JZXH_PLAN = truckMeasure.C_CONTAINERNO;
                }
                rate.T_JZXH = string.Empty;
                rate.T_DISTINGUISH_RESULT = "N";
                rate.T_DISTINGUISH_TIME = string.Empty;
                rate.T_JZXH_PICADDRESS1 = string.Empty;
                rate.T_JZXH_PICADDRESS2 = string.Empty;
                rate.T_RESERVE1 = string.Empty;
                rate.T_RESERVE2 = string.Empty;
                rate.T_RESERVE3 = string.Empty;
                rate.T_RESERVE4 = string.Empty;
            }
            //ContainerRateService.ExecuteDB_InsertContainerRateInfo(rate);
            HudaJZXHService.ExecuteDB_InsertReeferContainerRateInfo(rate);
        }
        //private void ShowContainerNo(PT_TruckMeasurePlan truckMeasure,string pondid)
        //{
        //    Hashtable ht = new Hashtable();
        //    ht.Add("CarName", truckMeasure.C_CARNAME);
        //    ht.Add("pondid", pondid);
        //    var rs=JZXHService.ExecuteDB_QueryByCarNameAndPond(ht);
        //    if(pondid=="101" || pondid == "102")//金材过磅
        //    {
        //        //计划下发了集装箱号
        //        if (!string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
        //        {
        //            if (rs != null)//识别到集装箱结果
        //            {
        //                //比对结果相同
        //                if (rs.C_ContainerNO == truckMeasure.C_CONTAINERNO)
        //                {
        //                    txt_contarno.Text = rs.C_ContainerNO;
        //                    //识别成功
        //                    GetContainerRate(rs, true);
        //                }
        //                else
        //                {
        //                    txt_contarno.Text = rs.C_ContainerNO;
        //                    //识别失败（识别结果不同）
        //                    GetContainerRate(rs, false);
        //                    MessageBox.Show("集装箱号识别结果和委托下发不匹配，请核对！");
        //                    ShowTxtLog("集装箱号识别结果和委托下发不匹配");
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                //识别失败
        //                GetContainerRate(rs, false);
        //                MessageBox.Show("未识别到集装箱号，请人工录入");
        //                ShowTxtLog("未识别到集装箱号");
        //                return;
        //            }                        
        //        }
        //        //计划未下发集装箱号
        //        if (string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
        //        {
        //            if (rs != null)//识别到集装箱结果
        //            {
        //                txt_contarno.Text = rs.C_ContainerNO;
        //                //识别成功
        //                GetContainerRate(rs, true);
        //            }
        //            else
        //            {
        //                //识别失败
        //                GetContainerRate(rs, false);
        //                MessageBox.Show("未识别到集装箱号，请人工录入");
        //                ShowTxtLog("未识别到集装箱号");
        //                return;
        //            }
        //        }


        //    }
        //    else
        //    {
        //        if(truckMeasure.I_RESERVE1 == 1 && !string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
        //        {
        //            txt_contarno.Text = truckMeasure.C_CONTAINERNO;
        //        }
        //        else
        //        {
        //            MessageBox.Show("未在集装箱识别站点过磅，请人工核对！");
        //            ShowTxtLog("未在集装箱识别站点过磅");
        //            return;
        //        }
        //    }


        //}

        private void ShowContainerNo2(PT_TruckMeasurePlan truckMeasure, string pondid)
        {
            Hashtable ht = new Hashtable();
            ht.Add("CarName", truckMeasure.C_CARNAME);
            ht.Add("pondid", pondid);
            if (pondid == "101" || pondid == "102")//金材过磅
            {
                jzxhInfo = JZXHService.ExecuteDB_QueryByCarNameAndPond(ht);
                if (jzxhInfo != null)//识别到集装箱结果
                {
                    //比对结果相同
                    if (jzxhInfo.C_ContainerNO == truckMeasure.C_CONTAINERNO)
                    {
                        //识别成功
                        GetContainerRate(jzxhInfo, true);
                    }
                    else
                    {
                        //识别失败（识别结果不同）
                        MessageBox.Show("集装箱号识别结果为" + jzxhInfo.C_ContainerNO + ",和委托下发不一致，请查看图片核对！");
                        ShowTxtLog("集装箱号识别结果为" + jzxhInfo.C_ContainerNO + ",和委托下发不一致，请查看图片核对！");
                        isJzxh = true;
                        //GetContainerRate(jzxhInfo, false);
                    }
                    strFilePath = jzxhInfo.C_PhotoAddress;
                }
                else
                {
                    //识别失败
                    GetContainerRate(jzxhInfo, false);
                    MessageBox.Show("未从集装箱号系统中识别集装箱号，请查看图片核对！");
                    ShowTxtLog("未从集装箱号系统中识别集装箱号，请查看图片核对！");
                    return;
                }
            }
        }
        /// <summary>
        /// 湖大集装箱号
        /// </summary>
        /// <param name="truckMeasure"></param>
        /// <param name="pondid"></param>
        private void ShowContainerNo3(PT_TruckMeasurePlan truckMeasure, string pondid)
        {
            Hashtable ht = new Hashtable();
            ht.Add("carName", truckMeasure.C_CARNAME);
            ht.Add("pondId", pondid);
            if (pondid.Equals("109") || pondid.Equals("111"))//炼铁南北磅   || pondid.Equals("111")
            {                
                //hudaJzxInfo = HudaJZXHService.ExecuteDB_QueryAllByCondition_Huda(ht);
                if (HudaJZXHService.ExecuteDB_QueryAllByCondition_Huda(ht) != null && HudaJZXHService.ExecuteDB_QueryAllByCondition_Huda(ht).Count > 0)//识别到集装箱结果
                {
                    hudaJzxInfo = HudaJZXHService.ExecuteDB_QueryAllByCondition_Huda(ht).FirstOrDefault();
                    //比对结果相同
                    if ((hudaJzxInfo.T_JZXH.Substring(4)).Equals(truckMeasure.C_CONTAINERNO))
                    {
                        //识别成功
                        InsertContainerRate(hudaJzxInfo, true);
                    }
                    else
                    {
                        //识别失败（识别结果不同）
                        /*
                        MessageBox.Show("集装箱号识别结果为" + hudaJzxInfo.T_JZXH + ",和委托下发不一致，请查看图片核对！");
                        
                        ShowTxtLog("集装箱号识别结果为" + hudaJzxInfo.T_JZXH + ",和委托下发不一致，请查看图片核对！");
                         * */
                        isHudaJzxh = true;
                        //InsertContainerRate(hudaJzxInfo, false);
                    }
                    //strFilePath = jzxhInfo.C_PhotoAddress;
                }
                else
                {
                    //识别失败
                    InsertContainerRate(hudaJzxInfo, false);
                    return;
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //string strFilePath = @"D:\\Container\101\20201228172231.jpg";
                string path = "http://10.200.114.66/";
                if (!string.IsNullOrEmpty(strFilePath))
                {
                    path = path + strFilePath.Replace(@"D:\Container", "").Replace(@"\", "/");
                    //path = "http://172.18.200.16/2020/901202009/901202009020736574.jpg";
                    PM_ShowTruckPicture aa = new PM_ShowTruckPicture();
                    aa.pxs.Image = GetImage.getImageFromUrl(path);
                    aa.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog("1418---" + ex.Message);
            }
        }

        private void ShowUiMsg(PT_TruckMeasurePlan truckMeasure, TaskTruckData taskTruckData, string pondid)
        {
            ShowWeightType(truckMeasure.I_BUSINESSTYPE);
            #region 第一套
            //if (truckMeasure.I_RESERVE1 == 1)
            //{
            //    ShowContainerNo(truckMeasure, pondid);
            //}
            //else if(truckMeasure.I_RESERVE1 == 0)
            //{
            //    txt_contarno.Text = truckMeasure.C_CONTAINERNO;
            //}
            #endregion
            #region 第二套
            if (string.IsNullOrEmpty(truckMeasure.C_CONTAINERNO))
            {
                txt_contarno.Text = truckMeasure.C_CONTAINERNO;
            }
            else
            {
                txt_contarno.Text = truckMeasure.C_CONTAINERNO;
                ShowContainerNo2(truckMeasure, pondid);
                //湖大集装箱数据
                ShowContainerNo3(truckMeasure, pondid);
            }
            #endregion
            txt_PlanNo.Text = truckMeasure.C_PLANNO;
            txt_MaterName.Text = truckMeasure.C_MATERIALNAME;
            txt_FromDept.Text = truckMeasure.C_FROMDEPTNAME;
            txt_ToDept.Text = truckMeasure.C_TODEPTNAME;
            txt_FromStore.Text = truckMeasure.C_FROMSTORENAME;
            txt_ToStore.Text = truckMeasure.C_TOSTORENAME;
            txt_WeightRule.Text = truckMeasure.I_WEIGHTTYPE.ToString();
            txt_CarNoSelect.Text = truckMeasure.C_CARNAME;
            txt_remark.Text = truckMeasure.C_REMARK;

            if (taskTruckData != null)
            {
                txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
            }
            else
            {
                txt_CarNoCamera.Text = string.Empty;
                txt_CarNoRFID.Text = string.Empty;
                //txt_Reason.Text = string.Empty;
            }
            txt_ConnectPlanNo.Text = truckMeasure.C_CONNECTPLANNO;
        }

        // 上次皮重
        private void LastTareWgt(string carNo)
        {
            IList<SM_TareWeight> truckList = tareWeightService.ExecuteDB_QueryAllByCarNo(carNo);
            if (truckList != null)
            {
                if (truckList.Count > 0)
                {
                    txtLastTare.Text = truckList[0].NewTare.ToString();
                }
                else
                {
                    txtLastTare.Text = "首次过磅";
                }
            }
            else
            {
                txtLastTare.Text = "首次过磅";
            }
        }

        // 上次皮重
        private SM_TareWeight LastTareWgt2(string carNo)
        {
            try
            {
                IList<SM_TareWeight> truckList = tareWeightService.ExecuteDB_QueryAllByCarNo(carNo);
                if (truckList != null)
                {
                    if (truckList.Count > 0)
                    {
                        return truckList[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Settxt_poundsiteData()
        {
            var rss = pondSiteInfoService.ExecuteDB_QueryAll2();
            rss = rss == null ? null : rss.Where(e => e.PondSiteType != null && e.PondSiteType.EnumValue == SiteType.CarPound).ToList();
            synchronizationContext.Send(a =>
            {
                txt_poundsite.Properties.DataSource = rss;
            }, null);
        }

        private void ShowTxtLog(string errStr)
        {
            errStr = String.Format("{0}  {1}{2}", DateTime.Now.ToLocalTime(), errStr, Environment.NewLine);
            synchronizationContext.Send(a =>
            {
                txtStatus.Text = errStr + txtStatus.Text;
            }, null);
        }

        private DialogResult ShowYesOrNo()
        {
            DialogResult rs = MessageBox.Show("是否接收过磅任务?", DialogStr, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            return rs;
        }

        private void CloseDialg()
        {
            IntPtr rs = MyDialogHelper.FindWindow(null, DialogStr);
            if (rs != IntPtr.Zero)
            {
                IntPtr result;
                isUnrecive = MyDialogHelper.EndDialog(rs, out result);
            }
        }

        private void ClearBuffData()
        {
            _IsTasking = false;
            carName = string.Empty;
            logic = string.Empty;
            tareWeight = null;
            jzxhInfo = null;
            //湖大集装箱
            hudaJzxInfo = null;
            isHudaJzxh = false;

            oneMoreTruck = null;
            ptruck = null;
            billTruck = null;
            truckMeasure = null;
            taskTruckData = null;
            route = null;
            pondSiteInfo = null;
            isUnrecive = false;
            isCanEnd = false;
            isJzxh = false;
            strFilePath = string.Empty;

            isNeedTips = true;
            isExceed = 0;
        }

        private void ClearUI()
        {
            synchronizationContext.Send(a =>
            {
                lblWeight.Text = "000000";
                txt_poundsite.EditValue = null;
                chk_TuiHuo.Checked = false;
                //chk_RepeatGross.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                txt_PlanNo.Text = string.Empty;
                txt_MaterName.Text = string.Empty;
                txt_FromDept.Text = string.Empty;
                txt_ToDept.Text = string.Empty;
                txt_CarNoFirst.Text = string.Empty;
                txt_CarNoSelect.Text = string.Empty;
                txt_CarNoRFID.Text = string.Empty;
                txt_CarNoCamera.Text = string.Empty;
                txt_WeightRule.Text = string.Empty;
                txt_ConnectPlanNo.Text = string.Empty;
                txt_FromStore.Text = string.Empty;
                txt_ToStore.Text = string.Empty;
                txt_remark.Text = string.Empty;
                txt_contarno.Text = string.Empty;
                //txt_Reason.Text = string.Empty;
                txtGross.Text = "0";
                txtTare.Text = "0";
                txtNet.Text = "0";
                txtLastTare.Text = "0";
                label1.Text = string.Empty;
                btnGrossWeight.Enabled = false;
                btnTareWeight.Enabled = false;
                txtAlarmLeft.BackColor = Color.Lime;
                txtAlarmRight.BackColor = Color.Lime;
            }, null);
        }

        //选择计划单号或者跳任务毛重
        private void showSelectPlan(PT_TruckMeasurePlan truckMeasure, string pondid)
        {
            if (truckMeasure != null)//查询到计划
            {
                //①判断计划为正常销售或者内倒  无特殊业务
                if ((truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先皮后毛 || truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.限期皮重) && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.无 && truckMeasure.I_ONETWOPLAN == 0)
                {
                    //查询有效皮重
                    if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先皮后毛)
                    {
                        tareWeight = tareWeightService.ExecuteDB_QueryUsedByCarNo(truckMeasure.C_CARNAME);
                        if (tareWeight != null && tareWeight.IsUsed.EntityValue == 0)
                        {
                            txtTare.Text = tareWeight.NewTare.ToString();
                            ShowTxtLog("重车采集");
                            btnTareWeight.Enabled = false;
                            btnGrossWeight.Enabled = true;
                            logic = "A";
                        }
                        else
                        {
                            ShowTxtLog("没有称皮重,无法采集");
                            btnTareWeight.Enabled = false;
                            btnGrossWeight.Enabled = false;
                        }
                        ShowUiMsg(truckMeasure, taskTruckData, pondid);
                    }
                    else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.限期皮重)
                    {
                        int tareLimit = truckMeasure.I_TARETIMELIMIT;
                        tareWeight = tareWeightService.ExecuteDB_QueryUsedByCarNo(truckMeasure.C_CARNAME);
                        if (tareWeight != null)
                        {
                            //限时皮重在有限期之内
                            if (DateTime.Compare((Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(tareWeight.CREATETIME)).AddHours(tareLimit)), DateTime.Now) >= 0)
                            {
                                txtTare.Text = tareWeight.NewTare.ToString();
                                ShowTxtLog("一皮多毛(限期皮重)重车采集");
                                btnTareWeight.Enabled = false;
                                btnGrossWeight.Enabled = true;
                                logic = "A";
                            }
                            else
                            {
                                ShowTxtLog("皮重有效期已过,无法采集");
                                btnTareWeight.Enabled = false;
                                btnGrossWeight.Enabled = false;
                            }
                        }
                        else
                        {
                            label1.Text = "没有称皮重";
                            ShowTxtLog("没有称皮重,无法采集重车");
                            btnTareWeight.Enabled = false;
                            btnGrossWeight.Enabled = false;
                        }
                        ShowUiMsg(truckMeasure, taskTruckData, pondid);
                    }

                }//销售的一车多装业务
                else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先皮后毛 && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.一车多装)
                {
                    //根据车号和关联计划单号找出最近的一条磅单的毛重当做这一车的皮重
                    Hashtable ht = new Hashtable();
                    ht.Add("PlanNo", truckMeasure.C_CONNECTPLANNO);
                    ht.Add("CarName", truckMeasure.C_CARNAME);
                    PM_Bill_Truck billTruck = billTruckService.ExecuteDB_QueryBillTruckByPlanNo(ht);
                    if (billTruck != null)
                    {
                        //显示这一车皮重(上一车的毛重)
                        txtTare.Text = billTruck.N_GROSSWGT.ToString();
                        tareWeight = new SM_TareWeight();
                        tareWeight.CreateUserName = billTruck.C_GROSSWGTMAN;
                        tareWeight.SiteNo = billTruck.C_GROSSWGTSITENO;
                        tareWeight.SiteName = billTruck.C_GROSSWGTSITENAME;
                        tareWeight.CREATETIME = billTruck.C_GROSSWGTTIME;
                        ShowTxtLog("一车多装重车");
                        logic = "A";
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = true;
                    }
                    else
                    {
                        ShowTxtLog("一车多装，无法找到该车关联单号" + truckMeasure.C_CONNECTPLANNO + "的磅单信息");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                    }
                    ShowUiMsg(truckMeasure, taskTruckData, pondid);
                }//正常采购，无特殊业务（一车多单、一车两单、复磅）
                else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.无 && truckMeasure.I_ONETWOPLAN == 0 && truckMeasure.I_REPEATPOUND == REPEATPOUND.无)
                {
                    //查询是否有半条磅单
                    IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo2(truckMeasure.C_CARNAME);
                    if (billList != null && billList.Count > 0)
                    {
                        ShowTxtLog("该车重车已称,无法再次采集");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                    }
                    else if (billList != null && billList.Count == 0)
                    {
                        ShowTxtLog("重车采集");
                        logic = "B";
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = true;
                    }
                    else
                    {
                        ShowTxtLog("查询未完成磅单出错,无法采集");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                    }
                    ShowUiMsg(truckMeasure, taskTruckData, pondid);
                }//采购业务 (一车两单的)
                else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.无 && truckMeasure.I_ONETWOPLAN == 1 && truckMeasure.I_REPEATPOUND == REPEATPOUND.无)
                {
                    IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo2(truckMeasure.C_CARNAME);
                    if (billList != null && billList.Count > 0)
                    {
                        ShowTxtLog("该车重车已称，无法再次采集(一车两单)");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                    }
                    else if (billList != null && billList.Count == 0)
                    {
                        ShowTxtLog("一车两单重车采集");
                        logic = "B";
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = true;
                    }
                    else
                    {
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                        ShowTxtLog("查询未完成磅单出错,无法采集");
                    }
                    ShowUiMsg(truckMeasure, taskTruckData, pondid);
                }//销售业务(一车两单)
                else if ((truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先皮后毛) && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.无 && truckMeasure.I_ONETWOPLAN == 1)
                {
                    //查询有效皮重
                    if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先皮后毛)
                    {
                        tareWeight = tareWeightService.ExecuteDB_QueryUsedByCarNo(truckMeasure.C_CARNAME);
                        if (tareWeight != null && tareWeight.IsUsed.EntityValue == 0)
                        {
                            txtTare.Text = tareWeight.NewTare.ToString();
                            ShowTxtLog("销售一车两单采集");
                            btnTareWeight.Enabled = false;
                            btnGrossWeight.Enabled = true;
                            logic = "A";
                        }
                        else
                        {
                            ShowTxtLog("没有称皮重,无法采集");
                            btnTareWeight.Enabled = false;
                            btnGrossWeight.Enabled = false;
                        }
                        ShowUiMsg(truckMeasure, taskTruckData, pondid);
                    }
                }//采购复磅的（毛毛皮或者毛毛皮皮）
                else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.无 && truckMeasure.I_ONETWOPLAN == 0 && truckMeasure.I_REPEATPOUND != REPEATPOUND.无)
                {
                    //先查看是否存在有半条磅单的一条记录，有则是复毛，没有则是第一条毛
                    IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo(truckMeasure.C_CARNAME);
                    if (billList != null && billList.Count == 0)
                    {
                        label1.Text = truckMeasure.I_REPEATPOUND.ToString() + "的第一次毛重";
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = true;
                        logic = "B";
                    }
                    else if (billList != null && billList.Count == 1)
                    {
                        label1.Text = truckMeasure.I_REPEATPOUND.ToString() + "的第二次毛重";
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = true;
                        logic = "C";
                    }
                    else
                    {
                        ShowTxtLog("存在2条以上未完成磅单或查询失败,请联系班长");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                    }
                    ShowUiMsg(truckMeasure, taskTruckData, pondid);
                }//一车多卸
                else if (truckMeasure.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && truckMeasure.I_ONEMORESTOCK == ONEMORESTOCK.一车多卸)
                {
                    string connectPlanNo = truckMeasure.C_CONNECTPLANNO;
                    //通过关联单号判断是同品名还是不同品名
                    PT_TruckMeasurePlan truckMeasurePlan = truckMeasureService.ExecuteDB_QueryTruckMeasurePlanByPlanNo(connectPlanNo);
                    if (truckMeasurePlan != null)
                    {
                        //同品名
                        if (truckMeasurePlan.I_ISCHILDIDENFY == ISCHILDIDENFY.母标识)
                        {
                            //根据车号和关联计划单号找出最近的一条磅单的皮重当做这一车的毛重
                            Hashtable ht = new Hashtable();
                            ht.Add("PlanNo", truckMeasure.C_CONNECTPLANNO);
                            ht.Add("CarName", truckMeasure.C_CARNAME);
                            oneMoreTruck = billTruckService.ExecuteDB_QueryBillTruckByPlanNo(ht);
                            if (oneMoreTruck != null)
                            {
                                //显示这一车毛重(上一车的皮重)
                                txtGross.Text = oneMoreTruck.N_TAREWGT.ToString();
                                label1.Text = "一车多卸(同品名)";
                                btnTareWeight.Enabled = true;
                                btnGrossWeight.Enabled = false;
                                logic = "G";
                            }
                            else
                            {
                                label1.Text = "一车多卸，无法找到该车关联单号的磅单信息";
                                btnTareWeight.Enabled = false;
                                btnGrossWeight.Enabled = false;
                            }
                            ShowUiMsg(truckMeasure, taskTruckData, pondid);

                        }
                        else//不同品名
                        {
                            //根据车号和关联计划单号找出最近的一条磅单的皮重当做这一车的毛重
                            Hashtable ht = new Hashtable();
                            ht.Add("PlanNo", truckMeasure.C_CONNECTPLANNO);
                            ht.Add("CarName", truckMeasure.C_CARNAME);
                            oneMoreTruck = billTruckService.ExecuteDB_QueryBillTruckByPlanNo(ht);
                            if (oneMoreTruck != null)
                            {
                                //显示这一车毛重(上一车的皮重)
                                txtGross.Text = oneMoreTruck.N_TAREWGT.ToString();
                                label1.Text = "一车多卸(不同品名)";
                                btnTareWeight.Enabled = true;
                                btnGrossWeight.Enabled = false;
                                logic = "G";

                            }
                            else
                            {
                                label1.Text = "一车多卸，无法找到该车关联单号的磅单信息";
                                btnTareWeight.Enabled = false;
                                btnGrossWeight.Enabled = false;
                            }
                            ShowUiMsg(truckMeasure, taskTruckData, pondid);
                        }
                    }
                    else
                    {
                        ShowTxtLog("关联单号不存在，无法称重");
                        btnTareWeight.Enabled = false;
                        btnGrossWeight.Enabled = false;
                        ShowUiMsg(truckMeasure, taskTruckData, pondid);
                    }
                }
                LastTareWgt(truckMeasure.C_CARNAME);
            }
            else
            {
                ShowTxtLog("选择的计划查询不到，请重新查询！");
                btnGrossWeight.Enabled = false;
                btnTareWeight.Enabled = false;
            }
        }

        //跳任务皮重
        private void showSelectTare()
        {
            IList<PM_Bill_Truck> billTruck = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo(taskTruckData.SelectCarNo);
            if (billTruck != null && billTruck.Count == 1)
            {
                ptruck = billTruck[0];
                //如果不是复磅的半条毛榜单
                if (ptruck.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && ptruck.I_REPEATFLAG == 0)
                {
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = ptruck.I_WEIGHTTYPE.ToString();
                    //txt_Reason.Text = taskTruckData.Reason;
                    txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                    txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    logic = "E";
                    ShowTxtLog("皮重采集");
                    btnTareWeight.Enabled = true;
                    btnGrossWeight.Enabled = false;
                }//如果是复磅的半条毛榜单(毛毛皮皮)
                else if (ptruck.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && ptruck.I_REPEATFLAG == 1 && ptruck.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                {
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = ptruck.I_WEIGHTTYPE.ToString();
                    //txt_Reason.Text = taskTruckData.Reason;
                    txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                    txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    logic = "E";
                    ShowTxtLog("皮重复磅采集");
                    btnTareWeight.Enabled = true;
                    btnGrossWeight.Enabled = false;
                }
                else
                {
                    ShowTxtLog("存在不明确的过磅数据，请联系班长！");
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = ptruck.I_WEIGHTTYPE.ToString();
                    //txt_Reason.Text = taskTruckData.Reason;
                    txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                    txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    btnGrossWeight.Enabled = false;
                    btnTareWeight.Enabled = false;
                }
            }
            else if (billTruck != null && billTruck.Count == 2)
            {
                //如果等于2条，那就是复磅的第一次称皮
                //毛 0  0
                //毛 0  1
                for (int i = 0; i < billTruck.Count; i++)
                {
                    if (billTruck[i].I_REPEATFLAG == 0)
                    {
                        ptruck = billTruck[i];
                        break;
                    }
                }
                ShowWeightType(ptruck.I_BUSINESSTYPE);
                txt_PlanNo.Text = ptruck.C_PLANNO;
                txt_MaterName.Text = ptruck.C_MATERIALNAME;
                txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                txt_ToDept.Text = ptruck.C_TODEPTNAME;
                txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                txt_ToStore.Text = ptruck.C_TOSTORENAME;
                txt_WeightRule.Text = ptruck.I_WEIGHTTYPE.ToString();
                //txt_Reason.Text = taskTruckData.Reason;
                txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                txt_CarNoSelect.Text = ptruck.C_CARNAME;
                txt_remark.Text = ptruck.C_REMARK;
                txt_contarno.Text = ptruck.C_CONTAINERNO;
                txtGross.Text = ptruck.N_GROSSWGT.ToString();
                btnTareWeight.Enabled = true;
                btnGrossWeight.Enabled = false;
                logic = "F";
                ShowTxtLog("复磅的第一个皮重采集");
            }
            else
            {
                txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                txt_CarNoSelect.Text = taskTruckData.SelectCarNo;
                logic = "D";
                btnTareWeight.Enabled = true;
                btnGrossWeight.Enabled = false;
                ShowTxtLog("皮重采集");
            }
            LastTareWgt(taskTruckData.SelectCarNo);
        }

        //回车键皮重
        private void showSelectEnterCarNoTare()
        {
            //根据车号查询半条毛磅单
            IList<PM_Bill_Truck> billTruck = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo(txt_CarNoSelect.Text.ToUpper().Trim());
            if (billTruck != null && billTruck.Count == 1)
            {
                ptruck = billTruck[0];
                //如果不是复磅的半条毛榜单
                if (ptruck.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && ptruck.I_REPEATFLAG == 0)
                {
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = billTruck[0].I_WEIGHTTYPE.ToString();
                    if (taskTruckData != null)
                    {
                        //txt_Reason.Text = taskTruckData.Reason;
                        txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                        txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    }
                    else
                    {
                        //txt_Reason.Text = string.Empty;
                        txt_CarNoCamera.Text = string.Empty;
                        txt_CarNoRFID.Text = string.Empty;
                    }
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    logic = "E";
                    ShowTxtLog("皮重采集");
                    btnTareWeight.Enabled = true;
                    btnGrossWeight.Enabled = false;
                }//如果是复磅的半条毛榜单(毛毛皮皮)
                else if (ptruck.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮 && ptruck.I_REPEATFLAG == 1 && ptruck.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                {
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = billTruck[0].I_WEIGHTTYPE.ToString();
                    if (taskTruckData != null)
                    {
                        //txt_Reason.Text = taskTruckData.Reason;
                        txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                        txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    }
                    else
                    {
                        //txt_Reason.Text = string.Empty;
                        txt_CarNoCamera.Text = string.Empty;
                        txt_CarNoRFID.Text = string.Empty;
                    }
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    logic = "E";
                    ShowTxtLog("皮重复磅采集");
                    btnTareWeight.Enabled = true;
                    btnGrossWeight.Enabled = false;
                }
                else
                {
                    ShowTxtLog("存在不明确的过磅数据，请联系班长！");
                    ShowWeightType(ptruck.I_BUSINESSTYPE);
                    txt_PlanNo.Text = ptruck.C_PLANNO;
                    txt_MaterName.Text = ptruck.C_MATERIALNAME;
                    txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                    txt_ToDept.Text = ptruck.C_TODEPTNAME;
                    txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                    txt_ToStore.Text = ptruck.C_TOSTORENAME;
                    txt_WeightRule.Text = billTruck[0].I_WEIGHTTYPE.ToString();
                    txt_remark.Text = ptruck.C_REMARK;
                    txt_contarno.Text = ptruck.C_CONTAINERNO;
                    if (taskTruckData != null)
                    {
                        //txt_Reason.Text = taskTruckData.Reason;
                        txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                        txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    }
                    else
                    {
                        //txt_Reason.Text = string.Empty;
                        txt_CarNoCamera.Text = string.Empty;
                        txt_CarNoRFID.Text = string.Empty;
                    }
                    txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                    txt_CarNoSelect.Text = ptruck.C_CARNAME;
                    txtGross.Text = ptruck.N_GROSSWGT.ToString();
                    btnGrossWeight.Enabled = false;
                    btnTareWeight.Enabled = false;
                }
            }
            else if (billTruck != null && billTruck.Count == 2)
            {
                //如果等于2条，那就是复磅的第一次称皮
                //毛 0  0
                //毛 0  1
                for (int i = 0; i < billTruck.Count; i++)
                {
                    if (billTruck[i].I_REPEATFLAG == 0)
                    {
                        ptruck = billTruck[i];
                        break;
                    }
                }
                ShowWeightType(ptruck.I_BUSINESSTYPE);
                txt_PlanNo.Text = ptruck.C_PLANNO;
                txt_MaterName.Text = ptruck.C_MATERIALNAME;
                txt_FromDept.Text = ptruck.C_FROMDEPTNAME;
                txt_ToDept.Text = ptruck.C_TODEPTNAME;
                txt_FromStore.Text = ptruck.C_FROMSTORENAME;
                txt_ToStore.Text = ptruck.C_TOSTORENAME;
                txt_WeightRule.Text = ptruck.I_WEIGHTTYPE.ToString();
                if (taskTruckData != null)
                {
                    //txt_Reason.Text = taskTruckData.Reason;
                    txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                    txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                }
                else
                {
                    //txt_Reason.Text = string.Empty;
                    txt_CarNoCamera.Text = string.Empty;
                    txt_CarNoRFID.Text = string.Empty;
                }
                txt_remark.Text = ptruck.C_REMARK;
                txt_contarno.Text = ptruck.C_CONTAINERNO;
                txt_ConnectPlanNo.Text = ptruck.C_CONNECTPLANNO;
                txt_CarNoSelect.Text = ptruck.C_CARNAME;
                txtGross.Text = ptruck.N_GROSSWGT.ToString();
                btnTareWeight.Enabled = true;
                btnGrossWeight.Enabled = false;
                logic = "F";
                ShowTxtLog("复磅的第一个皮重采集");
            }
            else
            {
                if (taskTruckData != null)
                {
                    txt_CarNoCamera.Text = taskTruckData.CameraCarNo;
                    txt_CarNoRFID.Text = taskTruckData.RfidCarNo;
                    //txt_Reason.Text = taskTruckData.Reason;
                }
                else
                {
                    //txt_Reason.Text = string.Empty;
                    txt_CarNoCamera.Text = string.Empty;
                    txt_CarNoRFID.Text = string.Empty;
                }
                logic = "D";
                btnTareWeight.Enabled = true;
                btnGrossWeight.Enabled = false;
                ShowTxtLog("皮重采集");
            }
            LastTareWgt(txt_CarNoSelect.Text.ToUpper().Trim());
        }

        //回车车号--根据车号称皮
        private void txt_CarNoSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8)
                {
                    if (e.KeyChar >= 97 && e.KeyChar <= 122)
                    {
                        e.KeyChar = (char)(e.KeyChar - 32);
                    }
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                if (route != null)
                {
                    if (e.KeyChar == 13)//回车键
                    {
                        if (string.IsNullOrEmpty(txt_CarNoSelect.Text.ToUpper().Trim()))
                        {
                            MessageBox.Show("车号不能为空!");
                            return;
                        }
                        showSelectEnterCarNoTare();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        public void ClosePanelControl8()
        {
            panelControl8.Controls.Clear();
            panelControl8.Visible = false;
        }

        //求助
        private void showHelp()
        {
            txt_PlanNo.Text = string.Empty;
            txt_MaterName.Text = string.Empty;
            txt_FromDept.Text = string.Empty;
            txt_ToDept.Text = string.Empty;
            txt_FromStore.Text = string.Empty;
            txt_ToStore.Text = string.Empty;
            txt_CarNoCamera.Text = string.Empty;
            txt_CarNoRFID.Text = string.Empty;
            txt_CarNoSelect.Text = string.Empty;
            txt_CarNoFirst.Text = string.Empty;
            //txt_Reason.Text = taskTruckData.Reason;
            txt_ConnectPlanNo.Text = string.Empty;
            txt_remark.Text = string.Empty;
            txt_contarno.Text = string.Empty;
            label1.Text = "求助";
            btnGrossWeight.Enabled = false;
            btnTareWeight.Enabled = false;
        }

        private void CheckBlackCar(ref bool isBlack)
        {
            try
            {
                IList<SM_BlackList> blackList = blackService.ExecuteDB_QueryBlackListByCarName2(carName);
                if (blackList != null && blackList.Count > 0)
                {
                    isBlack = true;
                }
                else
                {
                    isBlack = false;
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void CheckLastWeightTime(ref bool isLessThan)
        {
            try
            {
                IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryLatestPM_Bill_TruckByCarNo(carName);
                if (billList != null && billList.Count > 0)
                {
                    DateTime dateNow = blackService.ExecuteDB_GetDBTimeNow();
                    if (dateNow != null)
                    {
                        DateTime dateLastTime = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(billList[0].C_NETWGTTIME));
                        TimeSpan ts = dateNow - dateLastTime;
                        if (ts.TotalMinutes < 5)
                        {
                            isLessThan = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }
        private string getWglistNo(string siteNo)
        {
            string date = blackService.ExecuteDB_GetDBTimeNow().ToString("yyyyMMddHHmmss");
            return siteNo + date;
        }
        private void planToTruck()
        {
            billTruck.C_PLANNO = truckMeasure.C_PLANNO;
            billTruck.C_CARNO = truckMeasure.C_CARNO;
            billTruck.C_CARNAME = truckMeasure.C_CARNAME;
            billTruck.C_CARSERIALNUMBER = truckMeasure.C_CARSERIALNUMBER;
            billTruck.C_CONTRACTNO = truckMeasure.C_CONTRACTNO;
            billTruck.C_MATERIALNO = truckMeasure.C_MATERIALNO;
            billTruck.C_MATERIALNAME = truckMeasure.C_MATERIALNAME;
            billTruck.C_FROMDEPTNO = truckMeasure.C_FROMDEPTNO;
            billTruck.C_FROMDEPTNAME = truckMeasure.C_FROMDEPTNAME;
            billTruck.C_FROMSTORENO = truckMeasure.C_FROMSTORENO;
            billTruck.C_FROMSTORENAME = truckMeasure.C_FROMSTORENAME;
            billTruck.C_TODEPTNO = truckMeasure.C_TODEPTNO;
            billTruck.C_TODEPTNAME = truckMeasure.C_TODEPTNAME;
            billTruck.C_TOSTORENO = truckMeasure.C_TOSTORENO;
            billTruck.C_TOSTORENAME = truckMeasure.C_TOSTORENAME;
            billTruck.I_BUSINESSTYPE = truckMeasure.I_BUSINESSTYPE;
            billTruck.I_PLANTYPE = truckMeasure.I_PLANTYPE;
            billTruck.I_ISAUTO = truckMeasure.I_ISAUTO;
            billTruck.I_WEIGHTTYPE = truckMeasure.I_WEIGHTTYPE;
            billTruck.I_TARETIMELIMIT = truckMeasure.I_TARETIMELIMIT;
            billTruck.I_ONEMORESTOCK = truckMeasure.I_ONEMORESTOCK;
            billTruck.I_ISCHILDIDENFY = truckMeasure.I_ISCHILDIDENFY;
            billTruck.I_ISCREATEMOTHERPOND = truckMeasure.I_ISCREATEMOTHERPOND;
            billTruck.C_CONNECTPLANNO = truckMeasure.C_CONNECTPLANNO;
            billTruck.I_ONETWOPLAN = truckMeasure.I_ONETWOPLAN;
            billTruck.C_MIDDLEDEPTNO = truckMeasure.C_MIDDLEDEPTNO;
            billTruck.C_MIDDLEDEPTNAME = truckMeasure.C_MIDDLEDEPTNAME;
            billTruck.C_MIDDLESTORENO = truckMeasure.C_MIDDLESTORENO;
            billTruck.C_MIDDLESTORENAME = truckMeasure.C_MIDDLESTORENAME;
            billTruck.I_RETALLYKG = truckMeasure.I_RETALLYKG;
            billTruck.I_COMPUTERTYPE = truckMeasure.I_COMPUTERTYPE;
            billTruck.I_DOWNVALUE = truckMeasure.I_DOWNVALUE;
            billTruck.I_UPVALUE = truckMeasure.I_UPVALUE;
            billTruck.C_PERCENTAGE = truckMeasure.C_PERCENTAGE;
            billTruck.C_SHIPPINGNOTE = truckMeasure.C_SHIPPINGNOTE;
            billTruck.I_REPEATPOUND = truckMeasure.I_REPEATPOUND;
            billTruck.C_PLANLIMITTIME = truckMeasure.C_PLANLIMITTIME;
            billTruck.C_PONDLIMIT = truckMeasure.C_PONDLIMIT;
            billTruck.C_CREATETIME = truckMeasure.C_CREATETIME;
            billTruck.C_CREATEUSERNAME = truckMeasure.C_CREATEUSERNAME;
            billTruck.C_REMARK = truckMeasure.C_REMARK;
            billTruck.C_RESERVE1 = truckMeasure.C_RESERVE1;
            billTruck.C_RESERVE2 = truckMeasure.C_RESERVE2;
            billTruck.C_RESERVE3 = truckMeasure.C_RESERVE3;
            billTruck.I_RESERVE1 = truckMeasure.I_RESERVE1;
            billTruck.I_RESERVE2 = truckMeasure.I_RESERVE2;
            billTruck.I_RESERVE3 = truckMeasure.I_RESERVE3;
            billTruck.C_PLANSTATE = truckMeasure.C_PLANSTATE;
            billTruck.C_CONTAINERNO = truckMeasure.C_CONTAINERNO;
            billTruck.C_RESERVE4 = truckMeasure.C_RESERVE4;
            billTruck.C_RESERVE5 = truckMeasure.C_RESERVE5;
            billTruck.C_RESERVE6 = truckMeasure.C_RESERVE6;
            billTruck.C_RESERVE7 = truckMeasure.C_RESERVE7;
        }

        private DialogResult DisConnYesOrNo()
        {
            DialogResult rs = MessageBox.Show("过磅结束，是否关闭连接?", DialogStr, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            return rs;
        }

        private void LogicA(bool logci = true)
        {
            try
            {
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;
                if (weightNow < MyNumberHelper.ConvertToDecimal(txtTare.Text))
                {
                    MessageBox.Show("毛重小于皮重,无法采集");
                    return;
                }
                //销售毛 或者内倒毛 形成完整磅单
                billTruck = new PM_Bill_Truck();
                planToTruck();
                billTruck.strFilePath = strFilePath;
                billTruck.C_REMARK = txt_remark.Text.Trim();
                billTruck.C_CONTAINERNO = txt_contarno.Text.Trim();
                DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                billTruck.C_BARCODENO = string.Empty;
                billTruck.N_TAREWGT = Convert.ToInt32(txtTare.Text);
                billTruck.N_GROSSWGT = Convert.ToInt32(weightNow);
                billTruck.N_NETWGT = Convert.ToInt32(weightNow) - Convert.ToInt32(txtTare.Text);
                billTruck.C_TAREWGTTIME = tareWeight.CREATETIME;
                billTruck.C_GROSSWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_TAREWGTSITENO = tareWeight.SiteNo;
                billTruck.C_TAREWGTSITENAME = tareWeight.SiteName;
                billTruck.C_GROSSWGTSITENO = pondSiteInfo.PondSiteNo;
                billTruck.C_GROSSWGTSITENAME = pondSiteInfo.PondSiteName;
                billTruck.C_TAREWGTMAN = tareWeight.CreateUserName;
                billTruck.C_GROSSWGTMAN = SessionHelper.LogUserNickName;
                billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                billTruck.C_PONDREMARK = string.Empty;
                billTruck.C_BILLSTATE = PLANSTATE.已完成;
                billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                billTruck.I_REPEATFLAG = 0;
                billTruck.C_RESERVEFLAG1 = string.Empty;
                billTruck.C_RESERVEFLAG2 = string.Empty;
                billTruck.C_RESERVEFLAG3 = string.Empty;
                billTruck.I_RESERVEFLAG1 = 0;
                billTruck.I_RESERVEFLAG2 = 0;
                billTruck.I_RESERVEFLAG3 = 0;

                txtGross.Text = billTruck.N_GROSSWGT.ToString();
                txtNet.Text = (billTruck.N_GROSSWGT - billTruck.N_TAREWGT).ToString();
                if (logci)
                {
                    var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为毛重并采集，如确定请继续?");
                    if (rs == DialogResult.Yes)
                    {
                        var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, false, null);
                        if (result is CustomDBError)
                        {
                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                            ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        }
                        else
                        {
                            //新增成功，打印完整磅单
                            WeightShow weightshowNow = new WeightShow();
                            weightshowNow.GrossWeight = billTruck.N_GROSSWGT.ToString();
                            weightshowNow.TareWeight = billTruck.N_TAREWGT.ToString();
                            weightshowNow.NetWeight = billTruck.N_NETWGT.ToString();
                            string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                            MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                            btnGrossWeight.Enabled = false;
                            btnTareWeight.Enabled = false;
                            PrintBillForEnd(billTruck);
                            var rs1 = DialogResult.Yes;
                            rs1 = DisConnYesOrNo();
                            if (rs1 == DialogResult.Yes)
                            {
                                EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                            }
                            //Thread td = new Thread(() =>
                            //{
                            //    PrintBillForEnd(billTruck);
                            //    Thread.Sleep(3000);
                            //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                            //});
                            //td.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicB(bool logci = true)
        {
            try
            {
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;
                //采购毛  形成半条磅单
                billTruck = new PM_Bill_Truck();
                planToTruck();
                billTruck.strFilePath = strFilePath;
                billTruck.C_REMARK = txt_remark.Text.Trim();
                billTruck.C_CONTAINERNO = txt_contarno.Text.Trim();
                DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                billTruck.C_BARCODENO = string.Empty;
                billTruck.N_TAREWGT = 0;
                billTruck.N_GROSSWGT = Convert.ToInt32(weightNow);
                billTruck.N_NETWGT = 0;
                billTruck.C_GROSSWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_GROSSWGTSITENO = pondSiteInfo.PondSiteNo;
                billTruck.C_GROSSWGTSITENAME = pondSiteInfo.PondSiteName;
                billTruck.C_GROSSWGTMAN = SessionHelper.LogUserNickName;
                billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                billTruck.C_PONDREMARK = string.Empty;
                billTruck.C_BILLSTATE = PLANSTATE.未完成;
                billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                billTruck.I_REPEATFLAG = 0;
                billTruck.C_RESERVEFLAG1 = string.Empty;
                billTruck.C_RESERVEFLAG2 = string.Empty;
                billTruck.C_RESERVEFLAG3 = string.Empty;
                billTruck.I_RESERVEFLAG1 = 0;
                billTruck.I_RESERVEFLAG2 = 0;
                billTruck.I_RESERVEFLAG3 = 0;

                txtGross.Text = billTruck.N_GROSSWGT.ToString();
                txtNet.Text = "0";
                txtTare.Text = "0";
                var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为毛重并采集，如确定请继续?");
                if (rs == DialogResult.Yes)
                {
                    var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, false, null);
                    if (result is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    }
                    else
                    {
                        //新增成功，不打印半条毛重磅单  (半条毛重磅单区不区分一车两单和正常毛?)
                        WeightShow weightshowNow = new WeightShow();
                        weightshowNow.GrossWeight = billTruck.N_GROSSWGT.ToString();
                        weightshowNow.TareWeight = billTruck.N_TAREWGT.ToString();
                        weightshowNow.NetWeight = billTruck.N_NETWGT.ToString();
                        string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                        MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                        btnGrossWeight.Enabled = false;
                        btnTareWeight.Enabled = false;
                        PrintBillForEnd(billTruck);//加的打印半条磅单
                        var rs1 = DialogResult.Yes;
                        rs1 = DisConnYesOrNo();
                        if (rs1 == DialogResult.Yes)
                        {
                            EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        }
                        //Thread td = new Thread(() =>
                        //{
                        //    Thread.Sleep(3000);
                        //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        //});
                        //td.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicC(bool logci = true)
        {
            //复磅毛重
            try
            {
                //获取毛重设置的磅差
                string repetPond = string.Empty;
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;

                IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo(truckMeasure.C_CARNAME);
                if (billList != null && billList.Count == 1)
                {
                    //一二次毛重在磅差范围内,选用第一次毛重
                    if (Math.Abs(billList[0].N_GROSSWGT - weightNow) <= Convert.ToInt32("300"))
                    {
                        billTruck = new PM_Bill_Truck();
                        planToTruck();
                        billTruck.C_REMARK = txt_remark.Text.Trim();
                        billTruck.C_CONTAINERNO = txt_contarno.Text.Trim();
                        DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                        if (truckMeasure.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                        {
                            billTruck.C_CARNAME = truckMeasure.C_CARNAME;
                        }
                        billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                        billTruck.C_BARCODENO = string.Empty;
                        billTruck.N_TAREWGT = 0;
                        billTruck.N_GROSSWGT = Convert.ToInt32(weightNow);
                        billTruck.N_NETWGT = 0;
                        billTruck.C_GROSSWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        billTruck.C_GROSSWGTSITENO = pondSiteInfo.PondSiteNo;
                        billTruck.C_GROSSWGTSITENAME = pondSiteInfo.PondSiteName;
                        billTruck.C_GROSSWGTMAN = SessionHelper.LogUserNickName;
                        billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                        billTruck.C_PONDREMARK = string.Empty;
                        billTruck.C_BILLSTATE = PLANSTATE.未完成;
                        billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                        billTruck.I_REPEATFLAG = 1;//复磅标注
                        billTruck.C_RESERVEFLAG1 = string.Empty;
                        billTruck.C_RESERVEFLAG2 = string.Empty;
                        billTruck.C_RESERVEFLAG3 = string.Empty;
                        billTruck.I_RESERVEFLAG1 = 0;
                        billTruck.I_RESERVEFLAG2 = 0;
                        billTruck.I_RESERVEFLAG3 = 0;
                        billTruck.strFilePath = strFilePath;

                        txtGross.Text = billList[0].N_GROSSWGT.ToString();
                        txtNet.Text = "0";
                        txtTare.Text = "0";
                        var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为复磅毛重并采集，如确定请继续?");
                        if (rs == DialogResult.Yes)
                        {
                            var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, false, null);
                            if (result is CustomDBError)
                            {
                                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                                ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                            }
                            else
                            {
                                //新增成功，打印半条毛重磅单  毛重磅单为第一条称的磅单
                                WeightShow weightshowNow = new WeightShow();
                                weightshowNow.GrossWeight = billTruck.N_GROSSWGT.ToString();
                                weightshowNow.TareWeight = billTruck.N_TAREWGT.ToString();
                                weightshowNow.NetWeight = billTruck.N_NETWGT.ToString();
                                string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                                MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                                btnGrossWeight.Enabled = false;
                                btnTareWeight.Enabled = false;
                                PrintBillForEnd(billTruck);//加的打印半条磅单
                                var rs1 = DialogResult.Yes;
                                rs1 = DisConnYesOrNo();
                                if (rs1 == DialogResult.Yes)
                                {
                                    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                }
                                //Thread td = new Thread(() =>
                                //{
                                //    Thread.Sleep(3000);
                                //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                //});
                                //td.Start();
                            }
                        }
                    }
                    else//在磅差范围之外
                    {
                        //chk_RepeatGross.Enabled = true;
                        //if (chk_RepeatGross.Checked) //勾上复毛，选择第二条毛重
                        //{
                        //    billTruck = new PM_Bill_Truck();
                        //    planToTruck();
                        //    if (truckMeasure.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                        //    {
                        //        billList[0].C_CARNAME += "F";
                        //    }
                        //    billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                        //    billTruck.C_BARCODENO = string.Empty;
                        //    billTruck.N_TAREWGT = 0;
                        //    billTruck.N_GROSSWGT = Convert.ToInt32(weightNow);
                        //    billTruck.N_NETWGT = 0;
                        //    billTruck.C_GROSSWGTTIME = CommonHelper.TimeToStr14(DateTime.Now);
                        //    billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(DateTime.Now);
                        //    billTruck.C_GROSSWGTSITENO = pondSiteInfo.PondSiteNo;
                        //    billTruck.C_GROSSWGTSITENAME = pondSiteInfo.PondSiteName;
                        //    billTruck.C_GROSSWGTMAN = SessionHelper.LogUserNickName;
                        //    billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 1 : 0;
                        //    billTruck.C_PONDREMARK = string.Empty;
                        //    billTruck.C_BILLSTATE = PLANSTATE.未完成;
                        //    billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                        //    billTruck.I_REPEATFLAG = 0;//复磅标注
                        //    billTruck.C_RESERVEFLAG1 = string.Empty;
                        //    billTruck.C_RESERVEFLAG2 = string.Empty;
                        //    billTruck.C_RESERVEFLAG3 = string.Empty;
                        //    billTruck.I_RESERVE1 = 0;
                        //    billTruck.I_RESERVE2 = 0;
                        //    billTruck.I_RESERVE3 = 0;

                        //    txtGross.Text = billTruck.N_GROSSWGT.ToString();
                        //    txtNet.Text = "0";
                        //    txtTare.Text = "0";
                        //    var rs = MessageDxUtil.ShowYesNoAndTips("已勾选复磅毛重，将选用第二条毛重，如确定请继续?");
                        //    if (rs == DialogResult.Yes)
                        //    {   //新增一条磅单，并修改上一条磅单的复磅状态为1
                        //        var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, true, billList[0]);
                        //        if (result is CustomDBError)
                        //        {
                        //            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        //            ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        //        }
                        //        else
                        //        {
                        //            //新增成功，打印半条毛重磅单  毛重磅单为第二条称的磅单
                        //            ShowTxtLog("计量成功");
                        //            MessageToPondSite(BaseOperateMethod.OtherOperate, string.Empty);
                        //            btnGrossWeight.Enabled = false;
                        //            btnTareWeight.Enabled = false;
                        //            Thread td = new Thread(() =>
                        //            {
                        //                Thread.Sleep(6000);
                        //                EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        //            });
                        //            td.Start();
                        //        }
                        //    }
                        //}
                        //else//不勾，选择第一条毛重
                        //{
                        billTruck = new PM_Bill_Truck();
                        planToTruck();
                        billTruck.C_REMARK = txt_remark.Text.Trim();
                        billTruck.C_CONTAINERNO = txt_contarno.Text.Trim();
                        DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                        if (truckMeasure.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                        {
                            billTruck.C_CARNAME = truckMeasure.C_CARNAME;
                        }
                        billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                        billTruck.C_BARCODENO = string.Empty;
                        billTruck.N_TAREWGT = 0;
                        billTruck.N_GROSSWGT = Convert.ToInt32(weightNow);
                        billTruck.N_NETWGT = 0;
                        billTruck.C_GROSSWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        billTruck.C_GROSSWGTSITENO = pondSiteInfo.PondSiteNo;
                        billTruck.C_GROSSWGTSITENAME = pondSiteInfo.PondSiteName;
                        billTruck.C_GROSSWGTMAN = SessionHelper.LogUserNickName;
                        billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                        billTruck.C_PONDREMARK = string.Empty;
                        billTruck.C_BILLSTATE = PLANSTATE.未完成;
                        billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                        billTruck.I_REPEATFLAG = 1;//复磅标注
                        billTruck.C_RESERVEFLAG1 = string.Empty;
                        billTruck.C_RESERVEFLAG2 = string.Empty;
                        billTruck.C_RESERVEFLAG3 = string.Empty;
                        billTruck.I_RESERVEFLAG1 = 0;
                        billTruck.I_RESERVEFLAG2 = 0;
                        billTruck.I_RESERVEFLAG3 = 0;
                        billTruck.strFilePath = strFilePath;

                        txtGross.Text = billList[0].N_GROSSWGT.ToString();
                        txtNet.Text = "0";
                        txtTare.Text = "0";
                        var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为复磅毛重并采集，如确定请继续?");
                        if (rs == DialogResult.Yes)
                        {
                            var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, false, null);
                            if (result is CustomDBError)
                            {
                                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                                ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                            }
                            else
                            {
                                //新增成功，打印半条毛重磅单  毛重磅单为第一条称的磅单
                                MessageToPondSite(BaseOperateMethod.OtherOperate, string.Empty);
                                btnGrossWeight.Enabled = false;
                                btnTareWeight.Enabled = false;
                                PrintBillForEnd(billTruck);//加的打印半条磅单
                                var rs1 = DialogResult.Yes;
                                //过磅结束是否关闭
                                rs1 = DisConnYesOrNo();
                                if (rs1 == DialogResult.Yes)
                                {
                                    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                }
                                //Thread td = new Thread(() =>
                                //{
                                //    Thread.Sleep(6000);
                                //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                //});
                                //td.Start();
                            }
                        }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicD(bool logci = true)
        {
            //纯称皮重
            try
            {
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;
                if (weightNow >= 30000)
                {
                    ShowTxtLog("空车皮重大于30吨，请注意！");
                    DialogResult diaRs = MessageDxUtil.ShowYesNoAndQuestionDefultNo("空车皮重大于30吨是否继续计量?", "任务提示");
                    if (diaRs == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                txtGross.Text = "0";
                txtNet.Text = "0";
                txtTare.Text = weightNow.ToString();
                var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为皮重并采集，如确定请继续?");
                if (rs == DialogResult.Yes)
                {
                    string status = string.Empty;
                    //插入皮重
                    SM_TareWeight tareWeight = new SM_TareWeight();
                    tareWeight.CarName = carName;
                    tareWeight.NewTare = Convert.ToInt32(weightNow);
                    tareWeight.SiteNo = pondSiteInfo.PondSiteNo;
                    tareWeight.SiteName = pondSiteInfo.PondSiteName;
                    tareWeight.IsUsed = new EntityInt() { EntityValue = 0 };
                    tareWeight.CreateUserName = SessionHelper.LogUserNickName;
                    tareWeight.CREATETIME = CommonHelper.TimeToStr14(DateTime.Now);
                    SM_TareWeight tareLatest = tareWeightService.ExecuteDB_QueryUsedByCarNo(carName);
                    if (tareLatest != null)
                    {
                        status = "Y";
                    }
                    else
                    {
                        status = "N";
                    }
                    var result = tareWeightService.ExecuteDB_InsertTareWeight2(tareWeight, status, isExceed);
                    if (result is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    }
                    else
                    {
                        //新增成功，打印半条纯皮重信息
                        WeightShow weightshowNow = new WeightShow();
                        weightshowNow.GrossWeight = "0";
                        weightshowNow.TareWeight = txtTare.Text;
                        weightshowNow.NetWeight = "0";
                        string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                        MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                        btnGrossWeight.Enabled = false;
                        btnTareWeight.Enabled = false;

                        PrintBillForEnd2(tareWeight);

                        var rs1 = DialogResult.Yes;
                        rs1 = DisConnYesOrNo();
                        if (rs1 == DialogResult.Yes)
                        {
                            EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                            //修改标志状态

                        }
                        //Thread td = new Thread(() =>
                        //{
                        //    Thread.Sleep(6000);
                        //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        //});
                        //td.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicE(bool logci = true)
        {
            try
            {
                //采皮与半条磅单形成完整磅单 （修改）
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;
                if (weightNow >= 30000)
                {
                    ShowTxtLog("皮重大于30吨，请注意！");
                    DialogResult diaRs = MessageDxUtil.ShowYesNoAndQuestionDefultNo("皮重大于30吨是否继续计量?", "任务提示");
                    if (diaRs == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                PM_Bill_Truck btruck = ptruck;
                if (weightNow > ptruck.N_GROSSWGT)
                {
                    MessageBox.Show("皮重大于毛重,无法采集");
                    return;
                }
                //补全皮重信息
                DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                btruck.N_TAREWGT = Convert.ToInt32(weightNow);
                btruck.N_NETWGT = btruck.N_GROSSWGT - btruck.N_TAREWGT;
                btruck.C_TAREWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                btruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                btruck.C_TAREWGTSITENO = pondSiteInfo.PondSiteNo;
                btruck.C_TAREWGTSITENAME = pondSiteInfo.PondSiteName;
                btruck.C_TAREWGTMAN = SessionHelper.LogUserNickName;
                if (btruck.I_RETURNFLAG == 1)
                {
                    btruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                }
                btruck.C_PONDREMARK = string.Empty;
                btruck.C_BILLSTATE = PLANSTATE.已完成;
                btruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                btruck.C_RESERVEFLAG1 = string.Empty;
                btruck.C_RESERVEFLAG2 = string.Empty;
                btruck.C_RESERVEFLAG3 = string.Empty;
                btruck.I_RESERVEFLAG1 = 0;
                btruck.I_RESERVEFLAG2 = 0;
                btruck.I_RESERVEFLAG3 = 0;
                btruck.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                if (btruck.C_UPLOADSTATUE == "Y")
                {
                    btruck.C_PLANSTATUS = "U";
                }
                txtGross.Text = btruck.N_GROSSWGT.ToString();
                txtTare.Text = btruck.N_TAREWGT.ToString();
                txtNet.Text = (btruck.N_GROSSWGT - btruck.N_TAREWGT).ToString();
                var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为皮重并采集，如确定请继续?");
                if (rs == DialogResult.Yes)
                {
                    var result = billTruckService.ExecuteDB_UpdatePM_Bill_Truck2(btruck, false);
                    if (result is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    }
                    else
                    {
                        //新增成功，打印完整磅单信息信息
                        WeightShow weightshowNow = new WeightShow();
                        weightshowNow.GrossWeight = btruck.N_GROSSWGT.ToString();
                        weightshowNow.TareWeight = btruck.N_TAREWGT.ToString();
                        weightshowNow.NetWeight = btruck.N_NETWGT.ToString();
                        string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                        MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                        btnGrossWeight.Enabled = false;
                        btnTareWeight.Enabled = false;

                        //插入皮重库，修改皮重最新状态为已使用
                        insertTare(weightNow, 1);

                        PrintBillForEnd(btruck);
                        var rs1 = DialogResult.Yes;
                        rs1 = DisConnYesOrNo();
                        if (rs1 == DialogResult.Yes)
                        {
                            EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        }
                        //Thread td = new Thread(() =>
                        //{
                        //    PrintBillForEnd(btruck);
                        //    Thread.Sleep(6000);
                        //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        //});
                        //td.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicF(bool logci = true)
        {
            //复磅称重的 第一次称皮(不知道是毛毛皮还是毛毛皮皮)
            try
            {
                if (ptruck != null)
                {
                    decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;
                    if (weightNow >= 30000)
                    {
                        ShowTxtLog("皮重大于30吨，请注意！");
                        DialogResult diaRs = MessageDxUtil.ShowYesNoAndQuestionDefultNo("皮重大于30吨是否继续计量?", "任务提示");
                        if (diaRs == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                    PM_Bill_Truck btruck = ptruck;
                    if (weightNow > ptruck.N_GROSSWGT)
                    {
                        MessageBox.Show("皮重大于毛重,无法采集");
                        return;
                    }
                    //ptruck 为不是复磅的一条磅单 与当前皮合成磅单
                    //if (ptruck.I_REPEATPOUND == REPEATPOUND.毛毛皮)
                    //{
                    //    //与当前毛重磅单补全皮重信息，并将另半条复磅磅单状态修改为已完成
                    //    btruck.N_TAREWGT = Convert.ToInt32(weightNow);
                    //    btruck.N_NETWGT = btruck.N_GROSSWGT - btruck.N_TAREWGT;
                    //    btruck.C_TAREWGTTIME = CommonHelper.TimeToStr14(DateTime.Now);
                    //    btruck.C_NETWGTTIME = CommonHelper.TimeToStr14(DateTime.Now);
                    //    btruck.C_TAREWGTSITENO = pondSiteInfo.PondSiteNo;
                    //    btruck.C_TAREWGTSITENAME = pondSiteInfo.PondSiteName;
                    //    btruck.C_TAREWGTMAN = SessionHelper.LogUserNickName;
                    //    btruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 1 : 0;
                    //    btruck.C_PONDREMARK = string.Empty;
                    //    btruck.C_BILLSTATE = PLANSTATE.已完成;
                    //    btruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                    //    btruck.C_RESERVEFLAG1 = string.Empty;
                    //    btruck.C_RESERVEFLAG2 = string.Empty;
                    //    btruck.C_RESERVEFLAG3 = string.Empty;
                    //    btruck.I_RESERVE1 = 0;
                    //    btruck.I_RESERVE2 = 0;
                    //    btruck.I_RESERVE3 = 0;
                    //    btruck.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;

                    //    txtGross.Text = btruck.N_GROSSWGT.ToString();
                    //    txtTare.Text = btruck.N_TAREWGT.ToString();
                    //    txtNet.Text = (btruck.N_GROSSWGT - btruck.N_TAREWGT).ToString();
                    //    var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为皮重并采集，如确定请继续?");
                    //    if (rs == DialogResult.Yes)
                    //    {
                    //        var result = billTruckService.ExecuteDB_UpdatePM_Bill_Truck2(btruck,true);
                    //        if (result is CustomDBError)
                    //        {
                    //            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    //            ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    //        }
                    //        else
                    //        {
                    //            //新增成功，打印完整磅单信息信息
                    //            ShowTxtLog("计量成功");
                    //            MessageToPondSite(BaseOperateMethod.OtherOperate, string.Empty);
                    //            btnGrossWeight.Enabled = false;
                    //            btnTareWeight.Enabled = false;
                    //            Thread td = new Thread(() =>
                    //            {
                    //                PrintBillForEnd();
                    //                Thread.Sleep(6000);
                    //                EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                    //            });
                    //            td.Start();
                    //        }

                    //        //插入皮重库，修改皮重最新状态为已使用
                    //        insertTare(weightNow, 1);
                    //    }
                    //}
                    if (ptruck.I_REPEATPOUND == REPEATPOUND.毛毛皮皮)
                    {
                        //补全皮重信息
                        DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                        btruck.N_TAREWGT = Convert.ToInt32(weightNow);
                        btruck.N_NETWGT = btruck.N_GROSSWGT - btruck.N_TAREWGT;
                        btruck.C_TAREWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        btruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                        btruck.C_TAREWGTSITENO = pondSiteInfo.PondSiteNo;
                        btruck.C_TAREWGTSITENAME = pondSiteInfo.PondSiteName;
                        btruck.C_TAREWGTMAN = SessionHelper.LogUserNickName;
                        if (btruck.I_RETURNFLAG == 1)
                        {
                            btruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                        }
                        btruck.C_PONDREMARK = string.Empty;
                        btruck.C_BILLSTATE = PLANSTATE.已完成;
                        btruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                        btruck.C_RESERVEFLAG1 = string.Empty;
                        btruck.C_RESERVEFLAG2 = string.Empty;
                        btruck.C_RESERVEFLAG3 = string.Empty;
                        btruck.I_RESERVEFLAG1 = 0;
                        btruck.I_RESERVEFLAG2 = 0;
                        btruck.I_RESERVEFLAG3 = 0;
                        btruck.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                        if (btruck.C_UPLOADSTATUE == "Y")
                        {
                            btruck.C_PLANSTATUS = "U";
                        }
                        txtGross.Text = btruck.N_GROSSWGT.ToString();
                        txtTare.Text = btruck.N_TAREWGT.ToString();
                        txtNet.Text = (btruck.N_GROSSWGT - btruck.N_TAREWGT).ToString();
                        var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为皮重并采集，如确定请继续?");
                        if (rs == DialogResult.Yes)
                        {
                            var result = billTruckService.ExecuteDB_UpdatePM_Bill_Truck2(btruck, false);
                            if (result is CustomDBError)
                            {
                                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                                ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                            }
                            else
                            {
                                //新增成功，打印完整磅单信息信息
                                WeightShow weightshowNow = new WeightShow();
                                weightshowNow.GrossWeight = btruck.N_GROSSWGT.ToString();
                                weightshowNow.TareWeight = btruck.N_TAREWGT.ToString();
                                weightshowNow.NetWeight = btruck.N_NETWGT.ToString();
                                string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                                MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                                btnGrossWeight.Enabled = false;
                                btnTareWeight.Enabled = false;

                                //插入皮重库，修改皮重最新状态为已使用
                                insertTare(weightNow, 1);

                                PrintBillForEnd(btruck);
                                var rs1 = DialogResult.Yes;
                                rs1 = DisConnYesOrNo();
                                if (rs1 == DialogResult.Yes)
                                {
                                    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                }
                                //Thread td = new Thread(() =>
                                //{
                                //    PrintBillForEnd(btruck);
                                //    Thread.Sleep(6000);
                                //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                                //});
                                //td.Start();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void LogicG(bool logci = true)
        {
            //一车多卸 称皮重 不存入皮重库
            try
            {
                //oneMoreTruck  表示最近一条磅单，要取这条磅单的皮重当做毛重
                decimal weightNow = PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight;

                if (weightNow > oneMoreTruck.N_TAREWGT)
                {
                    MessageBox.Show("皮重大于毛重,无法采集");
                    return;
                }
                //销售毛 或者内倒毛 形成完整磅单
                billTruck = new PM_Bill_Truck();
                planToTruck();
                billTruck.C_REMARK = txt_remark.Text.Trim();
                billTruck.C_CONTAINERNO = txt_contarno.Text.Trim();
                DateTime datetimeGross = blackService.ExecuteDB_GetDBTimeNow();
                billTruck.C_WGTLISTNO = getWglistNo(pondSiteInfo.PondSiteNo);
                billTruck.C_BARCODENO = string.Empty;
                billTruck.N_TAREWGT = Convert.ToInt32(weightNow);
                billTruck.N_GROSSWGT = oneMoreTruck.N_TAREWGT;
                billTruck.N_NETWGT = oneMoreTruck.N_TAREWGT - Convert.ToInt32(weightNow);
                billTruck.C_TAREWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_GROSSWGTTIME = oneMoreTruck.C_TAREWGTTIME;
                billTruck.C_NETWGTTIME = CommonHelper.TimeToStr14(datetimeGross);
                billTruck.C_TAREWGTSITENO = pondSiteInfo.PondSiteNo;
                billTruck.C_TAREWGTSITENAME = pondSiteInfo.PondSiteName;
                billTruck.C_GROSSWGTSITENO = oneMoreTruck.C_TAREWGTSITENO;
                billTruck.C_GROSSWGTSITENAME = oneMoreTruck.C_TAREWGTSITENAME;
                billTruck.C_TAREWGTMAN = SessionHelper.LogUserNickName;
                billTruck.C_GROSSWGTMAN = oneMoreTruck.C_TAREWGTMAN;
                billTruck.I_RETURNFLAG = chk_TuiHuo.Checked == true ? 0 : 1;
                billTruck.C_PONDREMARK = string.Empty;
                billTruck.C_BILLSTATE = PLANSTATE.已完成;
                billTruck.C_BILLCREATEUSERNAME = SessionHelper.LogUserNickName;
                billTruck.I_REPEATFLAG = 0;
                billTruck.C_RESERVEFLAG1 = string.Empty;
                billTruck.C_RESERVEFLAG2 = string.Empty;
                billTruck.C_RESERVEFLAG3 = string.Empty;
                billTruck.I_RESERVEFLAG1 = 0;
                billTruck.I_RESERVEFLAG2 = 0;
                billTruck.I_RESERVEFLAG3 = 0;

                txtTare.Text = billTruck.N_TAREWGT.ToString();
                txtNet.Text = (billTruck.N_GROSSWGT - billTruck.N_TAREWGT).ToString();
                var rs = MessageDxUtil.ShowYesNoAndTips("请确定本次计量是否为皮重并采集，如确定请继续?");
                if (rs == DialogResult.Yes)
                {
                    var result = billTruckService.ExecuteDB_InsertPM_Bill_Truck2(billTruck, false, null);
                    if (result is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
                        ShowTxtLog("操作失败：" + ((CustomDBError)result).ErrorMsg);
                    }
                    else
                    {
                        //新增成功，打印完整磅单信息信息
                        WeightShow weightshowNow = new WeightShow();
                        weightshowNow.GrossWeight = billTruck.N_GROSSWGT.ToString();
                        weightshowNow.TareWeight = billTruck.N_TAREWGT.ToString();
                        weightshowNow.NetWeight = billTruck.N_NETWGT.ToString();
                        string dataStr = MyJsonHelper.SerializeObject<WeightShow>(weightshowNow);
                        MessageToPondSite(BaseOperateMethod.OtherOperate, dataStr);
                        btnGrossWeight.Enabled = false;
                        btnTareWeight.Enabled = false;

                        //插入皮重库，修改皮重最新状态为已使用
                        insertTare(weightNow, 1);

                        PrintBillForEnd(billTruck);
                        var rs1 = DialogResult.Yes;
                        rs1 = DisConnYesOrNo();
                        if (rs1 == DialogResult.Yes)
                        {
                            EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        }
                        //Thread td = new Thread(() =>
                        //{
                        //    PrintBillForEnd(billTruck);
                        //    Thread.Sleep(6000);
                        //    EndRoute(route == null ? 0 : route.TaskId, string.Empty);
                        //});
                        //td.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        /// <summary>
        /// 插入皮重库，并修改皮重库状态 
        /// </summary>
        /// <param name="weightNow">重量</param>
        /// <param name="usedStatu">0 未使用  1已使用</param>
        private void insertTare(decimal weightNow, int usedStatu)
        {
            try
            {
                //插入皮重库,修改皮重最新状态
                string status = string.Empty;
                SM_TareWeight tareWeight = new SM_TareWeight();
                tareWeight.CarName = carName;
                tareWeight.NewTare = Convert.ToInt32(weightNow);
                tareWeight.SiteNo = pondSiteInfo.PondSiteNo;
                tareWeight.SiteName = pondSiteInfo.PondSiteName;
                tareWeight.IsUsed = new EntityInt() { EntityValue = usedStatu };
                tareWeight.CreateUserName = SessionHelper.LogUserNickName;

                SM_TareWeight tareLatest = tareWeightService.ExecuteDB_QueryUsedByCarNo(carName);
                if (tareLatest != null)
                {
                    status = "Y";
                }
                else
                {
                    status = "N";
                }
                tareWeightService.ExecuteDB_InsertTareWeight2(tareWeight, status, isExceed);
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }
        #endregion

        private void btnTareWeight_Click(object sender, EventArgs e)
        {
            lock (IsWorkingLock)
            {
                if (pondSiteInfo == null || pondSiteInfo.IntId < 1)
                {
                    ShowTxtLog("计量磅点信息不存在无法继续计量");
                    return;
                }
                //新增限重
                /*
                if (pondSiteInfo.PondSiteNo.Equals("103") && pondSiteInfo.PondSiteNo.Equals("107") && PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight > 100000)
                {
                    MessageBox.Show(pondSiteInfo.PondSiteNo + "该磅限重100吨，该车不允许过磅!");
                    ShowTxtLog(pondSiteInfo.PondSiteNo + "该磅限重100吨，该车不允许过磅!");
                    return;
                }
                 * */
                //进厂的 白云石粉 超过100吨  不允许过磅
               
                if (txt_MaterName.Text.Trim() == "白云石粉" && PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight > 100000 && radioButton2.Checked == true)
                {
                    MessageBox.Show("白云石粉进厂业务不能超过100吨，不允许称重，请结束任务");
                    ShowTxtLog("白云石粉进厂业务不能超过100吨，不允许称重，请结束任务");
                    return;
                }
                //2022.4.24 李佳政
                //与三条皮重库历史记录皮重均值 比较
                IList<SM_TareWeightHistory> CarNameDatas = tareWeightService.ExecuteDB_QueryHistoryByCarName(txt_CarNoCamera.Text);
                if (CarNameDatas.Count >= 2 && CarNameDatas != null)
                {
                    var sum = 0;
                    var avr = 0;
                    for (var i = 0; i < CarNameDatas.Count; i++)
                    {
                        sum += CarNameDatas[i].HistoryTare;
                    }
                    avr = sum / CarNameDatas.Count;
                    if (Convert.ToDouble(txtTare.Text) > 0)
                    {
                        if ((Math.Abs(avr - MyNumberHelper.ConvertToDecimal(txtTare.Text))) > 500)
                        {
                            SpeakTxtLog("该车皮重与历史记录均值差值大于500千克");
                            MessageBox.Show("该车皮重与历史记录均值差值大于500千克");
                            isExceed = 1;
                         }
                    }
                }
                bool isBlack = false;
                bool isLessThan = false;
                if (string.IsNullOrEmpty(txt_CarNoSelect.Text.ToUpper().Trim()))
                {
                    MessageBox.Show("车号不允许为空!");
                    ShowTxtLog("车号不允许为空!");
                    return;
                }
                if (PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight < 800)
                {
                    MessageBox.Show("皮重偏小，无法采集!");
                    ShowTxtLog("皮重偏小，无法采集!");
                    return;
                }
                carName = txt_CarNoSelect.Text.ToUpper().Trim();

                //判断车辆是否黑名单
                CheckBlackCar(ref isBlack);
                if (isBlack)
                {
                    MessageBox.Show("该车辆为黑名单，不允许称重!");
                    ShowTxtLog("该车辆为黑名单，不允许称重!");
                    return;
                }
                CheckLastWeightTime(ref isLessThan);
                if (isLessThan)
                {
                    MessageBox.Show("上次称重时间距离本次计量时间小于5分钟");
                    ShowTxtLog("上次称重时间距离本次计量时间小于5分钟");
                }
                switch (logic)
                {
                    case "D":
                        LogicD();
                        break;
                    case "E":
                        LogicE();
                        break;
                    case "F":
                        LogicF();
                        break;
                    case "G":
                        LogicG();
                        break;
                }
            }

        }

        private void btnGrossWeight_Click(object sender, EventArgs e)
        {
            lock (IsWorkingLock)
            {
                if (pondSiteInfo == null || pondSiteInfo.IntId < 1)
                {
                    ShowTxtLog("计量磅点信息不存在无法继续计量");
                    return;
                }
                //  毛重过磅限重      
                /*
                if (!pondSiteInfo.PondSiteNo.Equals("104") && !pondSiteInfo.PondSiteNo.Equals("110") && PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight >= 100000)
                {
                    MessageBox.Show(pondSiteInfo.PondSiteNo + "该磅点毛重限重100吨，该车不允许过磅!");
                    ShowTxtLog(pondSiteInfo.PondSiteNo + "该磅点毛重限重100吨，该车不允许过磅!");
                    return;
                }                 
                */
                /*
                if (pondSiteInfo.PondSiteNo.Equals("103") && pondSiteInfo.PondSiteNo.Equals("107") && PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight > 100000)
                {
                    MessageBox.Show(pondSiteInfo.PondSiteNo + "该磅限重100吨，该车不允许过磅!");
                    ShowTxtLog(pondSiteInfo.PondSiteNo + "该磅限重100吨，该车不允许过磅!");
                    return;
                }
                 * */
                //进厂的 白云石粉 超过100吨  不允许过磅
               
                if (txt_MaterName.Text.Trim() == "白云石粉" && PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight > 100000 && radioButton2.Checked == true)
                {
                    MessageBox.Show("白云石粉进厂业务不能超过100吨，不允许称重，请结束任务");
                    ShowTxtLog("白云石粉进厂业务不能超过100吨，不允许称重，请结束任务");
                    return;
                }               
                bool isBlack = false;
                bool isLessThan = false;
                if (string.IsNullOrEmpty(txt_CarNoSelect.Text.ToUpper().Trim()))
                {
                    MessageBox.Show("车号不允许为空!");
                    ShowTxtLog("车号不允许为空!");
                    return;
                }
                carName = txt_CarNoSelect.Text.ToUpper().Trim();
                
                if (txt_MaterName.Text.Trim() == "煤焦油" || txt_MaterName.Text.Trim() == "粗苯" || txt_MaterName.Text.Trim() == "硫磺" || txt_MaterName.Text.Trim() == "焦化浓氨水")
                {
                    if (PondDataBufferLocal.PondHardInfoForSite.MeterOneWeight >= 49000)
                    {
                        MessageBox.Show(txt_MaterName.Text.Trim() + "该品名重车不能超过49吨，不允许称重!");
                        ShowTxtLog(txt_MaterName.Text.Trim() + "该品名重车不能超过49吨，不允许称重!");
                        return;
                    }
                }


                //判断车辆是否黑名单
                CheckBlackCar(ref isBlack);
                if (isBlack)
                {
                    MessageBox.Show("该车辆为黑名单，不允许称重!");
                    ShowTxtLog("该车辆为黑名单，不允许称重!");
                    return;
                }
                CheckLastWeightTime(ref isLessThan);
                if (isLessThan)
                {
                    MessageBox.Show("上次称重时间距离本次计量时间小于5分钟");
                    ShowTxtLog("上次称重时间距离本次计量时间小于5分钟");
                }
                IList<PM_Bill_Truck> billList = billTruckService.ExecuteDB_QueryPM_Bill_TruckByCarNo2(txt_CarNoSelect.Text.Trim());
                if (billList != null && billList.Count > 0)
                {
                    MessageBox.Show("该车重车已称,无法再次采集");
                    ShowTxtLog("该车重车已称,无法再次采集");
                    return;
                }
                if (isJzxh)
                {
                    //是为了在这里对识别到了集装箱，但是和委托中的集装箱号不一样的情况的数据进行插入
                    if (jzxhInfo.C_ContainerNO == txt_contarno.Text.Trim())
                    {
                        GetContainerRate(jzxhInfo, true);
                    }
                    else
                    {
                        GetContainerRate(jzxhInfo, false);
                    }
                }
                if (isHudaJzxh)
                {
                    if (hudaJzxInfo.T_JZXH == txt_contarno.Text.Trim())
                    {
                        InsertContainerRate(hudaJzxInfo, true);
                    }
                    else
                    {
                        InsertContainerRate(hudaJzxInfo, false);
                    }
                }
                switch (logic)
                {
                    case "A":
                        LogicA();
                        break;
                    case "B":
                        LogicB();
                        break;
                    case "C":
                        LogicC();
                        break;
                }
            }
        }

        #region 任务调度接口实现-不常用
        public void PrintPondBill(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void ShowMsg(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void TaskEnd(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            CloseDialg();
            EndRoute(taskId, data);
            ShowTxtLog("任务结束");
        }

        public void Warning(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void PowerOut(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void ClearZero(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void OtherOperate(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void TaskBreak(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            CloseDialg();
            EndRoute(taskId, data);
            ShowTxtLog("任务中断");
        }

        public void TrackComing(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void TrackEnd(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void TrackWeight(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }

        public void PondToSiteEndTask(string data, int taskId, int pondId, int siteId, string taskNo)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btn_PrintHis_Click(object sender, EventArgs e)
        {
            if (route != null)
            {
                panelControl8_Show();
            }
        }

        private void panelControl8_Show()
        {
            if (!panelControl8.Visible)
            {
                panelControl8.Parent = this;
                panelControl8.BringToFront();
                panelControl8.Height = Size.Height - 20;
                panelControl8.Width = ((Size.Height - 20) * 4) / 3;
                panelControl8.Location = new Point((Size.Width - panelControl8.Width) / 2, (Size.Height - panelControl8.Height) / 2);
                TruckPrintQuery tq = new TruckPrintQuery(billTruckService, this);
                panelControl8.Controls.Clear();
                panelControl8.Controls.Add(tq);
                tq.Dock = DockStyle.Fill;
                panelControl8.Visible = true;
            }
        }
        //打印小票代码
        public void PrintBillForEnd(PM_Bill_Truck billTruck, bool isRepetPrint = true)
        {
            try
            {
                TaskMessageData data = new TaskMessageData();
                //一车两单
                if (billTruck.I_ONETWOPLAN == 0)
                {
                    data.IntData1 = 1;
                    //
                    data.StringData15 = string.Empty;
                }
                else
                {
                    data.IntData1 = 2;//小票纸张数为2
                    data.StringData15 = billTruck.C_MIDDLEDEPTNAME;
                }

                data.IntData2 = 0;
                //修改，直接用这个字段 来进行打印机的切换选择， comboBoxEdit1.Properties.Items[comboBoxEdit1.SelectedIndex].ToString();
                if (comboBoxEdit1.SelectedIndex == -1 || comboBoxEdit1.SelectedIndex == 2)
                {
                    data.IntData2 = 0;
                }
                else if (comboBoxEdit1.SelectedIndex == 1)
                {
                    data.IntData2 = 1;
                }
                else
                {
                    data.IntData2 = 2;
                }

                data.StringData1 = billTruck.C_CARNAME;
                data.StringData2 = billTruck.C_MATERIALNAME;
                data.StringData3 = billTruck.C_FROMDEPTNAME;
                data.StringData4 = billTruck.C_TODEPTNAME;
                data.StringData5 = billTruck.N_GROSSWGT.ToString();
                data.StringData6 = CommonHelper.Str14ToTimeFormart(billTruck.C_GROSSWGTTIME).Substring(5);
                data.StringData7 = billTruck.N_TAREWGT.ToString();
                if (billTruck.C_TAREWGTTIME == null || billTruck.N_TAREWGT == 0)
                {
                    data.StringData8 = string.Empty;
                }
                else
                {
                    data.StringData8 = CommonHelper.Str14ToTimeFormart(billTruck.C_TAREWGTTIME).Substring(5);
                }

                data.StringData9 = billTruck.N_NETWGT.ToString();
                data.StringData10 = billTruck.C_WGTLISTNO;
                data.StringData14 = billTruck.C_PLANNO;
                if (billTruck.I_WEIGHTTYPE == WEIGHTTYPE.先毛后皮)
                {
                    data.StringData11 = billTruck.C_TAREWGTMAN;
                    data.StringData12 = billTruck.C_TAREWGTSITENAME;
                }
                else
                {
                    data.StringData11 = billTruck.C_GROSSWGTMAN;
                    data.StringData12 = billTruck.C_GROSSWGTSITENAME;
                }
                if (billTruck.C_TAREWGTTIME == null || billTruck.N_TAREWGT == 0)
                {
                    data.StringData11 = billTruck.C_GROSSWGTMAN;
                    data.StringData12 = billTruck.C_GROSSWGTSITENAME;
                }
                data.StringData13 = billTruck.C_REMARK;
                data.StringData16 = billTruck.C_CONTRACTNO;
                //新增对打印机的选择信息

                string dataStr = MyJsonHelper.SerializeObject<TaskMessageData>(data);
                //封装好磅单信息,向磅房端发送指令
                MessageToPondSite(BaseOperateMethod.PrintPondBill, dataStr);

                if (!isRepetPrint)
                {
                    //补打磅单
                    SM_ReasonForNoAuto reasonAuto = new SM_ReasonForNoAuto();
                    reasonAuto.Carno = data.StringData1;
                    reasonAuto.Materialname = data.StringData2;
                    reasonAuto.Fromdeptname = data.StringData3;
                    reasonAuto.Todeptname = data.StringData4;
                    reasonAuto.Createuser = SessionHelper.LogUserNickName;
                    reasonForService.ExecuteDB_InsertReasonInfo(reasonAuto);
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }
        /// <summary>
        /// 发送给磅房命令和消息
        /// </summary>
        /// <param name="command">命令类别</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        private void MessageToPondSite(BaseOperateMethod command, string message)
        {
            bool isSucess = false;
            int numTemp = 0;
            if (route != null)
            {
                while (!isSucess)
                {
                    numTemp++;
                    if (numTemp > 4)
                    {
                        ShowTxtLog("消息发送失败请重试");
                        break;
                    }
                    try
                    {
                        if (Message_To_PondSitefactory == null)
                        {
                            Message_To_PondSitefactory = ctx.GetObject("DM_Message_To_PondSiteWCFServiceClient") as ChannelFactory<IDM_Message_To_PondSiteWCFService>;
                            messageTopondWCFservice = Message_To_PondSitefactory.CreateChannel();
                        }
                        string errmsg;
                        DM_Message_To_PondSite_WCF mp = new DM_Message_To_PondSite_WCF();
                        mp.TaskId = route.TaskId;
                        mp.PondId = route.PondId;
                        mp.SiteId = route.SiteId;
                        mp.Command = new BaseOperateMethodObj((int)(command));//BaseOperateMethod.OtherOperate
                        mp.Message = message;
                        //其他属性
                        var ree = messageTopondWCFservice.CreatePondSiteMessage(mp, out errmsg);
                        if (ree != 1)
                        {
                            ShowTxtLog("消息发送失败" + errmsg);
                        }
                        else
                        {
                            isSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Message_To_PondSitefactory != null)
                        {
                            try
                            {
                                Message_To_PondSitefactory.Close();
                            }
                            catch (Exception exm)
                            {
                            }
                            Message_To_PondSitefactory = null;
                        }
                        //ShowTxtLog("消息发送失败");
                    }
                }
            }
        }

        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (route != null)
                {
                    if (e.KeyChar == 13)//回车键
                    {
                        if (string.IsNullOrEmpty(txt_PlanNo.Text.Trim()))
                        {
                            MessageBox.Show("请输入计划单号");
                            return;
                        }
                        truckMeasure = truckMeasureService.ExecuteDB_QueryTruckMeasureUsingPlanByPlanNo(txt_PlanNo.Text.Trim());
                        string pondid = pondSiteInfo.PondSiteNo;
                        if (truckMeasure != null)
                        {
                            showSelectPlan(truckMeasure, pondid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (route != null)
            {
                try
                {
                    string errStr;
                    if (Message_To_PondSitefactory == null)
                    {
                        Message_To_PondSitefactory = ctx.GetObject("DM_Message_To_PondSiteWCFServiceClient") as ChannelFactory<IDM_Message_To_PondSiteWCFService>;
                        messageTopondWCFservice = Message_To_PondSitefactory.CreateChannel();
                    }
                    DM_Message_To_PondSite_WCF message = new DM_Message_To_PondSite_WCF();
                    message.Command = new BaseOperateMethodObj((int)BaseOperateMethod.ClearZero);
                    message.TaskId = route.TaskId;
                    message.SiteId = route.SiteId;
                    message.PondId = route.PondId;
                    message.Message = string.Empty;
                    int rs = messageTopondWCFservice.CreatePondSiteMessage(message, out errStr);
                    if (rs == 1)
                    {
                        ShowTxtLog("清零命令发送成功");
                    }
                    else
                    {
                        ShowTxtLog("清零命令发送失败");
                    }
                }
                catch (Exception ex)
                {
                    ShowTxtLog("清零失败");
                    if (Message_To_PondSitefactory != null)
                    {
                        try
                        {
                            Message_To_PondSitefactory.Close();
                        }
                        catch (Exception exm)
                        {
                        }
                        Message_To_PondSitefactory = null;
                    }
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            object o = txt_poundsite.EditValue;
            ClearUI();
            txt_poundsite.EditValue = o;
        }

        private void panelControl1_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(1);
        }

        private void panelControl2_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(2);
        }

        private void panelControl3_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(3);
        }

        private void panelControl4_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(4);
        }

        private void panelControl5_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(5);
        }

        private void panelControl6_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(6);
        }
        private void panelControl12_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(8);
        }
        private void panelControl11_DoubleClick(object sender, EventArgs e)
        {
            panelControl7_Show(7);
        }
        private void panelControl7_Show(int index)
        {
            if (!panelControl7.Visible)
            {
                panelControl7.Parent = this;
                panelControl7.BringToFront();
                panelControl7.Height = Size.Height - 20;
                panelControl7.Width = ((Size.Height - 20) * 4) / 3;
                panelControl7.Location = new Point((Size.Width - panelControl7.Width) / 2, (Size.Height - panelControl7.Height) / 2);
                panelControl7.Visible = true;
                if (iChannelNum[index - 1] > -1)
                {
                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                    lpPreviewInfo.hPlayWnd = panelControl7.Handle;//预览窗口 live view window
                    lpPreviewInfo.lChannel = iChannelNum[index - 1];//预览的设备通道 the device channel number
                    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数
                    IntPtr pUser = IntPtr.Zero;//用户数据 user data 
                    realHandle7 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                }
            }
        }

        private void panelControl9_Show(Image image)
        {
            panelControl9.Parent = this;
            panelControl9.BringToFront();
            panelControl9.Height = Size.Height - 20;
            panelControl9.Width = ((Size.Height - 20) * 4) / 3;
            panelControl9.Location = new Point((Size.Width - panelControl9.Width) / 2, (Size.Height - panelControl9.Height) / 2);
            panelControl9.Visible = true;
            panelControl9.Appearance.Image = image;
        }
        private void TruckMeasureForm_New_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (this.Size.Width / 3) * 2;
        }

        private void panelControl7_DoubleClick(object sender, EventArgs e)
        {
            panelControl7.Visible = false;
            if (realHandle7 > -1)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(realHandle7);
            }
        }

        private void txt_CarNoFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_CarNoSelect.Focus();
            txt_CarNoSelect.Text = txt_CarNoFirst.Text;
            txt_CarNoSelect.SelectionStart = txt_CarNoSelect.Text.Length;
        }

        private void SetDBTime()
        {
            try
            {
                DateTime dbtime = blackService.ExecuteDB_GetDBTimeNow();
                SystemTime MySystemTime = new SystemTime();
                GetLocalTime(MySystemTime);
                MySystemTime.vYear = (ushort)dbtime.Year;
                MySystemTime.vMonth = (ushort)dbtime.Month;
                MySystemTime.vDay = (ushort)dbtime.Day;
                MySystemTime.vHour = (ushort)dbtime.Hour;
                MySystemTime.vMinute = (ushort)dbtime.Minute;
                MySystemTime.vSecond = (ushort)dbtime.Second;
                SetLocalTime(MySystemTime);
            }
            catch (Exception)
            {
            }
        }

        private void panelControl7_MouseDown(object sender, MouseEventArgs e)
        {
            //if (realHandle7 == -1) return;
            //if (e.Button == MouseButtons.Left && e.Clicks == 1)
            //{
            //    CHCNetSDK.NET_DVR_PTZControlWithSpeed(realHandle7, 11, 0, 4);
            //}
            //else
            //{
            //    CHCNetSDK.NET_DVR_PTZControlWithSpeed(realHandle7, 12, 0, 4);
            //}
        }

        private void panelControl7_MouseUp(object sender, MouseEventArgs e)
        {
            //if (realHandle7 == -1) return;
            //if (e.Button == MouseButtons.Left && e.Clicks == 1)
            //{
            //    CHCNetSDK.NET_DVR_PTZControlWithSpeed(realHandle7, 11, 1, 4);
            //}
            //else
            //{
            //    CHCNetSDK.NET_DVR_PTZControlWithSpeed(realHandle7, 12, 1, 4);
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (route != null)
                {
                    if (!string.IsNullOrEmpty(txt_CarNoSelect.Text.Trim()))
                    {
                        SM_TareWeight tareWeight = LastTareWgt2(txt_CarNoSelect.Text.Trim());
                        if (tareWeight != null)
                        {
                            PrintBillForEnd2(tareWeight);
                            MessageBox.Show("打印皮重成功!");
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void PrintBillForEnd2(SM_TareWeight billTruck)
        {
            try
            {
                TaskMessageData data = new TaskMessageData();
                data.IntData1 = 1;
                data.IntData2 = 0;
                data.StringData1 = billTruck.CarName;
                data.StringData7 = billTruck.NewTare.ToString();
                data.StringData8 = CommonHelper.Str14ToTimeFormart(billTruck.CREATETIME).Substring(5);
                data.StringData11 = billTruck.CreateUserName;
                data.StringData12 = billTruck.SiteName;
                string dataStr = MyJsonHelper.SerializeObject<TaskMessageData>(data);
                MessageToPondSite(BaseOperateMethod.Warning, dataStr);

            }
            catch (Exception ex)
            {
                ShowTxtLog(ex.Message);
            }
        }

        private void panelControl9_DoubleClick(object sender, EventArgs e)
        {
            panelControl9.Visible = false;
        }
        /// <summary>
        /// 切换打印机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
        //新增 2021-11-10
        public void setPrintSelector()
        {
            comboBoxEdit1.Properties.Items.Clear();
            this.comboBoxEdit1.Properties.NullText = "随机打印";
            //自定义数组
            string[] strs = new string[] { "打印机1", "打印机2", "随机打印" };
            //添加项
            comboBoxEdit1.Properties.Items.AddRange(strs);
            //设置默认选定值
            comboBoxEdit1.SelectedIndex = 2;
            /*
            if (checkedComboBoxEdit1.Properties.Items.Count > 0)
            {
                checkedComboBoxEdit1.Properties.Items[strs[0]].CheckState = CheckState.Checked;
            }
             */
        }




    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class SystemTime
    {
        public ushort vYear;
        public ushort vMonth;
        public ushort vDayOfWeek;
        public ushort vDay;
        public ushort vHour;
        public ushort vMinute;
        public ushort vSecond;
    }

}

