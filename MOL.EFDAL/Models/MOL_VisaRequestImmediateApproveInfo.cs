namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaRequestImmediateApproveInfo
    {
		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public long FK_VisaRequestID { get; set; }
		[DataMember]
        public string ImmediateApproveCondition { get; set; }
		[DataMember]
        public string ImmediateApproveValue { get; set; }
    }
}
