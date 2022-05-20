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
    public class SM_Department_LevelOne_InfoServiceImpl : ISM_Department_LevelOne_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]

        public IList<SM_Department_LevelOne_Info> ExecuteDB_QueryAll()
        {
            IList<SM_Department_LevelOne_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Department_LevelOne_Info>("selectSM_Department_LevelOne_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_QueryDepartmentCode()
        {
            string rs;
            try
            {

                rs = CommonDao.ExecuteQueryForObject<string>("selectSM_Department_LevelOne_InfoForCode", null);
                if (rs == null)
                    rs = "D000000";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs =null;
            }
            return rs;
        }



        public object ExecuteDB_InsertDepartment(SM_Department_LevelOne_Info Site)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_Department_LevelOne_Info", Site);
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
        
        public object ExecuteDB_UpdateDepartment(SM_Department_LevelOne_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Department_LevelOne_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteDepartment(SM_Department_LevelOne_Info Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_Department_LevelOne_Info", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_Department_LevelOne_Info> ExecuteDB_QueryByDeptName(string Deptname)
        {
            IList<SM_Department_LevelOne_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Department_LevelOne_Info>("selectSM_Department_LevelOne_InfoByDeptName", Deptname);
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
