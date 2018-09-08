namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Owner
    {
        public MOL_Owner()
        {
        }

		[DataMember]
        public int PK_OwnerId { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public short? FK_NationalityId { get; set; }
		[DataMember]
        public string IdNo { get; set; }
		[DataMember]
        public System.DateTime? IdExpiryDate { get; set; }
		[DataMember]
        public string IdSource { get; set; }
		[DataMember]
        public int? FK_GenderId { get; set; }
		[DataMember]
        public int FK_CityId { get; set; }
		[DataMember]
        public string District { get; set; }
		[DataMember]
        public string Street { get; set; }
		[DataMember]
        public string PostalCode { get; set; }
		[DataMember]
        public string ZipCode { get; set; }
		[DataMember]
        public string Telephone1 { get; set; }
		[DataMember]
        public string Telephone2 { get; set; }
		[DataMember]
        public string Fax { get; set; }
		[DataMember]
        public int? FK_CurrentLaborOfficeId { get; set; }
		[DataMember]
        public bool? UpdatedByMOI { get; set; }
		[DataMember]
        public string MOIName { get; set; }
		[DataMember]
        public bool? IsVerified { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual Enum_Gender Enum_Gender { get; set; }
		[DataMember]
        public virtual Lookup_City Lookup_City { get; set; }
		[DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
		[DataMember]
        public virtual ICollection<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; } = new List<MOL_UnifiedNumber>();
    }
}
