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

using System.Speech.Synthesis;

using DevExpress.XtraPrinting;


namespace LTN.CS.SCMForm.PM
{
    public partial class Pond_ComplateTime_Form : CoreForm
    {
        public ISM_PoundSite_InfoService PoundSiteService { get; set; }
        public IPond_ComplateTimeService MainService { get; set; }

        SpeechSynthesizer speacker = new SpeechSynthesizer();

        Dictionary<string, string> pondDictionary = new Dictionary<string, string>();

        public Pond_ComplateTime_Form()
        {
            InitializeComponent();
        }

        private void Pond_ComplateTime_Form_Shown(object sender, EventArgs e)
        {
            InitView(gvw_main);
            slu_pondname.Properties.DataSource = PoundSiteService.ExecuteDB_QueryAll().Where(ee => ee.PoundType != null && ee.PoundType.EnumValue == PondType.CarPound).ToList();
            de_starttime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            de_endtime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            setPondName();

        }
        private void setPondName()
        {
            pondDictionary.Add("101", "金材1号南磅");
            pondDictionary.Add("102", "金材1号北磅");
            pondDictionary.Add("103", "东门南磅");
            pondDictionary.Add("104", "金材2号磅");
            pondDictionary.Add("105", "物资仓库东磅");
            pondDictionary.Add("106", "物资仓库西磅");
            pondDictionary.Add("107", "东门北磅");
            pondDictionary.Add("108", "成品汽车磅");
            pondDictionary.Add("109", "炼铁北磅");
            pondDictionary.Add("110", "金材3号磅");
            pondDictionary.Add("111", "炼铁南磅");

        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            slu_pondname.Focus();
            //查询识别信息
            IList<Pond_ComplateTime> list = MainService.ExecuteDB_QueryAll(getCondition());
            //gcl_main.DataSource = MainService.ExecuteDB_QueryAll(getCondition());
            int count = 0;
            foreach (Pond_ComplateTime pond in list)
            {
                if (pond.endTime != null && !string.IsNullOrEmpty(pond.endTime))
                {
                    string str = pond.startTime;
                    str = str.Substring(0, 4) + '/' + str.Substring(4, 2) + '/' + str.Substring(6, 2) + " " + str.Substring(8, 2) + ':' + str.Substring(10, 2) + ':' + str.Substring(12, 2);
                    DateTime startTime = Convert.ToDateTime(str);

                    string str1 = pond.endTime;
                    str1 = str1.Substring(0, 4) + '/' + str1.Substring(4, 2) + '/' + str1.Substring(6, 2) + " " + str1.Substring(8, 2) + ':' + str1.Substring(10, 2) + ':' + str1.Substring(12, 2);
                    DateTime endTime = Convert.ToDateTime(str1);

                    TimeSpan timeStamp = endTime.Subtract(startTime).Duration();
                    /*
                    if (timeStamp.TotalSeconds > 180)
                    {
                        MessageBox.Show(pondDictionary[pond.pondSiteNo] + "有车在磅上停留时间超过三分钟", "磅点信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //speacker.SpeakAsync(pondDictionary[pond.pondSiteNo] + "有车在磅上停留时间超过三分钟");
                    }
                     * */
                    //pond.pondTime = timeStamp.TotalSeconds.ToString();
                    int num = Convert.ToInt32(timeStamp.TotalSeconds);
                    count += num;
                    int hour = num / 3600;
                    int minute = (num - hour * 3600) / 60;
                    int seconde = num - hour * 3600 - minute * 60;
                    pond.pondTime = string.Format("{0}小时{1}分钟{2}秒", hour, minute, seconde);
                }
            }
            gcl_main.DataSource = list;
            gvw_main.BestFitColumns();
            count = count / list.Count;
            int hour_1 = count / 3600;
            int minute_1 = (count - hour_1 * 3600) / 60;
            int seconde_1 = count - hour_1 * 3600 - minute_1 * 60;
            textEdit1.Text = string.Format("{0}小时{1}分钟{2}秒", hour_1, minute_1, seconde_1);
        }
        private Hashtable getCondition()
        {
            Hashtable ht = new Hashtable();
            string pondId = string.Empty;
            string carName = string.Empty;
            string startTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.Text.Trim()));//;de_starttime.EditValue
            string endTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_endtime.Text.Trim())); //;de_endtime.EditValue     
            if (!string.IsNullOrEmpty(slu_pondname.Text))
            {
                pondId = slu_pondname.EditValue.ToString().Trim();
            }
            if (!string.IsNullOrEmpty(txt_CarName.Text))
            {
                carName = txt_CarName.Text.Trim();
            }
            ht.Add("StartTime", startTime);
            ht.Add("EndTime", endTime);
            ht.Add("PondSiteNo", pondId);
            ht.Add("CarName", carName);
            return ht;
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "pondSiteNo")
            {
                if (e.Value != null)
                {
                    e.DisplayText = pondDictionary[e.Value.ToString()];
                }
            }
            if (e.Column.FieldName == "startTime" || e.Column.FieldName == "endTime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }
        //测试插入
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             Pond_ComplateTime pond = new Pond_ComplateTime();
             pond.startTime = "20220317164200";
             pond.pondSiteNo = "110";
             pond.carName = "桂N7955";
             MainService.ExecuteDB_InsertPondComplateInfo(pond);
            */
            Hashtable ht = new Hashtable();
            ht.Add("carName", "桂N7955");
            ht.Add("startTime", "20220317164100");
            ht.Add("endTime", "20220317171300");
            MainService.ExecuteDB_UpdatePondComplateInfo(ht);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Pond_ComplateTime pond = new Pond_ComplateTime();
            pond.startTime = "20220317164200";
            pond.pondSiteNo = "110";
            pond.carName = "桂N7956";
            MainService.ExecuteDB_InsertPondComplateInfo(pond);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gcl_main.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                gvw_main.ExportToXls(fileDialog.FileName, options);
            }
        }
        //定时查询过磅时间过长的数据
        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            IList<Pond_ComplateTime> list = MainService.ExecuteDB_QueryUnComplecated();
            if (list != null && list.Count > 0)
            {
                foreach (Pond_ComplateTime pond in list)
                {
                    string str = pond.startTime;
                    str = str.Substring(0, 4) + '/' + str.Substring(4, 2) + '/' + str.Substring(6, 2) + " " + str.Substring(8, 2) + ':' + str.Substring(10, 2) + ':' + str.Substring(12, 2);                   
                    DateTime startTime = Convert.ToDateTime(str);
         
                    TimeSpan timeStamp = DateTime.Now.Subtract(startTime).Duration();
                    if (timeStamp.TotalSeconds > 180)
                    {
                        MessageBox.Show(pondDictionary[pond.pondSiteNo] + "有车在磅上停留时间超过三分钟","磅点信息提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        //speacker.SpeakAsync(pondDictionary[pond.pondSiteNo] + "有车在磅上停留时间超过三分钟");
                    }
                }
            }
        }
         * */


    }
}
