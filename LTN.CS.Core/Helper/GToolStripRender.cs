using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace LTN.CS.Core.Helper
{
    /// <summary>
    /// 自定义ToolStrip渲染器
    /// </summary>
    public class GToolStripRender : ToolStripProfessionalRenderer
    {
        public GToolStripRender()
        {
            
        }
        public GToolStripRender(ProfessionalColorTable professionalColorTable)
            : base(professionalColorTable)
        {
            
        }
        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            toolStrip.Paint += toolStrip_Paint;
        }
        private void toolStrip_Paint(object sender, PaintEventArgs e)
        {
            var ts = sender as ToolStrip;
            if ((ts.Height == 0) || (ts.Width == 0)) return;

            var clrTop = Color.FromArgb(255, 255, 255);
            var clrButtom = Color.FromArgb(230, 230, 235);
            var rect = new Rectangle(0, 0, ts.Width, ts.Height);
            var brush = new LinearGradientBrush(rect, clrTop, clrButtom, 90f);
            using (brush) e.Graphics.FillRectangle(brush, rect);

            Color clrLine3 = Color.FromArgb(248, 249, 251);
            Color clrLine2 = Color.FromArgb(184, 186, 194);
            Color clrLine1 = Color.FromArgb(222, 223, 226);
            using (var pen0 = new Pen(clrLine3)) e.Graphics.DrawLine(pen0, 0, 0, ts.Width, 0);
            using (var pen3 = new Pen(clrLine3)) e.Graphics.DrawLine(pen3, 0, ts.Height - 3, ts.Width, ts.Height - 3);
            using (var pen2 = new Pen(clrLine2)) e.Graphics.DrawLine(pen2, 0, ts.Height - 2, ts.Width, ts.Height - 2);
            using (var pen1 = new Pen(clrLine1)) e.Graphics.DrawLine(pen1, 0, ts.Height - 1, ts.Width, ts.Height - 1);
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }
}
