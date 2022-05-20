using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMDELIVERYHISTORYServiceImpl : IBMDELIVERYHISTORYService
    {
        public IBMDELIVERYHISTORYDao mainDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_Insert(BM_DELIVERY_HISTORY entity)
        {
            object rs;
            try
            {
                rs = mainDao.ExecuteInsert(entity);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public IList<BM_DELIVERY_HISTORY> ExecuteDB_QueryByMainId(int mainId)
        {
            IList<BM_DELIVERY_HISTORY> rs;
            try
            {
                rs = mainDao.QueryEntitiesByMainId(mainId);
            }
            catch (Exception ex)
            {
                rs = null;
            }
            return rs;
        }
    }
}
