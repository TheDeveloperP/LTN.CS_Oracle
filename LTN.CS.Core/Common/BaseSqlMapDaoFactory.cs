using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;

namespace LTN.CS.Core.Common
{
    /// <summary>
    /// 基础Dao生成工厂
    /// </summary>
    public class BaseSqlMapDaoFactory
    {
        public readonly string Key;
        private ConcurrentQueue<BaseSqlMapDaoImpl> SendQueue;
        private int SumConn;
        private readonly int MaxConn;
        public BaseSqlMapDaoFactory(string key,int maxConn,int initConn)
        {
            Key = key;
            MaxConn = maxConn;
            Init(initConn);
        }
        private void Init(int initConn)
        {
            if (BaseDaoContainer.data.ContainsKey(Key))
            {
                SendQueue = BaseDaoContainer.data[Key];
            }
            else
            {
                SendQueue = new ConcurrentQueue<BaseSqlMapDaoImpl>();
                BaseDaoContainer.data[Key] = SendQueue;
            }
            for (int i = 0; i < initConn; i++)
            {
                BaseSqlMapDaoImpl dao = new BaseSqlMapDaoImpl(Key);
                SendQueue.Enqueue(dao);
                Interlocked.Increment(ref SumConn);
            }
        }
        public BaseSqlMapDaoImpl GetBaseSqlMapDaoImpl()
        {
            BaseSqlMapDaoImpl rs = null;
            //int Count = 0;
            while (true)
            {
                if (SendQueue.Count > 0)
                {
                    bool ders = SendQueue.TryDequeue(out rs);
                    if (ders)
                    {
                        //Console.WriteLine("DaoCount" + Count);
                        break;
                    }
                    Thread.Sleep(5);
                }
                else
                {
                    if (SumConn >= MaxConn)
                    {
                        bool ders = SendQueue.TryDequeue(out rs);
                        if (ders)
                        {
                            //Console.WriteLine("DaoCount" + Count);
                            break;
                        }
                        Thread.Sleep(5);
                    }
                    else
                    {
                        rs = new BaseSqlMapDaoImpl(Key);
                        Interlocked.Increment(ref SumConn);
                        //Console.WriteLine("DaoCount" + Count);
                        break;
                    }
                }
                //Count++;
            }
            
            return rs;
        }
    }
}
