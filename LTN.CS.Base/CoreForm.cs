using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace LTN.CS.Base
{
    public partial class CoreForm : XtraForm
    {
        public CoreForm()
        {
            InitializeComponent();
        }

        private void CoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        public void ReLoadForm()
        {
            OnLoad(null);
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        public virtual void PrintTable()
        {
            Control.ControlCollection ccs = this.Controls;
            int n;
            if ((n = ccs.Count) > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Control ctl = ccs[i];
                    if (ctl is GridControl || ctl.GetType().IsSubclassOf(typeof(GridControl)))
                    {
                        GridControl gc = ctl as GridControl;
                        gc.ShowPrintPreview();
                        break;
                    }
                }
            }
        }

        public virtual void PrintTable(Control ctl)
        {
             if (ctl is GridControl || ctl.GetType().IsSubclassOf(typeof(GridControl)))
             {
                 GridControl gc = ctl as GridControl;
                 gc.ShowPrintPreview();
                
             }
              
        }

        /// <summary>
        /// 增加行号
        /// </summary>
        /// <param name="view"></param>
        public void InitView(GridView view)
        {
            view.CustomDrawRowIndicator += gvw_main_CustomDrawRowIndicator;
            view.RowCountChanged += gvw_main_RowCountChanged;
        }
        /// <summary>
        /// 增加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {

                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_RowCountChanged(object sender, EventArgs e)
        {
            if (sender is GridView)
            {
                GridView GridView = sender as GridView;
                if (GridView.RowCount > -2 && GridView.RowCount < 1000)
                {
                    GridView.IndicatorWidth = 43;
                }
                else if (GridView.RowCount < 10000)
                {
                    GridView.IndicatorWidth = 52;
                }
                else if (GridView.RowCount < 100000)
                {
                    GridView.IndicatorWidth = 54;
                }
                else if (GridView.RowCount < 1000000)
                {
                    GridView.IndicatorWidth = 64;
                }
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        public virtual void ExportTable()
        {
            
        }

        /// <summary>
        /// 从界面导出数据到EXCEL
        /// </summary>
        /// <param name="dategridview">传入显示数据的DataGridView名字</param>
        /// <param name="columstart"></param>
        public void dgvToExcel(GridControl gvw_main,string filename)
        {
            
                if (gvw_main.DataSource == null)
                {
                    return;
                }
                string fileName = filename;
                string sheetName = filename;

                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = Text;
                fileDialog.FileName = fileName;
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    XlsExportOptions options = new XlsExportOptions();
                    options.SheetName = sheetName;
                    options.TextExportMode = TextExportMode.Text;
                    gvw_main.ExportToXls(fileDialog.FileName, options);
                }
        }


        public string getDateTime(string d_and_t)
        {
            string datetime;
            datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string datetime;
            //try
            //{
            //    DbConnApi database = DbMan.getInstance();
            //    if (!database.getdbstring().Equals("localhost"))
            //    {
            //        string sqlstr = "select to_char(sysdate,'yyyy-mm-dd hh24:mi:ss')  from dual";
            //        DataSet dsCarryid = database.getDataSet(sqlstr, "table"); ;
            //        datetime = dsCarryid.Tables[0].Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //        ////datetime = DateTime.Now.ToLongTimeString();
            //    }
            //}
            //catch
            //{
            //    datetime = DateTime.Now.ToString();
            //}

            if (d_and_t.ToUpper() == "D")
            {
                return datetime.Substring(0, 10);
            }
            if (d_and_t.ToUpper() == "T")
            {
                return datetime.Substring(11);
            }
            if (d_and_t.ToUpper() == "DT")
            {
                return datetime;
            }
            else
            {
                return datetime;
            }
        }


        /// <summary>
        /// D 是取日期，T 是取时间，DT 取日期和时间，NEXT 是往后取几天，BEFORE 是往前取几天
        /// </summary>
        /// <param name="d_and_t">参数"D" 是取日期，"T" 是取时间，"DT" 取日期和时间</param>
        /// <param name="nextbefore">参数"NEXT" 是往后取几天，"BEFORE" 是往前取几天</param>
        /// <param name="num">参数是移动的天数</param>
        /// <returns></returns>
        public string getDateTime(string d_and_t, string nextbefore, int num)
        {
            string datetime;
            //try
            //{
            //    DbConnApi database = DbMan.getInstance();
            //    if (!(database.getdbstring().Equals("localhost")))
            //    {
            //        string sqlstr = "select to_char(sysdate,'yyyy-mm-dd hh24:mi:ss')  from dual";
            //        if (nextbefore.ToUpper() == "NEXT") sqlstr = "select to_char(sysdate+" + num + ",'yyyy-mm-dd hh24:mi:ss')  from dual";
            //        if (nextbefore.ToUpper() == "BEFORE") sqlstr = "select to_char(sysdate-" + num + ",'yyyy-mm-dd hh24:mi:ss')  from dual";
            //        DataSet dsCarryid = database.getDataSet(sqlstr, "table"); ;
            //        datetime = dsCarryid.Tables[0].Rows[0][0].ToString();
            //    }
            //    else
            //    {
            datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (nextbefore.ToUpper() == "NEXT") datetime = DateTime.Now.AddDays(-num).ToString("yyyy-MM-dd HH:mm:ss");
            if (nextbefore.ToUpper() == "BEFORE") datetime = DateTime.Now.AddDays(num).ToString("yyyy-MM-dd HH:mm:ss");
            //    }
            //}
            //catch
            //{
            //    datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    if (nextbefore.ToUpper() == "NEXT") datetime = DateTime.Now.AddDays(-num).ToString("yyyy-MM-dd HH:mm:ss");
            //    if (nextbefore.ToUpper() == "BEFORE") datetime = DateTime.Now.AddDays(num).ToString("yyyy-MM-dd HH:mm:ss");
            //}

            if (d_and_t.ToUpper() == "D")
            {
                return datetime.Substring(0, 10);
            }
            if (d_and_t.ToUpper() == "T")
            {
                return datetime.Substring(11);
            }
            if (d_and_t.ToUpper() == "DT")
            {
                return datetime;
            }
            else
            {
                return datetime;
            }
        }
        /// <summary>
        /// 设置grid字体
        /// </summary>
        /// <param name="view"></param>
        /// <param name="font"></param>
       public void SetGridFont(GridView view)
        {
            foreach (AppearanceObject ap in view.Appearance)
            {
                ap.Font = new Font("Tahoma", 13);
            }
        }

        public void setApprence(Control  cc) 
        {
            Control.ControlCollection ccs = this.Controls;
            int n;
            if ((n = ccs.Count) > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Control ctl = ccs[i];
                    if (ctl is GridControl || ctl.GetType().IsSubclassOf(typeof(GridControl)))
                    {
                        GridControl gc = ctl as GridControl;

                        gc.Font = new Font("Tahoma", 13, FontStyle.Bold);
                        
                        break;
                    }
                    if (ctl is LayoutControl || ctl.GetType().IsSubclassOf(typeof(LayoutControl))) 
                    {
                        LayoutControl ly = ctl as LayoutControl;
                        
                        
                    }
                }
            }
        
        }
    }
}