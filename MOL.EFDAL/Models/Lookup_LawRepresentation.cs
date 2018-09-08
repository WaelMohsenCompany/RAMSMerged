namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_LawRepresentation
    {
        public Lookup_LawRepresentation()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public virtual ICollection<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; } = new List<MOL_UnifiedNumber>();
    }
}
