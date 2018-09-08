namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Religion
    {
        public Lookup_Religion()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public bool? IsIncludedForEWV { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();
    }
}
