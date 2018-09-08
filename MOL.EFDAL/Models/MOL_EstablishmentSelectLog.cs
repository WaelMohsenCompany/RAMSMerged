namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentSelectLog
    {
		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public int ActualUserType { get; set; }
		[DataMember]
        public long EstablishmentID { get; set; }
		[DataMember]
        public long? LoggedUserID { get; set; }
		[DataMember]
        public long LoggedUserIdNo { get; set; }
		[DataMember]
        public long ImpersonatedUserIdNo { get; set; }
		[DataMember]
        public int? ImpersonatedUserType { get; set; }
		[DataMember]
        public string ServerIP { get; set; }
		[DataMember]
        public string ClientIP { get; set; }
		[DataMember]
        public string SessionID { get; set; }
		[DataMember]
        public System.DateTime TimeStamp { get; set; }
    }
}
