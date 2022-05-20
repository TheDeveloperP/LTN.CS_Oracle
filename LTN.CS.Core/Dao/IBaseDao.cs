using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Pagination;

namespace LTN.CS.Core.Dao
{
    public interface IBaseDao<T>
        where T : BaseEntity
    {
        object ExecuteGetMaxID();
        object ExecuteExists(object parameterObject);
        object ExecuteInsert(object parameterObject);
        object ExecuteUpdate(object parameterObject);
        object ExecuteDelete(object parameterObject);
        object ExecuteDisabled(object parameterObject);
        IList<T> ExecuteQueryForList<T>(object parameterObject);
        IList<T> ExecuteQueryForList<T>(object parameterObject, int skipResults, int maxResults);
        IPaginatedList ExecuteQueryForPaginatedList(object parameterObject, int pageSize);
        T ExecuteQueryForObject<T>(object parameterObject);
        DateTime ExecuteDBTime();
    }
}
