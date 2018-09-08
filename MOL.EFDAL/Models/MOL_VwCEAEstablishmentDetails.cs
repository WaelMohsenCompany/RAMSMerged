namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwCEAEstablishmentDetails
    {
		[DataMember]
        public long PK_EstablishmentId { get; set; }
		[DataMember]
        public int FK_LaborOfficeId { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public string EstablishmentName { get; set; }
		[DataMember]
        public int? MainEconomicActivityId { get; set; }
		[DataMember]
        public string MainEconomicActivity { get; set; }
		[DataMember]
        public int? SubEconomicActivityId { get; set; }
		[DataMember]
        public string SubEconomicActivity { get; set; }
		[DataMember]
        public int? PendingRequestsCount { get; set; }
		[DataMember]
        public int? ApprovedRequestsCount { get; set; }
		[DataMember]
        public string EconomicActivityText { get; set; }
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
        public System.DateTime? CommercialRecordConfirmationDate { get; set; }
    }
}
