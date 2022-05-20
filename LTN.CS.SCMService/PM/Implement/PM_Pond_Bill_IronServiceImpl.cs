using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.Core.Common;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Pond_Bill_IronServiceImpl : IPM_Pond_Bill_IronService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryAll()
        {
            IList<PM_Pond_Bill_Iron> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Iron", pond);
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
        public object ExecuteDB_UpdateIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Iron", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_Pond_Bill_Iron", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InvalidIronPondByIntId(PM_Pond_Bill_Iron pond)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_IronFlag", pond);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryIronPondByHashTable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                //result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronByCond", ht);
                //修改成按照磅单修改时间来排序
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronByCond3", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByDic(Hashtable dic)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbyDic", dic);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByGroup(string FormationTag)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbyGroup", FormationTag);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryBySiteAndTagFormation(Hashtable ht)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbySiteAndTagFormation", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

      
    }
}
