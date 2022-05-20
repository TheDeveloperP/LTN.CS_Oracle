using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Base.BusinessDao.BM.Interface;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Common;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMDICTIONARYDETAILServiceImpl : IBMDICTIONARYDETAILService
    {
        public IBMDICTIONARYDETAILDao dictionaryDao { get; set; }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_Insert(BM_DICTIONARY_DETAIL obj)
        {
            object rs;
            try
            {
                rs = dictionaryDao.ExecuteInsert(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Update(BM_DICTIONARY_DETAIL obj)
        {
            object rs;
            try
            {
                rs = dictionaryDao.ExecuteUpdate(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_Delete(BM_DICTIONARY_DETAIL obj)
        {
            object rs;
            try
            {
                rs = dictionaryDao.ExecuteDelete(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_DisableService(BM_DICTIONARY_DETAIL obj)
        {
            object rs;
            try
            {
                rs = dictionaryDao.ExecuteDisabled(obj);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }


        public IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryAll()
        {
            IList<BM_DICTIONARY_DETAIL> rs = null;
            try
            {
                rs = dictionaryDao.ExecuteQueryAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryBySn(string dicSn)
        {
            IList<BM_DICTIONARY_DETAIL> rs = null;
            try
            {
                rs = dictionaryDao.ExecuteQueryBYSN(dicSn);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public int ExecuteDB_QueryCountBySn(BM_DICTIONARY_DETAIL dic)
        {
            int rs = -1;
            try
            {
                rs = dictionaryDao.ExecuteQueryCountBYSN(dic);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        [Services(IsOutTransaction = true)]
        public BM_DICTIONARY_DETAIL ExecuteDB_QueryByDesc(BM_DICTIONARY_DETAIL dicDesc)
        {
            BM_DICTIONARY_DETAIL rs = null;
            try
            {
                rs = dictionaryDao.ExecuteQueryBYDESC(dicDesc);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        [Services(IsOutTransaction = true)]
        public BM_DICTIONARY_DETAIL ExecuteDB_QueryAllByDesc(BM_DICTIONARY_DETAIL dicDesc)
        {
            BM_DICTIONARY_DETAIL rs = null;
            try
            {
                rs = dictionaryDao.ExecuteQueryAllBYDESC(dicDesc);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        [Services(IsOutTransaction = true)]
        public IList<BM_DICTIONARY_DETAIL> ExecuteDB_QueryByDICDESC(BM_DICTIONARY_DETAIL dicDesc)
        {
            IList<BM_DICTIONARY_DETAIL> rs = null;
            try
            {
                rs = dictionaryDao.ExecuteQueryBYDICDESC(dicDesc);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
