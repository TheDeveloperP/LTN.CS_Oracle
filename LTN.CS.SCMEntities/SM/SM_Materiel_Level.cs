using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Materiel_Level
    {
        public int IntId { get; set; }
        public string MaterielCode { get; set; }
        public string MaterielName { get; set; }
        public string MaterielSpec { get; set; }
        public string MaterielModel { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

    }
}
