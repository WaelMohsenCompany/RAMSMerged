namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EmailLanguage
    {
        public Enum_EmailLanguage()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_User> MOL_User { get; set; } = new List<MOL_User>();
    }
}
