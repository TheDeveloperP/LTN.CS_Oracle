using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_ReasonForNoAutoServiceImpl : ISM_ReasonForNoAutoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<SM_ReasonForNoAuto> ExecuteDB_QueryAll()
        {
            IList<SM_ReasonForNoAuto> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_ReasonForNoAuto>("selectSM_ReasonForNoAutoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_ReasonForNoAuto> ExecuteDB_QueryByCondition(Hashtable ht)
        {
            IList<SM_ReasonForNoAuto> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_ReasonForNoAuto>("selectSM_ReasonForNoAutoByCondition", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertReasonInfo(SM_ReasonForNoAuto ReasonInfo)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_ReasonForNoAuto", ReasonInfo);
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
    }
}
