namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EstablishmentType
    {
        public Enum_EstablishmentType()
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
        public virtual ICollection<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; } = new List<MOL_UnifiedNumber>();
    }
}
