using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.ConditionEntity;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.API;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMEntities.CS;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_MoveTrain_Mats_Form_New : CoreForm
    {
        #region 实例变量
        public IPM_RawData_MoveTrainService rawdatamoveservice { get; set; }
        public ISM_PoundSite_InfoService pondSiteInfoService { get; set; }
        public IPM_Pond_Bill_SuppliesService pondsupperservice { get; set; }
        public IPM_Standard_Tare_InfoService tareService { get; set; }
        public IPM_Bill_SuppliesService matsService { get; set; }
        private ISM_Dvr_InfoService dvrService { get; set; }
        //新增
        public ISM_GczTare_InfoService gczService { get; set; }

        public PM_Pond_Bill_Supplies pmpondtrainiron { get; set; }
        private DM_PondSite_Info_WCF pondSiteInfo { get; set; }
        public string siteno;
        public string IP;
        public string formationtag;
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        #endregion

        #region 构造函数
        public PM_Bill_MoveTrain_Mats_Form_New()
        {
            InitializeComponent();
            splitContainerControl1.SplitterPosition = (this.Size.Width*8)/10 ;
        }
        #endregion
        
        #region 自定义方法
        private void Settxt_poundsiteData()
        {
            var rss = pondSiteInfoService.ExecuteDB_QueryAll2();
            rss = rss == null ? null : rss.Where(e => e.PondSiteType != null && e.PondSiteType.EnumValue == SiteType.DynamicMaterial).ToList();
            synchronizationContext.Send(a =>
            {
                lue_SiteNo.Properties.DataSource = rss;
            }, null);
        }
        private void lue_SiteNo_EditValueChanged(object sender, EventArgs e)
        {
            gcl_main.DataSource = null;
            if (MyNumberHelper.ConvertToInt32(lue_SiteNo.EditValue) != 0 && lue_SiteNo.EditValue != null)
            {

                DM_PondSite_Info_WCF pond = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                siteno = pond.PondSiteNo;
                IP = pond.PondSiteIP;
            }
            if (siteno == string.Empty)
            {
                MessageDxUtil.ShowTips("选择有效磅点！");
                return;
            }
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                ht.Add("SiteNo", lue_SiteNo.EditValue);
            }
            lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);


        }
        private void lue_FormationTag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                btn_select_Click(null, null);
                getPond(formationtag);
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(lue_SiteNo.Text))
                {
                    ht.Add("SiteNo", lue_SiteNo.EditValue);
                }
                lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);
            }
            catch (Exception)
            {
            }
        }
        private Hashtable NewMethod()
        {
            Hashtable condition = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                condition.Add("SiteNo", lue_SiteNo.EditValue.ToString());
            }
            if (!string.IsNullOrEmpty(lue_FormationTag.Text))
            {
                condition.Add("FormationTag", lue_FormationTag.Text);
            }

            return condition;
        }
        private void getPond(string formation)
        {
            var result = pondsupperservice.ExecuteDB_QueryByGroup(formation);
            if (result is CustomDBError)
            {
                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)result).ErrorMsg);
            }
            else
            {
                if (result.Count != 0)
                {
                    int num = 0;
                    List<PM_Pond_Bill_Supplies> data = result.ToList();
                    data.ForEach(r =>
                    {
                        if (r.GrossWgtTime != null)
                        {
                            r.GrossWgtTime = CommonHelper.Str14ToTimeFormart(r.GrossWgtTime);
                        }
                        if (r.TareWgtTime != null)
                        {
                            r.TareWgtTime = CommonHelper.Str14ToTimeFormart(r.TareWgtTime);
                        }
                        if (r.TareWgt == 0 && r.NetWgt == 0)
                        {
                            //gvw_pond.GetRow[num]
                        }
                    });
                }
                gcl_pond.DataSource = result;
                gvw_pond.BestFitColumns();
            }
        }

        private void mapping(PM_Pond_Bill_Supplies poundtrainmats, PM_Bill_Supplies supplies)
        {
            poundtrainmats.PlanNo = supplies.PlanNo;
            poundtrainmats.WagNo = supplies.WagNo;
            poundtrainmats.MaterialNo = supplies.MaterialNo;
            poundtrainmats.MaterialName = supplies.MaterialName;
            poundtrainmats.FromDeptNo = supplies.FromDeptNo;
            poundtrainmats.FromDeptName = supplies.FromDeptName;
            poundtrainmats.FromStoreNo = supplies.FromStoreNo;
            poundtrainmats.FromStoreName = supplies.FromStoreName;
            poundtrainmats.ToDeptNo = supplies.ToDeptNo;
            poundtrainmats.ToDeptName = supplies.ToDeptName;
            poundtrainmats.ToStoreNo = supplies.ToStoreNo;
            poundtrainmats.ToStoreName = supplies.ToStoreName;
            poundtrainmats.ShipNo = supplies.ShipNo;
            poundtrainmats.FromStation = supplies.FromStation;
            poundtrainmats.SerialNo = supplies.SerialNo;
            poundtrainmats.DeliveryNo = supplies.DeliveryNo;
            poundtrainmats.ContractNo = supplies.ContractNo;
            poundtrainmats.ProjectNo = supplies.ProjectNo;
            poundtrainmats.WayBillNo = supplies.WayBillNo;
            poundtrainmats.MarshallingNo = supplies.MarshallingNo;
            poundtrainmats.BusinessType = supplies.BusinessType;
            poundtrainmats.WeightType = supplies.WeightType;
            poundtrainmats.TareType = supplies.TareType;
            poundtrainmats.MoveStillType = supplies.MoveStillType;
            poundtrainmats.PlanLimitTime = supplies.PlanLimitTime;
            poundtrainmats.PondLimit = supplies.PondLimit;
            poundtrainmats.Remark = supplies.Remark;
            poundtrainmats.PondRemark = "";
            poundtrainmats.CReserve1 = supplies.CReserve1;
            poundtrainmats.CReserve2 = supplies.CReserve2;
            poundtrainmats.CReserve3 = supplies.CReserve3;
            poundtrainmats.IReserve1 = supplies.IReserve1;
            poundtrainmats.IReserve2 = supplies.IReserve2;
            poundtrainmats.IReserve3 = supplies.IReserve3;
            poundtrainmats.PlanCreateUser = supplies.CreateUser;
            poundtrainmats.PlanCreateTime = supplies.CreateTime;
            //匹配上传应该设置为开始计量状态，而不是已完成状态
            //poundtrainmats.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };    
            if (poundtrainmats.TareWgt > 0 && poundtrainmats.NetWgt > 0 && poundtrainmats.GrossWgt > 0)
            {
                poundtrainmats.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
                supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            }
            else
            {
                poundtrainmats.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
                supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.StareMeasure };
            }                     
            poundtrainmats.CreateUser = SessionHelper.LogUserNickName;
            poundtrainmats.UpdateUser = SessionHelper.LogUserNickName;
            poundtrainmats.DataFlag = new EntityInt(1);
            poundtrainmats.PlanStatus = "I";
            poundtrainmats.UpLoadStatus = "N";
            DateTime dt;
            if (DateTime.TryParse(poundtrainmats.GrossWgtTime, out dt))
            {
                poundtrainmats.GrossWgtTime = CommonHelper.TimeToStr14(dt);
            }
            if (DateTime.TryParse(poundtrainmats.TareWgtTime, out dt))
            {
                poundtrainmats.TareWgtTime = CommonHelper.TimeToStr14(dt);
            }
            //DateTime date = DateTime.ParseExact(poundtrainmats.GrossWgtTime, "yyyy-MM-dd HH:mm:ss", null);
            ////DateTime date = Convert.ToDateTime(poundtrainmats.GrossWgtTime);
            //poundtrainmats.GrossWgtTime = CommonHelper.TimeToStr14(date);
            ////date = Convert.ToDateTime(poundtrainmats.TareWgtTime);
            //date = DateTime.ParseExact(poundtrainmats.TareWgtTime, "yyyy-MM-dd HH:mm:ss", null);
            //poundtrainmats.TareWgtTime = CommonHelper.TimeToStr14(date);
            var res = pondsupperservice.ExecuteDB_UpdateSuppliesInfo(poundtrainmats);

            //根据实际情况进行修改
            //supplies.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.DoneMeasure };
            supplies.UpdateUser = SessionHelper.LogUserNickName;
            var bs = matsService.ExecuteDB_UpdateSuppliesInfo(supplies);
        }

        private bool matchPlan(PM_Pond_Bill_Supplies poundtrainmats, List<string> list)
        {
            bool bl = true;
            try
            {
                var rs = matsService.ExecuteDB_QueryIronByCarNo(String.Format("'{0}'", poundtrainmats.WagNo));
                if (rs != null && rs.Count == 1)
                {
                    PM_Bill_Supplies matsplan = rs.FirstOrDefault();
                    if (matsplan.BillStatus.IntValue != 2 && matsplan.BillStatus.IntValue != 3)
                    {
                        mapping(poundtrainmats, matsplan);
                    }
                }
                else
                {
                    bl = false;
                    list.Add(poundtrainmats.WagNo);
                }
            }
            catch (Exception)
            {
                bl = false;
            }
            return bl;
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 查询过磅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                if (lue_FormationTag.EditValue == null)
                {
                    // MessageDxUtil.ShowTips("选择有效磅点！");
                    return;
                }
                formationtag = lue_FormationTag.Text;
                Hashtable condition = NewMethod();
                var rawdata = rawdatamoveservice.ExecuteDB_QueryBytagdata(condition);
                gcl_main.DataSource = rawdata;
                //gvw_main.BestFitColumns();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 作废过磅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zuofei_Click(object sender, EventArgs e)
        {
            try
            {
                gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                if (gvw_main.RowCount > 0)
                {
                    int[] rows = gvw_main.GetSelectedRows();
                    if (rows.Length != 0)
                    {
                        foreach (var rowNum in rows)
                        {
                            PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                            if (gvw_main.GetRowCellValue(rowNum, "TankNo") != null)
                            {
                                updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
                            }

                            updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.obsolete };
                            updateEntity.UpdateUser = SessionHelper.LogUserNickName;
                            var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
                            if (rs is CustomDBError)
                            {
                                MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                            }
                        }
                        MessageDxUtil.ShowTips("已作废！");
                    }

                }
                btn_select_Click(null, null);
            }
            catch (Exception ep)
            {
                MessageDxUtil.ShowError(ep.Message);
            }
        }

        /// <summary>
        /// 视频连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shipin_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_shipin.Text == "视频连接")
                {
                    if (lue_SiteNo.EditValue != null)
                    {
                        pondSiteInfo = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
                        if (pondSiteInfo != null)
                        {
                            VideoPlay();
                            btn_huifang.Enabled = false;
                            btn_start.Enabled = false;
                            btn_stop.Enabled = false;
                            btn_back.Enabled = false;
                        }
                        btn_shipin.Text = "中断连接";
                    }
                }
                else
                {
                    if (pondSiteInfo != null)
                    {
                        VideoStop();
                        btn_huifang.Enabled = true;
                        btn_start.Enabled = true;
                        btn_stop.Enabled = true;
                        btn_back.Enabled = true;
                    }
                    pondSiteInfo = null;
                    btn_shipin.Text = "视频连接";
                }
            }
            catch (Exception ex)
            {
                ShowTxtLog("视频连接失败");
            }
        }

        /// <summary>
        /// 标记空车(该功能由于业务变更，暂时不用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_biaopi_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否为皮重？");
            if (yn == DialogResult.Yes)
            {
                try
                {
                    gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                    if (gvw_main.RowCount > 0)
                    {
                        List<string> list = new List<string>();
                        int[] rows = gvw_main.GetSelectedRows();
                        if (rows.Length != 0)
                        {
                            foreach (var rowNum in rows)
                            {
                                PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                                if (updateEntity.WeightData >= 50)
                                {
                                    var zl = MessageDxUtil.ShowYesNoAndTips("本次有重量大于50！！！");
                                    if (zl == DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                                if (updateEntity.CarNo == string.Empty)
                                {
                                    var zl = MessageDxUtil.ShowYesNoAndTips("本次标记的数据存在车号为空!!!");
                                    if (zl == DialogResult.No)
                                    {
                                        return;
                                    }
                                    break;
                                }
                                if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
                                {
                                    Hashtable ht = new Hashtable();
                                    ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
                                    var re = pondsupperservice.ExecuteDB_QueryByDic(ht);
                                    if (re.Count != 0)
                                    {
                                        PM_Pond_Bill_Supplies movedatamao = re.FirstOrDefault();
                                        movedatamao.TareWgt = updateEntity.WeightData;
                                        //DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
                                        movedatamao.TareWgtTime = updateEntity.WeightTime;
                                        movedatamao.TareWgtMan = SessionHelper.LogUserNickName;
                                        movedatamao.TareWgtSiteNo = lue_SiteNo.EditValue.ToString();
                                        movedatamao.TareWgtSiteName = lue_SiteNo.Text;
                                        movedatamao.UpdateUser = SessionHelper.LogUserNickName;
                                        movedatamao.TrainGroupTare = lue_FormationTag.Text;
                                        movedatamao.GrossWgtTime = CommonHelper.Str14ToTimeFormart(movedatamao.GrossWgtTime);
                                        movedatamao.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                        if (movedatamao.GrossWgt - movedatamao.TareWgt >= 0)
                                        {
                                            movedatamao.NetWgt = movedatamao.GrossWgt - movedatamao.TareWgt;
                                        }
                                        else
                                        {
                                            movedatamao.NetWgt = 0;
                                        }

                                        //movedatamao.UpLoadStatus = "N";
                                        //movedatamao.PlanStatus = "I";
                                        var rw = pondsupperservice.ExecuteDB_UpdateSuppliesInfo(movedatamao);
                                        if (rw is CustomDBError)
                                        {
                                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rw).ErrorMsg);
                                        }
                                        matchPlan(movedatamao, list);

                                    }
                                    else
                                    {
                                        MessageDxUtil.ShowTips("皮重未保存,请谨慎保存！");
                                        return;
                                    }
                                    updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
                                    updateEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.TareActual };
                                    updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                                    updateEntity.UpdateUser = SessionHelper.LogUserNickName;
                                    var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
                                    if (rs is CustomDBError)
                                    {
                                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                                    }
                                }
                            }
                            if (list.Count > 0)
                            {
                                string s = string.Join(",", list.ToArray());
                                MessageDxUtil.ShowTips(s + "车未正常匹配");
                                //btn_qplan_Click(null, null);
                            }
                            else
                            {
                                MessageDxUtil.ShowTips("标记完成！");
                            }
                        }
                    }
                    else
                    {
                        MessageDxUtil.ShowTips("请先勾选要标记的数据");
                    }

                    btn_select_Click(null, null);
                    getPond(lue_FormationTag.Text);
                }
                catch (Exception ep)
                {
                    MessageDxUtil.ShowError(ep.Message);
                }

            }
        }

        /// <summary>
        /// 标记重车            需要修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_biaomao_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否为毛重？");
            if (yn == DialogResult.Yes)
            {
                try
                {
                    gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                    if (gvw_main.RowCount > 0)
                    {
                        pmpondtrainiron = new PM_Pond_Bill_Supplies();
                        int[] rows = gvw_main.GetSelectedRows();
                        if (rows.Length != 0)
                        {
                            foreach (var rowNum in rows)
                            {
                                PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                                if (updateEntity.WeightData <= 50)
                                {
                                    var zl = MessageDxUtil.ShowYesNoAndTips("本次有重量小于50！！！");
                                    if (zl == DialogResult.No)
                                    {
                                        return;
                                    }
                                    //break;
                                }
                                if (updateEntity.CarNo == string.Empty)
                                {
                                    var zl = MessageDxUtil.ShowYesNoAndTips("本次标记的数据存在车号为空!!!");
                                    if (zl == DialogResult.No)
                                    {
                                        return;
                                    }
                                    break;
                                }
                                if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
                                {
                                    Hashtable ht = new Hashtable();
                                    ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
                                    var re = pondsupperservice.ExecuteDB_QueryByDic(ht).FirstOrDefault();
                                    if (re != null)
                                    {
                                        if (re.GrossWgt == 0)
                                        {
                                            MessageDxUtil.ShowTips(gvw_main.GetRowCellValue(rowNum, "CarNo").ToString() + "车存在未完成过磅记录，请谨慎保存！");
                                            continue;
                                        }
                                    }
                                    pmpondtrainiron.WagNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
                                    pmpondtrainiron.GrossWgt = updateEntity.WeightData;
                                    DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
                                    pmpondtrainiron.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
                                    pmpondtrainiron.NetWgtTime= date.ToString("yyyyMMddHHmmss");
                                    pmpondtrainiron.GrossWgtMan = SessionHelper.LogUserNickName;
                                    pmpondtrainiron.GrossWgtSiteNo = lue_SiteNo.EditValue.ToString();
                                    pmpondtrainiron.GrossWgtSiteName = lue_SiteNo.Text;
                                    pmpondtrainiron.CreateUser = SessionHelper.LogUserNickName;
                                    pmpondtrainiron.UpdateUser = SessionHelper.LogUserNickName;
                                    pmpondtrainiron.TrainGroupGross = lue_FormationTag.Text;
                                    pmpondtrainiron.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
                                    pmpondtrainiron.DataFlag = new EntityInt(1);
                                    var rw = pondsupperservice.ExecuteDB_InsertSuppliesInfo(pmpondtrainiron);
                                    if (rw is CustomDBError)
                                    {
                                        continue;
                                    }
                                    updateEntity.CarNo = gvw_main.GetRowCellValue(rowNum, "CarNo").ToString();
                                    updateEntity.WeightFlag = new WeightTypeObj() { IntValue = (int)WeightType.GrossActual };
                                    updateEntity.DataFlag = new RawDataStatusObj() { IntValue = (int)RawDataStatus.save };
                                    updateEntity.UpdateUser = SessionHelper.LogUserNickName;
                                    var rs = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(updateEntity);
                                    if (rs is CustomDBError)
                                    {
                                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                                    }
                                }


                            }
                            MessageDxUtil.ShowTips("保存完成！");
                        }
                        else
                        {
                            MessageDxUtil.ShowTips("请先勾选要保存数据");
                        }
                    }
                    btn_select_Click(null, null);
                    getPond(lue_FormationTag.Text);
                }
                catch (Exception ep)
                {
                    MessageDxUtil.ShowError(ep.Message);
                }
            }
        }

        /// <summary>
        /// 保存过磅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否确定保存？");
            if (yn == DialogResult.Yes)
            {
                try
                {
                    gvw_main.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                    if (gvw_main.RowCount > 0)
                    {
                        int[] rows = gvw_main.GetSelectedRows();
                        foreach (var rowNum in rows)
                        {
                            PM_RawData_MoveTrain updateEntity = gvw_main.GetRow(rowNum) as PM_RawData_MoveTrain;
                            if (gvw_main.GetRowCellValue(rowNum, "CarNo").ToString() != string.Empty)
                            {
                                pmpondtrainiron = new PM_Pond_Bill_Supplies();
                                if (updateEntity.WeightData < 60)
                                {
                                    if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
                                    {
                                        Hashtable ht = new Hashtable();
                                        ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
                                        var re = pondsupperservice.ExecuteDB_QueryByDic(ht).FirstOrDefault();
                                        if (re != null)
                                        {
                                            if (re.GrossWgt == 0)
                                            {
                                                MessageDxUtil.ShowTips(gvw_main.GetRowCellValue(rowNum, "CarNo").ToString() + "车存在未完成过磅记录，请谨慎保存！");
                                                continue;
                                            }
                                        }
                                        pmpondtrainiron.GrossWgt = updateEntity.WeightData;
                                        DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
                                        pmpondtrainiron.GrossWgtTime = date.ToString("yyyyMMddHHmmss");
                                        pmpondtrainiron.GrossWgtMan = SessionHelper.LogUserNickName;
                                        pmpondtrainiron.GrossWgtSiteNo = lue_SiteNo.EditValue.ToString();
                                        pmpondtrainiron.GrossWgtSiteName = lue_SiteNo.Text;
                                        pmpondtrainiron.CreateUser = SessionHelper.LogUserNickName;
                                        pmpondtrainiron.UpdateUser = SessionHelper.LogUserNickName;
                                        pmpondtrainiron.TrainGroupGross = lue_FormationTag.Text;
                                        pmpondtrainiron.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.StareMeasure };
                                        pmpondtrainiron.DataFlag = new EntityInt(1);
                                        var rs = pondsupperservice.ExecuteDB_InsertSuppliesInfo(pmpondtrainiron);
                                        if (rs is CustomDBError)
                                        {
                                            MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                                        }
                                    }
                                }
                                else
                                {
                                    if (updateEntity.DataFlag.RawDataStatusDesc != "保存")
                                    {
                                        Hashtable ht = new Hashtable();
                                        ht.Add("TankNo", gvw_main.GetRowCellValue(rowNum, "CarNo").ToString());
                                        var rs = pondsupperservice.ExecuteDB_QueryByDic(ht);
                                        if (rs.Count != 0)
                                        {
                                            PM_Pond_Bill_Supplies movedatamao = rs.FirstOrDefault();
                                            movedatamao.TareWgt = updateEntity.WeightData;
                                            DateTime date = Convert.ToDateTime(updateEntity.WeightTime);
                                            movedatamao.TareWgtTime = date.ToString("yyyyMMddHHmmss");
                                            movedatamao.TareWgtMan = SessionHelper.LogUserNickName;
                                            movedatamao.TareWgtSiteNo = lue_SiteNo.EditValue.ToString();
                                            movedatamao.TareWgtSiteName = lue_SiteNo.Text;
                                            movedatamao.UpdateUser = SessionHelper.LogUserNickName;
                                            movedatamao.TrainGroupTare = lue_FormationTag.Text;
                                            movedatamao.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                            if (movedatamao.GrossWgt - updateEntity.WeightData >= 0)
                                            {
                                                movedatamao.NetWgt = movedatamao.GrossWgt - updateEntity.WeightData;
                                            }
                                            else
                                            {
                                                movedatamao.NetWgt = 0;
                                            }
                                            var re = pondsupperservice.ExecuteDB_UpdateSuppliesInfo(movedatamao);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

        }

        /// <summary>
        /// 回退保存的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_return_Click(object sender, EventArgs e)
        {
            var huitui = MessageDxUtil.ShowYesNoAndTips("是否确定回退？");
            if (huitui == DialogResult.Yes)
            {
                int[] rows = gvw_pond.GetSelectedRows();
                if (rows.Length != 0)
                {
                    foreach (var rowNum in rows)
                    {
                        var pondbill = gvw_pond.GetRow(rowNum) as PM_Pond_Bill_Supplies;
                        if (pondbill.BillStatus.IntValue != 2)
                        {
                            if (pondbill.TareWgt != (decimal)0.00)
                            {
                                pondbill.DataFlag = new EntityInt(0);
                                pondbill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.InvalidMeasure };
                                pondbill.UpdateUser = SessionHelper.LogUserNickName;
                                //对于有净重的磅单，就默认为磅单已完成状态，所以应该设置这两个字段值
                                pondbill.PlanStatus = "D";
                                pondbill.UpLoadStatus = "N";

                                var rs = pondsupperservice.ExecuteDB_InvalidSuppliesPondByIntId(pondbill);
                                if (rs is CustomDBError)
                                {
                                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                                    return;
                                }

                                Hashtable ht = new Hashtable();
                                ht.Add("CarNo", pondbill.WagNo);
                                ht.Add("FormationTag", pondbill.TrainGroupTare);
                                ht.Add("SiteNo", lue_SiteNo.EditValue.ToString());
                                ht.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.TareWgtTime));
                                IList<PM_RawData_MoveTrain> grossdata = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht);
                                for (int i = 0; i < grossdata.Count; i++)
                                {
                                    grossdata[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                                    grossdata[i].UpdateUser = SessionHelper.LogUserNickName;
                                    var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata[i]);
                                }

                                Hashtable ht1 = new Hashtable();
                                ht1.Add("CarNo", pondbill.WagNo);
                                ht1.Add("FormationTag", pondbill.TrainGroupGross);
                                ht1.Add("SiteNo", lue_SiteNo.EditValue.ToString());
                                ht1.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.GrossWgtTime));
                                IList<PM_RawData_MoveTrain> grossdata1 = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht1);
                                for (int i = 0; i < grossdata1.Count; i++)
                                {
                                    grossdata1[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                                    grossdata1[i].UpdateUser = SessionHelper.LogUserNickName;
                                    var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata1[i]);
                                }
                            }
                            else
                            {
                                pondbill.DataFlag = new EntityInt(0);
                                pondbill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.InvalidMeasure };
                                pondbill.UpdateUser = SessionHelper.LogUserNickName;
                                var rs = pondsupperservice.ExecuteDB_InvalidSuppliesPondByIntId(pondbill);
                                if (rs is CustomDBError)
                                {
                                    MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                                    return;
                                }

                                Hashtable ht = new Hashtable();
                                ht.Add("CarNo", pondbill.WagNo);
                                ht.Add("FormationTag", pondbill.TrainGroupGross);
                                ht.Add("SiteNo", lue_SiteNo.EditValue.ToString());
                                ht.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.GrossWgtTime));
                                IList<PM_RawData_MoveTrain> grossdata = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht);
                                for (int i = 0; i < grossdata.Count; i++)
                                {
                                    grossdata[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                                    grossdata[i].UpdateUser = SessionHelper.LogUserNickName;
                                    var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata[i]);
                                }
                            }
                        }
                        else
                        {
                            /*
                            var rss = matsService.ExecuteDB_QuerySuppliesByPlan(pondbill.PlanNo);
                            if (rss.Count != 0)
                            {
                                PM_Bill_Supplies supplies = rss.FirstOrDefault();
                                supplies.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.NoMeasure };
                                supplies.UpdateUser = SessionHelper.LogUserNickName;
                                var rw = matsService.ExecuteDB_UpdateSuppliesInfo(supplies);
                            }
                            */

                            pondbill.DataFlag = new EntityInt(0);
                            pondbill.BillStatus = new BillStatusObj { IntValue = (int)BillStatus.InvalidMeasure };
                            pondbill.UpdateUser = SessionHelper.LogUserNickName;
                            pondbill.PlanStatus = "D";
                            pondbill.UpLoadStatus = "N";
                            var rs = pondsupperservice.ExecuteDB_InvalidSuppliesPondByIntId(pondbill);
                            if (rs is CustomDBError)
                            {
                                MessageDxUtil.ShowError(((CustomDBError)rs).ErrorMsg);
                                return;
                            }

                            Hashtable ht = new Hashtable();
                            ht.Add("CarNo", pondbill.WagNo);
                            ht.Add("FormationTag", pondbill.TrainGroupTare);
                            ht.Add("SiteNo", lue_SiteNo.EditValue.ToString());
                            ht.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.TareWgtTime));
                            IList<PM_RawData_MoveTrain> grossdata = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht);
                            for (int i = 0; i < grossdata.Count; i++)
                            {
                                grossdata[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                                grossdata[i].UpdateUser = SessionHelper.LogUserNickName;
                                var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata[i]);
                            }

                            Hashtable ht1 = new Hashtable();
                            ht1.Add("CarNo", pondbill.WagNo);
                            ht1.Add("FormationTag", pondbill.TrainGroupGross);
                            ht1.Add("SiteNo", lue_SiteNo.EditValue.ToString());
                            ht1.Add("BeginDate", CommonHelper.Str14ToTimeFormart(pondbill.GrossWgtTime));
                            IList<PM_RawData_MoveTrain> grossdata1 = rawdatamoveservice.ExecuteDB_QueryByHashTable(ht1);
                            for (int i = 0; i < grossdata1.Count; i++)
                            {
                                grossdata1[i].DataFlag = new RawDataStatusObj { IntValue = (int)RawDataStatus.receive };
                                grossdata1[i].UpdateUser = SessionHelper.LogUserNickName;
                                var ree = rawdatamoveservice.ExecuteDB_UpdateRawDataInfo(grossdata1[i]);
                            }
                        }
                        if (pondbill.PlanNo != null && !string.IsNullOrEmpty(pondbill.PlanNo))
                        {
                            var rss = matsService.ExecuteDB_QuerySuppliesByPlan(pondbill.PlanNo);
                            if (rss.Count != 0)
                            {
                                PM_Bill_Supplies supplies = rss.FirstOrDefault();
                                supplies.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.NoMeasure };
                                supplies.UpdateUser = SessionHelper.LogUserNickName;
                                var rw = matsService.ExecuteDB_UpdateSuppliesInfo(supplies);
                            }
                        }                        
                    }
                    MessageDxUtil.ShowTips("回退成功！");
                    btn_select_Click(null, null);
                    getPond(formationtag);
                }
                else
                {
                    MessageDxUtil.ShowTips("请勾选要回退的数据！");
                }
            }
        }

        /// <summary>
        /// 查询对应的计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qplan_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                string trainos;
                gvw_pond.CloseEditor();     //解决编辑后光标还未离开直接点保存问题
                if (gvw_pond.RowCount > 0)
                {
                    int[] rows = gvw_pond.GetSelectedRows();
                    if (rows.Length != 0)
                    {
                        foreach (var rowNum in rows)
                        {
                            pmpondtrainiron = gvw_pond.GetRow(rowNum) as PM_Pond_Bill_Supplies;
                            if (pmpondtrainiron.WagNo != string.Empty)
                            {
                                trainos = String.Format("'{0}'", pmpondtrainiron.WagNo);
                                list.Add(trainos);
                            }
                        }
                    }
                }
                string s = string.Join(",", list.ToArray());
                var carbills = matsService.ExecuteDB_QueryIronByCarNo(s);
                if (carbills.Count() < list.Count())
                {
                    MessageDxUtil.ShowError("计划条数与车辆数不匹配");
                }

                gcl_result.DataSource = carbills;
                gvw_result.BestFitColumns();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pipei_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否确定匹配？");
            if (yn == DialogResult.Yes)
            {
                if (gcl_result.DataSource == null)
                {
                    btn_qplan_Click(null, null);
                }
                int[] rows = gvw_pond.GetSelectedRows();
                int[] row = gvw_result.GetSelectedRows();
                if (rows.Length != 0 && row.Length != 0)
                {
                    List<string> list1 = new List<string>();
                    List<string> list2 = new List<string>();
                    List<string> list3 = new List<string>();
                    foreach (var items in rows)
                    {                    
                        PM_Pond_Bill_Supplies poundtrainmats = gvw_pond.GetRow(items) as PM_Pond_Bill_Supplies;
                        List<PM_Bill_Supplies> list = new List<PM_Bill_Supplies>();
                        foreach (var item in row)
                        {
                            PM_Bill_Supplies supplies = gvw_result.GetRow(item) as PM_Bill_Supplies;
                            if (poundtrainmats.BillStatus.IntValue != 2 && poundtrainmats.WagNo == supplies.WagNo)
                            {
                                list.Add(supplies);                               
                                //mapping(poundtrainmats, supplies);
                            }                        
                        }
                        if (list.Count == 1)
                        {                            
                            mapping(poundtrainmats, list[0]);
                        }
                        else if(list.Count == 0)
                        {
                            list2.Add(poundtrainmats.WagNo);
                            //MessageDxUtil.ShowTips(poundtrainmats.WagNo + "该车号查询到多个委托，请手动核实");
                            continue;
                        }
                        else
                        {
                            list3.Add(poundtrainmats.WagNo);
                            continue;
                        }
                        string car = String.Format("'{0}'", poundtrainmats.WagNo);
                        list1.Add(car);
                    }
                    
                    string s = string.Join(",", list1.ToArray());
                    if (list2.Count > 0 || list3.Count > 0)
                    {
                        string noChecked = string.Join(",", list2.ToArray());
                        string needCheck = string.Join(",", list3.ToArray());
                        //后续根据实际需求看是否提示有哪些车
                        //MessageDxUtil.ShowTips("匹配完成!"+'\n'+noChecked+"无匹配计划"+'\n'+needCheck+"有多条计划需核实");
                        MessageDxUtil.ShowTips("匹配完成!" + '\n' + list2.Count + "车无匹配计划" + '\n' + list3.Count + "车需核实计划");
                    }
                    else
                    {
                        MessageDxUtil.ShowTips("匹配完成！");
                    }
                    getPond(formationtag);
                    var iron = matsService.ExecuteDB_QueryIronByCarNo(s);
                    gcl_result.DataSource = iron;
                    gvw_result.BestFitColumns();
                }
            }
        }
        
        /// <summary>
        /// 匹配皮重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_matchTare_Click(object sender, EventArgs e)
        {            
            int[] rows = gvw_pond.GetSelectedRows();
            int count = 0;
            int num = 0;
            int needCheak = 0;
            if (rows.Length == 0)
            {
                MessageDxUtil.ShowTips("请勾选要匹配皮重的磅单");
            }
            else
            {
                //检查勾选的磅单中是否存在已经匹配了委托的
                if (chenkPondPlan(rows) == false)
                {
                    MessageDxUtil.ShowError("勾选的该批量数据中存在已经匹配了委托的磅单"+'\n'+"请重新操作");
                    return;
                }
                    
                List<string> list = new List<string>();
                List<PM_Pond_Bill_Supplies> pondList = new List<PM_Pond_Bill_Supplies>();
                foreach (var items in rows)
                {
                    PM_Pond_Bill_Supplies poundtrainmats = gvw_pond.GetRow(items) as PM_Pond_Bill_Supplies;                    
                    Hashtable ht = new Hashtable();
                    ht.Add("siteNo", lue_SiteNo.EditValue);                    
                    ht.Add("carName", poundtrainmats.WagNo);
                    string grossWgtTime = poundtrainmats.GrossWgtTime;
                    //这个时间段在上线之前再调整为前后两分钟
                    DateTime time1 = Convert.ToDateTime(grossWgtTime).AddMinutes(-2);
                    DateTime time2 = Convert.ToDateTime(grossWgtTime).AddMinutes(2);
                    ht.Add("startTime", time1.ToString("yyyyMMddHHmmss"));
                    ht.Add("endTime", time2.ToString("yyyyMMddHHmmss"));
                    IList<SM_GczTare_Info> tareList = gczService.ExecuteDB_QueryGczTareForMatch(ht);                    
                    if (tareList != null && tareList.Count > 0)
                    {
                        if (checkTareList(tareList) == false)
                        {
                            needCheak++;
                            continue;
                        }
                        if (tareList.Count == 1)
                        {
                            SM_GczTare_Info tare = tareList[0];
                            
                            poundtrainmats = matchTareWeight(poundtrainmats, tare);                                                                                                   
                        }
                        else
                        {
                            foreach (SM_GczTare_Info tare in tareList)
                            {
                                if (!(Convert.ToDecimal(tare.C_TAREWEIGHT) > 0))
                                {
                                    continue;
                                }
                                poundtrainmats = matchTareWeight(poundtrainmats, tare);                               
                            }
                        }
                        DateTime time = new DateTime();
                        DateTime.TryParse(poundtrainmats.GrossWgtTime, out time);
                        poundtrainmats.GrossWgtTime = time.ToString("yyyyMMddHHmmss");
                        var rw = pondsupperservice.ExecuteDB_UpdateSuppliesInfo(poundtrainmats);
                        if (rw is CustomDBError)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        num++;
                    }
                }
                if (count > 0 || num > 0 || needCheak > 0)
                {
                    MessageDxUtil.ShowWarning("有" + count + "车匹配失败"+'\n'+"有"+num+"车未识别皮重"+'\n'+"有"+needCheak+"车需要手动核实");
                }
                else
                {
                    MessageDxUtil.ShowTips("皮重匹配完成");
                }
                getPond(formationtag);
            }            
        }
        /// <summary>
        /// 保存磅单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_savepond_Click(object sender, EventArgs e)
        {
            var yn = MessageDxUtil.ShowYesNoAndTips("本次过磅数据，是否保存磅单？");
            if (yn == DialogResult.Yes)
            {
                int[] rows = gvw_pond.GetSelectedRows();
                List<string> list = new List<string>();
                foreach (var items in rows)
                {
                    PM_Pond_Bill_Supplies poundtrainmats = gvw_pond.GetRow(items) as PM_Pond_Bill_Supplies;
                    if (poundtrainmats.TareWgt!=0)
                    {
                        poundtrainmats.TareWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        poundtrainmats.TareWgtMan = poundtrainmats.GrossWgtMan;
                        poundtrainmats.TareWgtSiteNo = poundtrainmats.GrossWgtSiteNo;
                        poundtrainmats.TareWgtSiteName = poundtrainmats.GrossWgtSiteName;
                        poundtrainmats.NetWgt = poundtrainmats.GrossWgt - poundtrainmats.TareWgt;
                        poundtrainmats.TrainGroupTare = poundtrainmats.TrainGroupGross;
                        poundtrainmats.GrossWgtTime = DateTime.ParseExact(poundtrainmats.GrossWgtTime, "yyyy-MM-dd HH:mm:ss", null).ToString("yyyyMMddHHmmss");
                        poundtrainmats.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        var rw = pondsupperservice.ExecuteDB_UpdateSuppliesInfo(poundtrainmats);

                        PM_Standard_Tare_Info tare = new PM_Standard_Tare_Info();
                        tare.TareWgt = poundtrainmats.TareWgt;
                        tare.WagNo = poundtrainmats.WagNo;
                        tare.TareTime = poundtrainmats.TareWgtTime;
                        tare.IsUse = 1;
                        tare.CreateUser = SessionHelper.LogUserNickName;
                        tare.UpdateUser = SessionHelper.LogUserNickName;
                        var rq = tareService.ExecuteDB_InsertTareInfo(tare);
                        matchPlan(poundtrainmats, list);
                    }
                    else
                    {
                        MessageDxUtil.ShowTips(poundtrainmats.WagNo + "该车号请输入皮重重量！");
                    }
                    if (list.Count > 0)
                    {
                        string s = string.Join(",", list.ToArray());
                        MessageDxUtil.ShowTips(s + "车未正常匹配计划");
                    }
                }
                getPond(formationtag);
            }
        }

        private void gvw_main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Down}");
                SendKeys.Send("{F2}");
            }
        }
        private void gvw_pond_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Down}");
                SendKeys.Send("{F2}");
            }
        }

        /// <summary>
        /// 录像回放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_huifang_Click(object sender, EventArgs e)
        {
            if (_videoStatus == true)
            {
                VideoStop();
            }
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();

            if (m_bInitSDK == false)
            {
                MessageDxUtil.ShowTips("SDK加载失败！");
                return;
            }
            pondSiteInfo = lue_SiteNo.GetSelectedDataRow() as DM_PondSite_Info_WCF;
            if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
            {
                SM_Dvr_Info dvr = dvrService.ExecuteDB_QueryAllByPondId(pondSiteInfo.IntId);
                if (dvr != null)
                {
                    m_lUserID = CHCNetSDK.NET_DVR_Login_V30(dvr.DvrIP1, 8000, dvr.Username, dvr.Password, ref m_struDeviceInfo);
                    if (m_lUserID == -1)
                    {
                        ShowTxtLog("硬盘录像机连接失败！");
                        return;
                    }

                    DateTime endTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(lue_FormationTag.Text).AddMinutes(MyNumberHelper.ConvertToInt32(c_min.Text));
                    DateTime startTime = MyDateTimeHelper.ConvertToDateTimeDefaultNow(lue_FormationTag.Text);

                    dateTimeStart.dwYear = (uint)startTime.Year;
                    dateTimeStart.dwMonth = (uint)startTime.Month;
                    dateTimeStart.dwDay = (uint)startTime.Day;
                    dateTimeStart.dwHour = (uint)startTime.Hour;
                    dateTimeStart.dwMinute = (uint)startTime.Minute;
                    dateTimeStart.dwSecond = (uint)startTime.Second;
                    //设置下载的结束时间 Set the stopping time
                    dateTimeEnd.dwYear = (uint)endTime.Year;
                    dateTimeEnd.dwMonth = (uint)endTime.Month;
                    dateTimeEnd.dwDay = (uint)endTime.Day;
                    dateTimeEnd.dwHour = (uint)endTime.Hour;
                    dateTimeEnd.dwMinute = (uint)endTime.Minute;
                    dateTimeEnd.dwSecond = (uint)endTime.Second;

                    if (lue_vedio.Text != "")
                    {
                        int a = 0;
                        switch (lue_vedio.Text)
                        {
                            case "视频1":
                                a = 33;
                                break;
                            case "视频2":
                                a = 34;
                                break;
                            case "视频3":
                                a = 35;
                                break;
                            case "视频4":
                                a = 36;
                                break;
                            default:
                                break;
                        }
                        m_lRealHandle1 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, a, ref dateTimeStart, ref dateTimeEnd, panelControl1.Handle);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 1, 0, ref lpOutValue);
                        lblVideo1.Visible = false;
                        panelControl1_DoubleClick(null, null);
                        btn_huifang.Enabled = false;
                        btn_shipin.Enabled = false;
                    }
                    else
                    {
                        m_lRealHandle1 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 33, ref dateTimeStart, ref dateTimeEnd, panelControl1.Handle);
                        m_lRealHandle2 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 34, ref dateTimeStart, ref dateTimeEnd, panelControl2.Handle);
                        m_lRealHandle3 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 35, ref dateTimeStart, ref dateTimeEnd, panelControl3.Handle);
                        m_lRealHandle4 = CHCNetSDK.NET_DVR_PlayBackByTime(m_lUserID, 36, ref dateTimeStart, ref dateTimeEnd, panelControl4.Handle);

                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 1, 0, ref lpOutValue);
                        CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 1, 0, ref lpOutValue);
                        lblVideo1.Visible = false;
                        lblVideo2.Visible = false;
                        lblVideo3.Visible = false;
                        lblVideo4.Visible = false;
                        lue_vedio.Enabled = false;
                        btn_huifang.Enabled = false;
                        btn_shipin.Enabled = false;
                    }

                }
            }
        }
        /// <summary>
        /// 开始/暂停播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (VideoStatus)
            {
                btn_start.Text = "播放";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 3, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 3, 0, ref lpOutValue);
            }
            else
            {
                btn_start.Text = "暂停";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 4, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 4, 0, ref lpOutValue);
            }
            VideoStatus = !VideoStatus;
        }
        /// <summary>
        /// 快进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_back_Click(object sender, EventArgs e)
        {
            if (_videoStatus2)
            {
                btn_back.Text = "正常";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 5, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 5, 0, ref lpOutValue);
                btn_start.Enabled = false;
            }
            else
            {
                btn_back.Text = "快进";
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle1, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle2, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle3, 7, 0, ref lpOutValue);
                CHCNetSDK.NET_DVR_PlayBackControl(m_lRealHandle4, 7, 0, ref lpOutValue);
                btn_start.Enabled = true;
            }
            _videoStatus2 = !_videoStatus2;
        }
        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stop_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle1);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle2);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle3);
            CHCNetSDK.NET_DVR_StopPlayBack(m_lRealHandle4);
            CHCNetSDK.NET_DVR_Logout(m_lUserID);
            m_lRealHandle1 = m_lRealHandle2 = m_lRealHandle3 = m_lRealHandle4 = m_lUserID = -1;
            CHCNetSDK.NET_DVR_Cleanup();
            lblVideo1.Visible = true;
            lblVideo2.Visible = true;
            lblVideo3.Visible = true;
            lblVideo4.Visible = true;
            btn_huifang.Enabled = true;
            lue_vedio.Enabled = true;
            btn_shipin.Enabled = true;
        }

        private void panelControl1_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }

        private void panelControl2_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[0].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[0].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }

        private void panelControl3_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[0].Width = 5000;
            }
        }
        private void panelControl4_DoubleClick(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowStyles[1].Height == 5000)
            {
                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.ColumnStyles[1].Width = 50;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 5000;
                tableLayoutPanel1.ColumnStyles[1].Width = 5000;
            }
        }

        private void gvw_pond_Click(object sender, EventArgs e)
        {
            pmpondtrainiron = gvw_pond.GetFocusedRow() as PM_Pond_Bill_Supplies;
            string time = "";
            DateTime dt;

            if (pmpondtrainiron != null)
            {
                if (pmpondtrainiron.TareWgtTime != "" && pmpondtrainiron.TareWgtTime != null)
                {
                    dt = Convert.ToDateTime(pmpondtrainiron.TareWgtTime);
                    time = dt.ToString("yyyyMMddHHmmss");
                }

                IList<PM_Standard_Tare_Info> picList = tareService.ExecuteDB_QueryByCar(pmpondtrainiron.WagNo).Where(x => (x.TareTime == time)).ToList();
                if (picList != null && picList.Count != 0)
                {
                    Pic_Show(picList.Select(x => x.ImgURL).ToList());
                }
            }
        }
        public void Pic_Show(IList<string> list)
        {
            ClearPic();
            int count = list.Count;
            if (list != null)
            {
                for (int i = 0; i < count; i++)
                {
                    pictureEdit1.Visible = false;
                    MyFTPPictureHelper.ShowFTPPicture(pictureEdit1, list[i], IP);
                }
            }
        }
        public void ClearPic()
        {
            if (pictureEdit1.Image != null)
            {
                pictureEdit1.Image.Dispose();
            }
            pictureEdit1.Image = null;
        }

        private void searchLookUpEdit2View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string IsUse = searchLookUpEdit2View.GetRowCellValue(e.RowHandle, "IsUse").ToString();
            if (IsUse == "1")
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void searchLookUpEdit2View_Click(object sender, EventArgs e)
        {
            QueryForMovedataNum data = searchLookUpEdit2View.GetFocusedRow() as QueryForMovedataNum;

            if (data != null)
            {
                PM_RawData_MoveTrain rawData = new PM_RawData_MoveTrain();
                rawData.FormationTag = data.FormationTag;
                rawData.SiteNo = new SM_PoundSite_Info() { PoundSiteNo = siteno };
                rawData.IsUse = 1;

                var re = rawdatamoveservice.ExecuteDB_UpdateRawDataUse(rawData);
            }
        }
        private void PM_Bill_MoveTrain_Mats_Form_New_Load(object sender, EventArgs e)
        {
            InitView(gvw_main);
            InitView(gvw_pond);
            InitView(gvw_result);
            Settxt_poundsiteData();
            timer1.Start();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(lue_SiteNo.Text))
            {
                ht.Add("SiteNo", lue_SiteNo.EditValue);
            }
            lue_FormationTag.Properties.DataSource = rawdatamoveservice.ExecuteDB_QueryBytag(ht);
        }
        #endregion

        #region 硬盘录像机

        //private CHCNetSDK.REALDATACALLBACK m_fRealData = null;
        //private CHCNetSDK.NET_DVR_CLIENTINFO lpClientInfo;
        private CHCNetSDK.NET_DVR_TIME dateTimeStart;
        private CHCNetSDK.NET_DVR_TIME dateTimeEnd;
        private CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        private bool VideoStatus = true;
        public bool _videoStatus2 = true;
        private IntPtr pUser;
        private Int32 m_lUserID = -1;
        private Int32 m_lUserID2 = -1;
        private Int32 m_lUserID3 = -1;
        private bool m_bInitSDK = false;

        private Int32 m_lRealHandle1 = -1;
        private Int32 m_lRealHandle2 = -1;
        private Int32 m_lRealHandle3 = -1;
        private Int32 m_lRealHandle4 = -1;
        private Int32 m_lRealHandle5 = -1;
        private Int32 m_lRealHandle6 = -1;
        private Int32 m_lRealHandle7 = -1;
        private Int32 m_lRealHandle8 = -1;
        private uint lpOutValue = 0;

        private bool _videoStatus = false;
        private Int32 _voiceCom = -1;
        private uint iLastErr = 0;
        private string str;

        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private int[] iChannelNum = new int[96];
        private List<Int32> realHandles = new List<Int32>();
        private Int32 realHandle7 = 0;
        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
            iChannelNum = new int[96];
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
            }
            else
            {
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (int i = 0; i < dwAChanTotalNum; i++)
                {
                    iChannelNum[i] = i + (int)m_struDeviceInfo.byStartChan;
                }

                byte byStreamType = 0;
                uint iDChanNum = 64;
                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;
                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;

                    dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[i].uGetStream);
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);

        }
        private void ShowTxtLog(string errStr)
        {
            errStr = String.Format("{0}  {1}{2}", DateTime.Now.ToLocalTime(), errStr, Environment.NewLine);
            synchronizationContext.Send(a =>
            {
                txtStatus.Text = errStr + txtStatus.Text;
                //txtStatus.SelectedText = errStr;
            }, null);

            //_voice.Speak(CutString(errStr));
        }
        public void VideoPlay()
        {
            try
            {
                if (!_videoStatus)
                {
                    _videoStatus = true;
                    m_bInitSDK = CHCNetSDK.NET_DVR_Init();

                    if (m_bInitSDK == false)
                    {
                        ShowTxtLog("SDK加载失败！");
                        return;
                    }
                    if (pondSiteInfo != null && pondSiteInfo.IntId > 0)
                    {
                        SM_Dvr_Info dvr = dvrService.ExecuteDB_QueryAllByPondId(pondSiteInfo.IntId);
                        if (dvr != null)
                        {
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(dvr.DvrIP1, 8000, dvr.Username, dvr.Password, ref m_struDeviceInfo);

                            if (m_lUserID == -1)
                            {
                                ShowTxtLog("硬盘录像机连接失败！");
                                return;
                            }
                            else
                            {
                                dwAChanTotalNum = (uint)m_struDeviceInfo.byChanNum;
                                dwDChanTotalNum = (uint)m_struDeviceInfo.byIPChanNum + 256 * (uint)m_struDeviceInfo.byHighDChanNum;
                                InfoIPChannel();
                            }
                            List<LabelControl> labls = new List<LabelControl>();
                            labls.Add(lblVideo1);
                            labls.Add(lblVideo2);
                            labls.Add(lblVideo3);
                            labls.Add(lblVideo4);

                            List<PanelControl> pannels = new List<PanelControl>();
                            pannels.Add(panelControl1);
                            pannels.Add(panelControl2);
                            pannels.Add(panelControl3);
                            pannels.Add(panelControl4);

                            realHandles.Clear();
                            CHCNetSDK.NET_DVR_SetAudioMode(2);
                            for (int i = 0; i < pannels.Count; i++)
                            {
                                if (iChannelNum[i] > -1)
                                {
                                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                    lpPreviewInfo.lChannel = iChannelNum[i];//预览的设备通道 the device channel number

                                    lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数
                                    IntPtr pUser = IntPtr.Zero;//用户数据 user data 
                                    synchronizationContext.Send(a =>
                                    {
                                        lpPreviewInfo.hPlayWnd = pannels[i].Handle;//预览窗口 live view window
                                        int m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                        if (m_lRealHandle > -1)
                                        {
                                            realHandles.Add(m_lRealHandle);
                                            if (i < 2)
                                            {
                                                CHCNetSDK.NET_DVR_OpenSoundShare(m_lRealHandle);
                                                CHCNetSDK.NET_DVR_SetVolume_Card(m_lRealHandle, 0xffff);
                                            }
                                            labls[i].Visible = false;
                                        }

                                    }, null);
                                }
                            }
                            synchronizationContext.Send(a =>
                            {
                                btn_shipin.Text = @"关闭视频";
                            }, null);
                            //CHCNetSDK.VOICEDATACALLBACKV30 fVoiceDataCallBack = null;//打开对讲
                            //_voiceCom = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, 1, true, fVoiceDataCallBack, IntPtr.Zero);//打开对讲
                            //uint rsInt = CHCNetSDK.NET_DVR_GetLastError();
                            //if (rsInt != 0)
                            //{
                            //    ShowTxtLog("对讲失败" + rsInt);
                            //}
                            //if (_voiceCom == -1)
                            //{
                            //    ShowTxtLog("对讲通道被其他坐席所占，无法开启对讲通道！");
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void VideoStop()
        {
            synchronizationContext.Send(a =>
            {
                btn_shipin.Text = @"视频连接";
                _videoStatus = false;
                lblVideo1.Visible = true;
                lblVideo2.Visible = true;
                lblVideo3.Visible = true;
                lblVideo4.Visible = true;
                foreach (Int32 handel in realHandles)
                {
                    CHCNetSDK.NET_DVR_CloseSoundShare(handel);
                    CHCNetSDK.NET_DVR_StopRealPlay(handel);
                }
                CHCNetSDK.NET_DVR_StopVoiceCom(_voiceCom);
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                CHCNetSDK.NET_DVR_Cleanup();
                panelControl1.Invalidate();
                panelControl2.Invalidate();
                panelControl3.Invalidate();
                panelControl4.Invalidate();
            }, null);
        }


        #endregion
        /// <summary>
        /// 该方法中检查皮重是否满足匹配要求：1.只识别到一个不为0的皮重2.识别到两个皮重但其中一个为0；3.该皮重和历史皮重相比相差不超过0.1吨
        /// </summary>
        /// <param name="tareList"></param>
        /// <returns></returns>
        private bool checkTareList(IList<SM_GczTare_Info> tareList)
        {
            bool flag = false;
            if (tareList.Count > 0)
            {
                if (tareList.Count == 1)
                {
                    if (Convert.ToDecimal(tareList[0].C_TAREWEIGHT) > 0)
                    {
                        if (checkTareHistory(tareList[0]))
                        {
                            flag = true;
                        }                 
                    }
                }
                else if (tareList.Count == 2)
                {
                    //只有一个重量为0
                    Decimal weight1 = Convert.ToDecimal(tareList[0].C_TAREWEIGHT);
                    Decimal weight2 = Convert.ToDecimal(tareList[1].C_TAREWEIGHT);
                    /*
                    if ((weight1 == 0 || weight2 == 0) && (weight1 + weight2 > 0))
                    {
                        flag = true;
                    }
                    */
                    if(weight1 == 0 && weight2 > 0)
                    {
                        if (checkTareHistory(tareList[1]))
                        {
                            flag = true;
                        }
                    }else if( weight1 > 0 && weight2 == 0)
                    {
                        if (checkTareHistory(tareList[2]))
                        {
                            flag = true;
                        }

                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 当前皮重与历史皮重平均值比较
        /// </summary>
        /// <param name="tare"></param>
        /// <returns></returns>
        private bool checkTareHistory(SM_GczTare_Info tare)
        {
            bool flag = false;
            string carName = tare.C_CARNAME;
            Hashtable ht = new Hashtable();
            ht.Add("carName", carName);
            IList<PM_Pond_Bill_Supplies> bills = pondsupperservice.ExecuteDB_QueryHistoryByWagNo(ht);
            if (bills.Count > 0)
            {
                decimal num = 0;
                foreach (PM_Pond_Bill_Supplies bill in bills)
                {
                    num += bill.TareWgt;
                }
                if (Convert.ToDouble(num / bills.Count) - Convert.ToDouble(tare.C_TAREWEIGHT) < 0.1)
                {
                    flag = true;
                }
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        private bool chenkPondPlan(int[] rows)
        {
            bool flag = true;
            foreach (var items in rows)
            {
                PM_Pond_Bill_Supplies pm = gvw_pond.GetRow(items) as PM_Pond_Bill_Supplies;
                if (pm.PlanNo != null && !string.IsNullOrEmpty(pm.PlanNo))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        //新增
        private void gvw_Pond_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {           
            //列名为 gridColumn2的单元列
            if (e.Column.Name == "gridColumn10" || e.Column.Name == "gridColumn11")
            {
                var v = e.CellValue;
                if (v != null)
                {
                    if (Convert.ToDecimal(v.ToString()) <= 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="poundtrainmats"></param>
        /// <param name="tare"></param>
        /// <returns></returns>
        private PM_Pond_Bill_Supplies matchTareWeight(PM_Pond_Bill_Supplies poundtrainmats, SM_GczTare_Info tare)
        {
            poundtrainmats.TareWgt = tare.C_TAREWEIGHT;
            poundtrainmats.TareWgtTime = tare.C_CREATETIME.ToString("yyyyMMddHHmmss");
            poundtrainmats.TareWgtSiteNo = tare.C_SITENO;
            poundtrainmats.TareWgtSiteName = lue_SiteNo.Text;
            poundtrainmats.TareWgtMan = SessionHelper.LogUserNickName.ToString();
            poundtrainmats.NetWgt = Convert.ToDecimal(poundtrainmats.GrossWgt) - Convert.ToDecimal(poundtrainmats.TareWgt);
            poundtrainmats.NetWgtTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            return poundtrainmats;

        }
      
    }
}
