using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.Exceptions;
using IBatisNet.Common.Pagination;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.Common;
using System.Collections;
using IBatisNet.DataMapper.Scope;
using System.Xml;
using IBatisNet.Common.Utilities;

namespace LTN.CS.Core.Common
{
    /// <summary>
    /// 基于IBatisNet的数据访问基类 
    /// </summary>
    public class BaseSqlMapDaoImpl : IBaseSqlMapDao
    {

        /// <summary>
        /// IsqlMapper实例
        /// </summary>
        /// <returns></returns>
        public ISqlMapper sqlMap { get; set; }
        public string Key { get; set; }
        #region 构造
        /// <summary>
        /// 1.构造函数利用配置的连接字符串生成相应的DataSource
        /// 2.生成SQLMap 讲DataSource 复制给SQLMap
        /// </summary>
        /// <param name="key"></param>
        public BaseSqlMapDaoImpl(string key)
        {
            Key = key;
            SqlMapElements elements = SqlMapElementsFactory.CreateInstance(key);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMap = builder.Build(elements.Document, elements.DataSourceForKey, false, elements.Properties);
        }

        #endregion


        /// <summary>
        /// 得到最大流水号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public int ExecuteGetMaxID(string statementName)
        {
            try
            {
                object obj = sqlMap.QueryForObject(statementName, null);
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public bool ExecuteExists(string statementName, object parameterObject)
        {
            try
            {
                object obj = sqlMap.QueryForObject(statementName, parameterObject);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (obj == null))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        /// <summary>
        /// 执行添加
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        public object ExecuteInsert(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.Insert(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for insert.  Cause: {1}", statementName, e.Message), e);
            }
        }
        /// <summary>
        /// 执行添加，返回自动增长列
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回自动增长列</returns>
        public int ExecuteInsertForInt(string statementName, object parameterObject)
        {
            try
            {
                object obj = sqlMap.Insert(statementName, parameterObject);
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for insert.  Cause: {1}", statementName, e.Message), e);
            }
        }
        /// <summary>
        /// 执行修改
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回影响行数</returns>
        public int ExecuteUpdate(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for update.  Cause: {1}", statementName, e.Message), e);
            }
        }


        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回影响行数</returns>
        public int ExecuteDelete(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.Delete(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for delete.  Cause: {1}", statementName, e.Message), e);
            }
        }


        /// <summary>
        /// 得到列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名称，对应xml中的Statement的id</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        public IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for list.  Cause: {1}", statementName, e.Message), e);
            }
        }


        /// <summary>
        /// 得到列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名称，对应xml中的Statement的id</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        public IList ExecuteQueryForList(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.QueryForList(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for list.  Cause: {1}", statementName, e.Message), e);
            }
        }

        /// <summary>
        /// 得到指定数量的记录数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject">参数</param>
        /// <param name="skipResults">跳过的记录数</param>
        /// <param name="maxResults">最大返回的记录数</param>
        /// <returns></returns>
        public IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for list.  Cause: {1}", statementName, e.Message), e);
            }
        }

        /// <summary>
        /// 得到分页的列表
        /// </summary>
        /// <param name="statementName">操作名称</param>
        /// <param name="parameterObject">参数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        [Obsolete("This method will be remove in future version.", false)]
        public IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, int pageSize)
        {
            try
            {
                return sqlMap.QueryForPaginatedList(statementName, parameterObject, pageSize);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for paginated list.  Cause: {1}", statementName, e.Message), e);
            }
        }

        /// <summary>
        /// 查询得到对象的一个实例
        /// </summary>
        /// <typeparam name="T">对象type</typeparam>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        public T ExecuteQueryForObject<T>(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.QueryForObject<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException(String.Format("Error executing query '{0}' for object.  Cause: {1}", statementName, e.Message), e);
            }
        }
        /// <summary>
        /// 获取当前Command
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public IDbCommand GetDbCommand(string statementName, object paramObject)
        {
            IStatement statement = sqlMap.GetMappedStatement(statementName).Statement;

            IMappedStatement mapStatement = sqlMap.GetMappedStatement(statementName);

            ISqlMapSession session = new SqlMapSession(sqlMap);

            if (sqlMap.LocalSession != null)
            {
                session = sqlMap.LocalSession;
            }
            else
            {
                session = sqlMap.OpenConnection();
            }

            RequestScope request = statement.Sql.GetRequestScope(mapStatement, paramObject, session);
           

            mapStatement.PreparedCommand.Create(request, session as ISqlMapSession, statement, paramObject);
            IDbCommand cmd = session.CreateCommand(CommandType.Text);
            cmd.CommandText = request.IDbCommand.CommandText;
            
            IList<IDataParameter> parammeters = new List<IDataParameter>();
            foreach(IDataParameter param in request.IDbCommand.Parameters)
            {
                parammeters.Add(param);
            }
            request.IDbCommand.Parameters.Clear();
            foreach(IDataParameter param in parammeters)
            {
                cmd.Parameters.Add(param);
            }
            return cmd;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">key Type</typeparam>
        /// <typeparam name="M">value Type</typeparam>
        /// <param name="statementName">select ID</param>
        /// <param name="paramObject">查询条件</param>
        /// <param name="keyField">key的字段名</param>
        /// <param name="valueField">value的字段名</param>
        /// <returns></returns>
        public IDictionary<T, M> ExecuteQueryForDictionary<T, M>(string statementName, object paramObject,string keyField,string valueField)
        {
            return sqlMap.QueryForDictionary<T, M>(statementName, paramObject,keyField,valueField);
        }

        /**/
        /// <summary>
        /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
        /// </summary>
        /// <param name="statementName">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <param name="htOutPutParameter)">Output参数值哈希表</param>
        /// <returns>得到的DataTable</returns>
        public DataTable ExecuteQueryForDataTable(string statementName, object paramObject, out Hashtable htOutPutParameter)
        {
            DataSet ds = new DataSet();
            htOutPutParameter = new Hashtable();
            bool isSessionLocal = false;
            IDalSession session = sqlMap.LocalSession;
            if (session == null)
            {
                session = new SqlMapSession(sqlMap);
                session.OpenConnection();
                isSessionLocal = true;
            }

            IDbCommand cmd = GetDbCommand(statementName, paramObject);

            try
            {
                cmd.Connection = session.Connection;
                IDbDataAdapter adapter = session.CreateDataAdapter(cmd);
                adapter.Fill(ds);
            }
            finally
            {
                if (isSessionLocal)
                {
                    session.CloseConnection();
                }
            }

            foreach (IDataParameter parameter in cmd.Parameters)
            {
                if (parameter.Direction == ParameterDirection.Output)
                {
                    htOutPutParameter[parameter.ParameterName] = parameter.Value;
                }
            }

            return ds.Tables[0];

        }

        /**/
        /// <summary>
        /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
        /// </summary>
        /// <param name="statementName">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <param name="htOutPutParameter)">Output参数值哈希表</param>
        /// <returns>得到的DataTable</returns>
        public void ExecuteNoQuery(string statementName, object paramObject, out Hashtable htOutPutParameter)
        {
            htOutPutParameter = new Hashtable();
            bool isSessionLocal = false;
            IDalSession session = sqlMap.LocalSession;
            if (session == null)
            {
                session = new SqlMapSession(sqlMap);
                session.OpenConnection();
                isSessionLocal = true;
            }

            using (IDbCommand cmd = GetDbCommand(statementName, paramObject))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (isSessionLocal)
                    {
                        session.CloseConnection();
                    }
                }
                foreach (IDataParameter parameter in cmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output)
                    {
                        htOutPutParameter[parameter.ParameterName] = parameter.Value;
                    }
                }
            }

        }

    }
}
