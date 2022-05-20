using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_ShowTruckPicture : Form
    {
        public PictureEdit pxs { get; set; }

        public PM_ShowTruckPicture()
        {
            InitializeComponent();
            pxs = PE1;
        }

        private void PE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 16.54822f;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }
    }
}
