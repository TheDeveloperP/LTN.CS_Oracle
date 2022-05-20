using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.Common;
using LTN.CS.BaseEntities.BM;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.SCMEntities.SM
{
  public  class SM_Site_Info:BaseEntity
    {

        public int IntId { get; set; }
        public string siteId { get; set; }
        public string siteName { get; set; }
        // public string siteType { get; set; }
        //public DataPondTypeObj siteType { get; set; }//坐席类别
        public PondTypeObj siteType { get; set; }//坐席类别
        public string siteLocation { get; set; }
        public string siteIp1 { get; set; }
        public string siteIp2 { get; set; }       
        public int siteLevel { get; set; }//坐席优先级
        //public string isAuto { get; set; }
        public EntityInt IsAutoWeigh { get; set; }  // 是否自动过磅  1 是  0 否
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser
                                                // new public string  createTime { get; set; } //新增时间
        public string createTime { get; set; } //新增时间
        public string  updateTime { get; set; }  //修改时间








    }
}
