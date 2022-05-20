using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMCustomUI.CustomUI
{
    public  delegate void SelectRowChangeHandel(string selectkey, string selectText);
    public partial class CustomSearchTextBox_Form : Form
    {

        public event SelectRowChangeHandel SelectRowChangeEvent;
        public string SelectText
        {
            get
            {
                return _selectText;
            }
            set
            {
                _selectText = value;
                SelectRowChangeEvent(SelectKey,SelectText);
            }
        }
        private string _selectText = string.Empty;
        public string SelectKey
        {
            get { return _selectkey; }
            set
            {
                _selectkey = value;
            }
        }
        private  string _selectkey { get; set; }
        public object DataSouces { get; set; }

        public CustomSearchTextBox_Form()
        {
            InitializeComponent();
            this.Shown += CustomSearchTextBox_Form_Shown;
        }

        private void CustomSearchTextBox_Form_Shown(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = DataSouces;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var item = this.gridView1.GetFocusedRow() as SM_Materiel_Level;
            if (item == null)
            {
                return;
            }
            SelectKey = item.MaterielCode;
            SelectText = item.MaterielName;
            this.Dispose();
        }

        private void CustomSearchTextBox_Form_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
