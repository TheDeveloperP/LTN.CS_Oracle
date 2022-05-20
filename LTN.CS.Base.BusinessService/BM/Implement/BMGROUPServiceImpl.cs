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
    public class BMGROUPServiceImpl : IBMGROUPService
    {
        public IBMGROUPDao groupDao { get; set; }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction=true)]
        public BM_GROUP ExecuteDB_QueryByName(string name)
        {
            BM_GROUP rs = null;
            try
            {
                rs = groupDao.ExecuteQueryByName(name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_GROUP> ExecuteDB_QueryAll()
        {
            IList<BM_GROUP> rs = null;
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
        public object ExecuteDB_InserGROUP(BM_GROUP group)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteInsert(group);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateGROUP(BM_GROUP group)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteUpdate(group);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DeleteGROUP(BM_GROUP group)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteDelete(group);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DisableDGROUP(BM_GROUP group)
        {
            object rs;
            try
            {
                rs = groupDao.ExecuteDisabled(group);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
