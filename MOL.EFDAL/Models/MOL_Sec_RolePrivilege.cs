namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_RolePrivilege
    {
		[DataMember]
        public long Role_Id { get; set; }
		[DataMember]
        public long Privilege_Id { get; set; }
		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public virtual MOL_Sec_Privilege MOL_Sec_Privilege { get; set; }
		[DataMember]
        public virtual MOL_Sec_Role MOL_Sec_Role { get; set; }
    }
}
