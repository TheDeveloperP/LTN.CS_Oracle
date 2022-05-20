using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using System.Collections;
using System.Data;

namespace LTN.CS.SCMService.SM.Interface
{
    public  interface ISM_CameraCarNOService
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IList<SM_CameraCarNO> ExecuteDB_QueryAll();


        /// <summary>
        /// 根据站点名称、车牌、时间查询SM_CameraCarNO
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        IList<SM_CameraCarNO> ExecuteDB_QuerySiteCar(Hashtable ht);


        /// <summary>
        /// 查询站点识别率
        /// </summary>
        /// <returns></returns>
        DataTable ExecuteDB_QueryCarRecognitionRateAll();

        /// <summary>
        /// 插入过磅的数据
        /// </summary>
        /// <param name="sm_cameracarno"></param>
        /// <returns></returns>
        IList<SM_CameraCarNO> ExecuteDB_InsertCameraSiteCar(SM_CameraCarNO sm_cameracarno);

    }
}
