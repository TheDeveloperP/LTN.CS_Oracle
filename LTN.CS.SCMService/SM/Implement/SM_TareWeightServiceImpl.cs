using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Collections;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_TareWeightServiceImpl : ISM_TareWeightService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<SM_TareWeight> ExecuteDB_QueryAll()
        {
            IList<SM_TareWeight> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeight>("selectSM_TareWeightAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_TareWeight> ExecuteDB_QueryAllByCarNo(string carNo)
        {
            IList<SM_TareWeight> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_TareWeight>("selectSM_TareWeightAllByCarNo", carNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_TareWeightHistory> ExecuteDB_QueryHistoryAll()
        {
            IList<SM_TareWeightHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeightHistory>("selectSM_TareWeightHistoryAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertTareWeight(SM_TareWeight TareWeight)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_TareWeight", TareWeight);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InsertTareWeight2(SM_TareWeight TareWeight, string status, int IsExceed)
        {
            object rs;
            try
            {
                //判断最新是否存在车号数据，存在修改，不存在插入最新皮重库
                if (status == "Y")
                {

                    rs = CommonDao.ExecuteUpdate("UpdateSM_TareWeightByCarNo", TareWeight);
                }
                else
                {
                    rs = CommonDao.ExecuteInsert("InsertSM_TareWeight", TareWeight);
                }
                //插入历史皮重库
                //if (TareWeight.NewTare < 30000)
                //{
                    SM_TareWeightHistory tareHistory = new SM_TareWeightHistory();
                    tareHistory.CarName = TareWeight.CarName;
                    tareHistory.HistoryTare = TareWeight.NewTare;
                    tareHistory.SiteNo = TareWeight.SiteNo;
                    tareHistory.SiteName = TareWeight.SiteName;
                    tareHistory.CreateUserName = TareWeight.CreateUserName;
                    tareHistory.IsExceed = IsExceed;
                    rs = CommonDao.ExecuteInsert("InsertSM_TareWeightHistory", tareHistory); 
                //}
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        
        public object ExecuteDB_UpdateTareWeight(SM_TareWeight TareWeight)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_TareWeight", TareWeight);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteTareWeight(SM_TareWeight TareWeight)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_Car_Info", TareWeight);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_TareWeight> ExecuteDB_QueryAllByCondition(Hashtable condition)
        {
            IList<SM_TareWeight> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeight>("selectSM_TareWeightByCarNameAndTime", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdateTareWeight2(SM_TareWeight TareWeight)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_TareWeight2", TareWeight);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public SM_TareWeight ExecuteDB_QueryUsedByCarNo(string carNo)
        {
            SM_TareWeight result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<SM_TareWeight>("QuerySM_TareWeightByCarNo", carNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public IList<SM_TareWeightHistory> ExecuteDB_QueryHistoryByCarName(string CarName)
        {
            IList<SM_TareWeightHistory> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_TareWeightHistory>("selectSM_TareWeightHistoryByCarName", CarName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            
            return rs;
        }

        public object ExecuteDB_UpdateTareWeight3(SM_TareWeight TareWeight)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_TareWeight3", TareWeight);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
