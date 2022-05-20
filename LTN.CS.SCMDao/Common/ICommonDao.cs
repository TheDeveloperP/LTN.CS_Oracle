using IBatisNet.Common.Pagination;
using LTN.CS.Core;
using LTN.CS.Core.Dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMDao.Common
{
    public interface ICommonDao: IBaseDao<BaseEntity>
    {
        /// <summary>
        /// 得到最大流水号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        int ExecuteGetMaxID(string statementName);


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        bool ExecuteExists(string statementName, object parameterObject);


        /// <summary>
        /// 执行添加
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        object ExecuteInsert(string statementName, object parameterObject);

        /// <summary>
        /// 执行添加，返回自动增长列
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回自动增长列</returns>
        int ExecuteInsertForInt(string statementName, object parameterObject);

        /// <summary>
        /// 执行修改
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回影响行数</returns>
        int ExecuteUpdate(string statementName, object parameterObject);



        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>返回影响行数</returns>
        int ExecuteDelete(string statementName, object parameterObject);


        /// <summary>
        /// 得到列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名称，对应xml中的Statement的id</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject);



        /// <summary>
        /// 得到列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名称，对应xml中的Statement的id</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        IList ExecuteQueryForList(string statementName, object parameterObject);

        /// <summary>
        /// 得到指定数量的记录数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject">参数</param>
        /// <param name="skipResults">跳过的记录数</param>
        /// <param name="maxResults">最大返回的记录数</param>
        /// <returns></returns>
        IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults);

            /// <summary>
            /// 得到分页的列表
            /// </summary>
            /// <param name="statementName">操作名称</param>
            /// <param name="parameterObject">参数</param>
            /// <param name="pageSize">每页记录数</param>
            /// <returns></returns>
        IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, int pageSize);


            /// <summary>
            /// 查询得到对象的一个实例
            /// </summary>
            /// <typeparam name="T">对象type</typeparam>
            /// <param name="statementName">操作名</param>
            /// <param name="parameterObject">参数</param>
            /// <returns></returns>
        T ExecuteQueryForObject<T>(string statementName, object parameterObject);

        /// <summary>
        /// 获取当前Command
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        IDbCommand GetDbCommand(string statementName, object paramObject);


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
        IDictionary<T, M> ExecuteQueryForDictionary<T, M>(string statementName, object paramObject, string keyField, string valueField);


            /**/
            /// <summary>
            /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
            /// </summary>
            /// <param name="statementName">语句ID</param>
            /// <param name="paramObject">语句所需要的参数</param>
            /// <param name="htOutPutParameter)">Output参数值哈希表</param>
            /// <returns>得到的DataTable</returns>
        DataTable ExecuteQueryForDataTable(string statementName, object paramObject, out Hashtable htOutPutParameter);

            /**/
            /// <summary>
            /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
            /// </summary>
            /// <param name="statementName">语句ID</param>
            /// <param name="paramObject">语句所需要的参数</param>
            /// <param name="htOutPutParameter)">Output参数值哈希表</param>
            /// <returns>得到的DataTable</returns>
        void ExecuteNoQuery(string statementName, object paramObject, out Hashtable htOutPutParameter);


    }
}
