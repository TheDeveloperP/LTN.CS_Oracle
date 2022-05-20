using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Dao;
using LTN.CS.BaseEntities.BM;

namespace LTN.CS.Base.BusinessDao.BM.Interface
{
    public interface IBMDELIVERYHISTORYDao : IBaseDao<BM_DELIVERY_HISTORY>
    {
        /// <summary>
        /// 根据主表ID查询实体
        /// </summary>
        /// <param name="mainId"></param>
        /// <returns></returns>
        IList<BM_DELIVERY_HISTORY> QueryEntitiesByMainId(int mainId);

        /// <summary>
        /// 根据主表ID查询
        /// </summary>
        /// <param name="mainId"></param>
        /// <returns></returns>
        object QueryMaxIdByMainId(int mainId);
    }
}
