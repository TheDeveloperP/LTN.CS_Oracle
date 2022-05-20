using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM_Query;
using LTN.CS.BaseEntities.BM;
using IBatisNet.Common.Logging;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMMAINGROUPServiceImpl : IBMMAINGROUPService
    {
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IBMMAINGROUPDao groupDao { get; set; }
        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP> ExecuteDB_QueryAllByUserId(SelectBMMAINGROUPAll condition)
        {
            IList<BM_MAIN_GROUP> rs = null;
            try
            {
                rs = groupDao.ExecuteQueryAllByUserId(condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP> ExecuteDB_QueryAll()
        {
            IList<BM_MAIN_GROUP> rs = null;
            try
            {
                rs = groupDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP> ExecuteDB_QueryByGroupName(string groupName)
        {
            IList<BM_MAIN_GROUP> rs = null;
            try
            {
                rs = groupDao.ExecuteQueryByGroupName(groupName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertMainGroup(BM_MAIN_GROUP mainGroup)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteInsert(mainGroup);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_UpdateMainGroup(BM_MAIN_GROUP mainGroup)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteUpdate(mainGroup);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteMainGroup(BM_MAIN_GROUP mainGroup)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteDelete(mainGroup);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP> ExecuteDB_QueryByPageId(int pageid)
        {
            IList<BM_MAIN_GROUP> rs = null;
            try
            {
                rs = groupDao.ExecuteQueryByPageId(pageid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP> ExecuteDB_QueryByIntId(int intid)
        {
            IList<BM_MAIN_GROUP> rs = null;
            try
            {
                rs = groupDao.ExecuteQueryByIntId(intid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DisabledMainGroup(BM_MAIN_GROUP mainGroup)
        {
            object rs = null;
            try
            {
                rs = groupDao.ExecuteDisabled(mainGroup);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
