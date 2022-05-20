using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.Interface;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.ServiceInterface.Interface;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.API;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_StaticTrain_Mats_Form : CoreForm
    {
        #region 实例变量
        public ISM_PoundSite_InfoService pondSiteService;
        public IPM_Bill_SuppliesService suppliesService;
        public IPM_Pond_Bill_SuppliesService pondSuppliesService;
        public ISM_Site_InfoService seatinfoService { get; set; }
        public IPM_RawData_MoveTrainService rawDataService;
        private ISM_Dvr_InfoService dvrService { get; set; }
        public PM_Bill_Supplies supplies;
        public DM_Site_Info_WCF seat { get; set; }
        public DM_Task_WCF maintask { get; set; }
        public IDM_PondSite_Monitor_WCFService pondSiteMonitorWCFservice { get; set; }
        public PM_Pond_Bill_Supplies pond;
        private DM_PondSite_Info_WCF pondSiteInfo { get; set; }
        public string seatip = string.Empty;
        ChannelFactory<IDM_PondSite_Monitor_WCFService> PondSite_Monitorfactory { get; set; }
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        int a = 1;
        #endregion

        #region 构造函数
        public PM_Bill_StaticTrain_Mats_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void setDataSource()
        {
            txt_BillStatus.Properties.DataSource = BillStatusObj.GetBillStatusData();
            //txt_poundsite.Properties.DataSource = pondSiteService.ExecuteDB_QueryByPoundType((int)PondType.PondStaticMaterial);
            txt_TareType.Properties.DataSource = TareTypeObj.GetTareTypeData();
            dte_begin.EditValue = DateTime.Now.AddDays(-7);
            dte_end.EditValue = DateTime.Now;

            var rss = pondSiteService.ExecuteDB_QueryAll2();
            rss = rss == null ? null : rss.Where(e => e.PondSiteType != null && e.PondSiteType.EnumValue == SiteType.StaticMaterial).ToList();
            synchronizationContext.Send(a =>
            {
                txt_poundsite.Properties.DataSource = rss;
            }, null);
        }

        /// <summary>
        /// 清空界面
        /// </summary>
        private void cleandata()
        {
            txt_WagNo.Text = null;
            txt_MaterialName.Text = null;
            txt_FromDeptName.Text = null;
            txt_ToDeptName.Text = null;
            txt_mao.EditValue = null;
            txt_pi.EditValue = null;
            //lb_weight.Text = "AAA";
            txt_BillStatus.EditValue = null;
            gcl_main.DataSource = null;
            _voiceCom = -1;
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PM_Bill_StaticTrain_Mats_Form_Shown(object sender, EventArgs e)
        {
            setDataSource();
            maintask = new DM_Task_WCF();
            seatip = SessionHelper.IP;
            seat = seatinfoService.ExecuteDB_QueryBySiteIp2(seatip).FirstOrDefault();
            if (seat == null)
            {
                MessageDxUtil.ShowTips("不存在该IP地址的坐席！");
                return;
            }
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (ChannelFactory<IDM_TaskWCFService> factory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>)
            {
                //1成功,0失败
                string errmsg;
                IDM_TaskWCFService service = factory.CreateChannel();
                var ree = service.InitSiteForLoad(seat.IntId, out errmsg);

            }

            if (seat.SiteType.EnumValue == SiteType.StaticMaterial)
            {
                timer1.Start();
                timer2.Start();
            }
        }

        /// <summary>
        /// 查询静轨计划数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            DateTime dt;
            if (!string.IsNullOrEmpty(dte_begin.Text))
            {
                dt = Convert.ToDateTime(dte_begin.Text);
                ht.Add("StartTime", dt.ToString("yyyyMMdd")+"000000");
            }
            if (!string.IsNullOrEmpty(dte_end.Text))
            {
                dt = Convert.ToDateTime(dte_end.Text);
                ht.Add("EndTime", dt.ToString("yyyyMMdd")+"235959");
            }
            var rs = suppliesService.ExecuteDB_QueryIronByStatic(ht);
            gcl_main.DataSource = rs;
            gvw_main.BestFitColumns();
        }

        /// <summary>
        /// 双击填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txt_poundsite.Text!=string.Empty)
                {
                    //btn_pi.Enabled = true;
                    //btn_mao.Enabled = true;
                    txt_mao.Text = string.Empty;
                    txt_pi.Text = string.Empty;
                    supplies = gvw_main.GetFocusedRow() as PM_Bill_Supplies;
                    txt_WagNo.Text = supplies.WagNo;
                    txt_MaterialName.Text = supplies.MaterialName;
                    txt_FromDeptName.Text = supplies.FromDeptName;
                    txt_ToDeptName.Text = supplies.ToDeptName;
                    txt_BillStatus.EditValue = supplies.BillStatus.IntValue;
                    txt_TareType.EditValue = supplies.TareType.IntValue;
                    if (supplies.BillStatus.IntValue == 1)
                    {
                        var rs = pondSuppliesService.ExecuteDB_QueryByPlanNo(supplies.PlanNo);
                        if (rs.Count != 0 && rs != null)
                        {
                            pond = rs.FirstOrDefault();
                            if (pond.GrossWgt != 0)
                            {
                                btn_mao.Enabled = false;
                                txt_mao.Text = pond.GrossWgt.ToString();
                            }
                            else
                            {
                                btn_pi.Enabled = false;
                                txt_pi.Text = pond.TareWgt.ToString();
                            }
                        }
                    }
                    else
                    {
                        if (supplies!=null && supplies.WeightType.IntValue == 1)
                        {
                            btn_pi.Enabled = true;
                            btn_mao.Enabled = false;
                        }
                        else if (supplies.WeightType.IntValue == 2)
                        {
                            btn_pi.Enabled = false;
                            btn_mao.Enabled = true;
                        }
                        else
                        {
                            btn_mao.Enabled = true;
                            btn_pi.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 保存毛重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mao_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_BillStatus.Text != string.Empty)
                {
                    if (txt_BillStatus.Text == "未计量")
                    {
                        PM_Pond_Bill_Supplies bill = new PM_Pond_Bill_Supplies();
                        if (supplies != null)
                        {
                            bill.PlanNo = supplies.PlanNo;
                            bill.WagNo = supplies.WagNo;
                            bill.MaterialNo = supplies.MaterialNo;
                            bill.MaterialName = supplies.MaterialName;
                            bill.FromDeptNo = supplies.FromDeptNo;
                            bill.FromDeptName = supplies.FromDeptName;
                            bill.FromStoreNo = supplies.FromStoreNo;
                            bill.FromStoreName = supplies.FromStoreName;
                            bill.ToDeptNo = supplies.ToDeptNo;
                            bill.ToDeptName = supplies.ToDeptName;
                            bill.ToStoreNo = supplies.ToStoreNo;
                            bill.ToStoreName = supplies.ToStoreName;
                            bill.ShipNo = supplies.ShipNo;
                            bill.FromStation = supplies.FromStation;
                            bill.SerialNo = supplies.SerialNo;
                            bill.DeliveryNo = supplies.DeliveryNo;
                            bill.ContractNo = supplies.ContractNo;
                            bill.ProjectNo = supplies.ProjectNo;
                            bill.WayBillNo = supplies.WayBillNo;
                            bill.MarshallingNo = supplies.MarshallingNo;
                            bill.BusinessType = supplies.BusinessType;
                            bill.WeightType = supplies.WeightType;
                            bill.TareType = supplies.TareType;
                            bill.MoveStillType = supplies.MoveStillType;
                            bill.PlanLimitTime = supplies.PlanLimitTime;
                            bill.PondLimit = supplies.PondLimit;
                            bill.Remark = supplies.Remark;
                            bill.CReserve1 = supplies.CReserve1;
                            bill.CReserve2 = supplies.CReserve2;
                            bill.CReserve3 = supplies.CReserve3;
                            bill.IReserve1 = supplies.IReserve1;
                            bill.IReserve2 = supplies.IReserve2;
                            bill.IReserve3 = supplies.IReserve3;
                            bill.PlanCreateUser = supplies.CreateUser;
                            bill.PlanCreateTime = supplies.CreateTime;
                            bill.GrossWgt = Convert.ToDecimal(lb_weight.Text);
                            bill.GrossWgtMan = SessionHelper.LogUserNickName;
                            bill.GrossWgtSiteNo = txt_poundsite.EditValue.ToString();
                            bill.GrossWgtSiteName = txt_poundsite.Text;
                            bill.GrossWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            bill.TrainGroupGross = time;
                            bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
                            bill.DataFlag = new EntityInt(1);
                            bill.CreateUser = SessionHelper.LogUserNickName;
                            var rs = pondSuppliesService.ExecuteDB_InsertSuppliesInfo(bill);

                            supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
                            supplies.UpdateUser = SessionHelper.LogUserNickName;
                            var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);

                            PM_RawData_MoveTrain train = new PM_RawData_MoveTrain();
                            train.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = txt_poundsite.EditValue.ToString() };
                            train.OrderNo = a.ToString().PadLeft(2, '0');
                            train.CarNo = bill.WagNo;
                            train.FormationTag = bill.TrainGroupGross;
                            train.WeightData = bill.GrossWgt;
                            train.Speed = 0;
                            train.WeightTime = CommonHelper.Str14ToTimeFormart(bill.GrossWgtTime);
                            train.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.GrossActual };
                            train.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                            train.CreateUser = SessionHelper.LogUserNickName;
                            train.UpdateUser = SessionHelper.LogUserNickName;
                            var re = rawDataService.ExecuteDB_InsertRawDataInfo(train);
                        }
                    }
                    else
                    {
                        if (pond != null)
                        {
                            pond.GrossWgt = Convert.ToDecimal(lb_weight.Text);
                            pond.GrossWgtMan = SessionHelper.LogUserNickName;
                            pond.GrossWgtSiteNo = txt_poundsite.EditValue.ToString();
                            pond.GrossWgtSiteName = txt_poundsite.Text;
                            pond.GrossWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            pond.TrainGroupGross = time;
                            pond.NetWgt = pond.GrossWgt - pond.TareWgt;
                            pond.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                            pond.UpdateUser = SessionHelper.LogUserNickName;
                            pond.UpLoadStatus = "N";
                            pond.PlanStatus = "I";
                            var rs = pondSuppliesService.ExecuteDB_UpdateSuppliesInfo(pond);

                            supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                            supplies.UpdateUser = SessionHelper.LogUserNickName;
                            var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);

                            PM_RawData_MoveTrain train = new PM_RawData_MoveTrain();
                            train.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = txt_poundsite.EditValue.ToString() };
                            train.OrderNo = a.ToString().PadLeft(2, '0');
                            train.CarNo = pond.WagNo;
                            train.FormationTag = pond.TrainGroupGross;
                            train.WeightData = pond.GrossWgt;
                            train.Speed = 0;
                            train.WeightTime = CommonHelper.Str14ToTimeFormart(pond.GrossWgtTime);
                            train.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.GrossActual };
                            train.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                            train.CreateUser = SessionHelper.LogUserNickName;
                            train.UpdateUser = SessionHelper.LogUserNickName;
                            var re = rawDataService.ExecuteDB_InsertRawDataInfo(train);
                        }
                    }
                    a++;
                    txt_mao.Text = lb_weight.Text;
                    MessageDxUtil.ShowTips("保存成功！");
                    cleandata();
                    btn_select_Click(null, null);
                }
            }
            catch (Exception)
            {
                MessageDxUtil.ShowTips("保存失败！");
            }
           
        }

        /// <summary>
        /// 保存皮重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_BillStatus.Text != string.Empty)
                {
                    if (txt_BillStatus.Text == "未计量")
                    {
                        PM_Pond_Bill_Supplies bill = new PM_Pond_Bill_Supplies();
                        if (supplies != null)
                        {
                            bill.PlanNo = supplies.PlanNo;
                            bill.WagNo = supplies.WagNo;
                            bill.MaterialNo = supplies.MaterialNo;
                            bill.MaterialName = supplies.MaterialName;
                            bill.FromDeptNo = supplies.FromDeptNo;
                            bill.FromDeptName = supplies.FromDeptName;
                            bill.FromStoreNo = supplies.FromStoreNo;
                            bill.FromStoreName = supplies.FromStoreName;
                            bill.ToDeptNo = supplies.ToDeptNo;
                            bill.ToDeptName = supplies.ToDeptName;
                            bill.ToStoreNo = supplies.ToStoreNo;
                            bill.ToStoreName = supplies.ToStoreName;
                            bill.ShipNo = supplies.ShipNo;
                            bill.FromStation = supplies.FromStation;
                            bill.SerialNo = supplies.SerialNo;
                            bill.DeliveryNo = supplies.DeliveryNo;
                            bill.ContractNo = supplies.ContractNo;
                            bill.ProjectNo = supplies.ProjectNo;
                            bill.WayBillNo = supplies.WayBillNo;
                            bill.MarshallingNo = supplies.MarshallingNo;
                            bill.BusinessType = supplies.BusinessType;
                            bill.WeightType = supplies.WeightType;
                            bill.TareType = supplies.TareType;
                            bill.MoveStillType = supplies.MoveStillType;
                            bill.PlanLimitTime = supplies.PlanLimitTime;
                            bill.PondLimit = supplies.PondLimit;
                            bill.Remark = supplies.Remark;
                            bill.CReserve1 = supplies.CReserve1;
                            bill.CReserve2 = supplies.CReserve2;
                            bill.CReserve3 = supplies.CReserve3;
                            bill.IReserve1 = supplies.IReserve1;
                            bill.IReserve2 = supplies.IReserve2;
                            bill.IReserve3 = supplies.IReserve3;
                            bill.PlanCreateUser = supplies.CreateUser;
                            bill.PlanCreateTime = supplies.CreateTime;
                            bill.TareWgt = Convert.ToDecimal(lb_weight.Text);
                            bill.TareWgtMan = SessionHelper.LogUserNickName;
                            bill.TareWgtSiteNo = txt_poundsite.EditValue.ToString();
                            bill.TareWgtSiteName = txt_poundsite.Text;
                            bill.TareWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            bill.TrainGroupTare = time;
                            bill.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
                            bill.DataFlag = new EntityInt(1);
                            bill.CreateUser = SessionHelper.LogUserNickName;
                            var rs = pondSuppliesService.ExecuteDB_InsertSuppliesInfo(bill);

                            supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
                            supplies.UpdateUser = SessionHelper.LogUserNickName;
                            var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);

                            PM_RawData_MoveTrain train = new PM_RawData_MoveTrain();
                            train.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = txt_poundsite.EditValue.ToString() };
                            train.OrderNo = a.ToString().PadLeft(2, '0');
                            train.CarNo = bill.WagNo;
                            train.FormationTag = bill.TrainGroupTare;
                            train.WeightData = bill.TareWgt;
                            train.Speed = 0;
                            train.WeightTime = CommonHelper.Str14ToTimeFormart(bill.TareWgtTime);
                            train.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.TareActual };
                            train.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                            train.CreateUser = SessionHelper.LogUserNickName;
                            train.UpdateUser = SessionHelper.LogUserNickName;
                            var re = rawDataService.ExecuteDB_InsertRawDataInfo(train);
                        }
                    }
                    else
                    {
                        if (pond != null)
                        {
                            pond.TareWgt = Convert.ToDecimal(lb_weight.Text);
                            pond.TareWgtMan = SessionHelper.LogUserNickName;
                            pond.TareWgtSiteNo = txt_poundsite.EditValue.ToString();
                            pond.TareWgtSiteName = txt_poundsite.Text;
                            pond.TareWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            pond.TrainGroupTare = str;
                            pond.NetWgt = pond.GrossWgt - pond.TareWgt;
                            pond.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.DoneMeasure };
                            pond.UpdateUser = SessionHelper.LogUserNickName;
                            pond.UpLoadStatus = "N";
                            pond.PlanStatus = "I";
                            var rs = pondSuppliesService.ExecuteDB_UpdateSuppliesInfo(pond);

                            supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                            supplies.UpdateUser = SessionHelper.LogUserNickName;
                            var bs = suppliesService.ExecuteDB_UpdateSuppliesInfo(supplies);

                            PM_RawData_MoveTrain train = new PM_RawData_MoveTrain();
                            train.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = txt_poundsite.EditValue.ToString() };
                            train.OrderNo = a.ToString().PadLeft(2, '0');
                            train.CarNo = pond.WagNo;
                            train.FormationTag = pond.TrainGroupTare;
                            train.WeightData = pond.TareWgt;
                            train.Speed = 0;
                            train.WeightTime = CommonHelper.Str14ToTimeFormart(pond.TareWgtTime);
                            train.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.TareActual };
                            train.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                            train.CreateUser = SessionHelper.LogUserNickName;
                            train.UpdateUser = SessionHelper.LogUserNickName;
                            var re = rawDataService.ExecuteDB_InsertRawDataInfo(train);
                        }
                    }
                    a++;
                    txt_pi.Text = lb_weight.Text;
                    MessageDxUtil.ShowTips("保存成功！");
                    cleandata();
                    btn_select_Click(null, null);
                }
            }
            catch (Exception)
            {
                MessageDxUtil.ShowTips("保存失败！");
            }
           
        }

        /// <summary>
        /// 磅点改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_poundsite_EditValueChanged(object sender, EventArgs e)
        {
            a = 1;
            time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (maintask != null && maintask.IntId != 0)
            {
                try
                {

                    if (txt_poundsite.EditValue != null && maintask.IntId != 0 && maintask != null)
                    {

                        //index = 1;
                        IApplicationContext ctx = ContextRegistry.GetContext();
                        using (ChannelFactory<IDM_Message_To_PondSiteWCFService> factory = ctx.GetObject("DM_Message_To_PondSiteWCFServiceClient") as ChannelFactory<IDM_Message_To_PondSiteWCFService>)
                        {
                            IDM_Message_To_PondSiteWCFService service = factory.CreateChannel();
                            //1成功,0失败
                            DM_Message_To_PondSite_WCF message = new DM_Message_To_PondSite_WCF();
                            message.TaskId = maintask.IntId;
                            message.SiteId = seat.IntId;
                            message.PondId = MyNumberHelper.ConvertToInt32(pondSiteInfo.IntId);
                            message.Command = new BaseOperateMethodObj((int)BaseOperateMethod.OtherOperate);
                            message.Message = "1";
                            string errMsg = string.Empty;
                            int rs = service.CreatePondSiteMessage(message, out errMsg);
                        }
                    }
                }
                catch (Exception)
                {
                }
                //duankai();
                btn_guobang_Click(null, null);
                //a = 1;
            }

            txt_poundsite.ReadOnly = true;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_break_Click(object sender, EventArgs e)
        {
            var duankai = MessageDxUtil.ShowYesNoAndTips("是否确定断开连接");
            if (duankai == DialogResult.No)
            {
                return;
            }
            //timer2.Stop();
            //VideoStop();
            cleandata();
            //a = 1;
            txt_poundsite.EditValue = null;
            txt_poundsite.ReadOnly = false;
            btn_select_Click(null,null);
            btn_mao.Enabled = true;
            btn_pi.Enabled = true;
        }

        private void btn_shipin_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_shipin.Text == "视频连接")
                {
                    if (txt_poundsite.EditValue != null)
                    {
                        pondSiteInfo = txt_poundsite.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                        if (pondSiteInfo != null)
                        {
                            VideoPlay();
                        }
                        btn_shipin.Text = "中断连接";
                    }
                }
                else
                {
                    if (pondSiteInfo != null)
                    {
                        VideoStop();
                    }
                    pondSiteInfo = null;
                    btn_shipin.Text = "视频连接";
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog("视频连接失败");
            }
        }
        #endregion
        #region 硬盘录像机
        private CHCNetSDK.NET_DVR_TIME dateTimeStart;
        private CHCNetSDK.NET_DVR_TIME dateTimeEnd;
        private CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        private bool VideoStatus = true;
        public bool _videoStatus2 = true;
        private IntPtr pUser;
        private Int32 m_lUserID = -1;
        private Int32 m_lUserID2 = -1;
        private Int32 m_lUserID3 = -1;
        private bool m_bInitSDK = false;

        private Int32 m_lRealHandle1 = -1;
        private Int32 m_lRealHandle2 = -1;
        private Int32 m_lRealHandle3 = -1;
        private Int32 m_lRealHandle4 = -1;
        private uint lpOutValue = 0;

        private bool _videoStatus = false;
        private Int32 _voiceCom = -1;
        private uint iLastErr = 0;
        private string str;

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
        private void ShowTxtLog(string errStr)
        {
            errStr = String.Format("{0}  {1}{2}", DateTime.Now.ToLocalTime(), errStr, Environment.NewLine);
            synchronizationContext.Send(a =>
            {
                txtStatus.Text = errStr + txtStatus.Text;
                //txtStatus.SelectedText = errStr;
            }, null);

            //_voice.Speak(CutString(errStr));
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

                            List<PanelControl> pannels = new List<PanelControl>();
                            pannels.Add(panelControl7);
                            pannels.Add(panelControl2);
                            pannels.Add(panelControl3);
                            pannels.Add(panelControl4);

                            realHandles.Clear();
                            CHCNetSDK.NET_DVR_SetAudioMode(2);
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
                                            if (i < 2)
                                            {
                                                CHCNetSDK.NET_DVR_OpenSoundShare(m_lRealHandle);
                                                CHCNetSDK.NET_DVR_SetVolume_Card(m_lRealHandle, 0xffff);
                                            }
                                            labls[i].Visible = false;
                                        }

                                    }, null);
                                }
                            }
                            synchronizationContext.Send(a =>
                            {
                                btn_shipin.Text = @"关闭视频";
                            }, null);
                            //CHCNetSDK.VOICEDATACALLBACKV30 fVoiceDataCallBack = null;//打开对讲
                            //_voiceCom = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, 1, true, fVoiceDataCallBack, IntPtr.Zero);//打开对讲
                            //uint rsInt = CHCNetSDK.NET_DVR_GetLastError();
                            //if (rsInt != 0)
                            //{
                            //    ShowTxtLog("对讲失败" + rsInt);
                            //}
                            //if (_voiceCom == -1)
                            //{
                            //    ShowTxtLog("对讲通道被其他坐席所占，无法开启对讲通道！");
                            //}
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
                btn_shipin.Text = @"视频连接";
                _videoStatus = false;
                lblVideo1.Visible = true;
                lblVideo2.Visible = true;
                lblVideo3.Visible = true;
                lblVideo4.Visible = true;
                foreach (Int32 handel in realHandles)
                {
                    CHCNetSDK.NET_DVR_CloseSoundShare(handel);
                    CHCNetSDK.NET_DVR_StopRealPlay(handel);
                }
                CHCNetSDK.NET_DVR_StopVoiceCom(_voiceCom);
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                CHCNetSDK.NET_DVR_Cleanup();
                panelControl7.Invalidate();
                panelControl2.Invalidate();
                panelControl3.Invalidate();
                panelControl4.Invalidate();
            }, null);
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            using (ChannelFactory<IDM_Message_To_SiteWCFService> factory = ctx.GetObject("DM_Message_To_SiteWCFServiceClient") as ChannelFactory<IDM_Message_To_SiteWCFService>)
            {
                IDM_Message_To_SiteWCFService service = factory.CreateChannel();
                //1成功,0失败

                var rs = service.GetSiteMessage(seat.IntId, null, null);
                if (rs != null)
                {
                    for (int i = 0; i < rs.Count(); i++)
                    {
                        maintask.IntId = rs[i].TaskId;
                        maintask.PondId = rs[i].PondId;
                        maintask.SiteId = rs[i].SiteId;

                        var testMethod = typeof(IBaseOperate).GetMethod(rs[i].Command.BaseOperateMethodDesc);

                        testMethod.Invoke(this, new object[] { rs[i].Message, rs[i].TaskId, rs[i].PondId, rs[i].SiteId, rs[i].TaskNo });
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();

            PondSite_Monitorfactory = ctx.GetObject("DM_PondSite_Monitor_WCFServiceClient") as ChannelFactory<IDM_PondSite_Monitor_WCFService>;
            if (PondSite_Monitorfactory != null)
            {
                if (pondSiteMonitorWCFservice == null)
                {
                    pondSiteMonitorWCFservice = PondSite_Monitorfactory.CreateChannel();
                    //1成功,0失败

                    var rs = pondSiteMonitorWCFservice.QueryMonitorById(maintask.ToPondId.Value);
                    lb_weight.Text = Convert.ToInt32(rs.MeterOneWeight).ToString();

                    // lb_weight.Text = "85.14";
                }
                else
                {
                    var rs = pondSiteMonitorWCFservice.QueryMonitorById(maintask.ToPondId.Value);
                    lb_weight.Text = Convert.ToInt32(rs.MeterOneWeight).ToString();
                    //lb_weight.Text = "85.14";
                }
            }
        }

        private void btn_guobang_Click(object sender, EventArgs e)
        {
            pondSiteInfo = txt_poundsite.GetSelectedDataRow() as DM_PondSite_Info_WCF;
            if (maintask != null && maintask.IntId != 0)
            {
                MessageDxUtil.ShowWarning("已有磅房连接，请先断开连接!");
                return;
            }
            //加判断是否已有链接，如需手动过磅，先断开连接
            if (pondSiteInfo!= null)
            {
                //txt_poundsite
                IApplicationContext ctx = ContextRegistry.GetContext();
                using (ChannelFactory<IDM_TaskWCFService> factory = ctx.GetObject("DM_TaskWCFServiceClient") as ChannelFactory<IDM_TaskWCFService>)
                {
                    //1成功,0失败
                    string errmsg;
                    int mainid;
                    //task.PondId == null && task.SiteId != null  这俩属性是任务来源
                    maintask.IsKeep = new EntityInt(1);
                    maintask.ToPondId = MyNumberHelper.ConvertToInt32(pondSiteInfo.IntId);
                    maintask.SiteId = seat.IntId; ;
                    maintask.TaskType = new SiteTypeObj((int)(SiteType.StaticMaterial));
                    maintask.TaskStatus = new TaskStatusObj((int)(TaskStatus.Accepting));

                    IDM_TaskWCFService service = factory.CreateChannel();
                    var ree = service.CreateTask(maintask, out mainid, out errmsg);
                    maintask.IntId = mainid;
                    maintask.PondId = MyNumberHelper.ConvertToInt32(pondSiteInfo.IntId);

                }
                VideoPlay();
                timer2.Start();
            }
        }

        private void panelControl7_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }

        private void panelControl2_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }

        private void panelControl3_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }

        private void panelControl4_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }
    }
}
