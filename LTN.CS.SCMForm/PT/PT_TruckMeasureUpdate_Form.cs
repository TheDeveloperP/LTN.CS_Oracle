using LTN.CS.SCMEntities.PT;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;
using LTN.CS.Base;

namespace LTN.CS.SCMForm.PT
{
    public partial class PT_TruckMeasureUpdate_Form : CoreForm
    {
        public IPT_TruckMeasurePlanService MainService { get; set; }
        public IList<PT_TruckMeasurePlan> list { get; set; }

        public PT_TruckMeasureUpdate_Form()
        {
            InitializeComponent();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PT_TruckMeasureUpdate_Form_Shown(object sender, EventArgs e)
        {
            //string planno = list.Select(s => s.C_PLANNO).ToString();
            //var r = MainService.ExecuteDB_QueryTruckMeasureUsingPlanByPlanNo(planno);
            //fromdeptno = r.C_FROMDEPTNO;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (list != null)
            {
                dxErrorProvider1.ClearErrors();
                //if (txt_fromdept.Text == "")
                //{
                //    dxErrorProvider1.SetError(txt_fromdept, "来源单位不能为空!", ErrorType.Information);
                //}
                //if (txt_todept.Text == "")
                //{
                //    dxErrorProvider1.SetError(txt_todept, "去向单位不能为空！", ErrorType.Information);
                //}
                if (dxErrorProvider1.HasErrors) { return; }
                PT_TruckMeasurePlan rss = MainService.ExecuteDB_QueryTruckMeasurePlanByfromdept(txt_fromdept.Text);
                //if (rss == null) { return; }
                //string fromdeptno = rss.C_FROMDEPTNO;
                //string fromstoreno = rss.C_FROMSTORENO;
                //string todeptno = rss.C_TODEPTNO;
                //string tostoreno = rss.C_TOSTORENO;
                foreach (PT_TruckMeasurePlan p in list)
                {
                    if (!string.IsNullOrEmpty(txt_fromdept.Text.Trim()))
                    {
                        p.C_FROMDEPTNAME = txt_fromdept.Text.Trim();//来源单位名称
                    }
                    if (!string.IsNullOrEmpty(txt_todept.Text.Trim()))
                    {
                        p.C_TODEPTNAME = txt_todept.Text.Trim();//去向单位名称
                    }
                    if (!string.IsNullOrEmpty(txt_MATERIALNAME.Text.Trim()))
                    {
                        p.C_MATERIALNAME = txt_MATERIALNAME.Text.Trim();//品名名称
                    }
                    if (!string.IsNullOrEmpty(txt_CONTAINERNO.Text.Trim()))
                    {
                        p.C_CONTAINERNO = txt_CONTAINERNO.Text.Trim();//集装箱号
                    }
                    if (!string.IsNullOrEmpty(txt_REMARK.Text.Trim()))
                    {
                        p.C_REMARK = txt_REMARK.Text.Trim();//备注
                    }
                    //if (!string.IsNullOrEmpty(fromdeptno))
                    //{
                    //    p.C_FROMDEPTNO = fromdeptno;//来源单位编码
                    //}
                    //if (!string.IsNullOrEmpty(fromstoreno))
                    //{
                    //    p.C_FROMSTORENO = fromstoreno;//来源仓库编码
                    //}

                    //if (!string.IsNullOrEmpty(todeptno))
                    //{
                    //    p.C_TODEPTNO = todeptno;//去向单位编码
                    //}
                    //if (!string.IsNullOrEmpty(tostoreno))
                    //{
                    //    p.C_TOSTORENO = tostoreno;//去向仓库编码
                    //}
                }
                try
                {
                    var rs = MainService.ExecuteDB_UpdateTruckMeasurePlanForBatch(list);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                        return;
                    }
                    else
                    {
                        MessageDxUtil.ShowTips("批量修改成功！");
                        this.Close();
                    }


                }
                catch (Exception ex)
                {
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
        }
    }
}
