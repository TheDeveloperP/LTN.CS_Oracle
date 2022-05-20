using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Standard_Tare_Info
    {
        public int IntId { get; set; }//主键
        public string WagNo { get; set; }//车皮号
        public decimal TareWgt { get; set; }//标准皮重
        public string ImgURL { get; set; }//图片地址
        public string PondNo { get; set; }//磅点编号
        public string TareTime { get; set; }//过磅时间
        public int IsWeighing { get; set; }//是否过磅 0:不过磅1:过磅
        public int IsUse { get; set; }//是否使用 0:未修正1:人工修正
        public string CreateUser { get; set; }//新增人员
        public string CreateTime { get; set; }//新增时间
        public string UpdateUser { get; set; }//修改人员
        public string UpdateTime { get; set; }//修改时间
    }
}
