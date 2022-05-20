using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using LTN.CS.Core.Dao;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;
using IBatisNet.Common.Logging;
namespace LTN.CS.Core.Aspects
{
    public class SqlMapDaoAfterAdvice : IAfterReturningAdvice
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            bool isSuccess;
            if (returnValue == null || returnValue.GetType().Equals(typeof(CustomDBError)) || returnValue.GetType().IsSubclassOf(typeof(CustomDBError)))
                isSuccess = false;
            else
                isSuccess = true;
            PropertyInfo[] fields = target.GetType().GetProperties();
            Dictionary<BaseSqlMapDaoImpl, BaseSqlMapDaoFactory> factoryTemp = new Dictionary<BaseSqlMapDaoImpl, BaseSqlMapDaoFactory>();

            foreach (PropertyInfo fi in fields)
            {
                object rs = fi.GetValue(target, null);

                Type rsType = rs.GetType();
                PropertyInfo rsInfo = rsType.GetProperty("basedao", typeof(BaseSqlMapDaoImpl));
                PropertyInfo basedaoFactoryrsInfo = rsType.GetProperty("basedaoFactory", typeof(BaseSqlMapDaoFactory));
                if (basedaoFactoryrsInfo != null)
                {
                    BaseSqlMapDaoImpl basedao = rsInfo.GetValue(rs, null) as BaseSqlMapDaoImpl;
                    BaseSqlMapDaoFactory basedaoFactory = basedaoFactoryrsInfo.GetValue(rs, null) as BaseSqlMapDaoFactory;
                    try
                    {
                        object att = Attribute.GetCustomAttribute(method, typeof(ServicesAttribute));
                        ServicesAttribute classAttribute = att == null ? new ServicesAttribute() { IsOutTransaction = false } : (ServicesAttribute)att;
                        if (factoryTemp.ContainsKey(basedao))
                        {
                            continue;
                        }
                        else
                        {
                            factoryTemp[basedao] = basedaoFactory;
                            if (!classAttribute.IsOutTransaction)
                            {
                                if (isSuccess)
                                {
                                    basedao.sqlMap.CommitTransaction();
                                }
                                else
                                {
                                    basedao.sqlMap.RollBackTransaction();
                                }
                            }
                            if (BaseDaoContainer.data.ContainsKey(basedaoFactory.Key))
                            {
                                BaseDaoContainer.data[basedaoFactory.Key].Enqueue(basedao);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (BaseDaoContainer.data.ContainsKey(basedaoFactory.Key))
                        {
                            BaseDaoContainer.data[basedaoFactory.Key].Enqueue(basedao);
                        }
                        log.Error(ex.Message);
                        continue;
                    }
                }

            }
        }
    }
}
