using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.BaseEntities.BM
{
    public class BM_MAIN_GROUP_SERVICE_MENU
    {
        public int IntId { get; set; }
        public int GroupId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceDes { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNo { get; set; }
        public int Index { get; set; }
        public int MainAssemblyId { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyShortName { get; set; }
        public string Glyph { get; set; }
        public string LargeGlyph { get; set; }

    }
}
