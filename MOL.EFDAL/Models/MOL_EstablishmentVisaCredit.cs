namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentVisaCredit
    {
        public MOL_EstablishmentVisaCredit()
        {
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public long EstablishmentID { get; set; }
        [DataMember]
        public int RequestedCredit { get; set; }
        [DataMember]
        public int ApprovedCredit { get; set; }
        [DataMember]
        public int UsedCredit { get; set; }
        [DataMember]
        public int? AvailableCredit { get; set; }
        [DataMember]
        public System.DateTime ExpirationDate { get; set; }
        [DataMember]
        public int? TransferedFromID { get; set; }
        [DataMember]
        public System.DateTime? TerminationDate { get; set; }
        [DataMember]
        public int? TerminationReasonID { get; set; }
        [DataMember]
        public bool IsTerminated { get; set; }
        [DataMember]
        public long CreatedBy { get; set; }
        [DataMember]
        public long? LastModifiedBy { get; set; }
        [DataMember]
        public System.DateTime CreateDate { get; set; }
        [DataMember]
        public System.DateTime? LastModifiedDate { get; set; }
        [DataMember]
        public string ReferenceData { get; set; }
        [DataMember]
        public System.Guid? GroupingRefrence { get; set; }
        [DataMember]
        public virtual Enum_EstablishmentVisaCreditTerminationReason Enum_EstablishmentVisaCreditTerminationReason { get; set; }
        [DataMember]
        public virtual Enum_EstablishmentVisaCreditType Enum_EstablishmentVisaCreditType { get; set; }
        [DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit1 { get; set; } = new List<MOL_EstablishmentVisaCredit>();

        [DataMember]
        public virtual MOL_EstablishmentVisaCredit MOL_EstablishmentVisaCredit2 { get; set; }
        [DataMember]
        public virtual MOL_User MOL_User { get; set; }
        [DataMember]
        public virtual MOL_User MOL_User1 { get; set; }
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs { get; set; } = new List<MOL_EstablishmentVisaCreditJobs>();
    }
}
