namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_CancelVisaRequest
    {
		[DataMember]
        public long PK_RequestId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public long FK_RequesterId { get; set; }
		[DataMember]
        public string OOUT_No { get; set; }
		[DataMember]
        public string BorderNo { get; set; }
		[DataMember]
        public System.DateTime TimeStamp { get; set; }
		[DataMember]
        public string NICResponse { get; set; }
		[DataMember]
        public long isManPower { get; set; }
		[DataMember]
        public string RequesterIdNo { get; set; }
		[DataMember]
        public bool? VisaCreditRefundResponce { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
