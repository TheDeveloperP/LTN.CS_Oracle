using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMSERVERServiceImpl : IBMSERVERService
    {

        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IBMSERVICEDao serviceDao { get; set; }

        /// <summary>
        /// 根据服务名查询用户对象
        /// </summary>
        [Services(IsOutTransaction = true)]
        public BM_SERVICE ExecuteDB_QueryByNo(string serviceNo)
        {
            BM_SERVICE rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryByNo(serviceNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        /// <summary>
        /// 根据服务名查询用户对象
        /// </summary>
        [Services(IsOutTransaction = true)]
        public BM_SERVICE ExecuteDB_QueryById(int serviceId)
        {
            BM_SERVICE rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryById(serviceId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryServerId(int serviceId)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryByServerId(serviceId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryInGroup(int GroupId)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryInGroup(GroupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryNotInGroup(int GroupId)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryNotInGroup(GroupId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryInUser(int UserId)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryInUser(UserId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryNotInUser(int UserId)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryNotInUser(UserId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryAll()
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_SERVICE> ExecuteDB_QueryByIntId(int intid)
        {
            IList<BM_SERVICE> rs = null;
            try
            {
                rs = serviceDao.ExecuteQueryByIntId(intid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        #region IBMSERVERService 成员


        public object ExecuteDB_Insert(BM_SERVICE page)
        {
            object rs;
            try
            {
                rs = serviceDao.ExecuteInsert(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Update(BM_SERVICE page)
        {
            object rs;
            try
            {
                rs = serviceDao.ExecuteUpdate(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Delete(BM_SERVICE page)
        {
            object rs;
            try
            {
                rs = serviceDao.ExecuteDelete(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        #endregion


        public object ExecuteDB_DisableService(BM_SERVICE service)
        {
            object rs;
            try
            {
                rs = serviceDao.ExecuteDisabled(service);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_LimitedService(BM_SERVICE service)
        {
            object rs;
            try
            {
                rs = serviceDao.ExecuteLimited(service);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        
    }
}
