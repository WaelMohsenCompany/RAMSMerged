namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwOEFElectronicInquiries
    {
		[DataMember]
        public int? OEFLaborOfficeId { get; set; }
		[DataMember]
        public int? OEFHijriYear { get; set; }
		[DataMember]
        public int OEFSequenceNumber { get; set; }
		[DataMember]
        public long? OEFEstablishmentId { get; set; }
		[DataMember]
        public long? OEFUserId { get; set; }
		[DataMember]
        public System.DateTime? OEFCreatedOn { get; set; }
		[DataMember]
        public long? UserIdNumber { get; set; }
		[DataMember]
        public int EstablishmentStatusId { get; set; }
		[DataMember]
        public string EstablishmentStatusName { get; set; }
    }
}
