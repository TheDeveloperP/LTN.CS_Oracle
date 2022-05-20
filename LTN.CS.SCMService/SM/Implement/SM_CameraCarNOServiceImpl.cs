using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Attributes;
using LTN.CS.Core.Common;
using System.Data;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_CameraCarNOServiceImpl : ISM_CameraCarNOService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        [Services(IsOutTransaction = true)]
        public IList<SM_CameraCarNO> ExecuteDB_QueryAll()
        {
            IList<SM_CameraCarNO> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_CameraCarNO>("SelectSM_CameraCarNOAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<SM_CameraCarNO> ExecuteDB_QuerySiteCar(Hashtable ht)
        {
            IList<SM_CameraCarNO> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_CameraCarNO>("SelectSM_CameraSiteCar", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public DataTable ExecuteDB_QueryCarRecognitionRateAll()
        {
            DataTable rs = null;
            try
            {
                Hashtable ht = new Hashtable();
                rs = CommonDao.ExecuteQueryForDataTable("CarRecognitionRateAll",null,out ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<SM_CameraCarNO> ExecuteDB_InsertCameraSiteCar(SM_CameraCarNO sm_cameracarno)
        {
            IList<SM_CameraCarNO> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<SM_CameraCarNO>("InsertSM_CameraSiteCar", sm_cameracarno);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
