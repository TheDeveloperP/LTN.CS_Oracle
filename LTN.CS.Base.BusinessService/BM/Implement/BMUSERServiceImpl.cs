using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Base.BusinessDao.BM.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMUSERServiceImpl : IBMUSERService
    {
        public IBMUSERDao userDao { get; set; }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]
        public object ExecuteDB_QueryByName(string name)
        {
            object rs = null;
            try
            {
                rs=userDao.ExecuteQueryByName(name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.Message.Contains("Unable to open connection"))
                {
                    rs = new CustomDBError("无法连接数据库，请联系管理员！");
                }
                else
                {
                    rs = new CustomDBError(ex.Message);
                }
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_USER> ExecuteDB_QueryAll()
        {
            IList<BM_USER>  rs = null;
            try
            {
                rs = userDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_USER> ExecuteDB_QueryNotInGroup(int groupId)
        {
            IList<BM_USER> rs = null;
            try
            {
                rs = userDao.ExecuteQueryNotInGroup(groupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_USER> ExecuteDB_QueryInGroup(int groupId)
        {
            IList<BM_USER> rs = null;
            try
            {
                rs = userDao.ExecuteQueryInGroup(groupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<BM_USER> ExecuteDB_QueryNotInBusinessManager(int groupId)
        {
            IList<BM_USER> rs = null;
            try
            {
                rs = userDao.ExecuteQueryNotInBusinessManager(groupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_USER> ExecuteDB_QueryInBusinessManager(int groupId)
        {
            IList<BM_USER> rs = null;
            try
            {
                rs = userDao.ExecuteQueryInBusinessManager(groupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InserUser(BM_USER user)
        {
            object rs;
            try
            {
                rs = userDao.ExecuteInsert(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateUser(BM_USER user)
        {
            object rs;
            try
            {
                rs = userDao.ExecuteUpdate(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DeleteUser(BM_USER user) 
        {
            object rs;
            try
            {
                rs = userDao.ExecuteDelete(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DisableUser(BM_USER user)
        {
            object rs;
            try
            {
                rs = userDao.ExecuteDisabled(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
