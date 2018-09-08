namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_OpenIDLogs
    {
		[DataMember]
        public int OLog_PK { get; set; }
		[DataMember]
        public string OLog_Message { get; set; }
		[DataMember]
        public System.DateTime? OLog_timestamp { get; set; }
    }
}
