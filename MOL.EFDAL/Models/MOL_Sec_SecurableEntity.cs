namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_SecurableEntity : IAuditable
    {
        public MOL_Sec_SecurableEntity()
        {
        }

        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Securable_Entity_Type_Id { get; set; }
        [DataMember]
        public string Securable_Entity_Id { get; set; }
        [DataMember]
        public virtual Lookup_SecurableEntityType Lookup_SecurableEntityType { get; set; }
        [DataMember]
        public virtual ICollection<MOL_Sec_UserEntityPrivilege> MOL_Sec_UserEntityPrivilege { get; set; } = new List<MOL_Sec_UserEntityPrivilege>();

        [DataMember]
        public virtual ICollection<MOL_Sec_UserRole> MOL_Sec_UserRole { get; set; } = new List<MOL_Sec_UserRole>();

        [DataMember]
        public virtual ICollection<MOL_Sec_UserRevokePrivilege> MOL_Sec_UserRevokePrivilege { get; set; } = new List<MOL_Sec_UserRevokePrivilege>();

        #region [ IAuditable ]
        public long CurrentUserID { get; set; }
        public string DBTableName => "MOL_Sec_SecurableEntity";

        private AuditExtraFieldCollection mExtraFields = new AuditExtraFieldCollection();
        public AuditExtraFieldCollection ExtraFields { get { return mExtraFields; } }
        #endregion
    }
}
