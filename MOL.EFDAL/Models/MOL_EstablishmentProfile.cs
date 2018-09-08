namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentProfile
    {
        public MOL_EstablishmentProfile()
        {
        }

		[DataMember]
        public long PK_EstablishmentProfileId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public string AddressLine1 { get; set; }
		[DataMember]
        public string AddressLine2 { get; set; }
		[DataMember]
        public int FK_CityId { get; set; }
		[DataMember]
        public string Website { get; set; }
		[DataMember]
        public System.DateTime LastModified { get; set; }
		[DataMember]
        public long FK_LastModifiedUser { get; set; }
		[DataMember]
        public System.DateTime Created { get; set; }
		[DataMember]
        public long FK_CreatedBy { get; set; }
		[DataMember]
        public bool IsActive { get; set; }
		[DataMember]
        public string ActivationStatusChangeReason { get; set; }
		[DataMember]
        public virtual Lookup_City Lookup_City { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User1 { get; set; }
    }
}
