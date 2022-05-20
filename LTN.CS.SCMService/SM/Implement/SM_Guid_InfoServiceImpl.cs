using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMService.SM.Interface;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_Guid_InfoServiceImpl : ISM_Guid_InfoService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public object ExecuteDB_InsertGuidInfo(SM_Guid_Info Dvr)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteInsert("InsertSM_Guid_Info", Dvr);
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
