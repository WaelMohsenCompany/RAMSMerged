namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EstablishmentStatus
    {
        public Enum_EstablishmentStatus()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Establishment> MOL_Establishment { get; set; } = new List<MOL_Establishment>();

	    [DataMember]
        public virtual ICollection<MOL_EstablishmentChangeStatus> MOL_EstablishmentChangeStatus { get; set; } = new List<MOL_EstablishmentChangeStatus>();
    }
}
