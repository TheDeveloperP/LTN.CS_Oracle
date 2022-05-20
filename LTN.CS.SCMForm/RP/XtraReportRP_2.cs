using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.Core.Helper;
using LTN.CS.SCMForm.Common;
using ZXing.Common;
using ZXing;

namespace LTN.CS.SCMForm.RP
{
    public partial class XtraReportRP_2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportRP_2()
        {
            InitializeComponent();
        }

        private void XtraReport3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = Wgstion.fromdeptname;
            xrLabel5.Text = Wgstion.todeptname;
            xrLabel7.Text = Wgstion.materialname;
            xrLabel9.Text = SessionHelper.LogUserNickName;

            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 50; // 必须制定高度、宽度
            encodeOption.Width = 100;
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字
            Bitmap img = wr.Write(Wgstion.wgistion1); // 生成图片

            pic.Image = img;
        }
        int i = 0;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (i != 0 && i % 20 == 0) //每页显示8条
            //{
            //    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            //}
            //else
            //{
            //    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            //}
            //i++;
            //修改
            i++;
            if ((i == 51) || (i % 51 == 0))
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            }
            else
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            }
        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DateTime dt;
            //if (xrTableCell9.Text != string.Empty)
            //{
            //    dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell9.Text));
            //    xrTableCell9.Text = dt.ToString("MM-dd HH:mm");
            //}
            //if (xrTableCell10.Text != string.Empty)
            //{
            //    dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell10.Text));
            //    xrTableCell10.Text = dt.ToString("MM-dd HH:mm");
            //}
            //if (xrTableCell12.Text != string.Empty)
            //{
            //    xrTableCell12.Text = (Convert.ToDecimal(xrTableCell12.Text) * 1000).ToString();
            //}
            //if (xrTableCell13.Text != string.Empty)
            //{
            //    xrTableCell13.Text = (Convert.ToDecimal(xrTableCell13.Text) * 1000).ToString();
            //}
            //if (xrTableCell14.Text != string.Empty)
            //{
            //    xrTableCell14.Text = (Convert.ToDecimal(xrTableCell14.Text) * 1000).ToString();
            //}
            //修改
            xrLabel12.Text = DateTime.Now.ToString();
        }

        private void xrLabel11_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            int pageindex = e.PageIndex;
            int value = pageindex + 1;
            this.xrLabel11.Text = string.Format("第{0}页", value);
        }
    }
}
