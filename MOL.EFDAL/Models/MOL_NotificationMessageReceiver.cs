namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_NotificationMessageReceiver
    {
		[DataMember]
        public long FK_UserID { get; set; }
		[DataMember]
        public long FK_NotificationMessageID { get; set; }
		[DataMember]
        public string SMSReceiver { get; set; }
		[DataMember]
        public string EmailTo { get; set; }
		[DataMember]
        public virtual MOL_NotificationMessage MOL_NotificationMessage { get; set; }
    }
}
