namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OpenId_Association
    {
		[DataMember]
        public string DistinguishingFactor { get; set; }
		[DataMember]
        public string Handle { get; set; }
		[DataMember]
        public System.DateTime Expires { get; set; }
		[DataMember]
        public byte[] PrivateData { get; set; }
    }
}
