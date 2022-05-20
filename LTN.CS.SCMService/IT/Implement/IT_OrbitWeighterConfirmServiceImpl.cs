using LTN.CS.SCMService.IT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.IT;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;

namespace LTN.CS.SCMService.IT.Implement
{
    public class IT_OrbitWeighterConfirmServiceImpl : IIT_OrbitWeighterConfirmService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<IT_OrbitweighterConfirm> ExecuteDB_QueryByCalibrateAndTime(Hashtable ht)
        {
            IList<IT_OrbitweighterConfirm> rs;
            try
            {                
                rs = CommonDao.ExecuteQueryForList<IT_OrbitweighterConfirm>("SelectIT_OrbitWeighterConfirmByCondition", ht);
            }catch(Exception ex){
                Console.WriteLine("查询数据发生异常");
                log.Error(ex.Message);
                rs = null;
            }

            return rs;
        }

    }
}
