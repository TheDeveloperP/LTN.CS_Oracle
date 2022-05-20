using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.Common;

namespace LTN.CS.SCMForm.PM
{
    public partial class XtraReport5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport5()
        {
            InitializeComponent();
        }

        private void XtraReport5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = Wgstion.fromdeptname;
            xrLabel5.Text = Wgstion.todeptname;
            xrLabel7.Text = Wgstion.materialname;
            xrLabel9.Text = SessionHelper.LogUserNickName;
        }
        int i = 0;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (i != 0 && i % 20 == 0) //每页显示20条
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            }
            else
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            }
            i++;
        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime dt;
            if (xrTableCell9.Text != string.Empty)
            {
                dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell9.Text));
                xrTableCell9.Text = dt.ToString("MM-dd HH:mm");
            }
            if (xrTableCell10.Text != string.Empty)
            {
                dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell10.Text));
                xrTableCell10.Text = dt.ToString("MM-dd HH:mm");
            }
            if (xrTableCell12.Text != string.Empty)
            {
                xrTableCell12.Text = (Convert.ToDouble(xrTableCell12.Text) / 1000).ToString("0.00");
            }
            if (xrTableCell13.Text != string.Empty)
            {
                xrTableCell13.Text = (Convert.ToDouble(xrTableCell13.Text) / 1000).ToString("0.00");
            }
            if (xrTableCell14.Text != string.Empty)
            {
                xrTableCell14.Text = (Convert.ToDouble(xrTableCell14.Text) / 1000).ToString("0.00");
            }
        }
    }
}
