namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ManpowerMenu_Groups
    {
        public ManpowerMenu_Groups()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public int? Order { get; set; }
		[DataMember]
        public int? SectionID { get; set; }
		[DataMember]
        public virtual ICollection<ManpowerMenu_Groups_EntityTypes> ManpowerMenu_Groups_EntityTypes { get; set; } = new List<ManpowerMenu_Groups_EntityTypes>();

	    [DataMember]
        public virtual ManpowerMenu_Sections ManpowerMenu_Sections { get; set; }
    }
}
