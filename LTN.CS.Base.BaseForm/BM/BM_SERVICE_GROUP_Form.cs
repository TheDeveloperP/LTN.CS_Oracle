using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.BusinessService.BM.Interface;
using System.Threading;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_SERVICE_GROUP_Form : CoreForm
    {
        #region 实例变量
        public IBMGROUPService groupService { get; set; }
        public IBMSERVERService serverService { get; set; }
        public IBMGROUPSERVERService groupServerService { get; set; }
        private int selectId { get; set; }
        private BM_GROUP groupSelect { get; set; }
        #endregion

        #region 构造函数
        public BM_SERVICE_GROUP_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 界面加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_SERVICE_GROUP_Form_Load(object sender, EventArgs e)
        {
            SetGridData(true);
        }
        /// <summary>
        /// 主视图焦点行切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvw_main != null && gvw_main.GetFocusedRow() != null)
            {
                groupSelect = gvw_main.GetFocusedRow() as BM_GROUP;
                selectId = groupSelect.IntId;
                SetLeftGridData();
                SetRighrGridData();
            }
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            SetGridData(false);
        }
        /// <summary>
        /// 删除服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            CustomDelete();
        }
        /// <summary>
        /// 添加服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            CustomAdd();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 设定Grid数据
        /// </summary>
        private void SetGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectIdOld = selectId;
                    gcl_center.DataSource = groupService.ExecuteDB_QueryAll();
                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectId = selectIdOld;
                        SetLeftFocusRow();
                        SetLeftGridData();
                        SetRighrGridData();
                    }
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 左服务视图数据绑定
        /// </summary>
        private void SetLeftGridData()
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    gridControl1.DataSource = serverService.ExecuteDB_QueryInGroup(selectId);
                    gridView1.BestFitColumns();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 左服务视图数据绑定
        /// </summary>
        private void SetRighrGridData()
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    gridControl2.DataSource = serverService.ExecuteDB_QueryNotInGroup(selectId);
                    gridView2.BestFitColumns();
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 焦点行转换
        /// </summary>
        private void SetLeftFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    BM_GROUP group = gvw_main.GetRow(i) as BM_GROUP;
                    if (group.IntId == selectId)
                    {
                        gvw_main.FocusedRowHandle = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectId)
                {
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectId = rowcount - 1;
                }
                else if (selectId == 0)
                {
                    gvw_main.FocusedRowHandle = 0;
                    selectId = 0;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectId;
                }
            }
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        private void CustomDelete()
        {
            try
            {
                if (gridView1 != null && gridView1.GetFocusedRow() != null)
                {
                    BM_USER user = SessionHelper.LogUser as BM_USER;
                    if (groupSelect.CreateEMPId.IntId != user.IntId && groupSelect.ManageEMPId.IntId != user.IntId)
                    {
                        MessageDxUtil.ShowError("当前用户无管理权限！");
                        return;
                    }
                    BM_SERVICE service = gridView1.GetFocusedRow() as BM_SERVICE;
                    BM_SERVICE_GROUP serviceGroup = new BM_SERVICE_GROUP()
                    { 
                        GroupId = selectId,
                        ServiceId = service.IntId 
                    };
                    var rs = groupServerService.ExecuteDB_Delete(serviceGroup);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                        return;
                    }
                    SetGridData(false);
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }

        /// <summary>
        /// 自定义添加
        /// </summary>
        private void CustomAdd()
        {
            try
            {
                if (gridView2 != null && gridView2.GetFocusedRow() != null)
                {
                    BM_USER user = SessionHelper.LogUser as BM_USER;
                    if (groupSelect.CreateEMPId.IntId != user.IntId && groupSelect.ManageEMPId.IntId != user.IntId)
                    {
                        MessageDxUtil.ShowError("当前用户无管理权限！");
                        return;
                    }
                    BM_SERVICE service = gridView2.GetFocusedRow() as BM_SERVICE;
                    BM_SERVICE_GROUP serviceGroup = new BM_SERVICE_GROUP()
                    {
                        GroupId = selectId,
                        ServiceId = service.IntId,
                        CreateUser = SessionHelper.LogUser as BM_USER,
                        UpdateUser = SessionHelper.LogUser as BM_USER
                    };
                    var rs = groupServerService.ExecuteDB_Insert(serviceGroup);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                        return;
                    }
                    SetGridData(false);
                }
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }
        #endregion




    }
}
