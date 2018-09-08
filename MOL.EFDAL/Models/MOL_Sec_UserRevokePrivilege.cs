namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_UserRevokePrivilege
    {
		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public long IdNo { get; set; }
		[DataMember]
        public long? User_Id { get; set; }
		[DataMember]
        public long Privilege_Id { get; set; }
		[DataMember]
        public long FK_SecurableEntityId { get; set; }
		[DataMember]
        public virtual MOL_Sec_Privilege MOL_Sec_Privilege { get; set; }
		[DataMember]
        public virtual MOL_Sec_SecurableEntity MOL_Sec_SecurableEntity { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
