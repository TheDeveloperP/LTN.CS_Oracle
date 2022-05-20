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
namespace LTN.CS.SCMForm.PM
{
    public partial class testForm : CoreForm
    {
        public testForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("测试按钮");
        }
    }
}