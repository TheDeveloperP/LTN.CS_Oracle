using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_RFID_InfoServiceImpl : ISM_RFID_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        /// <summary>
        /// 新增RFID信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public object ExecuteDB_InsertRFIDInfo(SM_RFID_Info Info)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_RFID_Info", Info);
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
        /// <summary>
        /// 作废RFID信息
        /// </summary>
        /// <param name="RFid"></param>
        /// <returns></returns>
        public object ExecuteDB_InvalidRFIDInfo(SM_RFID_Info Info)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("Invalid_SM_RFID_Info", Info);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        /// <summary>
        /// 查询RFID信息
        /// </summary>
        /// <returns></returns>
        public IList<SM_RFID_Info> ExecuteDB_QueryAll()
        {
            IList<SM_RFID_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_RFID_Info>("selectSM_RFID_InfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        /// <summary>
        /// 修改RFID信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public object ExecuteDB_UpdateRFIDInfo(SM_RFID_Info Info)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_RFID_Info", Info);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_RFID_Info> ExecuteDB_QueryCarNo(string CarNo)
        {
            IList<SM_RFID_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_RFID_Info>("selectSM_RFID_InfoForJudgeCarNo", CarNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_RFID_Info> ExecuteDB_QueryRFID(string RFID)
        {
            IList<SM_RFID_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_RFID_Info>("selectSM_RFID_InfoForJudgeRFID", RFID);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_RFID_Info> ExecuteDB_QueryCarNameFromRfid(string RFID)
        {
            IList<SM_RFID_Info> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_RFID_Info>("selectCarNameFromRfidNo", RFID);
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
