using System;
using System.Collections.Generic;
using System.Linq;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Base.BusinessDao.BM.Interface;

namespace LTN.CS.Base.BusinessDao.BM.Implement
{
    public class BMMAINASSEMBLYDaoImpl : BaseDaoImp<BM_MAIN_ASSEMBLY>, IBMMAINASSEMBLYDao
    {
        public IList<BM_MAIN_ASSEMBLY> ExecuteQueryAll()
        {
            return basedao.ExecuteQueryForList<BM_MAIN_ASSEMBLY>("SelectAllBMMAINASSEMBLY", null);
        }
        public BM_MAIN_ASSEMBLY ExecuteQueryById(int id)
        {
            return basedao.ExecuteQueryForObject<BM_MAIN_ASSEMBLY>("SelectBYIDBMMAINASSEMBLY", id);
        }
        public override object ExecuteInsert(object parameterObject)
        {
            return basedao.ExecuteInsert("InsertBMMAINASSEMBLY", parameterObject);
        }
        public override object ExecuteUpdate(object parameterObject)
        {
            return basedao.ExecuteUpdate("UpdateBMMAINASSEMBLY", parameterObject);
        }
        public override object ExecuteDelete(object parameterObject)
        {
            return basedao.ExecuteDelete("DeleteBMMAINASSEMBLY", parameterObject);
        }

        public IList<BM_MAIN_ASSEMBLY> SelectByAssemblyName(string assemblyName)
        {
            return basedao.ExecuteQueryForList<BM_MAIN_ASSEMBLY>("SelectByASSEMBLYNAME", assemblyName);
        }
        public override object ExecuteDisabled(object parameterObject)
        {
            return basedao.ExecuteUpdate("DisabledMAINASSEMBLY", parameterObject);
        }
    }
}
