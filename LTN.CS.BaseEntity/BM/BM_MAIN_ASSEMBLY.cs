using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;
using LTN.CS.Core.Helper;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_MAIN_ASSEMBLY : BaseEntity
    {
        public int IntId { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyShortName { get; set; }
        public BM_USER CreateEMPId { get; set; }
        public BM_USER ManageEMPId { get; set; }
        public EntityInt IsForbid { get; set; }
        public BM_USER CreateUser { get; set; }
        public BM_USER UpdateUser { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's IntId is {0}\n", IntId));
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's AssemblyName is {0}\n", AssemblyName));
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's AssemblyShortName is {0}\n", AssemblyShortName));
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's CreateEMPId is {0}\n", CreateEMPId.UserName));
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's ManageEMPId is {0}\n", ManageEMPId.UserName));
            str.Append(String.Format("this BM_MAIN_ASSEMBLY's IsForbid is {0}\n", IsForbid.EntityDes));
            return str.ToString();
        }
    }
}
