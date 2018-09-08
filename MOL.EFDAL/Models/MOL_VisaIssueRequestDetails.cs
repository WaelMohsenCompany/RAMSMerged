namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaIssueRequestDetails
    {
		[DataMember]
        public long PK_VisaIssueRequestDetailID { get; set; }
		[DataMember]
        public long FK_VisaIssueRequestID { get; set; }
		[DataMember]
        public int Fk_JobID { get; set; }
		[DataMember]
        public int FK_NationalityID { get; set; }
		[DataMember]
        public int FK_OriginID { get; set; }
		[DataMember]
        public int FK_ReligionID { get; set; }
		[DataMember]
        public int FK_GenderID { get; set; }
		[DataMember]
        public int LaborRequestCount { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public virtual MOL_VisaIssueRequests MOL_VisaIssueRequests { get; set; }
    }
}
