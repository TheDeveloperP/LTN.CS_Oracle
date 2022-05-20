using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using System.Data;
using System.Collections;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_ReeferContainerNo_InfoServiceImpl : ISM_ReeferContainerNo_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertReeferContainerRateInfo(SM_ReeferContainerNo_Info rate)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_ReeferContainerNoInfo_Rate", rate);
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

        public IList<SM_ReeferContainerNo_Info> ExecuteDB_QueryAll()
        {
            IList<SM_ReeferContainerNo_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_ReeferContainerNo_Info>("QuerySM_ReeferContainerNo_Info_RateAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        /// <summary>
        /// 用于统计识别率
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable ExecuteDB_QueryReeferContainerRecognitionRateAll(Hashtable condition)
        {
            DataTable rs = null;
            try
            {
                Hashtable ht = new Hashtable();
                rs = CommonDao.ExecuteQueryForDataTable("QueryReeferContainerNoInfoAll", condition, out ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<SM_ReeferContainerNo_Info> ExecuteDB_QueryAllByCondition(Hashtable condition)
        {
            IList<SM_ReeferContainerNo_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_ReeferContainerNo_Info>("QuerySM_ReeferContainer_RateNoInfoByCondition", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        /*
        public SM_JZX_Huda_Message ExecuteDB_QueryAllByCondition_Huda(Hashtable condition)
        {            
            SM_JZX_Huda_Message message;
            try
            {                
                message = CommonDao.ExecuteQueryForObject<SM_JZX_Huda_Message>("QuerySM_JZX_Huda_MessageByCarNameAndPond", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                message = null;
            }
            return message;     
        }
        
    */
        public IList<SM_JZX_Huda_Message> ExecuteDB_QueryAllByCondition_Huda(Hashtable condition)
        {
            IList<SM_JZX_Huda_Message> message;
            try
            {
                message = CommonDao.ExecuteQueryForList<SM_JZX_Huda_Message>("QuerySM_JZX_Huda_MessageByCarNameAndPond", condition);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                message = null;
            }
            return message;
        }

    }
}
