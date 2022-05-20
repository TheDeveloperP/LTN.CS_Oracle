using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IRP_Print_RecordService
    {
        //打印记录表数据插入
        object ExecuteDB_InsertRP_Print_Record(RP_Materiel_PrintRecord printEntity);
        IList<RP_Materiel_PrintRecord> ExecuteDB_QueryByPrintInfo(Hashtable ht);
    }
}
