namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaIssuePrivateContract
    {
		[DataMember]
        public long PK_PrivateContractID { get; set; }
		[DataMember]
        public long FK_VisaRequestID { get; set; }
		[DataMember]
        public string ContractNumber { get; set; }
		[DataMember]
        public string ContractorName { get; set; }
		[DataMember]
        public string ContractPlace { get; set; }
		[DataMember]
        public double? ContractBudget { get; set; }
		[DataMember]
        public System.DateTime? ContractStartDate { get; set; }
		[DataMember]
        public System.DateTime? ContractEndDate { get; set; }
		[DataMember]
        public long CreatedByUserID { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public virtual MOL_VisaRequests MOL_VisaRequests { get; set; }
    }
}
