namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaRequestImmediateApproveDetails
    {
		[DataMember]
        public long ID { get; set; }
		[DataMember]
        public long? FK_VisaRequestID { get; set; }
		[DataMember]
        public bool? HasNoActiveNote { get; set; }
		[DataMember]
        public bool? HasNoFemaleJob { get; set; }
		[DataMember]
        public bool? HasNoGovSupportJob { get; set; }
		[DataMember]
        public bool? HasValidEstNitaq { get; set; }
		[DataMember]
        public int? EstablishmentColorID { get; set; }
		[DataMember]
        public int? RequestedVISAsCount { get; set; }
		[DataMember]
        public int? AllowedNitaqLimit { get; set; }
		[DataMember]
        public int? UnusedVISACredit { get; set; }
		[DataMember]
        public int? MinimumForeigners { get; set; }
		[DataMember]
        public int? AutoApprovalQuota { get; set; }
		[DataMember]
        public bool? ExistsInNitaqatHistoryDB { get; set; }
		[DataMember]
        public bool? WithinAllowedRunawayRequestPecentage { get; set; }
		[DataMember]
        public int? RunawayRequests { get; set; }
		[DataMember]
        public int? ForeignersLaborersCount { get; set; }
		[DataMember]
        public decimal? RunawayRequestsPercentage { get; set; }
		[DataMember]
        public decimal? AllowedRunawayRequestsPercentage { get; set; }
		[DataMember]
        public bool? WithinAllowedTransferedNewComersPecentage { get; set; }
		[DataMember]
        public int? NewComersCount { get; set; }
		[DataMember]
        public int? TransferedNewComersCount { get; set; }
		[DataMember]
        public decimal? TransferedNewComersPercentage { get; set; }
		[DataMember]
        public decimal? AllowedTransferedNewComersPercentage { get; set; }
		[DataMember]
        public bool? EconomicActivityAllowed { get; set; }
    }
}
