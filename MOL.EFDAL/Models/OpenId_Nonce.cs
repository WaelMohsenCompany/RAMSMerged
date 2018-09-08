namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OpenId_Nonce
    {
		[DataMember]
        public string Context { get; set; }
		[DataMember]
        public string Code { get; set; }
		[DataMember]
        public System.DateTime Issued { get; set; }
		[DataMember]
        public System.DateTime Expires { get; set; }
    }
}
