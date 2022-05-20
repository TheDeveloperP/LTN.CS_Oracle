using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.BaseEntities.BM_Query;
using IBatisNet.Common.Logging;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMMAINGROUPSERVICEServiceImpl : IBMMAINGROUPSERVICEService
    {
        public IBMMAINGROUPSERVICEDao groupServiceDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
         
        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryById(int id)
        {
            IList<BM_MAIN_GROUP_SERVICE> rs = null;
            try
            {
                rs = groupServiceDao.ExecuteQueryByServiceId(id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryByGroupId(int groupid)
        {
            IList<BM_MAIN_GROUP_SERVICE> rs = null;
            try
            {
                rs = groupServiceDao.ExecuteQueryByGroupId(groupid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public BM_MAIN_GROUP_SERVICE ExecuteDB_QueryByName(string name)
        {
            BM_MAIN_GROUP_SERVICE rs = null;
            try
            {
                rs = groupServiceDao.ExecuteQueryByName(name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP_SERVICE> ExecuteDB_QueryAll()
        {
            IList<BM_MAIN_GROUP_SERVICE> rs = null;
            try
            {
                rs = groupServiceDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InserUser(BM_MAIN_GROUP_SERVICE user)
        {
            object rs;
            try
            {
                rs = groupServiceDao.ExecuteInsert(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateUser(BM_MAIN_GROUP_SERVICE user)
        {
            object rs;
            try
            {
                rs = groupServiceDao.ExecuteUpdate(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_DeleteUser(BM_MAIN_GROUP_SERVICE user)
        {
            object rs;
            try
            {
                rs = groupServiceDao.ExecuteDelete(user);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_GROUP_SERVICE_MENU> ExecuteDB_QueryAllByUserId(SelectBMMAINGROUPSERVICEAll condition)
        {
            IList<BM_MAIN_GROUP_SERVICE_MENU> rs = null;
            try
            {
                rs = groupServiceDao.ExecuteQueryAllByUserId(condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DisableSERVICEMENU(BM_MAIN_GROUP_SERVICE menu)
        {
            object rs;
            try
            {
                rs = groupServiceDao.ExecuteDisabled(menu);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
