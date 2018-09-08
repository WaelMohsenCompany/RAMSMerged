namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_RunAwayCancelRequests
    {
		[DataMember]
        public long PK_RequestID { get; set; }
		[DataMember]
        public long CurrentUser_ID { get; set; }
		[DataMember]
        public string RunAwayID { get; set; }
		[DataMember]
        public string CurrentUserIDNo { get; set; }
		[DataMember]
        public long Fk_EstablishmentID { get; set; }
		[DataMember]
        public int ReqStatus { get; set; }
		[DataMember]
        public string Reject_Reason_Desc { get; set; }
		[DataMember]
        public string NIC_ResultCode { get; set; }
		[DataMember]
        public string NIC_ResultMessage { get; set; }
		[DataMember]
        public System.DateTime RequestDate { get; set; }
		[DataMember]
        public long? DecisionTakenByUser_ID { get; set; }
    }
}
