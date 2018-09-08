namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_ChangeEstablishmentActivityRequest
    {
		[DataMember]
        public long Pk_ChangeEstablishmentActivityRequestId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public string RequestNumber { get; set; }
		[DataMember]
        public int FK_OldMainEconomicActivityId { get; set; }
		[DataMember]
        public int? Fk_OldSubEconomicActivityId { get; set; }
		[DataMember]
        public int Fk_ChangeEstablishmentActivityRequestStatusId { get; set; }
		[DataMember]
        public int? FK_NewMainEconomicActivityId { get; set; }
		[DataMember]
        public int? FK_NewSubEconomicActivityId { get; set; }
		[DataMember]
        public int FK_NewEconomicActivityId { get; set; }
		[DataMember]
        public int Fk_ChangeEstablishmentActivityReasonId { get; set; }
		[DataMember]
        public long Fk_CreatedBy { get; set; }
		[DataMember]
        public int ApprovalsRequired { get; set; }
		[DataMember]
        public System.DateTime DateCreated { get; set; }
		[DataMember]
        public System.DateTime DateModified { get; set; }
		[DataMember]
        public int? Fk_RejectionReasonId { get; set; }
		[DataMember]
        public long Fk_ModifiedBy { get; set; }
		[DataMember]
        public virtual Enum_ChangeEstablishmentActivityRequestStatus Enum_ChangeEstablishmentActivityRequestStatus { get; set; }
		[DataMember]
        public virtual Lookup_ChangeEstablishmentActivityReason Lookup_ChangeEstablishmentActivityReason { get; set; }
		[DataMember]
        public virtual Lookup_ChangeEstablishmentActivityRejectionReason Lookup_ChangeEstablishmentActivityRejectionReason { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
