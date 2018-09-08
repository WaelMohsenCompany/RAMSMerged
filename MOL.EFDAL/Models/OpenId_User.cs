namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OpenId_User
    {
		[DataMember]
        public long UserId { get; set; }
		[DataMember]
        public string OpenIDClaimedIdentifier { get; set; }
		[DataMember]
        public string OpenIDFriendlyIdentifier { get; set; }
    }
}
