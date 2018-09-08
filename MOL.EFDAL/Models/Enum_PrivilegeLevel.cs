namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_PrivilegeLevel
    {
        public Enum_PrivilegeLevel()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Sec_Privilege> MOL_Sec_Privilege { get; set; } = new List<MOL_Sec_Privilege>();
    }
}
