namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_City
    {
        public Lookup_City()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Agent> MOL_Agent { get; set; } = new List<MOL_Agent>();
	    [DataMember]
        public virtual ICollection<MOL_EstablishmentProfile> MOL_EstablishmentProfile { get; set; } = new List<MOL_EstablishmentProfile>();
	    [DataMember]
        public virtual ICollection<MOL_LaborOffice> MOL_LaborOffice { get; set; } = new List<MOL_LaborOffice>();
	    [DataMember]
        public virtual ICollection<MOL_Owner> MOL_Owner { get; set; } = new List<MOL_Owner>();
    }
}
