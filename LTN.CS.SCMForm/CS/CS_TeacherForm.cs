using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base;
using LTN.CS.SCMService.CS.Interface;
using System.Threading;
using LTN.CS.SCMEntities.CS;
using LTN.CS.Core.Helper;
using LTN.CS.Core.Common;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Collections;

namespace LTN.CS.SCMForm.CS
{
    public partial class CS_TeacherForm : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private bool queryMain { get; set; }
        public ITeacherService studentService { get; set; }
        private CS_Teacher selectMainEntity { get; set; }

        public CS_TeacherForm()
        {
            InitializeComponent();
        }

        private void CS_Teacher_Shown(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        /// <summary>
        /// 设定主档Grid数据
        /// 获取数据
        /// </summary>
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = studentService.ExecuteDB_QueryAll();

                    gcl_main.DataSource = rss;

                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
                    }
                    queryMain = true;
                    SetMainEditerData();
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 设定操作区数据
        /// </summary>
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as CS_Teacher;
                if (entity != null)
                {
                    SetMainEditer(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                selectMainEntity = entity;
                queryMain = true;
            }
        }

        /// <summary>
        /// 设定主档编辑区
        /// </summary>
        /// <param name="entity"></param>
        private void SetMainEditer(CS_Teacher entity)
        {
            if (entity != null && entity.teacherName != null)
            {
               
                txt_stuName.EditValue = entity.teacherName;
                txt_stuAge.EditValue = entity.teacherAge.ToString();

            }
        }

        private void ClearMainEditer()
        {
         
            txt_stuName.EditValue = string.Empty;
            txt_stuAge.EditValue = string.Empty;
            
        }

        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_Add.Enabled = true;
                btn_update.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else
            {
                btn_Add.Enabled = false;
                btn_update.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Confirm.Enabled = true;
                btn_Cancel.Enabled = true;
            }
        }

        private void SetMainEditerEnabled(bool enabled)
        {
           
            txt_stuName.Enabled = enabled;
            txt_stuAge.Enabled = enabled;


            if (enabled)
            {
                txt_stuName.Focus();
            }
        }

        /// <summary>
        /// 主档焦点行转换
        /// 修改后默认选中
        /// </summary>
        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    CS_Teacher group = gvw_main.GetRow(i) as CS_Teacher;
                    if (group.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        selectMainRowNum = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (!isFocused)
            {
                if (rowcount - 1 < selectMainRowNum)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_Confirm.Click += eventMainNow;
        }

        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = studentService.ExecuteDB_InsertStudent(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        public void ResetSelectMainEntity()
        {
            dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(txt_stuName.Text))
            {
                dxErrorProvider1.SetError(txt_stuName, "学生姓名为必填！", ErrorType.Information);
            }

            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                selectMainEntity = new CS_Teacher()
                {  
                };
            }
            selectMainEntity.teacherName = txt_stuName.Text;
            selectMainEntity.teacherAge = MyNumberHelper.ConvertToInt32(txt_stuAge.Text);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_Confirm.Click += eventMainNow;
        }

        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = studentService.ExecuteDB_UpdateStudent(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_Confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            CS_Teacher gates = gvw_main.GetFocusedRow() as CS_Teacher;
            if (gates == null)
            {
                MessageBox.Show("没有数据可以删除!");
                return;
            }
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
        }

        private void CustomMainDelete()
        {
            try
            {
                var rs = studentService.ExecuteDB_DeleteStudent(selectMainEntity);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as CS_Teacher;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
                SetMainButtonEnabled(true);
            }
        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(txt_stuNameS.Text.Trim()))
            {
                ht.Add("teacherName", txt_stuNameS.Text.Trim());
            }
            var rss = studentService.ExecuteDB_QueryAllByName(ht);
            gcl_main.DataSource = rss;
            gvw_main.BestFitColumns();
        }



    }
}
