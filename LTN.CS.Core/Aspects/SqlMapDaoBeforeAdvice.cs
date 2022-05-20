using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using LTN.CS.Core.Dao;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;
using System.Data;
using IBatisNet.Common.Logging;

namespace LTN.CS.Core.Aspects
{
    public class SqlMapDaoBeforeAdvice : IMethodBeforeAdvice
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        /// <summary>
        /// services切面方法：
        /// 1.注入BaseDAO
        /// 2.启动事务
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <param name="target"></param>
        public void Before(MethodInfo method, object[] args, object target)
        {
            PropertyInfo[] fields = target.GetType().GetProperties();
            Dictionary<BaseSqlMapDaoFactory, BaseSqlMapDaoImpl> factoryTemp = new Dictionary<BaseSqlMapDaoFactory, BaseSqlMapDaoImpl>();
            foreach (PropertyInfo fi in fields)
            {
                object rs = fi.GetValue(target, null);
                try
                {
                    Type rsType = rs.GetType();
                    PropertyInfo basedaorsInfo = rsType.GetProperty("basedao", typeof(BaseSqlMapDaoImpl));
                    PropertyInfo basedaoFactoryrsInfo = rsType.GetProperty("basedaoFactory", typeof(BaseSqlMapDaoFactory));
                    object att = Attribute.GetCustomAttribute(method, typeof(ServicesAttribute));
                    ServicesAttribute classAttribute = att==null ? new ServicesAttribute(){ IsOutTransaction=false} :(ServicesAttribute)att;
                    if (basedaoFactoryrsInfo != null)
                    {
                        BaseSqlMapDaoFactory basedaoFactory = basedaoFactoryrsInfo.GetValue(rs, null) as BaseSqlMapDaoFactory;
                        if (basedaoFactory != null)
                        {
                            BaseSqlMapDaoImpl dao = null;
                            if (factoryTemp.ContainsKey(basedaoFactory))
                            {
                                dao = factoryTemp[basedaoFactory];
                                basedaorsInfo.SetValue(rs, dao, null);
                            }
                            else
                            {
                                dao = basedaoFactory.GetBaseSqlMapDaoImpl();
                                factoryTemp[basedaoFactory] = dao;
                                basedaorsInfo.SetValue(rs, dao, null);
                                if (!classAttribute.IsOutTransaction)
                                {
                                    dao.sqlMap.BeginTransaction(Convert.ToInt32(classAttribute.IsoLevel) == 0 || classAttribute.IsoLevel == IsolationLevel.Unspecified ? IsolationLevel.ReadCommitted : classAttribute.IsoLevel);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    continue;
                }
            }
        }
    }
}
