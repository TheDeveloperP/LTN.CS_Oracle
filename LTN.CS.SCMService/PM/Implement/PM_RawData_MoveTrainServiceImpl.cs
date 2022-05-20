using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using System.Collections;
using LTN.CS.SCMEntities.ConditionEntity;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_RawData_MoveTrainServiceImpl : IPM_RawData_MoveTrainService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeleteRawDataInfo(PM_RawData_MoveTrain RawData)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_RawData_MoveTrain", RawData);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertRawDataInfo(PM_RawData_MoveTrain RawData)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_RawData_MoveTrain", RawData);
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

        public IList<PM_RawData_MoveTrain> ExecuteDB_QueryAll()
        {
            IList<PM_RawData_MoveTrain> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<PM_RawData_MoveTrain>("selectPM_RawData_MoveTrainAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdateRawDataInfo(PM_RawData_MoveTrain RawData)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_RawData_MoveTrain", RawData);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_UpdateRawDataUse(PM_RawData_MoveTrain RawData)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_RawData_MoveTrainUse", RawData);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<PM_RawData_MoveTrain> ExecuteDB_QueryByHashTable(Hashtable ht)
        {
            IList<PM_RawData_MoveTrain> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_RawData_MoveTrain>("selectPM_RawData_MoveTrainByCond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<QueryForMovedataNum> ExecuteDB_QueryBytag(Hashtable ht)
        {
            IList< QueryForMovedataNum > result;
            try
            {
                result = CommonDao.ExecuteQueryForList<QueryForMovedataNum>("SelectPM_RawData_MoveTrainByTag", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_RawData_MoveTrain> ExecuteDB_QueryBytagdata(Hashtable dic)
        {
            IList<PM_RawData_MoveTrain> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_RawData_MoveTrain>("selectPM_RawData_MoveTrainbyDic", dic);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_RawData_MoveTrain> ExecuteDB_QueryByCar(string CarsNo)
        {
            IList<PM_RawData_MoveTrain> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_RawData_MoveTrain>("selectPM_RawData_MoveTrainByCar", CarsNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_InvalidRawDatByIntId(PM_RawData_MoveTrain RawData)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("InvalidRawDataByIntId", RawData);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        //新增
        public IList<PM_RawData_MoveTrain_New> ExecuteDB_QueryByHashTable_New(Hashtable ht)
        {
            IList<PM_RawData_MoveTrain_New> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_RawData_MoveTrain_New>("selectPM_RawData_MoveTrain_NewByCond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public object ExecuteDB_InvalidRawDatByIntId_New(PM_RawData_MoveTrain_New RawData)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("InvalidRawDataByIntId_New", RawData);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public object ExecuteDB_DeleteRawDataInfo_New(PM_RawData_MoveTrain_New RawData)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_RawData_MoveTrain_New", RawData);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_UpdateRawDataInfo_New(PM_RawData_MoveTrain_New RawData)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_RawData_MoveTrain_New", RawData);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InsertRawDataInfo_New(PM_RawData_MoveTrain_New RawData)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_RawData_MoveTrain_New", RawData);
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
    }
}
