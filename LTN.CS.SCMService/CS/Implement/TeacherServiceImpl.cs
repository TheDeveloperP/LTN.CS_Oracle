using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMDao.CS.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;
using LTN.CS.SCMEntities.CS;
using System.Collections;
using LTN.CS.SCMDao.Common;

namespace LTN.CS.SCMService.CS.Implement
{
    public class TeacherServiceImpl : ITeacherService
    {
        public ITeacherDao teacherDao { get; set; }
        public ICommonDao commonDao { get; set; }


        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]
        public IList<CS_Teacher> ExecuteDB_QueryAll()
        {
            IList<CS_Teacher> rs;
            try
            {
                // rs = teacherDao.ExecuteQueryAllList();
                rs = commonDao.ExecuteQueryForList<CS_Teacher>("selectCS_TeacherAll",null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<CS_Teacher> ExecuteDB_QueryAllByName(Hashtable name)
        {
            IList<CS_Teacher> rs;
            try
            {
                rs = commonDao.ExecuteQueryForList<CS_Teacher>("selectCS_TeacherAllByName", name);
              //  rs = teacherDao.ExecuteQueryAllListByName(name);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertStudent(CS_Teacher meter)
        {
            object rs;
            try
            {
                rs = teacherDao.ExecuteInsert(meter);
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

        public object ExecuteDB_UpdateStudent(CS_Teacher meter)
        {
            object rs;
            try
            {
                rs = teacherDao.ExecuteUpdate(meter);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteStudent(CS_Teacher meter)
        {
            object rs;
            try
            {
                rs = teacherDao.ExecuteDelete(meter);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
