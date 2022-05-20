using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.SM;
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
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_ReasonForNoAuto_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        private SM_ReasonForNoAuto selectMainEntity { get; set; }
        public ISM_ReasonForNoAutoService MainService { get; set; }
        public ISM_PoundSite_InfoService PoundService { get; set; }
        public ISM_Car_InfoService CarService { get; set; }
        public SM_ReasonForNoAuto_Form()
        {
            InitializeComponent();
        }

        private void SM_ReasonForNoAuto_Form_Shown(object sender, EventArgs e)
        {
            //de_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            //de_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            SetMainGridData(false);
            SetData();

        }
        /// <summary>
        /// 设置GridView数据
        /// </summary>
        /// <param name="isFirst"></param>
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;

                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAll();
                    TimeDisplay(rss);
                    gcl_main.DataSource = rss;
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
                    }
                    queryMain = true;
                    SetMainEditerData();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 设置主焦点行
        /// </summary>
        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_ReasonForNoAuto group = gvw_main.GetRow(i) as SM_ReasonForNoAuto;
                    if (group.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        selectMainRowNum = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (!isFocused)
            {
                if (rowcount - 1 < selectMainRowNum)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }
        /// <summary>
        /// 设置编辑区数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_ReasonForNoAuto;
                selectMainEntity = entity;
                queryMain = true;
            }
        }
        private void SetData()
        {
            var _pound = PoundService.ExecuteDB_QueryAll();
            slu_Poundsite.Properties.DataSource = _pound;
            var _car= CarService.ExecuteDB_QueryAll();
            slu_CarNO.Properties.DataSource = _car;
        }
        private void btn_Query_Click(object sender, EventArgs e)
        {
            var rss= MainService.ExecuteDB_QueryByCondition(GetCondition());
            TimeDisplay(rss);
            gcl_main.DataSource = rss;
        }
        private Hashtable GetCondition()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(de_StartTime.Text))
            {
                condition.Add("SDate", CommonHelper.TimeToStr14(Convert.ToDateTime(de_StartTime.EditValue)));
            }
            if(!string.IsNullOrEmpty(de_EndTime.Text))
            {
                condition.Add("EDate", CommonHelper.TimeToStr14(Convert.ToDateTime(de_EndTime.EditValue)));
            }
            if(!string.IsNullOrEmpty(slu_Poundsite.Text))
            {
                condition.Add("SiteNO", slu_Poundsite.EditValue);
            }
            if (!string.IsNullOrEmpty(slu_CarNO.Text))
            {
                condition.Add("CarNO", slu_CarNO.EditValue);
            }
            if (!string.IsNullOrEmpty(cbb_NoAutoWeigh.Text))
            {
                condition.Add("Reason", cbb_NoAutoWeigh.Text);
            }
            return condition;
        }
        /// <summary>
        /// 规范化展示时间格式
        /// </summary>
        /// <param name="rss"></param>
        private void TimeDisplay(IList<SM_ReasonForNoAuto> rss)
        {
            if (rss != null)
            {
                List<SM_ReasonForNoAuto> data = rss.ToList();
                data.ForEach(r =>
                {
                    if (r.UpdateTime != null)
                    {
                        r.Updatetime = CommonHelper.Str14ToTimeFormart(r.Updatetime);
                    }
                    if (r.CreateTime != null)
                    {
                        r.Createtime = CommonHelper.Str14ToTimeFormart(r.Createtime);
                    }
                });
            }
        }
        //测试新增功能
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            //SM_ReasonForNoAuto selectMainEntity = new SM_ReasonForNoAuto();
            //selectMainEntity.Carno = "桂A22222";
            //selectMainEntity.Createuser = SessionHelper.LogUserNickName;
            //selectMainEntity.Updateuser = SessionHelper.LogUserNickName;
            //selectMainEntity.Planno = "TestNo";
            //selectMainEntity.Reason = "未读到RFID";

            //MainService.ExecuteDB_InsertReasonInfo(selectMainEntity);
        }
    }
}
