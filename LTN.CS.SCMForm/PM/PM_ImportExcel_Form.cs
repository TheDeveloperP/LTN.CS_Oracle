using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Core.Helper;
using System.IO;
using DevExpress.Spreadsheet;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_ImportExcel_Form : Form
    {
        public PM_ImportExcel_Form()
        {
            InitializeComponent();
        }
        public List<Cell> Cells = null;
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
           Cells = SheetControl.ActiveWorksheet.GetUsedRange().ToList();
           this.Close();
        }
    }
}
