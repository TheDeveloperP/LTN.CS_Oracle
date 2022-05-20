using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Department_LevelTwo_Info:BaseEntity
    {
        public int IntId { get; set; }//业务主键
        public int MainId { get; set; }//一级部门主键
        public string TwoDeptCode { get; set; }//二级部门编码
        public string TwoDeptName { get; set; }//二级部门名称
        public string TwoDeptShortName { get; set; }//二级部门简称
        public string CreateUserName{ get; set; }
        public string UpdateUserName { get; set; }
        public string CREATETIME { get; set; }//创建时间
        public string UPDATETIME { get; set; }//修改时间


    }
}
