using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace LTN.CS.Core.Common
{
    public interface IDeliveryService
    {
        DataTable ExecuteDB_QueryData(object args);
        object ExecuteDB_Confirm(object args);
        object ExecuteDB_SendBack(object args); 
    }
}
