namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwCEAInbox
    {
		[DataMember]
        public string RequestNumber { get; set; }
		[DataMember]
        public int FK_LaborOfficeId { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public string EstablishmentName { get; set; }
		[DataMember]
        public System.DateTime DateCreated { get; set; }
		[DataMember]
        public System.DateTime DateModified { get; set; }
		[DataMember]
        public long Fk_CreatedBy { get; set; }
		[DataMember]
        public string EmployeeFullName { get; set; }
		[DataMember]
        public string CreatedByFullName { get; set; }
		[DataMember]
        public int? User_Type_Id { get; set; }
		[DataMember]
        public System.DateTime DateAssigned { get; set; }
		[DataMember]
        public int? RequestActionId { get; set; }
		[DataMember]
        public string RequestStatus { get; set; }
		[DataMember]
        public int RequestStatusId { get; set; }
		[DataMember]
        public string RequestAction { get; set; }
		[DataMember]
        public long Pk_ChangeEstablishmentActivityRequestId { get; set; }
		[DataMember]
        public long Pk_CEAInbox { get; set; }
		[DataMember]
        public long Fk_UserId { get; set; }
		[DataMember]
        public int NewEconomicActivityId { get; set; }
		[DataMember]
        public string NewEconomicActivity { get; set; }
		[DataMember]
        public int? OldMainEconomicActivityId { get; set; }
		[DataMember]
        public string OldMainEconomicActivity { get; set; }
		[DataMember]
        public int? OldSubEconomicActivityId { get; set; }
		[DataMember]
        public string OldSubEconomicActivity { get; set; }
		[DataMember]
        public int? NewMainEconomicActivityId { get; set; }
		[DataMember]
        public string NewMainEconomicActivity { get; set; }
		[DataMember]
        public int? NewSubEconomicActivityId { get; set; }
		[DataMember]
        public string NewSubEconomicActivity { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public int? InboxRejectionReasonId { get; set; }
		[DataMember]
        public string InboxRejectionReason { get; set; }
		[DataMember]
        public int? RequestRejectionReasonId { get; set; }
		[DataMember]
        public string RequestRejectionReason { get; set; }
		[DataMember]
        public string ChangeReason { get; set; }
		[DataMember]
        public int ChangeReasonId { get; set; }
		[DataMember]
        public string CommercialRecordNumber { get; set; }
		[DataMember]
        public System.DateTime? CommercialRecordReleaseDate { get; set; }
		[DataMember]
        public System.DateTime? CommercialRecordEndDate { get; set; }
		[DataMember]
        public string CommercialRecordSource { get; set; }
		[DataMember]
        public string CommercialRecordCancellationNo { get; set; }
		[DataMember]
        public System.DateTime? CommercialRecordCancellationDt { get; set; }
		[DataMember]
        public string EconomicActivityText { get; set; }
		[DataMember]
        public System.DateTime? CommercialRecordConfirmationDate { get; set; }
    }
}
