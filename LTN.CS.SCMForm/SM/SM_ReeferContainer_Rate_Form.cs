using LTN.CS.Base;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.Common;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMForm.API;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.PT.Interface;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_ReeferContainer_Rate_Form : CoreForm
    {
        public ISM_PoundSite_InfoService PoundSiteService { get; set; }
        public ISM_ReeferContainerNo_InfoService MainService { get; set; }
        //汽车磅磅单服务
        //public IPM_Bill_TruckService CarPondBillService { get; set; }
        //汽车磅委托服务
        //private IPT_TruckMeasurePlanService truckMeasureService { get; set; }
        public SM_ReeferContainer_Rate_Form()
        {
            InitializeComponent();
        }

        private void SM_ReeferContainer_Rate_Form_Shown(object sender, EventArgs e)
        {
            InitView(gvw_main);
            slu_pondname.Properties.DataSource = PoundSiteService.ExecuteDB_QueryAll().Where(ee => ee.PoundType != null && ee.PoundType.EnumValue == PondType.CarPound).ToList();
            de_starttime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            de_endtime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            slu_pondname.Focus();
            //查询统计信息  两个信息都是来自同一张表，在sql语句中对数据进行处理
            gCtrl_main.DataSource = MainService.ExecuteDB_QueryReeferContainerRecognitionRateAll(getCondition());
            gView_main.BestFitColumns();
            //查询识别信息
            gcl_main.DataSource = MainService.ExecuteDB_QueryAllByCondition(getCondition());
            gvw_main.BestFitColumns();
        }
        private Hashtable getCondition()
        {
            Hashtable ht = new Hashtable();
            string pondId = string.Empty;
            string containerNo = string.Empty;
            
           
            string startTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.Text.Trim()));//;de_starttime.EditValue
            string endTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_endtime.Text.Trim())); //;de_endtime.EditValue     
            if (!string.IsNullOrEmpty(slu_pondname.Text))
            {
                pondId = slu_pondname.EditValue.ToString().Trim();
            }
            if (!string.IsNullOrEmpty(txt_ContainerNo.Text))
            {
               containerNo = txt_ContainerNo.Text.Trim();
            }
            ht.Add("startTime", startTime);
            ht.Add("endTime", endTime);
            ht.Add("pondId", pondId);
            ht.Add("containerNo", containerNo);
            return ht;
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "T_DISTINGUISH_RESULT")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "Y":
                            e.DisplayText = "成功"; break;
                        case "N":
                            e.DisplayText = "失败"; break;
                    }
                }
            }
            if (e.Column.FieldName == "T_DISTINGUISH_TIME")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }

        //聚焦到这一行时，在右边显示集装箱照片
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {              
                var entity = gvw_main.GetFocusedRow() as SM_ReeferContainerNo_Info;
                if (entity != null)
                {
                    string pondId = entity.T_PONDID;
                    string strDrass1 = entity.T_JZXH_PICADDRESS1;
                    string strDrass2 = entity.T_JZXH_PICADDRESS2;
                    if (pondId.Equals("109"))
                    {//北磅
                        if (!string.IsNullOrEmpty(strDrass1))
                        {
                            //http://10.200.115.158/LG/Images/20210624/%E6%88%90%E5%8A%9F/401202106240645028A.jpg
                            //string path1 = "http://10.200.115.158/";//改成湖大放集装箱图片的地址
                            //string path1 = "http://172.16.130.200:8081/";
                            string path1 = "http://10.200.114.190:80/";
                            path1 = path1 + strDrass1.Replace(@"D:\", "").Replace(@"D:/","").Replace(@"\", "/");
                            Console.WriteLine(path1);
                            pictureEdit1.Image = GetImage.getImageFromUrl(path1);
                            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                        }
                        else
                        {
                            pictureEdit1.Image = null;
                        }

                        if (!string.IsNullOrEmpty(strDrass2))
                        {
                            //string path2 = "http://172.16.130.200:8081/";//改成湖大放集装箱图片的地址
                            string path2 = "http://10.200.114.190:80/";
                            path2 = path2 + strDrass1.Replace(@"D:\", "").Replace(@"D:/","").Replace(@"\", "/");
                            pictureEdit2.Image = GetImage.getImageFromUrl(path2);
                            pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                        }
                        else
                        {
                            pictureEdit2.Image = null;
                        }            
                    }
                    else if (pondId.Equals("111"))
                    {//南磅
                        /*
                        if (!string.IsNullOrEmpty(strDrass1))
                        {
                            //http://10.200.115.158/LG/Images/20210624/%E6%88%90%E5%8A%9F/401202106240645028A.jpg
                            //string path1 = "http://10.200.115.158/";//改成湖大放集装箱图片的地址
                            string path1 = "http://172.16.130.200:8081/";
                            path1 = path1 + strDrass1.Replace(@"D:\", "").Replace(@"\", "/");
                            Console.WriteLine(path1);
                            pictureEdit1.Image = GetImage.getImageFromUrl(path1);
                        }
                        else
                        {
                            pictureEdit1.Image = null;
                        }

                        if (!string.IsNullOrEmpty(strDrass2))
                        {
                            string path2 = "http://172.16.130.200:8081/";//改成湖大放集装箱图片的地址
                            path2 = path2 + strDrass1.Replace(@"D:\", "").Replace(@"\", "/");
                            pictureEdit2.Image = GetImage.getImageFromUrl(path2);
                        }
                        else
                        {
                            pictureEdit2.Image = null;
                        }   
                         * */
                    }
                    
                           
                }
            }
            catch (Exception)
            {
            }

        }
        /// <summary>
        /// 生成识别率数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*
        private void getRataData_Click(object sender, EventArgs e)
        {
            //根据条件先查询到相应时间段以内的数据   磅号（109、111),过磅时间
            Hashtable ht = new Hashtable();                  
            string startTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.Text.Trim()));//;de_starttime.EditValue
            string endTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_endtime.Text.Trim())); //;de_endtime.EditValue                      
            ht.Add("startTime", startTime);
            ht.Add("endTime", endTime);           
            //查询符合条件的磅单
            IList<PM_Bill_Truck> billList = CarPondBillService.ExecuteDB_QueryPM_Bill_TruckByHashtable_ForHuda(ht);
            foreach (var obj in billList)
            {
                PM_Bill_Truck bill = obj;
                if (obj != null)
                {
                    string planno = obj.C_PLANNO;
                    string pondId = obj.C_GROSSWGTSITENO;
                    //根据委托号查询集装箱号                    
                    PT_TruckMeasurePlan plan = truckMeasureService.ExecuteDB_QueryTruckMeasurePlanByPlanNo(planno);
                    string containerNo = plan.C_CONTAINERNO;
                    string carname = plan.C_CARNAME;
                    //根据车号和磅号查找最新的一条湖大集装箱识别数据
                    


                }
            }
            //查询符合条件的委托数据
            //JZXH_Huda_Message   和   委托中的集装箱号结合  （根据车号）

        }
         * */
    }
}
