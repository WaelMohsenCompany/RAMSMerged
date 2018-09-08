namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwUserEstablishments
    {
		[DataMember]
        public long? PK_AuthorizedId { get; set; }
		[DataMember]
        public string AuthorizedIdNo { get; set; }
		[DataMember]
        public long? PK_AuthorizationId { get; set; }
		[DataMember]
        public long PK_EstablishmentId { get; set; }
		[DataMember]
        public int FK_LaborOfficeId { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public int AuthorizedType { get; set; }
		[DataMember]
        public string AuthorizedName { get; set; }
		[DataMember]
        public bool? IsVerified { get; set; }
    }
}
