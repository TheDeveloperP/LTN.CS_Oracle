using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Implement
{
    public class RP_Print_RecordService : IRP_Print_RecordService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public object ExecuteDB_InsertRP_Print_Record(RP_Materiel_PrintRecord printEntity)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertRP_Print_Record_Info", printEntity);
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

        public IList<RP_Materiel_PrintRecord> ExecuteDB_QueryByPrintInfo(Hashtable ht)
        {
            IList<RP_Materiel_PrintRecord> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<RP_Materiel_PrintRecord>("QueryByPrintInfo", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
