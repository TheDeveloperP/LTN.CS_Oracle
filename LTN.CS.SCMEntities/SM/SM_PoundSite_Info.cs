using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Base.Common;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_PoundSite_Info : BaseEntity
    {
        public int IntId { get; set; }
        public string PoundSiteNo { get; set; }
        public string PoundSiteName { get; set; }
        public string PoundSiteNickName { get; set; }

        //public int Level { get; set; }

        // public DataPondTypeObj DataPondType { get; set; } //磅点类别
        public PondTypeObj PoundType { get; set; } //磅点类别
        public string PoundSiteIP { get; set; }
        public string PoundSiteAddress { get; set; }
        public PondStatusObj PoundSiteStatus { get; set; } //磅点状态，1为启用，0为否，默认否
        public EntityInt IsSettle { get; set; }//是否结算.1为是，0为否，默认否
        public decimal? Accuracy { get; set; }//精确度
        public decimal? Range { get; set; }//量程
        public EntityInt IsRedOpen { get; set; }  // 是否锁定红外光栅  1 是  0 否
        public string DVRIP { get; set; }//硬盘录像机地址
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser        
        public string createTime { get; set; } //新增时间
        public string updateTime { get; set; }  //修改时间
        public string SiteType { get; set; }//磅点类型，Q为汽车磅，DT为动态铁水轨道衡，DW为动态物资，JW为静态物资
        //public DataTypeObj DataType { get; set; } //是否作废  0 正常 1 作废

        // public HK_Dvr_Info DVRIP { get; set; }
    }
}
