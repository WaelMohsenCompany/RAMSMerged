namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_OpenId_Consumer
    {
		[DataMember]
        public string ConsumerKey { get; set; }
		[DataMember]
        public string Secret { get; set; }
		[DataMember]
        public string Callback { get; set; }
		[DataMember]
        public int ConsumerId { get; set; }
		[DataMember]
        public string VerificationCodeFormat { get; set; }
		[DataMember]
        public string VerificationCodeLength { get; set; }
    }
}
