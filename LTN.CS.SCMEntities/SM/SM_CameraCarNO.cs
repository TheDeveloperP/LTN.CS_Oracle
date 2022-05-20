using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public  class SM_CameraCarNO
    {
        public int IntId { get; set; }//业务主键
        public string SiteNo { get; set; }//站点编号
        public string Cameracarno { get; set; }//车牌识别车号
        public string Cardcarno { get; set; }//IC卡车号
        public string Matchtime { get; set; }//匹配时间
        public int Resulttype { get; set; }//匹配结果 1 成功，0 失败
        public string Createtime { get; set; }//新增时间
        public string Createuser { get; set; }//新增人
        public string SiteName { get; set; }//站点名称
    }
}
