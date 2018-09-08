namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Agent
    {
        public MOL_Agent()
        {
        }

		[DataMember]
        public int PK_AgentId { get; set; }
		[DataMember]
        public string AgentName { get; set; }
		[DataMember]
        public string IdNo { get; set; }
		[DataMember]
        public string IdSource { get; set; }
		[DataMember]
        public System.DateTime IdReleaseDate { get; set; }
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
        public int? FK_CurrentLaborOffice { get; set; }
		[DataMember]
        public long? SequenceNumber { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual Lookup_City Lookup_City { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentAgent> MOL_EstablishmentAgent { get; set; } = new List<MOL_EstablishmentAgent>();
    }
}
