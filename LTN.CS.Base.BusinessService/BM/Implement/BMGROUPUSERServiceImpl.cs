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
    public class BMGROUPUSERServiceImpl:IBMGROUPUSERService
    {
        public IBMGROUPUSERDao groupuserDao { get; set; }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

         [Services(IsOutTransaction = true)]
        public IList<BM_GROUP_USER> ExecuteDB_QueryAll()
        {
            IList<BM_GROUP_USER> rs = null;
            try
            {
                rs = groupuserDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InserGroupUser(BM_GROUP_USER user)
        {
            object rs;
            try
            {
                rs = groupuserDao.ExecuteInsert(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }



        public object ExecuteDB_DeleteGroupUser(BM_GROUP_USER user)
        {
            object rs;
            try
            {
                rs = groupuserDao.ExecuteDelete(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<BM_GROUP_USER> ExecuteDB_QueryByUserId(int id)
        {
            IList<BM_GROUP_USER> rs = null;
            try
            {
                rs = groupuserDao.ExecuteQueryByUserId(id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
