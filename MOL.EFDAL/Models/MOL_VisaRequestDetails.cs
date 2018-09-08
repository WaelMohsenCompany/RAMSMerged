namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaRequestDetails
    {
		[DataMember]
        public long PK_VisaRequestDetailID { get; set; }
		[DataMember]
        public long FK_VisaRequestID { get; set; }
		[DataMember]
        public int Fk_JobID { get; set; }
		[DataMember]
        public int FK_GenderID { get; set; }
		[DataMember]
        public int LaborRequestCount { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public int ApprovedRequestCount { get; set; }
		[DataMember]
        public virtual MOL_VisaRequests MOL_VisaRequests { get; set; }
    }
}
