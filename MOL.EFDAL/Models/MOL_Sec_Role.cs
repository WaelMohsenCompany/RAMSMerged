namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_Role
    {
        public MOL_Sec_Role()
        {
        }

		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public int? GroupID { get; set; }
		[DataMember]
        public bool IsSystem { get; set; }
		[DataMember]
        public virtual MOL_Sec_Group MOL_Sec_Group { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Sec_RolePrivilege> MOL_Sec_RolePrivilege { get; set; } = new List<MOL_Sec_RolePrivilege>();

	    [DataMember]
        public virtual ICollection<MOL_Sec_UserRole> MOL_Sec_UserRole { get; set; } = new List<MOL_Sec_UserRole>();
    }
}
