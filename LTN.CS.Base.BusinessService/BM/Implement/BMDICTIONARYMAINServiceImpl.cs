using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.BusinessService.BM.Interface;
using LTN.CS.Base.BusinessDao.BM.Interface;
using LTN.CS.Core.Common;
using IBatisNet.Common.Logging;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core.Attributes;

namespace LTN.CS.Base.BusinessService.BM.Implement
{
    public class BMDICTIONARYMAINServiceImpl : IBMDICTIONARYMAINService
    {
        public IBMDICTIONARYMAINDao dictionaryDao { get; set; }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_Insert(BM_DICTIONARY_MAIN obj)
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

        public object ExecuteDB_Update(BM_DICTIONARY_MAIN obj)
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

        public object ExecuteDB_Delete(BM_DICTIONARY_MAIN obj)
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

        public object ExecuteDB_DisableService(BM_DICTIONARY_MAIN obj)
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


        public IList<BM_DICTIONARY_MAIN> ExecuteDB_QueryAll()
        {
            IList<BM_DICTIONARY_MAIN> rs = null;
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
        public IList<BM_DICTIONARY_MAIN> ExecuteDB_QueryBySn(string dicSn)
        {
            IList<BM_DICTIONARY_MAIN> rs = null;
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
    }
}
