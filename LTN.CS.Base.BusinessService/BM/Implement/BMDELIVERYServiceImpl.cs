using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Implement;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Helper;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMDELIVERYServiceImpl : IBMDELIVERYService
    {
        public IBMDELIVERYDao mainDao { get; set; }
        public IBMDELIVERYHISTORYDao historyDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_Insert(BM_DELIVERY entity)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteInsert(entity);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public object ExecuteDB_QueryEntityByStatus(params int[] args)
        {
            object rs = null;
            List<BM_DELIVERY> queryRs = new List<BM_DELIVERY>();
            try
            {
                foreach (int arg in args)
                {
                    IList<BM_DELIVERY> queryRsTemp = mainDao.QueryEntitiesByStatus(arg);
                    queryRs.AddRange(queryRsTemp.Where<BM_DELIVERY>(e=>e.Approver.IntId == SessionHelper.LogUserId).ToList());
                }
                rs = queryRs;
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Quasi(BM_DELIVERY entity,BM_DELIVERY_HISTORY history)
        {
            object rs;
            try
            {
                rs = historyDao.ExecuteInsert(history);
                rs = mainDao.ExecuteUpdate(entity);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Update(BM_DELIVERY entity)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteUpdate(entity);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_UnQuasi(BM_DELIVERY entity)
        {
            object rs;
            try
            {;
                rs = mainDao.ExecuteUpdate(entity);
                object historyId = historyDao.QueryMaxIdByMainId(entity.IntId);
                historyDao.ExecuteDelete(historyId);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Confirm(BM_DELIVERY entity, BM_DELIVERY_HISTORY history)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteInsert(entity);
                history.MainId = MyNumberHelper.ConvertToInt32(rs);
                rs = historyDao.ExecuteInsert(history);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
