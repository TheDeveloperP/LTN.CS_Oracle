using System;
using LTN.CS.Core;
using LTN.CS.Base.Common;
using LTN.CS.Core.Helper;
using LTN.CS.BaseEntities.BM;
using System.Runtime.Serialization;

namespace LTN.CS.Base.ServiceInterface.Entity
{
    [DataContract]
    [KnownType(typeof(SiteTypeObj))]
    [KnownType(typeof(PondStatusObj))]
    [KnownType(typeof(EntityInt))]
    public class DM_PondSite_Info_WCF : BaseEntity
    {
        [DataMember]
        public int IntId { get; set; }
        [DataMember]
        public string LESNo { get; set; }
        [DataMember]
        public string PondSiteNo { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public string PondSiteNickName { get; set; }
        [DataMember]
        public SiteTypeObj PondSiteType { get; set; }
        [DataMember]
        public string PondSiteName { get; set; }
        [DataMember]
        public string PondSiteIP { get; set; }
        [DataMember]
        public string PondSiteAddress { get; set; }
        [DataMember]
        public PondStatusObj PondSiteStatus { get; set; }
        [DataMember]
        public int DVRId { get; set; }
        [DataMember]
        public string DVRIP { get; set; }
        [DataMember]
        public decimal Range { get; set; }
        [DataMember]
        public decimal Accuracy { get; set; }
        [DataMember]
        public EntityInt IsBusinessScale { get; set; }
        [DataMember]
        public EntityInt UsingGrating { get; set; }
        [DataMember(IsRequired = false)]
        public EntityInt IsUpload { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime PondSiteStatusDate { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER CreateUser { get; set; }
        [DataMember(IsRequired = false)]
        public BM_USER UpdateUser { get; set; }
        [DataMember]
        public string PondSiteIPTwo { get; set; }
        [DataMember]
        public string DVRIP2 { get; set; }
        [DataMember]
        public string DVRIP3 { get; set; }
        [DataMember]
        public int DVRId3 { get; set; }
        [DataMember]
        public string DVRIP4 { get; set; }
        [DataMember]
        public int DVRId4 { get; set; }
    }
}
