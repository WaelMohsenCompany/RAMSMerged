namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class VW_EstablishmentActivityCorrection
    {
		[DataMember]
        public long PK_EstablishmentActivityCorrection { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public long? SequenceNumber { get; set; }
		[DataMember]
        public int? FK_LaborOfficeId { get; set; }
		[DataMember]
        public string EconomicActivityText { get; set; }
		[DataMember]
        public int? FK_MainEconomicActivityId { get; set; }
		[DataMember]
        public int? FK_SubEconomicActivityId { get; set; }
		[DataMember]
        public string ActivityName { get; set; }
		[DataMember]
        public int? OrgMainEconomicActivityId { get; set; }
		[DataMember]
        public int? OrgSubEconomicActivityId { get; set; }
		[DataMember]
        public string AuthorizedIdNo { get; set; }
		[DataMember]
        public System.DateTime? ExpDate { get; set; }
		[DataMember]
        public bool? IsDeleted { get; set; }
		[DataMember]
        public long PK_EstablishmentId { get; set; }
    }
}
