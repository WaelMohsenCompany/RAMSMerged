namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_CEAInbox
    {
		[DataMember]
        public long Pk_CEAInbox { get; set; }
		[DataMember]
        public long Fk_ChangeEstablishmentActivityRequestId { get; set; }
		[DataMember]
        public long Fk_UserId { get; set; }
		[DataMember]
        public int? Fk_ChangeEstablishmentActivityUserActionId { get; set; }
		[DataMember]
        public System.DateTime DateCreated { get; set; }
		[DataMember]
        public System.DateTime DateModified { get; set; }
		[DataMember]
        public int? FK_RejectionReasonId { get; set; }
		[DataMember]
        public virtual Lookup_ChangeEstablishmentActivityRejectionReason Lookup_ChangeEstablishmentActivityRejectionReason { get; set; }
    }
}
