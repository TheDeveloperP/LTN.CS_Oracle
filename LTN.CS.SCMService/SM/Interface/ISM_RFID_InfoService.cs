using LTN.CS.SCMEntities.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.SM.Interface
{
    public interface ISM_RFID_InfoService
    {
        /// <summary>
        /// 查询RFID数据
        /// </summary>
        /// <returns></returns>
        IList<SM_RFID_Info> ExecuteDB_QueryAll();
        IList<SM_RFID_Info> ExecuteDB_QueryCarNo(string CarNo);
        IList<SM_RFID_Info> ExecuteDB_QueryRFID(string RFID);

        IList<SM_RFID_Info> ExecuteDB_QueryCarNameFromRfid(string rfidCarNo);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InsertRFIDInfo(SM_RFID_Info Info);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_UpdateRFIDInfo(SM_RFID_Info Info);
        /// <summary>
        /// 作废RFID
        /// </summary>
        /// <returns></returns>
        object ExecuteDB_InvalidRFIDInfo(SM_RFID_Info Info);
    }
}
