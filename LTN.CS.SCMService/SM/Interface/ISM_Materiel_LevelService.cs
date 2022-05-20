using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_Materiel_LevelService
    {
        IList<SM_Materiel_Level> ExecuteDB_QueryAll();

        IList<SM_Materiel_Level> ExecuteDB_QueryMaterielCode();
        IList<SM_Materiel_Level> ExecuteDB_QueryRepeatByMaterielName(string name);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertMateriel(SM_Materiel_Level Site);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateMateriel(SM_Materiel_Level Site);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_DeleteMateriel(SM_Materiel_Level Site);
    }
}
