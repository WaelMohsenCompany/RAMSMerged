namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_UserRole : IAuditable
    {
        [DataMember]
        public long? User_Id { get; set; }
        [DataMember]
        public long Role_Id { get; set; }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long? IDNO { get; set; }
        [DataMember]
        public bool? IsStopRole { get; set; }
        [DataMember]
        public System.DateTime? StartDate { get; set; }
        [DataMember]
        public System.DateTime? EndDate { get; set; }
        [DataMember]
        public long? FK_SecurableEntityId { get; set; }
        [DataMember]
        public virtual MOL_Sec_Role MOL_Sec_Role { get; set; }
        [DataMember]
        public virtual MOL_Sec_SecurableEntity MOL_Sec_SecurableEntity { get; set; }
        [DataMember]
        public virtual MOL_User MOL_User { get; set; }

        #region [ IAuditable ]
        public long CurrentUserID { get; set; }
        public string DBTableName => "MOL_Sec_UserRole";

        private AuditExtraFieldCollection mExtraFields = new AuditExtraFieldCollection();
        public AuditExtraFieldCollection ExtraFields { get { return mExtraFields; } }
        #endregion
    }
}
