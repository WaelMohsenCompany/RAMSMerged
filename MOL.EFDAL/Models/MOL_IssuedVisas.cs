namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_IssuedVisas
    {
		[DataMember]
        public long PK_VisaID { get; set; }
		[DataMember]
        public long FK_VisaIssueRequestID { get; set; }
		[DataMember]
        public long BorderNumber { get; set; }
		[DataMember]
        public int? Fk_JobID { get; set; }
		[DataMember]
        public int? FK_NationalityID { get; set; }
		[DataMember]
        public int? FK_OriginID { get; set; }
		[DataMember]
        public int? FK_ReligionID { get; set; }
		[DataMember]
        public int? FK_GenderID { get; set; }
		[DataMember]
        public short? VisaStatus { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public long? CreditID { get; set; }
		[DataMember]
        public int? CreditType { get; set; }
        [DataMember]
        public bool? IsRefunded { get; set; }
        [DataMember]
        public virtual MOL_VisaIssueRequests MOL_VisaIssueRequests { get; set; }
    }
}
