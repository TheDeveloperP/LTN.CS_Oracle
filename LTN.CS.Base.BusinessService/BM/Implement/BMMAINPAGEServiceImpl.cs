using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMMAINPAGEServiceImpl : IBMMAINPAGEService
    {
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IBMMAINPAGEDao pageDao { get; set; }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_PAGE> ExecuteDB_QueryByUser(int userId)
        {
            IList<BM_MAIN_PAGE> rs = null;
            try
            {
                rs = pageDao.ExecuteQueryByUserId(userId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_PAGE> ExecuteDB_QueryAllPage()
        {
            IList<BM_MAIN_PAGE> rs = null;
            try
            {
                rs = pageDao.ExecuteQueryForList<BM_MAIN_PAGE>(null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_PAGE> ExecuteDB_QueryByPageName(string pageName)
        {
            IList<BM_MAIN_PAGE> rs = null;
            try
            {
                rs = pageDao.ExecuteQueryByPageName(pageName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_Insert(BM_MAIN_PAGE page)
        {
            object rs;
            try
            {
                rs = pageDao.ExecuteInsert(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Update(BM_MAIN_PAGE page)
        {
            object rs;
            try
            {
                rs = pageDao.ExecuteUpdate(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Delete(BM_MAIN_PAGE page)
        {
            object rs;
            try
            {
                rs = pageDao.ExecuteDelete(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_PAGE> ExecuteDB_QueryAll()
        {
            IList<BM_MAIN_PAGE> rs = null;
            try
            {
                rs = pageDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Disabled(BM_MAIN_PAGE page)
        {
            object rs;
            try
            {
                rs = pageDao.ExecuteDisabled(page);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
