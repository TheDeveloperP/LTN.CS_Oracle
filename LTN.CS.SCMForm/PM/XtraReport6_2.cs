using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LTN.CS.Core.Helper;
using ZXing.Common;
using ZXing;
using LTN.CS.SCMEntities.ConditionEntity;

namespace LTN.CS.SCMForm.PM
{
    public partial class XtraReport6_2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport6_2()
        {
            InitializeComponent();
            xrLabel7.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xrLabel12.Text = SessionHelper.LogUserNickName;
        }

        private void XtraReport6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 50; // 必须制定高度、宽度
            encodeOption.Width = 100;
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字
            Bitmap img = wr.Write(Wgstion.wgistion1); // 生成图片

            pic.Image = img;
        }

    }
}
