using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMService.CS.Interface;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.SCMEntities.CS;
using System.Collections;

namespace LTN.CS.SCMService.CS.Implement
{
    public class SM_WeightList_InfoServiceImpl : ISM_WeightList_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<SM_WeightList_Info> ExecuteDB_QueryWeight(Hashtable ht)
        {
            IList<SM_WeightList_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_WeightList_Info>("selectSM_WeightList_Info", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_WeightList_Info> ExecuteDB_QueryWeight2(Hashtable ht)
        {
            IList<SM_WeightList_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_WeightList_Info>("selectSM_WeightList_Info2", ht);
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
