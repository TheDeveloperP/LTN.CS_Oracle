using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Department_LevelTwo_InfoServiceImpl : ISM_Department_LevelTwo_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]
        public IList<SM_Department_LevelTwo_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Department_LevelTwo_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Department_LevelTwo_Info>("selectSM_Department_LevelTwo_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertDepartment(SM_Department_LevelTwo_Info Site)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_Department_LevelTwo_Info", Site);
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
        public object ExecuteDB_UpdateDepartment(SM_Department_LevelTwo_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Department_LevelTwo_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteDepartment(SM_Department_LevelTwo_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_Department_LevelTwo_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_Department_LevelTwo_Info> ExecuteDB_QueryByMainId(int MainId)
        {
            IList<SM_Department_LevelTwo_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_Department_LevelTwo_Info>("selectSM_Department_LevelTwo_InfoByMainId", MainId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
