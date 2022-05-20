using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_JZXH_InfoServiceImpl : ISM_JZXH_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<SM_JZXH_Info> ExecuteDB_QueryAll()
        {
            IList<SM_JZXH_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_JZXH_Info>("QuerySM_JZXH_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public SM_JZXH_Info ExecuteDB_QueryByCarNameAndPond(Hashtable ht)
        {
            SM_JZXH_Info rs;
            try
            {

                rs = CommonDao.ExecuteQueryForObject<SM_JZXH_Info>("QuerySM_JZXH_InfoByCarNameAndPond", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_JZXH_Info> ExecuteDB_QueryByCarName(Hashtable ht)
        {
            IList<SM_JZXH_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_JZXH_Info>("QuerySM_JZXH_InfoAllByCarName", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
