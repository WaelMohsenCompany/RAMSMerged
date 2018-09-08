namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class IstikdamRequestRejectionReason
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public int? FK_IstikdamBalanceRequestId { get; set; }
		[DataMember]
        public int? FK_RejectionReasonId { get; set; }
    }
}
