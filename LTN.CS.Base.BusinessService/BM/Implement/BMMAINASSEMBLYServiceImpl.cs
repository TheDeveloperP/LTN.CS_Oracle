using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.BaseEntities.BM_Query;
using LTN.CS.BaseEntities.BM;
using IBatisNet.Common.Logging;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMMAINASSEMBLYServiceImpl : IBMMAINASSEMBLYService
    {
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IBMMAINASSEMBLYDao mainassemblyDao { get; set; }

         [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_ASSEMBLY> ExecuteDB_QueryAll()
        {
            IList<BM_MAIN_ASSEMBLY> rs = null;
            try
            {
                rs = mainassemblyDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

         [Services(IsOutTransaction = true)]
        public IList<BM_MAIN_ASSEMBLY> SelectByAssemblyName(string assemblyName)
        {
            IList<BM_MAIN_ASSEMBLY> rs = null;
            try
            {
                rs = mainassemblyDao.SelectByAssemblyName(assemblyName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        [Services(IsOutTransaction = true)]
        public BM_MAIN_ASSEMBLY ExecuteDB_QueryById(int id)
        {
            BM_MAIN_ASSEMBLY rs = null;
            try
            {
                rs = mainassemblyDao.ExecuteQueryById(id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_InsertmainAssembly(BM_MAIN_ASSEMBLY mainAssembly)
        {
            object rs;
            try
            {
                rs = mainassemblyDao.ExecuteInsert(mainAssembly);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_UpdatemainAssembly(BM_MAIN_ASSEMBLY mainAssembly)
        {
            object rs;
            try
            {
                rs = mainassemblyDao.ExecuteUpdate(mainAssembly);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DeletemainAssembly(BM_MAIN_ASSEMBLY mainAssembly)
        {
            object rs;
            try
            {
                rs = mainassemblyDao.ExecuteDelete(mainAssembly);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public object ExecuteDB_Disabled(BM_MAIN_ASSEMBLY mainAssembly)
        {
            object rs;
            try
            {
                rs = mainassemblyDao.ExecuteDisabled(mainAssembly);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
