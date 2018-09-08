namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_AccountManager : IAuditable
    {
        [DataMember]
        public long PK_AccountManagerID { get; set; }
        [DataMember]
        public long? FK_UserID { get; set; }
        [DataMember]
        public long IDNO { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string ThirdName { get; set; }
        [DataMember]
        public string FourthName { get; set; }
        [DataMember]
        public System.DateTime BirthDate { get; set; }
        [DataMember]
        public short FK_NationalityID { get; set; }
        [DataMember]
        public long FK_UnifiedNumberId { get; set; }
        [DataMember]
        public int FK_AccountManagerTypeId { get; set; }
		[DataMember]
        public System.Guid? FK_AttachmentID { get; set; }
		[DataMember]
        public virtual Enum_AccountManagerType Enum_AccountManagerType { get; set; }
        [DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
        [DataMember]
        public virtual MOL_User MOL_User { get; set; }

        #region [ IAuditable ]
        [IgnoreDataMember]
        public long CurrentUserID { get; set; }

        [IgnoreDataMember]
        public string DBTableName => "MOL_AccountManager";


        private AuditExtraFieldCollection mExtraFields = new AuditExtraFieldCollection();

        [IgnoreDataMember]
        public AuditExtraFieldCollection ExtraFields { get { return mExtraFields; } }
        #endregion
    }
}
