namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentSaudiCertificate
    {
		[DataMember]
        public long PK_SaudiCertificateId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public System.DateTime DateOfIssue { get; set; }
		[DataMember]
        public System.DateTime DateOfExpiry { get; set; }
		[DataMember]
        public string CertificateNumber { get; set; }
		[DataMember]
        public int? FK_DirectedToId { get; set; }
		[DataMember]
        public string EstablishmentName { get; set; }
		[DataMember]
        public string CommercialRecordNumber { get; set; }
		[DataMember]
        public string CommercialRecordSource { get; set; }
		[DataMember]
        public int? FK_PurposeId { get; set; }
		[DataMember]
        public string Purpose_Others { get; set; }
		[DataMember]
        public string EstablishmentState { get; set; }
		[DataMember]
        public string EstablishmentColor { get; set; }
		[DataMember]
        public short? FK_CertificateApprovalStatusId { get; set; }
		[DataMember]
        public string ProjectName { get; set; }
		[DataMember]
        public string FK_LaborOfficeId { get; set; }
		[DataMember]
        public System.DateTime? TimeStamp { get; set; }
		[DataMember]
        public virtual Enum_SaudiCertificateApprovalStatus Enum_SaudiCertificateApprovalStatus { get; set; }
		[DataMember]
        public virtual Lookup_SaudiCertificateDirectedTo Lookup_SaudiCertificateDirectedTo { get; set; }
		[DataMember]
        public virtual Lookup_SaudiCertificatePurpose Lookup_SaudiCertificatePurpose { get; set; }
    }
}
