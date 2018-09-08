namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OpenId_AuthToken
    {
		[DataMember]
        public int TokenId { get; set; }
		[DataMember]
        public string Token { get; set; }
		[DataMember]
        public string TokenSecret { get; set; }
		[DataMember]
        public int ConsumerId { get; set; }
		[DataMember]
        public long UserId { get; set; }
		[DataMember]
        public int State { get; set; }
		[DataMember]
        public System.DateTime IssueDate { get; set; }
		[DataMember]
        public string Scope { get; set; }
		[DataMember]
        public string RequestTokenVerifier { get; set; }
		[DataMember]
        public string RequestTokenCallback { get; set; }
		[DataMember]
        public string ConsumerVersion { get; set; }
    }
}
