namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ManpowerMenu_Sections
    {
        public ManpowerMenu_Sections()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public virtual ICollection<ManpowerMenu_Groups> ManpowerMenu_Groups { get; set; } = new List<ManpowerMenu_Groups>();
    }
}
