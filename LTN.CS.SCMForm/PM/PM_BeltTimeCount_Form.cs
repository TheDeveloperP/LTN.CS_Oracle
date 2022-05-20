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
using DevExpress.XtraPrinting;

//using pSpaceCTLNET;


namespace LTN.CS.SCMForm.PM
{
    public partial class PM_BeltTimeCount_Form : CoreForm
    {
        public IPT_BeltScalePlanService PT_BeltScalePlanService { get; set; }
        public IPM_BeltHandlerService MainService { get; set; }


        // private DbConnector dbconnector = new DbConnector();

        public PM_BeltTimeCount_Form()
        {
            InitializeComponent();
        }

        private void PM_BeltTimeCount_Form_Shown(object sender, EventArgs e)
        {
            InitView(gridView1);
            de_starttime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            de_endtime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            txt_beltNo.Focus();
            if (string.IsNullOrEmpty(de_starttime.Text.Trim()))
            {
                MessageBox.Show("请输入开始时间", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(de_endtime.Text.Trim()))
            {
                MessageBox.Show("请输入结束时间", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("请输入取数间隔（单位：秒)", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */
            Hashtable ht = getCondition();
            List<PM_BeltTimeCount> list = MainService.getBeltRunTime(ht);
            if (list != null && list.Count > 0)
            {
                string queryStartTime = ht["startTime"].ToString();
                string queryStopTime = ht["endTime"].ToString();

                foreach (PM_BeltTimeCount count in list)
                {
                    int planTimeCount = 0;
                    string beltNo = count.c_beltno;
                    Hashtable table = getCondition();
                    table.Add("countBeltNo", beltNo);
                    IList<PT_BeltScalePlan> planList = PT_BeltScalePlanService.ExecuteDB_QueryBeltPlanByConditions(table);
                    //得到了涉及到该皮带秤，该时间段内的所有委托
                    foreach (PT_BeltScalePlan plan in planList)
                    {
                        planTimeCount += calculateTime(queryStartTime, queryStopTime, plan);
                    }
                    count.c_planTimeTotalCount = transferTime(planTimeCount);
                    int beltTimeCount = Convert.ToInt32(count.c_beltTimeTotalCount);
                    count.c_beltTimeTotalCount = transferTime(beltTimeCount);
                    count.c_countAbsoluteValue = transferTime(beltTimeCount - planTimeCount);
                }
            }
            else
            {
                MessageBox.Show("该皮带秤编号暂时未进行在线取数", "操作提示", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
            }
            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
            gridView1.FocusedRowHandle = 0;
        }
        private Hashtable getCondition()
        {
            Hashtable ht = new Hashtable();

            string beltNo = string.IsNullOrEmpty(txt_beltNo.Text) ? string.Empty : txt_beltNo.EditValue.ToString().Trim();
            string startTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_starttime.Text.Trim()));//;de_starttime.EditValue
            string endTime = CommonHelper.TimeToStr14(Convert.ToDateTime(de_endtime.Text.Trim())); //;de_endtime.EditValue     
            //string interval = textEdit1.Text.Trim();
            ht.Add("startTime", startTime);
            ht.Add("endTime", endTime);
            ht.Add("beltNo", beltNo);
            //ht.Add("interval", interval);
            return ht;
        }

        private void gvw_main_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //absoluteValue   beltTimeCount   planTimeCount

            if (e.Column.FieldName == "absoluteValue" || e.Column.FieldName == "beltTimeCount" || e.Column.FieldName == "planTimeCount")
            {
                if (e.Value != null)
                {
                    //把值转化为分钟    假设当前num是以秒为单位            
                    int num = Convert.ToInt32(e.Value.ToString());
                    int hour = num / 3600;
                    int minute = (num - hour * 3600) / 60;
                    int seconde = num - hour * 3600 - minute * 60;
                    e.DisplayText = string.Format("{0}小时{1}分钟{2}秒", hour, minute, seconde);
                }
            }

        }
        //测试插入             

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gridControl1.DataSource == null)
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
                gridView1.ExportToXls(fileDialog.FileName, options);
            }
        }
        public int calculateTime(string time1, string time2, PT_BeltScalePlan plan)
        {
            int count = 0;
            DateTime queryStartTime = DateTime.ParseExact(time1, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
            DateTime queryStopTime = DateTime.ParseExact(time2, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
            DateTime startTime = DateTime.ParseExact(plan.C_Starttime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
            if (plan.C_Stoptime == null)
            {
                DateTime stopTime = new DateTime();
                DateTime startTimeTemp = new DateTime();
                DateTime tempTime = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                if (tempTime > queryStopTime)
                {
                    stopTime = queryStopTime;
                }
                else
                {
                    stopTime = tempTime;
                }
                if (startTime < queryStartTime)
                {
                    startTimeTemp = queryStartTime;
                }
                else
                {
                    startTimeTemp = startTime;
                }
                //DateTime stopTime = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                count += Convert.ToInt32((stopTime - startTimeTemp).TotalSeconds);
            }
            else
            {
                DateTime stopTime = DateTime.ParseExact(plan.C_Stoptime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                //分四种情况处理时间
                if (queryStartTime >= startTime && stopTime >= queryStopTime)
                {
                    count += Convert.ToInt32((queryStopTime - queryStartTime).TotalSeconds);
                }
                else if (queryStartTime > startTime && queryStopTime > stopTime && stopTime > queryStartTime)
                {
                    count += Convert.ToInt32((stopTime - queryStartTime).TotalSeconds);
                }
                else if (startTime > queryStartTime && stopTime > queryStopTime && queryStopTime > startTime)
                {
                    count += Convert.ToInt32((queryStopTime - startTime).TotalSeconds);
                }
                else if (startTime >= queryStartTime && queryStopTime >= stopTime)
                {
                    count += Convert.ToInt32((stopTime - startTime).TotalSeconds);
                }
            }

            return count;
        }

        public string transferTime(int count)
        {
            if (count == 0)
            {
                return "0小时0分0秒";
            }
            int num = count;
            int hour = num / 3600;
            int minute = (num - hour * 3600) / 60;
            int seconde = num - hour * 3600 - minute * 60;
            string time = string.Format("{0}小时{1}分钟{2}秒", hour, minute, seconde);
            return time;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}
