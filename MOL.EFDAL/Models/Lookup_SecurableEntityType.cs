namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_SecurableEntityType
    {
        public Lookup_SecurableEntityType()
        {
        }

		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public bool IsSystem { get; set; }
		[DataMember]
        public virtual ICollection<ManpowerMenu_Groups_EntityTypes> ManpowerMenu_Groups_EntityTypes { get; set; } = new List<ManpowerMenu_Groups_EntityTypes>();

	    [DataMember]
        public virtual ICollection<MOL_Sec_Privilege> MOL_Sec_Privilege { get; set; } = new List<MOL_Sec_Privilege>();

	    [DataMember]
        public virtual ICollection<MOL_Sec_SecurableEntity> MOL_Sec_SecurableEntity { get; set; } = new List<MOL_Sec_SecurableEntity>();
    }
}
