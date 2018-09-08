namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Laborer_MOI_Audit
    {
        [DataMember]
        public decimal MOLLaborerMOIAuditId { get; set; }
        [DataMember]
        public long UserIdNumber { get; set; }
        [DataMember]
        public long FK_LaborerId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
    }
}
