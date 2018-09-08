namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaIssueRequests
    {
        public MOL_VisaIssueRequests()
        {
        }

		[DataMember]
        public long PK_VisaIssueRequestID { get; set; }
		[DataMember]
        public long FK_EstablishmentID { get; set; }
		[DataMember]
        public int FK_LaborOfficeID { get; set; }
		[DataMember]
        public int RequestYear { get; set; }
		[DataMember]
        public int Sequence { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public short RequestType { get; set; }
		[DataMember]
        public long FK_VisaRequestID { get; set; }
		[DataMember]
        public short NICStatus { get; set; }
		[DataMember]
        public string NICOutgoingNumber { get; set; }
		[DataMember]
        public decimal? NICOutgoingDate { get; set; }
		[DataMember]
        public long CreatedByUserID { get; set; }
		[DataMember]
        public string RequestedByIDNo { get; set; }
		[DataMember]
        public int CurrentQuota { get; set; }
		[DataMember]
        public int CurrentNitaq { get; set; }
		[DataMember]
        public int TotalLaborRequest { get; set; }
		[DataMember]
        public int CurrentVisaRequestBalance { get; set; }
		[DataMember]
        public int? NICRejectReasonID { get; set; }
		[DataMember]
        public int? FK_ExceptionID { get; set; }
		[DataMember]
        public virtual ICollection<MOL_IssuedVisas> MOL_IssuedVisas { get; set; } = new List<MOL_IssuedVisas>();
	    [DataMember]
        public virtual ICollection<MOL_VisaIssueRequestDetails> MOL_VisaIssueRequestDetails { get; set; } = new List<MOL_VisaIssueRequestDetails>();
    }
}
