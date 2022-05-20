using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMDao.CS.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.SCMEntities.CS;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;
using System.Collections;
using LTN.CS.SCMDao.Common;

namespace LTN.CS.SCMService.CS.Implement
{
    public class StudentServiceImpl : IStudentService
    {
        public IStudentDao mainDao { get; set; }
        public ICommonDao commonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]
        public IList<CS_Student> ExecuteDB_QueryAll()
        {
            IList<CS_Student> rs;
            try
            {
                rs=commonDao.ExecuteQueryForList<CS_Student>("selectCS_StudentAll", null);
                rs = commonDao.ExecuteQueryForList<CS_Student>("selectCS_StudentAll", null);
                rs = commonDao.ExecuteQueryForList<CS_Student>("selectCS_StudentAll", null);
                 rs = mainDao.ExecuteQueryAllList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<CS_Student> ExecuteDB_QueryAllByName(Hashtable name)
        {
            IList<CS_Student> rs;
            try
            {
                rs = commonDao.ExecuteQueryForList<CS_Student>("selectCS_StudentAllByName", name);
                //  rs = mainDao.ExecuteQueryAllListByName(name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertStudent(CS_Student meter)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteInsert(meter);
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

        public object ExecuteDB_UpdateStudent(CS_Student meter)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteUpdate(meter);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteStudent(CS_Student meter)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteDelete(meter);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
