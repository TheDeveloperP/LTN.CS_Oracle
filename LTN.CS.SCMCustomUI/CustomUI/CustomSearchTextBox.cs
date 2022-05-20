using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMCustomUI.CustomUI
{
    public partial class CustomSearchTextBox : UserControl
    {
        public override string Text
        {
            get { return text; }
            set
            {
                this.buttonEdit1.Text = value;
                _selectText = value;
                text = value;
            }
        }
        private string text = string.Empty;
        public string SelectText
        {
            get
            {
                return _selectText;
            }
            set
            {
                this.buttonEdit1.Text = value;
                _selectText = value;
                this.Text = value;
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
        private string _selectkey = string.Empty;
        public object Datasources { get; set; }



        public CustomSearchTextBox()
        {
            InitializeComponent();
        }

        private int x;
        private int y;
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 30, specified);
            this.x = x;
            this.y = y;
        }


        private void SearchForm_SelectRowChangeEvent(string selectkey, string selectText)
        {
            this.SelectText = selectText;
            this.SelectKey = selectkey;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            CustomSearchTextBox_Form SearchForm = new CustomSearchTextBox_Form();
            SearchForm.DataSouces = Datasources;
            var dp = this.PointToClient(MousePosition);
            int X = this.Width - dp.X ;
            int Y = this.Height - dp.Y;

            SearchForm.Location = new Point(MousePosition.X-dp.X, MousePosition.Y+Y-1) ;
            SearchForm.SelectRowChangeEvent += SearchForm_SelectRowChangeEvent;
            SearchForm.Show();
        }
    }
}
