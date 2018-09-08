namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class InstanceState
    {
		[DataMember]
        public System.Guid uidInstanceID { get; set; }
		[DataMember]
        public byte[] state { get; set; }
		[DataMember]
        public int? status { get; set; }
		[DataMember]
        public int? unlocked { get; set; }
		[DataMember]
        public int? blocked { get; set; }
		[DataMember]
        public string info { get; set; }
		[DataMember]
        public System.DateTime modified { get; set; }
		[DataMember]
        public System.Guid? ownerID { get; set; }
		[DataMember]
        public System.DateTime? ownedUntil { get; set; }
		[DataMember]
        public System.DateTime? nextTimer { get; set; }
    }
}
