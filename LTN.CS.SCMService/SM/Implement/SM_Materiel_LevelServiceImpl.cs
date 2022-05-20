using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Materiel_LevelServiceImpl : ISM_Materiel_LevelService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        [Services(IsOutTransaction = true)]

        public IList<SM_Materiel_Level> ExecuteDB_QueryAll()
        {
            IList<SM_Materiel_Level> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Materiel_Level>("selectSM_Materiel_LevelAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_Materiel_Level> ExecuteDB_QueryMaterielCode()
        {
            IList<SM_Materiel_Level> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Materiel_Level>("selectSM_Materiel_LevelForCode", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertMateriel(SM_Materiel_Level Site)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertSM_Materiel_Level", Site);
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
        public object ExecuteDB_UpdateMateriel(SM_Materiel_Level Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("UpdateSM_Materiel_Level", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeleteMateriel(SM_Materiel_Level Site)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_Materiel_Level", Site);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public IList<SM_Materiel_Level> ExecuteDB_QueryRepeatByMaterielName(string name)
        {
            IList<SM_Materiel_Level> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_Materiel_Level>("selectSM_Materiel_LevelByMaterielName", name);
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
