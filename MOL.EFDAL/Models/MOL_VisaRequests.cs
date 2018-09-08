namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaRequests
    {
        public MOL_VisaRequests()
        {
        }

		[DataMember]
        public long PK_VisaRequestID { get; set; }
		[DataMember]
        public long FK_EstablishmentID { get; set; }
		[DataMember]
        public int FK_LaborOfficeID { get; set; }
		[DataMember]
        public int RequestYear { get; set; }
		[DataMember]
        public int Sequence { get; set; }
		[DataMember]
        public int LastStatus { get; set; }
		[DataMember]
        public System.DateTime? ExpiryDate { get; set; }
		[DataMember]
        public int? ValidityMonths { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public System.DateTime LastUpdatedDate { get; set; }
		[DataMember]
        public int RequestedVisaTotal { get; set; }
		[DataMember]
        public int ApprovedVisaTotal { get; set; }
		[DataMember]
        public int RequestType { get; set; }
		[DataMember]
        public long? LockedByUserID { get; set; }
		[DataMember]
        public System.DateTime? LockTime { get; set; }
		[DataMember]
        public short DecisionFlag { get; set; }
		[DataMember]
        public System.DateTime? DecisionDate { get; set; }
		[DataMember]
        public int ReservedVisaTotal { get; set; }
		[DataMember]
        public int IssuedVisaTotal { get; set; }
		[DataMember]
        public long? AssingedToUserID { get; set; }
		[DataMember]
        public System.DateTime? AssingTime { get; set; }
		[DataMember]
        public int ReturnToEstCount { get; set; }
		[DataMember]
        public bool isImmediateCredit { get; set; }
		[DataMember]
        public virtual ICollection<MOL_VisaIssuePrivateContract> MOL_VisaIssuePrivateContract { get; set; } = new List<MOL_VisaIssuePrivateContract>();

	    [DataMember]
        public virtual ICollection<MOL_VisaRequestDetails> MOL_VisaRequestDetails { get; set; } = new List<MOL_VisaRequestDetails>();
    }
}
