using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using System.Threading;
using DevExpress.XtraGrid.Views.Base;
using Spring.Context;
using Spring.Context.Support;
using System.Collections;

namespace LTN.CS.Base.BaseForm.BM
{
    public partial class BM_DELIVERY_Form : CoreForm
    {
        
        #region  实例变量
        public IBMDELIVERYService mainService { get; set; } //审核服务
        public IBMDELIVERYHISTORYService historyService { get; set; } //审核历史服务
        private IDeliveryService deliveryService { get; set; } //审核核心服务
        private int selectId; //当前主表焦点行ID
        private bool queryBottom;
        #endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BM_DELIVERY_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region  自定义方法

        private void QueryDeliberyUser()
        {
             
        }

        /// <summary>
        /// 查询审核数据
        /// </summary>
        private void QueryDeliveryData()
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    try
                    {
                        if (gvw_left != null && gvw_left.GetFocusedRow() != null)
                        {
                            BM_DELIVERY entitySelect = gvw_left.GetFocusedRow() as BM_DELIVERY;
                            IApplicationContext ctx = ContextRegistry.GetContext();
                            deliveryService = ctx.GetObject(entitySelect.ServiceName) as IDeliveryService;
                            gvw_right.Columns.Clear();
                            gcl_right.DataSource = deliveryService.ExecuteDB_QueryData(entitySelect.DataId);
                            gvw_right.BestFitColumns();
                        }
                        else
                        {
                            gcl_right.DataSource = null;
                            gvw_right.BestFitColumns();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDxUtil.ShowError(ex.Message);
                    }
                    
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        /// <summary>
        /// 查询历史信息
        /// </summary>
        private void QueryDeliberyHistory()
        { 
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    if (gvw_left != null && gvw_left.GetFocusedRow() != null)
                    {
                        BM_DELIVERY entity = gvw_left.GetFocusedRow() as BM_DELIVERY;
                        if (entity.Status.DeliveryValue != 1)
                        {
                            ResetButton(false);
                        }
                        else
                        {
                            ResetButton(true);
                        }
                        IList<BM_DELIVERY_HISTORY> rs = historyService.ExecuteDB_QueryByMainId(entity.IntId);
                        gcl_bottom.DataSource = rs;
                        gvw_bottom.BestFitColumns();
                    }
                    else
                    {
                        gcl_bottom.DataSource = null;
                        gvw_bottom.BestFitColumns();
                        ResetButton(false);
                    }
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 查询审核信息
        /// </summary>
        private void QueryDelivery(bool isFirst)
        {

            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    queryBottom = false;
                    try
                    {
                        int selectIdOld = selectId;
                        object rs;
                        if (txt_IsDeliveried.InnerEditor.Checked)
                        {
                            rs = mainService.ExecuteDB_QueryEntityByStatus(2, 3);
                        }
                        else
                        {
                            rs = mainService.ExecuteDB_QueryEntityByStatus(1);
                        }
                        if (rs is CustomDBError)
                        {
                            MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                            return;
                        }
                        else
                        {
                            gcl_left.DataSource = rs;
                            gvw_left.BestFitColumns();
                        }
                        if (!isFirst)
                        {
                            selectId = selectIdOld;
                        }
                        SetLeftFocusRow();
                        if (rs == null)
                        {
                            gcl_right.DataSource = null;
                            gcl_bottom.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDxUtil.ShowError(ex.Message);
                    }
                    queryBottom = true;
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
            int rowcount = gvw_left.RowCount;
            bool isFocused = false;
            if (selectId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    BM_DELIVERY dic = gvw_left.GetRow(i) as BM_DELIVERY;
                    if (dic.IntId == selectId)
                    {
                        gvw_left.FocusedRowHandle = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (selectId == 0 || !isFocused)
            {
                if (rowcount - 1 < selectId)
                {
                    gvw_left.FocusedRowHandle = rowcount - 1;
                    selectId = rowcount - 1;
                }
                else if (selectId == 0)
                {
                    gvw_left.FocusedRowHandle = 0;
                    selectId = 0;
                }
                else
                {
                    gvw_left.FocusedRowHandle = selectId;
                }
            }
        }

        /// <summary>
        /// 用户自定义退回
        /// </summary>
        private void CustomRollBack()
        {
            try
            {
                DialogResult dr = MessageDxUtil.ShowYesNoAndTips("确认退回该单据吗？");
                if (dr == DialogResult.Yes)
                {
                    if (gvw_left != null && gvw_left.GetFocusedRow() != null)
                    {
                        BM_DELIVERY entitySelect = gvw_left.GetFocusedRow() as BM_DELIVERY;
                        BM_DELIVERY_HISTORY history = new BM_DELIVERY_HISTORY()
                        {
                            MainId = entitySelect.IntId,
                            Operator = new BM_USER() { IntId = SessionHelper.LogUserId },
                            Remarks = textEdit1.Text,
                            CreateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                            UpdateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                            OperatorType = "退回"
                        };
                        entitySelect.Status.DeliveryValue = 3;
                        entitySelect.Remarks = textEdit1.Text;
                        object rs = mainService.ExecuteDB_Quasi(entitySelect, history);
                        if (rs is CustomDBError)
                        {
                            MessageDxUtil.ShowError("退回失败：" + ((CustomDBError)rs).ErrorMsg);
                        }
                        else
                        {
                            IApplicationContext ctx = ContextRegistry.GetContext();
                            deliveryService = ctx.GetObject(entitySelect.ServiceName) as IDeliveryService;
                            rs = deliveryService.ExecuteDB_SendBack(entitySelect);
                            if (rs is CustomDBError)
                            {
                                entitySelect.Status.DeliveryValue = 1;
                                mainService.ExecuteDB_UnQuasi(entitySelect);
                                MessageDxUtil.ShowError("退回失败：" + ((CustomDBError)rs).ErrorMsg);
                            }
                            else
                            {
                                MessageDxUtil.ShowTips("退回成功");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError("退回失败：" + ex.Message);
            }
            finally
            {
                QueryDelivery(true);
                QueryDeliberyHistory();
                QueryDeliveryData();
            }
        }

        /// <summary>
        /// 用户自定义核准
        /// </summary>
        private void CustomDelivery()
        {
            try
            {
                 DialogResult dr = MessageDxUtil.ShowYesNoAndTips("确认核准该单据吗？");
                 if (dr == DialogResult.Yes)
                 {
                     if (gvw_left != null && gvw_left.GetFocusedRow() != null)
                     {
                         BM_DELIVERY entitySelect = gvw_left.GetFocusedRow() as BM_DELIVERY;
                         BM_DELIVERY_HISTORY history = new BM_DELIVERY_HISTORY()
                         {
                             MainId = entitySelect.IntId,
                             Operator = new BM_USER() { IntId = SessionHelper.LogUserId },
                             Remarks = textEdit1.Text,
                             CreateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                             UpdateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                             OperatorType = "核准"
                         };
                         entitySelect.Status.DeliveryValue = 2;
                         entitySelect.Remarks = textEdit1.Text;
                         object rs = mainService.ExecuteDB_Quasi(entitySelect, history);
                         if (rs is CustomDBError)
                         {
                             MessageDxUtil.ShowError("核准失败：" + ((CustomDBError)rs).ErrorMsg);
                         }
                         else
                         {
                             IApplicationContext ctx = ContextRegistry.GetContext();
                             deliveryService = ctx.GetObject(entitySelect.ServiceName) as IDeliveryService;
                             rs = deliveryService.ExecuteDB_Confirm(entitySelect);
                             if (rs is CustomDBError)
                             {
                                 entitySelect.Status.DeliveryValue = 1;
                                 mainService.ExecuteDB_UnQuasi(entitySelect);
                                 MessageDxUtil.ShowError("核准失败：" + ((CustomDBError)rs).ErrorMsg);
                             }
                             else
                             {
                                 MessageDxUtil.ShowTips("核准成功");
                             }
                         }
                     }
                 }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError("核准失败：" + ex.Message);
            }
            finally
            {
                QueryDelivery(true);
                QueryDeliberyHistory();
                QueryDeliveryData();
            }
        }

        /// <summary>
        /// 用户自定义拟准
        /// </summary>
        private void CustomQuasi()
        {
            try
            {
                ToolStripMenuItem ts = null;
                foreach (ToolStripMenuItem rsTemp in txt_FirstDeliveryUser.DropDownItems)
                {
                    if (rsTemp.Selected)
                    {
                        ts = rsTemp;
                    }
                }
                if (ts == null)
                {
                    MessageDxUtil.ShowError("请先选择拟准对象！");
                }
                else
                {
                    DialogResult dr = MessageDxUtil.ShowYesNoAndTips("确认拟准该单据吗？");
                    if (dr == DialogResult.Yes)
                    {
                        if (gvw_left != null && gvw_left.GetFocusedRow() != null)
                        {
                            BM_DELIVERY entitySelect = gvw_left.GetFocusedRow() as BM_DELIVERY;
                            BM_DELIVERY_HISTORY history = new BM_DELIVERY_HISTORY()
                            {
                                MainId = entitySelect.IntId,
                                Operator = new BM_USER() { IntId = SessionHelper.LogUserId },
                                Continue = new BM_USER() { IntId = MyNumberHelper.ConvertToInt32(ts.Tag) },
                                Remarks = textEdit1.Text,
                                CreateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                                UpdateUser = new BM_USER() { IntId = SessionHelper.LogUserId },
                                OperatorType = "拟准"
                            };
                            entitySelect.Reporter = new BM_USER() { IntId = SessionHelper.LogUserId };
                            entitySelect.Approver = new BM_USER() { IntId = MyNumberHelper.ConvertToInt32(ts.Tag) };
                            entitySelect.Remarks = textEdit1.Text;
                            object rs = mainService.ExecuteDB_Quasi(entitySelect, history);
                            if (rs is CustomDBError)
                            {
                                MessageDxUtil.ShowError("拟准失败：" + ((CustomDBError)rs).ErrorMsg);
                            }
                            else
                            {
                                MessageDxUtil.ShowTips("拟准成功");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError("拟准失败：" + ex.Message);
            }
            finally
            {
                QueryDelivery(true);
                QueryDeliberyHistory();
                QueryDeliveryData();
            }
        }
        /// <summary>
        /// 定义按钮
        /// </summary>
        /// <param name="isEnable"></param>
        private void ResetButton(bool isEnable)
        {
            gToolStripButton2.Enabled = isEnable;
            gToolStripButton3.Enabled = isEnable;
            gToolStripButton4.Enabled = isEnable;
        }
        #endregion

        #region  控件事件
        /// <summary>
        /// 表单加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM_DELIVERY_Form_Load(object sender, EventArgs e)
        {
            QueryDelivery(true);
            QueryDeliberyHistory();
            QueryDeliveryData();
            QueryDeliberyUser();
        }
        /// <summary>
        /// 焦点行切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvw_left_FocusedRowChanged(object sender,FocusedRowChangedEventArgs e)
        {
            if (queryBottom)
             {
                 QueryDeliberyHistory();
                 QueryDeliveryData();
             }
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            QueryDelivery(true);
            QueryDeliberyHistory();
            QueryDeliveryData();
        }
        /// <summary>
        /// 拟准按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            CustomQuasi();
        }

        /// <summary>
        /// 核准按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton3_Click(object sender, EventArgs e)
        {
            CustomDelivery();
        }
        /// <summary>
        /// 退回按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton4_Click(object sender, EventArgs e)
        {
            CustomRollBack();
        }

        /// <summary>
        /// 勾选单选后重新查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_IsDeliveried_Click(object sender, EventArgs e)
        {
            QueryDelivery(true);
            QueryDeliberyHistory();
            QueryDeliveryData();
        }
        #endregion
       
    }
}
