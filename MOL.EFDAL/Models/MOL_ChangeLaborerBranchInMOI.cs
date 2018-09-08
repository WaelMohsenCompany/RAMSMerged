namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_ChangeLaborerBranchInMOI
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public long LaborerId { get; set; }
        [DataMember]
        public long EstablishmentId { get; set; }
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string UserIdNumber { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public string ClientIP { get; set; }
        [DataMember]
        public virtual MOL_Laborer MOL_Laborer { get; set; }
        [DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
        [DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
