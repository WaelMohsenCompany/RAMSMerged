namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_Group
    {
        public MOL_Sec_Group()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_name { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Sec_Role> MOL_Sec_Role { get; set; } = new List<MOL_Sec_Role>();
    }
}
