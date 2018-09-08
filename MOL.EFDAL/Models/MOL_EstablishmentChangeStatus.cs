namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentChangeStatus
    {
		[DataMember]
        public long PK_EstablishmentChangeStatus { get; set; }
		[DataMember]
        public string Reason { get; set; }
		[DataMember]
        public string Notes { get; set; }
		[DataMember]
        public string CommercialRecordCancellationNumber { get; set; }
		[DataMember]
        public System.DateTime? CommercialRecordCancellationDate { get; set; }
		[DataMember]
        public string MunicipalLicenseCancellationNumber { get; set; }
		[DataMember]
        public System.DateTime? MunicipalLicenseCancellationDate { get; set; }
		[DataMember]
        public long FK_EstablishmentID { get; set; }
		[DataMember]
        public int FK_EstablishmentStatusId { get; set; }
		[DataMember]
        public long UserID { get; set; }
		[DataMember]
        public virtual Enum_EstablishmentStatus Enum_EstablishmentStatus { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
