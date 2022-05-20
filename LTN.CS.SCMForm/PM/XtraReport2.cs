using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LTN.CS.Core.Helper;
using ZXing.Common;
using ZXing;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMForm.Common;

namespace LTN.CS.SCMForm.PM
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport2()
        {
            InitializeComponent();
            xrLabel7.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xrLabel12.Text = SessionHelper.LogUserNickName;
        }

        private void XtraReport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //EncodingOptions encodeOption = new EncodingOptions();
            //encodeOption.Height = 50; // 必须制定高度、宽度
            //encodeOption.Width = 100;
            //ZXing.BarcodeWriter wr = new BarcodeWriter();
            //wr.Options = encodeOption;
            //wr.Format = BarcodeFormat.QR_CODE; //  条形码规格：EAN13规格：12（无校验位）或13位数字
            //Bitmap img = wr.Write(Wgstion.wgistion1); // 生成图片

            //pic.Image = img;
        }

        private void xrTable1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime dt;
            if (xrTableCell8.Text != string.Empty)
            {
                dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell8.Text));
                xrTableCell8.Text = dt.ToString("MM-dd HH:mm");
            }
            if (xrTableCell9.Text != string.Empty)
            {
                dt = Convert.ToDateTime(CommonHelper.Str14ToTimeFormart(xrTableCell9.Text));
                xrTableCell9.Text = dt.ToString("MM-dd HH:mm");
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
