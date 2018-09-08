namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_OracleTransactionLog
    {
		[DataMember]
        public long PK_OracleTransactionId { get; set; }
		[DataMember]
        public long FK_Online_Requests { get; set; }
		[DataMember]
        public int FK_ServiceId { get; set; }
		[DataMember]
        public long? FK_UserId { get; set; }
		[DataMember]
        public int Lab_Off { get; set; }
		[DataMember]
        public int Ser_YY { get; set; }
		[DataMember]
        public int Seq_No { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public string RepresentativeIdNo { get; set; }
		[DataMember]
        public int? TransactionStatus { get; set; }
		[DataMember]
        public string OracleResult { get; set; }
		[DataMember]
        public string Error { get; set; }
		[DataMember]
        public bool? isManPower { get; set; }
		[DataMember]
        public System.DateTime? TimeStamp { get; set; }
		[DataMember]
        public virtual Enum_Service Enum_Service { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
        [DataMember]
        public virtual CJD_Online_Requests CJD_Online_Requests { get; set; }
        [DataMember]
        public virtual ST_Online_Requests ST_Online_Requests { get; set; }
    }
}
