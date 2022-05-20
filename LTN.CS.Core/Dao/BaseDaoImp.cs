using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core.Common;

namespace LTN.CS.Core.Dao
{
    public abstract class BaseDaoImp<T>
        where T : BaseEntity
    {
        public BaseSqlMapDaoImpl basedao { set; get; }
        public BaseSqlMapDaoFactory basedaoFactory { set; get; }
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        public virtual object ExecuteGetMaxID()
        {
            return -1;
        }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteExists(object parameterObject)
        {
            return false;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteInsert(object parameterObject)
        {
            return null;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteUpdate(object parameterObject)
        {
            return 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteDelete(object parameterObject)
        {
            return 0;
        }
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual IList<T> ExecuteQueryForList<T>(object parameterObject)
        {
            return null;
        }
        /// <summary>
        /// 间隔查询集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterObject"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public virtual IList<T> ExecuteQueryForList<T>(object parameterObject, int skipResults, int maxResults)
        {
            return null;
        }
        /// <summary>
        /// 查询翻页集合
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual IBatisNet.Common.Pagination.IPaginatedList ExecuteQueryForPaginatedList(object parameterObject, int pageSize)
        {
            return null;
        }
        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual T ExecuteQueryForObject<T>(object parameterObject)
        {
            return default(T);
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteDisabled(object parameterObject)
        {
            return 0;
        }

        /// <summary>
        /// 限制
        /// </summary>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual object ExecuteLimited(object parameterObject)
        {
            return 0;
        }

        public virtual DateTime ExecuteDBTime()
        {
            return basedao.ExecuteQueryForObject<DateTime>("GetDBDateTime", null);
        }
    }
}
