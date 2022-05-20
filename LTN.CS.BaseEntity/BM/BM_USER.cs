using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    /// <summary>
    /// 通讯用户实体
    /// </summary>
    public class BM_USER : BaseEntity
    {
        public int IntId { get; set; }
        public string UserName { get; set; }
        public string UserNickName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public EntityInt IsForbid { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_USER's IntId is {0}\r\n", IntId));
            str.Append(String.Format("this BM_USER's UserName is {0}\r\n", UserName));
            str.Append(String.Format("this BM_USER's UserName is {0}\r\n", UserNickName));
            str.Append(String.Format("this BM_USER's Password is {0}\r\n", Password));
            str.Append(String.Format("this BM_USER's MobileNo is {0}\r\n", MobileNo));
            str.Append(String.Format("this BM_USER's Email is {0}\r\n", Email));
            return str.ToString(); 
        }
    }
}
