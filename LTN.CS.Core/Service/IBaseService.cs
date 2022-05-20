using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Pagination;

namespace LTN.CS.Core.Service
{
    public interface IBaseService
    {
        int ExecuteGetMaxID(string statementName);
        bool ExecuteExists(string statementName, object parameterObject);
        object ExecuteInsert(string statementName, object parameterObject);
        int ExecuteInsertForInt(string statementName, object parameterObject);
        int ExecuteUpdate(string statementName, object parameterObject);
        int ExecuteDelete(string statementName, object parameterObject);
        IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject);
        IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults);
        IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, int pageSize);
        T ExecuteQueryForObject<T>(string statementName, object parameterObject);
    }
}
