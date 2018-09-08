namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaActivityPeriod
    {
		[DataMember]
        public int ActivityID { get; set; }
		[DataMember]
        public int ValidityPeriodDays { get; set; }
		[DataMember]
        public int? ApprovedRequestWaitingPeriod { get; set; }
		[DataMember]
        public int? CanceledRequestWaitingPeriod { get; set; }
		[DataMember]
        public int? RejectedRequestWaitingPeriod { get; set; }
		[DataMember]
        public int? AutomaticRejectWaitingPeriod { get; set; }
    }
}
