namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_Privilege
    {
        public MOL_Sec_Privilege()
        {
        }

		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public long? Securable_Entity_Type_Id { get; set; }
		[DataMember]
        public bool IsSystem { get; set; }
		[DataMember]
        public int? FK_PrivilegeLevelID { get; set; }
		[DataMember]
        public virtual Enum_PrivilegeLevel Enum_PrivilegeLevel { get; set; }
		[DataMember]
        public virtual Lookup_SecurableEntityType Lookup_SecurableEntityType { get; set; }
		[DataMember]
        public virtual ManpowerMenu ManpowerMenu { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Sec_RolePrivilege> MOL_Sec_RolePrivilege { get; set; } = new List<MOL_Sec_RolePrivilege>();

	    [DataMember]
        public virtual ICollection<MOL_Sec_UserEntityPrivilege> MOL_Sec_UserEntityPrivilege { get; set; } = new List<MOL_Sec_UserEntityPrivilege>();

	    [DataMember]
        public virtual ICollection<MOL_Sec_UserRevokePrivilege> MOL_Sec_UserRevokePrivilege { get; set; } = new List<MOL_Sec_UserRevokePrivilege>();

	    [DataMember]
        public virtual ICollection<Enum_Service> Enum_Service { get; set; } = new List<Enum_Service>();

	    [DataMember]
        public virtual ICollection<MOL_User> MOL_User { get; set; } = new List<MOL_User>();
    }
}
