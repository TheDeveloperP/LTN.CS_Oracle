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
    public class SM_GczTare_InfoServiceImpl : ISM_GczTare_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<SM_GczTare_Info> ExecuteDB_QueryGczTare(Hashtable ht)
        {
            IList<SM_GczTare_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_GczTare_Info>("selectSM_GczTare_Info", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_GczTare_Info> ExecuteDB_QueryGczTare(string ht)
        {
            IList<SM_GczTare_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_GczTare_Info>("selectSM_GczTare_InfoByWgtNo", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }


        public IList<SM_GczTare_Info> ExecuteDB_QueryGczTareForMatch(Hashtable ht)
        {
            IList<SM_GczTare_Info> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_GczTare_Info>("selectSM_GczTare_InfoByHt", ht);
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
